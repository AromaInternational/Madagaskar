Imports SMARTtBR_BL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms.TreeNode
Imports System.Windows.Forms.TreeView
Imports System.Windows.Forms

Public Class AccountMaster_Frm

    Dim M_CommonBL As New CommonBL
    Dim M_AccMasterBL As New AccountMasterBL
    Dim M_AccGroupBL As New AccountGroupBL

    Private M_EntryMode As String
    Dim M_AccCode As Long
    Dim M_GPID As Long
    Dim ParentNode As TreeNode
    Dim iCount As Long = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Function ValidateControl() As Boolean
        Dim sMsg As String
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            If SST_Accnt_Master.SelectedIndex = 0 Then

                If Trim(Txt_GPName.Text) = "" Then
                    Txt_GPName.Focus()
                    Txt_GPName.SelectAll()
                    sMsg = "A/c group name could not be blank !"
                    GoTo Invalid
                End If

                If Trim(Txt_GPSeqNo.Text) = "" Then
                    Txt_GPSeqNo.Focus()
                    Txt_GPSeqNo.SelectAll()
                    sMsg = "A/c group's sequence code could not be blank !"
                    GoTo Invalid
                End If

                If Trim(Txt_GPParentId.Text) = "" Then
                    Txt_GPParentId.Focus()
                    Txt_GPParentId.SelectAll()
                    sMsg = "A/c group's parent group code could not be blank !" & vbNewLine & "Please provide the new group code if this is a top level group."
                    GoTo Invalid
                End If

                If M_AccGroupBL.Check_GroupNameExists(Txt_GPName.Text.Trim, M_GPID) Then
                    sMsg = "Group name is duplicated ! " & vbNewLine & "Please correct this before saving."
                    Txt_GPName.Focus()
                    Txt_GPName.SelectAll()
                    GoTo Invalid
                End If

            ElseIf SST_Accnt_Master.SelectedIndex = 1 Then

                If Trim(Txt_AccName.Text) = "" Then
                    sMsg = "A/c head name could not be blank !"
                    Txt_AccName.Focus()
                    Txt_AccName.SelectAll()
                    GoTo Invalid
                End If

                If Trim(Cmb_AccGPName.SelectedValue) = "" Then
                    sMsg = "A/c head's parent group name could not be blank !"
                    Cmb_AccGPName.Focus()
                    GoTo Invalid
                End If

                If Trim(Txt_AccSeqNo.Text) = "" Then
                    sMsg = "A/c head's sequence number could not be blank !"
                    Txt_AccSeqNo.Focus()
                    Txt_AccSeqNo.SelectAll()
                    GoTo Invalid
                End If

                If Cmb_AccBalanceType.SelectedValue = "C" Then

                    If Cmb_AccType.SelectedValue <> "L" And Cmb_AccType.SelectedValue <> "I" Then
                        sMsg = "A/c Type selected is not valid for this balance type !"
                        Cmb_AccType.Focus()
                        GoTo Invalid
                    End If

                ElseIf Cmb_AccBalanceType.SelectedValue = "B" Then

                    If Cmb_AccType.SelectedValue <> "A" And Cmb_AccType.SelectedValue <> "E" Then
                        sMsg = "A/c Type selected is not valid for this balance type !"
                        Cmb_AccType.Focus()
                        GoTo Invalid
                    End If
                End If

                If Cmb_AccType.SelectedValue = "A" Or Cmb_AccType.SelectedValue = "L" Then

                    If Cmb_Position.SelectedValue <> "B" And Cmb_Position.SelectedValue <> "TB" And Cmb_Position.SelectedValue <> "PB" Then
                        sMsg = "Position selected is not valid for this A/c type !"
                        Cmb_Position.Focus()
                        GoTo Invalid
                    End If

                ElseIf Cmb_AccType.SelectedValue = "I" Or Cmb_AccType.SelectedValue = "E" Then

                    If Cmb_Position.SelectedValue = "B" Then
                        sMsg = "Position selected is not valid for this A/c type !"
                        Cmb_Position.Focus()
                        GoTo Invalid
                    End If
                End If


                If M_AccMasterBL.Check_HeadNameExists(Txt_AccName.Text.Trim, M_AccCode) Then
                    sMsg = "A/c head's Name is duplicated ! " & vbNewLine & "Please correct this before saving."
                    Txt_AccName.Focus()
                    Txt_AccName.SelectAll()
                    GoTo Invalid
                End If

            End If

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Return True
            Exit Function
Invalid:
            If sMsg <> "" Then MsgBox(sMsg, MsgBoxStyle.Critical, "Could not Save")
            Return False
            Exit Function
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub Clear_Controls()
        Cmd_Save.Enabled = True  ''Enable Save Button
        M_GPID = 0
        M_AccCode = 0
        If Cmb_AccType.Items.Count > 0 Then Cmb_AccType.SelectedIndex = 0
        If Cmb_AccType.Items.Count > 0 Then Cmb_AccType.SelectedIndex = 0
        If Cmb_Position.Items.Count > 0 Then Cmb_Position.SelectedIndex = 0
        If Cmb_AccStmtType.Items.Count > 0 Then Cmb_AccStmtType.SelectedIndex = 0
        If Cmb_AccEnabled.Items.Count > 0 Then Cmb_AccEnabled.SelectedIndex = 0
        If Cmb_GPEnabled.Items.Count > 0 Then Cmb_GPEnabled.SelectedIndex = 0
        If Cmb_AccGPName.Items.Count > 0 Then Cmb_AccGPName.SelectedIndex = 0
        If Cmb_BillBreakUp.Items.Count > 0 Then Cmb_BillBreakUp.SelectedIndex = 0
        Txt_GPID.Text = ""
        Txt_GPName.Text = ""
        Txt_GPSeqNo.Text = ""
        Txt_GPParentId.Text = ""
        Txt_AccCode.Text = ""
        Txt_AccName.Text = ""
        Txt_AccSeqNo.Text = ""
        Txt_GPParentName.Text = ""
        M_EntryMode = "NEW"
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            Call Clear_Controls()
            If SST_Accnt_Master.SelectedIndex = 0 Then
                If Txt_GPID.Visible = True Then Txt_GPID.Focus()
            ElseIf SST_Accnt_Master.SelectedIndex = 1 Then
                If Txt_AccCode.Visible = True Then Txt_AccCode.Focus()
            End If
            M_EntryMode = "NEW"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub AccountMaster_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub AccountMaster_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Fill_Details()
            Call Clear_Controls()
            Call Fill_AccountTreeView()
            SST_Accnt_Master.SelectTab(1)
            Me.ActiveControl = Txt_AccCode

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Fill_Details()
        Try
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Call Fill_AccHeadBalanceType(Cmb_AccBalanceType)
            If Cmb_AccBalanceType.Items.Count > 0 Then Cmb_AccBalanceType.SelectedIndex = 0

            Call Fill_AccHeadType(Cmb_AccType)
            If Cmb_AccType.Items.Count > 0 Then Cmb_AccType.SelectedIndex = 0

            Call Fill_YesNo(Cmb_BillBreakUp)
            If Cmb_BillBreakUp.Items.Count > 0 Then Cmb_BillBreakUp.SelectedIndex = 0

            Call Fill_AccHeadPosition(Cmb_Position)
            If Cmb_Position.Items.Count > 0 Then Cmb_Position.SelectedIndex = 0

            Call Fill_AccHeadStmtType(Cmb_AccStmtType)
            If Cmb_AccStmtType.Items.Count > 0 Then Cmb_AccStmtType.SelectedIndex = 0

            Call Fill_ActiveStatus(Cmb_GPEnabled)
            Call Fill_ActiveStatus(Cmb_AccEnabled)

            M_CommonBL.Fill_AccountGroup(Cmb_AccGPName)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Tvw_AccGroup_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Tvw_AccGroup.NodeMouseDoubleClick

        Dim name As String = ""
        Dim Code As String = ""
        Try
            M_EntryMode = "VIEW"

            If Tvw_AccGroup.SelectedNode Is Nothing Then
                Exit Sub
            Else
                name = Tvw_AccGroup.SelectedNode.Text
                Code = Tvw_AccGroup.SelectedNode.ToolTipText
            End If

            If Tvw_AccGroup.SelectedNode.Tag = "GROUP" Then
                SST_Accnt_Master.SelectTab(0)
                Call Get_AccGPDetails(Val(Code.ToString.Substring(0, 3)))
            Else
                SST_Accnt_Master.SelectTab(1)
                Call Get_AccMasDetails(Val(Code.ToString.Substring(3, 5)))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Get_AccGPDetails(ByVal AcGP As Integer)

        Dim M_AccGroupBO As New AccountGroupBO
        Dim M_AccGroupBL As New AccountGroupBL

        Try

            M_AccGroupBO = M_AccGroupBL.Locate_Data(AcGP)

            With M_AccGroupBO
                If .GPID = 0 Then
                    M_EntryMode = "NEW"
                    Call Clear_Controls()
                Else
                    M_EntryMode = "VIEW"
                    M_GPID = .GPID
                    Txt_GPID.Text = .GPID
                    Txt_GPName.Text = .GPName
                    Txt_GPSeqNo.Text = .GPSeqNo
                    Txt_GPParentId.Text = .GPParentId
                    Cmb_GPEnabled.SelectedValue = .ActiveStatus
                End If
            End With

            If Val(Txt_GPParentId.Text) > 0 Then
                M_AccGroupBO = M_AccGroupBL.Locate_Data(Val(Txt_GPParentId.Text))
                With M_AccGroupBO
                    Txt_GPParentName.Text = .GPName
                End With
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Get_AccMasDetails(ByVal AcCode As Integer)
        Dim M_AccMasterBO As New AccountMasterBO
        Dim M_AccMasterBL As New AccountMasterBL

        Try
            M_AccMasterBO = M_AccMasterBL.Locate_Data(Company_Code, AcCode)
            With M_AccMasterBO
                If .AccCode = 0 Then
                    M_EntryMode = "NEW"
                    Call Clear_Controls()
                Else
                    M_EntryMode = "VIEW"

                    M_AccCode = .AccCode
                    Txt_AccCode.Text = .AccCode
                    Txt_AccName.Text = .AccName
                    Txt_AccSeqNo.Text = .AccSeqNo
                    Cmb_AccGPName.SelectedValue = .AccGPID
                    Cmb_AccBalanceType.SelectedValue = .AccBalType
                    Cmb_AccType.SelectedValue = .AccALIE
                    Cmb_Position.SelectedValue = .AccPosition
                    Cmb_AccStmtType.SelectedValue = .AccStatementtype
                    Cmb_AccEnabled.SelectedValue = .ActiveStatus
                    Cmb_BillBreakUp.SelectedValue = .AccBillBreakup
                End If
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Fill_AccountTreeView()
        Dim M_DtGroup As DataTable
        Dim I As Integer
        Try
            Tvw_AccGroup.Nodes.Clear()
            M_DtGroup = M_AccGroupBL.Fill_AccountMasterTree(Company_Code)

            For I = 0 To M_DtGroup.Rows.Count - 1
                Dim sKey As String = M_DtGroup.Rows(I).Item("Key").ToString
                M_DtGroup.Rows(I).Item("Level") = FindLevel(M_DtGroup, sKey, 0)
            Next

            If M_DtGroup.Rows.Count > 0 Then Call Fill_TreeView(M_DtGroup)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function FindLevel(ByVal M_Dt As DataTable, ByVal sKey As String, ByRef Level As Integer) As Integer
        Dim i As Integer
        Try
            For i = 0 To M_Dt.Rows.Count - 1
                Dim ID1 As String = M_Dt.Rows(i).Item("Key").ToString
                Dim sParent As String = M_Dt.Rows(i).Item("KeyParent").ToString

                If sKey = ID1 Then
                    If sParent = sKey Then
                        Return Level
                    Else
                        Level = Level + 1
                        Call FindLevel(M_Dt, sParent, Level)
                        Return Level
                    End If
                End If
            Next

            Return Level
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub Fill_TreeView(ByVal M_Dt As DataTable)
        Dim ChildNode As TreeNode
        Dim MaxLevel As Integer = CInt(M_Dt.Compute("MAX(Level)", ""))

        Dim i, j As Integer
        Try
            For i = 0 To MaxLevel
                Dim sRows() As DataRow = M_Dt.Select("Level = " & i)

                For j = 0 To sRows.Count - 1
                    Dim sID As String = sRows(j).Item("Key").ToString
                    Dim sName As String = sRows(j).Item("NAME").ToString
                    Dim iCode As String = sRows(j).Item("ID").ToString
                    Dim sParent As String = sRows(j).Item("KeyParent").ToString
                    Dim sType As String = sRows(j).Item("ItemType").ToString

                    If sParent = sID Then
                        ParentNode = Tvw_AccGroup.Nodes.Add(sID, sName)
                        ParentNode.ToolTipText = iCode
                        ParentNode.Tag = sType
                    Else
                        Dim TreeNodes() As TreeNode = Tvw_AccGroup.Nodes.Find(sParent, True)

                        If TreeNodes.Length > 0 Then
                            ChildNode = TreeNodes(0).Nodes.Add(sID, sName)
                            ChildNode.ToolTipText = iCode
                            ChildNode.Tag = sType
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Txt_AccCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_AccCode.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 7, 1, Txt_AccCode, SMARTtBR_MDI.Enm_SearchProperty.Text, " AND Acc_CmpCode = " & Company_Code)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_AccCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_AccCode.KeyPress
        e.KeyChar = Chr(Validate_KeyAscii((Asc(e.KeyChar)), Txt_AccCode.Text, "DOUBLE", 15))
    End Sub

    Private Sub Txt_AccCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_AccCode.Validating
        Call Get_AccMasDetails(Val(Txt_AccCode.Text))
    End Sub

    Private Sub Txt_GPID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_GPID.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 6, 1, Txt_GPID, SMARTtBR_MDI.Enm_SearchProperty.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_GPID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_GPID.Validating
        Call Get_AccGPDetails(Val(Txt_GPID.Text))
    End Sub

    Private Sub Txt_GPParentId_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_GPParentId.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 6, 1, Txt_GPParentId, SMARTtBR_MDI.Enm_SearchProperty.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_GPParentId_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_GPParentId.Validating
        Dim M_AccGroupBO As New AccountGroupBO
        Dim M_AccGroupBL As New AccountGroupBL

        Try
            If Txt_GPID.Text.Trim <> Txt_GPParentId.Text.Trim And Val(Txt_GPParentId.Text) > 0 Then
                M_AccGroupBO = M_AccGroupBL.Locate_Data(Val(Txt_GPParentId.Text))
                With M_AccGroupBO
                    Txt_GPParentName.Text = .GPName
                End With
            Else
                Txt_GPParentName.Text = Txt_GPName.Text
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AccountMaster_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub Txt_GPID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = Chr(Validate_KeyAscii((Asc(e.KeyChar)), Txt_GPID.Text, "DOUBLE", 15))
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Txt_GPSeqNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_GPSeqNo.KeyPress
        e.KeyChar = Chr(Validate_KeyAscii((Asc(e.KeyChar)), Txt_GPSeqNo.Text, "DOUBLE", 15))
    End Sub

    Private Sub Txt_AccSeqNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_AccSeqNo.KeyPress
        e.KeyChar = Chr(Validate_KeyAscii((Asc(e.KeyChar)), Txt_AccSeqNo.Text, "DOUBLE", 15))
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Try

            If SST_Accnt_Master.SelectedIndex = 0 Then

                If ValidateControl() = False Then Exit Sub

                Dim M_AccountGroup As New SMARTtBR_BO.AccountGroupBO

                Cmd_Save.Enabled = False  ''Disable Save Button

                With M_AccountGroup
                    .GPID = Val(Txt_GPID.Text)
                    .GPSeqNo = Val(Txt_GPSeqNo.Text)
                    .MakerID = User_ID
                    If M_EntryMode = "VIEW" Then
                        .UpdaterID = User_ID
                    Else
                        .UpdaterID = 0
                    End If
                    .GPName = Txt_GPName.Text.ToString
                    .GPParentId = Txt_GPParentId.Text.ToString
                    .ActiveStatus = Cmb_GPEnabled.SelectedValue
                End With

                Dim M_AccountGroupBL As New AccountGroupBL
                M_GPID = M_AccountGroupBL.Save_Data(M_AccountGroup, M_EntryMode, Me.Tag)
                If M_GPID > 0 Then
                    MessageBox.Show("Data Saved... GPID : " & M_GPID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call Fill_AccountTreeView()
                    Call Clear_Controls()
                    Call Fill_Details()
                    M_AccountGroupBL = Nothing
                    Txt_GPID.Focus()
                Else
                    Cmd_Save.Enabled = True  ''Enable Save Button
                End If

            ElseIf SST_Accnt_Master.SelectedIndex = 1 Then

                If ValidateControl() = False Then Exit Sub

                Dim M_AccountMaster As New SMARTtBR_BO.AccountMasterBO

                Cmd_Save.Enabled = False  ''Disable Save Button

                With M_AccountMaster
                    .AccCode = Val(Txt_AccCode.Text)
                    .AccGPID = Cmb_AccGPName.SelectedValue
                    .AccCmpCode = Company_Code
                    .AccSeqNo = Val(Txt_AccSeqNo.Text)
                    .MakerID = User_ID
                    If M_EntryMode = "VIEW" Then
                        .UpdaterID = User_ID
                    Else
                        .UpdaterID = 0
                    End If
                    .AccName = Txt_AccName.Text.Trim
                    .AccBalType = Cmb_AccBalanceType.SelectedValue
                    .AccALIE = Cmb_AccType.SelectedValue
                    .AccPosition = Cmb_Position.SelectedValue
                    .AccStatementtype = Cmb_AccStmtType.SelectedValue
                    .AccBillBreakup = Cmb_BillBreakUp.SelectedValue
                    .ActiveStatus = Cmb_AccEnabled.SelectedValue
                End With

                Dim M_AccountMasterBL As New AccountMasterBL
                M_AccCode = M_AccountMasterBL.Save_Data(M_AccountMaster, M_EntryMode, Me.Tag)
                If M_AccCode > 0 Then
                    MessageBox.Show("Data Saved... AccCode : " & M_AccCode, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call Fill_AccountTreeView()
                    Call Clear_Controls()
                    Call Fill_Details()
                    Txt_AccCode.Focus()
                    M_AccountMasterBL = Nothing
                Else
                    Cmd_Save.Enabled = True  ''Enable Save Button
                End If
            End If
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmb_GPEnabled_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Cmb_GPEnabled.KeyDown
        If e.KeyCode.Equals(Keys.Tab) Or e.KeyCode.Equals(Keys.Enter) Then
            SST_Accnt_Master.SelectTab(1)
        End If
    End Sub

    Private Sub Cmd_Delete_Click(sender As Object, e As EventArgs) Handles Cmd_Delete.Click
        Dim M_CommonBL As New CommonBL
        Dim M_ID As Integer = 0
        Dim M_Type As String = ""
        Try
            Dim M_DataSet As System.Data.DataSet
            Dim M_Dt As DataTable
            If SST_Accnt_Master.SelectedIndex = 0 Then
                If Val(Txt_GPID.Text) > 0 Then
                    M_ID = Val(Txt_GPID.Text)
                    M_Type = "G"
                Else
                    MessageBox.Show("Select Group ID....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf SST_Accnt_Master.SelectedIndex = 1 Then
                If Val(Txt_AccCode.Text) > 0 Then
                    M_ID = Val(Txt_AccCode.Text)
                    M_Type = "A"
                Else
                    MessageBox.Show("Select Account ID....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            M_DataSet = M_CommonBL.Delete_AccountGroup("DELETE", Company_Code, M_Type, M_ID, User_ID, Me.Tag)
            If Not M_DataSet Is Nothing Then
                M_Dt = M_DataSet.Tables(0)
                If M_Dt.Rows.Count > 0 Then
                    If M_Dt.Rows(0).Item("R_Status").ToString = "Y" Then
                        MessageBox.Show(M_Dt.Rows(0).Item("R_Message").ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call Fill_AccountTreeView()
                        Call Clear_Controls()
                        Call Fill_Details()
                        Txt_AccCode.Focus()
                    Else
                        MessageBox.Show(M_Dt.Rows(0).Item("R_Message").ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Contact IT Team....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            M_CommonBL = Nothing
        Catch ex As Exception
            M_CommonBL = Nothing
        End Try
    End Sub

End Class