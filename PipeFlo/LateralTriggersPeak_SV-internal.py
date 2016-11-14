import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlo Extract with Modeling Factor.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()
 
# Read the data file

lineup = "Pending Peak"
errors = 0
updates = 0
factor = 1
laterals = []
dmaxs = []
trigs = []

for count in range(1,5):
	doc.set_current_lineup(lineup)
	lat_count = 0
	with open( data_file_path ) as csvfile:
	 
		reader = csv.reader( csvfile )
		next(reader, None)

		for data_col in reader:
		
			if not data_col: break
			sizing_valve_name = data_col[0]														#EDIT THIS VALUE DEPENDING ON WHAT COLUMN DPOC_SEGMENT_FPOC IS
			flow_value = data_col[9] 															#EDIT THIS VALUE DEPENDING ON WHAT COLUMN THE DEMANDS ARE IN

			cur_lat = data_col[12]								#cur_lat receives this row's dp_segment_name
			cur_dmax = data_col[13]								#cur_dmax receives this row's design_max
			cur_trig = data_col[15]								#cur_trig receives this row's trigger value
			if cur_lat not in laterals:							#if this row's dp_segment_name hasn't already been stored in laterals
				laterals.append( cur_lat )						#store this row's dp_segment_name in the latest entry in laterals
				dmaxs.append( int(cur_dmax) )						#store this row's design_max in the latest entry in dmaxs
				trigs.append( float(cur_trig) )						#store this row's trigger in the latest entry in trigs
					
			try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
				p = doc.get_sizing_valve( sizing_valve_name )	 								#assign demand name to the variable 'p'
			except RuntimeError:  																#check for runtime error (non-existent demand name)
				print( 'Did not find sizing_valve', sizing_valve_name ) 						#print problem to the output window
				errors += 1  																	#adds 1 to the error count - OPTIONAL
				continue																		#return to the top of the for loop and continue with the next row of data
					
			try: 																				#set environment to test values
				sizing_valve_flow = float( flow_value ) * factor 										#assign the value as a floating point number
			except ValueError: 																	#check for value type error which indicates bad data
				sizing_valve_flow = 0
				print( 'Invalid value type', sizing_valve_name, flow_value ) 					#print problem to the output window
				errors += 1
				continue 
					
			p.set_valve_settings(valve_settings(FCV, flow_rate(sizing_valve_flow,gpm ), pressure(0,psi)))
			
			updates += 1 																		#add 1 to the count of updated demands
	
	print('\n' + lineup + '\n' + 'Lateral Name \tDesign Max \t\tTrigger Flow \tCalc Flow \t\tVelocity \tdp per 100')
	
	doc.calculate_and_refresh()		#calculate the given lineup for evaluation
	
	for l in range(0, len(laterals)):					

		#try: 
		p = doc.get_pipe( laterals[l] )
		#except RuntimeError: 
		p_f = round(p.get_calculated_flow().value,2)
		v_f = round(p.get_velocity().value,2)
		# v_f-u = v_f.unit_label().value
		dp = round(p.get_dp_per_100().value,2)
		# dp-u = dp.unit_label().value
		
		if p_f > trigs[l]: 
			print(laterals[l] + '\t' + str(dmaxs[l]) + '\t\t' + str(trigs[l]) + '\t' + str(p_f) + '\t\t' + str(v_f) + '\t' + str(dp))
			lat_count += 1
		# else: print(laterals[l] + ' is NOT exceeding the trigger value: ' + str(p_f) + ' < ' + str(trigs[l]) + '\n')
	
	if lat_count == 0: print('None exceeded trigger')
	
	if count == 1:					#if you've run through the first iteration
		factor = 1.1				#change factor to 1.1 to enter 110% of flow
		lineup = "1.1x"				#change lineup to '1.1x' to enter 110% of flow
	
	elif count == 2:				#if you've run through the second iteration
		factor = 1.2				#change factor to 1.2 to enter 120% of flow
		lineup = "1.2x"				#change lineup to '1.2x' to enter 120% of flow
		
	elif count == 3:				#if you've run through the third iteration
		factor = 1.3				#change factor to 1.3x to enter 130% of flow
		lineup = "1.3x"				#change lineup to '1.3x' to enter 130% of flow
	
# print( count )
# print( factor ) 
# print( 'Import finished.' ) 																	#print to the output window
# if updates > 0:  																				#if updates exist print count - OPTIONAL
	# print( updates, 'items updated.' )
# if errors > 0: 																					#if updates exist print count - OPTIONAL
	# print( errors, 'errors.' )
