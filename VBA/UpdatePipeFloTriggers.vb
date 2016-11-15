Sub UpdateLaterals()
    Dim cur As Workbook
    Dim fNameAndPath As Variant
    Dim ex As Workbook
    Dim ex_last As Integer
    Dim cur_first As Integer
    Dim cur_last As Integer
    Dim d_max As Integer
    Dim factor As Double
    Dim trigger As Double
    Dim size As String
    
    Set cur = ThisWorkbook
    
    With cur.Sheets("Laterals").ListObjects("TriggerTable")
        Set rList = .Range
        .Unlist
    End With
    
    With rList
        .Interior.ColorIndex = xlColorIndexNone
        .Font.ColorIndex = xlColorIndexAutomatic
        .Borders.LineStyle = xlLineStyleNone
    End With
    
    Range("A6").Select
    m_last = Selection.End(xlDown).Row
    Range("B6:C" & m_last).ClearContents
    cur.Sheets("Laterals").Range("AQ5:AT" & Cells(Rows.Count, "AQ").End(xlUp).Row).ClearContents
    
    fNameAndPath = Application.GetOpenFilename(FileFilter:="Text Files (*.CSV), *.CSV", Title:="Select the 'PipeFlo Extract With Modeling Factor'.csv for this system")
    If fNameAndPath = False Then Exit Sub
    
    Set ex = Workbooks.Open(fNameAndPath)
    
    ex.Sheets("PipeFlo Extract with Modeling F").Range("M2").Select
    ex_last = Selection.End(xlDown).Row
    ex.Sheets("PipeFlo Extract with Modeling F").Range("M2:M" & ex_last).AdvancedFilter Action:=xlFilterCopy, CopyToRange:= _
    cur.Sheets("Laterals").Range("AQ6"), Unique:=True
    
    cur.Sheets("Laterals").Activate
    ActiveSheet.Range("AQ6").Select
    cur_first = Selection.Row
    cur_last = Selection.End(xlDown).Row
    
    Range("AQ5").Value = "F_names"
    Range("AR5").Value = "m_row"
    Range("AS5").Value = "d_max"
    
    For i = cur_first To cur_last
        
        If IsError(Application.Match(Range("AQ" & i).Value, Range("A1:A" & m_last), 0)) Then
            Range("AR" & i).Value = "Not in model"
        Else
            'find lateral name in column a, pull out row
            m_row = Application.Match(Range("AQ" & i).Value, Range("A1:A" & m_last), 0)
            
            'apply trigger and size to columns B & C of pulled row
            Range("B" & m_row).Value = Application.WorksheetFunction.VLookup(Range("AQ" & i).Value, _
            ex.Sheets("PipeFlo Extract with Modeling F").Range("M2:Q" & ex_last), 4, False)
            Range("C" & m_row).NumberFormat = "0.00"
            Range("C" & m_row).Value = Application.WorksheetFunction.VLookup(Range("AQ" & i).Value, _
            ex.Sheets("PipeFlo Extract with Modeling F").Range("M2:Q" & ex_last), 5, False)
        End If
        
        Range("AS" & i).Value = Application.WorksheetFunction.VLookup(Range("AQ" & i).Value, _
            ex.Sheets("PipeFlo Extract with Modeling F").Range("M2:Q" & ex_last), 2, False)
        
    Next i
    
    ex.Close (False)
    
    ActiveSheet.ListObjects.Add(xlSrcRange, Range("$B$5:$C$" & m_last), , xlYes).Name = _
        "TriggerTable"
    ActiveSheet.ListObjects("TriggerTable").Range.AutoFilter Field:=1, Criteria1 _
        :="<>"
    Range("$B$5:$C$5").Font.Color = vbWhite
    
    

End Sub