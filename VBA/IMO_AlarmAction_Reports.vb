SELECT DISTINCTROW z-Test Sheets Lookup (Alarms).Alarm-ID INNER JOIN ON z-Test Sheets Lookup (Responses).Alarm-ID
	Alarms = I/O.Message-ID INNER JOIN ON Alarm-IDs.Alarm-ID Left Join SamplePointforTestSheet.Alarm-ID
		'I/O
		'Alarm-IDs
		SamplePointforTestSheet = Alarm-IDs.Alarm-ID INNER JOIN ON SampleDeviceAssignmentWithGas.Alarm-ID INNER JOIN ON I/O.Message-ID
			'Alarm-IDs
			'I/O
			SampleDeviceAssignmentWithGas = SampleDeviceAssignments.Gas A Left Join ON Gas Alarm Levels.GasType (Gas B too)
				'Gas Alarm Levels
				'SampleDeviceAssignments
	Responses = I/O.Message-ID INNER JOIN ON Response-ID.Response-ID
		'I/O
		'Response-ID
