Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Public Class AccYearlyClosingBL
    Private M_AYID As Long

    Public Function Save_Data(ByVal M_AccYearlyClosing As AccYearlyClosingBO, ByVal M_EntryMode As String, ByVal Menu_ID As Integer) As Long
        Try

            Dim M_AccYearlyClosingDA As New AccYearlyClosingDA
            Dim UserTime As String
            If CheckUserRight(M_EntryMode, M_AccYearlyClosing.MakerID, Menu_ID) = True Then
                UserTime = Get_UserTime()
                M_AYID = M_AccYearlyClosingDA.Save_Data(M_AccYearlyClosing, M_EntryMode, UserTime)
                M_AccYearlyClosingDA = Nothing
                Return M_AYID
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Locate_Data(ByVal M_UNID As Integer, M_FinYear As String) As AccYearlyClosingBO
        Try

            Dim M_AccYearlyClosingDA As New AccYearlyClosingDA
            Return M_AccYearlyClosingDA.Locate_Data(M_UNID, M_FinYear)
            M_AccYearlyClosingDA = Nothing

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
