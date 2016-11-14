import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'Feed CSV.csv' )
doc = pipeflo().doc()

# Read the data file

with open( data_file_path ) as csvfile:

    reader = csv.reader( csvfile )

    for data_row in reader:

        # Process one line of data

        flow_demand_name = data_row[0]

        flow_demand_flow = float( data_row[1] )  # Convert the string to a number!

       # pipe_size = data_row[2]

        # Print the name, length and size

      #  print( 'Pipe: {}\tLength: {}\tSize: {}'.format( pipe_name, pipe_length, pipe_size ) )

        # Get the pipe by its name

        p = doc.get_flow_demand( flow_demand_name )

        p.set_flow(flow_demand_flow )



