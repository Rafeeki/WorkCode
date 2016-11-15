Sub DelRow()
 For i = 1 To 5100
    If i > 4000 And Range("A" & i).Value = "" Then
        GoTo EndRow:
    End If
    If Left(Range("A" & i).Value, 2) <> "[{" Then
        Rows(i).Delete
        i = i - 1
    End If
 Next i
EndRow:

End Sub
