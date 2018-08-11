Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Public Class ReportsBL

    Public Function ProcRpt_AccDayBookReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try

            Dim M_ReportsDA As New ReportsDA
            Dim M_Dt As DataSet
            If CheckUserRight("VIEW", M_UserID, M_MenuID) = True Then
                M_Dt = M_ReportsDA.ProcRpt_AccDayBookReport(M_CmpCode, M_MenuID, M_RptID, M_UserID, M_UnitList, M_FromDate, M_ToDate)
                M_ReportsDA = Nothing
                Return M_Dt
            Else
                M_Dt = Nothing
                Return M_Dt
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ProcRpt_AccLedgerReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_AccHeadList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try

            Dim M_ReportsDA As New ReportsDA
            Dim M_Dt As DataSet
            If CheckUserRight("VIEW", M_UserID, M_MenuID) = True Then
                M_Dt = M_ReportsDA.ProcRpt_AccLedgerReport(M_CmpCode, M_MenuID, M_RptID, M_UserID, M_UnitList, M_AccHeadList, M_FromDate, M_ToDate)
                M_ReportsDA = Nothing
                Return M_Dt
            Else
                M_Dt = Nothing
                Return M_Dt
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ProcRpt_AccRandDReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_AccHeadList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try

            Dim M_ReportsDA As New ReportsDA
            Dim M_Dt As DataSet
            If CheckUserRight("VIEW", M_UserID, M_MenuID) = True Then
                M_Dt = M_ReportsDA.ProcRpt_AccRandDReport(M_CmpCode, M_MenuID, M_RptID, M_UserID, M_UnitList, M_AccHeadList, M_FromDate, M_ToDate)
                M_ReportsDA = Nothing
                Return M_Dt
            Else
                M_Dt = Nothing
                Return M_Dt
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ProcRpt_AccTrialBalanceReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try

            Dim M_ReportsDA As New ReportsDA
            Dim M_Dt As DataSet
            If CheckUserRight("VIEW", M_UserID, M_MenuID) = True Then
                M_Dt = M_ReportsDA.ProcRpt_AccTrialBalanceReport(M_CmpCode, M_MenuID, M_RptID, M_UserID, M_UnitList, M_FromDate, M_ToDate)
                M_ReportsDA = Nothing
                Return M_Dt
            Else
                M_Dt = Nothing
                Return M_Dt
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ProcRpt_AccPandLReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_FromDate As Date, ByVal M_ToDate As Date) As DataSet
        Try

            Dim M_ReportsDA As New ReportsDA
            Dim M_Dt As DataSet
            If CheckUserRight("VIEW", M_UserID, M_MenuID) = True Then
                M_Dt = M_ReportsDA.ProcRpt_AccPandLReport(M_CmpCode, M_MenuID, M_RptID, M_UserID, M_UnitList, M_FromDate, M_ToDate)
                M_ReportsDA = Nothing
                Return M_Dt
            Else
                M_Dt = Nothing
                Return M_Dt
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ProcRpt_AccBalanceSheetReport(ByVal M_CmpCode As Integer, ByVal M_MenuID As Integer, ByVal M_RptID As Integer, ByVal M_UserID As Integer, ByVal M_UnitList As String, ByVal M_AsOnDate As Date) As DataSet
        Try

            Dim M_ReportsDA As New ReportsDA
            Dim M_Dt As DataSet
            If CheckUserRight("VIEW", M_UserID, M_MenuID) = True Then
                M_Dt = M_ReportsDA.ProcRpt_AccBalanceSheetReport(M_CmpCode, M_MenuID, M_RptID, M_UserID, M_UnitList, M_AsOnDate)
                M_ReportsDA = Nothing
                Return M_Dt
            Else
                M_Dt = Nothing
                Return M_Dt
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

End Class
