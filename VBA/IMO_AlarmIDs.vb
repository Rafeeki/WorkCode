Sub AlmID()
    Set alm = ThisWorkbook.Sheets(1)
    Set bfz = ThisWorkbook.Sheets(2)
    Set ids = alm.Range("C2:C1484")
    x = 2
    For Each i In ids
        
        code = Left(i, 2) + " " + Mid(i, 3, 2) + " " + Right(i, 2)
        
        For b = 128 To 6683
            
            cell = bfz.Range("A" & b).Value
            
            If Left(cell, 1) = " " Or Left(cell, 1) = "0" Then
                GoTo NextIt:
            ElseIf InStr(1, cell, code) Then
                s1 = InStr(1, cell, " ")
                ty = Left(cell, s1 - 1)
                s2 = InStr(15, cell, " ")
                tool = Right(cell, Len(cell) - s2 - 1)
                alm.Range("A" & x).Value = tool
                alm.Range("B" & x).Value = ty
            End If
NextIt:
        Next b
        x = x + 1
    Next i
    
End Sub
