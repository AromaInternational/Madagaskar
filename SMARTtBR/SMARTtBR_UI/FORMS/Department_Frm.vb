Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class Department_Frm

    Dim M_DepID As Long

    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_DepartmentBL As New DepartmentBL

    Private Sub Clear_Controls()
        Try
            Txt_DepID.Text = ""
            M_DepID = 0
            Txt_DepName.Text = ""
            M_EntryMode = "NEW"
            Cmd_Save.Enabled = True  ''Enable Save Button
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Fill_Details()
        Try
            Call Set_CursorType("W")

            Call Fill_ActiveStatus(Cmb_ActveStatus)
            Call M_DepartmentBL.Fill_Grid(Dgd_Department)

            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function ValidateControls() As Boolean

        Dim sMsg As String

        Try
            If Trim(Txt_DepName.Text) = "" Then
                Txt_DepName.Focus()
                Txt_DepName.SelectAll()
                sMsg = "Department Name could not be blank !"
                GoTo Invalid
            End If

            If M_DepartmentBL.Check_DepartmentNameExists(Txt_DepName.Text.Trim, M_DepID) Then
                sMsg = "Department name is duplicated ! " & vbNewLine & "Please correct this before saving."
                Txt_DepName.Focus()
                Txt_DepName.SelectAll()
                GoTo Invalid
            End If
            Return True
            Exit Function
Invalid:
            If sMsg <> "" Then MsgBox(sMsg, MsgBoxStyle.Critical, "Could not Save")
            Return False
            Exit Function
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub Department_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub Department_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub Department_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Call Fill_Details()
            Call Clear_Controls()
            Txt_DepID.Focus()
            Me.ActiveControl = Txt_DepID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Dim M_Department As New DepartmentBO

        If ValidateControls() = False Then Exit Sub
        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_Department
            .DepID = M_DepID
            .MakerID = User_ID
            .UpdaterID = IIf(M_EntryMode = "VIEW", User_ID, 0)
            .DepName = Txt_DepName.Text.ToString
            .ActiveStatus = Cmb_ActveStatus.SelectedValue
        End With

        Try
            Dim M_DepartmentBL As New DepartmentBL
            M_DepID = M_DepartmentBL.Save_Data(M_Department, M_EntryMode, Me.Tag)
            If M_DepID > 0 Then
                MessageBox.Show("Data Saved... ID : " & M_DepID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call Fill_Details()
                Call Clear_Controls()
                Me.ActiveControl = Txt_DepID
            Else
                Cmd_Save.Enabled = True  ''Enable Save Button
            End If
            M_DepartmentBL = Nothing
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
        End Try
    End Sub

    Private Sub Locate_Data(ByVal M_Department As SMARTtBR_BO.DepartmentBO)

        If M_Department.DepID = 0 Then
            M_EntryMode = "NEW"
            Call Clear_Controls()
            Exit Sub
        End If
        With M_Department

            M_DepID = .DepID
            Txt_DepID.Text = .DepID
            Txt_DepName.Text = .DepName
            Cmb_ActveStatus.SelectedValue = .ActiveStatus

        End With
        M_EntryMode = "VIEW"
    End Sub

    Private Sub Txt_DepID_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_DepID.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 2, 1, Txt_DepID, SMARTtBR_MDI.Enm_SearchProperty.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Txt_DepID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_DepID.Validating
        If Txt_DepID.Text.Length = 0 Then
            Call Clear_Controls()
            M_EntryMode = "NEW"
        Else
            Try
                Dim M_Department As New SMARTtBR_BO.DepartmentBO
                Dim M_DepartmentBL As New DepartmentBL
                M_Department = M_DepartmentBL.Locate_Data(Txt_DepID.Text)
                Call Locate_Data(M_Department)
                M_DepartmentBL = Nothing
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Dgd_Department_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgd_Department.CellDoubleClick
        Try
            If Dgd_Department.SelectedRows.Count > 0 Then
                Txt_DepID.Text = Dgd_Department.Item(0, Dgd_Department.CurrentRow.Index).Value
                Me.ActiveControl = Txt_DepID
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            Call Clear_Controls()
            Me.ActiveControl = Txt_DepID
            M_EntryMode = "NEW"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
