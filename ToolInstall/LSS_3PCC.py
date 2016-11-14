import sys
import csv
import os
import easygui as g

# dir = os.path.dirname( os.path.abspath( __file__ ) )

# Grab TO name, tool CEID (which gives tool family), and activity/type/FA
TO_name = raw_input('What is your name? ')
tool_CEID = raw_input('What CEID are you referencing? ')
tool_fam = tool_CEID[:3]
eventtype = raw_input('Is this a Demo, Determ Only, or QAQC? ')
activity = raw_input('What type of activity is this? ')
FA = raw_input('What functional area is this? ')		# Ideally the program would know this from a database

# Ask for start date/time of test in Outlook format.
stime = raw_input('What time will you start? (yyyy-mm-dd hh:mm) ')

# Ask for tool location.
building = raw_input('Where should everybody meet? ')

# Program navigates to folder with name tool_CEID either in ICCT or 3PCC sharedrive to pull all the
# associated drawings. Nice to have - program also suggests which test sheets to add based on MOR rules.
# Program grabs addresses for additional sheets from ICCT/3PCC and stores them in T_sheets for later.

rootDir = '.'
T_sheets = []
for dirName, subdirList, fileList in os.walk(rootDir):
	# try to find tool family folder, then try to find tool, then find fname in fileList and return as choices
	if dirName == '{0}\{1}'.format(rootDir, tool_CEID):
		for fname in fileList:
			T_sheets.append(fname)
		break
	elif dirName == '{0}\{1}\{2}'.format(rootDir, tool_fam, tool_CEID):
		for fname in fileList:
			T_sheets.append(fname)
		break
	else:
		continue	

# Prompter to choose which test sheets to be added
T_msg = "Which ones do you need?"
T_title = "Test sheets"
choices = T_sheets

# Ask for additional test sheets.
sheet = []
while sheet != 'n/a':
	sheet = raw_input('Name another test sheet (enter n/a when finished): ')
	T_sheets.append(sheet)

# Ask for names to be invited to test. Nice to have - Jonathan's groups to click and select instead of 
# inputting. Names could be saved in a spreadsheet/database in LSS folder.
T_names = []
T_names_Outlook = []
name = []
n_count = 0
while name!= 'n/a':
	name = raw_input('Who needs to attend the test? (enter n/a when finished): ')
	T_names.append(name)
	n_count = n_count + 1
T_names_Outlook = '; '.join(T_names[:n_count-1]) # Cleaning up names for Outlook format
	
# Creating Outlook meeting
import win32com.client
oOutlook = win32com.client.Dispatch('Outlook.Application')
appt = oOutlook.CreateItem(1) 
appt.Start = stime
appt.Subject = tool_CEID + ' ' + eventtype + ' ' + building[:4] + ' ' + activity + ' ' + FA
appt.Duration = 60
appt.Location = building
appt.MeetingStatus = 1 # changing an appointment to a meeting so recipients can be added
appt.Recipients.Add(T_names_Outlook)
for i in T_sheets:
	appt.Attachments.Add('{0}\{1}\{2}\{3}'.format(rootDir, tool_fam, tool_CEID, T_sheets[i]))

# MUST ADD functionality to attach drawings (from CEID) and T_sheets
# dir = os.path.dirname( os.path.abspath( __file__ ) )
# data_file_path = os.path.join( dir, 'PipeFlow Testing.csv')	# EDIT THIS NAME DEPENDING ON CSV FILE NAME

appt.save()
# appt.send()