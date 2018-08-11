Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms

Public Class AccYearlyClosing_Frm

    Dim M_AYID As Long
    Dim M_CommonBL As New CommonBL
    Dim M_EntryMode As String
    Dim M_AccYearlyClosingBL As New AccYearlyClosingBL
    Dim M_DefaultFinYear As String = ""
    Dim M_FinOBDate As Date = Tran_Date
    Dim M_FinStartDate As Date = Tran_Date
    Dim M_FinEndDate As Date = Tran_Date
    Private Sub Clear_Controls()
        Try
            M_EntryMode = "NEW"
            Cmd_Save.Enabled = True  ''Enable Save Button
            Cmb_FinYear.SelectedValue = M_DefaultFinYear
            Cmb_TrUnit.SelectedValue = User_UnitID
        Catch ex As Exception : End Try
    End Sub


    Private Sub Fill_Details()
        Try
            Call Set_CursorType("W")
            Call M_CommonBL.Fill_FinYear(Cmb_FinYear, Company_Code, Tran_Date, M_DefaultFinYear, M_FinOBDate, M_FinStartDate)
            Call Fill_Unit(Cmb_TrUnit, "Y")
            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
        End Try
    End Sub

    Public Function ValidateControls() As Boolean

        Dim sMsg As String
        Try

            Dim M_AccYearlyClosing As New SMARTtBR_BO.AccYearlyClosingBO
            M_AccYearlyClosing = M_AccYearlyClosingBL.Locate_Data(Cmb_TrUnit.SelectedValue, Cmb_FinYear.Text)

            If M_AccYearlyClosing.AYID > 0 Then
                If MsgBox("Yearly closing already done for the year -" & Cmb_FinYear.Text & vbNewLine & " Do you want to continue..??", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "SMART BiZ") = MsgBoxResult.No Then
                    GoTo Invalid
                Else
                    M_EntryMode = "VIEW"
                    M_AYID = M_AccYearlyClosing.AYID
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


    Private Sub AccYearlyClosing_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub AccYearlyClosing_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call SendKeyTab(Me, Me.ActiveControl, e)
    End Sub

    Private Sub AccYearlyClosing_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Fill_Details()
            Call Clear_Controls()
            Me.ActiveControl = Cmb_FinYear
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click

        Dim M_AccYearlyClosing As New SMARTtBR_BO.AccYearlyClosingBO

        If ValidateControls() = False Then Exit Sub

        Cmd_Save.Enabled = False  ''Disable Save Button

        With M_AccYearlyClosing
            .UNID = Cmb_TrUnit.SelectedValue
            .MakerID = User_ID
            If M_EntryMode = "NEW" Then
                .UpdaterID = 0
            Else
                .UpdaterID = User_ID
            End If
            .AYDate = Tran_Date
            .AYID = M_AYID
            .AYFinYear = Cmb_FinYear.Text
            .ActiveStatus = "Y"
        End With

        Try
            Call Set_CursorType("W")

            M_AYID = M_AccYearlyClosingBL.Save_Data(M_AccYearlyClosing, M_EntryMode, Me.Tag)
            If M_AYID > 0 Then
                MessageBox.Show("Data Saved... ID : " & M_AYID, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call Clear_Controls()
            Else
                Cmd_Save.Enabled = True  ''Enable Save Button
            End If
            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            Cmd_Save.Enabled = True  ''Enable Save Button
        End Try
    End Sub


    Private Sub Cmb_FinYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_FinYear.SelectedIndexChanged
        If Cmb_FinYear.Items.Count = 0 Or Cmb_FinYear.ValueMember.Length = 0 Then Exit Sub
        Try
            Dim sBRows() As DataRow = Cmb_FinYear.DataSource.Select("Fin_ID = " & Cmb_FinYear.SelectedValue)
            For J = 0 To sBRows.Count - 1
                Dtp_AccOpDate.Value = sBRows(J).Item("Fin_EndDate").ToString
            Next
        Catch ex As Exception
            LogErrorToLogFile(Me.Name & " - Cmb_FinYear_SelectedIndexChanged ", ex.Message)
        End Try
    End Sub
End Class

