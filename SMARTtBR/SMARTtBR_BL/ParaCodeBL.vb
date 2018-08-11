Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Public Class ParaCodeBL
    Private M_PCID As Integer
    Public Function Save_Data(ByVal M_ParaCode As ParaCodeBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer) As Integer
        Try

            Dim M_ParaCodeDA As New ParaCodeDA
            Dim UserTime As String
            If CheckUserRight(M_EntryMode, M_ParaCode.MakerID, M_MenuID) = True Then
                UserTime = Get_UserTime()
                M_PCID = M_ParaCodeDA.Save_Data(M_ParaCode, M_EntryMode, M_MenuID, UserTime)
                M_ParaCodeDA = Nothing
                Return M_PCID
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Locate_Data(ByVal M_PCID As Integer) As ParaCodeBO
        Try

            Dim M_ParaCodeDA As New ParaCodeDA
            Return M_ParaCodeDA.Locate_Data(M_PCID)
            M_ParaCodeDA = Nothing

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Check_ParameterNameExists(ByVal ParameterName As String, ByVal ParaType As Integer) As Boolean

        Try
            Dim M_Return As Boolean
            Dim M_ParaCodeDA As New ParaCodeDA
            M_Return = M_ParaCodeDA.Check_ParameterNameExists(ParameterName, ParaType)
            M_ParaCodeDA = Nothing
            Return M_Return

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Check_ParameterLocked(ByVal ParamCode As Integer) As Boolean

        Try
            Dim M_Return As Boolean
            Dim M_ParaCodeDA As New ParaCodeDA
            M_Return = M_ParaCodeDA.Check_ParameterLocked(ParamCode)
            M_ParaCodeDA = Nothing
            Return M_Return

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ParamTypeDetails(Optional ByVal ActiveStatus As String = "") As DataTable

        Try
            Dim M_ParaCodeDA As New ParaCodeDA
            Return M_ParaCodeDA.Fill_ParamTypeDetails(ActiveStatus)
            M_ParaCodeDA = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Fill_ParamCodeDetails(Optional ByVal M_PCType As Integer = 0, Optional ByVal ActiveStatus As String = "") As DataTable

        Try
            Dim M_ParaCodeDA As New ParaCodeDA
            Return M_ParaCodeDA.Fill_ParamCodeDetails(M_PCType, ActiveStatus)
            M_ParaCodeDA = Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
