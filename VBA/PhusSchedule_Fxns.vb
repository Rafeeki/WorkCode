'Functions:

Public Function GrandTot() As Integer
'
' Sel_Prog Macro
'

'
    Sheets("Demo with BL").Select
    Range("B11").Select
    Selection.End(xlDown).Select
    GrandTot = Selection.Value

End Function

Public Function GrandTotInstall() As Integer
'
' Sel_Prog Macro
'

'
    Sheets("Install with BL").Select
    Range("B11").Select
    Selection.End(xlDown).Select
    GrandTotInstall = Selection.Value

End Function
