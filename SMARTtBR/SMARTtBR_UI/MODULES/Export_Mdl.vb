Imports System.Data
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports SMARTtBR_CO.CommonClass
Module Export_Mdl
    Public Function Is_ExcelExist() As Boolean
        Dim oExcel As Excel.Application
        Try
            oExcel = CreateObject("Excel.Application")
            oExcel.Quit()
            ReleaseObject(oExcel)
            oExcel = Nothing
            Return True
        Catch ex As Exception : Return False : End Try
    End Function

    Public Sub ExportDataTable(ByVal M_Dt As System.Data.DataTable, ByVal Branch As String, ByVal Heading As String, ByVal SheetName As String, ByVal FileName As String, Optional ByRef sDefaultHeadColumn As Integer = 3)
        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Dim bToExcel As Boolean = False
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        Try
            If f.ShowDialog() = DialogResult.OK Then
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")

                Dim sExportPath = f.SelectedPath + FileName
                If Is_ExcelExist() Then
                    Dim oExcel As Excel.Application
                    Dim oBook As Excel.Workbook
                    Dim oSheet As Excel.Worksheet
                    oExcel = CreateObject("Excel.Application")
                    oBook = oExcel.Workbooks.Add(Type.Missing)
                    oSheet = oBook.Worksheets(1)

                    rowIndex = rowIndex + 1
                    oSheet.Cells(rowIndex, sDefaultHeadColumn) = Company_Name
                    rowIndex = rowIndex + 1
                    oSheet.Cells(rowIndex, sDefaultHeadColumn) = Branch

                    If Heading <> "" Then
                        rowIndex = rowIndex + 1
                        oSheet.Cells(rowIndex, sDefaultHeadColumn) = Heading
                    End If

                    'Export the Columns to excel file
                    rowIndex = rowIndex + 1
                    For Each dc In M_Dt.Columns
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex, colIndex) = dc.ColumnName
                    Next

                    'Export the rows to excel file
                    For Each dr In M_Dt.Rows
                        rowIndex = rowIndex + 1
                        colIndex = 0
                        For Each dc In M_Dt.Columns
                            colIndex = colIndex + 1
                            oSheet.Cells(rowIndex, colIndex) = dr(dc.ColumnName)
                            oSheet.Name = SheetName
                        Next
                    Next

                    'txtPath.Text = finalPath
                    oSheet.Columns.AutoFit()
                    'Save file in final path
                    oBook.SaveAs(sExportPath, XlFileFormat.xlWorkbookNormal, Type.Missing, _
                    Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, _
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

                    'Release the objects
                    ReleaseObject(oSheet)
                    oBook.Close(False, Type.Missing, Type.Missing)
                    ReleaseObject(oBook)
                    oExcel.Quit()
                    ReleaseObject(oExcel)
                    'Some time Office application does not quit after automation: 
                    'so i am calling GC.Collect method.
                    GC.Collect()

                    Call DisplayExcelFile(sExportPath)
                Else
                    Dim writer As System.IO.StreamWriter
                    writer = New System.IO.StreamWriter(sExportPath)
                    ' first write a line with the columns name
                    Dim sep As String = ""
                    Do While sDefaultHeadColumn <> 1
                        sep = sep + ","
                        sDefaultHeadColumn = sDefaultHeadColumn - 1
                    Loop

                    Dim builder As New System.Text.StringBuilder

                    builder.Append(sep).Append(Company_Name)
                    writer.WriteLine(builder.ToString())

                    builder = New System.Text.StringBuilder
                    builder.Append(sep).Append(Branch)
                    writer.WriteLine(builder.ToString())

                    builder = New System.Text.StringBuilder
                    builder.Append(sep).Append(Heading)
                    writer.WriteLine(builder.ToString())

                    sep = ""
                    builder = New System.Text.StringBuilder
                    For Each col As DataColumn In M_Dt.Columns
                        builder.Append(sep).Append(col.ColumnName)
                        sep = ","
                    Next
                    writer.WriteLine(builder.ToString())

                    ' then write all the rows
                    For Each row As DataRow In M_Dt.Rows
                        sep = ""
                        builder = New System.Text.StringBuilder

                        For Each col As DataColumn In M_Dt.Columns
                            builder.Append(sep).Append(row(col.ColumnName))
                            sep = ","
                        Next
                        writer.WriteLine(builder.ToString())
                    Next
                    writer.Close()
                    ReleaseObject(writer)
                    Process.Start("explorer.exe", sExportPath)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Public Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Public Sub DisplayExcelFile(ByVal FileName As String)
        Dim xlsApp As Excel.Application = Nothing
        Dim xlsWorkBooks As Excel.Workbooks = Nothing
        Dim xlsWB As Excel.Workbook = Nothing
        Try

            xlsApp = New Excel.Application
            xlsApp.Visible = True
            xlsWorkBooks = xlsApp.Workbooks
            xlsWB = xlsWorkBooks.Open(FileName)
        Catch ex As Exception : End Try
    End Sub

    Public Function ExportTo_CSV(ByVal M_Dt As System.Data.DataTable, ByVal Cmp_Name As String, ByVal Branch As String, ByVal Heading As String, ByVal SheetName As String, ByVal FileName As String, Optional ByRef sExportToPath As String = "", Optional ByVal FileOpenRequired As Boolean = False, Optional ByRef sDefaultHeadColumn As Integer = 3) As Boolean
        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try

            If sExportToPath = "" Then
                If f.ShowDialog() = DialogResult.OK Then
                    sExportToPath = f.SelectedPath + FileName
                Else
                    Exit Function
                End If
            Else
                If System.IO.Directory.Exists(sExportToPath) Then
                    System.IO.Directory.Delete(sExportToPath, True)
                End If

                System.IO.Directory.CreateDirectory(sExportToPath)
                sExportToPath = sExportToPath + FileName
            End If

            Dim writer As System.IO.StreamWriter
            writer = New System.IO.StreamWriter(sExportToPath)
            ' first write a line with the columns name
            Dim sep As String = ""
            Do While sDefaultHeadColumn <> 1
                sep = sep + ","
                sDefaultHeadColumn = sDefaultHeadColumn - 1
            Loop

            Dim builder As New System.Text.StringBuilder

            If Cmp_Name <> "" Then
                builder.Append(sep).Append(Cmp_Name)
                writer.WriteLine(builder.ToString())
            End If

            If Branch <> "" Then
                builder = New System.Text.StringBuilder
                builder.Append(sep).Append(Branch)
                writer.WriteLine(builder.ToString())
            End If

            If Heading <> "" Then
                builder = New System.Text.StringBuilder
                builder.Append(sep).Append(Heading)
                writer.WriteLine(builder.ToString())
            End If

            sep = ""
            builder = New System.Text.StringBuilder
            For Each col As DataColumn In M_Dt.Columns
                builder.Append(sep).Append(col.ColumnName)
                sep = ","
            Next
            writer.WriteLine(builder.ToString())

            ' then write all the rows
            For Each row As DataRow In M_Dt.Rows
                sep = ""
                builder = New System.Text.StringBuilder

                For Each col As DataColumn In M_Dt.Columns
                    builder.Append(sep).Append(row(col.ColumnName))
                    sep = ","
                Next
                writer.WriteLine(builder.ToString())
            Next
            writer.Close()
            ReleaseObject(writer)

            If FileOpenRequired Then Process.Start("explorer.exe", sExportToPath)

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
            Return False
        End Try
    End Function

End Module
