import sys
import csv
import os
pdz = raw_input('Enter the file name: ')
dir = os.path.dirname( os.path.abspath( __file__ ) )
pdz_file_path = os.path.join( dir, pdz)
tools_file_path = os.path.join(dir,'IMO_Cabs.csv')
yes_path = os.path.join(dir, pdz[:8]+ '_Cabs_with_HPM.txt')
yes = open(yes_path,'w')
no_path = os.path.join(dir, pdz[:8]+ '_Cabs_without_HPM.txt')
no = open(no_path,'w')

with open(tools_file_path) as tool_list:
	reader = csv.reader(tool_list)

	for tool in reader:
		with open(pdz_file_path) as f:
			yes.write("\n" + str(tool)[2:12] + "\n")
			j = 0
			for line in f:
				temp_addr = ""
				i_addr = ""
				o_addr = ""
				io_addr = ""
				i = 0

				if str(tool)[2:12] in line:
					j = j + 1
					if line[0:4] == "    ":
						i_addr = prev_line[4:12].replace(" ","")
						o_addr = line[10:18].replace(" ","")
						yes.write("Output only: \n" + i_addr + "," + o_addr + "\n")
						continue
					else:
						next_line = next(f)
						if line[0] == "A": 
							i_addr = line[4:12].replace(" ","")
							while next_line[0] == "0":
								i=i+1
								io_addr = io_addr + next_line[6:-1].replace(" ","") + ","
								next_line = next(f)
						elif line[0] == "S" and next_line[:4] == "    ":
							i_addr = line[4:12].replace(" ","")
							while next_line[:4] == "    ":
								i=i+1
								io_addr = io_addr + next_line[10:18].replace(" ","") + ","
								next_line = next(f)
						else:
							o_addr = line[4:12].replace(" ","")
							yes.write("Output: \n" + o_addr + "\n")
							continue
						if i == 0: yes.write("Input: \n" + i_addr + "\n")
						else: 
							io_rel = i_addr + ", " + io_addr
							yes.write("Input/Output: \n" + io_rel[:-1] + "\n")
						continue
				prev_line = line
			if j == 0: 
				# Delete past 6 characters
				yes.seek(-12,2)
				yes.write("       ")
				no.write(str(tool)[2:12] + "\n")