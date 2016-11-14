from pylab import *

H = array([12.0,2.0,-126.0,-15.0,105.0])
S = array([35.0,-125.0,100.0,-100.0,30.0])
T_C = array([25.0,25.0,25.0,25.0,200.0])
T_K = T_C + 273.15
G = H - ( S / 1000 ) * T_K

res = [0.0,0.0,0.0,0.0,0.0]

for i in range (0,5):
    if G[i] < 0: res[i] = 'Spontaneous'
    else: res[i] = 'Not spontaneous'

print res


Hb = [H[0], H[1], H[3], H[4]]
Sb = [S[0], S[1], S[3], S[4]]
Tb = [0.0,0.0,0.0,0.0]
for i in range(0,4):
    Tb[i] = Hb[i]/( Sb[i] / 1000 )

print Tb