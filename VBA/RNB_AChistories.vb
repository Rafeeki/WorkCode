Sub Macro1()
'
' Macro1 Macro
'

'
    Windows("Robert_Noyce_Building_RNB_AC3.SF5FM__Flow_Rate_Cubic_Feet_per_Minute.csv" _
        ).Activate
    Range("A1:H3203").Select
    Selection.Columns.AutoFit
    Columns("E:E").Select
    Selection.Cut
    Selection.End(xlToLeft).Select
    Columns("A:A").Select
    Selection.Insert Shift:=xlToRight
    Sheets("Robert_Noyce_Building_RNB_AC3.3").Select
    Sheets("Robert_Noyce_Building_RNB_AC3.3").Move After:=Workbooks( _
        "AC3_VM_Histories.xlsm").Sheets(9)
End Sub
Function SHEETNAME(number As Long) As String
    SHEETNAME = Sheets(number).Name
End Function
