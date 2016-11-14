import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlow Testing.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()
 
# Read the data file
 
errors = 0
updates = 0

with open( data_file_path ) as csvfile:
 
	reader = csv.reader( csvfile )
	
	for data_row in reader:
	
		if not data_row: break
		control_valve_name = data_row[1]													#EDIT THIS VALUE DEPENDING ON WHAT COLUMN DPOC_SEGMENT_FPOC IS
		flow_value = data_row[2]															#EDIT THIS VALUE DEPENDING ON WHAT COLUMN THE DEMANDS ARE IN
		bypass = data_row[3]			
		# print(control_valve_name, flow_value, bypass)

		try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
			p = doc.get_control_valve( control_valve_name )	 								#assign demand name to the variable 'p'
		except RuntimeError:  																#check for runtime error (non-existent demand name)
			print( 'Did not find control_valve', control_valve_name ) 						#print problem to the output window
			errors += 1  																	#adds 1 to the error count - OPTIONAL
			continue																		#return to the top of the for loop and continue with the next row of data
			
		try: 																				#set environment to test values
			control_valve_flow = float( flow_value ) 										#assign the value as a floating point number
		except ValueError: 																	#check for value type error which indicates bad data
			control_valve_flow = 0
			print( 'Invalid value type', control_valve_name, flow_value ) 					#print problem to the output window
			errors += 1
		p.set_spec_valve_settings(spec_valve_settings(FCV, flow_rate(control_valve_flow,gpm ), pressure(0,psi), 0))
		continue 
		updates += 1 																		#add 1 to the count of updated demands

print( 'Import finished.' ) 																#print to the output window
if updates > 0:  																			#if updates exist print count - OPTIONAL
	print( updates, 'items updated.' )
if errors > 0: 																				#if updates exist print count - OPTIONAL
	print( errors, 'errors.' )
