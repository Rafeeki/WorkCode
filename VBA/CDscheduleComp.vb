Sub Data()
    ActiveSheet.Range("B3").Select
    lrow = Selection.End(xlDown).Row
    
    ChDir "A:\F42-Share1\05_06_TI_DsgnGN\5.06.03 Design Schedule\5.06.03.07 Design Micro Schedule"
    fNameAndPath = Application.GetOpenFilename(FileFilter:="Excel Files (*.XLSX), *.XLSX", Title:="Select the latest CD Schedule")
    If fNameAndPath = False Then Exit Sub
    
    Set ex = Workbooks.Open(fNameAndPath)
    Set cur = ThisWorkbook
    
    For i = 3 To lrow
    
        If IsEmpty(cur.Sheets(1).Range("B" & i).Value) Or cur.Sheets(1).Range("B" & i).Value = "" Then
            GoTo NextIteration:
        Else
            Rng = cur.Sheets(1).Range("B" & i).Value
        End If
        
        If IsNumeric(Mid(Rng, 2, 1)) Then
            col = Left(Rng, 1)
            Row = Right(Rng, Len(Rng) - 1)
        Else
            col = Left(Rng, 2)
            Row = Right(Rng, Len(Rng) - 2)
        End If
        
        cur.Sheets(1).Range("F" & i).Value = ex.Sheets(1).Range("A" & Row).Value
        cur.Sheets(1).Range("G" & i).Value = ex.Sheets(1).Range(col & "1").Value
NextIteration:
    Next i
    
    ex.Close (False)
    
    cur.Sheets(1).Range("F2").Value = "Tool"
    cur.Sheets(1).Range("G2").Value = "Quality"
    cur.Sheets(1).Range("H2").Value = "Old Value"
    cur.Sheets(1).Range("I2").Value = "New Value"
    cur.Sheets(1).Range("J2").Value = "Delta"
    
    For i = 3 To lrow
        
        old_long = ActiveSheet.Range("C" & i).Value
        new_long = ActiveSheet.Range("D" & i).Value
        
        If InStr(1, old_long, "(") - 2 < 0 Then
            ActiveSheet.Range("H" & i).Value = old_long
        Else
            ActiveSheet.Range("H" & i).Value = Left(old_long, InStr(1, old_long, "(") - 2)
        End If
        
        If InStr(1, new_long, "(") - 2 < 0 Then
            ActiveSheet.Range("I" & i).Value = new_long
        Else
            ActiveSheet.Range("I" & i).Value = Left(new_long, InStr(1, new_long, "(") - 2)
            Range("J" & i).Value = Range("I" & i).Value - Range("H" & i).Value
        End If

    Next i

    cur.Sheets(1).Columns("A:E").Hidden = True
    Range("J2").Select
    Range(Selection, Selection.End(xlToLeft)).Select
    Selection.AutoFilter
    Selection.End(xlToLeft).Select
    
End Sub
