Public Class ParaCodeBO
    Private M_PCID As Integer
    Private M_PCType As Integer
    Private M_PCOrder As Integer
    Private M_MakerID As Integer
    Private M_UpdaterId As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_PCDescription As String
    Private M_PCLocked As String
    Private M_ActiveStatus As String
    Public Property PCID() As Integer        Get            Return M_PCID        End Get        Set(ByVal value As Integer)            M_PCID = value        End Set    End Property
    Public Property PCType() As Integer        Get            Return M_PCType        End Get        Set(ByVal value As Integer)            M_PCType = value        End Set    End Property
    Public Property PCOrder() As Integer        Get            Return M_PCOrder        End Get        Set(ByVal value As Integer)            M_PCOrder = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property UpdaterId() As Integer        Get            Return M_UpdaterId        End Get        Set(ByVal value As Integer)            M_UpdaterId = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property PCDescription() As String        Get            Return M_PCDescription        End Get        Set(ByVal value As String)            M_PCDescription = value        End Set    End Property
    Public Property PCLocked() As String        Get            Return M_PCLocked        End Get        Set(ByVal value As String)            M_PCLocked = value        End Set    End Property
    Public Property ActiveStatus() As String        Get            Return M_ActiveStatus        End Get        Set(ByVal value As String)            M_ActiveStatus = value        End Set    End Property
End Class