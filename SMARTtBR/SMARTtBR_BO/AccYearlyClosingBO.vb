Imports SMARTtBR_CO.CommonClass
Public Class AccYearlyClosingBO
    Private M_UNID As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_AYDate As Date
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_AYID As Long
    Private M_AYFinYear As String
    Private M_ActiveStatus As String
    Public Property UNID() As Integer
        Get
            Return M_UNID
        End Get
        Set(ByVal value As Integer)
            M_UNID = value
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
    Public Property AYDate() As Date
        Get
            Return M_AYDate
        End Get
        Set(ByVal value As Date)
            M_AYDate = value
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
    Public Property AYID() As Long
        Get
            Return M_AYID
        End Get
        Set(ByVal value As Long)
            M_AYID = value
        End Set
    End Property
    Public Property AYFinYear() As String
        Get
            Return M_AYFinYear
        End Get
        Set(ByVal value As String)
            M_AYFinYear = value
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
End Class