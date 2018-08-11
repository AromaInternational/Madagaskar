Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class ReportsDA
    Private M_DBConn As Connection

    Public Function ProcRpt_AccDayBookReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try
            Dim M_DataSet As New DataSet
            Dim M_Sql As String

            M_Sql = "Exec ProcRpt_AccDayBookReport_Sp "
            M_Sql = M_Sql & M_CmpCode & ","
            M_Sql = M_Sql & M_MenuID & ","
            M_Sql = M_Sql & M_RptID & ","
            M_Sql = M_Sql & M_UserID & ","
            M_Sql = M_Sql & "'" & M_UnitList & "',"
            M_Sql = M_Sql & "'" & Format(M_FromDate, "MM/dd/yyyy") & "',"
            M_Sql = M_Sql & "'" & Format(M_ToDate, "MM/dd/yyyy") & "'"

            M_DBConn.ExecuteDataSet(M_DataSet, M_Sql)
            Return M_DataSet

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ProcRpt_AccLedgerReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_AccHeadList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try
            Dim M_DataSet As New DataSet
            Dim M_Sql As String

            M_Sql = "Exec ProcRpt_AccLedgerReport_Sp "
            M_Sql = M_Sql & M_CmpCode & ","
            M_Sql = M_Sql & M_MenuID & ","
            M_Sql = M_Sql & M_RptID & ","
            M_Sql = M_Sql & M_UserID & ","
            M_Sql = M_Sql & "'" & M_UnitList & "',"
            M_Sql = M_Sql & "'" & M_AccHeadList & "',"
            M_Sql = M_Sql & "'" & Format(M_FromDate, "MM/dd/yyyy") & "',"
            M_Sql = M_Sql & "'" & Format(M_ToDate, "MM/dd/yyyy") & "'"
            M_DBConn.ExecuteDataSet(M_DataSet, M_Sql)
            Return M_DataSet

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ProcRpt_AccRandDReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_AccHeadList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try
            Dim M_DataSet As New DataSet
            Dim M_Sql As String

            M_Sql = "Exec ProcRpt_AccRandDReport_Sp "
            M_Sql = M_Sql & M_CmpCode & ","
            M_Sql = M_Sql & M_MenuID & ","
            M_Sql = M_Sql & M_RptID & ","
            M_Sql = M_Sql & M_UserID & ","
            M_Sql = M_Sql & "'" & M_UnitList & "',"
            M_Sql = M_Sql & "'" & M_AccHeadList & "',"
            M_Sql = M_Sql & "'" & Format(M_FromDate, "MM/dd/yyyy") & "',"
            M_Sql = M_Sql & "'" & Format(M_ToDate, "MM/dd/yyyy") & "'"

            M_DBConn.ExecuteDataSet(M_DataSet, M_Sql)
            Return M_DataSet

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ProcRpt_AccTrialBalanceReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try
            Dim M_DataSet As New DataSet
            Dim M_Sql As String

            M_Sql = "Exec ProcRpt_AccTrialBalanceReport_Sp "
            M_Sql = M_Sql & M_CmpCode & ","
            M_Sql = M_Sql & M_MenuID & ","
            M_Sql = M_Sql & M_RptID & ","
            M_Sql = M_Sql & M_UserID & ","
            M_Sql = M_Sql & "'" & M_UnitList & "',"
            M_Sql = M_Sql & "'" & Format(M_FromDate, "MM/dd/yyyy") & "',"
            M_Sql = M_Sql & "'" & Format(M_ToDate, "MM/dd/yyyy") & "'"

            M_DBConn.ExecuteDataSet(M_DataSet, M_Sql)
            Return M_DataSet

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ProcRpt_AccPandLReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try
            Dim M_DataSet As New DataSet
            Dim M_Sql As String

            M_Sql = "Exec ProcRpt_AccPandLReport_Sp "
            M_Sql = M_Sql & M_CmpCode & ","
            M_Sql = M_Sql & M_MenuID & ","
            M_Sql = M_Sql & M_RptID & ","
            M_Sql = M_Sql & M_UserID & ","
            M_Sql = M_Sql & "'" & M_UnitList & "',"
            M_Sql = M_Sql & "'" & Format(M_FromDate, "MM/dd/yyyy") & "',"
            M_Sql = M_Sql & "'" & Format(M_ToDate, "MM/dd/yyyy") & "'"

            M_DBConn.ExecuteDataSet(M_DataSet, M_Sql)
            Return M_DataSet

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ProcRpt_AccBalanceSheetReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_AsOnDate As Date) As DataSet
        Try
            Dim M_DataSet As New DataSet
            Dim M_Sql As String

            M_Sql = "Exec ProcRpt_AccBalanceSheetReport_Sp "
            M_Sql = M_Sql & M_CmpCode & ","
            M_Sql = M_Sql & M_MenuID & ","
            M_Sql = M_Sql & M_RptID & ","
            M_Sql = M_Sql & M_UserID & ","
            M_Sql = M_Sql & "'" & M_UnitList & "',"
            M_Sql = M_Sql & "'" & Format(M_AsOnDate, "MM/dd/yyyy") & "'"

            M_DBConn.ExecuteDataSet(M_DataSet, M_Sql)
            Return M_DataSet

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub New()
        Try
            M_DBConn = New Connection
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            M_DBConn = Nothing
            MyBase.Finalize()
        Catch ex As Exception
        End Try
    End Sub

End Class
