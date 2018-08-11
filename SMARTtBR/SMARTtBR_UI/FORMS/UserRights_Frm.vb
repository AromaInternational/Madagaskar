Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class UserRights_Frm

    Dim M_UserID As Long

    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_UserRightsBL As New UserRightsBL
    Dim M_RightTbl As DataTable

    Private Sub Fill_Details()
        Try
            Call Set_CursorType("W")

            Call M_CommonBL.Fill_User(Cmb_RefUser, 0, "Y", True, "S")
            If Cmb_RefUser.Items.Count > 0 Then Cmb_RefUser.SelectedValue = 0
            Call M_CommonBL.Fill_User(Cmb_User, 0, "Y")

            If Cmb_User.Items.Count > 0 Then
                Cmb_User.SelectedIndex = 0
                Txt_UserID.Text = Cmb_User.SelectedValue
                M_RightTbl = M_UserRightsBL.Fill_UserRightGrid(Cmb_User.SelectedValue, User_TypeID, User_ID)
                Call GridBind()
            Else
                M_RightTbl = M_UserRightsBL.Fill_UserRightGrid(0, User_TypeID, User_ID)
                Call GridBind()
            End If
            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GridBind()
        Dim Col As Integer
        Dim DgCol As DataGridViewColumn
        Try
            Call LogErrorToLogFile("User Rights Form", "GridBind")
            Dgv_Rights.DataSource = M_RightTbl
            Dgv_Rights.Columns(Col).Visible = True
            For Col = 0 To Dgv_Rights.Columns.Count - 1
                DgCol = Dgv_Rights.Columns(Col)
                If DgCol.Name = "MM_Caption" Then
                    DgCol.HeaderText = "Menu Name"
                    DgCol.Width = 200
                ElseIf DgCol.Name = "UR_View" Then
                    DgCol.HeaderText = "View"
                    DgCol.Width = 50

                ElseIf DgCol.Name = "UR_Add" Then
                    DgCol.HeaderText = "Add"
                    DgCol.Width = 50
                ElseIf DgCol.Name = "UR_Edit" Then
                    DgCol.HeaderText = "Edit"
                    DgCol.Width = 50
                ElseIf DgCol.Name = "UR_Delete" Then
                    DgCol.HeaderText = "Delete"
                    DgCol.Width = 50
                ElseIf DgCol.Name = "UR_Print" Then
                    DgCol.HeaderText = "Print"
                    DgCol.Width = 50
                ElseIf DgCol.Name = "UR_Authn" Then
                    DgCol.HeaderText = "Authorise"
                    DgCol.Width = 50
                Else
                    Dgv_Rights.Columns(Col).Visible = False
                End If
            Next

            Dgv_Rights.Refresh()
        Catch ex As Exception
            Call LogErrorToLogFile("User Form", "GridBind")
        End Try
    End Sub

    Private Sub Cmb_User_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_User.SelectedIndexChanged
        If Cmb_User.SelectedIndex >= 0 Then
            If Cmb_User.ValueMember.Length > 0 Then
                Txt_UserID.Text = Cmb_User.SelectedValue
                M_RightTbl = M_UserRightsBL.Fill_UserRightGrid(Cmb_User.SelectedValue, User_TypeID, User_ID)
                Call GridBind()
            End If
        End If
    End Sub

    Private Sub UserRights_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub UserRights_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub UserRights_Frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            M_EntryMode = "NEW"
            Call Fill_Details()
            Me.ActiveControl = Cmb_User
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Dgv_Rights_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv_Rights.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim MenuId As Double = Val(Dgv_Rights.Item(0, e.RowIndex).Value)
        Dim MainMenuId As Double = Val(Dgv_Rights.Item(1, e.RowIndex).Value)
        Dim SubMenuId As Double = Val(Dgv_Rights.Item(2, e.RowIndex).Value)
        Dim SubChildMenuId As Double = Val(Dgv_Rights.Item(3, e.RowIndex).Value)

        If e.ColumnIndex <= 4 Then Exit Sub

        Dim Dr() As DataRow

        If SubMenuId > 0 And SubChildMenuId > 0 Then
            Dr = M_RightTbl.Select("MM_ID=" & MenuId)
        ElseIf SubMenuId > 0 And SubChildMenuId = 0 Then
            Dr = M_RightTbl.Select("MM_MainID=" & MainMenuId & " AND MM_SubID=" & SubMenuId)
        Else
            Dr = M_RightTbl.Select("MM_MainID=" & MainMenuId)
        End If

        If Dgv_Rights.Item(e.ColumnIndex, e.RowIndex).Value = "Y" Then
            For I = 0 To UBound(Dr)
                Dr(I)(e.ColumnIndex) = "N"
            Next
        Else
            For I = 0 To UBound(Dr)
                Dr(I)(e.ColumnIndex) = "Y"
            Next
        End If

        GridBind()

        Dgv_Rights.CurrentCell = Dgv_Rights(e.ColumnIndex, e.RowIndex)
    End Sub

    Private Sub Dgv_Rights_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Dgv_Rights.CellFormatting
        Dim drv As DataRowView
        If e.RowIndex >= 0 Then
            If e.RowIndex <= M_RightTbl.Rows.Count - 1 Then
                drv = M_RightTbl.DefaultView.Item(e.RowIndex)
                Dim Backcolor As Color
                Dim Forecolor As Color
                If drv.Item("MM_SubID").ToString = "0" Then ' Heading
                    Backcolor = Color.DarkBlue
                    Forecolor = Color.White
                ElseIf drv.Item("HasChild").ToString = "Y" Then ' Has Child
                    Backcolor = Color.Pink
                    Forecolor = Color.Red
                ElseIf Val(drv.Item("MM_SubChildID").ToString) > 0 Then ' Sub Child
                    Backcolor = Color.Pink
                    Forecolor = Color.Black
                Else
                    Backcolor = Color.SkyBlue
                    Forecolor = Color.Black
                End If
                e.CellStyle.BackColor = Backcolor
                e.CellStyle.ForeColor = Forecolor
            End If
        End If
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click
        Dim M_UserRights As New SMARTtBR_BO.UserRightsBO
        Dim UserID As Integer

        Dim M_UserRightsBL As New UserRightsBL
        Dim M_RightsSw As New IO.StringWriter
        M_RightTbl.WriteXml(M_RightsSw)

        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_UserRights
            .UserID = Cmb_User.SelectedValue
            .MakerID = User_ID
        End With

        UserID = M_UserRightsBL.Save_Data(M_UserRights, M_RightsSw.ToString.Replace("DocumentElement", "NewDataSet"), M_EntryMode, Me.Tag)

        If UserID > 0 Then
            MessageBox.Show("Data Saved...  ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cmd_Save.Enabled = True  ''Enable Save Button
    End Sub

    Private Sub Cmb_RefUser_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_RefUser.SelectedIndexChanged
        If Cmb_RefUser.SelectedIndex >= 0 Then
            If Cmb_RefUser.ValueMember.Length > 0 Then
                M_RightTbl = M_UserRightsBL.Fill_UserRightGrid(Cmb_RefUser.SelectedValue, User_TypeID, User_ID)
                Call GridBind()
            End If
        End If
    End Sub

End Class