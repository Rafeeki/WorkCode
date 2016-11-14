from pylab import *
from scipy.optimize import curve_fit

t = array([0,184,526,867,1877])
Ca_t = array([2.33,2.08,1.67,1.36,0.72])
Ca_o = Ca_t[0]
ln_Ca = - log(Ca_t/Ca_o)

def func(x,a,b):
        return a + b*x
        
a_fit,cov = curve_fit(func,t,ln_Ca)

K_1 = a_fit[1]
dK_1 = sqrt(cov[1][1])
print 'K_1 = %g, with uncertainty %g' % (K_1, dK_1)

Ca_2 = (1/Ca_o - 1/Ca_t)
a_fit2,cov2 = curve_fit(func,t,Ca_2)
K_2 = a_fit2[1]
dK_2 = sqrt(cov2[1][1])
print 'K_2 = %g, with uncertainty %g' % (K_2, dK_2)

Ca_3 = .5*array([1/(2.33*2.33)- 1/(Ca_o*Ca_o),1/(2.08*2.08)- 1/(Ca_o*Ca_o),1/(1.67*1.67)- 1/(Ca_o*Ca_o),1/(1.36*1.36)- 1/(Ca_o*Ca_o),1/(0.72*0.72)- 1/(Ca_o*Ca_o)]) 
a_fit3,cov3 = curve_fit(func,t,Ca_3)
K_3 = a_fit3[1]
dK_3 = sqrt(cov3[1][1])
print 'K_3 = %g, with uncertainty %g' % (K_3, dK_3)