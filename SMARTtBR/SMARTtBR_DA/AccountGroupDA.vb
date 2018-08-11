Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class AccountGroupDA
    Private M_DBConn As Connection
    Private M_GPID As Integer
    Public Function Save_Data(ByVal M_AccountGroup As AccountGroupBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As Integer
        Try
            Dim M_Sql As String

            With M_AccountGroup
                M_Sql = "Exec IUM_AccountGroup_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & M_MenuID & ","
                M_Sql = M_Sql & .GPID & ","
                M_Sql = M_Sql & "'" & .GPName & "',"
                M_Sql = M_Sql & .GPSeqNo & ","
                M_Sql = M_Sql & .GPParentId & ","
                M_Sql = M_Sql & "'" & .ActiveStatus & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterID & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "'"
            End With

            M_GPID = M_DBConn.ExecuteScalar(M_Sql)

            Return M_GPID

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Locate_Data(ByVal M_GPID As Integer) As AccountGroupBO
        Try
            Dim M_Dt As New DataTable
            Dim M_AccountGroup As New AccountGroupBO
            Dim Qry As String
            Qry = "Select * from AccountGroup_P_Tbl where GP_ID = " & M_GPID
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_AccountGroup
                    .GPID = M_Dt.Rows(0).Item("GP_ID")
                    .GPSeqNo = M_Dt.Rows(0).Item("GP_SeqNo")
                    .GPParentId = M_Dt.Rows(0).Item("GP_ParentId")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .GPName = M_Dt.Rows(0).Item("GP_Name")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                End With
            End If
            Return M_AccountGroup
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Check_GroupNameExists(ByVal M_GroupName As String, ByVal M_GPID As Long) As Boolean
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT GP_Name FROM AccountGroup_P_Tbl WHERE GP_Name = '" & M_GroupName & "'" & IIf(M_GPID > 0, " And GP_Code <> " & M_GPID, "")
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

    Public Function Fill_AccountMasterTree(ByVal M_CmpCode As Integer, ByVal M_WithHead As String, ByVal M_Type As String, ByVal M_Sort As String) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT * FROM  dbo.AccountMasterTree_Fn(" & M_CmpCode & ",'" & M_WithHead & "','" & M_Sort & "') Where 1= 1 "
            If M_Type <> "" Then M_Sql = M_Sql & " And ItemType = '" & M_Type & "'"
            If M_Sort = "Name" Then
                M_Sql = M_Sql & " Order By ItemType,Name"
            Else
                M_Sql = M_Sql & " Order By ItemType,ID"
            End If
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
