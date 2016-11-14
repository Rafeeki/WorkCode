import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlo Extract with Modeling Factor.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()

laterals = []
dmaxs = []
trigs = []
table = []

with open( data_file_path ) as csvfile:
 
	reader = csv.reader( csvfile )
	next(reader, None)

	for data_col in reader:
	
		if not data_col: break
		cur_lat = data_col[12]								#cur_lat receives this row's dp_segment_name
		cur_dmax = data_col[13]								#cur_dmax receives this row's design_max
		cur_trig = data_col[15]								#cur_trig receives this row's trigger value
		if cur_lat not in laterals:							#if this row's dp_segment_name hasn't already been stored in laterals
			laterals.append( cur_lat )						#store this row's dp_segment_name in the latest entry in laterals
			dmaxs.append( cur_dmax )						#store this row's design_max in the latest entry in dmaxs
			trigs.append( float(cur_trig) )						#store this row's trigger in the latest entry in trigs

for l in range(0, len(laterals)):

	p = doc.get_pipe( laterals[l] )
	p_f = round(p.get_calculated_flow().value,2)
	
	print( 'Is ' + laterals[l] + ' exceeding the trigger value?')
	if p_f > trigs[l]: print('Yes, ' + str(p_f) + ' > ' + str(trigs[l]) + '\n')
	else: print('No, ' + str(p_f) + ' < ' + str(trigs[l]) + '\n')
	# if int(p_f) > int(trigs[l]):
		# print( laterals[l], " ",  int(p_f))