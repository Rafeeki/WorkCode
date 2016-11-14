import sys, csv, os, codecs, shutil

dir = os.path.dirname( os.path.abspath( __file__ ) )
data_file_path = os.path.join( dir, 'PipeFlow Testing.csv')
counter = 0

with open( data_file_path ) as csvfile:

	reader = csv.reader(csvfile)
	
	for data_row in reader:
		one = data_row[0]
		print(one)
		
	print('All finished')