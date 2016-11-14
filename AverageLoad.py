Sub Average_Load()
'
' Average_Load Macro
'
' Keyboard Shortcut: Ctrl+a
'
    Windows("Capacity vs Demand.xls").Activate
    Range("W:W").Select
    Selection.Copy
    Windows("PipeFlo DataLink Template Rev 2.2.xls").Activate
    Range("A1").Select
    Selection.PasteSpecial Paste:=xlPasteValues, Operation:=xlNone, SkipBlanks _
        :=False, Transpose:=False
    Range("A65536").End(xlUp).Select
    lrow = ActiveCell.Row
    Windows("Capacity vs Demand.xls").Activate
    Range("AV:AX").Select
    Application.CutCopyMode = False
    Selection.Copy
    Windows("PipeFlo DataLink Template Rev 2.2.xls").Activate
    Range("B1").Select
    Selection.PasteSpecial Paste:=xlPasteValues, Operation:=xlNone, SkipBlanks _
        :=False, Transpose:=False
    Range("K1:K" & lrow).Select
    Selection.ClearContents
    Range("E1:G1").Select
    Selection.AutoFill Destination:=Range("E1:G" & lrow), Type:=xlFillDefault
    Range("E1:G" & lrow).Select
    Range("H1").Select
    Selection.Copy
    Range("H2:H" & lrow).Select
    ActiveSheet.Paste
    Application.CutCopyMode = False
    Selection.Copy
    ActiveWindow.SmallScroll ToRight:=3
    Range("K2").Select
    Selection.PasteSpecial Paste:=xlPasteValues, Operation:=xlNone, SkipBlanks _
        :=False, Transpose:=False
    Range("H2:H" & lrow).Select
    Application.CutCopyMode = False
    Selection.ClearContents
    With Selection.Interior
        .Pattern = xlNone
        .TintAndShade = 0
        .PatternTintAndShade = 0
    End With
    Range("K2:K" & lrow).Select
    Selection.Copy
    Range("L8").Select
    Range("E2:G" & lrow).Select
    Selection.ClearContents
    Range("E25").Select
    Range("H2:J" & lrow).Select
    Selection.ClearComments
    Range("I24").Select
    Range("K2:K" & lrow).Select
    Selection.Copy
End Sub