Imports SMARTtBR_BL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms.TreeNode
Imports System.Windows.Forms.TreeView
Imports System.Windows.Forms

Public Class ParaCode_Frm

    Dim M_CommonBL As New CommonBL
    Dim M_ParaCodeBL As New ParaCodeBL
    Private M_EntryMode As String
    Dim M_PCID As Long
    Dim ParentNode As TreeNode
    Dim iCount As Long = 0
    Dim M_LockedStatus As String = "N"

    Private Function ValidateControls() As Boolean
        Dim sMsg As String
        Try
            Call Set_CursorType("W")

            If Trim(Txt_PCDescription.Text) = "" Then
                Txt_PCDescription.Focus()
                Txt_PCDescription.SelectAll()
                sMsg = "Parameter name could not be blank !"
                GoTo Invalid
            End If

            If Trim(Txt_PCOrder.Text) = "" Then
                Txt_PCOrder.Focus()
                Txt_PCOrder.SelectAll()
                sMsg = "Sequence No could not be blank !"
                GoTo Invalid
            End If

            If Trim(Cmb_PCType.SelectedValue) = 0 Then
                Cmb_PCType.Focus()
                sMsg = "Select parameter Type !"
                GoTo Invalid
            End If

            If M_EntryMode = "NEW" Then
                If M_ParaCodeBL.Check_ParameterNameExists(Txt_PCDescription.Text.Trim, Cmb_PCType.SelectedValue) Then
                    sMsg = "Parameter name is duplicated ! " & vbNewLine & "Please correct this before saving."
                    Txt_PCDescription.Focus()
                    Txt_PCDescription.SelectAll()
                    GoTo Invalid
                End If
            ElseIf M_EntryMode = "VIEW" And User_TypeID <> 0 Then
                If M_ParaCodeBL.Check_ParameterLocked(Val(Txt_PCID.Text.Trim)) Then
                    sMsg = "Parameter name is Locked ! " & vbNewLine & "Can't saving."
                    GoTo Invalid
                End If
            End If


            Call Set_CursorType("N")
            Return True
            Exit Function
Invalid:
            If sMsg <> "" Then MsgBox(sMsg, MsgBoxStyle.Critical, "Could not Save")
            Return False
            Exit Function
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub Clear_Controls()
        M_PCID = 0
        Cmd_Save.Enabled = True  ''Enable Save Button
        If Cmb_ActiveStatus.Items.Count > 0 Then Cmb_ActiveStatus.SelectedIndex = 0
        Txt_PCID.Text = ""
        Txt_PCDescription.Text = ""
        Txt_PCOrder.Text = ""
        Cmb_PCType.Enabled = True
        M_LockedStatus = "N"
        M_EntryMode = "NEW"
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            Call Clear_Controls()
            Me.ActiveControl = Txt_PCID
            M_EntryMode = "NEW"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub ParaCode_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub ParaCode_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Fill_Details()
            Call Clear_Controls()
            Call Fill_ParamTreeView()
            Me.ActiveControl = Txt_PCID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Fill_Details()
        Try
            Call Set_CursorType("W")

            M_CommonBL.Fill_ParamType(Cmb_PCType)
            Call Fill_ActiveStatus(Cmb_ActiveStatus)
            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Tvw_ParamList_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Tvw_ParamList.NodeMouseDoubleClick

        Dim name As String = ""
        Dim Code As Integer = 0
        Try
            M_EntryMode = "VIEW"

            If Tvw_ParamList.SelectedNode Is Nothing Then
                Exit Sub
            Else
                name = Tvw_ParamList.SelectedNode.Text
                Code = Val(Tvw_ParamList.SelectedNode.ToolTipText)
            End If

            If Tvw_ParamList.SelectedNode.Tag = "HEAD" And Code <> 0 Then
                Txt_PCID.Text = Code
                Me.ActiveControl = Txt_PCID
            Else
                Call Clear_Controls()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Fill_ParamTreeView()
        Dim M_DtType As DataTable
        Dim M_DtCode As DataTable

        Try
            iCount = 1
            Tvw_ParamList.Nodes.Clear()
            M_DtType = M_ParaCodeBL.Fill_ParamTypeDetails()
            M_DtCode = M_ParaCodeBL.Fill_ParamCodeDetails()

            For Each dRowG In M_DtType.Rows
                Call Fill_TreeView(M_DtType, M_DtCode, dRowG("PT_ID").ToString, dRowG("PT_Description").ToString)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Fill_TreeView(ByVal M_Dt As DataTable, ByVal M_DtC As DataTable, ByVal PType As String, ByVal GrpName As String)
        Dim ChildNode As TreeNode
        Try
            ParentNode = Tvw_ParamList.Nodes.Add(iCount.ToString, GrpName.ToString)
            ParentNode.Tag = "GROUP"
            ParentNode.ToolTipText = PType.ToString
            iCount = iCount + 1

            For Each FoundRows As DataRow In M_DtC.[Select]("PC_Type=" & PType.ToString)
                ChildNode = ParentNode.Nodes.Add(iCount.ToString, FoundRows("PC_Description").ToString)
                ChildNode.ToolTipText = FoundRows("PC_Id").ToString
                ChildNode.Tag = "HEAD"
                iCount = iCount + 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Txt_PCID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = Chr(Validate_KeyAscii((Asc(e.KeyChar)), Txt_PCID.Text, "DOUBLE", 15))
    End Sub

    Private Sub Locate_Data(ByVal M_ParaCode As SMARTtBR_BO.ParaCodeBO)

        If M_ParaCode.PCId = 0 Then
            M_EntryMode = "NEW"
            Call Clear_Controls()
            Exit Sub
        End If

        With M_ParaCode
            M_PCID = .PCID
            Txt_PCID.Text = .PCId
            Cmb_PCType.SelectedValue = .PCType
            Txt_PCOrder.Text = .PCOrder
            Txt_PCDescription.Text = .PCDescription
            Cmb_ActiveStatus.SelectedValue = .ActiveStatus
            M_LockedStatus = .PCLocked
            Cmb_PCType.Enabled = False
        End With
        M_EntryMode = "VIEW"
    End Sub

    Private Sub Txt_PCID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_PCID.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 4, 1, Txt_PCID, SMARTtBR_MDI.Enm_SearchProperty.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Txt_PCId_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_PCID.Validating
        If Txt_PCId.Text.Length = 0 Then
            Call Clear_Controls()
            M_EntryMode = "NEW"
        Else
            Try
                Dim M_ParaCode As New SMARTtBR_BO.ParaCodeBO
                Dim M_ParaCodeBL As New ParaCodeBL
                M_ParaCode = M_ParaCodeBL.Locate_Data(Txt_PCId.Text)
                Call Locate_Data(M_ParaCode)
                M_ParaCodeBL = Nothing
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub ParaCode_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Txt_PCOrder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PCOrder.KeyPress
        e.KeyChar = Chr(Validate_KeyAscii((Asc(e.KeyChar)), Txt_PCOrder.Text, "DOUBLE", 15))
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Dim M_ParaCode As New SMARTtBR_BO.ParaCodeBO

        If M_EntryMode = "NEW" Then
            If MsgBox("Do you want to Add Parameter Under " & Cmb_PCType.Text & " ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMARTtBR") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If ValidateControls() = False Then Exit Sub
        If User_TypeID < 2 Then
            M_LockedStatus = InputBox("Enter Locked Status...", "SMARTtBR", M_LockedStatus)
        End If
        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_ParaCode
            .PCID = M_PCID
            .PCType = Cmb_PCType.SelectedValue
            .PCOrder = Val(Txt_PCOrder.Text)
            .MakerID = User_ID
            If M_EntryMode = "VIEW" Then
                .UpdaterId = User_ID
            Else
                .UpdaterId = 0
            End If
            .PCDescription = Txt_PCDescription.Text.ToString.Trim
            .PCLocked = M_LockedStatus
            .ActiveStatus = Cmb_ActiveStatus.SelectedValue
        End With

        Try
            M_PCID = M_ParaCodeBL.Save_Data(M_ParaCode, M_EntryMode, Me.Tag)
            If M_PCID > 0 Then
                M_ParamCodeList = M_CommonBL.Fill_ParamCodeList()
                MessageBox.Show("Data Saved... ID : " & M_PCID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call Fill_ParamTreeView()
                Call Clear_Controls()
                Call Fill_Details()
                Txt_PCID.Focus()
            Else
                Cmd_Save.Enabled = True  ''Enable Save Button
            End If
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
        End Try
    End Sub

End Class