Imports SMARTtBR_CO.CommonClass
Imports SMARTtBR_BL
Imports System.Windows.Forms

Public Class AccountFilter_Frm
    Dim M_CommonBL As New CommonBL
    Dim M_TreeGroup_Tbl As DataTable
    Dim ParentNode As TreeNode
    Dim Is_SetCurrentFilter As Boolean = False

    Public M_Filter_Tbl As New DataTable("Table")
    Public M_OK As Boolean = False

    Private Sub AccHeadFilter_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyChar = Chr(27) Then
            M_OK = False
            Me.Hide()
        End If
    End Sub

    Private Sub Cmd_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Ok.Click
        Call Set_NewFilter()
        M_OK = True
        Me.Hide()
    End Sub

    Public Sub Fill_AccountTreeView()
        Dim I As Integer
        Is_SetCurrentFilter = True
        Try
            Tvw_Accounts.Nodes.Clear()
            M_TreeGroup_Tbl = M_AccountMasterTreeList

            For I = 0 To M_TreeGroup_Tbl.Rows.Count - 1
                Dim sKey As String = M_TreeGroup_Tbl.Rows(I).Item("Key").ToString
                M_TreeGroup_Tbl.Rows(I).Item("Level") = FindLevel(M_TreeGroup_Tbl, sKey, 0)
            Next

            If M_TreeGroup_Tbl.Rows.Count > 0 Then
                Call Fill_TreeView(M_TreeGroup_Tbl, Tvw_Accounts)
                Tvw_Accounts.ExpandAll()
            End If

            Is_SetCurrentFilter = False
        Catch ex As Exception
            Is_SetCurrentFilter = False
            LogErrorToLogFile(Me.Name & " - Fill_AccHeadTreeView ", ex.Message)
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
                        ParentNode.Checked = True
                    Else
                        Dim TreeNodes() As TreeNode = Tvw_Tree.Nodes.Find(sParent, True)

                        If TreeNodes.Length > 0 Then
                            ChildNode = TreeNodes(0).Nodes.Add(sID, sName)
                            ChildNode.ToolTipText = iCode
                            ChildNode.Tag = sType
                            ChildNode.Checked = True
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

    Private Sub Tvw_AccHead_KeyDown(sender As Object, e As KeyEventArgs) Handles Tvw_Accounts.KeyDown
        If e.KeyCode = Keys.F5 Then
            Call Fill_AccountTreeView()
        End If
    End Sub

    Private Sub Tvw_AccHead_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles Tvw_Accounts.AfterCheck
        If Is_SetCurrentFilter Then Exit Sub

        RemoveHandler Tvw_Accounts.AfterCheck, AddressOf Tvw_AccHead_AfterCheck

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

        AddHandler Tvw_Accounts.AfterCheck, AddressOf Tvw_AccHead_AfterCheck
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

    Public Sub Set_CurrentFilter(ByVal M_AccHeadFilter_Tbl As DataTable)
        Is_SetCurrentFilter = True
        Try
            M_Filter_Tbl = M_AccHeadFilter_Tbl
            If M_Filter_Tbl.Rows.Count > 0 Then
                For Each node As TreeNode In Tvw_Accounts.Nodes
                    Call Set_CurrentFilterNodesToChecked(node)
                Next
            End If
            Is_SetCurrentFilter = False
        Catch ex As Exception
            Is_SetCurrentFilter = False
            LogErrorToLogFile(Me.Name & " - Set_CurrentFilter ", ex.Message)
        End Try
    End Sub

    Private Sub Set_CurrentFilterNodesToChecked(ByVal tn As TreeNode)

        Dim drFilter() As DataRow = M_Filter_Tbl.Select("ID='" & tn.ToolTipText & "'")

        If drFilter.Length > 0 Then
            If Not tn.Checked Then tn.Checked = True
        Else
            tn.Checked = False
        End If

        For Each childNode As TreeNode In tn.Nodes
            Call Set_CurrentFilterNodesToChecked(childNode)
        Next
    End Sub

    Private Sub Set_NewFilter()
        Try
            If M_Filter_Tbl.Rows.Count > 0 Then M_Filter_Tbl.Rows.Clear()

            Dim checked As List(Of TreeNode) = GetCheckedNodes(Tvw_Accounts)
            For Each node As TreeNode In checked
                M_Filter_Tbl.Rows.Add(node.ToolTipText)
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
        Tvw_Accounts.ExpandAll()
    End Sub

    Private Sub Rd_CollapseAll_CheckedChanged(sender As Object, e As EventArgs) Handles Rd_CollapseAll.CheckedChanged
        Tvw_Accounts.CollapseAll()
    End Sub
End Class