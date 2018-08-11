Imports System.IO
Imports System.String
Imports System.Net
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Excel
Module Import_Mdl
    ''Public Function Proc_ExcelImport(ByVal strFolderPath As String, ByVal strFileName As String) As DataSet
    ''    Try
    ''        'CharacterSet=65001 will needed for UTF-8 settings
    ''        Dim strConnString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFolderPath & ";Extended Properties='text;HDR=Yes;FMT=Delimited;CharacterSet=65001;'"
    ''        Dim conn As New OleDbConnection(strConnString)
    ''        Try
    ''            conn.Open()
    ''            Dim cmd As New OleDbCommand("SELECT * FROM [" & strFileName & "]", conn)
    ''            Dim da As New OleDbDataAdapter()

    ''            da.SelectCommand = cmd
    ''            Dim ds As New DataSet()

    ''            da.Fill(ds)
    ''            da.Dispose()
    ''            Return ds
    ''        Catch ex As Exception
    ''            MessageBox.Show(ex.Message)
    ''            Return Nothing
    ''        Finally
    ''            conn.Close()
    ''        End Try
    ''    Catch ex As Exception
    ''    End Try
    ''End Function

    Public Function Proc_ExcelImport(ByVal strFileName As String, Optional ByVal M_FirstRowAsColumnName As Boolean = True) As System.Data.DataTable
        Try
            ' Create new Application.
            Dim M_DataTable As New System.Data.DataTable("Table")
            Dim Column As DataColumn
            Dim Row As DataRow
            Dim oExcel As Application = New Application
            Dim sValue As String = ""
            ' Open Excel spreadsheet.
            Dim oBook As Workbook = oExcel.Workbooks.Open(strFileName)

            ' Loop over all sheets.
            'For i As Integer = 1 To w.Sheets.Count

            ' Get sheet.
            Dim oSheet As Worksheet = oBook.Sheets(1)

            ' Get range.
            Dim r As Range = oSheet.UsedRange

            ' Load all cells into 2d array.
            Dim array(,) As Object = r.Value(XlRangeValueDataType.xlRangeValueDefault)

            ' Scan the cells.
            If array IsNot Nothing Then
                ' Get bounds of the array.
                Dim iRows As Integer = array.GetUpperBound(0)
                Dim iColoums As Integer = array.GetUpperBound(1)

                If M_FirstRowAsColumnName = False Then
                    For iC = 1 To iColoums
                        Column = New DataColumn()
                        Column.DataType = System.Type.GetType("System.String")
                        Column.ColumnName = "Column" & iC
                        Column.Caption = "Column" & iC
                        Column.ReadOnly = True
                        Column.Unique = False
                        M_DataTable.Columns.Add(Column)
                    Next

                    ' Loop over all elements.
                    For iR As Integer = 1 To iRows
                        Row = M_DataTable.NewRow
                        For iC As Integer = 1 To iColoums
                            sValue = array(iR, iC)
                            Row(iC - 1) = sValue
                        Next
                        M_DataTable.Rows.Add(Row)
                    Next
                Else
                    For iC As Integer = 1 To iColoums
                        sValue = array(1, iC)
                        Column = New DataColumn()
                        Column.DataType = System.Type.GetType("System.String")
                        Column.ColumnName = sValue
                        Column.Caption = sValue
                        Column.ReadOnly = True
                        Column.Unique = False
                        M_DataTable.Columns.Add(Column)
                    Next

                    ' Loop 2 row onwards.
                    For iR As Integer = 2 To iRows
                        Row = M_DataTable.NewRow
                        For iC As Integer = 1 To iColoums
                            sValue = array(iR, iC)
                            Row(iC - 1) = sValue
                        Next
                        M_DataTable.Rows.Add(Row)
                    Next
                End If
            End If
            'Next

            Call ReleaseObject(oSheet)
            Call oBook.Close(False, Type.Missing, Type.Missing)
            Call ReleaseObject(oBook)
            Call oExcel.Quit()
            Call ReleaseObject(oExcel)
            Call GC.Collect()

            Return M_DataTable
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
            Return Nothing
        End Try
    End Function

    Public Function ReadExcelIntoDataTable(ByVal FileName As String, ByVal SheetName As String) As DataTable
        Dim RetVal As New System.Data.DataTable

        Dim strConnString As String
        strConnString = "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" & FileName & ";"

        Dim strSQL As String
        strSQL = "SELECT * FROM [" & SheetName & "]"

        Dim y As New Odbc.OdbcDataAdapter(strSQL, strConnString)

        y.Fill(RetVal)

        Return RetVal

    End Function

    Public Function Proc_CSVImport(ByVal strFileName As String) As DataTable

        Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(strFileName)

        TextFileReader.TextFieldType = FileIO.FieldType.Delimited
        TextFileReader.SetDelimiters(",")

        Dim M_DataTable As DataTable = Nothing

        Dim Column As DataColumn
        Dim Row As DataRow
        Dim UpperBound As Int32
        Dim ColumnCount As Int32
        Dim CurrentRow As String()

        While Not TextFileReader.EndOfData
            Try
                CurrentRow = TextFileReader.ReadFields()
                If Not CurrentRow Is Nothing Then
                    ''# Check if DataTable has been created
                    If M_DataTable Is Nothing Then
                        M_DataTable = New System.Data.DataTable("Table")
                        ''# Get number of columns
                        UpperBound = CurrentRow.GetUpperBound(0)
                        ''# Create new DataTable
                        For ColumnCount = 0 To UpperBound
                            Column = New DataColumn()
                            Column.DataType = System.Type.GetType("System.String")
                            Column.ColumnName = "Column" & ColumnCount
                            Column.Caption = "Column" & ColumnCount
                            Column.ReadOnly = True
                            Column.Unique = False
                            M_DataTable.Columns.Add(Column)
                        Next
                    End If
                    Row = M_DataTable.NewRow
                    For ColumnCount = 0 To UpperBound
                        Row("Column" & ColumnCount) = CurrentRow(ColumnCount).ToString
                    Next
                    M_DataTable.Rows.Add(Row)
                End If
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
            End Try
        End While
        TextFileReader.Dispose()
        Return M_DataTable

    End Function

    Public Function Proc_ContactsImport(ByVal strFileName As String) As System.Data.DataTable
        Dim M_Extension As String
        Dim M_DataTable As New System.Data.DataTable("Table")
        Dim Column As DataColumn
        Dim Row As DataRow
        Dim UpperBound As Int32
        Dim CurrentRow As String()
        Dim sValue As String = ""

        UpperBound = 11
        For iC = 0 To UpperBound
            Column = New DataColumn()
            Select Case iC
                Case 0
                    Column.DataType = System.Type.GetType("System.Int32")
                    Column.ColumnName = "SLNO"
                Case 1
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "NAME"
                Case 2
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "MOBILE"
                Case 3
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "WORKTEL"
                Case 4
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "FAX"
                Case 5
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "EMAIL"
                Case 6
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "WEB"
                Case 7
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "COMPANY"
                Case 8
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "JOBTITLE"
                Case 9
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "ADDRESS"
                Case 10
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "SUBJECT"
                Case 11
                    Column.DataType = System.Type.GetType("System.String")
                    Column.ColumnName = "ACTIVITY"
            End Select
            Column.ReadOnly = True
            Column.Unique = False
            M_DataTable.Columns.Add(Column)
        Next

        M_Extension = Path.GetExtension(strFileName)
        If M_Extension.ToUpper = ".CSV" Then
            Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(strFileName)

            TextFileReader.TextFieldType = FileIO.FieldType.Delimited
            TextFileReader.SetDelimiters(",")
            CurrentRow = TextFileReader.ReadFields() ' read col headings

            While Not TextFileReader.EndOfData
                Try
                    CurrentRow = TextFileReader.ReadFields()
                    If Not CurrentRow Is Nothing Then
                        Row = M_DataTable.NewRow
                        For iC = 0 To UpperBound
                            sValue = CurrentRow(iC).ToString
                            If sValue Is Nothing Then
                                sValue = ""
                            Else
                                sValue = sValue.Replace("'", "`")
                            End If
                            Select Case iC
                                Case 0
                                    Row("SLNO") = sValue
                                Case 1
                                    Row("NAME") = sValue
                                Case 2
                                    Row("MOBILE") = sValue
                                Case 3
                                    Row("WORKTEL") = sValue
                                Case 4
                                    Row("FAX") = sValue
                                Case 5
                                    Row("EMAIL") = sValue
                                Case 6
                                    Row("WEB") = sValue
                                Case 7
                                    Row("COMPANY") = sValue
                                Case 8
                                    Row("JOBTITLE") = sValue
                                Case 9
                                    Row("ADDRESS") = sValue
                                Case 10
                                    Row("SUBJECT") = sValue
                                Case 11
                                    Row("ACTIVITY") = sValue
                            End Select
                        Next
                        M_DataTable.Rows.Add(Row)
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
            TextFileReader.Dispose()
        ElseIf M_Extension.ToUpper = ".XLS" Then
            Dim oExcel As Application = New Application
            Dim oBook As Workbook = oExcel.Workbooks.Open(strFileName) ' Open Excel spreadsheet.
            Dim oSheet As Worksheet = oBook.Sheets(1) ' Get sheet.
            Dim oRange As Range = oSheet.UsedRange ' Get range.
            Try
                Dim array(,) As Object = oRange.Value(XlRangeValueDataType.xlRangeValueDefault) ' Load all cells into 2d array.
                ' Scan the cells.
                If Array IsNot Nothing Then
                    ' Get bounds of the array.
                    Dim iRows As Integer = Array.GetUpperBound(0)
                    Dim iColoums As Integer = Array.GetUpperBound(1)

                    ' Loop 2 row onwards. 
                    For iR As Integer = 2 To iRows
                        Row = M_DataTable.NewRow
                        For iC As Integer = 1 To iColoums
                            Try
                                sValue = Array(iR, iC)
                                If sValue Is Nothing Then
                                    sValue = ""
                                Else
                                    sValue = sValue.Replace("'", "`")
                                End If
                                Select Case iC
                                    Case 1
                                        Row("SLNO") = sValue
                                    Case 2
                                        Row("NAME") = sValue
                                    Case 3
                                        Row("MOBILE") = sValue
                                    Case 4
                                        Row("WORKTEL") = sValue
                                    Case 5
                                        Row("FAX") = sValue
                                    Case 6
                                        Row("EMAIL") = sValue
                                    Case 7
                                        Row("WEB") = sValue
                                    Case 8
                                        Row("COMPANY") = sValue
                                    Case 9
                                        Row("JOBTITLE") = sValue
                                    Case 10
                                        Row("ADDRESS") = sValue
                                    Case 11
                                        Row("SUBJECT") = sValue
                                    Case 12
                                        Row("ACTIVITY") = sValue
                                End Select
                            Catch ex As Exception
                                MessageBox.Show(ex.Message & " (Row -" & iR & " Column -" & iC & ")", "Warning", MessageBoxButtons.OK)
                            End Try
                        Next
                        M_DataTable.Rows.Add(Row)
                    Next
                End If

                Call ReleaseObject(oSheet)
                Call oBook.Close(False, Type.Missing, Type.Missing)
                Call ReleaseObject(oBook)
                Call oExcel.Quit()
                Call ReleaseObject(oExcel)
                Call GC.Collect()
            Catch ex As Exception
                Call ReleaseObject(oSheet)
                Call oBook.Close(False, Type.Missing, Type.Missing)
                Call ReleaseObject(oBook)
                Call oExcel.Quit()
                Call ReleaseObject(oExcel)
                Call GC.Collect()
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
            End Try
        End If

        Return M_DataTable
    End Function

End Module