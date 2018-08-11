Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class Designation_Frm

    Dim M_DesID As Long

    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_DesignationBL As New DesignationBL

    Private Sub Clear_Controls()
        Try
            Txt_DesID.Text = ""
            Txt_DesName.Text = ""
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
            Call M_DesignationBL.Fill_Grid(Dgd_Designation)
            Call Set_Grid()

            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Set_Grid()
        Dim Col As Integer
        Dim DgCol As DataGridViewColumn

        For Col = 0 To Dgd_Designation.Columns.Count - 1
            DgCol = Dgd_Designation.Columns(Col)
            If DgCol.ValueType Is GetType(Double) Then
                DgCol.DefaultCellStyle.Format = "n2"
                DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ElseIf DgCol.ValueType Is GetType(Date) Then
                If UCase(DgCol.Name.ToString).Contains("TIME") Then
                    DgCol.DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss"
                Else
                    DgCol.DefaultCellStyle.Format = "dd/MM/yyyy"
                End If
            End If
        Next
        Dgd_Designation.Refresh()

    End Sub

    Public Function ValidateControls() As Boolean

        Dim sMsg As String

        Try

            If Trim(Txt_DesName.Text) = "" Then
                Txt_DesName.Focus()
                Txt_DesName.SelectAll()
                sMsg = "Designation Name could not be blank !"
                GoTo Invalid
            End If

            If M_DesignationBL.Check_DesignationNameExists(Txt_DesName.Text.Trim, M_DesID) Then
                sMsg = "Designation name is duplicated ! " & vbNewLine & "Please correct this before saving."
                Txt_DesName.Focus()
                Txt_DesName.SelectAll()
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

    Private Sub Designation_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub Designation_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub Designation_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Call Fill_Details()
            Call Clear_Controls()
            Txt_DesID.Focus()
            Me.ActiveControl = Txt_DesID
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Dim M_Designation As New SMARTtBR_BO.DesignationBO

        If ValidateControls() = False Then Exit Sub
        Cmd_Save.Enabled = False  ''Disable Save Button
        With M_Designation
            .DesID = Val(Txt_DesID.Text)
            .MakerID = User_ID
            If M_EntryMode = "VIEW" Then
                .UpdaterID = User_ID
            Else
                .UpdaterID = 0
            End If
            .DesName = Txt_DesName.Text.ToString
            .ActiveStatus = Cmb_ActveStatus.SelectedValue
        End With

        Try
            Dim M_DesignationBL As New DesignationBL
            M_DesID = M_DesignationBL.Save_Data(M_Designation, M_EntryMode, Me.Tag)
            If M_DesID > 0 Then
                MessageBox.Show("Data Saved... DesID : " & M_DesID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call Fill_Details()
                Call Clear_Controls()
                Me.ActiveControl = Txt_DesID
            Else
                Cmd_Save.Enabled = True  ''Enable Save Button
            End If
            M_DesignationBL = Nothing
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
        End Try
    End Sub

    Private Sub Locate_Data(ByVal M_Designation As SMARTtBR_BO.DesignationBO)

        If M_Designation.DesID = 0 Then
            M_EntryMode = "NEW"
            Call Clear_Controls()
            Exit Sub
        End If
        With M_Designation

            Txt_DesID.Text = .DesID
            Txt_DesName.Text = .DesName
            Cmb_ActveStatus.SelectedValue = .ActiveStatus

        End With
        M_EntryMode = "VIEW"
    End Sub

    Private Sub Txt_DesID_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_DesID.KeyDown
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 3, 1, Txt_DesID, SMARTtBR_MDI.Enm_SearchProperty.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Txt_DesID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_DesID.Validating
        If Txt_DesID.Text.Length = 0 Then
            Call Clear_Controls()
            M_EntryMode = "NEW"
        Else
            Try
                Dim M_Designation As New SMARTtBR_BO.DesignationBO
                Dim M_DesignationBL As New DesignationBL
                M_Designation = M_DesignationBL.Locate_Data(Txt_DesID.Text)
                Call Locate_Data(M_Designation)
                M_DesignationBL = Nothing
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Dgd_Designation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgd_Designation.CellDoubleClick
        Try
            If Dgd_Designation.SelectedRows.Count > 0 Then
                Txt_DesID.Text = Dgd_Designation.Item(0, Dgd_Designation.CurrentRow.Index).Value
                Me.ActiveControl = Txt_DesID
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
            Me.ActiveControl = Txt_DesID
            M_EntryMode = "NEW"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
