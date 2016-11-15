Sub R()
    Set h = ThisWorkbook.Sheets("Bfa05185")
    Set al = ThisWorkbook.Sheets("ActionResponses")
    Set List = h.Range("Bfa05185!Remove")
    
    al_remove = 0
    rs_remove = 0
    
    For Each Item In List
        
        For a = 2 To 1308
            If al.Range("D" & a).Value = Item Then
                al.Rows(a).Delete
                al_remove = al_remove + 1
                h.Range("N" & al_remove + 1).Value = a
            End If
        Next a

    Next Item
    h.Range("N1").Value = h.Range("N1").Value + " " + Str(al_remove)
End Sub
