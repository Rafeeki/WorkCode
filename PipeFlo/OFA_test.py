import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'Tool_Export_OFA.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()

file = open("Tool_Export_OFA_Report.csv",'w')

file.write('These components have flow values exceeding their design max.\n')
file.write('Name,FaSTr Flow (scfm),Model Flow (scfm),dP (psi),Head Loss (ft)\n')
nex = []
dne = []

with open( data_file_path ) as csvfile:

	reader = csv.reader( csvfile )
	next(reader,None)
	
	for data_col in reader:
		
		if not data_col: break
		name = data_col[1]
		f_flow = data_col[32]
		
		try:
			t = doc.get_curve_dp(name) 
		except RuntimeError:
			dne.append(name)
			continue
		
		flow = round(t.get_calculated_flow().value,2)
		dp = round(t.get_dp().value,2)
		hl = round(t.get_head_loss().value,2)
		rpt = name + ',' + str(f_flow) + ',' + str(flow) + ',' + str(dp) + ',' +str(hl) + '\n'
		
		if flow > float(f_flow):
			file.write(rpt)
		else:
			nex.append(rpt)

file.write('\nThese components have not exceeded their design max.\n')
file.write('Name,FaSTr Flow (scfm),Model Flow (scfm),dP (psi),Head Loss (ft)\n')
for i in range(0,len(nex)):
	file.write(nex[i])

file.write('\nThese components do not exist in the model.\n')
file.write('Name\n')
for j in range(0,len(dne)):
	file.write(dne[j] + '\n')
	
print('Evaluation complete.')