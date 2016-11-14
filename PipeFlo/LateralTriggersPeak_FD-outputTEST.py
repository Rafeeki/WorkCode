import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlo Extract with Modeling Factor.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()
model_name = doc.get_file_name()
model_space1 =  model_name.find(" ")
model_space2 = model_name.find("-", model_space1+1)
building = model_name[:model_space1]
utility = model_name[model_space1+1:model_space2]
# Read the data file

lineup = "1.3x"
errors = 0
updates = 0
factor = 1.3
laterals = []
dmaxs = []
trigs = []

doc.set_current_lineup(lineup)
lat_count = 0
poc = open('POC_Errors.csv','w')
poc.write('Error Type,POC Name,Invalid Value\n')
lat = open('Lateral_Triggers.csv','w')
lat.write(lineup + ' Lineup\nLateral Name,Design Max,Trigger Flow,Calc Flow,Velocity,dp per 100\n')
fastr = open('DP_Segment_Load_File.csv','w')
fastr.write('Facility,Utility,Source,DP Segment,Design Max\n')


#IMPORT CSV DATA
with open( data_file_path ) as csvfile:
 
	reader = csv.reader( csvfile )
	next(reader, None)

	for data_col in reader:
	
		if not data_col: break
		flow_demand_name = data_col[0]														#EDIT THIS VALUE DEPENDING ON WHAT COLUMN DPOC_SEGMENT_FPOC IS
		flow_value = data_col[9] 															#EDIT THIS VALUE DEPENDING ON WHAT COLUMN THE DEMANDS ARE IN

		cur_lat = data_col[12]									#cur_lat receives this row's dp_segment_name
		cur_dmax = data_col[13]									#cur_dmax receives this row's design_max
		cur_trig = data_col[15]									#cur_trig receives this row's trigger value
		if cur_lat not in laterals:								#if this row's dp_segment_name hasn't already been stored in laterals
			laterals.append( cur_lat )							#store this row's dp_segment_name in the latest entry in laterals
			dmaxs.append( int(cur_dmax) )						#store this row's design_max in the latest entry in dmaxs
			trigs.append( float(cur_trig) )						#store this row's trigger in the latest entry in trigs
				
		try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
			p = doc.get_flow_demand( flow_demand_name )	 									#assign demand name to the variable 'p'
		except RuntimeError:  																#check for runtime error (non-existent demand name)
#PRINT TO POC FILE		
			poc.write('Did not find flow_demand,{}\n'.format(flow_demand_name)) 							#print problem to the output window
			errors += 1  																	#adds 1 to the error count - OPTIONAL
			continue																		#return to the top of the for loop and continue with the next row of data
				
		try: 																				#set environment to test values
			flow_demand_flow = float( flow_value ) * factor 										#assign the value as a floating point number
		except ValueError: 																	#check for value type error which indicates bad data
			flow_demand_flow = 0
#PRINT TO POC FILE
			poc.write( 'Invalid value type, {0},{1}\n'.format(flow_demand_name, flow_value)) 					#print problem to the output window
			errors += 1
			continue 
				
		p.set_flow(flow_demand_flow)
		
		updates += 1 																		#add 1 to the count of updated demands
doc.calculate_and_refresh()																	#calculate the given lineup for evaluation

for l in range(0, len(laterals)):					

	try: 
		p = doc.get_pipe( laterals[l] )
	except RuntimeError: 
#PRINT TO LATERAL FILE
		lat.write('Did not find {}\n'.format(laterals[l]))
		continue
	p_f = round(p.get_calculated_flow().value,2)
	v_f = round(p.get_velocity().value,2)
	dp = round(p.get_dp_per_100().value,2)
	
	if p_f > trigs[l]: 
#PRINT TO LATERAL FILE
		lat.write('{0},{1},{2},{3},{4},{5}\n'.format(laterals[l],str(dmaxs[l]),str(trigs[l]),str(p_f),str(v_f),str(dp)))
		lat_count += 1
		fastr.write('{0},{1},?,{2},{3}\n'.format(building,utility,laterals[l], p_f)) 
#PRINT TO LATERAL FILE
if lat_count == 0: lat.write('No Laterals exceeded their trigger.\n')

print('{0} import finished with {1} items updated and {2} errors\n'.format(lineup, updates, errors) ) 		#print to the output window
print('In the same folder as your PipeFlo model, view:')
print('\tPOC_Errors.csv for missing/invalid POCs')
print('\tLateral_Triggers.csv for lateral flow rates, velocities and dp per 100s.')
print('\nDP_Segment_Load_File.csv can be sent directly to your FaSTr admin to update the exceeded Lateral Triggers.Please verify the information is correct before doing so!!')