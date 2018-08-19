Imports SMARTtBR_DAL

Public Class Search_Frm
    Public M_SearchID As Integer
    Dim M_SearchTbl As DataTable
    Dim M_SearchVw As DataView
    Dim M_ParamTbl As DataTable
    Dim M_DBConn As Connection
    Dim M_Qry As String
    Dim M_Order As String
    Dim M_GridQry As String
    Dim M_GridHeading As String = ""
    Dim M_SearchDBFld As String = ""
    Dim M_SearchDBFldNO As Integer = 0
    Dim M_SearchGrdFld As String = ""
    Dim M_FixedFilter As String = ""
    Dim M_Filter As String = ""
    Dim M_FreezedFilter As String = ""
    Dim M_FreezedFilterDisplay As String = ""
    Public RtrnCol As Integer = 0 ' Return Column
    Public RtrnObject As Object ' Return Object
    Public RtrnObjectProperty As SMARTtBR_MDI.Enm_SearchProperty
    Dim M_OtherFilter As String = ""

    Public Sub SetSearch(ByVal SearchID As Integer, ByVal ReturnCol As Integer, ByRef ReturnObject As Object, ByVal ReturnObjectProperty As SMARTtBR_MDI.Enm_SearchProperty, Optional ByRef OtherFilter As String = "")
        RtrnCol = ReturnCol
        RtrnObject = ReturnObject
        RtrnObjectProperty = ReturnObjectProperty
        M_SearchID = SearchID
        M_OtherFilter = OtherFilter
    End Sub

    Private Sub Search_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim M_Sql As String
        M_DBConn = New Connection
        M_Sql = "Select * From Search_M_Tbl Where S_ID=" & M_SearchID
        M_DBConn.ExecuteDataTable(M_ParamTbl, M_Sql)

        If M_ParamTbl.Rows.Count > 0 Then
            M_Qry = M_ParamTbl.Rows(0)("S_Qry").ToString
            M_Order = M_ParamTbl.Rows(0)("S_Order").ToString
            If InStr(M_Qry, "Where", CompareMethod.Text) = False Then
                M_Qry = M_Qry & " Where 1=1 "
            End If

            If M_OtherFilter <> "" Then
                M_Qry = M_Qry & M_OtherFilter & " "
            End If

            If M_Order <> "" Then
                M_Qry = M_Qry & M_Order
            End If

            M_GridQry = M_Qry
            M_GridHeading = M_ParamTbl.Rows(0)("S_Heading").ToString
            Call Fill_Grid()
        End If

    End Sub

    Public Sub Fill_Grid()
        Dim Col As Integer
        Dim DgCol As DataGridViewColumn
        Try
            M_DBConn.ExecuteDataTable(M_SearchTbl, M_GridQry)
            DgvSearch.DataSource = M_SearchTbl
            M_SearchVw = M_SearchTbl.AsDataView

            For Col = 0 To DgvSearch.Columns.Count - 1
                DgCol = DgvSearch.Columns(Col)
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

            If M_SearchDBFld.Length = 0 Then
                M_SearchDBFld = M_SearchTbl.Columns.Item(0).Caption
            End If

            Call Refresh_Grid()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub Refresh_Grid()
        Try
            Dim Str() As String
            Dim I As Integer
            Dim DgCol As System.Windows.Forms.DataGridViewColumn

            DgvSearch.DataSource = M_SearchVw
            DgvSearch.Refresh()

            Str = Split(M_GridHeading, "|")

            For I = 0 To UBound(Str)
                DgCol = DgvSearch.Columns(I)
                DgCol.HeaderText = Str(I)
            Next

            Call Set_FilterDisplay()
        Catch ex As Exception : End Try
    End Sub

    Private Sub DgvSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgvSearch.KeyDown, Me.KeyDown, TxtFilter.KeyDown
        Try
            Dim SelectedRow As Integer
            If e.KeyCode = System.Windows.Forms.Keys.Down Then
                SelectedRow = DgvSearch.SelectedRows(0).Index
                If SelectedRow = DgvSearch.Rows.Count - 1 Then Exit Sub
                DgvSearch.ClearSelection()
                DgvSearch.Rows(SelectedRow + 1).Selected = True
            ElseIf e.KeyCode = System.Windows.Forms.Keys.Up Then
                SelectedRow = DgvSearch.SelectedRows(0).Index
                If SelectedRow = 0 Then Exit Sub
                DgvSearch.ClearSelection()
                DgvSearch.Rows(SelectedRow - 1).Selected = True
            ElseIf e.KeyCode = System.Windows.Forms.Keys.Right Then
                If M_SearchDBFldNO = DgvSearch.Columns.Count - 1 Then Exit Sub
                M_SearchDBFldNO = M_SearchDBFldNO + 1

                M_SearchDBFld = M_SearchTbl.Columns.Item(M_SearchDBFldNO).Caption
                M_SearchGrdFld = DgvSearch.Columns(M_SearchDBFldNO).HeaderText

            ElseIf e.KeyCode = System.Windows.Forms.Keys.Left Then
                If M_SearchDBFldNO = 0 Then Exit Sub
                M_SearchDBFldNO = M_SearchDBFldNO - 1

                M_SearchDBFld = M_SearchTbl.Columns.Item(M_SearchDBFldNO).Caption

                M_SearchGrdFld = DgvSearch.Columns(M_SearchDBFldNO).HeaderText
            ElseIf e.KeyValue = System.Windows.Forms.Keys.F2 Then
                If M_FreezedFilter = "" And M_Filter <> "" Then
                    M_FreezedFilterDisplay = DgvSearch.Columns(M_SearchDBFldNO).HeaderText & IIf(Rd_StartWith.Checked, " Like " & TxtFilter.Text & "%", IIf(Rd_Contains.Checked, " Like %" & TxtFilter.Text & "%", " Like %" & TxtFilter.Text))
                    TxtFilter.Text = ""
                    M_FreezedFilter = M_Filter
                Else
                    M_FreezedFilterDisplay = ""
                    M_FreezedFilter = ""
                End If
            ElseIf e.KeyValue = System.Windows.Forms.Keys.Enter Then
                Call SearchRetrun()
                Exit Sub
            ElseIf e.KeyValue = System.Windows.Forms.Keys.Escape Then
                Me.Dispose()
                Exit Sub
            End If

            Call Set_FilterDisplay()
            DgvSearch.CurrentCell = DgvSearch(M_SearchDBFldNO, DgvSearch.SelectedRows(0).Index)
        Catch ex As Exception : End Try
    End Sub

    Private Sub TxtFilter_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFilter.KeyUp
        Try : Call Set_Filter() : Catch ex As Exception : End Try
    End Sub

    Private Sub DgvSearch_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSearch.CellDoubleClick
        SearchRetrun()
    End Sub

    Public Sub SearchRetrun()
        Try
            Dim M_Dr As DataRow
            M_Dr = M_SearchVw.Item(DgvSearch.SelectedRows(0).Index).Row

            If RtrnObjectProperty = SMARTtBR_MDI.Enm_SearchProperty.Text Then
                RtrnObject.Text = M_Dr(RtrnCol).ToString
            ElseIf RtrnObjectProperty = SMARTtBR_MDI.Enm_SearchProperty.Tag Then
                RtrnObject.Tag = M_Dr(RtrnCol).ToString
            ElseIf RtrnObjectProperty = SMARTtBR_MDI.Enm_SearchProperty.SelectedValue Then
                RtrnObject.SelectedValue = M_Dr(RtrnCol).ToString
            End If

            Me.Dispose()
        Catch ex As Exception : End Try
    End Sub

    Private Sub DgvSearch_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvSearch.Enter, Me.Enter, Rd_Contains.Enter, Rd_EndWith.Enter, Rd_StartWith.Enter
        TxtFilter.Focus()
    End Sub

    Private Sub DgvSearch_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSearch.CellClick
        Dim SelectedRow As Integer
        Try
            SelectedRow = e.RowIndex
            If SelectedRow < 0 Then SelectedRow = 0

            DgvSearch.ClearSelection()
            DgvSearch.Rows(SelectedRow).Selected = True

            M_SearchDBFldNO = e.ColumnIndex

            M_SearchDBFld = M_SearchTbl.Columns.Item(M_SearchDBFldNO).Caption

            M_SearchGrdFld = DgvSearch.Columns(M_SearchDBFldNO).HeaderText

            Call Set_FilterDisplay()
        Catch ex As Exception : End Try
    End Sub

    Private Sub Set_Filter()
        Dim DataType As System.Type
        Try
            DataType = M_SearchTbl.Columns(M_SearchDBFldNO).DataType

            M_Filter = ""
            If TxtFilter.Text.Length = 0 Then GoTo ClearFilter

            Select Case DataType.Name
                Case "String"
                    M_Filter = "[" & M_SearchDBFld & "]" & IIf(Rd_StartWith.Checked, " Like '" & TxtFilter.Text & "%'", IIf(Rd_Contains.Checked, " Like '%" & TxtFilter.Text & "%'", " Like '%" & TxtFilter.Text & "'"))
                Case "Int16", "Int32", "Int64", "Integer", "Double", "Decimal"
                    M_Filter = "[" & M_SearchDBFld & "]" & " = " & TxtFilter.Text
            End Select
ClearFilter:

            If M_FreezedFilter = "" Then
                M_SearchVw.RowFilter = M_Filter
            Else
                If M_Filter <> "" Then
                    M_SearchVw.RowFilter = M_FreezedFilter & " And " & M_Filter
                Else
                    M_SearchVw.RowFilter = M_FreezedFilter
                End If
            End If

            Call Refresh_Grid()
        Catch ex As Exception : End Try
    End Sub

    Private Sub Set_FilterDisplay()
        Dim M_FilterDisplay As String = DgvSearch.Columns(M_SearchDBFldNO).HeaderText & IIf(Rd_StartWith.Checked, " Like " & TxtFilter.Text & "%", IIf(Rd_Contains.Checked, " Like %" & TxtFilter.Text & "%", " Like %" & TxtFilter.Text))

        If M_FreezedFilter = "" Then
            LblField.Text = M_FilterDisplay
        Else
            LblField.Text = M_FreezedFilterDisplay & " And " & M_FilterDisplay
        End If
    End Sub
End Class