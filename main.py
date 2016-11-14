from __future__ import print_function

import cherrypy
import datetime
import dateutil.parser
import json
import os
import repeatedtimer
import requests
import sys
from tail import tail
import tap # local helper file
import time
import urllib
import csv

# Variables that are defined by environment variables
SWITCH_AUTOMATION_API_KEY   = os.getenv('SWITCH_AUTOMATION_API_KEY', '7CB30C8B-FE39-4E23-B81A-F0BFB7BA3087')
POLLING_INTERVAL_SECONDS    = int(os.getenv('POLLING_INTERVAL_SECONDS', 120))
PORT                        = int(os.getenv('PORT', 5000))
ATK_URL                     = os.getenv('ATK_URL', 'atk-intel-tmg-cs-4d1a57b8.tapcluster.colfaxresearch.com')
ATK_FRAME                   = os.getenv('ATK_FRAME', 'switch_automation_all')

latest_record = dateutil.parser.parse('2016-09-01')
local_cache = os.path.join(os.path.dirname(os.path.abspath(__file__)), 'cache.json')
credential_file = os.path.join(os.path.dirname(os.path.abspath(__file__)), 'cs.cred')

# Only necessary inside Intel
# Comment this out to push to production. This is an ugly solution to this problem, but then again, so is the Intel proxy.
proxies = {
    'http' : 'http://proxy.jf.intel.com:911',
    'https': 'http://proxy.jf.intel.com:912'
}

# Read csv file for device and sensor IDs
def csvreader():
    data_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), 'SwitchAPI_TAP.csv')
    meters = [None] * 85
    i = 0

    with open(data_path) as csvfile:
        reader = csv.reader(csvfile)
        next(reader, None)
        for data_col in reader:
            meters[i] = [data_col[0], data_col[1], data_col[2]]
            i = i + 1

    return meters


# Write rows to ATK frame
def output_rows(names, rows):
    print('Uploading ' + str(len(rows)) + ' rows')

    # this is useful for testing locally, it's not necessary for production
    with open(local_cache, 'w') as out:
        for row in rows:
            out.write(json.dumps(row))
            out.write('\n')

    tap.upload_rows(ATK_FRAME, names, rows)


def get_latest_record():
    global latest_record
    result = tap.get_latest_record(ATK_FRAME)
    if not result is None:
        latest_record = result

    #### Local Version ####
    #try:
    #    return dateutil.parser.parse(json.loads(tail(local_cache, 1))['DateTime'])
    #except:
    #    return None


# The actual web request to Switch Automation
def request_data(start, end):
    params = { 'Start': start, 'End': end }
    headers = { 'X-SwitchApiKey': SWITCH_AUTOMATION_API_KEY }

    meters = csvreader()
    responses = [None]*len(meters)
    names = [None]*len(meters)

    for i in range(len(meters)):
        url = 'https://api.switchautomation.com/v1/projects/00f23762/installations/c9c73343-46a4-45fd-9d53-01812f55dc7a/' \
              'devices/' + meters[i][1] + '/sensors/' + meters[i][2] + '/readings'
        responses[i] = requests.get(url, params=params, headers=headers, proxies=proxies).json()
        names[i] = meters[i][0]

    return names, responses


# This function is what runs periodically to pull everything together
def process_data():
    global latest_record

    print('Requesting data from Switch Automation')

    names, rows = request_data(latest_record, latest_record + datetime.timedelta(days=1))

    # no rows, we can either skip the whole range or skip up to now
    if len(rows) == 0:
        latest_record = min(latest_record + datetime.timedelta(days=1), datetime.datetime.now())
        return

    latest_record = dateutil.parser.parse(rows[-1][-1]['DateTime'])
    output_rows(names, rows)


# Super simple web root to make Cloud Foundry happy
class Root:

    @cherrypy.expose
    @cherrypy.tools.json_out()
    def index(self):
        return { 'last_record': latest_record.isoformat() }


if __name__ == '__main__':
    try:
        tap.connect(ATK_URL, credential_file)
        get_latest_record()
        rt = repeatedtimer.RepeatedTimer(POLLING_INTERVAL_SECONDS, process_data)

        print('Listening on port ', PORT)
        cherrypy.config.update({ 'server.socket_host': '0.0.0.0',
                                 'server.socket_port': PORT })

        cherrypy.tree.mount(Root(), "/")
        cherrypy.engine.start()

        # managing python threads is stupid and painful
        # so, sleep forever so that we have a place to catch a ctrl-c or other term signal
        # and clean up the web server and timer thread
        while True:
            time.sleep(1e6)

    except (KeyboardInterrupt):
        print('Quitting')
        cherrypy.engine.stop()
        rt.stop()
