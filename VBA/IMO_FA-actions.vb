Sub Actions()
    
    Set bfa = ActiveWorkbook.Sheets(1)
    Set act = ActiveWorkbook.Sheets(2)
    
    x = 2
    
    For i = 53 To 1861
        cell = bfa.Range("A" & i).Value
        If InStr(1, cell, "ACT") = 1 Or InStr(1, cell, "SEQ") = 1 Then
            s1 = InStr(1, cell, " ")
            ty = Left(cell, s1 - 1)
            s2 = InStr(s1 + 1, cell, " ")
            If s2 = 0 Then
                ID = Right(cell, Len(cell) - s1)
                msg = ""
                GoTo PlugIn:
            End If
            
            ID = Mid(cell, s1 + 1, s2 - s1 - 1)
            msg = Right(cell, Len(cell) - s2)
PlugIn:
            act.Range("A" & x).Value = ID
            act.Range("B" & x).Value = ty
            act.Range("D" & x).Value = msg
            x = x + 1
        End If
    Next i
End Sub

Sub ActionRespsSeqs()
    Set bfa = ActiveWorkbook.Sheets(1)
    Set actr = ActiveWorkbook.Sheets("ActionResponses")
    Set acts = ActiveWorkbook.Sheets("ActionsSequences")
    
    actr.Range("A2:D1500").NumberFormat = "@"
    acts.Range("A2:C1500").NumberFormat = "@"
    
    R = 2
    s = 2
    
    For i = 53 To 1861
        cell = bfa.Range("A" & i).Value
        If InStr(1, cell, "ACT") = 1 Then
            st = InStr(1, cell, " ")
            actID = Mid(cell, st + 1, 4)
        End If
        
        If Left(cell, 4) = "    " Then
            If actID = "" Then
                GoTo NextIteration:
            End If
            
            s1 = InStr(5, cell, " ")
            s2 = InStr(s1 + 1, cell, " ")
            l = Len(cell)
            If s2 = 10 Then
                out = Mid(cell, 5, 2)
                pri = Mid(cell, 8, 2)
                resp_id = Replace(Mid(cell, 11, 9), " ", "")
                If out = 10 Or out = 8 Then
                    pri = ""
                    resp_id = Replace(Mid(cell, 8, 9), " ", "")
                End If
                
                actr.Range("A" & R).Value = actID
                actr.Range("B" & R).Value = out
                actr.Range("C" & R).Value = pri
                actr.Range("D" & R).Value = resp_id
                R = R + 1
            Else
                act_out = Mid(cell, 5, 2)
                respa_id = Mid(cell, 8, 4)
                acts.Range("A" & s).Value = actID
                acts.Range("B" & s).Value = act_out
                acts.Range("C" & s).Value = respa_id
                s = s + 1
            End If
        End If
        
        If IsEmpty(cell) Then
            s1 = ""
            actID = ""
            l = ""
            act_out = ""
            out = ""
            pri = ""
            resp_id = ""
        End If
NextIteration:
    Next i


End Sub