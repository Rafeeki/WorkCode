import pylab
from pylab import *
import numpy

t = array([0,184,526,867,1877])
Ca_t = array([2.33,2.08,1.67,1.36,0.72])
plot(t,Ca_t)
pylab.show()
Ca_o = Ca_t[0]
Ca_1 = zeros(5)
Ca_2 = zeros(5)
Ca_3 = zeros(5)
A = numpy.zeros((2,2))
A_inv = numpy.zeros((2,2))
B = numpy.zeros((2,1))
sum_t = 0.0
sum_t2 = 0.0
sum_k1 = 0
sum_k2 = 0
sum_k3 = 0
sum_Ca_1 = 0
sum_Ca_1t = 0
sum_Ca_2 = 0
sum_Ca_2t = 0
sum_Ca_3 = 0
sum_Ca_3t = 0
b1 = 0
k1 = 0
b2 = 0
k2 = 0
b3 = 0
k3 = 0
n = len(t)
for i in range(0,n):
    sum_t = sum_t + t[i]
    sum_t2 = sum_t2 + t[i]*t[i]
    Ca_1[i] = - log(Ca_t[i]/Ca_o)
    sum_Ca_1 = sum_Ca_1 + Ca_1[i]
    sum_Ca_1t = sum_Ca_1t + t[i]*Ca_1[i]
    Ca_2[i] = (1/Ca_t[i] - 1/Ca_o)
    sum_Ca_2 = sum_Ca_2 + Ca_2[i]
    sum_Ca_2t = sum_Ca_2t + t[i]*Ca_2[i]
    Ca_3[i] = .5*(1/(Ca_t[i]*Ca_t[i]) - 1/(Ca_o*Ca_o))
    sum_Ca_3 = sum_Ca_3 + Ca_3[i]
    sum_Ca_3t = sum_Ca_3t + t[i]*Ca_3[i]
A[0][0] = sum_t2
A[0][1] = -sum_t
A[1][0] = -sum_t
A[1][1] = n
det = 1/(n*sum_t2-sum_t*sum_t)
A_inv = det*A

print 'sum_Ca_1 = %g' % (sum_Ca_1)
print 'sum_Ca_1t = %g' % (sum_Ca_1t)
k1 = A_inv[1][0]*sum_Ca_1 + A_inv[1][1]*sum_Ca_1t
b1 = A_inv[0][0]*sum_Ca_1 + A_inv[0][1]*sum_Ca_1t
print 'k1 = %g and b1 = %g' % (k1,b1)

print 'sum_Ca_2 = %g' % (sum_Ca_2)
print 'sum_Ca_2t = %g' % (sum_Ca_2t)
k2 = A_inv[1][0]*sum_Ca_2 + A_inv[1][1]*sum_Ca_2t
b2 = A_inv[0][0]*sum_Ca_2 + A_inv[0][1]*sum_Ca_2t
print 'k2 = %g and b2 = %g' % (k2,b2)

print 'sum_Ca_3 = %g' % (sum_Ca_3)
print 'sum_Ca_3t = %g' % (sum_Ca_3t)
k3 = A_inv[1][0]*sum_Ca_3 + A_inv[1][1]*sum_Ca_3t
b3 = A_inv[0][0]*sum_Ca_3 + A_inv[0][1]*sum_Ca_3t
print 'k3 = %g and b3 = %g' % (k3,b3)
