Imports SMARTtBR_CO.CommonClass
Public Class ClientMasterBO
    Private M_BrCode As Integer
    Private M_CMTitleID As Integer
    Private M_CMReferID As Long
    Private M_CMRefferType As Integer
    Private M_CMTypeID As Integer
    Private M_CMOccupation As Integer
    Private M_CMClass As Integer
    Private M_CMCreditPeriod As Integer
    Private M_CMDiscTypeID As Integer
    Private M_CMID As Long
    Private M_CMName As String
    Private M_CMFormalName As String
    Private M_CMPrAdrs1 As String
    Private M_CMPrAdrs2 As String
    Private M_CMPrAdrs3 As String
    Private M_CMPrCity As String
    Private M_CMLandMark As String
    Private M_CMPhoneNo As String
    Private M_CMPhoneResidency As String
    Private M_CMEMail As String
    Private M_CMPANNO As String
    Private M_CMKSTNO As String
    Private M_CMCSTNO As String
    Private M_CMTIN As String
    Private M_CMGSTIN As String
    Private M_CMNarration As String
    Private M_CMPrPin As String
    Private M_CMPrState As String
    Private M_CMPrStateCode As String
    Private M_CMPmAdrs1 As String
    Private M_CMPmAdrs2 As String
    Private M_CMPmAdrs3 As String
    Private M_CMPmCity As String
    Private M_CMPmPin As String
    Private M_CMPmState As String
    Private M_CMPmStateCode As String
    Private M_CMCreditEnabled As String
    Private M_CMLocationID As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_ActiveStatus As String
    Private M_CMMemberWithAbove65 As Integer
    Private M_CMMemberWithBelow10 As Integer
    Private M_CMTotalNoOfMembers As Integer
    Private M_CMDOB As Date
    Private M_OnBrCode As Integer
    Private M_CMAccCode As Integer

    Public Property On_BrCode() As Integer
        Get
            Return Branch_Code
        End Get
        Set(ByVal value As Integer)
            M_OnBrCode = value
        End Set
    End Property

    Public Property BrCode() As Integer
        Get
            Return M_BrCode
        End Get
        Set(ByVal value As Integer)
            M_BrCode = value
        End Set
    End Property
    Public Property CMTitleID() As Integer
        Get
            Return M_CMTitleID
        End Get
        Set(ByVal value As Integer)
            M_CMTitleID = value
        End Set
    End Property
    Public Property CMReferID() As Integer
        Get
            Return M_CMReferID
        End Get
        Set(ByVal value As Integer)
            M_CMReferID = value
        End Set
    End Property
    Public Property CMRefferType() As Integer
        Get
            Return M_CMRefferType
        End Get
        Set(ByVal value As Integer)
            M_CMRefferType = value
        End Set
    End Property
    Public Property CMTypeID() As Integer
        Get
            Return M_CMTypeID
        End Get
        Set(ByVal value As Integer)
            M_CMTypeID = value
        End Set
    End Property
    Public Property CMOccupation() As Integer
        Get
            Return M_CMOccupation
        End Get
        Set(ByVal value As Integer)
            M_CMOccupation = value
        End Set
    End Property
    Public Property CMClass() As Integer
        Get
            Return M_CMClass
        End Get
        Set(ByVal value As Integer)
            M_CMClass = value
        End Set
    End Property
    Public Property CMCreditPeriod() As Integer
        Get
            Return M_CMCreditPeriod
        End Get
        Set(ByVal value As Integer)
            M_CMCreditPeriod = value
        End Set
    End Property
    Public Property CMDiscTypeID() As Integer
        Get
            Return M_CMDiscTypeID
        End Get
        Set(ByVal value As Integer)
            M_CMDiscTypeID = value
        End Set
    End Property
    Public Property CMID() As Long
        Get
            Return M_CMID
        End Get
        Set(ByVal value As Long)
            M_CMID = value
        End Set
    End Property
    Public Property CMName() As String
        Get
            Return M_CMName
        End Get
        Set(ByVal value As String)
            M_CMName = value
        End Set
    End Property
    Public Property CMFormalName() As String
        Get
            Return M_CMFormalName
        End Get
        Set(ByVal value As String)
            M_CMFormalName = value
        End Set
    End Property
    Public Property CMPrAdrs1() As String
        Get
            Return M_CMPrAdrs1
        End Get
        Set(ByVal value As String)
            M_CMPrAdrs1 = value
        End Set
    End Property
    Public Property CMPrAdrs2() As String
        Get
            Return M_CMPrAdrs2
        End Get
        Set(ByVal value As String)
            M_CMPrAdrs2 = value
        End Set
    End Property
    Public Property CMPrAdrs3() As String
        Get
            Return M_CMPrAdrs3
        End Get
        Set(ByVal value As String)
            M_CMPrAdrs3 = value
        End Set
    End Property
    Public Property CMPrCity() As String
        Get
            Return M_CMPrCity
        End Get
        Set(ByVal value As String)
            M_CMPrCity = value
        End Set
    End Property
    Public Property CMLandMark() As String
        Get
            Return M_CMLandMark
        End Get
        Set(ByVal value As String)
            M_CMLandMark = value
        End Set
    End Property
    Public Property CMPhoneNo() As String
        Get
            Return M_CMPhoneNo
        End Get
        Set(ByVal value As String)
            M_CMPhoneNo = value
        End Set
    End Property
    Public Property CMPhoneResidency() As String
        Get
            Return M_CMPhoneResidency
        End Get
        Set(ByVal value As String)
            M_CMPhoneResidency = value
        End Set
    End Property
    Public Property CMEMail() As String
        Get
            Return M_CMEMail
        End Get
        Set(ByVal value As String)
            M_CMEMail = value
        End Set
    End Property
    Public Property CMPANNO() As String
        Get
            Return M_CMPANNO
        End Get
        Set(ByVal value As String)
            M_CMPANNO = value
        End Set
    End Property
    Public Property CMKSTNO() As String
        Get
            Return M_CMKSTNO
        End Get
        Set(ByVal value As String)
            M_CMKSTNO = value
        End Set
    End Property
    Public Property CMCSTNO() As String
        Get
            Return M_CMCSTNO
        End Get
        Set(ByVal value As String)
            M_CMCSTNO = value
        End Set
    End Property
    Public Property CMTIN() As String
        Get
            Return M_CMTIN
        End Get
        Set(ByVal value As String)
            M_CMTIN = value
        End Set
    End Property
    Public Property CMGSTIN() As String
        Get
            Return M_CMGSTIN
        End Get
        Set(ByVal value As String)
            M_CMGSTIN = value
        End Set
    End Property
    Public Property CMNarration() As String
        Get
            Return M_CMNarration
        End Get
        Set(ByVal value As String)
            M_CMNarration = value
        End Set
    End Property
    Public Property CMPrPin() As String
        Get
            Return M_CMPrPin
        End Get
        Set(ByVal value As String)
            M_CMPrPin = value
        End Set
    End Property
    Public Property CMPrState() As String
        Get
            Return M_CMPrState
        End Get
        Set(ByVal value As String)
            M_CMPrState = value
        End Set
    End Property
    Public Property CMPrStateCode() As String
        Get
            Return M_CMPrStateCode
        End Get
        Set(ByVal value As String)
            M_CMPrStateCode = value
        End Set
    End Property
    Public Property CMPmAdrs1() As String
        Get
            Return M_CMPmAdrs1
        End Get
        Set(ByVal value As String)
            M_CMPmAdrs1 = value
        End Set
    End Property
    Public Property CMPmAdrs2() As String
        Get
            Return M_CMPmAdrs2
        End Get
        Set(ByVal value As String)
            M_CMPmAdrs2 = value
        End Set
    End Property
    Public Property CMPmAdrs3() As String
        Get
            Return M_CMPmAdrs3
        End Get
        Set(ByVal value As String)
            M_CMPmAdrs3 = value
        End Set
    End Property
    Public Property CMPmCity() As String
        Get
            Return M_CMPmCity
        End Get
        Set(ByVal value As String)
            M_CMPmCity = value
        End Set
    End Property
    Public Property CMPmPin() As String
        Get
            Return M_CMPmPin
        End Get
        Set(ByVal value As String)
            M_CMPmPin = value
        End Set
    End Property
    Public Property CMPmState() As String
        Get
            Return M_CMPmState
        End Get
        Set(ByVal value As String)
            M_CMPmState = value
        End Set
    End Property
    Public Property CMPmStateCode() As String
        Get
            Return M_CMPmStateCode
        End Get
        Set(ByVal value As String)
            M_CMPmStateCode = value
        End Set
    End Property
    Public Property CMCreditEnabled() As String
        Get
            Return M_CMCreditEnabled
        End Get
        Set(ByVal value As String)
            M_CMCreditEnabled = value
        End Set
    End Property
    Public Property CMLocationID() As Integer
        Get
            Return M_CMLocationID
        End Get
        Set(ByVal value As Integer)
            M_CMLocationID = value
        End Set
    End Property

    Public Property MakerID() As Integer
        Get
            Return M_MakerID
        End Get
        Set(ByVal value As Integer)
            M_MakerID = value
        End Set
    End Property
    Public Property UpdaterID() As Integer
        Get
            Return M_UpdaterID
        End Get
        Set(ByVal value As Integer)
            M_UpdaterID = value
        End Set
    End Property
    Public Property MakingTime() As Date
        Get
            Return M_MakingTime
        End Get
        Set(ByVal value As Date)
            M_MakingTime = value
        End Set
    End Property
    Public Property UpdatingTime() As Date
        Get
            Return M_UpdatingTime
        End Get
        Set(ByVal value As Date)
            M_UpdatingTime = value
        End Set
    End Property

    Public Property ActiveStatus() As String
        Get
            Return M_ActiveStatus
        End Get
        Set(ByVal value As String)
            M_ActiveStatus = value
        End Set
    End Property

    Public Property CMMemberWithAbove65() As Integer
        Get
            Return M_CMMemberWithAbove65
        End Get
        Set(ByVal value As Integer)
            M_CMMemberWithAbove65 = value
        End Set
    End Property
    Public Property CMMemberWithBelow10() As Integer
        Get
            Return M_CMMemberWithBelow10
        End Get
        Set(ByVal value As Integer)
            M_CMMemberWithBelow10 = value
        End Set
    End Property
    Public Property CMTotalNoOfMembers() As Integer
        Get
            Return M_CMTotalNoOfMembers
        End Get
        Set(ByVal value As Integer)
            M_CMTotalNoOfMembers = value
        End Set
    End Property
    Public Property CMDOB() As Date
        Get
            Return M_CMDOB
        End Get
        Set(ByVal value As Date)
            M_CMDOB = value
        End Set
    End Property

    Public Property CMAccCode() As Integer
        Get
            Return M_CMAccCode
        End Get
        Set(ByVal value As Integer)
            M_CMAccCode = value
        End Set
    End Property

End Class

