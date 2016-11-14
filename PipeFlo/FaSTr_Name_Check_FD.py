import sys
import csv
import os
# Set data_file_path to the FaSTr Export's location, and doc to the currently open PipeFlo doc
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlo Extract with Modeling Factor.csv')		# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()

# Setting model information for FaSTr Import DP_Segment_Load_File.csv
model_name = doc.get_file_name()

# Initialize variables and set the first lineup to Pending Peak
lineup = "Name Check"
laterals = []

# Create separate .csv files for POC Errors, Lateral Triggers and FaSTr Import, set headings for each
poc = open('Name_Errors_' + model_name + '.csv','w')
poc.write('Lineup,Error Type,POC Name,Invalid Value\n')

# Read the data file for each different lineup

lat = 0
errors = 0
updates = 0
with open( data_file_path ) as csvfile:
 
	reader = csv.reader( csvfile )
	next(reader, None)

	for data_col in reader:
	
		if not data_col: break
		# Read POC names and flow values
		fpoc_name = data_col[0]							#EDIT THIS VALUE DEPENDING ON WHAT COLUMN DPOC_SEGMENT_FPOC IS
		
		# Read lateral names and flow values, store in cur_lat if unique
		cur_lat = data_col[12]									#cur_lat receives this row's dp_segment_name
		cur_dmax = data_col[13]									#cur_dmax receives this row's design_max
		cur_trig = data_col[15]									#cur_trig receives this row's trigger value
		if cur_lat not in laterals:								#if this row's dp_segment_name hasn't already been stored in laterals
			laterals.append( cur_lat )							#store this row's dp_segment_name in the latest entry in laterals
				
		# Attempt to find POC name in model, report error if unsuccessful
		try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
			p = doc.get_flow_demand( fpoc_name )	 									#assign demand name to the variable 'p'
		except RuntimeError:  																#check for runtime error (non-existent demand name)
			#PRINT TO POC FILE		
			poc.write('{0},Did not find flow_demand,{1}\n'.format(lineup,fpoc_name))
			errors += 1  																	#adds 1 to the error count - OPTIONAL
			continue																		#return to the top of the for loop and continue with the next row of data
		

# Report Import status to the output window and calculate the given lineup for evaluation
print('The {0} import has finished with {1} POC errors\n'.format(lineup, errors) ) 			

# Search for each lateral listed in the FaSTr export, grab the calculated flow rate, velocity and dp_per_100
for l in range(0, len(laterals)):					

	try: 
		p = doc.get_pipe( laterals[l] )
	except RuntimeError: 
		#PRINT TO POC FILE
		poc.write('{0},Did not find {1}\n'.format(lineup,laterals[l]))
		lat +=1
		continue

print('The {0} import has finished with {1} Lateral errors\n'.format(lineup, lat) ) 