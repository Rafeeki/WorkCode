from __future__ import print_function

import dateutil.parser
import trustedanalytics as tap

mode = None
frame = None

# record:
# {
#   "DateTime":"2016-09-01T00:00:43Z",
#   "Value":238,
#   "CustomData":[
#       {"Type":1,"Value":0},
#       {"Type":2,"Value":0},
#       {"Type":3,"Value":1}],
#   "Min":0,
#   "MinDateTime":"0001-01-01T00:00:00",
#   "Max":0,
#   "MaxDateTime":"0001-01-01T00:00:00"
# }

schema = [
    ('datetime', tap.datetime),
    ('sensor', str),
    ('value', tap.float32)
]

def connect(atk_url, credential):
    global mode

    if not mode is None:
        return

    try:
        import trustedanalytics as tap
        tap.server.uri = atk_url
        tap.connect(credential)
        print('connected to ATK')
        mode = 'cluster'
    except:
        print('failed to connect to ATK')
        mode = 'local'


def get_frame(name):
    global frame

    if mode is None or mode == 'local':
        print('Warning: Not connected to ATK')
        return

    if not frame is None:
        return frame

    frames = tap.get_frame_names()

    if name in frames:
        return tap.get_frame(name)

    frame = tap.Frame(tap.UploadRows([], schema))
    frame.name = name

    return frame


def upload_rows(frame_name, names, rows):
    if mode is None or mode == 'local':
        print('Warning: Not connected to ATK')
        return
    rs = [None]*len(rows)*100
    k = 0
    l = 0
    for r in rows:
        for j in range(len(r)):
            rs[l] = [[r[j]['DateTime'], names[k], r[j]['Value']]]
        l = l + 1
        k = k + 1

    rs1 = [r1 for r1 in rs if r1 != None]
    f = get_frame(frame_name)
    f.append(tap.UploadRows(rs, schema))


def get_latest_record(frame_name):
    f = get_frame(frame_name)
    if f.row_count == 0:
        return None

    return dateutil.parser.parse(f.take(1, offset=f.row_count-1, columns='datetime')[0][0])