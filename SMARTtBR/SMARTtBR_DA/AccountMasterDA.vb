Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class AccountMasterDA
    Private M_DBConn As Connection
    Private M_AccCode As Integer
    Public Function Save_Data(ByVal M_AccountMaster As AccountMasterBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As Integer
        Try
            Dim M_Sql As String

            With M_AccountMaster
                M_Sql = "Exec IUM_AccountMaster_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & M_MenuID & ","
                M_Sql = M_Sql & .AccCode & ","
                M_Sql = M_Sql & "'" & .AccName & "',"
                M_Sql = M_Sql & .AccCmpCode & ","
                M_Sql = M_Sql & .AccGPID & ","
                M_Sql = M_Sql & .AccSeqNo & ","
                M_Sql = M_Sql & "'" & .AccBalType & "',"
                M_Sql = M_Sql & "'" & .AccALIE & "',"
                M_Sql = M_Sql & "'" & .AccPosition & "',"
                M_Sql = M_Sql & "'" & .AccStatementtype & "',"
                M_Sql = M_Sql & "'" & .AccBillBreakup & "',"
                M_Sql = M_Sql & "'" & .ActiveStatus & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterID & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "'"
            End With

            M_AccCode = M_DBConn.ExecuteScalar(M_Sql)

            Return M_AccCode

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Locate_Data(ByVal M_CmpCode As String, ByVal M_AccCode As Integer) As AccountMasterBO
        Try
            Dim M_Dt As New DataTable
            Dim M_AccountMaster As New AccountMasterBO
            Dim Qry As String
            Qry = "Select * from AccountMaster_Vw where Acc_CmpCode = " & M_CmpCode & " And Acc_Code = " & M_AccCode
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_AccountMaster
                    .AccCode = M_Dt.Rows(0).Item("Acc_Code")
                    .AccCmpCode = M_Dt.Rows(0).Item("Acc_CmpCode")
                    .AccGPID = M_Dt.Rows(0).Item("Acc_GPID")
                    .GPSeqNo = M_Dt.Rows(0).Item("GP_SeqNo")
                    .AccSeqNo = M_Dt.Rows(0).Item("Acc_SeqNo")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .AccName = M_Dt.Rows(0).Item("Acc_Name")
                    .GPName = M_Dt.Rows(0).Item("GP_Name")
                    .AccPosition = M_Dt.Rows(0).Item("Acc_Position")
                    .AccBalType = M_Dt.Rows(0).Item("Acc_BalType")
                    .AccALIE = M_Dt.Rows(0).Item("Acc_ALIE")
                    .AccStatementtype = M_Dt.Rows(0).Item("Acc_Statementtype")
                    .AccBillBreakup = M_Dt.Rows(0).Item("Acc_BillBreakup")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                End With
            End If
            Return M_AccountMaster
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Check_HeadNameExists(ByVal M_CmpCode As String, ByVal M_AccName As String, ByVal M_AccCode As Long) As Boolean
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT Acc_Name FROM AccountMaster_P_Tbl Where Acc_CmpCode = " & M_CmpCode & " And Acc_Name = '" & M_AccName & "'" & IIf(M_AccCode > 0, " And Acc_Code <>" & M_AccCode, "")
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            If M_DataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Sub New()
        M_DBConn = New Connection
    End Sub

End Class
