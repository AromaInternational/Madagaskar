Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class UserMaster_Frm

    Dim M_UMID As Long = 0

    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_UserMasterBL As New UserMasterBL

    Dim ParentNode As TreeNode
    Dim M_TreeGroup_Tbl As DataTable
    Dim Is_SetCurrentFilter As Boolean = False

    Dim M_UnitFilter_Tbl As New DataTable("Table")

    Private Sub Clear_Controls()
        Try
            Cmd_Save.Enabled = True  ''Enable Save Button
            M_UMID = 0
            M_EntryMode = "NEW"
            Txt_UMName.Text = ""
            Txt_UMID.Text = ""
            Txt_UMPwd.Text = ""
            Txt_UMPwdConfirm.Text = ""
            Txt_UMAutoLogOutPeriod.Text = "5"

            If Cmb_UMDepID.Items.Count > 0 Then Cmb_UMDepID.SelectedIndex = 0
            If Cmb_UMTypeID.Items.Count > 0 Then Cmb_UMTypeID.SelectedValue = 3
            If Cmb_UMUNID.Items.Count > 0 Then Cmb_UMUNID.SelectedIndex = 0
            If Cmb_UMDesID.Items.Count > 0 Then Cmb_UMDesID.SelectedIndex = 0
            If Cmb_ActveStatus.Items.Count > 0 Then Cmb_ActveStatus.SelectedIndex = 0

            Call Load_UserUnitFilter(M_UMID)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Fill_Details()
        Try
            Call Set_CursorType("W")

            Call Fill_ActiveStatus(Cmb_ActveStatus)
            Call Fill_UserType(Cmb_UMTypeID)
            Call M_CommonBL.Fill_Department(Cmb_UMDepID, "Y")
            Call M_CommonBL.Fill_Designation(Cmb_UMDesID, "Y")
            Call Fill_UnitTreeView()
            Call Fill_Unit(Cmb_UMUNID, "Y")
            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function ValidateControls() As Boolean

        Dim sMsg As String
        Dim AssignedStatus As Boolean = False
        Try
            If Txt_UMName.Text.Length = 0 Then
                sMsg = "Eneter User Name.... !"
                GoTo Invalid
            End If

            If Txt_UMPwd.Text <> Txt_UMPwdConfirm.Text Then
                sMsg = "Passwords Not matching... !"
                GoTo Invalid
            End If

            If M_EntryMode = "NEW" Then
                If M_UserMasterBL.Check_UserNameExists(Txt_UMName.Text.Trim) Then
                    sMsg = "User name is duplicated ! " & vbNewLine & "Please correct this before saving."
                    Txt_UMName.Focus()
                    Txt_UMName.SelectAll()
                    GoTo Invalid
                End If
            End If

            Dim checked As List(Of TreeNode) = GetCheckedNodes(Tvw_Unit)
            For Each node As TreeNode In checked
                AssignedStatus = (Val(node.ToolTipText.Substring(3, 5)) = Val(Cmb_UMUNID.SelectedValue))
                If AssignedStatus = True Then Exit For
            Next

            If AssignedStatus = False Then
                sMsg = "Assigned Unit Not Alloted..... !"
                GoTo Invalid
            End If

            Return True
            Exit Function
Invalid:
            If sMsg <> "" Then MsgBox(sMsg, MsgBoxStyle.Critical, "Could not Save")
            Return False
            Exit Function
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub UserMaster_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub


    Private Sub UserMaster_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Call Fill_Details()
            Call Clear_Controls()
            Me.ActiveControl = Txt_UMID

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub


    Private Sub UserMaster_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Dim M_User As New SMARTtBR_BO.UserMasterBO

        If ValidateControls() = False Then Exit Sub
        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_User
            .UMID = M_UMID
            .UMDepID = Cmb_UMDepID.SelectedValue
            .UMDesID = Cmb_UMDesID.SelectedValue
            .UMTypeID = Cmb_UMTypeID.SelectedValue
            .MakerID = User_ID
            .UpdaterID = IIf(M_EntryMode = "VIEW", User_ID, 0)
            .UMPwd = Txt_UMPwd.Text.Trim
            .UMName = Txt_UMName.Text.Trim
            .UMUNID = Cmb_UMUNID.SelectedValue
            .UMAutoLogOutPeriod = Val(Txt_UMAutoLogOutPeriod.Text)
            .ActiveStatus = Cmb_ActveStatus.SelectedValue
        End With

        Call Set_UserUnitFilter()

        Try
            Dim M_AllotedUnitsSw As New IO.StringWriter
            M_UnitFilter_Tbl.WriteXml(M_AllotedUnitsSw)

            M_UMID = M_UserMasterBL.Save_Data(M_User, M_AllotedUnitsSw.ToString.Replace("DocumentElement", "NewDataSet"), M_EntryMode, Me.Tag)
            If M_UMID > 0 Then
                MessageBox.Show("Data Saved... ID : " & M_UMID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call Clear_Controls()
                Call Fill_Details()
                Me.ActiveControl = Txt_UMID
            Else
                Cmd_Save.Enabled = True  ''Enable Save Button
            End If
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
        End Try

    End Sub


    Private Sub Locate_Data(ByVal M_UserMaster As SMARTtBR_BO.UserMasterBO)

        If M_UserMaster.UMID = 0 Then
            M_EntryMode = "NEW"
            Call Clear_Controls()
            Exit Sub
        End If

        With M_UserMaster
            M_UMID = .UMID
            Cmb_UMDepID.SelectedValue = .UMDepID
            Cmb_UMDesID.SelectedValue = .UMDesID
            Cmb_UMTypeID.SelectedValue = .UMTypeID
            Txt_UMPwd.Text = .UMPwd
            Txt_UMPwdConfirm.Text = .UMPwd
            Txt_UMName.Text = .UMName
            Cmb_UMUNID.SelectedValue = .UMUNID
            Txt_UMAutoLogOutPeriod.Text = .UMAutoLogOutPeriod
            Cmb_ActveStatus.SelectedValue = .ActiveStatus
        End With

        Call Load_UserUnitFilter(M_UMID)

        M_EntryMode = "VIEW"
    End Sub

    Private Sub Txt_UMID_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_UMID.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 5, 1, Txt_UMID, SMARTtBR_MDI.Enm_SearchProperty.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Txt_UMID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_UMID.Validating
        If Txt_UMID.Text.Length = 0 Then
            Call Clear_Controls()
            M_EntryMode = "NEW"
        Else
            Try
                Dim M_UserMaster As New SMARTtBR_BO.UserMasterBO
                Dim M_UserMasterBL As New UserMasterBL
                M_UserMaster = M_UserMasterBL.Locate_Data(Txt_UMID.Text)
                Call Locate_Data(M_UserMaster)
                M_UserMasterBL = Nothing
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Try
            Call Clear_Controls()
            Me.ActiveControl = Txt_UMID
            M_EntryMode = "NEW"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Fill_UnitTreeView()
        Dim I As Integer
        Is_SetCurrentFilter = True
        Try
            Tvw_Unit.Nodes.Clear()
            M_TreeGroup_Tbl = M_CommonBL.Fill_UnitMasterTree(0, User_ID)

            For I = 0 To M_TreeGroup_Tbl.Rows.Count - 1
                Dim sKey As String = M_TreeGroup_Tbl.Rows(I).Item("Key").ToString
                M_TreeGroup_Tbl.Rows(I).Item("Level") = FindLevel(M_TreeGroup_Tbl, sKey, 0)
            Next

            If M_TreeGroup_Tbl.Rows.Count > 0 Then
                Call Fill_TreeView(M_TreeGroup_Tbl, Tvw_Unit)
                Tvw_Unit.ExpandAll()
            End If

            Is_SetCurrentFilter = False
        Catch ex As Exception
            Is_SetCurrentFilter = False
            LogErrorToLogFile(Me.Name & " - Fill_UnitTreeView ", ex.Message)
        End Try
    End Sub

    Private Sub Fill_TreeView(ByVal M_Dt As DataTable, ByVal Tvw_Tree As TreeView)
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
                        ParentNode = Tvw_Tree.Nodes.Add(sID, sName)
                        ParentNode.ToolTipText = iCode
                        ParentNode.Tag = sType
                    Else
                        Dim TreeNodes() As TreeNode = Tvw_Tree.Nodes.Find(sParent, True)

                        If TreeNodes.Length > 0 Then
                            ChildNode = TreeNodes(0).Nodes.Add(sID, sName)
                            ChildNode.ToolTipText = iCode
                            ChildNode.Tag = sType
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            LogErrorToLogFile(Me.Name & " - Fill_TreeView ", ex.Message)
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
            LogErrorToLogFile(Me.Name & " - FindLevel ", ex.Message)
        End Try
    End Function

    Private Sub Tvw_Unit_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles Tvw_Unit.AfterCheck
        If Is_SetCurrentFilter Then Exit Sub

        RemoveHandler Tvw_Unit.AfterCheck, AddressOf Tvw_Unit_AfterCheck

        Call CheckAllChildNodes(e.Node)

        If e.Node.Checked Then
            If e.Node.Parent Is Nothing = False Then
                Dim allChecked As Boolean = True
                Call IsEveryChildChecked(e.Node.Parent, allChecked)
                If allChecked Then
                    e.Node.Parent.Checked = True
                    Call ShouldParentsBeChecked(e.Node.Parent)
                End If
            End If
        Else
            Dim parentNode As TreeNode = e.Node.Parent
            While parentNode Is Nothing = False
                parentNode.Checked = False
                parentNode = parentNode.Parent
            End While
        End If

        AddHandler Tvw_Unit.AfterCheck, AddressOf Tvw_Unit_AfterCheck
    End Sub

    Private Sub CheckAllChildNodes(ByVal parentNode As TreeNode)
        For Each childNode As TreeNode In parentNode.Nodes
            childNode.Checked = parentNode.Checked
            CheckAllChildNodes(childNode)
        Next
    End Sub

    Private Sub IsEveryChildChecked(ByVal parentNode As TreeNode, ByRef checkValue As Boolean)
        For Each node As TreeNode In parentNode.Nodes
            Call IsEveryChildChecked(node, checkValue)
            If Not node.Checked Then
                checkValue = False
            End If
        Next
    End Sub

    Private Sub ShouldParentsBeChecked(ByVal startNode As TreeNode)
        If startNode.Parent Is Nothing = False Then
            Dim allChecked As Boolean = True
            Call IsEveryChildChecked(startNode.Parent, allChecked)
            If allChecked Then
                startNode.Parent.Checked = True
                Call ShouldParentsBeChecked(startNode.Parent)
            End If
        End If
    End Sub

    Private Sub Load_UserUnitFilter(ByVal M_UserID As Integer)
        Is_SetCurrentFilter = True
        Try
            M_UnitFilter_Tbl = M_CommonBL.Fill_UserUnitTreeCodeRight(M_UserID)
            For Each node As TreeNode In Tvw_Unit.Nodes
                Call Set_CurrentFilterNodesToChecked(node)
            Next
            Is_SetCurrentFilter = False
        Catch ex As Exception
            Is_SetCurrentFilter = False
            LogErrorToLogFile(Me.Name & " - Load_UserUnitFilter ", ex.Message)
        End Try
    End Sub

    Private Sub Set_CurrentFilterNodesToChecked(ByVal tn As TreeNode)

        Dim drFilter() As DataRow = M_UnitFilter_Tbl.Select("ID='" & tn.ToolTipText & "'")

        If drFilter.Length > 0 Then
            If Not tn.Checked Then tn.Checked = True
        Else
            tn.Checked = False
        End If

        For Each childNode As TreeNode In tn.Nodes
            Call Set_CurrentFilterNodesToChecked(childNode)
        Next
    End Sub

    Private Sub Set_UserUnitFilter()
        Try
            If M_UnitFilter_Tbl.Rows.Count > 0 Then M_UnitFilter_Tbl.Rows.Clear()

            Dim checked As List(Of TreeNode) = GetCheckedNodes(Tvw_Unit)
            For Each node As TreeNode In checked
                M_UnitFilter_Tbl.Rows.Add(node.ToolTipText)
            Next

        Catch ex As Exception
            LogErrorToLogFile(Me.Name & " - Set_NewFilter ", ex.Message)
        End Try
    End Sub

    Private Function GetCheckedNodes(ByVal TV As TreeView) As List(Of TreeNode)
        Dim checked As New List(Of TreeNode)
        For Each node As TreeNode In TV.Nodes
            GetCheckedNodes(node, checked)
        Next
        Return checked
    End Function

    Private Sub GetCheckedNodes(ByVal tn As TreeNode, ByVal checked As List(Of TreeNode))
        If tn.Checked Then
            checked.Add(tn)
        End If
        For Each childNode As TreeNode In tn.Nodes
            GetCheckedNodes(childNode, checked)
        Next
    End Sub

    Private Sub Rd_ExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_ExpandAll.CheckedChanged
        Tvw_Unit.ExpandAll()
    End Sub

    Private Sub Rd_CollapseAll_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_CollapseAll.CheckedChanged
        Tvw_Unit.CollapseAll()
    End Sub
End Class