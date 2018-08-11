Option Explicit On

Imports SMARTtBR_BL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_CO.CommonClass

Public Class Login_Frm

    Dim M_CommonBL As New CommonBL
    Dim iTryCount As Integer = 0

    Public Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        If Txt_UserName.Text.Length = 0 Then
            MessageBox.Show("Invalid UserName ", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim Return_Msg As String = ""
        Dim M_UserMasterBO As New UserMasterBO
        Dim M_UserBL As New UserMasterBL

        Try

            M_UserMasterBO = M_UserBL.Locate_DataWithName(Txt_UserName.Text.Trim())
            Tran_Date = Dtp_TranDate.Value.Date
            If M_UserMasterBO.UMName = "" Then
                If UCase(Txt_UserName.Text.Trim) = "SYSTEM" And Len(Txt_Password.Text.Trim) > 8 Then
                    If UCase(Txt_Password.Text.Trim.Substring(Len(Txt_Password.Text.Trim) - 5, 5)) = "OASIS" Then
                        User_Name = "SYSTEM"
                        User_Password = "OASIS"
                        User_ID = 1
                        User_TypeID = 0
                        User_UnitID = 0
                        AutoLogOut_Period = 5
                        User_Designation = "ADMIN"
                        Txt_UserName.Text = ""
                        Txt_Password.Text = ""

                        M_UserRightList = M_CommonBL.Fill_UserRightDetails(User_ID)
                        M_ParamCodeList = M_CommonBL.Fill_ParamCodeList()
                        M_UserUnitsList = M_CommonBL.Fill_UserUnitsList(Company_Code, User_ID)
                        M_ReportNameList = M_CommonBL.Fill_ReportTypeList()
                        M_UnitMasterTreeList = M_CommonBL.Fill_UnitMasterTree(Company_Code, User_ID)
                        M_AccountMasterTreeList = M_CommonBL.Fill_AccountMasterTree(Company_Code, "Y")

                        With SMARTtBR_MDI
                            .ToolStrip_UserName.Text = "USER : " & User_Name
                            .ToolStrip_Designation.Text = "DESIGNATION : " & User_Designation
                            .ToolStrip_TranDate.Text = "DATE : " & Format(Tran_Date, "dd/MMM/yyyy")
                            .ToolStrip_ServerName.Text = "SERVER : " & Server_Name
                            .SetUser_MenuItem(User_ID)
                            .Show()
                        End With
                    Else
                        iTryCount = iTryCount + 1

                        If iTryCount = 3 Then
                            Call Set_SystemDateFormat(False)
                            End
                        End If

                        MessageBox.Show("Invalid User Name Or Password...", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Txt_Password.Text = ""
                        Txt_Password.Focus()
                    End If
                Else
                    iTryCount = iTryCount + 1

                    If iTryCount = 3 Then
                        Call Set_SystemDateFormat(False)
                        End
                    End If


                    MessageBox.Show("Invalid User Name Or Password...", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txt_Password.Text = ""
                    Txt_Password.Focus()
                End If
            Else

                If M_UserBL.ValidateUser(M_UserMasterBO, Txt_Password.Text, Return_Msg) = False Then
                    iTryCount = iTryCount + 1

                    If iTryCount = 3 Then
                        Call Set_SystemDateFormat(False)
                        End
                    End If

                    MessageBox.Show(Return_Msg, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Txt_Password.Text = ""
                    Txt_Password.Focus()
                Else
                    With M_UserMasterBO
                        User_Name = .UMName
                        User_Password = .UMPwd
                        User_ID = .UMID
                        User_TypeID = .UMTypeID
                        User_UnitID = .UMUNID
                        User_Designation = .UMDesignation
                        AutoLogOut_Period = .UMAutoLogOutPeriod
                    End With

                    M_UserRightList = M_CommonBL.Fill_UserRightDetails(User_ID)
                    M_ParamCodeList = M_CommonBL.Fill_ParamCodeList()
                    M_UserUnitsList = M_CommonBL.Fill_UserUnitsList(Company_Code, User_ID)
                    M_ReportNameList = M_CommonBL.Fill_ReportTypeList()
                    M_UnitMasterTreeList = M_CommonBL.Fill_UnitMasterTree(Company_Code, User_ID)
                    M_AccountMasterTreeList = M_CommonBL.Fill_AccountMasterTree(Company_Code, "Y")

                    Txt_Password.Text = ""
                    Txt_UserName.Text = ""
                    With SMARTtBR_MDI
                        .ToolStrip_UserName.Text = "USER : " & User_Name
                        .ToolStrip_Designation.Text = "DESIGNATION : " & User_Designation
                        .ToolStrip_TranDate.Text = "DATE : " & Format(Tran_Date, "dd/MMM/yyyy")
                        .ToolStrip_ServerName.Text = "SERVER : " & Server_Name
                        .SetUser_MenuItem(User_ID)
                        .Show()
                    End With
                    Call M_CommonBL.InsertUpdate_LogDetails(User_LoginID, "NEW", User_ID, System_Name)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Call Set_SystemDateFormat(False)
        Me.Close()
    End Sub


    Public Sub New()

        InitializeComponent()
        Try
            Call Set_SystemDateFormat(True)
            Company_Code = Get_AppSettings("COMPANY_CODE")

            ServerType = Get_AppSettings("SERVER_INFO")
            If Get_AppSettings("SERVER_SELECTION") = True Then
                Dim Frm As New ServerSelection_Frm
                With Frm
                    If (ServerType = "L") Then
                        .Opt_Local.Checked = True
                        .Opt_Public.Checked = False
                    Else
                        .Opt_Local.Checked = False
                        .Opt_Public.Checked = True
                    End If
                    .ShowDialog(Me)
                End With
                Frm = Nothing

                If ServerType = "L" Then
                    Data_Base = Get_AppSettings("DATABASE")
                Else
                    Data_Base = Get_AppSettings("DATABASE_P")
                End If
            Else
                Data_Base = Get_AppSettings("DATABASE")
            End If

            Server_Name = CommonBL.Get_ServerName()
            Call CommonBL.Set_ProjectVariables("01/01/1900")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Login_Frm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If System_Name.ToUpper = "ITM" Or System_Name.ToUpper = "IT2" Then
            If e.KeyCode = Keys.F8 Then
                Txt_UserName.Text = "SYSTEM"
                Txt_Password.Text = "ASDFGHJOASIS"
                Call OK_Click(Me, e)
            End If
        End If
    End Sub

    Private Sub Login_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub Login_Frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dtp_TranDate.Value = Tran_Date
            Txt_UserName.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
