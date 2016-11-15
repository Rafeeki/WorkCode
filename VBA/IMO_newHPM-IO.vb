Sub HPM_IO()
    
    Worksheets("HPM_IO").Range("A2:D2702").NumberFormat = "@"
    i = 2
    For p = 2 To 26
        'Select panel from Panels, input PanelName, Loop and Panel onto HPM_IO before digging into the modules
        pan = Sheets("Panels").Cells(p, "C").Value

        If Left(pan, 3) = "GDP" Then
            'Define each slot according to DI_D, DO_D, DO, & AI rules
            For slot = 4 To 15
                If slot < 7 Then
                    For did = 0 To 15
                        Sheets("HPM_IO").Cells(i, "M").Value = pan
                        Sheets("HPM_IO").Cells(i, "A").Value = Mid(pan, 8, 1)
                        Sheets("HPM_IO").Cells(i, "B").Value = Right(pan, 3)
                        Sheets("HPM_IO").Cells(i, "H").Value = "DI_D"
                        Sheets("HPM_IO").Cells(i, "C").Value = "0" & slot
                        If did < 10 Then
                            Sheets("HPM_IO").Cells(i, "D").Value = "0" & did
                        Else
                            Sheets("HPM_IO").Cells(i, "D").Value = did
                        End If
                        Sheets("HPM_IO").Cells(i, "E").Value = Sheets("HPM_IO").Cells(i, "A").Value & Sheets("HPM_IO").Cells(i, "B").Value & Sheets("HPM_IO").Cells(i, "C").Value & Sheets("HPM_IO").Cells(i, "D").Value
                        Sheets("HPM_IO").Cells(i, "G").Value = "BOOL"
                        Sheets("HPM_IO").Cells(i, "I").Value = "Spare DI_D"
                        i = i + 1
                    Next did
                ElseIf slot < 10 Then
                    For dod = 0 To 15
                        Sheets("HPM_IO").Cells(i, "M").Value = pan
                        Sheets("HPM_IO").Cells(i, "A").Value = Mid(pan, 8, 1)
                        Sheets("HPM_IO").Cells(i, "B").Value = Right(pan, 3)
                        Sheets("HPM_IO").Cells(i, "H").Value = "DO_D"
                        Sheets("HPM_IO").Cells(i, "C").Value = "0" & slot
                        If dod < 10 Then
                            Sheets("HPM_IO").Cells(i, "D").Value = "0" & dod
                        Else
                            Sheets("HPM_IO").Cells(i, "D").Value = dod
                        End If
                        Sheets("HPM_IO").Cells(i, "E").Value = Sheets("HPM_IO").Cells(i, "A").Value & Sheets("HPM_IO").Cells(i, "B").Value & Sheets("HPM_IO").Cells(i, "C").Value & Sheets("HPM_IO").Cells(i, "D").Value
                        Sheets("HPM_IO").Cells(i, "G").Value = "BOOL"
                        Sheets("HPM_IO").Cells(i, "I").Value = "Spare DO_D"
                        i = i + 1
                    Next dod
                ElseIf slot < 13 Then
                    For dio = 0 To 31
                        Sheets("HPM_IO").Cells(i, "M").Value = pan
                        Sheets("HPM_IO").Cells(i, "A").Value = Mid(pan, 8, 1)
                        Sheets("HPM_IO").Cells(i, "B").Value = Right(pan, 3)
                        Sheets("HPM_IO").Cells(i, "H").Value = "DO"
                        Sheets("HPM_IO").Cells(i, "C").Value = slot
                        If dio < 10 Then
                            Sheets("HPM_IO").Cells(i, "D").Value = "0" & dio
                        Else
                            Sheets("HPM_IO").Cells(i, "D").Value = dio
                        End If
                        Sheets("HPM_IO").Cells(i, "E").Value = Sheets("HPM_IO").Cells(i, "A").Value & Sheets("HPM_IO").Cells(i, "B").Value & Sheets("HPM_IO").Cells(i, "C").Value & Sheets("HPM_IO").Cells(i, "D").Value
                        Sheets("HPM_IO").Cells(i, "G").Value = "BOOL"
                        Sheets("HPM_IO").Cells(i, "I").Value = "Spare DO"
                        i = i + 1
                    Next dio
                Else
                    For ai = 0 To 7
                        Sheets("HPM_IO").Cells(i, "M").Value = pan
                        Sheets("HPM_IO").Cells(i, "A").Value = Mid(pan, 8, 1)
                        Sheets("HPM_IO").Cells(i, "B").Value = Right(pan, 3)
                        Sheets("HPM_IO").Cells(i, "H").Value = "AI"
                        Sheets("HPM_IO").Cells(i, "C").Value = slot
                        Sheets("HPM_IO").Cells(i, "D").Value = "0" & ai
                        Sheets("HPM_IO").Cells(i, "E").Value = Sheets("HPM_IO").Cells(i, "A").Value & Sheets("HPM_IO").Cells(i, "B").Value & Sheets("HPM_IO").Cells(i, "C").Value & Sheets("HPM_IO").Cells(i, "D").Value
                        Sheets("HPM_IO").Cells(i, "G").Value = "WORD"
                        Sheets("HPM_IO").Cells(i, "I").Value = "Spare AI"
                        i = i + 1
                    Next ai
                End If
                
            Next slot
        Else
            'Allocate 81 VRT points per panel as slot 01 and with Gas Type Cl2
            For v = 1 To 81
                Sheets("HPM_IO").Cells(i, "M").Value = pan
                Sheets("HPM_IO").Cells(i, "A").Value = Mid(pan, 8, 1)
                Sheets("HPM_IO").Cells(i, "B").Value = Right(pan, 3)
                Sheets("HPM_IO").Cells(i, "H").Value = "VRT"
                Sheets("HPM_IO").Cells(i, "C").Value = "0" & 1
                If v < 10 Then
                    Sheets("HPM_IO").Cells(i, "D").Value = "0" & v
                Else
                    Sheets("HPM_IO").Cells(i, "D").Value = v
                End If
                Sheets("HPM_IO").Cells(i, "E").Value = Sheets("HPM_IO").Cells(i, "A").Value & Sheets("HPM_IO").Cells(i, "B").Value & Sheets("HPM_IO").Cells(i, "C").Value & Sheets("HPM_IO").Cells(i, "D").Value
                Sheets("HPM_IO").Cells(i, "G").Value = "WORD"
                Sheets("HPM_IO").Cells(i, "I").Value = "Spare VRT"
                Sheets("HPM_IO").Cells(i, "R").Value = "Cl2"
                i = i + 1
            Next v
        End If
    Next p
End Sub
