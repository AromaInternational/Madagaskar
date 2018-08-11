Imports SMARTtBR_CO.CommonClass
Public Class DepartmentBO
    Private M_DepID As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_DepName As String
    Private M_ActiveStatus As String

    Public Property DepID() As Integer
        Get
            Return M_DepID
        End Get
        Set(ByVal value As Integer)
            M_DepID = value
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
    Public Property DepName() As String
        Get
            Return M_DepName
        End Get
        Set(ByVal value As String)
            M_DepName = value
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
