import sys
import csv
import os
dir = os.path.dirname( os.path.abspath( __file__ ) )
pdz_file_path = os.path.join( dir, 'Bh409025.pdz')

with open(pdz_file_path) as f:
	for line in f:
		temp_addr = ""
		i_addr = ""
		o_addr = ""
		io_addr = ""
		i = 0
		if "DET04" in line:
			if line[0:4] == "    ":
				i_addr = prev_line[4:12].replace(" ","")
				o_addr = line[10:18].replace(" ","")
				print "Output only: \n" + i_addr + "," + o_addr + "\n"
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
					print "Output: \n" + o_addr + "\n"
					continue
				if i == 0: print "Input: \n" + i_addr + "\n"
				else: 
					io_rel = i_addr + ", " + io_addr
					print "Input/Output: \n" + io_rel[:-1] + "\n"
				continue
		prev_line = line
			# if line[0] == "A": 
				# i = i+1
				# i_addr = line[4:12].replace(" ","")
			# elif line[0:3] == "    ": 
				# i = i+1
				# prev_line = previous(f)
				# i_addr = prev_line[4:12].replace(" ","")
				# o_addr = line[10:18].replace(" ","")
			# next_line = next(f)
			# if next_line[0] == "0"
				# while next_line[0] == "0":
					# i= i+1
					# io_addr = io_addr + next_line[6:-1].replace(" ","") + ","
					# next_line = next(f)
			# elif next_line[:4] == "    "
				# while next_line[:4] == "    "
					# i = i+1
					# io_addr = line[10:18].replace(" ","")
					# next_line = next(f)
			# io_rel = i_addr + ", " + io_addr
			# if i == 0: 
				# o_addr = line[4:12].replace(" ","")
				# print "Output: \n" + i_addr + "\n"
			# else: print "Input/Output: \n" + io_rel[:-2] + "\n"
			# continue

