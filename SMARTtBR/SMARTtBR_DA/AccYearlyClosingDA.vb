Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class AccYearlyClosingDA
    Private M_DBConn As Connection
    Private M_AYID As Long
    Public Function Save_Data(ByVal M_AccYearlyClosing As AccYearlyClosingBO, ByVal M_EntryMode As String, ByVal UserTime As String) As Long
        Try
            Dim M_Sql As String

            With M_AccYearlyClosing
                M_Sql = "Exec IUM_AccYearlyClosing_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & .UNID & ","
                M_Sql = M_Sql & .AYID & ","
                M_Sql = M_Sql & "'" & Format(.AYDate, "MM/dd/yyyy") & "',"
                M_Sql = M_Sql & "'" & .AYFinYear & "',"
                M_Sql = M_Sql & "'" & .ActiveStatus & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterID & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "'"
            End With

            M_AYID = M_DBConn.ExecuteScalar(M_Sql)

            Return M_AYID

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Locate_Data(ByVal M_UNID As Integer, M_FinYear As String) As AccYearlyClosingBO
        Try
            Dim M_Dt As New DataTable
            Dim M_AccYearlyClosing As New AccYearlyClosingBO
            Dim Qry As String
            Qry = "Select * from AccYearlyClosing_M_Tbl where AY_UNID = " & M_UNID & " AND AY_FinYear ='" & M_FinYear & "'"
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_AccYearlyClosing
                    .UNID = M_Dt.Rows(0).Item("AY_UNID")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .AYDate = M_Dt.Rows(0).Item("AY_Date")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .AYID = M_Dt.Rows(0).Item("AY_ID")
                    .AYFinYear = M_Dt.Rows(0).Item("AY_FinYear")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                End With
            End If
            Return M_AccYearlyClosing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub New()
        M_DBConn = New Connection
    End Sub

End Class
