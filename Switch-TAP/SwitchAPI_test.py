from csvreader import csvreader
import dateutil.parser
import datetime
import requests
m = csvreader()
latest_record = dateutil.parser.parse('2016-09-01')
params = { 'Start': latest_record, 'End': latest_record + datetime.timedelta(days=1) }
headers = {'X-SwitchApiKey': '7CB30C8B-FE39-4E23-B81A-F0BFB7BA3087'}
proxies = {
    'http' : 'http://proxy.jf.intel.com:911',
    'https': 'http://proxy.jf.intel.com:912'
}
url = 'https://api.switchautomation.com/v1/projects/00f23762/installations/c9c73343-46a4-45fd-9d53-01812f55dc7a/devices/' + m[0][0] + '/sensors/' + m[0][1] + '/readings'
response = requests.get(url, params=params, headers=headers, proxies=proxies)