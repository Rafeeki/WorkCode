Sub DateClean()
    
    For i = 2 To 129
        orig = Cells(i, "A").Value
    If InStrRev(orig, "-") = 0 Then
        Cells(i, "B").Value = orig
        GoTo SeeYa:
    Else
        l = InStrRev(orig, "-")
        orig_y = Left(orig, l - 1) + "/" + Right(orig, Len(orig) - l)
        f = InStrRev(orig_y, "-")
        orig_f = Left(orig_y, f - 1) + "/" + Right(orig_y, Len(orig_y) - f)
        Cells(i, "B").Value = orig_f
    End If
     
SeeYa:
            
    Next i
End Sub
