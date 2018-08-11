Imports System.Reflection
Imports System.Windows.Forms
Imports SMARTtBR_CO.CommonClass
Imports SMARTtBR_BL
Imports System.Threading

Public Class SMARTtBR_MDI

    Dim M_CommonBL As New CommonBL

    Public Enum Enm_SearchProperty
        Text = 0
        Tag
        SelectedValue
    End Enum

    Public Sub Search(ByVal CallFrom As Object, ByVal M_SearchID As Integer, ByVal ReturnCol As Integer, ByRef ReturnObject As Object, Optional ByVal ReturnObjectProperty As Enm_SearchProperty = Enm_SearchProperty.Text, Optional ByRef OtherFilter As String = "")
        Dim FrmSrh As New Search_Frm
        FrmSrh.SetSearch(M_SearchID, ReturnCol, ReturnObject, ReturnObjectProperty, OtherFilter)

        FrmSrh.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        FrmSrh.ShowDialog(CallFrom)

        FrmSrh = Nothing
    End Sub

    Private Sub Menu_Click(ByVal Sender As Object, ByVal e As System.EventArgs)

        Dim MenuName As String = ""
        Dim FrmName As String = ""
        Dim Frm As New Form
        Dim M_MultipleInstance As Boolean = False
        Try
            FrmName = M_CommonBL.Get_FormName(User_ID, Sender.Tag, MenuName, M_MultipleInstance)
            Select Case MenuName
                Case "Mnu_Lock"
                    Call Smart_Lock()
                Case "Mnu_LogOff"
                    If MsgBox("Do You Want To Log Off SMART CrM.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART CrM") = MsgBoxResult.Yes Then
                        Call M_CommonBL.InsertUpdate_LogDetails(User_LoginID, "Exit", User_ID, System_Name)
                        Me.Dispose()
                        Login_Frm.Txt_UserName.Select()
                        Call Login_Frm.Show()
                    End If
                Case "Mnu_Exit"
                    If MsgBox("Do You Want To Close SMART CrM.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART CrM") = MsgBoxResult.Yes Then
                        Call M_CommonBL.InsertUpdate_LogDetails(User_LoginID, "Exit", User_ID, System_Name)
                        Me.Dispose()
                        End
                    End If
                Case "Mnu_Calc"
                    System.Diagnostics.Process.Start("Calc")
                Case "Mnu_Refresh"
                    Call Refresh_Data()
                Case Else
                    If FrmName = "" Then
                        MsgBox("Under Construction", MsgBoxStyle.Exclamation, "INFORMATION")
                    ElseIf FrmName = "HC" Then
                        Exit Sub
                    Else
                        Call ShowForm(FrmName, Sender.Tag, M_MultipleInstance)
                    End If
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ShowForm(ByVal FormName As String, ByVal M_MenuID As Integer, ByVal M_MultipleInstance As Boolean)
        Try
            If Validate_AllowFormMultiInstance(M_MenuID, M_MultipleInstance) = False Then
                MessageBox.Show("Menu Already  Opened..." & vbNewLine + " Multiple Menu Instance Not Allowed...", "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim Type As Type = Type.GetType("SMARTtBR_UI." & FormName)
                Dim FrmObject As Object = Activator.CreateInstance(Type)

                DirectCast(FrmObject, Form).Owner = Me
                DirectCast(FrmObject, Form).StartPosition = FormStartPosition.CenterScreen
                DirectCast(FrmObject, Form).Tag = M_MenuID
                DirectCast(FrmObject, Form).Show()
                FormOpen_ID = FormOpen_ID + 1

                If M_MultipleInstance = False Then Call Set_AddToMenuListTable(M_MenuID)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function Validate_AllowFormMultiInstance(ByVal M_MenuID As Integer, ByVal M_MultipleInstance As Boolean) As Boolean
        Dim Result As Boolean = True
        Dim Dr() As DataRow
        If M_MultipleInstance = False Then
            Dr = M_OpenMenuList.Select("MM_ID =" & M_MenuID.ToString, "MM_ID")
            If Dr.Length > 0 Then Result = False
        End If
        Return Result
    End Function

    Public Sub Set_MenuListTable()
        M_OpenMenuList = Create_MenuListTable()
    End Sub

    Public Sub Set_AddToMenuListTable(ByVal M_MenuID As Integer)
        M_OpenMenuList.Rows.Add(M_MenuID.ToString)
    End Sub

    Public Sub Set_DeleteFromMenuListTable(ByVal M_MenuID As String)
        Dim Dr() As DataRow
        Try
            Dr = M_OpenMenuList.Select("MM_ID =" & M_MenuID.ToString)
            For I = 0 To Dr.Length - 1
                M_OpenMenuList.Rows.Remove(Dr(I))
            Next
        Catch ex As Exception
            LogErrorToLogFile(Me.Name & " - Set_DeleteFromMenuListTable ", ex.Message)
        End Try
    End Sub

    Private Sub SMARTtBR_MDI_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If MsgBox("Do You Want To Close SMART CrM.", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART CrM") = MsgBoxResult.Yes Then
                Call M_CommonBL.InsertUpdate_LogDetails(User_LoginID, "Exit", User_ID, System_Name)
                Call Set_SystemDateFormat(False)
                Me.Dispose()
                End
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Refresh_Data()
        Try
            Call Set_CursorType("W")

            M_ParamCodeList = M_CommonBL.Fill_ParamCodeList()
            M_UserUnitsList = M_CommonBL.Fill_UserUnitsList(Company_Code, User_ID)
            M_ReportNameList = M_CommonBL.Fill_ReportTypeList()
            M_UnitMasterTreeList = M_CommonBL.Fill_UnitMasterTree(Company_Code, User_ID)
            M_AccountMasterTreeList = M_CommonBL.Fill_AccountMasterTree(Company_Code, "Y")
            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
        End Try
    End Sub

    Private Sub SMARTtBR_MDI_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Login_Frm.Hide()
            ApplicationPath = Application.StartupPath
            Me.Text = Application.ProductName & " " & Application.ProductVersion & " [ " & Company_Name & " ]"
            If ToolStrip.Items.Count = 0 Then ToolStrip.Visible = False

            Call Set_MenuListTable()

            IdealTime_Tmr.Enabled = (AutoLogOut_Period > 0)
            MessageBox.Show("Hi, Welcome to SMARTtBR." & vbNewLine & vbNewLine & " Your Login Date : " & Format(Tran_Date, "dd/MMM/yyyy"), ">>>>>>WELCOME<<<<<<", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
        End Try
    End Sub


    Public Sub SetUser_MenuItem(ByVal UserId As Integer)
        Dim M_CommonBL As New CommonBL
        Dim M_DtMain As DataTable
        Dim M_DtSub As DataTable
        Dim M_DtChild As DataTable
        Dim iCheck As Integer = 0
        Dim iRowCount As Integer = 0
        Dim iCRowCount As Integer = 0
        Dim iCCheck As Integer = 0
        M_DtMain = M_CommonBL.Get_UserWiseMenu(UserId, "M")

        Dim dRowM As DataRow
        Dim dRowS As DataRow
        Dim dRowC As DataRow

        MenuStrip.Items.Clear()

        For Each dRowM In M_DtMain.Rows
            Dim Item As New ToolStripMenuItem(dRowM("MM_Caption").ToString)
            Item.Name = dRowM("MM_Name").ToString
            Item.Tag = dRowM("MM_ID").ToString
            M_DtSub = M_CommonBL.Get_UserWiseMenu(UserId, "S", dRowM("MM_MainID"))
            iRowCount = M_DtSub.Rows.Count
            For Each dRowS In M_DtSub.Rows
                If (dRowS("MM_Caption") = "-") Then
                    If (iCheck > 0) And (iCheck < iRowCount - 1) Then
                        Dim SepItem As New ToolStripSeparator()
                        SepItem.Name = dRowS("MM_Name").ToString
                        SepItem.Tag = dRowS("MM_ID").ToString
                        Item.DropDownItems.Add(SepItem)
                        SepItem = Nothing
                    End If
                Else
                    Dim InnerItem As New ToolStripMenuItem(dRowS("MM_Caption").ToString)
                    InnerItem.Name = dRowS("MM_Name").ToString
                    InnerItem.Tag = dRowS("MM_ID").ToString
                    If dRowS("MM_ShortKey").ToString <> "" Then
                        InnerItem.ShowShortcutKeys = True
                        InnerItem.ShortcutKeys = dRowS("MM_ShortKey").ToString
                        'InnerItem.ShortcutKeys = DirectCast(Shortcut.CtrlF6, Keys)
                    End If
                    AddHandler InnerItem.Click, AddressOf Me.Menu_Click

                    M_DtChild = M_CommonBL.Get_UserWiseMenu(UserId, "C", dRowS("MM_MainID"), dRowS("MM_SubID"))
                    iCRowCount = M_DtChild.Rows.Count
                    For Each dRowC In M_DtChild.Rows
                        If (dRowC("MM_Caption") = "-") Then
                            If (iCCheck > 0) And (iCCheck < iCRowCount - 1) Then
                                Dim SepItem As New ToolStripSeparator()
                                SepItem.Name = dRowC("MM_Name").ToString
                                SepItem.Tag = dRowC("MM_ID").ToString
                                InnerItem.DropDownItems.Add(SepItem)
                                SepItem = Nothing
                            End If
                        Else
                            Dim ChildItem As New ToolStripMenuItem(dRowC("MM_Caption").ToString)
                            ChildItem.Name = dRowC("MM_Name").ToString
                            ChildItem.Tag = dRowC("MM_ID").ToString
                            If dRowS("MM_ShortKey").ToString <> "" Then
                                ChildItem.ShowShortcutKeys = True
                                InnerItem.ShortcutKeys = dRowS("MM_ShortKey").ToString
                            End If
                            AddHandler ChildItem.Click, AddressOf Me.Menu_Click
                            InnerItem.DropDownItems.Add(ChildItem)
                            ChildItem = Nothing
                        End If
                        iCCheck = iCCheck + 1
                    Next
                    iCCheck = 0

                    Item.DropDownItems.Add(InnerItem)
                    InnerItem = Nothing
                End If
                iCheck = iCheck + 1
            Next
            MenuStrip.Items.Add(Item)
            iCheck = 0
            Item = Nothing
        Next

    End Sub

    Public Sub Smart_LogOff()
        Try
            Call M_CommonBL.InsertUpdate_LogDetails(User_LoginID, "Exit", User_ID, System_Name)
            Me.Dispose()
            Login_Frm.Txt_UserName.Select()
            Call Login_Frm.Show()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Smart_Lock()
        Try
            ApplicationLock_Status = True
            Call M_CommonBL.InsertUpdate_LogDetails(User_LoginID, "Exit", User_ID, System_Name)
            Dim Frm As New Lock_Frm
            Frm.Txt_UserName.Enabled = False
            Frm.Txt_UserName.Text = User_Name
            Frm.Txt_Password.Select()
            Frm.ShowDialog(Me)
            Frm = Nothing
            ApplicationLock_Status = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IdealTime_Tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IdealTime_Tmr.Tick
        Dim sysIdleTime_Minute As Integer
        Dim MyLastInputInfo = New LASTINPUTINFO
        Try
            MyLastInputInfo.cbSize = Runtime.InteropServices.Marshal.SizeOf(MyLastInputInfo)
            If ApplicationLock_Status Then Exit Sub
            If GetLastInputInfo(MyLastInputInfo) Then     ' if we have an input info     
                Dim sysIdleTime_ms As Integer = (GetTickCount() - MyLastInputInfo.dwTime)
                sysIdleTime_Minute = sysIdleTime_ms / 60000
                If sysIdleTime_Minute >= AutoLogOut_Period Then
                    Call Smart_Lock()
                End If
            End If
        Catch ex As Exception : End Try
    End Sub

    Public Function Add_Modify_Units(ByRef M_UNID As Long) As Boolean
        Dim M_Result As Boolean = False
        Try
            Dim Frm As New UnitMaster_Frm
            Dim M_FormID As Integer = M_CommonBL.Get_FormID(User_ID, Frm.Name)
            Frm.Tag = M_FormID

            Frm.StartPosition = FormStartPosition.CenterParent
            Frm.M_ShowModal = True
            Frm.Fill_Details()
            Frm.Clear_Controls()

            If M_UNID <> 0 Then
                Frm.Locate_Units(M_UNID)
            End If
            Frm.Cmd_Clear.Enabled = False
            Frm.ShowDialog(Me)
            If Frm.M_OK = True Then
                M_Result = True
                M_UNID = Frm.M_UNID
            Else
                M_Result = False
            End If

            Frm = Nothing

            Return M_Result
        Catch ex As Exception
            Return M_Result
            LogErrorToLogFile(Me.Name & " - Add_Modify_Units ", ex.Message)
        End Try
    End Function

    Public Function Show_UnitFilter(ByVal M_UnitFilter_Tbl As DataTable) As DataTable
        Dim M_ResultTbl As DataTable
        Try
            Dim Frm As New UnitFilter_Frm
            Frm.StartPosition = FormStartPosition.CenterParent
            Frm.Fill_UnitTreeView()
            Frm.Set_CurrentFilter(M_UnitFilter_Tbl)
            Frm.ShowDialog(Me)
            If Frm.M_OK Then
                M_ResultTbl = Frm.M_Filter_Tbl
            Else
                M_ResultTbl = M_UnitFilter_Tbl
            End If
            Frm = Nothing

            Return M_ResultTbl
        Catch ex As Exception
            Return M_UnitFilter_Tbl
            LogErrorToLogFile(Me.Name & " - Show_UnitFilter ", ex.Message)
        End Try
    End Function

    Public Function Show_AccountFilter(ByVal M_AccHeadFilter_Tbl As DataTable) As DataTable
        Dim M_ResultTbl As DataTable
        Try
            Dim Frm As New AccountFilter_Frm
            Frm.StartPosition = FormStartPosition.CenterParent
            Frm.Fill_AccountTreeView()
            Frm.Set_CurrentFilter(M_AccHeadFilter_Tbl)
            Frm.ShowDialog(Me)
            If Frm.M_OK Then
                M_ResultTbl = Frm.M_Filter_Tbl
            Else
                M_ResultTbl = M_AccHeadFilter_Tbl
            End If
            Frm = Nothing

            Return M_ResultTbl
        Catch ex As Exception
            Return M_AccHeadFilter_Tbl
            LogErrorToLogFile(Me.Name & " - Show_AccHeadFilter ", ex.Message)
        End Try
    End Function

End Class
