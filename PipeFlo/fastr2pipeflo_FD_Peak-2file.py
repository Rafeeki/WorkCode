import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlo Extract with Modeling Factor.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()
model_name = doc.get_file_name()

# Read the data file

lincount = 3
lineup = "Connected Peak"
poc = open('POC_Errors_' + model_name + '.csv','w')
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
			flow_demand_name = data_col[0]														#EDIT THIS VALUE DEPENDING ON WHAT COLUMN DPOC_SEGMENT_FPOC IS
			flow_value = data_col[lincount]														#EDIT THIS VALUE DEPENDING ON WHAT COLUMN THE DEMANDS ARE IN
						
			try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
				p = doc.get_flow_demand( flow_demand_name )	 									#assign demand name to the variable 'p'
			except RuntimeError:  																#check for runtime error (non-existent demand name)
				#PRINT TO POC FILE		
				poc.write('{0},Did not find flow_demand,{1}\n'.format(lineup,flow_demand_name))
				errors += 1  																	#adds 1 to the error count - OPTIONAL
				continue																		#return to the top of the for loop and continue with the next row of data
						
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
		lincount += 3
		# Report Import status to the output window and calculate the given lineup for evaluation
		print('The {0} Lineup import has finished with {1} items updated and {2} errors.\n'.format(lineup, updates, errors) ) 
		if lincount == 6: lineup = "Committed Peak"
		elif lincount == 9: lineup = "Pending Peak"		

print('Please view POC_errors_' + model_name + '.csv for details on the errors mentioned above.')
print('This new file will be found in the same folder as this PipeFlo model.')