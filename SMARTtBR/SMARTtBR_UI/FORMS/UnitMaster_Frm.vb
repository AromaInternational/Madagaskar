Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class UnitMaster_Frm
    Dim M_EntryMode As String
    Public M_OK As Boolean = False
    Public M_ShowModal As Boolean = False

    Public M_UNID As Long = 0
    Dim iSelectRow As Integer = 0

    Dim M_CommonBL As New CommonBL
    Dim M_UnitMasterBL As New UnitMasterBL

    Public Sub Clear_Controls()
        Try
            M_EntryMode = "NEW"
            M_UNID = 0
            Cmd_Save.Enabled = True  ''Enable Save Button
            Txt_UNName.Text = ""
            Txt_UNID.Text = ""
            If Cmb_ActveStatus.Items.Count > 0 Then Cmb_ActveStatus.SelectedValue = "Y"
            If Cmb_Company.Items.Count > 0 Then Cmb_Company.SelectedValue = Company_Code

            Call Fill_SubDetailsGrid(Dgd_Logs, 5, Val(Me.Tag), M_UNID)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Fill_Details()
        Try
            Call Set_CursorType("W")

            Call Fill_ActiveStatus(Cmb_ActveStatus)
            Call M_CommonBL.Fill_Company(Cmb_Company)

            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function ValidateControls() As Boolean
        Dim sMsg As String
        Try
            If Txt_UNName.Text.Length = 0 Then
                sMsg = "Eneter Unit Name.... !"
                GoTo Invalid
            End If

            If M_EntryMode = "NEW" Then
                If M_UnitMasterBL.Check_UnitNameExists(Val(Cmb_Company.SelectedValue), Txt_UNName.Text.Trim, M_UNID) Then
                    sMsg = "Unit name is duplicated ! " & vbNewLine & "Please correct this before saving."
                    Txt_UNName.Focus()
                    Txt_UNName.SelectAll()
                    GoTo Invalid
                End If
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

    Private Sub UnitMaster_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub UnitMaster_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not M_ShowModal Then
                Call Fill_Details()
                Call Clear_Controls()
            End If
            Me.ActiveControl = Txt_UNName
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UnitMaster_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub Locate_Data(ByVal M_UnitMaster As SMARTtBR_BO.UnitMasterBO)
        If M_UnitMaster.UNID = 0 Then
            M_EntryMode = "NEW"
            Call Clear_Controls()
            Exit Sub
        End If
        With M_UnitMaster
            M_UNID = .UNID
            Txt_UNID.Text = .UNID
            Txt_UNName.Text = .UNName
            Cmb_Company.SelectedValue = .UNCmpCode
            Cmb_ActveStatus.SelectedValue = .ActiveStatus
        End With

        Call Fill_SubDetailsGrid(Dgd_Logs, 5, Val(Me.Tag), M_UNID)
        M_EntryMode = "VIEW"
    End Sub

    Private Sub Txt_UNID_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_UNID.KeyDown
        If M_ShowModal Then Exit Sub
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 1, 1, Txt_UNID, SMARTtBR_MDI.Enm_SearchProperty.Text, " AND UN_CmpCode = " & Company_Code)
                Call Locate_Units(Val(Txt_UNID.Text))
            End If
        Catch ex As Exception
        End Try
    End Sub


    Public Sub Locate_Units(ByVal M_ID As Long)
        If M_ID = 0 Then
            Call Clear_Controls()
            M_EntryMode = "NEW"
        Else
            Try
                Dim M_UnitMaster As New SMARTtBR_BO.UnitMasterBO
                M_UnitMaster = M_UnitMasterBL.Locate_Data(M_ID)
                Call Locate_Data(M_UnitMaster)
                Txt_UNName.Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Cmd_Save_Click(sender As Object, e As EventArgs) Handles Cmd_Save.Click
        Dim M_UnitMaster As New SMARTtBR_BO.UnitMasterBO

        If ValidateControls() = False Then Exit Sub
        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_UnitMaster
            .UNID = M_UNID
            .UNName = Txt_UNName.Text.Trim
            .UNCmpCode = Val(Cmb_Company.SelectedValue)
            .ActiveStatus = Cmb_ActveStatus.SelectedValue
            .MakerID = User_ID
            .UpdaterID = IIf(M_EntryMode = "NEW", 0, User_ID)
        End With

        Try
            M_UNID = M_UnitMasterBL.Save_Data(M_UnitMaster, M_EntryMode, Me.Tag)
            If M_UNID > 0 Then
                M_UserUnitsList = M_CommonBL.Fill_UserUnitsList(Company_Code, User_ID)
                MessageBox.Show("Data Saved... ID : " & M_UNID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If M_ShowModal Then
                    M_OK = True
                    Me.Hide()
                Else
                    Call Fill_Details()
                    Call Clear_Controls()
                    Me.ActiveControl = Txt_UNName
                End If
            Else
                Cmd_Save.Enabled = True  ''Enable Save Button
            End If
        Catch ex As Exception
            Cmd_Save.Enabled = True  ''Enable Save Button
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        Try
            Call Clear_Controls()
            Me.ActiveControl = Txt_UNName
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Txt_UNName_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_UNName.KeyDown
        If M_ShowModal Then Exit Sub
        Try
            If e.KeyCode = Keys.F3 Then
                SMARTtBR_MDI.Search(Me, 1, 1, Txt_UNID, SMARTtBR_MDI.Enm_SearchProperty.Text, " AND UN_CmpCode = " & Company_Code)
                Call Locate_Units(Val(Txt_UNID.Text))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Cmd_UnitSearch_Click(sender As Object, e As EventArgs) Handles Cmd_UnitSearch.Click
        If M_ShowModal Then Exit Sub
        Try
            SMARTtBR_MDI.Search(Me, 1, 1, Txt_UNID, SMARTtBR_MDI.Enm_SearchProperty.Text)
            Call Locate_Units(Val(Txt_UNID.Text))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Fill_SubDetailsGrid(ByVal Dgd_Grid As Object, ByVal M_SubType As Integer, ByVal M_ParrentType As Integer, ByVal M_ParrentID As Long)
        Dim Col As Integer
        Dim DgCol As DataGridViewColumn
        Try
            Call Set_CursorType("W")
            Dgd_Grid.DataSource = M_CommonBL.Fill_SubDetails(M_SubType, M_ParrentType, M_ParrentID, User_ID)
            Dgd_Grid.Columns(Col).Visible = True
            For Col = 0 To Dgd_Grid.Columns.Count - 1
                DgCol = Dgd_Grid.Columns(Col)
                If DgCol.ValueType Is GetType(System.Int64) Or DgCol.ValueType Is GetType(System.Int32) Or DgCol.ValueType Is GetType(System.Int16) Then
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                ElseIf DgCol.ValueType Is GetType(System.String) Then
                    DgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                ElseIf DgCol.ValueType Is GetType(Double) Or DgCol.ValueType Is GetType(System.Decimal) Then
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

            Dgd_Grid.Refresh()

            If Dgd_Grid.SelectedRows.Count > 0 And iSelectRow > 0 Then
                Dgd_Grid.CurrentCell = Dgd_Grid(Dgd_Grid.DataSource.Columns("ID").Ordinal, iSelectRow)
            End If

            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
        End Try
    End Sub

    Private Sub Cmd_Close_Click(sender As Object, e As EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

End Class