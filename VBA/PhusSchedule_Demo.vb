'DEMO:

Sub BCD()
'
' BCD Macro
    Dim ALL_tot As Integer
    Dim BCD_tot As Integer
    Dim AccuProg As Double
    Dim Activity As String

    ALL_tot = GrandTot()
    
    ActiveSheet.PivotTables("PivotTable1").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable8").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable2").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable9").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("CR").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    BCD_tot = GrandTot()
    AccuProg = Round(BCD_tot / ALL_tot, 4)
    Activity = Range("B8").Value
    Sheets("Demo with BL Chart").Select
        ActiveChart.ChartArea.Select
        ActiveChart.ChartTitle.Select
        ActiveChart.ChartTitle.Text = " PSSS+Laterals LOR 3.3-" & Activity & " (BCD)" & Chr(13) & _
        " Accu.Progress - " & AccuProg * 100 & "% (" & BCD_tot & "/" & ALL_tot & ")"
        

End Sub
Sub SpecGas()
'
' SpecGas Macro
'
    Dim ALL_tot As Integer
    Dim SG_tot As Integer
    Dim AccuProg As Double
    Dim Activity As String

    ALL_tot = GrandTot()
    
    Sheets("Demo with BL").Select
    ActiveSheet.PivotTables("PivotTable1").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = True
        .PivotItems("(blank)").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable8").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = True
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable2").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = True
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable9").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = True
        .PivotItems("(blank)").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    SG_tot = GrandTot()
    AccuProg = Round(SG_tot / ALL_tot, 4)
    Activity = Range("B8").Value
    Sheets("Demo with BL Chart").Select
        ActiveChart.ChartArea.Select
        ActiveChart.ChartTitle.Select
        ActiveChart.ChartTitle.Text = " PSSS+Laterals LOR 3.3-" & Activity & " (Spec Gas)" & Chr(13) & _
        " Accu.Progress - " & AccuProg * 100 & "% (" & SG_tot & "/" & ALL_tot & ")"

End Sub
Sub LSS()
'
' LSS Macro
'

    Dim ALL_tot As Integer
    Dim LSS_tot As Integer
    Dim AccuProg As Double
    Dim Activity As String

    ALL_tot = GrandTot()
    ActiveSheet.PivotTables("PivotTable1").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable8").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable2").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable9").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    LSS_tot = GrandTot()
    AccuProg = Round(LSS_tot / ALL_tot, 4)
    Activity = Range("B8").Value
    Sheets("Demo with BL Chart").Select
        ActiveChart.ChartArea.Select
        ActiveChart.ChartTitle.Select
        ActiveChart.ChartTitle.Text = " PSSS+Laterals LOR 3.3-" & Activity & " (LSS)" & Chr(13) & _
        " Accu.Progress - " & AccuProg * 100 & "% (" & LSS_tot & "/" & ALL_tot & ")"
End Sub
Sub Lateral()
'
' Lateral Macro
'
    Dim ALL_tot As Integer
    Dim LAT_tot As Integer
    Dim AccuProg As Double
    Dim Activity As String

    ALL_tot = GrandTot()
    ActiveSheet.PivotTables("PivotTable1").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = True
    End With
    ActiveSheet.PivotTables("PivotTable8").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = True
    End With
    ActiveSheet.PivotTables("PivotTable2").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = True
    End With
    ActiveSheet.PivotTables("PivotTable9").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = True
    End With
    LAT_tot = GrandTot()
    AccuProg = Round(LAT_tot / ALL_tot, 4)
    Activity = Range("B8").Value
    Sheets("Demo with BL Chart").Select
        ActiveChart.ChartArea.Select
        ActiveChart.ChartTitle.Select
        ActiveChart.ChartTitle.Text = " PSSS+Laterals LOR 3.3-" & Activity & " (Laterals)" & Chr(13) & _
        " Accu.Progress - " & AccuProg * 100 & "% (" & LAT_tot & "/" & ALL_tot & ")"
End Sub
Sub Electrical()
'
' Electrical Macro
'
    Dim ALL_tot As Integer
    Dim ELEC_tot As Integer
    Dim AccuProg As Double
    Dim Activity As String

    ALL_tot = GrandTot()
    ActiveSheet.PivotTables("PivotTable1").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("Electrical").Visible = True
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable8").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = True
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable2").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = True
        .PivotItems("CR").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable9").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("CR").Visible = False
        .PivotItems("Electrical").Visible = True
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ELEC_tot = GrandTot()
    AccuProg = Round(ELEC_tot / ALL_tot, 4)
    Activity = Range("B8").Value
    Sheets("Demo with BL Chart").Select
        ActiveChart.ChartArea.Select
        ActiveChart.ChartTitle.Select
        ActiveChart.ChartTitle.Text = " PSSS+Laterals LOR 3.3-" & Activity & " (Electrical)" & Chr(13) & _
        " Accu.Progress - " & AccuProg * 100 & "% (" & ELEC_tot & "/" & ALL_tot & ")"
End Sub
Sub CR()
'
' CleanRoom Macro
'
    Dim ALL_tot As Integer
    Dim CR_tot As Integer
    Dim AccuProg As Double
    Dim Activity As String

    ALL_tot = GrandTot()
    ActiveSheet.PivotTables("PivotTable1").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable8").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable2").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("Electrical").Visible = False
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable9").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Category")
        .PivotItems("BCD").Visible = False
        .PivotItems("CR").Visible = True
        .PivotItems("Electrical").Visible = False
        .PivotItems("SG").Visible = False
        .PivotItems("(blank)").Visible = False
        .PivotItems("LSS").Visible = False
        .PivotItems("I&C").Visible = False
        .PivotItems("IT").Visible = False
        .PivotItems("CSA").Visible = False
        .PivotItems("Category").Visible = False
        .PivotItems("Laterals").Visible = False
    End With
    CR_tot = GrandTot()
    AccuProg = Round(CR_tot / ALL_tot, 4)
    Activity = Range("B8").Value
    Sheets("Demo with BL Chart").Select
        ActiveChart.ChartArea.Select
        ActiveChart.ChartTitle.Select
        ActiveChart.ChartTitle.Text = " PSSS+Laterals LOR 3.3-" & Activity & " (CR)" & Chr(13) & _
        " Accu.Progress - " & AccuProg * 100 & "% (" & ELEC_tot & "/" & ALL_tot & ")"
End Sub
Sub All_DF()
'
' All_DF Macro
'
    Dim ALL_tot As Integer
    Dim AccuProg As Double

    Sheets("Demo with BL").Select
    ActiveSheet.PivotTables("PivotTable1").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("Electrical").Visible = True
        .PivotItems("SG").Visible = True
        .PivotItems("(blank)").Visible = True
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = True
        .PivotItems("IT").Visible = True
        .PivotItems("CSA").Visible = True
        .PivotItems("Category").Visible = True
        .PivotItems("Laterals").Visible = True
    End With
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Activity Name")
        .PivotItems("Demo DSL1/2 Signoff").Visible = False
        .PivotItems("Demo Finish").Visible = True
    End With
    ActiveSheet.PivotTables("PivotTable8").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("(blank)").Visible = True
        .PivotItems("SG").Visible = True
        .PivotItems("Electrical").Visible = True
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = True
        .PivotItems("IT").Visible = True
        .PivotItems("CSA").Visible = True
        .PivotItems("Category").Visible = True
        .PivotItems("Laterals").Visible = True
    End With
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Activity Name")
        .PivotItems("Demo DSL1/2 Signoff").Visible = False
        .PivotItems("Demo Finish").Visible = True
    End With
    ActiveSheet.PivotTables("PivotTable2").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("(blank)").Visible = True
        .PivotItems("SG").Visible = True
        .PivotItems("Electrical").Visible = True
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = True
        .PivotItems("IT").Visible = True
        .PivotItems("CSA").Visible = True
        .PivotItems("Category").Visible = True
        .PivotItems("Laterals").Visible = True
    End With
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Activity Name")
        .PivotItems("Demo DSL1/2 Signoff").Visible = False
        .PivotItems("Demo Finish").Visible = True
    End With
    ActiveSheet.PivotTables("PivotTable9").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("CR").Visible = True
        .PivotItems("Electrical").Visible = True
        .PivotItems("SG").Visible = True
        .PivotItems("(blank)").Visible = True
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = True
        .PivotItems("IT").Visible = True
        .PivotItems("CSA").Visible = True
        .PivotItems("Category").Visible = True
        .PivotItems("Laterals").Visible = True
    End With
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Activity Name")
        .PivotItems("Demo DSL1/2 Signoff").Visible = False
        .PivotItems("Demo Finish").Visible = True
    End With
    ALL_tot = GrandTot()
    Sheets("Demo with BL Chart").Select
        ActiveChart.ChartArea.Select
        ActiveChart.ChartTitle.Select
        ActiveChart.ChartTitle.Text = " PSSS+Laterals LOR 3.3-DemoFinish (All)" & Chr(13) & _
        " Accu.Progress - " & ALL_tot / ALL_tot * 100 & "% (" & ALL_tot & "/" & ALL_tot & ")"
End Sub
Sub ALL_DSL()
'
' All_DSL Macro
'
    Dim ALL_tot As Integer
    Dim AccuProg As Double

    Sheets("Demo with BL").Select
    ActiveSheet.PivotTables("PivotTable1").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("Electrical").Visible = True
        .PivotItems("SG").Visible = True
        .PivotItems("(blank)").Visible = True
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = True
        .PivotItems("IT").Visible = True
        .PivotItems("CSA").Visible = True
        .PivotItems("Category").Visible = True
        .PivotItems("Laterals").Visible = True
    End With
    With ActiveSheet.PivotTables("PivotTable1").PivotFields("Activity Name")
        .PivotItems("Demo DSL1/2 Signoff").Visible = True
        .PivotItems("Demo Finish").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable8").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("(blank)").Visible = True
        .PivotItems("SG").Visible = True
        .PivotItems("Electrical").Visible = True
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = True
        .PivotItems("IT").Visible = True
        .PivotItems("CSA").Visible = True
        .PivotItems("Category").Visible = True
        .PivotItems("Laterals").Visible = True
    End With
    With ActiveSheet.PivotTables("PivotTable8").PivotFields("Activity Name")
        .PivotItems("Demo DSL1/2 Signoff").Visible = True
        .PivotItems("Demo Finish").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable2").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("(blank)").Visible = True
        .PivotItems("SG").Visible = True
        .PivotItems("Electrical").Visible = True
        .PivotItems("CR").Visible = True
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = True
        .PivotItems("IT").Visible = True
        .PivotItems("CSA").Visible = True
        .PivotItems("Category").Visible = True
        .PivotItems("Laterals").Visible = True
    End With
    With ActiveSheet.PivotTables("PivotTable2").PivotFields("Activity Name")
        .PivotItems("Demo DSL1/2 Signoff").Visible = True
        .PivotItems("Demo Finish").Visible = False
    End With
    ActiveSheet.PivotTables("PivotTable9").PivotFields("Category").CurrentPage = _
        "(All)"
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Category")
        .PivotItems("BCD").Visible = True
        .PivotItems("CR").Visible = True
        .PivotItems("Electrical").Visible = True
        .PivotItems("SG").Visible = True
        .PivotItems("(blank)").Visible = True
        .PivotItems("LSS").Visible = True
        .PivotItems("I&C").Visible = True
        .PivotItems("IT").Visible = True
        .PivotItems("CSA").Visible = True
        .PivotItems("Category").Visible = True
        .PivotItems("Laterals").Visible = True
    End With
    With ActiveSheet.PivotTables("PivotTable9").PivotFields("Activity Name")
        .PivotItems("Demo DSL1/2 Signoff").Visible = True
        .PivotItems("Demo Finish").Visible = False
    End With
    ALL_tot = GrandTot()
    Sheets("Demo with BL Chart").Select
        ActiveChart.ChartArea.Select
        ActiveChart.ChartTitle.Select
        ActiveChart.ChartTitle.Text = " PSSS+Laterals LOR 3.3-DSL1/2 Signoff (All)" & Chr(13) & _
        " Accu.Progress - " & ALL_tot / ALL_tot * 100 & "% (" & ALL_tot & "/" & ALL_tot & ")"
End Sub
