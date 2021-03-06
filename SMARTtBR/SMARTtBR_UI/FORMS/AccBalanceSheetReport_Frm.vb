﻿Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL
Imports SMARTtBR_CO.CommonClass
Imports System.Windows.Forms
Public Class AccBalanceSheetReport_Frm
    Dim M_CommonBL As New CommonBL
    Dim M_ReportsBL As New ReportsBL
    Dim M_Report As New DataSet
    Dim M_UnitFilter_Tbl As New DataTable("Table")

    Private Sub Fill_Details()
        Try
            Call Set_CursorType("W")
            Call Fill_ReportName(Cmb_ReportType, 5)
            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Clear_Controls()
        Try
            M_UnitFilter_Tbl = Set_UnitFilterTable()

            Dtp_AsOnDate.Value = Tran_Date
        Catch ex As Exception

        End Try
    End Sub


    Public Function ValidateControls() As Boolean

        Dim sMsg As String = ""
        Try

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

    Private Sub Cmd_Clear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call Clear_Controls()
    End Sub

    Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click
        Me.Close()
    End Sub

    Private Sub AccBalanceSheetReport_Frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SMARTtBR_MDI.Set_DeleteFromMenuListTable(Me.Tag)
    End Sub

    Private Sub AccBalanceSheetReport_Frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        Call SendKeyTab(Me, Me.ActiveControl, e)

    End Sub
    Private Sub AccBalanceSheetReport_Frm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call Fill_Details()
            Call Clear_Controls()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmd_Show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Show.Click

        Try
            If Not ValidateControls() Then Exit Sub
            Call Set_CursorType("W")
            Dim M_UnitFilterSw As New IO.StringWriter
            M_UnitFilter_Tbl.WriteXml(M_UnitFilterSw)

            M_Report = M_ReportsBL.ProcRpt_AccBalanceSheetReport(Company_Code, Me.Tag, Val(Cmb_ReportType.SelectedValue), User_ID, M_UnitFilterSw.ToString.Replace("DocumentElement", "NewDataSet"), Dtp_AsOnDate.Value)
            If Not M_Report Is Nothing Then
                Call CrystalReport_Mdl.DisplayCrystalReport(M_Report, Me.Tag, False, False)
            End If
            Call Set_CursorType("N")
        Catch ex As Exception
            Call Set_CursorType("N")
            MessageBox.Show(ex.Message, "SMARTtBR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Cmd_UnitFilter_Click(sender As Object, e As EventArgs) Handles Cmd_UnitFilter.Click
        M_UnitFilter_Tbl = SMARTtBR_MDI.Show_UnitFilter(M_UnitFilter_Tbl)
    End Sub
End Class
