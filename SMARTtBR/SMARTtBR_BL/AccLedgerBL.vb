Imports SMARTtBR_DAImports SMARTtBR_BOImports SMARTtBR_BL.CommonBLImports SMARTtBR_CO.CommonClassPublic Class AccLedgerBL    Private M_AccId As Long    Public Function Save_Data(ByVal M_AccLedger As AccLedgerBO, ByVal M_TranSw As String, ByVal M_EntryMode As String, ByVal M_MenuID As Integer) As Long        Try            Dim M_AccLedgerDA As New AccLedgerDA            Dim UserTime As String            If CheckUserRight(M_EntryMode, M_AccLedger.MakerID, M_MenuID) = True Then                UserTime = Get_UserTime()                M_AccId = M_AccLedgerDA.Save_Data(M_AccLedger, M_TranSw, M_EntryMode, M_MenuID, UserTime)                M_AccLedgerDA = Nothing                Return M_AccId            Else                Return 0            End If        Catch ex As Exception            Return 0        End Try    End Function    Public Function Locate_Data(ByVal M_AccId As Long) As AccLedgerBO        Try            Dim M_AccLedgerDA As New AccLedgerDA            Return M_AccLedgerDA.Locate_Data(M_AccId)            M_AccLedgerDA = Nothing        Catch ex As Exception            Return Nothing        End Try    End Function    Public Function Fill_AccTran(Optional ByVal Acc_ID As Long = 0) As DataTable

        Try
            Dim M_DataTable As DataTable
            Dim M_AccLedgerDA As New AccLedgerDA
            M_DataTable = M_AccLedgerDA.Fill_AccTran(Acc_ID)
            M_AccLedgerDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End Function    Public Function Proc_AccTranSearch(ByVal M_CmpCode As Integer, ByVal M_FinYear As String, ByVal M_VoucherType As String, ByVal M_TrUnit As Integer, ByVal M_TrDateFrom As Date, _                                       ByVal M_TrDateTo As Date, ByVal M_VrNoFrom As Integer, ByVal M_VrNoTo As Integer, ByVal M_AmountFrom As Double, _                                       ByVal M_AmountTo As Double, ByVal M_TrType As Integer, ByVal M_AccCode As Integer, ByVal M_Remarks As String, ByVal M_UserID As Integer) As DataTable

        Try
            Dim M_DataTable As DataTable
            Dim M_AccLedgerDA As New AccLedgerDA
            M_DataTable = M_AccLedgerDA.Proc_AccTranSearch(M_CmpCode, M_FinYear, M_VoucherType, M_TrUnit, M_TrDateFrom, M_TrDateTo, M_VrNoFrom, M_VrNoTo, M_AmountFrom, M_AmountTo, M_TrType, M_AccCode, M_Remarks, M_UserID)
            M_AccLedgerDA = Nothing
            Return M_DataTable
        Catch ex As Exception
            Return Nothing
        End Try

    End FunctionEnd Class
