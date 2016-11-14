import sys
import csv
import os
pdz = raw_input('Enter the file name: ')
dir = os.path.dirname( os.path.abspath( __file__ ) )
pdz_file_path = os.path.join( dir, pdz)
tools_file_path = os.path.join(dir,'IMO_Tools.csv')
yes_path = os.path.join(dir, pdz[:8]+ '_Tools_with_HPM_d.txt')
yes = open(yes_path,'w')
no_path = os.path.join(dir, pdz[:8]+ '_Tools_without_HPM_d.txt')
no = open(no_path,'w')

with open(tools_file_path) as tool_list:
	reader = csv.reader(tool_list)

	for tool in reader:
		with open(pdz_file_path) as f:
			
			j = 0
			for line in f:
				i = 0

				if str(tool)[2:7] in line:
					j = j + 1
		if j > 0: yes.write(str(tool)[2:7] + "\n")
		else: no.write(str(tool)[2:7] + "\n")