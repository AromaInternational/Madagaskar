Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class UserRightsDA
    Private M_DBConn As Connection
    Private M_UMID As Integer
    Public Function Save_Data(ByVal M_UserRights As UserRightsBO, ByVal M_RightsSw As String, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As Integer
        Try
            Dim M_Sql As String

            With M_UserRights
                M_Sql = "Exec IUM_UserRights_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & M_MenuID & ","
                M_Sql = M_Sql & .UserID & ","
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & M_RightsSw & "'"
            End With

            M_UMID = M_DBConn.ExecuteScalar(M_Sql)

            Return M_UMID

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Public Function Locate_Data(ByVal M_UMID As String) As UserRightsBO
        Try
            Dim M_Dt As New DataTable
            Dim M_UserRights As New UserRightsBO
            Dim Qry As String
            Qry = "Select * from UserRights_M_Tbl where UR_UMID = " & M_UMID
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_UserRights
                    .MenuID = M_Dt.Rows(0).Item("UR_MMID")
                    .UserID = M_Dt.Rows(0).Item("UR_UMID")
                    .ViewRight = M_Dt.Rows(0).Item("UR_View")
                    .AddRight = M_Dt.Rows(0).Item("UR_Add")
                    .EditRight = M_Dt.Rows(0).Item("UR_Edit")
                    .DeleteRight = M_Dt.Rows(0).Item("UR_Delete")
                    .PrintRight = M_Dt.Rows(0).Item("UR_Print")
                    .AuthnRight = M_Dt.Rows(0).Item("UR_Authn")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                End With
            End If
            Return M_UserRights
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_UserRightGrid(ByVal UserID As Integer, ByVal UserType As Integer, ByVal MakerID As Integer) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "Select M.MM_ID,MM_MainID,MM_SubID,MM_SubChildID,MM_Caption,ISNULL(U.UR_View,'N') As UR_View,"
            M_Sql = M_Sql & " ISNULL(U.UR_Add,'N') As UR_Add,ISNULL(U.UR_Edit,'N') As UR_Edit,"
            M_Sql = M_Sql & " ISNULL(U.UR_Delete,'N') As UR_Delete,ISNULL(U.UR_Print,'N') As UR_Print,"
            M_Sql = M_Sql & " ISNULL(U.UR_Authn,'N') As UR_Authn,Isnull(U.UR_UMID,0) As User_ID,"
            M_Sql = M_Sql & " Case When (SELECT COUNT(MM_ID) FROM MenuMaster_P_Tbl S WHERE S.MM_SubID = M.MM_SubID AND S.MM_MainID = M.MM_MainID AND M.MM_SubChildID =0 )>1 Then 'Y' Else 'N' End As HasChild "
            M_Sql = M_Sql & " From MenuMaster_P_Tbl M"
            M_Sql = M_Sql & " Left Outer Join UserRights_M_Tbl U On U.UR_MMID=M.MM_ID And U.UR_UMID = " & UserID & " Where MM_Active='Y' "
            If UserType > 0 Then M_Sql = M_Sql & " And Exists(Select 1 FROM UserRights_M_Tbl MR WHERE MR.UR_MMID=M.MM_ID AND MR.UR_View ='Y' And MR.UR_UMID =" & MakerID & ")"
            M_Sql = M_Sql & " Order By MM_MainID,MM_SubID,MM_SubChildID"

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
