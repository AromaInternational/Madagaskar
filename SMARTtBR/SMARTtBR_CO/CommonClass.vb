Imports System.Configuration
Imports System.Configuration.ConfigurationManager
Imports System.Management
Imports System.Windows
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Globalization
Imports System.Net.Mail

Public Class CommonClass

    Public Const LOCALE_SSHORTDATE As Long = &H1F   'short date format string
    Public Declare Function GetSystemDefaultLCID Lib "kernel32" () As Long
    Public Declare Function SetLocaleInfo Lib "kernel32" Alias "SetLocaleInfoA" (ByVal Locale As Long, ByVal LCType As Long, ByVal lpLCData As String) As Boolean
    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Public Declare Function GetTickCount Lib "kernel32" () As Long
    Public Declare Function GetLastInputInfo Lib "User32.dll" (ByRef lii As LASTINPUTINFO) As Boolean

    Public Const BasicMeasureUnitShort As String = "cm"
    Public Const BasicMeasureUnitLong As String = "Centementer"

    Public Structure LASTINPUTINFO
        Public cbSize As Integer
        Public dwTime As Integer
    End Structure

    Public Enum ClientType
        Supplier = 1
        Customer = 2
    End Enum

    Dim mOnesArray(8) As String
    Dim mOneTensArray(9) As String
    Dim mTensArray(7) As String
    Dim mPlaceValues(4) As String

    Public Shared User_Password As String = ""
    Public Shared User_Name As String = ""
    Public Shared User_ID As Integer = 1
    Public Shared User_Designation As String = "ADMIN"
    Public Shared User_LoginID As Long = 0
    Public Shared User_TypeID As Integer = 0
    Public Shared User_UnitID As Integer = 0
    Public Shared Tran_Date As Date

    Public Shared System_Name As String = ""
    Public Shared Terminal_Name As String = ""

    Public Shared Server_Name As String = ""
    Public Shared Data_Base As String = ""
    Public Shared ServerType As String = "L"

    Public Shared Branch_Name As String = ""
    Public Shared Branch_Code As Integer = 0
    Public Shared Branch_Phone As String = ""
    Public Shared Branch_Server As String = ""
    Public Shared Region_Code As Integer = 0

    Public Shared Company_Code As String = ""
    Public Shared Company_Name As String = ""
    Public Shared Company_Addr As String = ""
    Public Shared Company_Fax As String = ""
    Public Shared Company_Email As String = ""
    Public Shared Company_Website As String = ""
    Public Shared Report_Path As String = ""
   
    Public Shared FormOpen_ID As Integer = 1
    Public Shared AutoLogOut_Period As Integer = 5


    Public Shared LastModified_Lead As Integer = 0
    Public Shared LastModified_Account As Integer = 0
    Public Shared LastModified_Contact As Integer = 0
    Public Shared LastModified_Activity As Integer = 0
    Public Shared LastModified_Task As Integer = 0
    Public Shared LastModified_Opportunities As Integer = 0
    Public Shared ApplicationLock_Status As Boolean = False

    Public Shared SysShortDate As String = "dd-MM-yyyy"
    Public Shared SMShortDate As String = "dd/MM/yyyy"

    Public Shared M_OpenMenuList As DataTable
    Public Shared M_UserRightList As DataTable
    Public Shared M_ParamCodeList As DataTable
    Public Shared M_UserUnitsList As DataTable
    Public Shared M_ReportNameList As DataTable
    Public Shared M_UnitMasterTreeList As DataTable
    Public Shared M_AccountMasterTreeList As DataTable

    Public Shared ApplicationPath As String = "D:\AROMA\SMARTtBR"

    Const GoodChar As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ "
    Const GoodNum As String = "1234567890"

    Public Shared Function Get_AppSettings(ByVal Param_Type As String) As String

        Dim result As String

        result = AppSettings(Param_Type)

        Return result

    End Function

    Public Shared Function Get_SystemInfo() As Boolean


        Dim objMgmt As ManagementObject
        Dim objos As ManagementObjectSearcher

        Try


            objos = New ManagementObjectSearcher("Select * from win32_OperatingSystem")
            For Each objMgmt In objos.Get
                System_Name = objMgmt("csname").ToString()
            Next
        Catch ex As Exception

            MsgBox(ex.Message)

        Finally

            objos = Nothing
            objMgmt = Nothing

        End Try

    End Function

    Public Shared Sub Set_SystemDateFormat(ByVal M_Set As Boolean)
        Try
            If M_Set Then
                SysShortDate = Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", SysShortDate)
                If SysShortDate <> SMShortDate Then
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", SMShortDate)
                End If
            Else
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", SysShortDate)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function IsDouble(ByVal sText As String) As Boolean
        Dim newInteger As Double
        If sText.Trim <> "" Then
            If Not Double.TryParse(sText.ToString(), newInteger) Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Shared Function Set_ComboxDefaultValue(ByRef Cmbbx As Object, Optional ByVal sValue As String = "") As Boolean
        Try
            If Not Cmbbx Is Nothing Then
                If Cmbbx.Items.Count > 0 Then
                    If sValue <> "" Then
                        Cmbbx.SelectedValue = sValue
                        If Cmbbx.SelectedIndex < 0 Then Cmbbx.SelectedIndex = 0
                    Else
                        Cmbbx.SelectedIndex = 0
                    End If
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_Combo(ByRef Cmbbx As Object, ByVal M_Datatbl As DataTable, ByVal DisplayMem As String, ByVal ValueMem As String) As Boolean
        Try
            If Not Cmbbx Is Nothing Then
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = DisplayMem
                    .ValueMember = ValueMem
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_ParamCode(ByRef Cmbbx As Object, Optional ByVal M_PCType As Integer = 0, Optional ByVal ActiveStatus As String = "", Optional ByVal DescriptionSort As Boolean = False, Optional ByVal bDefault As Boolean = False, Optional ByVal sDefaultTyp As String = "S") As Boolean
        Dim M_DataTable As New DataTable("ParamCode_Tbl")
        Try
            Dim M_Filter As String = "PC_Type = " & M_PCType & IIf(ActiveStatus <> "", " AND Active_Status ='" & ActiveStatus & "'", "")
            Dim M_Sort As String = IIf(DescriptionSort = True, "PC_Description ASC", "PC_Order ASC")
            Dim iCount As Integer = 1
            If Not Cmbbx Is Nothing Then
                M_DataTable.Columns.Add("ID", GetType(String))
                M_DataTable.Columns.Add("Name", GetType(String))
                M_DataTable.Columns.Add("Sort", GetType(String))
                If bDefault Then
                    If sDefaultTyp = "A" Then
                        M_DataTable.Rows.Add("0", "<-ALL->", "0")
                    ElseIf sDefaultTyp = "S" Then
                        M_DataTable.Rows.Add("0", "--", "0")
                    End If
                End If

                Dim dRow As DataRow
                For Each dRow In M_ParamCodeList.Select(M_Filter, M_Sort)
                    M_DataTable.Rows.Add(dRow("PC_ID").ToString, dRow("PC_Description").ToString, iCount.ToString)
                    iCount = iCount + 1
                Next dRow

                Call Fill_Combo(Cmbbx, M_DataTable, "Name", "ID")
                If Cmbbx.Items.Count > 0 Then Cmbbx.SelectedIndex = 0
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_Unit(ByRef Cmbbx As Object, Optional ByVal ActiveStatus As String = "", Optional ByVal bDefault As Boolean = False, Optional ByVal sDefaultTyp As String = "S") As Boolean
        Dim M_DataTable As New DataTable("Unit_Tbl")
        Try
            Dim M_Filter As String = "1 = 1" & IIf(ActiveStatus <> "", " AND Active_Status ='" & ActiveStatus & "'", "")
            Dim M_Sort As String = "UN_Name ASC"
            Dim iCount As Integer = 1
            If Not Cmbbx Is Nothing Then
                M_DataTable.Columns.Add("ID", GetType(String))
                M_DataTable.Columns.Add("Name", GetType(String))
                M_DataTable.Columns.Add("Sort", GetType(String))
                If bDefault Then
                    If sDefaultTyp = "A" Then
                        M_DataTable.Rows.Add("0", "<-ALL->", "0")
                    ElseIf sDefaultTyp = "S" Then
                        M_DataTable.Rows.Add("0", "--", "0")
                    End If
                End If

                Dim dRow As DataRow
                For Each dRow In M_UserUnitsList.Select(M_Filter, M_Sort)
                    M_DataTable.Rows.Add(dRow("UN_ID").ToString, dRow("UN_Name").ToString, iCount.ToString)
                    iCount = iCount + 1
                Next dRow

                Call Fill_Combo(Cmbbx, M_DataTable, "Name", "ID")
                If Cmbbx.Items.Count > 0 Then Cmbbx.SelectedIndex = 0
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_ReportName(ByRef Cmbbx As Object, ByVal M_Type As Integer, Optional ByVal ActiveStatus As String = "Y", Optional ByVal DescriptionSort As Boolean = False) As Boolean
        Dim M_DataTable As New DataTable("ReportName_Tbl")
        Try
            Dim M_Filter As String = "RN_Type = " & M_Type & IIf(ActiveStatus <> "", " AND Active_Status ='" & ActiveStatus & "'", "")
            Dim M_Sort As String = IIf(DescriptionSort = True, "RN_Description ASC", "RN_Order ASC")
            Dim iCount As Integer = 1
            If Not Cmbbx Is Nothing Then
                M_DataTable.Columns.Add("ID", GetType(String))
                M_DataTable.Columns.Add("Name", GetType(String))
                M_DataTable.Columns.Add("Sort", GetType(String))

                Dim dRow As DataRow
                For Each dRow In M_ReportNameList.Select(M_Filter, M_Sort)
                    M_DataTable.Rows.Add(dRow("RN_Id").ToString, dRow("RN_Description").ToString, iCount.ToString)
                    iCount = iCount + 1
                Next dRow

                Call Fill_Combo(Cmbbx, M_DataTable, "Name", "ID")
                If Cmbbx.Items.Count > 0 Then Cmbbx.SelectedIndex = 0
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_AccHeadBalanceType(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("AccBalanceType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Status", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("D", "Dr")
                M_Datatbl.Rows.Add("C", "Cr")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Status"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_AccHeadType(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("AccHeadType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Status", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("A", "Asset")
                M_Datatbl.Rows.Add("L", "Liability")
                M_Datatbl.Rows.Add("I", "Income")
                M_Datatbl.Rows.Add("E", "Expense")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Status"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_AccHeadPosition(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("AccHeadPosition")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Status", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("T", "Trading")
                M_Datatbl.Rows.Add("P", "Profit & Loss")
                M_Datatbl.Rows.Add("B", "Balance Sheet")
                M_Datatbl.Rows.Add("TB", "Trading & Balance Sheet")
                M_Datatbl.Rows.Add("PB", "Profit & Loss and Balance Sheet")
                M_Datatbl.Rows.Add("N", "Nothing (Provision Head )") ' These heads not show in P & L  and Balance Sheet
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Status"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_AccHeadStmtType(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("AccHeadStmtType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Status", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("D", "Detailed")
                M_Datatbl.Rows.Add("S", "Summary")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Status"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_ActiveStatus(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("ActiveStatus")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Status", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<ALL>")
                M_Datatbl.Rows.Add("Y", "Active")
                M_Datatbl.Rows.Add("N", "DeActive")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Status"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_SearchFilterType(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("SearchFilterType_Tbl")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Name", GetType(String))
                M_Datatbl.Rows.Add("S", "Start With")
                M_Datatbl.Rows.Add("E", "End With")
                M_Datatbl.Rows.Add("C", "Contains")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_SearchFilterJoins(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("SearchFilterJoins_Tbl")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Name", GetType(String))
                M_Datatbl.Rows.Add("And", "AND")
                M_Datatbl.Rows.Add("Or", "OR")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_UserType(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("UserType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                M_Datatbl.Rows.Add("1", "SUPER USER")
                M_Datatbl.Rows.Add("2", "ADMIN USER")
                M_Datatbl.Rows.Add("3", "USER")

                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_UserGroup(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("UserGroup")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Group", GetType(String))
                M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("B", "BRANCH")
                M_Datatbl.Rows.Add("R", "REGION")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Group"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    
    Public Shared Function Fill_TranType(ByRef Cmbbx As Object, ByVal M_Mode As String, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("TranType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("0", "Both")
                If M_Mode = "B" Then
                    M_Datatbl.Rows.Add("1", "Deposit")
                    M_Datatbl.Rows.Add("-1", "Withdrawal")
                Else
                    M_Datatbl.Rows.Add("1", "Receipt")
                    M_Datatbl.Rows.Add("-1", "Payment")
                End If
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    
    Public Shared Function Fill_CalcType(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("CalcType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                M_Datatbl.Rows.Add("V", "Variable")
                M_Datatbl.Rows.Add("F", "Fixed")
                'M_Datatbl.AcceptChanges()

                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_TranMode(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("TranMode")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Mode", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("CA", "Cash")
                M_Datatbl.Rows.Add("CQ", "Cheque")
                M_Datatbl.Rows.Add("TR", "Transfer")
                M_Datatbl.Rows.Add("OT", "Other")

                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Mode"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_ChequeType(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("ChequeType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("CROSS", "Crossed Cheque")
                M_Datatbl.Rows.Add("CASH", "Cash Cheque")
                M_Datatbl.Rows.Add("NONE", "None Of This")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_AccType(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("AccountType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("0", "<-ALL->")
                M_Datatbl.Rows.Add("-1", "Creditor(Supplier)")
                M_Datatbl.Rows.Add("1", "Debtor(Customer)")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

   
    Public Shared Function Fill_WeekDays(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("WeekDays")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                M_Datatbl.Rows.Add("Sun", "Sunday")
                M_Datatbl.Rows.Add("Mon", "Monday")
                M_Datatbl.Rows.Add("Tue", "Tuesday")
                M_Datatbl.Rows.Add("Wed", "Wednesday")
                M_Datatbl.Rows.Add("Thu", "Thursday")
                M_Datatbl.Rows.Add("Fri", "Friday")
                M_Datatbl.Rows.Add("Sat", "Saturday")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                    .SelectedIndex = 0
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_Month(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("sMonth")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("sMonth", GetType(String))
                M_Datatbl.Rows.Add("1", "January")
                M_Datatbl.Rows.Add("2", "February")
                M_Datatbl.Rows.Add("3", "March")
                M_Datatbl.Rows.Add("4", "April")
                M_Datatbl.Rows.Add("5", "May")
                M_Datatbl.Rows.Add("6", "June")
                M_Datatbl.Rows.Add("7", "July")
                M_Datatbl.Rows.Add("8", "August")
                M_Datatbl.Rows.Add("9", "September")
                M_Datatbl.Rows.Add("10", "October")
                M_Datatbl.Rows.Add("11", "November")
                M_Datatbl.Rows.Add("12", "December")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "sMonth"
                    .ValueMember = "ID"
                    .Refresh()
                    .SelectedIndex = 0
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_Year(ByRef Cmbbx As Object, ByVal TrDate As Date) As Boolean
        Dim M_Datatbl As New DataTable("sYear")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("sYear", GetType(String))
                For I As Integer = 2017 To TrDate.Year
                    M_Datatbl.Rows.Add(I, I)
                Next I
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "sYear"
                    .ValueMember = "ID"
                    .Refresh()
                    .SelectedIndex = 0
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Create_MenuListTable() As DataTable
        Dim M_Datatbl As New DataTable("MenuList")
        Try
            M_Datatbl.Columns.Add("MM_ID", GetType(String))
            Return M_Datatbl
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function Fill_StatusType(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("StatusType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                M_Datatbl.Rows.Add("-1", "Pending")
                If Is_All Then M_Datatbl.Rows.Add("0", "<-ALL->")
                M_Datatbl.Rows.Add("1", "Complete")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

   
    Public Shared Function Fill_DataType(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("DataType_Tbl")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                M_Datatbl.Rows.Add("B", "Yes/No")
                M_Datatbl.Rows.Add("D", "DateTime")
                M_Datatbl.Rows.Add("N", "Numeric")
                M_Datatbl.Rows.Add("S", "String")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_DataLength(ByRef Cmbbx As Object, ByVal sDataType As String) As Boolean
        Dim M_Datatbl As New DataTable("DataLength_Tbl")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Length", GetType(String))


                If sDataType = "B" Then
                    M_Datatbl.Rows.Add("1", "1")
                ElseIf sDataType = "D" Then
                    M_Datatbl.Rows.Add("D", "Date")
                    M_Datatbl.Rows.Add("T", "Time")
                ElseIf sDataType = "N" Then
                    M_Datatbl.Rows.Add("0", "0")
                    M_Datatbl.Rows.Add("1", "1")
                    M_Datatbl.Rows.Add("2", "2")
                    M_Datatbl.Rows.Add("3", "3")
                ElseIf sDataType = "S" Then
                    For I = 1 To 250
                        M_Datatbl.Rows.Add(I.ToString, I.ToString)
                    Next I
                End If
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Length"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_OperatorType(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("OT")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                M_Datatbl.Rows.Add(">", "GT")
                M_Datatbl.Rows.Add(">=", "GT Or ET")
                M_Datatbl.Rows.Add("<", "LT")
                M_Datatbl.Rows.Add("<=", "LT Or ET")
                M_Datatbl.Rows.Add("<>", "NET")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_Gender(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("Gender")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("M", "Male")
                M_Datatbl.Rows.Add("F", "Female")
                M_Datatbl.Rows.Add("T", "Transgender")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_YesNo(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("YesNo")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Status", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("A", "<-ALL->")
                M_Datatbl.Rows.Add("Y", "Yes")
                M_Datatbl.Rows.Add("N", "No")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Status"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_IntervalType(ByRef Cmbbx As Object) As Boolean
        Dim M_Datatbl As New DataTable("IntervalType")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Type", GetType(String))
                M_Datatbl.Rows.Add("D", "Day")
                M_Datatbl.Rows.Add("W", "Week")
                M_Datatbl.Rows.Add("M", "Month")
                M_Datatbl.Rows.Add("H", "Half Year")
                M_Datatbl.Rows.Add("Y", "Year")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Fill_AccountTransactionType(ByRef Cmbbx As Object, Optional ByVal Is_All As Boolean = False) As Boolean
        Dim M_Datatbl As New DataTable("YesNo")
        Try
            If Not Cmbbx Is Nothing Then
                M_Datatbl.Columns.Add("ID", GetType(String))
                M_Datatbl.Columns.Add("Status", GetType(String))
                If Is_All Then M_Datatbl.Rows.Add("0", "<-ALL->")
                M_Datatbl.Rows.Add("1", "Cr")
                M_Datatbl.Rows.Add("-1", "Dr")
                With Cmbbx
                    .DataSource = M_Datatbl
                    .DisplayMember = "Status"
                    .ValueMember = "ID"
                    .Refresh()
                End With
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function Set_UnitFilterTable() As DataTable
        Dim M_DataTable As New DataTable("Table")
        M_DataTable.Columns.Add("ID", GetType(String))
        Return M_DataTable
    End Function

    Public Shared Sub Set_CursorType(Optional ByVal M_Type As String = "N")
        If M_Type <> "N" Then
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Else
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Public Shared Sub AddComboBoxColumns(ByVal addAt As Integer, ByVal cName As String, ByVal cID As String, ByVal sID As String, ByVal dt As DataTable, ByVal GView As Object, ByVal ColWidth As Integer)
        Dim cboCol As System.Windows.Forms.DataGridViewComboBoxColumn
        ' Creat a Combobox
        ' Syntax: CreateComboBoxColumn([Field Name],[Item ID field to be bind with DataGridView to Combobox])
        cboCol = CreateComboBoxColumn(cName, sID, ColWidth)

        ' Fill Combobox with alternate choices
        ' Syntax: SetAlternateChoicesUsingDataSource([cboCol: object], [cName: Field Name], [cID: Source item ID(like itemdata)], [qry: query to fill combobox])
        SetAlternateChoicesUsingDataSource(cboCol, cName, cID, dt)
        cboCol.HeaderText = cName
        ' Combobox created so add it to DataGridView
        GView.Columns.Insert(addAt, cboCol)

    End Sub

    Public Shared Function CreateComboBoxColumn(ByVal cName As String, ByVal sID As String, ByVal ColWidth As Integer) As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim col As New System.Windows.Forms.DataGridViewComboBoxColumn()
        With col
            '.Name = cName & "ABC"
            ' Bind ID field of destination Table. (Where value is stored)
            .DataPropertyName = sID
            .HeaderText = cName
            .DropDownWidth = 160
            .Width = ColWidth
            .MaxDropDownItems = 5
            .FlatStyle = System.Windows.Forms.FlatStyle.Flat
        End With
        Return col
    End Function

    Public Shared Sub SetAlternateChoicesUsingDataSource(ByVal cboColumn As System.Windows.Forms.DataGridViewComboBoxColumn, ByVal cName As String, ByVal cID As String, ByVal dt As DataTable)
        With cboColumn
            '.Name = "ABC"
            ' Fill Combobox
            .DataSource = dt
            ' Source Table Field To Be Displayed on Combobox
            .DisplayMember = cName
            ' Source Table Field with ID to be stored in table.
            .ValueMember = cID
        End With
    End Sub
    Public Shared Function IsInteger(ByVal sText As String) As Boolean
        Dim b As Boolean = True
        Dim x As Integer = 0
        For x = 0 To sText.Length - 1
            Dim sChar As String = sText.Substring(x, 1)
            If Asc(sChar) < 48 Or Asc(sChar) > 57 Then
                b = False
                Exit For
            End If
        Next
        Return b
    End Function
    Public Sub New()

        mOnesArray(0) = "one"
        mOnesArray(1) = "two"
        mOnesArray(2) = "three"
        mOnesArray(3) = "four"
        mOnesArray(4) = "five"
        mOnesArray(5) = "six"
        mOnesArray(6) = "seven"
        mOnesArray(7) = "eight"
        mOnesArray(8) = "nine"

        mOneTensArray(0) = "ten"
        mOneTensArray(1) = "eleven"
        mOneTensArray(2) = "twelve"
        mOneTensArray(3) = "thirteen"
        mOneTensArray(4) = "fourteen"
        mOneTensArray(5) = "fifteen"
        mOneTensArray(6) = "sixteen"
        mOneTensArray(7) = "seventeen"
        mOneTensArray(8) = "eightteen"
        mOneTensArray(9) = "nineteen"

        mTensArray(0) = "twenty"
        mTensArray(1) = "thirty"
        mTensArray(2) = "forty"
        mTensArray(3) = "fifty"
        mTensArray(4) = "sixty"
        mTensArray(5) = "seventy"
        mTensArray(6) = "eighty"
        mTensArray(7) = "ninety"

        mPlaceValues(0) = "hundred"
        mPlaceValues(1) = "thousand"
        mPlaceValues(2) = "million"
        mPlaceValues(3) = "billion"
        mPlaceValues(4) = "trillion"

    End Sub
    Protected Function GetOnes(ByVal OneDigit As Integer) As String

        GetOnes = ""

        If OneDigit = 0 Then
            Exit Function
        End If

        GetOnes = mOnesArray(OneDigit - 1)

    End Function


    Protected Function GetTens(ByVal TensDigit As Integer) As String

        GetTens = ""

        If TensDigit = 0 Or TensDigit = 1 Then
            Exit Function
        End If

        GetTens = mTensArray(TensDigit - 2)

    End Function


    Public Function ConvertNumberToWords(ByVal NumberValue As String) As String

        Dim Delimiter As String = " "
        Dim TensDelimiter As String = "-"
        Dim mNumberValue As String = ""
        Dim mNumbers As String = ""
        Dim mNumWord As String = ""
        Dim mFraction As String = ""
        Dim mNumberStack() As String
        Dim j As Integer = 0
        Dim i As Integer = 0
        Dim mOneTens As Boolean = False

        ConvertNumberToWords = ""
        ' validate input
        Try
            j = CDbl(NumberValue)
        Catch ex As Exception
            ConvertNumberToWords = "Invalid input."
            Exit Function
        End Try

        ' get fractional part {if any}
        If InStr(NumberValue, ".") = 0 Then
            ' no fraction
            mNumberValue = NumberValue
        Else
            mNumberValue = Microsoft.VisualBasic.Left(NumberValue, InStr(NumberValue, ".") - 1)
            mFraction = Mid(NumberValue, InStr(NumberValue, ".")) ' + 1)
            mFraction = Math.Round(CSng(mFraction), 2) * 100

            If CInt(mFraction) = 0 Then
                mFraction = ""
            Else
                mFraction = "&& " & mFraction & "/100"
            End If
        End If
        mNumbers = mNumberValue.ToCharArray

        ' move numbers to stack/array backwards
        For j = mNumbers.Length - 1 To 0 Step -1
            ReDim Preserve mNumberStack(i)

            mNumberStack(i) = mNumbers(j)
            i += 1
        Next

        For j = mNumbers.Length - 1 To 0 Step -1
            Select Case j
                Case 0, 3, 6, 9, 12
                    ' ones  value
                    If Not mOneTens Then
                        mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter
                    End If

                    Select Case j
                        Case 3
                            ' thousands
                            mNumWord &= mPlaceValues(1) & Delimiter

                        Case 6
                            ' millions
                            mNumWord &= mPlaceValues(2) & Delimiter

                        Case 9
                            ' billions
                            mNumWord &= mPlaceValues(3) & Delimiter

                        Case 12
                            ' trillions
                            mNumWord &= mPlaceValues(4) & Delimiter
                    End Select


                Case Is = 1, 4, 7, 10, 13
                    ' tens value
                    If Val(mNumberStack(j)) = 0 Then
                        mNumWord &= GetOnes(Val(mNumberStack(j - 1))) & Delimiter
                        mOneTens = True
                        Exit Select
                    End If

                    If Val(mNumberStack(j)) = 1 Then
                        mNumWord &= mOneTensArray(Val(mNumberStack(j - 1))) & Delimiter
                        mOneTens = True
                        Exit Select
                    End If

                    mNumWord &= GetTens(Val(mNumberStack(j)))

                    ' this places the tensdelimiter; check for succeeding 0
                    If Val(mNumberStack(j - 1)) <> 0 Then
                        mNumWord &= TensDelimiter
                    End If
                    mOneTens = False

                Case Else
                    ' hundreds value 
                    mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter

                    If Val(mNumberStack(j)) <> 0 Then
                        mNumWord &= mPlaceValues(0) & Delimiter
                    End If
            End Select
        Next

        Return mNumWord & mFraction

    End Function

    Public Shared Function DBDATE(ByVal Dt As Date, Optional ByVal WithoutQuate As Boolean = False) As String
        If WithoutQuate = False Then
            Return "'" & Format(Dt, "MM/dd/yyyy") & "'"
        Else
            Return "" & Format(Dt, "MM/dd/yyyy") & ""
        End If
    End Function

    Public Function Towords(ByVal Num As Double, Optional ByVal IsPrefix As Boolean = True)

        '*****       *****       *****       *****       *****
        ' Developed By  :     Pramod Bhasker
        ' DateTime      :     28-Dec-2006 18:44
        ' Procedure     :     Towords
        ' Purpose       :     To Display the rupees in words
        '*****       *****       *****       *****       *****

        Dim Word As String
        Dim pai As String
        Dim J As Int16 = 0
        Dim I As Int16 = 0
        Dim p As String = ""
        Dim f As String = ""
        Dim a(19) As String
        Dim leng As String, num1 As String
        Dim inwords As String
        Dim b(13) As String
        Dim C(15) As String

        On Error GoTo Towords_Error

        leng = CStr(Format(Num, ".00"))
        num1 = leng
        leng = Len(leng)
        a(1) = "One "
        a(2) = "Two "
        a(3) = "Three "
        a(4) = "Four "
        a(5) = "Five "
        a(6) = "Six "
        a(7) = "Seven "
        a(8) = "Eight "
        a(9) = "Nine "
        a(10) = "Ten "
        a(11) = "Eleven "
        a(12) = "Twelve "
        a(13) = "Thirteen "
        a(14) = "Fourteen "
        a(15) = "Fifteen "
        a(16) = "Sixteen "
        a(17) = "Seventeen "
        a(18) = "Eighteen "
        a(19) = "Nineteen "
        b(1) = "Ten "
        b(2) = "Twenty "
        b(3) = "Thirty "
        b(4) = "Forty "
        b(5) = "Fifty "
        b(6) = "Sixty "
        b(7) = "Seventy "
        b(8) = "Eighty "
        b(9) = "Ninty "
        b(10) = "Hundred "
        b(11) = "Thousand "
        b(12) = "Lakh "
        b(13) = "Crore "
        If Val(Num) = 0 Then
            Word = "Zero"
        ElseIf leng > 15 Then
            Exit Function
        Else
            J = 1
            For I = leng To 1 Step -1
                C(J) = Mid(num1, I, 1)
                If C(J) = "." Then
                    Dim last As Integer, flast As Integer
                    last = leng - J
                    flast = leng - I
                    p = CStr(Left(num1, last))
                    f = CStr(Right(num1, flast))
                End If
                J = J + 1
            Next

            If IsPrefix Then
                Word = Word + "Rupees "
            End If

            J = leng
            For I = Len(p) To 1 Step -1
                If (I = 2 Or I = 5 Or I = 7 Or I = 9) And C(J) <> "0" Then
                    If C(J) = "1" Then
                        I = I - 1
                        Word = Word + a(C(J) + C(J - 1))
                        J = J - 1
                        Select Case I
                            Case 8
                                Word = Word + b(13)
                            Case 6
                                Word = Word + b(12)
                            Case 4
                                Word = Word + b(11)
                            Case 3
                                Word = Word + b(10)
                        End Select
                    Else
                        Word = Word + b(Val(C(J)))
                        If C(J - 1) = "0" Then
                            Select Case I - 1
                                Case 8
                                    Word = Word + b(13)
                                Case 6
                                    Word = Word + b(12)
                                Case 4
                                    Word = Word + b(11)
                                Case 3
                                    Word = Word + b(10)
                            End Select
                        End If
                    End If
                ElseIf C(J) <> "0" Then
                    Word = Word + a(Val(C(J)))
                    Select Case I
                        Case 8
                            Word = Word + b(13)
                        Case 6
                            Word = Word + b(12)
                        Case 4
                            Word = Word + b(11)
                        Case 3
                            Word = Word + b(10)
                    End Select
                End If
                J = J - 1
            Next
            If C(1) <> "0" Or C(2) <> "0" Then Word = Word + "And "

            For I = Len(f) To 1 Step -1
                If I = 2 And C(I) <> "0" Then
                    If I = 2 And C(I) = "1" Then
                        Word = Word + a(C(I) + C(I - 1))
                        I = I - 1
                        pai = "T"
                    Else
                        Word = Word + b(Val(C(I)))
                        pai = "T"
                    End If
                ElseIf C(I) <> 0 Then
                    Word = Word + a(C(I))
                    pai = "T"
                End If

            Next
            If pai = "T" Then Word = Word + "Paise "
            Word = Word + "Only"
            inwords = Word
            Towords = inwords
        End If

        Exit Function

Towords_Error:


    End Function
    Public Shared Function ChkDate(ByVal Dt As String) As Boolean
        'FOR DATE CHECKIMG IN DD/MM/YY OR DD/MM/YYYY
        ChkDate = True
        If Not IsDate(Dt) Then
            ChkDate = False
            Exit Function
        ElseIf CInt(Left(Dt, 2)) > 31 Then
            ChkDate = False
            Exit Function
        ElseIf CInt(Mid(Dt, 4, 2)) > 12 Then
            ChkDate = False
            Exit Function
        ElseIf CInt(Mid(Dt, 7, 4)) > 2100 Then
            ChkDate = False
            Exit Function
        ElseIf CInt(Mid(Dt, 7, 4)) <= 1900 Then
            ChkDate = False
            Exit Function
        End If

        Exit Function
    End Function

    Public Function SfDateDiff(ByVal Interval As String, ByVal Date1 As Date, ByVal Date2 As Date) As Integer
        Dim I As Integer
        On Error GoTo SfDateDiff_Error

        I = DateDiff(Interval, Date1, Date2)

        If UCase(Interval) = "M" Then
            If Day(Date2) < Day(Date1) And Month(Date2) = Month(DateAdd("D", 1, Date2)) And LastDayOfMonth(Date2) <> Date2 Then
                If I >= 0 Then I = I - 1
            End If
        ElseIf UCase(Interval) = "Y" Then
            If Day(Date2) < Day(Date1) And Month(Date2) = Month(DateAdd("D", 1, Date2)) And LastDayOfMonth(Date2) <> Date2 Then
                If I >= 0 Then I = I - 1
            ElseIf DatePart("M", Date1) > DatePart("M", Date2) Then
                If I >= 0 Then I = I - 1
            End If
        End If
        Return I

        Exit Function

SfDateDiff_Error:
        Return 0
    End Function

    Public Shared Function LastDayOfMonth(ByVal Date1 As Date) As Date
        Dim rDate As Date

        On Error GoTo ErrHandler

        rDate = DateAdd("M", 1, Date1)
        rDate = DateAdd("D", (Day(rDate) * -1), rDate)

        Return rDate

        Exit Function
ErrHandler:
        Return Nothing
    End Function

    Public Shared Function MonthYearTo_Date(ByVal iMonth As Integer, ByVal iYear As Integer) As Date
        Dim M_Result As Date
        Dim M_FirstDate As New Date(iYear, iMonth, 1, 0, 0, 0)
        Try
            M_Result = LastDayOfMonth(M_FirstDate)
            Return M_Result

            Exit Function
        Catch
            Return Tran_Date
        End Try
    End Function

    Public Shared Function LogErrorToLogFile(ByVal M_EventName As String, ByVal Str As String) As String
        Try

            Dim path As String
            path = "C:\Log\"

            ' check if directory exists
            If Not System.IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path & DateTime.Today.ToString("dd-MMM-yyyy") & ".log"
            ' check if file exist
            If Not System.IO.File.Exists(path) Then
                System.IO.File.Create(path).Dispose()
            End If
            ' log the error now
            Using writer As System.IO.StreamWriter = System.IO.File.AppendText(path)
                Dim [error] As String = ""
                [error] = "Log written at : " & DateTime.Now.ToString() & " " & vbLf & Str & " At " & M_EventName
                writer.WriteLine([error])
                writer.Flush()
                writer.Close()
            End Using
            Return Str
        Catch
            Return ""
        End Try
    End Function

    Public Function LogErrorToLogFile(ByVal ee As Exception, ByVal userFriendlyError As String, Optional ByVal DllCall As Boolean = False) As String
        Try

            Dim path As String
            If DllCall = True Then
                path = "E:\Log\"
            Else
                path = System.Web.HttpContext.Current.Server.MapPath("~/ErrorLogging/")
            End If

            ' check if directory exists
            If Not System.IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path & DateTime.Today.ToString("dd-MMM-yyyy") & ".log"
            ' check if file exist
            If Not System.IO.File.Exists(path) Then
                System.IO.File.Create(path).Dispose()
            End If
            ' log the error now
            Using writer As System.IO.StreamWriter = System.IO.File.AppendText(path)
                Dim [error] As String = ""
                If DllCall = False Then
                    [error] = vbCr & vbLf & "Log written at : " & DateTime.Now.ToString() & vbCr & vbLf & "Error occured on page : " & System.Web.HttpContext.Current.Request.Url.ToString() & vbCr & vbLf & vbCr & vbLf & "Here is the actual error :" & vbLf & ee.ToString()
                Else
                    [error] = vbLf & ee.ToString()
                End If
                [error] = [error] & vbCr & vbCrLf & "Msg : " & ee.Message
                writer.WriteLine([error])
                writer.WriteLine("==========================================")
                writer.Flush()
                writer.Close()
            End Using
            Return userFriendlyError
        Catch : Return "" : End Try
    End Function

    Private Sub LoggError(ByVal ee As Exception)
        Try
            LogErrorToLogFile(ee, "")
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub SendKeyTab(ByVal Sender As Object, ByVal ActiveControl As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal Check_MultiLineProperty As Boolean = True)
        If e.KeyChar = Chr(13) Then
            If ActiveControl.GetType.ToString = "System.Windows.Forms.TextBox" And Check_MultiLineProperty Then
                If ActiveControl.Multiline = True Then
                    e.KeyChar = vbNewLine
                Else
                    Forms.SendKeys.Send("{TAB}")
                End If
            Else
                Forms.SendKeys.Send("{TAB}")
            End If
        ElseIf e.KeyChar = Chr(27) Then
            If MsgBox("Do You Want To Close...?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART CrM") = MsgBoxResult.Yes Then
                Sender.Close()
            End If
        End If
    End Sub

    Public Shared Sub SendKeyTab()
        Forms.SendKeys.Send("{TAB}")
    End Sub

    Public Shared Function Validate_KeyAscii(ByVal keycode As Short, ByVal Expression As String, ByVal DataType As String, ByVal MaxLength As Short) As Short

        Validate_KeyAscii = keycode

        If keycode = System.Windows.Forms.Keys.Back Then Exit Function
        If keycode = System.Windows.Forms.Keys.Tab Then Exit Function

        Dim ChrKeycode As String

        ChrKeycode = Chr(keycode)

        If MaxLength > 0 Then
            If Len(Expression.Trim) >= MaxLength Then Validate_KeyAscii = 0 : Exit Function
        End If


        Select Case DataType.ToUpper.Trim
            Case "DATETYPE"

            Case "ALPHA"

            Case "ALPHANUMERIC"

            Case "INTEGER"

                If InStr(1, GoodNum, ChrKeycode) = 0 Then
                    Validate_KeyAscii = 0 : Exit Function
                End If

            Case "DOUBLE"


                If InStr(1, CStr(GoodNum & "."), ChrKeycode) = 0 Then
                    Validate_KeyAscii = 0 : Exit Function
                Else
                    If ChrKeycode = "." Then
                        If InStr(1, Expression, ".") > 0 Then Validate_KeyAscii = 0 : Exit Function
                    End If
                End If

            Case "GENERAL"

            Case Else

        End Select


    End Function



    Public Shared Function SendMail(ByVal sSmtpServer As String, ByVal sSmtpPort As Integer, ByVal sSmtpCredentialUserName As String, _
                             ByVal sSmtpCredentialPassword As String, ByVal bSmtpEnableSsl As Boolean, ByVal sMailFrom As String, _
                             ByVal sMailReplyTo As String, ByVal sMailSender As String, ByVal sMailTo As String, ByVal sMailSubject As String, ByVal sMailBody As String, _
                             Optional ByVal sMailCC As String = "", Optional ByVal sMailBCC As String = "", Optional ByVal sAttachment As String = "") As Boolean
        Dim Mail As New MailMessage()
        Dim SmtpServer As New SmtpClient(sSmtpServer)
        Try
            SmtpServer.Port = sSmtpPort
            SmtpServer.Credentials = New System.Net.NetworkCredential(sSmtpCredentialUserName, sSmtpCredentialPassword)
            SmtpServer.EnableSsl = bSmtpEnableSsl

            Mail.From = New MailAddress(sMailFrom)
            Mail.ReplyTo = New MailAddress(sMailReplyTo)
            Mail.Sender = New MailAddress(sMailSender)
            Mail.To.Add(sMailTo)
            Mail.Subject = sMailSubject
            Mail.Body = sMailBody
            Mail.IsBodyHtml = True

            If sMailCC <> "" Then
                Mail.CC.Add(sMailCC)
            End If
            If sMailBCC <> "" Then
                Mail.Bcc.Add(sMailBCC)
            End If
            If sAttachment <> "" Then
                Dim Attachment As System.Net.Mail.Attachment
                Attachment = New System.Net.Mail.Attachment(sAttachment)
                Mail.Attachments.Add(Attachment)
            End If

            SmtpServer.Send(Mail)
            Return True
        Catch ex As Exception
            LogErrorToLogFile("SendMail - ", ex.Message)
            Return False
        End Try
    End Function
End Class
