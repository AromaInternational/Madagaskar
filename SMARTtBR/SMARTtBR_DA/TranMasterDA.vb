Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class TranMasterDA
    Private M_DBConn As Connection
    Private M_TranID As Integer

    Public Function Fill_TranGrid(Optional ByVal TranID As Integer = 0) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "Select * from Transaction_Vw "
            M_Sql = M_Sql & " Where TranID = " & TranID & " Order By TranSeqNo"

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Locate_Data(ByVal M_TranID As Integer) As TranMasterBO        Try            Dim M_Dt As New DataTable            Dim M_TranMaster As New TranMasterBO            Dim Qry As String            Qry = "Select * from TransactionMaster_T_Tbl where TranID = " & M_TranID            M_DBConn.ExecuteDataTable(M_Dt, Qry)            If M_Dt.Rows.Count > 0 Then                With M_TranMaster                    .TrDate = M_Dt.Rows(0).Item("TrDate")
                    .InvoiceDate = M_Dt.Rows(0).Item("InvoiceDate")
                    .TranID = M_Dt.Rows(0).Item("TranID")
                    .ClientID = M_Dt.Rows(0).Item("ClientID")
                    .CurrencyEntryID = M_Dt.Rows(0).Item("CurrencyEntryID")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterId = M_Dt.Rows(0).Item("Updater_Id")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .RoundOff = M_Dt.Rows(0).Item("RoundOff")
                    .GrossAmount = M_Dt.Rows(0).Item("GrossAmount")
                    .NetAmount = M_Dt.Rows(0).Item("NetAmount")
                    .Frieght = M_Dt.Rows(0).Item("Frieght")
                    .DiscountOnTotal = M_Dt.Rows(0).Item("DiscountOnTotal")
                    .BillNo = M_Dt.Rows(0).Item("BillNo")
                    .ShipmentAddress = M_Dt.Rows(0).Item("ShipmentAddress")
                    .BillingAddress = M_Dt.Rows(0).Item("BillingAddress")
                    .InvoiceNumber = M_Dt.Rows(0).Item("InvoiceNumber")
                    .Remarks = M_Dt.Rows(0).Item("Remarks")
                    .AutoRoundOff = M_Dt.Rows(0).Item("AutoRoundOff")

                End With            End If            Return M_TranMaster        Catch ex As Exception            Return Nothing        End Try    End Function

    Public Function Save_Data(ByVal M_TranMaster As TranMasterBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String, ByVal M_TranSw As String) As Integer        Try            Dim M_Sql As String            With M_TranMaster                M_Sql = "Exec IUM_TransactionMaster_Sp "                M_Sql = M_Sql & "'" & M_EntryMode & "',"                M_Sql = M_Sql & M_MenuID & ","                M_Sql = M_Sql & .TranID & ","
                M_Sql = M_Sql & "'" & .BillNo & "',"
                M_Sql = M_Sql & "'" & Format(.TrDate, "MM/dd/yyyy") & "',"
                M_Sql = M_Sql & .ClientID & ","
                M_Sql = M_Sql & "'" & .ShipmentAddress & "',"
                M_Sql = M_Sql & "'" & .BillingAddress & "',"
                M_Sql = M_Sql & "'" & Format(.InvoiceDate, "MM/dd/yyyy") & "',"
                M_Sql = M_Sql & "'" & .InvoiceNumber & "',"
                M_Sql = M_Sql & .RoundOff & ","
                M_Sql = M_Sql & .GrossAmount & ","
                M_Sql = M_Sql & .NetAmount & ","
                M_Sql = M_Sql & .Frieght & ","
                M_Sql = M_Sql & .DiscountOnTotal & ","
                M_Sql = M_Sql & .CurrencyEntryID & ","
                M_Sql = M_Sql & "'" & .Remarks & "',"
                M_Sql = M_Sql & "'" & .AutoRoundOff & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterId & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "',"
                M_Sql = M_Sql & "'" & M_TranSw & "'"

            End With            M_TranID = M_DBConn.ExecuteScalar(M_Sql)            Return M_TranID        Catch ex As Exception            'MsgBox(ex.Message)            Return False        End Try    End Function

    Public Sub New()
        Try
            M_DBConn = New Connection
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            M_DBConn = Nothing
            MyBase.Finalize()
        Catch ex As Exception
        End Try
    End Sub
End Class
