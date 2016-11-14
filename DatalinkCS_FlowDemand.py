import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'DatalinkCS_FlowDemand.csv')							# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()
 
# Read the data file

errors = 0
updates = 0


with open( data_file_path ) as csvfile:
	 
	reader = csv.reader( csvfile )
	next(reader, None)
	next(reader, None)

	for data_col in reader:
		
		if not data_col: break
		flow_demand_name = data_col[2]														#EDIT THIS VALUE DEPENDING ON WHAT COLUMN DPOC_SEGMENT_FPOC IS
		flow_value = data_col[9] 															#EDIT THIS VALUE DEPENDING ON WHAT COLUMN THE DEMANDS ARE IN
			
		try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
			p = doc.get_flow_demand( flow_demand_name )	 									#assign demand name to the variable 'p'
		except RuntimeError:  																#check for runtime error (non-existent demand name)
			print( 'Did not find flow_demand', flow_demand_name )	 						#print problem to the output window
			errors += 1  																	#adds 1 to the error count - OPTIONAL
			continue																		#return to the top of the for loop and continue with the next row of data
					
		try: 																				#set environment to test values
			flow_demand_flow = float( flow_value ) 											#assign the value as a floating point number
		except ValueError: 																	#check for value type error which indicates bad data
			flow_demand_flow = 0
			print( 'Invalid value type', flow_demand_name, flow_value ) 					#print problem to the output window
			errors += 1
			continue 
					
		p.set_flow(flow_demand_flow)
			
		updates += 1 																		#add 1 to the count of updated demands
		
print( 'Import finished.' ) 																	#print to the output window
if updates > 0:  																				#if updates exist print count - OPTIONAL
	print( updates, 'items updated.' )
if errors > 0: 																					#if updates exist print count - OPTIONAL
	print( errors, 'errors.' )
