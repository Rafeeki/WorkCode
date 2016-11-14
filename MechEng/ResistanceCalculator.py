# Logic for K-value creation based on "Hydraulic Resistance of Tees and Wyes"
# spreadsheet from M&W (?). Input combined flow rate and diameter of the run,
# flow rate and diameter of the branch, whether it is a converging or diverging
# flow, and the angle between the branch and the run. The units for diameters 
# and flows are irrelevant because of the ratios of those two values are used.
# The K-Total value should be added to the combined leg in the model.

import sys, math

def kcalc(Qc, dc, Qb, db, F, a):
		
	Qrat = float(Qb / Qc)
	drat = float(db / dc)

	if F == 'c':
	# The K-run value depends mostly on the angle if converging, and on the ratios if
	# diverging. The K-branch value has a set equation for each of the converging and 
	# diverging scenarios which differ based on their coefficients C, D, G, H and J. 
	# The formulas below calculate the values for both K-run and K-branch depending on
	# this logic.
		if drat > 0.5916:
			if Qrat > 0.4:  C = 0.55
			else: 			C = 0.9*(1-Qrat)
		else: 				C = 1
		
		if a == 90:
							kr = 1.55*Qrat - Qrat**2
							D = 0
		elif a == 60:		
							D = 1
							kr = 1-(1-Qrat)**2-D*(Qrat/drat)**2
		elif a == 45:		
							D = 1.41
							kr = 1-(1-Qrat)**2-D*(Qrat/drat)**2
		else: 				
							D = 1.74
							kr = 1-(1-Qrat)**2-D*(Qrat/drat)**2
							
		kb = C*((1+(Qrat/(drat**2))**2-2*(1-Qrat)**2)-D*(Qrat/drat)**2)
	else:
		if a == 90:
			if drat > .67: 	G = 1+0.3*Qrat**2
			else: 			G = 1
		elif drat > 0.59:
			if Qrat > 0.6:	G = 0.6
			else:			G = 1-0.6*Qrat
		elif Qrat > 0.4:	G = 0.85
		else:				G = 1.1-0.7*Qrat
		
		if drat > 0.63:
			if Qrat > 0.5:	kr = 0.3*(2*Qrat-1)*Qrat**2
			else:			kr = 2*(2*Qrat-1)*Qrat**2
		else:				kr = 0.4*Qrat**2
		
		if a == 90 and drat > 0.666:
							H = 0.3
							J = 0
		else: 				
							H = 1
							J = 2
		kb = G*(1+H*(Qrat/(drat)**2)**2-J*(Qrat/(drat**2)*math.cos(a*math.pi/180)))
		
	ktot = kr + kb
	
	# print 'Krun = %s, Kbranch = %s' % (kr, kb)
	print 'Total K = %s' 			% (ktot)
	return ktot
	

def main():
	Qc = float(sys.argv[1])
	dc = float(sys.argv[2])
	Qb = float(sys.argv[3])
	db = float(sys.argv[4])
	F = str(sys.argv[5])
	a = float(sys.argv[6])
	
	# Qc = float(input('Enter the flow rate of the combined pipe: '))
	# dc = float(input('Enter the diameter of the combined pipe: '))
	# Qb = float(input('Enter the flow rate of the branch pipe: '))
	# db = float(input('Enter the diameter of the branch pipe: '))
	# F = raw_input('Is the flow converging (c) or diverging (d)? ')
	# a = float(input('Enter the angle between the combined pipe and the branch: '))

	kcalc(Qc, dc, Qb, db, F, a)
	
				
if __name__ == '__main__':
	main()
		


