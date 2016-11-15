Sub Macro5()
'
' Macro5 Macro
'
' Keyboard Shortcut: Ctrl+Shift+Z
'
    Cells.Find(what:="1/0/1900", After:=ActiveCell, LookIn:=xlFormulas, _
        LookAt:=xlPart, SearchOrder:=xlByRows, SearchDirection:=xlNext, _
        MatchCase:=False, SearchFormat:=False).Activate
    With Selection.Interior
        .Pattern = xlSolid
        .PatternColorIndex = xlAutomatic
        .Color = 255
        .TintAndShade = 0
        .PatternTintAndShade = 0
    End With
End Sub
Sub Macro6()
    
    Set ws = Worksheets("Sheet1")
    ws.Range("L8") = ws.Cells(40112 - 40104, "E").Value
    ws.Range("M8") = ws.Cells(8, "D").Value
    ws.Range("N8") = ws.Cells(40112 - 40104, "D").Value
    If ws.Range("L8") > ws.Range("M8") Then
        ws.Range("L9") = True
    Else
        ws.Range("L9") = False
        End If
    If ws.Range("N8") < ws.Range("M8") Then
        ws.Range("N9") = True
    Else
        ws.Range("N9") = False
        End If
        
End Sub
Sub Macro7()

    Dim edate As Date
    Dim cyc As Integer
    Dim WIP As Integer
    Dim tool_dur As Integer
    Dim date_dur As Long
    Dim etool As Integer
    Dim stool As Integer
    
    Set ws = Worksheets("Sheet1")
    sdate = ws.Cells(6, "M").Value
    edate = Application.WorksheetFunction.Max(Sheet1.Range("Table1[SL2 Construction Finish]"))
    etool = ws.Range("Table1[SL2 Construction Finish]").Find(what:=edate).Row
    sTdate = Application.WorksheetFunction.VLookup(CLng(sdate), Sheet1.Range("D:D"), 1, True)
    stool = Application.WorksheetFunction.Match(sTdate, ws.Range("D:D"), True)
    
    For i = sdate To edate
        WIP = 0
        date_dur = 0
        i = CLng(i)
        Cells(i - (sdate - 2), "P") = i

        If (i) Mod (7) = 0 Then
            cyc = 0
            For j = stool To etool
                If ws.Cells(j, "E").Value >= i - 7 And ws.Cells(j, "E").Value < i Then
                    cyc = cyc + 1
                End If
            Next j
            If cyc <> 0 Then
                Cells(i - (sdate - 2), "S").Value = 150 / cyc
            Else
                Cells(i - (sdate - 2), "S").Value = 0
            End If
        End If
        
        For j = stool To etool
            
            If ws.Cells(j, "D").Value > i Then Exit For
            
            If ws.Cells(j, "E").Value > i And ws.Cells(j, "D").Value <= i Then
                WIP = WIP + 1
                tool_dur = ws.Cells(j, "F").Value
                date_dur = date_dur + tool_dur
            End If
            tool_dur = 0
        Next j
        
        j = stool
        Cells(i - (sdate - 2), "Q").Value = WIP
        If WIP <> 0 Then
            Cells(i - (sdate - 2), "R").Value = date_dur / WIP
        Else
            Cells(i - (sdate - 2), "R").Value = 0
        End If
    Next i

End Sub
Sub CycTimeCum()
    Dim sdate As Date
    Dim edate As Date
    Dim cyc As Integer
    Dim WIP As Integer
    Dim tool_dur As Integer
    Dim date_dur As Long
    Dim etool As Integer
    Dim stool As Integer
    
    Set ws = Worksheets("Sheet1")
    sdate = ws.Cells(2, "D").Value
    edate = Application.WorksheetFunction.Max(Sheet1.Range("Table1[SL2 Construction Finish]"))
    etool = ws.Range("Table1[SL2 Construction Finish]").Find(what:=edate).Row
    stool = ws.Range("D2").Row
    
    For i = sdate To (edate + 7)
        WIP = 0
        date_dur = 0
        i = CLng(i)
        Cells(i - (sdate - 2), "J") = i
        
        If (i) Mod (7) = 0 Then
            cyc = 0
            For j = stool To etool
                If ws.Cells(j, "E").Value >= i - 7 And ws.Cells(j, "E").Value < i Then
                    cyc = cyc + 1
                End If
            Next j
            If cyc <> 0 Then
                Cells(i - (sdate - 2), "M").Value = 150 / cyc
            Else
                Cells(i - (sdate - 2), "M").Value = 0
            End If
        End If
        
        stool = ws.Range("D2").Row
        
        For j = stool To etool
            
            If ws.Cells(j, "D").Value > i Then Exit For
                                    
            If ws.Cells(j, "E").Value > i And ws.Cells(j, "D").Value <= i Then
                WIP = WIP + 1
                tool_dur = ws.Cells(j, "E").Value - i
                date_dur = date_dur + tool_dur
            End If
            tool_dur = 0
        Next j
              
        j = stool
        Cells(i - (sdate - 2), "K").Value = WIP
        If WIP <> 0 Then
            Cells(i - (sdate - 2), "L").Value = date_dur / WIP
        Else
            Cells(i - (sdate - 2), "L").Value = 0
        End If
    Next i
      
    
End Sub

Sub CycTimeWeek()
    Dim edate As Date
    Dim cyc As Integer
    Dim WIP As Integer
    Dim tool_dur As Integer
    Dim date_dur As Long
    Dim etool As Integer
    Dim stool As Integer
    
    Set ws = Worksheets("Sheet1")
    sdate = ws.Cells(2, "D:D").Value
    edate = Application.WorksheetFunction.Max(Sheet1.Range("Table1[SL2 Construction Finish]"))
    etool = ws.Range("Table1[SL2 Construction Finish]").Find(what:=edate).Row
    stool = ws.Range("D2").Row
    
    For i = sdate To edate + 7
        WIP = 0
        date_dur = 0
        i = CLng(i)
        Cells(i - (sdate - 2), "P") = i
        
        If (i) Mod (7) = 0 Then
            cyc = 0
            For j = stool To etool
                If ws.Cells(j, "E").Value >= i - 7 And ws.Cells(j, "E").Value < i Then
                    cyc = cyc + 1
                End If
            Next j
            If cyc <> 0 Then
                Cells(i - (sdate - 2), "S").Value = 150 / cyc
            Else
                Cells(i - (sdate - 2), "S").Value = 0
            End If
        End If
        
        stool = ws.Range("D2").Row
        
        For j = stool To etool
            
            If ws.Cells(j, "D").Value > i Then Exit For
                                    
            If ws.Cells(j, "E").Value > i And ws.Cells(j, "D").Value <= i Then
                WIP = WIP + 1
                tool_dur = ws.Cells(j, "F").Value
                date_dur = date_dur + tool_dur
            End If
            tool_dur = 0
        Next j
              
        j = stool
        Cells(i - (sdate - 2), "Q").Value = WIP
        If WIP <> 0 Then
            Cells(i - (sdate - 2), "R").Value = date_dur / WIP
        Else
            Cells(i - (sdate - 2), "R").Value = 0
        End If
    Next i
    
End Sub

Sub CycTimeTool()
    
    Dim sdate As Date
    Dim stool As Integer
    Dim edate As Date
    Dim etool As Integer
    Dim sTdate As Date
    Dim eTdate As Date
    Dim srow As Integer
    Dim erow As Integer
    
       
    Set ws = Worksheets("Sheet1")
    sdate = Application.WorksheetFunction.Min(ws.Range("Table1[Prefac Start]"))
    stool = ws.Range("Table1[Prefac Start]").Find(what:=sdate).Row
    edate = Application.WorksheetFunction.Max(ws.Range("Table1[Prefac Start]"))
    etool = ws.Range("Table1[Prefac Start]").Find(what:=edate).Row
    dates = ws.Range("H:H")
    
    ws.Range("G1") = "Average WIP"
    ws.Range("H1") = "Average Cycle Time * 100"
    

    
    For i = stool To etool
        sTdate = ws.Cells(i, "D").Value
        eTdate = ws.Cells(i, "E").Value
        dur = eTdate - sTdate + 1
        WIP_tot = 0
        ftools = 0
        srow = ws.Range("J:J").Find(what:=sTdate).Row
        erow = ws.Range("J:J").Find(what:=eTdate).Row
        
        For j = srow To erow
            WIP_tot = WIP_tot + ws.Cells(j, "K").Value
        Next j
        
        For k = stool To etool
           
            If ws.Cells(k, "D").Value > eTdate Then Exit For
            
            If ws.Cells(k, "D").Value > sTdate And ws.Cells(k, "E").Value < eTdate Then
                ftools = ftools + 1
            End If
        Next k
        
        WIP_avg = WIP_tot / dur
        Cells(i, "G") = WIP_avg
        cyc_avg = 100 * ftools / dur
        Cells(i, "H") = cyc_avg
        
    Next i
        
    Range("Table1[[Average WIP]:[Average Cycle Time]]").Select
    Range(Selection, Selection.End(xlToRight)).Select
    Range(Selection, Selection.End(xlDown)).Select
    ActiveSheet.Shapes.AddChart2(322, xlColumnClustered).Select
    ActiveChart.FullSeriesCollection(1).ChartType = xlColumnClustered
    ActiveChart.FullSeriesCollection(2).ChartType = xlLine
    ActiveChart.FullSeriesCollection(2).Select
    ActiveChart.FullSeriesCollection(1).Name = "=Sheet1!$G$1"
    ActiveChart.FullSeriesCollection(2).Name = "=Sheet1!$H$1"
    ActiveChart.FullSeriesCollection(2).XValues = "=Sheet1!$A$2:$A$445"
    ActiveChart.ChartTitle.Select
    ActiveChart.ChartTitle.Text = _
        "Average WIP and Cycle Time From Prefac Start to SL2 Construction Finish for Each Tool"
    Selection.Format.TextFrame2.TextRange.Characters.Text = _
        "Average WIP and Cycle Time From Prefac Start to SL2 Construction Finish for Each Tool"
    With Selection.Format.TextFrame2.TextRange.Characters(1, 85).ParagraphFormat
        .TextDirection = msoTextDirectionLeftToRight
        .Alignment = msoAlignCenter
    End With
    With Selection.Format.TextFrame2.TextRange.Characters(1, 31).Font
        .BaselineOffset = 0
        .Bold = msoFalse
        .NameComplexScript = "+mn-cs"
        .NameFarEast = "+mn-ea"
        .Fill.Visible = msoTrue
        .Fill.ForeColor.RGB = RGB(89, 89, 89)
        .Fill.Transparency = 0
        .Fill.Solid
        .Size = 14
        .Italic = msoFalse
        .Kerning = 12
        .Name = "+mn-lt"
        .UnderlineStyle = msoNoUnderline
        .Spacing = 0
        .Strike = msoNoStrike
    End With
    With Selection.Format.TextFrame2.TextRange.Characters(32, 54).Font
        .BaselineOffset = 0
        .Bold = msoFalse
        .NameComplexScript = "+mn-cs"
        .NameFarEast = "+mn-ea"
        .Fill.Visible = msoTrue
        .Fill.ForeColor.RGB = RGB(89, 89, 89)
        .Fill.Transparency = 0
        .Fill.Solid
        .Size = 14
        .Italic = msoFalse
        .Kerning = 12
        .Name = "+mn-lt"
        .UnderlineStyle = msoNoUnderline
        .Spacing = 0
        .Strike = msoNoStrike
    End With
End Sub
