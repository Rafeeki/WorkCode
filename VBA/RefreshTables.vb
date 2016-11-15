Sub RefreshTables()
'
' Macro5 Macro
'

'
    Selection.ListObject.QueryTable.Refresh BackgroundQuery:=False
    ActiveCell.Offset(1, 1).Select
    Range(Selection, Selection.End(xlDown)).Select
    Selection.TextToColumns DataType:=xlDelimited, _
        TextQualifier:=xlDoubleQuote, ConsecutiveDelimiter:=False, Tab:=True, _
        Semicolon:=False, Comma:=False, Space:=False, Other:=False, FieldInfo _
        :=Array(1, 1), TrailingMinusNumbers:=True
    ActiveCell.Offset(0, 1).Select
    Range(Selection, Selection.End(xlDown)).Select
    Selection.TextToColumns DataType:=xlDelimited, _
        TextQualifier:=xlDoubleQuote, ConsecutiveDelimiter:=False, Tab:=True, _
        Semicolon:=False, Comma:=False, Space:=False, Other:=False, FieldInfo _
        :=Array(1, 1), TrailingMinusNumbers:=True
End Sub
