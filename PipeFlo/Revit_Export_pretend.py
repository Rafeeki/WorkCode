import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'Revit_Export_pretend.csv')									# EDIT THIS NAME DEPENDING ON CSV FILE NAME
doc = pipeflo().doc()
 
# Read the data file

errors = 0
flupdate = 0
spupdate = 0
siupdate = 0
lupdate = 0
fiupdate = 0
eupdate = 0

with open( data_file_path ) as csvfile:
	 
	reader = csv.reader( csvfile )
	next(reader, None)

	for data_row in reader:
		if not data_row: break
		
		id = data_row[0]																	#EDIT THIS VALUE DEPENDING ON WHAT COLUMN PIPE ID IS
		try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
			p = doc.get_pipe( id )							 								#assign id to the variable 'p' if that id matches an existing pipe
		except RuntimeError:  																#check for runtime error (non-existent pipe name)
			print( 'Did not find pipe', id )						 						#print problem to the output window
			errors += 1  																	#adds 1 to the error count - OPTIONAL
			continue																		#return to the top of the for loop and continue with the next row of data
		
		fluid = data_row[1] 																#EDIT THIS VALUE DEPENDING ON WHAT COLUMN FLUID ZONE IS
		try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
			p.set_fluid_zone(fluid)							 								#assign fluid to its associated pipe id
		except RuntimeError:  																#check for runtime error (non-existent fluid_zone)
			print( 'Did not find fluid_zone ', fluid, ' for: ', id )				 		#print problem to the output window
			errors += 1  																	#adds 1 to the error count - OPTIONAL
			flupdate -= 1
		flupdate += 1
		
		spec = data_row[2]																	#EDIT THIS VALUE DEPENDING ON WHAT COLUMN MATERIAL SPECIFICATION IS
		try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
			p.set_specification( spec )						 								#assign spec to its associated pipe id
		except RuntimeError:  																#check for runtime error (non-existent specification)
			print( 'Did not find specification', spec, ' for: ', id )				 		#print problem to the output window
			errors += 1  																	#adds 1 to the error count - OPTIONAL
			spupdate -= 1
		spupdate += 1
		
		size = data_row[3]																	#EDIT THIS VALUE DEPENDING ON WHAT COLUMN PIPE SIZE IS
		try: 																				#set environment to test values
			p.set_pipe_size( size ) 				 										#assign the value as a floating point number
		except RuntimeError:																#check for value type error which indicates bad data
			print( 'Invalid value type', id, ": " , size )				 					#print problem to the output window
			size = 0																		#reset size to zero in case the next value is null
			errors += 1																		#adds 1 to the error count - OPTIONAL
			siupdate -= 1
		siupdate += 1
				
		length = data_row[4]																#EDIT THIS VALUE DEPENDING ON WHAT COLUMN PIPE LENGTH IS
		try: 																				#set environment to test values
			plength = float( length )					 									#assign the value as a floating point number
		except ValueError:																	#check for value type error which indicates bad data
			print( 'Invalid value type for', id, ": " , length )					 		#print problem to the output window
			plength = 0																		#reset length to zero in case the next value is null
			errors += 1																		#adds 1 to the error count - OPTIONAL
			lupdate -= 1
		p.set_length( plength )																#assign floating point length to its associated pipe id
		lupdate += 1
		
		total_k = data_row[5]																#EDIT THIS VALUE DEPENDING ON WHAT COLUMN TOTAL K-VALUE IS
		f = pipe_fitting()																	#Create pipe_fitting object 'f'
		f.type = "Other"																	#Give it type 'Other' instead of a specific V&F
		f.description = "Fixed K"															#Choose type 'Fixed K' for calculation purposes
		f.count = 1																			#Just need a single one since it's an aggregate value
		f.name = "Fixed K"																	#Stylistic
		try: 																				#set environment to test values
			ptotal_k = float( total_k )				 										#assign the value as a floating point number
		except ValueError: 																	#check for value type error which indicates bad data
			ptotal_k = 0																	#reset total_k to zero in case the next value is null
			print( 'Invalid value type', id, total_k )					 					#print problem to the output window
			errors += 1																		#adds 1 to the error count - OPTIONAL
					
		f.coefficient = dimensionless( ptotal_k )											#Plugging the actual K-value into the fitting object
		f.user_description = "Total V&F"													#Stylistic
		fittings = [ f ] 																	#Make a new list containing the single pipe_fitting, f
		try:																				#set environment to test values
			p.set_installed_fittings( fittings )											#Get the pipe and set the data
		except RuntimeError:																#Check for RuntimeError which means ptotal_k = 0
			ptotal_k = 0																	#reset total_k to zero in case the next value is null
			print( 'K-value for', id, 'not updated because = ', total_k )					#print problem to the output window
			errors += 1																		#adds 1 to the error count - OPTIONAL
			fiupdate -= 1
		fiupdate += 1
	
# For elevation, need logic to determine if the ending node is a node, and if it is if we can assign a value to it.  If the ending node
# is a component or already has a matching elevation, we will print that information and move on.
		elev = data_row[6]																	#EDIT THIS VALUE DEPENDING ON WHAT COLUMN ENDING ELEVATION IS
		end_node = data_row[7]																#EDIT THIS VALUE DEPENDING ON WHAT COLUMN ENDING NODE IS
		pelev = float(elev)
		try:											 									#set environment to test values without aborting the rest of the script when errors are encountered
			n = doc.get_node( end_node )					 								#assign end_node to the variable 'n' if it matches an existing node name
		except RuntimeError:  																#check for runtime error (non-existent pipe name)
			print( end_node, 'elevation not updated because it was not a node' )			#print problem to the output window
			errors += 1  																	#adds 1 to the error count - OPTIONAL
			continue																		#return to the top of the for loop and continue with the next row of data
		n.set_elevation( pelev )															#assign floating point size to its associated pipe id
		eupdate += 1 																		#add 1 to the count of updated pipes
	

print( 'Import finished.' ) 																	#print to the output window
if errors > 0: 																					#if updates exist print count - OPTIONAL
	print( errors, 'errors.' )

if flupdate > 0:  																				#if updates exist print count - OPTIONAL
	print( flupdate, 'fluid zones updated.' )
if spupdate > 0:  																				#if updates exist print count - OPTIONAL
	print( spupdate, 'specifications updated.' )
if siupdate > 0:  																				#if updates exist print count - OPTIONAL
	print( siupdate, 'sizes updated.' )
if lupdate > 0:  																				#if updates exist print count - OPTIONAL
	print( lupdate, 'lengths updated.' )
if fiupdate > 0:  																				#if updates exist print count - OPTIONAL
	print( fiupdate, 'K-values updated.' )
if eupdate > 0:  																				#if updates exist print count - OPTIONAL
	print( eupdate, 'elevations updated.' )


