Sub Hyperlink()

CEID = Range("C2:C41")

For Each i In CEID
        
    If IsError(i) Then
        GoTo NextIteration
    Else
        currentrow = Application.WorksheetFunction.Match(i, CEID, 0)
        Process = Cells(currentrow, "C").Offset(1, 2).Value
        currentlink = Process & "\" & i & ".pptx"
        ActiveSheet.Hyperlinks.Add Cells(currentrow + 1, "C"), currentlink
        Cells(currentrow + 1, "W").Value = "no"
NextIteration:


Next i

End Sub
