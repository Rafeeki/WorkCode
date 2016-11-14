import os
import sys
# print(sys.path)
os.getcwd()
import easygui as g

rootDir = '.'
# print(rootDir+'\BCDS')
fam = 'BCDS'
tool = 'AVX812'
T_sheets=[]
for dirName, subdirList, fileList in os.walk(rootDir):
	if dirName =='{0}\{1}\{2}'.format(rootDir, fam, tool):
		# if dirName =='.\BCDS\AVX812':
			for fname in fileList:
				T_sheets.append(fname)
				# print(T_sheets)
	# print('Found directory: %s' % dirName)
	# for fname in fileList:
		# print('\t%s' % fname)
T_msg = "Which ones do you need?"
T_title = "Test sheets"
choices = T_sheets
choice = g.choicebox(T_msg, T_title, choices)