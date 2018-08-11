Public Class UnitMasterBO
    Private M_UNID As Integer
    Private M_UNCmpCode As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_UNName As String
    Private M_ActiveStatus As String
    Public Property UNID() As Integer        Get            Return M_UNID        End Get        Set(ByVal value As Integer)            M_UNID = value        End Set    End Property
    Public Property UNCmpCode() As Integer        Get            Return M_UNCmpCode        End Get        Set(ByVal value As Integer)            M_UNCmpCode = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property UpdaterID() As Integer        Get            Return M_UpdaterID        End Get        Set(ByVal value As Integer)            M_UpdaterID = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property UNName() As String        Get            Return M_UNName.Trim()        End Get        Set(ByVal value As String)            M_UNName = value.Trim()        End Set    End Property
    Public Property ActiveStatus() As String        Get            Return M_ActiveStatus.Trim()        End Get        Set(ByVal value As String)            M_ActiveStatus = value.Trim()        End Set    End Property
End Class