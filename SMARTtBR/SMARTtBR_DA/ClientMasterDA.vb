Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class ClientMasterDA
    Private M_DBConn As Connection
    Private M_CMID As Integer
    Public Function Save_Data(ByVal M_Client As ClientMasterBO, ByVal M_EntryMode As String, ByVal UserTime As String) As Integer
        Try
            Dim M_Sql As String

            With M_Client
                M_Sql = "Exec IUM_ClientMaster_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                '  M_Sql = M_Sql & .On_BrCode & ","
                M_Sql = M_Sql & .BrCode & ","
                M_Sql = M_Sql & .CMID & ","
                M_Sql = M_Sql & "'" & .CMName & "',"
                M_Sql = M_Sql & "'" & .CMFormalName & "',"
                M_Sql = M_Sql & .CMTitleID & ","
                M_Sql = M_Sql & .CMReferID & ","
                M_Sql = M_Sql & .CMRefferType & ","
                M_Sql = M_Sql & "'" & .CMPrAdrs1 & "',"
                M_Sql = M_Sql & "'" & .CMPrAdrs2 & "',"
                M_Sql = M_Sql & "'" & .CMPrAdrs3 & "',"
                M_Sql = M_Sql & "'" & .CMPrCity & "',"
                M_Sql = M_Sql & "'" & .CMPrPin & "',"
                M_Sql = M_Sql & "'" & .CMPrState & "',"
                M_Sql = M_Sql & "'" & .CMPrStateCode & "',"
                M_Sql = M_Sql & "'" & .CMPmAdrs1 & "',"
                M_Sql = M_Sql & "'" & .CMPmAdrs2 & "',"
                M_Sql = M_Sql & "'" & .CMPmAdrs3 & "',"
                M_Sql = M_Sql & "'" & .CMPmCity & "',"
                M_Sql = M_Sql & "'" & .CMPmPin & "',"
                M_Sql = M_Sql & "'" & .CMPmState & "',"
                M_Sql = M_Sql & "'" & .CMPmStateCode & "',"
                M_Sql = M_Sql & "'" & .CMEMail & "',"
                M_Sql = M_Sql & .CMTypeID & ","
                M_Sql = M_Sql & "'" & .CMPANNO & "',"
                M_Sql = M_Sql & "'" & .CMKSTNO & "',"
                M_Sql = M_Sql & "'" & .CMCSTNO & "',"
                M_Sql = M_Sql & "'" & .CMTIN & "',"
                M_Sql = M_Sql & "'" & .CMGSTIN & "',"
                M_Sql = M_Sql & .CMOccupation & ","
                M_Sql = M_Sql & .CMClass & ","
                M_Sql = M_Sql & .CMCreditPeriod & ","
                M_Sql = M_Sql & "'" & .CMNarration & "',"
                M_Sql = M_Sql & "'" & .CMLandMark & "',"
                M_Sql = M_Sql & "'" & .CMPhoneNo & "',"
                M_Sql = M_Sql & "'" & .CMPhoneResidency & "',"
                M_Sql = M_Sql & .CMDiscTypeID & ","
                M_Sql = M_Sql & .CMLocationID & ","
                M_Sql = M_Sql & "'" & Format(.CMDOB, "MM/dd/yyyy") & "',"
                M_Sql = M_Sql & .CMMemberWithAbove65 & ","
                M_Sql = M_Sql & .CMMemberWithBelow10 & ","
                M_Sql = M_Sql & .CMTotalNoOfMembers & ","
                M_Sql = M_Sql & .CMAccCode & ","
                M_Sql = M_Sql & "'" & .CMCreditEnabled & "',"
                M_Sql = M_Sql & "'" & .ActiveStatus & "',"
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & .UpdaterID & ","
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "',0,'Y'"
            End With

            ' M_CMID = M_DBConn.ExecuteScalar(M_Sql, 0, False)

            Return M_CMID

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Locate_Data(ByVal M_CmpCode As Integer, ByVal M_CMID As String, ByVal M_CMPhoneNo As String, ByVal M_TypeID As Integer) As ClientMasterBO
        Try
            Dim M_Dt As New DataTable
            Dim M_Client As New ClientMasterBO
            Dim Qry As String

            If M_CMID = "" And M_CMPhoneNo = "" Then M_CMID = "0"

            Qry = "Exec Proc_LocateCustData_Sp '" & M_CmpCode & "','" & M_CMID & "','" & M_CMPhoneNo & "'," & M_TypeID

            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_Client
                    .BrCode = M_Dt.Rows(0).Item("Br_Code")
                    .CMTitleID = M_Dt.Rows(0).Item("CM_TitleID")
                    .CMTypeID = M_Dt.Rows(0).Item("CM_TypeID")
                    .CMRefferType = M_Dt.Rows(0).Item("CM_RefferType")
                    .CMOccupation = M_Dt.Rows(0).Item("CM_Occupation")
                    .CMClass = M_Dt.Rows(0).Item("CM_Class")
                    .CMCreditPeriod = M_Dt.Rows(0).Item("CM_CreditPeriod")
                    .CMDiscTypeID = M_Dt.Rows(0).Item("CM_DiscTypeID")
                    .CMLocationID = M_Dt.Rows(0).Item("CM_LocationID")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .UpdaterID = M_Dt.Rows(0).Item("Updater_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .CMID = M_Dt.Rows(0).Item("CM_ID")
                    .CMReferID = M_Dt.Rows(0).Item("CM_ReferID")
                    .CMName = M_Dt.Rows(0).Item("CM_Name")
                    .CMFormalName = M_Dt.Rows(0).Item("CM_FormalName")
                    .CMPrAdrs1 = M_Dt.Rows(0).Item("CM_PrAdrs1")
                    .CMPrAdrs2 = M_Dt.Rows(0).Item("CM_PrAdrs2")
                    .CMPrAdrs3 = M_Dt.Rows(0).Item("CM_PrAdrs3")
                    .CMPrCity = M_Dt.Rows(0).Item("CM_PrCity")
                    .CMPrPin = M_Dt.Rows(0).Item("CM_PrPin")
                    .CMPrState = M_Dt.Rows(0).Item("CM_PrState")
                    .CMPrStateCode = M_Dt.Rows(0).Item("CM_PrStateCode")
                    .CMLandMark = M_Dt.Rows(0).Item("CM_LandMark")
                    .CMPhoneNo = M_Dt.Rows(0).Item("CM_PhoneNo")
                    .CMPhoneResidency = M_Dt.Rows(0).Item("CM_PhoneResidency")
                    .CMEMail = M_Dt.Rows(0).Item("CM_EMail")
                    .CMPANNO = M_Dt.Rows(0).Item("CM_PANNO")
                    .CMKSTNO = M_Dt.Rows(0).Item("CM_KSTNO")
                    .CMCSTNO = M_Dt.Rows(0).Item("CM_CSTNO")
                    .CMTIN = M_Dt.Rows(0).Item("CM_TIN")
                    .CMGSTIN = M_Dt.Rows(0).Item("CM_GSTIN")
                    .CMNarration = M_Dt.Rows(0).Item("CM_Narration")
                    .CMPmAdrs1 = M_Dt.Rows(0).Item("CM_PmAdrs1")
                    .CMPmAdrs2 = M_Dt.Rows(0).Item("CM_PmAdrs2")
                    .CMPmAdrs3 = M_Dt.Rows(0).Item("CM_PmAdrs3")
                    .CMPmCity = M_Dt.Rows(0).Item("CM_PmCity")
                    .CMPmPin = M_Dt.Rows(0).Item("CM_PmPin")
                    .CMPmState = M_Dt.Rows(0).Item("CM_PmState")
                    .CMPmStateCode = M_Dt.Rows(0).Item("CM_PmStateCode")
                    .CMCreditEnabled = M_Dt.Rows(0).Item("CM_CreditEnabled")
                    .ActiveStatus = M_Dt.Rows(0).Item("Active_Status")
                    .CMMemberWithAbove65 = M_Dt.Rows(0).Item("CM_MemberWithAbove65")
                    .CMMemberWithBelow10 = M_Dt.Rows(0).Item("CM_MemberWithBelow10")
                    .CMTotalNoOfMembers = M_Dt.Rows(0).Item("CM_TotalNoOfMembers")
                    .CMDOB = M_Dt.Rows(0).Item("CM_DOB")
                    .CMAccCode = M_Dt.Rows(0).Item("CM_AccCode")
                End With
            End If
            Return M_Client
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
