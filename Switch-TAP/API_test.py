import requests

resp = requests.get('https://api.switchautomation.com/v1/projects/00f23762/installations/c9c73343-46a4-45fd-9d53-01812f55dc7a/devices/da1501b6-4ec4-431f-a5ac-3968b6e120f0/sensors')
#if resp.status_code != 200:
    # This means something went wrong.
    #raise ApiError('GET /tasks/ {}'.format(resp.status_code))
for sensor in resp.json():
    print('{} {}'.format(sensor['id'], sensor['summary']))
