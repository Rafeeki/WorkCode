Sub ION_PowerLogic_DB()
'
' ION_PowerLogic_DB Macro
'

'
    With ActiveSheet.ListObjects.Add(SourceType:=0, Source:= _
        "ODBC;DRIVER=SQL Server;SERVER=172.25.131.133,1433;UID=IONAdmin;;APP=Microsoft Office 2013;WSID=RYANGENT-MOBL2;DATABASE=ION_Data" _
        , Destination:=Range("$BU$1")).QueryTable
        .CommandText = Array( _
        "SELECT DataLog2.TimestampUTC, Source.DisplayName, Quantity.Name, DataLog2.Value, Quantity.Unit" & Chr(13) & "" & Chr(10) & "FROM ION_Data.dbo.DataLog2 DataLog2, ION_Data.dbo.Quantity Quantity, ION_Data.dbo.Source Source" & Chr(13) & "" & Chr(10) & "WHERE " _
        , "DataLog2.QuantityID = Quantity.ID AND DataLog2.SourceID = Source.ID AND ((DataLog2.TimestampUTC>'2016-10-13 00:00:00.00') AND (Source.DisplayName Like ('%'+'RNB_MSB_B'+'%')) AND (Quantity.Name Like (" _
        , "'Active Power Mean'+'%')))")
        .RowNumbers = False
        .FillAdjacentFormulas = False
        .PreserveFormatting = True
        .RefreshOnFileOpen = False
        .BackgroundQuery = True
        .RefreshStyle = xlInsertDeleteCells
        .SavePassword = False
        .SaveData = True
        .AdjustColumnWidth = True
        .RefreshPeriod = 0
        .PreserveColumnInfo = True
        .ListObject.DisplayName = "Table_Query_from_SC_ION_PowerLogic_14"
        .Refresh BackgroundQuery:=False
    End With
End Sub