Sub IO_Table()


    j = 1
    Worksheets("IO_Table").Range("A2:D1912").NumberFormat = "@"
    Worksheets("IO_Table").Range("A1").Value = "Address"
    Worksheets("IO_Table").Range("B1").Value = "Zone"
    Worksheets("IO_Table").Range("C1").Value = "Panel"
    Worksheets("IO_Table").Range("D1").Value = "Device"
    Worksheets("IO_Table").Range("E1").Value = "Location"
    Worksheets("IO_Table").Range("F1").Value = "Message"
    Worksheets("IO_Table").Range("G1").Value = "GDP"
    
    For i = 128 To 2040
        
        desc = Worksheets("Bfm05185").Cells(i, "A").Value
        If Left(desc, 1) = "#" And Left(desc, 2) <> "#Z" Then
            gdp = Mid(desc, 2, 150)
            GoTo Seeya:
        End If
        
        If Left(desc, 1) = "Z" Then
            zone = Mid(desc, 3, 2)
            panel = Mid(desc, 6, 2)
            device = Mid(desc, 9, 2)
            s = Mid(desc, 14, 150)
            s_len = Len(s)
            j = j + 1
        
        ElseIf Left(desc, 2) = "#Z" Then
            zone = Mid(desc, 4, 2)
            panel = Mid(desc, 7, 2)
            device = Mid(desc, 10, 2)
            s = Mid(desc, 15, 150)
            s_len = Len(s)
            j = j + 1
        End If
        
        Address = zone + panel + device
        Worksheets("IO_Table").Cells(j, "A").Value = Address
        Worksheets("IO_Table").Cells(j, "B").Value = zone
        Worksheets("IO_Table").Cells(j, "C").Value = panel
        Worksheets("IO_Table").Cells(j, "D").Value = device
        

        If InStr(2, s, "\") = 0 Then
            If InStrRev(s, "/") = 0 Then
                If InStrRev(s, "-") = 0 Then
                    If InStrRev(s, ",") = 0 Then
                        Location = Mid(s, 2, s_len - 2)
                        Message = "n/a"
                    Else
                        Separator = InStrRev(s, ",")
                        Location = Mid(s, 2, Separator - 2)
                        Message = Mid(s, Separator + 1, s_len - Separator - 1)
                    End If
                Else
                    Separator = InStrRev(s, "-")
                    Location = Mid(s, 2, Separator - 2)
                    Message = Mid(s, Separator + 1, s_len - Separator - 1)
                End If
            Else
                Separator = InStrRev(s, "/")
                Location = Mid(s, 2, Separator - 2)
                Message = Mid(s, Separator + 1, s_len - Separator - 1)
            End If
        Else
            Separator = InStr(2, s, "\")
            Location = Mid(s, 2, Separator - 2)
            Message = Mid(s, Separator + 2, s_len - Separator - 2)
        End If

        If InStr(1, Location, "Spare", 1) > 0 Then
            Separator = InStr(1, Location, "Spare", 1)
            If Separator < 2 Then
                Message = Location + " " + Message
                Location = "n/a"
            Else
                loc1 = Mid(Location, 1, Separator - 1)
                Message = Right(Location, Len(Location) - Separator + 1)
                Location = loc1
            End If
        End If
        

        
        If InStr(1, Location, "GDS", 1) > 0 Then
            gds_loc = Right(Location, Len(Location) - InStr(1, Location, "GDS", 1) + 1)
            Message = gds_loc + " " + Message
            Location = Left(Location, InStr(1, Location, "GDS", 1) - 1)
        End If
        
        Worksheets("IO_Table").Cells(j, "E").Value = Location
        Worksheets("IO_Table").Cells(j, "F").Value = Message
        If InStr(1, Location, "GDP", 1) > 0 And InStr(1, gdp, "GDP", 1) = 0 Then
            gdp_loc = Mid(Location, InStr(1, Location, "GDP", 1), 7)
            Worksheets("IO_Table").Cells(j, "G").Value = gdp_loc + " " + gdp
        Else
            Worksheets("IO_Table").Cells(j, "G").Value = gdp
        End If

Seeya:
        
          
    Next i

End Sub
