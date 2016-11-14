import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlo Extract with Modeling Factor.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()
model_name = doc.get_file_name()

# Read the data file

lincount = 4
lineup = "Connected Average"
poc = open(dir + '\\POC_Errors_' + model_name + '.csv','w')
poc.write('Lineup,Error Type,POC Name,Invalid Value\n')

while lincount < 11:
	doc.set_current_lineup(lineup)
	errors = 0
	updates = 0
	with open( data_file_path ) as csvfile:
	 
		reader = csv.reader( csvfile )
		next(reader, None)
		
		
		for data_col in reader:
		
			if not data_col: break
			fpoc_name = data_col[0]																#EDIT THIS VALUE DEPENDING ON WHAT COLUMN DPOC_SEGMENT_FPOC IS
			if "BYPASS" in fpoc_name:																#check to see if a UPW bypass valve
				
				sizing_valve_name = fpoc_name
				flow_value = data_col[lincount + 1]													#EDIT THIS VALUE DEPENDING ON WHAT COLUMN THE DEMANDS ARE IN
						
				try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
					b = doc.get_sizing_valve( sizing_valve_name )	 								#assign demand name to the variable 'p'
				except RuntimeError:  																#check for runtime error (non-existent demand name)
					#PRINT TO POC FILE
					poc.write('{0},Did not find sizing_valve,{1}\n'.format(lineup,sizing_valve_name))
					errors += 1  																	#adds 1 to the error count - OPTIONAL
					continue																		#return to the top of the for loop and continue with the next row of data
					
				try: 																				#set environment to test values
					sizing_valve_flow = float( flow_value ) 										#assign the value as a floating point number
				except ValueError: 																	#check for value type error which indicates bad data
					sizing_valve_flow = 0
					#PRINT TO POC FILE
					poc.write('{0},Invalid value type,{1},{2}\n'.format(lineup,sizing_valve_name, flow_value))
					errors += 1
					continue 
					
				b.set_valve_settings(valve_settings(FCV, flow_rate(sizing_valve_flow,gpm ), pressure(0,psi)))
				
				updates += 1 																		#add 1 to the count of updated demands
				
			else:
				
				flow_demand_name = fpoc_name
				flow_value = data_col[lincount]												#Average values are one column left of bypass values
				bypass_name = fpoc_name + "-BY"
				bypass_value = data_col[lincount + 1]
				
				try:
					p = doc.get_flow_demand( flow_demand_name )
				except RuntimeError:
					#PRINT TO POC FILE		
					poc.write('{0},Did not find flow_demand,{1}\n'.format(lineup,flow_demand_name))
					errors += 1
					continue
				
				try: 																				#set environment to test values
					flow_demand_flow = float( flow_value ) 											#assign the value as a floating point number
				except ValueError: 																	#check for value type error which indicates bad data
					flow_demand_flow = 0
					#PRINT TO POC FILE
					poc.write('{0},Invalid value type,{1},{2}\n'.format(lineup,flow_demand_name, flow_value))
					errors += 1
					continue 
					
				p.set_flow(flow_demand_flow)
				
				updates += 1 																		#add 1 to the count of updated demands
				
				try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
					pb = doc.get_sizing_valve( bypass_name )	 								#assign demand name to the variable 'p'
				except RuntimeError:  																#check for runtime error (non-existent demand name)
					#PRINT TO POC FILE
					poc.write('{0},Did not find tool_bypass_valve,{1}\n'.format(lineup,bypass_name))
					errors += 1  																	#adds 1 to the error count - OPTIONAL
					continue																		#return to the top of the for loop and continue with the next row of data
					
				try: 																				#set environment to test values
					bypass_valve_flow = float( bypass_value ) 										#assign the value as a floating point number
				except ValueError: 																	#check for value type error which indicates bad data
					bypass_valve_flow = 0
					#PRINT TO POC FILE
					poc.write('{0},Invalid value type,{1},{2}\n'.format(lineup,bypass_name,bypass_value))
					errors += 1
					continue 
					
				pb.set_valve_settings(valve_settings(FCV, flow_rate(bypass_valve_flow,gpm ), pressure(0,psi)))
				
		lincount += 3
		# Report Import status to the output window and calculate the given lineup for evaluation
		print('The {0} Lineup import has finished with {1} items updated and {2} errors.\n'.format(lineup, updates, errors) ) 
		if lincount == 7: lineup = "Committed Average"
		elif lincount == 10: lineup = "Pending Average"		
		
print('Please view POC_errors_' + model_name + '.csv for details on the errors mentioned above.')
print('This new file will be found in the same folder as the PipeFlo Extract csv.')