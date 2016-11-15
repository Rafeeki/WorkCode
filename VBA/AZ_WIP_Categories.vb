Sub RemoveBlanks()

stool = Range("A2").Row
Set WS = Worksheets("Sheet1")
With WS
    Set LastCell = .Cells(.Rows.Count, "A").End(xlUp)
    etool = LastCell.Row
End With

For i = stool To etool
    
    If IsEmpty(Range("A" & i)) Then Exit For
    
    If IsEmpty(Range("D" & i)) Or IsEmpty(Range("E" & i)) Or IsEmpty(Range("F" & i)) Or IsEmpty(Range("G" & i)) Or IsEmpty(Range("H" & i)) Or IsEmpty(Range("I" & i)) Or IsEmpty(Range("J" & i)) Or IsEmpty(Range("K" & i)) Then
        
        Rows(i).Select
        Selection.Delete Shift:=xlUp
        i = i - 1
    End If
    
Next i

End Sub

Sub RemoveStopWork()
    Cells.Find(what:="Stop", After:=ActiveCell, LookIn:=xlFormulas, _
        LookAt:=xlPart, SearchOrder:=xlByRows, SearchDirection:=xlNext, _
        MatchCase:=False, SearchFormat:=False).Activate
    Rows(ActiveCell.Row).Select
    Selection.Delete Shift:=xlUp
End Sub

Sub RemoveQual()
    Cells.Find(what:="Qual", After:=ActiveCell, LookIn:=xlFormulas, _
        LookAt:=xlPart, SearchOrder:=xlByRows, SearchDirection:=xlNext, _
        MatchCase:=False, SearchFormat:=False).Activate
    Rows(ActiveCell.Row).Select
    Selection.Delete Shift:=xlUp
End Sub

Sub RemoveConvFac()
    Cells.Find(what:="Conv-Fac", After:=ActiveCell, LookIn:=xlFormulas, _
        LookAt:=xlPart, SearchOrder:=xlByRows, SearchDirection:=xlNext, _
        MatchCase:=False, SearchFormat:=False).Activate
    Rows(ActiveCell.Row).Select
    Selection.Delete Shift:=xlUp
End Sub

Sub WIP_Categories()
    Dim sdate As Date
    Dim edate As Date
    Dim Lsdate As Date
    Dim DesignWIP As Integer
    Dim PrefacWIP As Integer
    Dim SL1_WIP As Integer
    Dim SL2_WIP As Integer
    Dim LimboWIP As Integer
    Dim etool As Integer
    Dim stool As Integer
    
    Range("Table1[#All]").Select
    Selection.Columns.AutoFit
    sdate = ActiveWorkbook.Application.WorksheetFunction.Min(Range("Table1[Design Start]"))
    stool = Range("Table1[Design Start]").Find(what:=sdate).Row
    edate = ActiveWorkbook.Application.WorksheetFunction.Max(Range("Table1[SL2 Construction Finish]"))
    Lsdate = ActiveWorkbook.Application.WorksheetFunction.Max(Range("Table1[Design Start]"))
    etool = Range("Table1[Design Start]").Find(what:=Lsdate).Row
    Range("N1").Value = "Dates"
    Range("O1").Value = "Design WIP"
    Range("P1").Value = "Prefac WIP"
    Range("Q1").Value = "SL1 WIP"
    Range("R1").Value = "SL2 WIP"
    Range("S1").Value = "Limbo WIP"
    
    
    For i = sdate To edate
        DesignWIP = 0
        PrefacWIP = 0
        SL1_WIP = 0
        SL2_WIP = 0
        LimboWIP = 0
        i = CLng(i)
        Cells(i - (sdate - 2), "N") = i
        
        For j = stool To etool
        
            If Cells(j, "E").Value > i Then Exit For
End Sub

