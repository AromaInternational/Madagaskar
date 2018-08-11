Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class AccLedgerDA
    Private M_DBConn As Connection
    Private M_AccId As Long
    Public Function Save_Data(ByVal M_AccLedger As AccLedgerBO, ByVal M_TranSw As String, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As Long
        Try
            Dim M_Sql As String

            With M_AccLedger
                M_Sql = "Exec IUM_AccLedger_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & M_MenuID & ","
                M_Sql = M_Sql & .AccId & ","
                M_Sql = M_Sql & .AccUNID & ","
                M_Sql = M_Sql & "'" & .AccVrTyp & "',"
                M_Sql = M_Sql & .AccVrNo & ","
                M_Sql = M_Sql & "'" & .AccFinYear & "',"
                M_Sql = M_Sql & "'" & .AccType & "',"
                M_Sql = M_Sql & "'" & Format(.AccTrDate, "MM/dd/yyyy") & "',"
                M_Sql = M_Sql & "'" & .AccChqNo & "',"
                M_Sql = M_Sql & "'" & .AccOrgFrom & "',"
                M_Sql = M_Sql & "'" & .AccNarration & "',"
                M_Sql = M_Sql & "'" & Format(.AccChqDate, "MM/dd/yyyy") & "',"
                M_Sql = M_Sql & "'" & .ActiveStatus & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterID & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "',"
                M_Sql = M_Sql & "'" & M_TranSw & "','Y'"
            End With

            M_AccId = M_DBConn.ExecuteScalar(M_Sql)

            Return M_AccId

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Locate_Data(ByVal M_AccId As Long) As AccLedgerBO
        Try
            Dim M_Dt As New DataTable
            Dim M_AccLedger As New AccLedgerBO
            Dim Qry As String
            Qry = "Select * from AccLedger_M_Tbl where Acc_Id = " & M_AccId
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_AccLedger
                    .AccUNID = M_Dt.Rows(0).Item("Acc_UNID")
                    .AccVrNo = M_Dt.Rows(0).Item("Acc_VrNo")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .AccTrDate = M_Dt.Rows(0).Item("Acc_TrDate")
                    .AccChqDate = M_Dt.Rows(0).Item("Acc_ChqDate")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .AccId = M_Dt.Rows(0).Item("Acc_Id")
                    .AccVrTyp = M_Dt.Rows(0).Item("Acc_VrTyp")
                    .AccFinYear = M_Dt.Rows(0).Item("Acc_FinYear")
                    .AccChqNo = M_Dt.Rows(0).Item("Acc_ChqNo")
                    .AccOrgFrom = M_Dt.Rows(0).Item("Acc_OrgFrom")
                    .AccNarration = M_Dt.Rows(0).Item("Acc_Narration")
                    .AccType = M_Dt.Rows(0).Item("Acc_Type")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                End With
            End If
            Return M_AccLedger
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_AccTran(ByVal Acc_ID As Long) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "SELECT Acc_SlNo,Acc_TrType, Acc_Code, Acc_Name, Acc_CrAmount, Acc_DrAmount,Acc_TranType, Acc_Amt FROM AccLedgerDetails_Vw "
            M_Sql = M_Sql & " Where Acc_Id = " & Acc_ID & " Order By Acc_SlNo"

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Proc_AccTranSearch(ByVal M_CmpCode As Integer, ByVal M_FinYear As String, ByVal M_VoucherType As String, ByVal M_TrUnit As Integer, ByVal M_TrDateFrom As Date, _
                                       ByVal M_TrDateTo As Date, ByVal M_VrNoFrom As Integer, ByVal M_VrNoTo As Integer, ByVal M_AmountFrom As Double, _
                                       ByVal M_AmountTo As Double, ByVal M_TrType As Integer, ByVal M_AccCode As Integer, ByVal M_Remarks As String, ByVal M_UserID As Integer) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "Exec Proc_AccTranSearch_Sp "
            M_Sql = M_Sql & M_CmpCode & ","
            M_Sql = M_Sql & "'" & M_FinYear & "',"
            M_Sql = M_Sql & "'" & M_VoucherType & "',"
            M_Sql = M_Sql & M_TrUnit & ","
            M_Sql = M_Sql & "'" & Format(M_TrDateFrom, "MM/dd/yyyy") & "',"
            M_Sql = M_Sql & "'" & Format(M_TrDateTo, "MM/dd/yyyy") & "',"
            M_Sql = M_Sql & M_VrNoFrom & ","
            M_Sql = M_Sql & M_VrNoTo & ","
            M_Sql = M_Sql & M_AmountFrom & ","
            M_Sql = M_Sql & M_AmountTo & ","
            M_Sql = M_Sql & M_TrType & ","
            M_Sql = M_Sql & M_AccCode & ","
            M_Sql = M_Sql & "'" & M_Remarks & "',"
            M_Sql = M_Sql & M_UserID

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub New()
        M_DBConn = New Connection
    End Sub

End Class
