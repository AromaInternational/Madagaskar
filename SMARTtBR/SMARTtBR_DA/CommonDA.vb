Imports SMARTtBR_DAL
Imports SMARTtBR_CO
Imports SMARTtBR_BO
Public Class CommonDA
    Private M_DBConn As Connection

    Public Function Fill_UserRightDetails(ByVal M_UserID As Integer) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "SELECT UM_ID, UM_Name, MM_ID, MM_MainID, MM_SubID, MM_SubChildID,HasChild, MM_Name,MM_ShortKey, MM_Caption, MM_FormName, MM_AllowMultipleInstance, "
            M_Sql = M_Sql & "MM_Active,MM_ShowInMenu, UR_View, UR_Add, UR_Edit, UR_Delete, UR_Print, UR_Authn FROM UserRightDetails_Vw WHERE 1 = 1 "
            If M_UserID > 1 Then M_Sql = M_Sql & "AND UM_ID = " & M_UserID

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function Fill_CompanyProfile() As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT Cmp_Code,Cmp_Name, Cmp_Address, Cmp_FaxNo, Cmp_Email, Cmp_Website FROM CompanyProfile_P_Tbl "
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_Company(ByVal bDefault As Boolean, ByVal sDefaultTyp As String) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = ""
            If bDefault Then
                If sDefaultTyp = "A" Then
                    M_Sql = M_Sql & "SELECT '<<==ALL==>>' Cmp_Name,0 Cmp_Code UNION ALL "
                ElseIf sDefaultTyp = "S" Then
                    M_Sql = M_Sql & "SELECT '<<==SELECT==>>' Cmp_Name,0 Cmp_Code UNION ALL "
                End If
            End If

            M_Sql = M_Sql & "SELECT Cmp_Name,Cmp_Code FROM CompanyProfile_P_Tbl Where Cmp_Code >0 "
            M_Sql = M_Sql & "Order by Cmp_Name"

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_User(ByVal M_UserType As Integer, ByVal Active_Only As String, ByVal bDefault As Boolean, ByVal sDefaultTyp As String) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = ""
            If bDefault Then
                If sDefaultTyp = "A" Then
                    M_Sql = M_Sql & "SELECT '<<==ALL==>>' UM_Name,0 UM_ID UNION ALL "
                ElseIf sDefaultTyp = "S" Then
                    M_Sql = M_Sql & "SELECT '<<==SELECT==>>' UM_Name,0 UM_ID UNION ALL "
                End If
            End If
            M_Sql = M_Sql & "SELECT UM_Name,UM_ID FROM UserMaster_Vw Where UM_ID>0 "
            If Active_Only = "Y" Then M_Sql = M_Sql & "AND Active_Status = 'Y' "
            If M_UserType > 0 Then M_Sql = M_Sql & "AND UM_TypeID = " & M_UserType & " "
            M_Sql = M_Sql & "Order by UM_Name"

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_Department(ByVal Active_Only As String, ByVal bDefault As Boolean, ByVal sDefaultTyp As String) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = ""
            If bDefault Then
                If sDefaultTyp = "A" Then
                    M_Sql = M_Sql & "SELECT '<<==ALL==>>' Dep_Name,0 Dep_ID UNION ALL "
                ElseIf sDefaultTyp = "S" Then
                    M_Sql = M_Sql & "SELECT '<<==SELECT==>>' Dep_Name,0 Dep_ID UNION ALL "
                End If
            End If

            M_Sql = M_Sql & "SELECT Dep_Name,Dep_ID FROM Department_P_Tbl Where Dep_ID >0 "
            If Active_Only = "Y" Then M_Sql = M_Sql & "AND Active_Status = 'Y' "
            M_Sql = M_Sql & "Order by Dep_Name"

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_Designation(ByVal Active_Only As String, ByVal bDefault As Boolean, ByVal sDefaultTyp As String) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = ""
            If bDefault Then
                If sDefaultTyp = "A" Then
                    M_Sql = M_Sql & "SELECT '<<==ALL==>>' Des_Name,0 Des_ID UNION ALL "
                ElseIf sDefaultTyp = "S" Then
                    M_Sql = M_Sql & "SELECT '<<==SELECT==>>' Des_Name,0 Des_ID UNION ALL "
                End If
            End If

            M_Sql = M_Sql & "SELECT Des_Name,Des_ID FROM Designation_P_Tbl Where Des_ID >0 "
            If Active_Only = "Y" Then M_Sql = M_Sql & "AND Active_Status = 'Y' "
            M_Sql = M_Sql & "Order by Des_Name"

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetUserMaster(ByVal M_UserID As Integer) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT * FROM UserMaster_Vw Where UM_ID =" & M_UserID
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_Server_DateTime() As String
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "Select GETDATE() AS ServerDateTime"
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            If M_DataTable.Rows.Count > 0 Then
                Return Format(M_DataTable.Rows(0).Item("ServerDateTime"), "MM/dd/yyyy HH:mm:ss")
            Else
                Return Format(Now, "MM/dd/yyyy HH:mm:ss")
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Get_TerminalName() As String
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "Select HOST_ID() AS HOSTID"
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            If M_DataTable.Rows.Count > 0 Then
                Return M_DataTable.Rows(0).Item("HOSTID").ToString.Trim()
            Else
                Return ""
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_ServerName() As String
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "Select UPPER(@@SERVERNAME) AS SERVERNAME"
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            If M_DataTable.Rows.Count > 0 Then
                Return M_DataTable.Rows(0).Item("SERVERNAME").ToString.Trim()
            Else
                Return ""
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub InsertUpdate_LogDetails(ByRef M_LogId As Long, ByVal M_EntryMode As String, ByVal M_UserId As Integer, ByVal SystemName As String)
        Try
            Dim M_Sql As String
            M_Sql = "Exec IUM_UserLoginDetails_Sp "
            M_Sql = M_Sql & "'" & M_EntryMode & "',"
            M_Sql = M_Sql & M_LogId & ","
            M_Sql = M_Sql & M_UserId & ","
            M_Sql = M_Sql & "'" & SystemName & "',"
            M_Sql = M_Sql & "'" & Get_Server_DateTime() & "',"
            M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", Get_Server_DateTime()) & "'"
            M_LogId = M_DBConn.ExecuteScalar(M_Sql)

        Catch ex As Exception
            MsgBox(ex.Message)
            M_LogId = 0
        End Try
    End Sub

    Public Function Fill_AccountGroup(Optional ByVal ActiveStatus As String = "", Optional ByVal IsAll As Boolean = False) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = ""
            If IsAll Then
                M_Sql = M_Sql & "SELECT '<<==ALL=>>' GP_Name,0 GP_ID UNION ALL "
            End If
            M_Sql = M_Sql & "select  GP_Name,GP_ID  from  AccountGroup_P_Tbl  Where 1=1 "
            If ActiveStatus <> "" Then M_Sql = M_Sql & " AND Active_Status ='" & ActiveStatus & "' "
            M_Sql = M_Sql & " order by GP_Name "
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ParamType(ByVal ActiveStatus As String, ByVal bDefault As Boolean, ByVal sDefaultTyp As String) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = ""
            If bDefault Then
                If sDefaultTyp = "A" Then
                    M_Sql = M_Sql & "SELECT '<<==ALL==>>' PT_Description,0 PT_ID UNION ALL "
                ElseIf sDefaultTyp = "S" Then
                    M_Sql = M_Sql & "SELECT '--' PC_Description,0 PT_ID UNION ALL "
                End If
            End If
            M_Sql = M_Sql & "Select  PT_Description,PT_ID from  ParaType_P_Tbl Where 1=1 "
            If ActiveStatus <> "" Then M_Sql = M_Sql & " AND Active_Status ='" & ActiveStatus & "' "
            M_Sql = M_Sql & " order by PT_Description "
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ReportType(Optional ByVal ActiveStatus As String = "Y") As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT  RT_Description,RT_Code from  ReportType_P_Tbl Where 1=1 "
            If ActiveStatus <> "" Then M_Sql = M_Sql & " AND Active_Status ='" & ActiveStatus & "' "
            M_Sql = M_Sql & " order by RT_Description "
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_TransDate(ByVal M_TranDate As Date) As Date
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "Exec Get_TransDate_Sp '" & Format(M_TranDate, "MM/dd/yyyy") & "'"
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            If M_DataTable.Rows.Count > 0 Then
                Return CDate(M_DataTable.Rows(0).Item("TransDate").ToString)
            Else
                Return "01/01/2000"
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Fill_SubDetails(ByVal M_SubType As Integer, ByVal M_ParrentType As Integer, ByVal M_ParrentID As Long, ByVal M_UserID As Integer) As DataTable

        Try
            Dim M_Sql As String
            Dim M_DataTable As New DataTable
            M_Sql = "Exec dbo.Proc_FillSubDetails_Sp "
            M_Sql = M_Sql & M_SubType & ","
            M_Sql = M_Sql & M_ParrentType & ","
            M_Sql = M_Sql & M_ParrentID & ","
            M_Sql = M_Sql & M_UserID

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Fill_ParamCodeList() As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "SELECT PC_ID, PC_Description, PC_Type, PT_Description, PC_Order, PC_Locked, Active_Status FROM ParaCode_Vw WHERE 1 = 1 "

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_UserUnitsList(ByVal M_CmpCode As Integer, ByVal M_UserID As Integer) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "SELECT UN_ID, UN_Name, Active_Status FROM UserUnitsDetails_Vw WHERE UM_ID = " & M_UserID & " AND Cmp_Code = " & M_CmpCode

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ReportTypeList() As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String

            M_Sql = "SELECT RN_Id, RN_Description, RN_Name, RN_Type, RT_Description, RN_Order, Active_Status FROM ReportNames_Vw WHERE 1 = 1 "

            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_UnitMasterTree(ByVal M_CmpCode As Integer, ByVal M_UserID As Integer, ByVal M_Sort As String) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT * FROM  dbo.UnitMasterTree_Fn(" & M_CmpCode & "," & M_UserID & ",'" & M_Sort & "') Where 1= 1 "
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
    Public Function Fill_UserUnitTreeCodeRight(ByVal M_UserID As Integer) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT TreeCode ID FROM  dbo.UserUnitTreeCodeRight_Fn(" & M_UserID & ")"
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
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

    Public Function Fill_AccVrType(ByVal CmpCode As Integer, ByVal bDefault As Boolean, ByVal sDefaultTyp As String) As DataTable

        Try
            Dim M_Sql As String
            Dim M_DataTable As New DataTable
            M_Sql = "SELECT VR_ID,VR_Type,VR_DEFAULT FROM  dbo.Fill_AccVrType_Fn(" & CmpCode & ",'" & IIf(bDefault, "Y", "N") & "','" & sDefaultTyp & "')"
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)

            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Fill_FinYear(ByVal CmpCode As Integer, ByVal TrDate As Date) As DataTable
        Try
            Dim M_DataTable As New DataTable
            Dim M_Sql As String
            M_Sql = "SELECT Fin_ID,Fin_Period,Fin_OBDate,Fin_StartDate,Fin_EndDate,Current_Fin FROM  dbo.FinYear_Details_Fn("
            M_Sql = M_Sql & CmpCode & ","
            M_Sql = M_Sql & "'" & Format(TrDate, "MM/dd/yyyy") & "')"
            M_DBConn.ExecuteDataTable(M_DataTable, M_Sql)
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Delete_AccountGroup(ByVal M_CmpCode As Integer, ByVal Type As String, ByVal M_ID As Integer, ByVal MakerID As Integer, ByVal UserTime As String) As DataSet
        Try
            Dim M_DataSet As New DataSet
            Dim M_Sql As String

            M_Sql = "Exec DEL_AccountGroup_Sp "
            M_Sql = M_Sql & M_CmpCode & ","
            M_Sql = M_Sql & "'" & Type & "',"
            M_Sql = M_Sql & M_ID & ","
            M_Sql = M_Sql & MakerID & ","
            M_Sql = M_Sql & "'" & UserTime & "'"

            M_DBConn.ExecuteDataSet(M_DataSet, M_Sql)
            Return M_DataSet

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

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

