Public Function WorkDays(sdate As Long, edate As Long) As Integer
    Dim count As Integer
    Holidays = Range("Holidays!$A$2:$I$6")
    
    For i = sdate To edate
        
        r = (i) Mod (7)
        If r > 1 Then
            count = count + 1
        End If
        
        For Each cell In Holidays
            If i = cell Then
            count = count - 1
            End If
        Next cell
            
    Next i
    
    WorkDays = count
    count = 0
    
End Function

Sub DurCount()
    Dim ldate As Date
    Dim lrow As Integer
    Dim a As Date
    Dim b As Date
    Dim c As Integer
        
    ldate = ActiveWorkbook.Application.WorksheetFunction.Max(Range("A:A"))
    lrow = Range("A:A").Find(what:=ldate).Row
    
    
    'Range("F1").Value = "Workdays (no Hols)"
    
    For i = 3 To lrow
        a = Range("A" & i - 1).Value
        b = Range("A" & i).Value
        c = WorkDays(CLng(a), CLng(b))
        Range("F" & i).Value = c
    Next i
    
    Range("Table1[[#Headers],[Workdays (no Hols)]]").Select
    Range(Selection, Selection.End(xlDown)).Select
    Selection.Columns.AutoFit
End Sub

