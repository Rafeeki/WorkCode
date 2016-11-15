Sub ChemguardFab()
    
    F12 = Range("Chemguards!$C$2:$F$11")
    F22 = Range("Chemguards!$C$14:$F$24")
    F32 = Range("Chemguards!$C$27:$C$41")
    
    s = 2
    e = 94
    Count = 2
    Range("T1") = "Missing from Layout"
    
    For i = s To e
        tool = Right(Range("Chemguards!I" & i).Value, 6)
        
        
        For Each cell In F12
            If tool = cell Then
                Range("R" & i).Value = "F12"
            End If
        Next
        
        For Each cell In F22
            If tool = cell Then
                Range("R" & i).Value = "F22"
            End If
        Next
                
        For Each cell In F32
            If tool = cell Then
                Range("R" & i).Value = "F32"
            End If
        Next
        
        If Range("R" & i).Value = "" Then
            Range("R" & i).Value = "n/a"
            Range("T" & Count).Value = tool
            Count = Count + 1
        End If
        
    Next
    
    
    
End Sub

Sub AirgardFab()
    
    F12 = Range("Chemguards!$C$2:$F$11")
    F22 = Range("Chemguards!$C$14:$F$24")
    F32 = Range("Chemguards!$C$27:$C$41")
    
    s = 2
    e = 94
    Count = 2
    Range("T1") = "Missing from Layout"
    
    For i = s To e
        tool = Right(Range("Chemguards!I" & i).Value, 6)
        
        
        For Each cell In F12
            If tool = cell Then
                Range("R" & i).Value = "F12"
            End If
        Next
        
        For Each cell In F22
            If tool = cell Then
                Range("R" & i).Value = "F22"
            End If
        Next
                
        For Each cell In F32
            If tool = cell Then
                Range("R" & i).Value = "F32"
            End If
        Next
        
        If Range("R" & i).Value = "" Then
            Range("R" & i).Value = "n/a"
            Range("T" & Count).Value = tool
            Count = Count + 1
        End If
        
    Next
    
    
    
End Sub
