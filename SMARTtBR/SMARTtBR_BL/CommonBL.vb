Imports SMARTtBR_CO
Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports System.Windows.Forms
Imports SMARTtBR_CO.CommonClass
Public Class CommonBL
    Public Shared Function Get_UserRight(ByVal M_TypeID As Integer, ByVal M_UserID As Integer, ByVal M_MenuID As Integer) As UserRightsBO
        Dim M_RightsBO As New UserRightsBO
        Try
            With M_RightsBO
                If M_TypeID = 0 Then
                    .ViewRight = True
                    .AddRight = True
                    .EditRight = True
                    .DeleteRight = True
                    .PrintRight = True
                    .AuthnRight = True
                Else
                    .ViewRight = False
                    .AddRight = False
                    .EditRight = False
                    .DeleteRight = False
                    .PrintRight = False
                    .AuthnRight = False

                    Dim dRow As DataRow
                    Dim M_Filter As String = "MM_ID = " & M_MenuID & " And UM_ID = " & M_UserID
                    For Each dRow In M_UserRightList.Select(M_Filter)
                        If UCase(dRow("UR_View").ToString) = "Y" Then .ViewRight = True
                        If UCase(dRow("UR_Add").ToString) = "Y" Then .AddRight = True
                        If UCase(dRow("UR_Edit").ToString) = "Y" Then .EditRight = True
                        If UCase(dRow("UR_Delete").ToString) = "Y" Then .DeleteRight = True
                        If UCase(dRow("UR_Print").ToString) = "Y" Then .PrintRight = True
                        If UCase(dRow("UR_Authn").ToString) = "Y" Then .AuthnRight = True
                    Next dRow
                End If
            End With

            Return M_RightsBO
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function CheckUserRight(ByVal M_EntryMode As String, ByVal M_UserID As Integer, ByVal M_MenuID As Integer) As Boolean
        Dim M_UserRightsBO As New UserRightsBO
        Dim M_UserRightsBL As New UserRightsBL
        Dim M_Permission As Boolean

        Try

            M_UserRightsBO = Get_UserRight(User_TypeID, M_UserID, M_MenuID)
            With M_UserRightsBO
                If M_EntryMode = "NEW" Then
                    M_Permission = .AddRight
                ElseIf M_EntryMode = "VIEW" Then
                    M_Permission = .EditRight
                ElseIf M_EntryMode = "DELETE" Then
                    M_Permission = .DeleteRight
                ElseIf M_EntryMode = "AUTHORIZE" Then
                    M_Permission = .AuthnRight
                ElseIf M_EntryMode = "PRINT" Then
                    M_Permission = .PrintRight
                End If
            End With

            M_UserRightsBO = Nothing
            If M_Permission = False Then
                MsgBox("Permission Denied....!!!" & vbNewLine & " You don't have Right...", MsgBoxStyle.Critical, "Could not Save")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Fill_UserRightDetails(ByVal M_UserID As Integer) As DataTable
        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.Fill_UserRightDetails(M_UserID)
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function Get_UserTime() As String
        Dim M_Date As String = "01/01/1900"
        Try
            Dim M_CommonDA As New CommonDA
            M_Date = M_CommonDA.Get_Server_DateTime()
            M_CommonDA = Nothing
            Return M_Date
        Catch ex As Exception
            Return M_Date
        End Try
    End Function

    Public Shared Function Get_TransDate(ByVal M_TranDate As Date) As Date
        Dim M_Date As String = "01/01/1900"
        Try
            Dim M_CommonDA As New CommonDA
            M_Date = M_CommonDA.Get_TransDate(M_TranDate)
            M_CommonDA = Nothing
            Return M_Date
        Catch ex As Exception
            Return M_Date
        End Try
    End Function

    Public Shared Function Set_ProjectVariables(ByVal M_TranDate As Date) As Boolean
        Dim M_CommonBL As New CommonBL
        Try
            If Not Set_CompanyProfile() Then Return False

            Tran_Date = Get_TransDate(M_TranDate)

            Call Get_SystemInfo()

            Report_Path = Get_AppSettings("REPORT_FOLDER") & "\SMARTtBRREPORTS\"
            Terminal_Name = Get_TerminalName()
            Return True
        Catch ex As Exception
            Call MessageBox.Show(ex.Message, "SMART CrM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Return False
        End Try

    End Function

    Public Function Fill_CompanyProfile() As DataTable
        Try

            Dim M_CommonDA As New CommonDA
            Dim M_Dt As DataTable
            M_Dt = M_CommonDA.Fill_CompanyProfile()
            M_CommonDA = Nothing
            Return M_Dt
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Fill_Company(ByRef Cmbbx As Object, Optional ByVal bDefault As Boolean = False, Optional ByVal sDefaultTyp As String = "S") As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "Cmp_Name"
            Dim M_ValueMem As String = "Cmp_Code"
            M_DataTable = M_CommonDA.Fill_Company(bDefault, sDefaultTyp)
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            M_CommonDA = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function

    Private Shared Function Set_CompanyProfile() As Boolean

        Try
            Dim M_Dt As DataTable
            Dim M_CommonDA As New CommonDA
            M_Dt = M_CommonDA.Fill_CompanyProfile()

            If M_Dt.Rows.Count > 0 Then
                Company_Code = M_Dt.Rows(0).Item("Cmp_Code")
                Company_Name = M_Dt.Rows(0).Item("Cmp_Name")
                Company_Addr = M_Dt.Rows(0).Item("Cmp_Address")
                Company_Fax = M_Dt.Rows(0).Item("Cmp_FaxNo")
                Company_Email = M_Dt.Rows(0).Item("Cmp_Email")
                Company_Website = M_Dt.Rows(0).Item("Cmp_Website")
            End If
            M_CommonDA = Nothing
            Return True
        Catch ex As Exception
            Return False
            Call MessageBox.Show(ex.Message, "SMART CrM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Function

    Public Function Fill_User(ByRef Cmbbx As Object, Optional ByVal M_UserType As Integer = 3, Optional ByVal Active_Only As String = "Y", Optional ByVal bDefault As Boolean = False, Optional ByVal sDefaultTyp As String = "S") As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "UM_Name"
            Dim M_ValueMem As String = "UM_ID"
            M_DataTable = M_CommonDA.Fill_User(M_UserType, Active_Only, bDefault, sDefaultTyp)
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            M_CommonDA = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function Fill_Department(ByRef Cmbbx As Object, Optional ByVal Active_Only As String = "Y", Optional ByVal bDefault As Boolean = False, Optional ByVal sDefaultTyp As String = "S") As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "Dep_Name"
            Dim M_ValueMem As String = "Dep_ID"
            M_DataTable = M_CommonDA.Fill_Department(Active_Only, bDefault, sDefaultTyp)
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            M_CommonDA = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function Fill_Designation(ByRef Cmbbx As Object, Optional ByVal Active_Only As String = "Y", Optional ByVal bDefault As Boolean = False, Optional ByVal sDefaultTyp As String = "S") As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "Des_Name"
            Dim M_ValueMem As String = "Des_ID"
            M_DataTable = M_CommonDA.Fill_Designation(Active_Only, bDefault, sDefaultTyp)
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            M_CommonDA = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function GetUserMaster(ByVal M_UserID As String) As DataTable

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.GetUserMaster(M_UserID)
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_UserWiseMenu(ByVal M_UserID As Integer, Optional ByVal MenuType As String = "", Optional ByVal MainID As Integer = 0, Optional ByVal MainSubID As Integer = 0) As DataTable

        Try
            Dim M_DataTable As DataTable

            Dim M_Filter As String = "MM_Active = 'Y' And MM_ShowInMenu ='Y' And UM_ID = " & M_UserID
            Dim M_Sort As String = "MM_MainID, MM_SubID,MM_SubChildID,MM_ID"

            If MenuType = "M" Then
                M_Filter = M_Filter & " AND MM_SubID = 0 "
            ElseIf MenuType = "S" Then
                M_Filter = M_Filter & " AND MM_SubID > 0 AND MM_SubChildID = 0 "
            ElseIf MenuType = "C" Then
                M_Filter = M_Filter & " AND MM_SubChildID > 0 "
            End If

            If MainID > 0 Then M_Filter = M_Filter & " AND MM_MainID =  " & MainID
            If MainSubID > 0 Then M_Filter = M_Filter & " AND MM_SubID =  " & MainSubID
            If M_UserID > 1 Then M_Filter = M_Filter & " AND UR_View ='Y' "

            M_DataTable = M_UserRightList.Clone

            For Each MydataRow In M_UserRightList.Select(M_Filter, M_Sort)
                M_DataTable.ImportRow(MydataRow)
            Next MydataRow

            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Get_FormName(ByVal M_UserID As Integer, ByVal M_MenuID As Integer, ByRef M_MenuName As String, ByRef M_MultipleInstance As Boolean) As String

        Try
            Dim dRow As DataRow
            Dim M_FormName As String = ""
            Dim M_Filter As String = "MM_ID = " & M_MenuID & " And UM_ID = " & M_UserID

            For Each dRow In M_UserRightList.Select(M_Filter)
                M_FormName = dRow("MM_FormName").ToString()
                M_MenuName = dRow("MM_Name").ToString()
                M_MultipleInstance = (dRow("MM_AllowMultipleInstance").ToString() = "Y")
                M_FormName = IIf(dRow("HasChild").ToString() = "Y", "HC", M_FormName)
            Next dRow

            Return M_FormName
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_FormID(ByVal M_UserID As Integer, ByVal M_FormName As String) As Integer

        Try
            Dim M_ID As Integer = 0
            Dim dRow As DataRow
            Dim M_Filter As String = "MM_FormName = '" & M_FormName & "' And UM_ID = " & M_UserID

            For Each dRow In M_UserRightList.Select(M_Filter)
                M_ID = dRow("MM_ID").ToString()
            Next dRow

            Return M_ID
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_MenueViewRight(ByVal M_UserID As Integer, ByVal M_FormName As String) As Boolean

        Try
            Dim M_Result As Boolean = False
            Dim dRow As DataRow
            Dim M_Filter As String = "MM_FormName = '" & M_FormName & "' And UM_ID = " & M_UserID

            For Each dRow In M_UserRightList.Select(M_Filter)
                M_Result = (dRow("UR_View").ToString() = "Y")
            Next dRow

            Return M_Result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_Server_DateTime() As String
        Try
            Dim M_Date As String
            Dim M_CommonDA As New CommonDA
            M_Date = M_CommonDA.Get_Server_DateTime()
            M_CommonDA = Nothing
            Return M_Date
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function Get_TerminalName() As String
        Try
            Dim HostID As String
            Dim M_CommonDA As New CommonDA
            HostID = M_CommonDA.Get_TerminalName()
            M_CommonDA = Nothing
            Return HostID
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function Get_ServerName() As String
        Try
            Dim HostName As String
            Dim M_CommonDA As New CommonDA
            HostName = M_CommonDA.Get_ServerName()
            M_CommonDA = Nothing
            Return HostName
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub InsertUpdate_LogDetails(ByRef M_LogId As Long, ByVal M_EntryMode As String, ByVal M_UserId As Integer, ByVal SystemName As String)
        If User_TypeID = 0 Then Exit Sub
        Try
            Dim M_CommonDA As New CommonDA
            Call M_CommonDA.InsertUpdate_LogDetails(M_LogId, M_EntryMode, M_UserId, SystemName)
            M_CommonDA = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Public Function Fill_AccountGroup(ByRef Cmbbx As Object, Optional ByVal ActiveStatus As String = "", Optional ByVal IsAll As Boolean = False) As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "GP_Name"
            Dim M_ValueMem As String = "GP_ID"
            M_DataTable = M_CommonDA.Fill_AccountGroup(ActiveStatus, IsAll)
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            If Cmbbx.Items.Count > 0 Then Cmbbx.SelectedIndex = 0
            M_CommonDA = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ParamType(ByRef Cmbbx As Object, Optional ByVal ActiveStatus As String = "", Optional ByVal bDefault As Boolean = False, Optional ByVal sDefaultTyp As String = "S") As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "PT_Description"
            Dim M_ValueMem As String = "PT_ID"
            M_DataTable = M_CommonDA.Fill_ParamType(ActiveStatus, bDefault, sDefaultTyp)
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            If Cmbbx.Items.Count > 0 Then Cmbbx.SelectedIndex = 0
            M_CommonDA = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ReportType(ByRef Cmbbx As Object, Optional ByVal ActiveStatus As String = "Y") As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "RT_Description"
            Dim M_ValueMem As String = "RT_Code"
            M_DataTable = M_CommonDA.Fill_ReportType(ActiveStatus)
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            If Cmbbx.Items.Count > 0 Then Cmbbx.SelectedIndex = 0
            M_CommonDA = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_SubDetails(ByVal M_SubType As Integer, ByVal M_ParrentType As Integer, ByVal M_ParrentID As Long, ByVal M_UserID As Integer) As DataTable
        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.Fill_SubDetails(M_SubType, M_ParrentType, M_ParrentID, M_UserID)
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ParamCodeList() As DataTable
        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.Fill_ParamCodeList()
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_UserUnitsList(ByVal M_CmpCode As Integer, ByVal M_UserID As Integer) As DataTable
        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.Fill_UserUnitsList(M_CmpCode, M_UserID)
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ReportTypeList() As DataTable
        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.Fill_ReportTypeList()
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_UnitMasterTree(ByVal M_CmpCode As Integer, ByVal M_UserID As Integer, Optional ByVal M_Sort As String = "Name") As DataTable

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.Fill_UnitMasterTree(M_CmpCode, M_UserID, M_Sort)
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function Fill_UserUnitTreeCodeRight(ByVal M_UserID As Integer) As DataTable

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.Fill_UserUnitTreeCodeRight(M_UserID)
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_AccountMasterTree(ByVal M_CmpCode As Integer, Optional ByVal M_WithHead As String = "N", Optional ByVal M_Type As String = "", Optional ByVal M_Sort As String = "Name") As DataTable

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            M_DataTable = M_CommonDA.Fill_AccountMasterTree(M_CmpCode, M_WithHead, M_Type, M_Sort)
            M_CommonDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_AccVrType(ByRef Cmbbx As Object, ByVal CmpCode As Integer, ByRef M_DefaultVrType As String, Optional ByVal bDefault As Boolean = False, Optional ByVal sDefaultTyp As String = "S") As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "VR_TYPE"
            Dim M_ValueMem As String = "VR_ID"
            M_DefaultVrType = ""
            M_DataTable = M_CommonDA.Fill_AccVrType(CmpCode, bDefault, sDefaultTyp)
            Dim sBRows() As DataRow = M_DataTable.Select("VR_DEFAULT = 'Y'")
            For J = 0 To sBRows.Count - 1
                M_DefaultVrType = sBRows(J).Item("VR_ID").ToString
            Next
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            If Cmbbx.Items.Count > 0 Then
                If M_DefaultVrType <> "" Then
                    Cmbbx.SelectedValue = M_DefaultVrType
                    If Cmbbx.SelectedIndex < 0 Then Cmbbx.SelectedIndex = 0
                Else
                    Cmbbx.SelectedIndex = 0
                End If
            End If
            M_CommonDA = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_FinYear(ByRef Cmbbx As Object, ByVal CmpCode As Integer, ByVal TrDate As Date, ByRef M_DefaultFinYear As String, ByRef M_FinOBDate As Date, ByRef M_FinStartDate As Date) As Boolean

        Try
            Dim M_DataTable As DataTable
            Dim M_CommonDA As New CommonDA
            Dim M_DisplayMem As String = "Fin_Period"
            Dim M_ValueMem As String = "Fin_Period"
            M_DataTable = M_CommonDA.Fill_FinYear(CmpCode, TrDate)

            Dim sBRows() As DataRow = M_DataTable.Select("Current_Fin = 'Y'")
            For J = 0 To sBRows.Count - 1
                M_DefaultFinYear = sBRows(J).Item("Fin_Period").ToString
                M_FinStartDate = sBRows(J).Item("Fin_StartDate").ToString
                M_FinOBDate = sBRows(J).Item("Fin_OBDate").ToString
            Next
            Fill_Combo(Cmbbx, M_DataTable, M_DisplayMem, M_ValueMem)
            If Cmbbx.Items.Count > 0 Then
                If M_DefaultFinYear <> "" Then
                    Cmbbx.SelectedValue = M_DefaultFinYear
                Else
                    Cmbbx.SelectedIndex = 0
                End If
            End If
            M_CommonDA = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Delete_AccountGroup(ByVal M_EntryMode As String, ByVal M_CmpCode As Integer, ByVal Type As String, ByVal M_ID As Integer, ByVal MakerID As Integer, ByVal Menu_ID As Integer) As DataSet
        Try

            Dim M_CommonDA As New CommonDA
            Dim M_Dt As DataSet
            Dim UserTime As String
            If CheckUserRight(M_EntryMode, MakerID, Menu_ID) = True Then
                UserTime = Get_UserTime()
                M_Dt = M_CommonDA.Delete_AccountGroup(M_CmpCode, Type, M_ID, MakerID, UserTime)
                M_CommonDA = Nothing
                Return M_Dt
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class



