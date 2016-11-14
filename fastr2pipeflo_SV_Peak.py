import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlo Extract with Modeling Factor.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()
 
# Read the data file

lincount = 3
lineup = "Connected Peak"
errors = 0
updates = 0

while lincount < 10:
	doc.set_current_lineup(lineup)
	with open( data_file_path ) as csvfile:
	 
		reader = csv.reader( csvfile )
		next(reader, None)
		
		
		for data_col in reader:
		
			if not data_col: break
			sizing_valve_name = data_col[0]														#EDIT THIS VALUE DEPENDING ON WHAT COLUMN DPOC_SEGMENT_FPOC IS
			flow_value = data_col[lincount]														#EDIT THIS VALUE DEPENDING ON WHAT COLUMN THE DEMANDS ARE IN
						
			try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
				p = doc.get_sizing_valve( sizing_valve_name )	 								#assign demand name to the variable 'p'
			except RuntimeError:  																#check for runtime error (non-existent demand name)
				print( 'Did not find sizing_valve', sizing_valve_name ) 						#print problem to the output window
				errors += 1  																	#adds 1 to the error count - OPTIONAL
				continue																		#return to the top of the for loop and continue with the next row of data
				
			try: 																				#set environment to test values
				sizing_valve_flow = float( flow_value ) 										#assign the value as a floating point number
			except ValueError: 																	#check for value type error which indicates bad data
				sizing_valve_flow = 0
				print( 'Invalid value type', sizing_valve_name, flow_value ) 					#print problem to the output window
				errors += 1
				continue 
				
			p.set_valve_settings(valve_settings(FCV, flow_rate(sizing_valve_flow,gpm ), pressure(0,psi)))
			
			updates += 1 																		#add 1 to the count of updated demands
		lincount += 3
		if lincount == 6: lineup = "Committed Peak"
		elif lincount == 9: lineup = "Pending Peak"		

print( 'Import finished.' ) 																	#print to the output window
if updates > 0:  																				#if updates exist print count - OPTIONAL
	print( updates, 'items updated.' )
if errors > 0: 																					#if updates exist print count - OPTIONAL
	print( errors, 'errors.' )
