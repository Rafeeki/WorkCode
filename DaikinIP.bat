ip access-list extended RNB-IoT-ACL-IN
permit ip any host 224.0.0.2
permit icmp any any 
permit udp any eq bootpc any eq bootps
permit udp any eq bootps any eq bootps
permit udp any any eq domain
REMARK BLOCK Internal VR
Deny ip 172.25.93.128 0.0.0.31 172.25.164.176 0.0.0.15
Deny ip 172.25.164.176 0.0.0.15 172.25.93.128 0.0.0.31
REMARK PERMIT
Permit ip 172.25.93.128 0.0.0.31 any
Permit ip 172.25.164.176 0.0.0.15 any