Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports SMARTtBR_BO
Imports SMARTtBR_BL
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Module CrystalReport_Mdl
    Dim Frm As ReportViewerFrm

    Public Sub DisplayCrystalReport(ByVal DataSource As Object, ByVal M_MenuID As Integer, Optional ByRef ShowModal As Boolean = False, Optional ByRef SetPrinter As Boolean = True)
        Dim Prn_Setting As New PrinterSettings
        Dim RptName As String = ""
        Dim SubRptName As String = ""
        Dim ParamFieldDefs As String = ""
        Dim ReportHeading As String = ""
        Dim NoOfCopies As Integer = 1

        Dim M_Dr() As DataRow

        Dim StrFlf(500) As String
        Dim StrSubFlf(500) As String
        Dim I As Integer
        Dim N, M As Integer
        Dim ObjReport As New ReportDocument
        Dim ObjSubReport As New ReportDocument

        If DataSource Is Nothing Then Exit Sub

        Try
            If DataSource.Tables(0).Rows.Count > 0 Then
                M_Dr = DataSource.Tables(0).Select("SlNO=1")
                If UBound(M_Dr) >= 0 Then
                    RptName = M_Dr(0)("RptName").ToString
                    SubRptName = M_Dr(0)("SubRptName").ToString
                    ParamFieldDefs = M_Dr(0)("ParamFieldDefs").ToString
                    ReportHeading = M_Dr(0)("ReportHeading").ToString
                    NoOfCopies = Val(M_Dr(0)("NoOfCopies").ToString)
                End If
                If RptName = "NotSet" Then Exit Sub
                RptName = Report_Path & RptName

                ObjReport.Load(RptName, OpenReportMethod.OpenReportByDefault)

                If SetPrinter Then
                    Dim PrDialog As New PrintDialog
                    For Each Printer In PrinterSettings.InstalledPrinters
                        Prn_Setting.PrinterName = Printer
                        If Prn_Setting.IsDefaultPrinter = True Then Exit For
                    Next

                    ObjReport.PrintOptions.PrinterName = Prn_Setting.PrinterName
                    PrDialog.PrinterSettings.PrinterName = Prn_Setting.PrinterName
                    ObjReport.PrintOptions.PaperSize = CType(PrDialog.PrinterSettings.DefaultPageSettings.PaperSize.RawKind, CrystalDecisions.Shared.PaperSize)
                    ObjReport.PrintOptions.PaperOrientation = IIf(PrDialog.PrinterSettings.DefaultPageSettings.Landscape = True, PaperOrientation.Landscape, PaperOrientation.Portrait)
                End If

                If Not DataSource Is Nothing Then
                    ObjReport.SetDataSource(DataSource.Tables(2))
                End If

                If ParamFieldDefs <> "" Then
                    StrFlf = Split(ParamFieldDefs, "|")
                    N = StrFlf.Length
                    For I = 0 To N - 1 Step 2
                        If ObjReport.DataDefinition.FormulaFields(StrFlf(I)).FormulaName <> StrFlf(I + 1) Then
                            ObjReport.DataDefinition.FormulaFields(StrFlf(I)).Text = "'" + StrFlf(I + 1) + "'"
                            If I > N - 1 Then
                                Exit For
                            End If
                        End If
                    Next
                End If

                If SubRptName <> "" Then
                    StrSubFlf = Split(SubRptName, "|")
                    M = StrSubFlf.Length
                    If M > 0 Then
                        For I = 0 To M - 1
                            ObjSubReport = ObjReport.OpenSubreport(StrSubFlf(I))
                            ObjSubReport.SetDataSource(DataSource.Tables(I + 3))
                        Next
                    End If
                End If

                Frm = New ReportViewerFrm

                If CheckUserRight("PRINT", User_ID, M_MenuID) = True Then
                    Frm.CrystalReportViewer1.ShowPrintButton = True
                    Frm.CrystalReportViewer1.ShowExportButton = True
                Else
                    Frm.CrystalReportViewer1.ShowPrintButton = False
                    Frm.CrystalReportViewer1.ShowExportButton = False
                End If

                Frm.Head = ReportHeading
                Frm.Rpt = RptName
                Frm.CrystalReportViewer1.ReportSource = ObjReport
                Frm.CrystalReportViewer1.Refresh()
                Frm.Text = ReportHeading
                If ShowModal Then
                    Frm.ShowDialog()
                Else
                    Frm.Show()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub PrintContinuous(ByVal DataSource As Object, ByVal M_UserID As Integer, ByVal M_MenuID As Integer, Optional ByVal PrintNeed As Boolean = True)
        Dim RptName As String = ""
        Dim SubRptName As String = ""
        Dim ParamFieldDefs As String = ""
        Dim ReportHeading As String = ""
        Dim NoOfCopies As Integer = 1

        Dim M_Dr() As DataRow
        Dim StrFlf(15) As String
        Dim StrSubFlf(10) As String
        Dim i As Integer
        Dim N, M As Integer
        Dim ObjReport As New ReportDocument
        Dim ObjSubReport As New ReportDocument

        If DataSource Is Nothing Then Exit Sub

        If PrintNeed = True Then
            If CheckUserRight("PRINT", M_UserID, M_MenuID) = False Then
                MsgBox("You don't have permission....!!!!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        End If
        Try

            If DataSource.Tables(0).Rows.Count > 0 Then
                M_Dr = DataSource.Tables(0).Select("SlNO=1")
                If UBound(M_Dr) >= 0 Then
                    RptName = M_Dr(0)("RptName").ToString
                    SubRptName = M_Dr(0)("SubRptName").ToString
                    ParamFieldDefs = M_Dr(0)("ParamFieldDefs").ToString
                    ReportHeading = M_Dr(0)("ReportHeading").ToString
                    NoOfCopies = Val(M_Dr(0)("NoOfCopies").ToString)
                End If
                If RptName = "NotSet" Then Exit Sub
                RptName = Report_Path & RptName

                ObjReport.Load(RptName)

                ObjReport.SetDataSource(DataSource.Tables(2))

                If ParamFieldDefs <> "" Then
                    StrFlf = Split(ParamFieldDefs, "|")
                    N = StrFlf.Length
                    For i = 0 To N - 1 Step 2
                        If ObjReport.DataDefinition.FormulaFields(StrFlf(i)).FormulaName <> StrFlf(i + 1) Then
                            ObjReport.DataDefinition.FormulaFields(StrFlf(i)).Text = "'" + StrFlf(i + 1) + "'"
                            If i > N - 1 Then
                                Exit For
                            End If
                        End If
                    Next
                End If

                StrSubFlf = Split(SubRptName, "|")
                M = StrSubFlf.Length
                If M > 1 Then
                    For i = 0 To M - 1
                        ObjSubReport = ObjReport.OpenSubreport(StrSubFlf(i))
                        ObjSubReport.SetDataSource(DataSource.Tables(i + 3))
                    Next
                End If


                ObjReport.PrintOptions.ApplyPageMargins(New CrystalDecisions.Shared.PageMargins(0, 0, 0, 150))

                If PrintNeed Then ObjReport.PrintToPrinter(NoOfCopies, False, 1, 500)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Module
