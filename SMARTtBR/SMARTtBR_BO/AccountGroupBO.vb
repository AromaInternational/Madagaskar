Public Class AccountGroupBO
    Private M_GPID As Integer
    Private M_GPSeqNo As Integer
    Private M_GPParentId As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_GPName As String
    Private M_ActiveStatus As String
    Public Property GPID() As Integer        Get            Return M_GPID        End Get        Set(ByVal value As Integer)            M_GPID = value        End Set    End Property
    Public Property GPSeqNo() As Integer        Get            Return M_GPSeqNo        End Get        Set(ByVal value As Integer)            M_GPSeqNo = value        End Set    End Property
    Public Property GPParentId() As Integer        Get            Return M_GPParentId        End Get        Set(ByVal value As Integer)            M_GPParentId = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property UpdaterID() As Integer        Get            Return M_UpdaterID        End Get        Set(ByVal value As Integer)            M_UpdaterID = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property GPName() As String        Get            Return M_GPName.Trim()        End Get        Set(ByVal value As String)            M_GPName = value.Trim()        End Set    End Property
    Public Property ActiveStatus() As String        Get            Return M_ActiveStatus.Trim()        End Get        Set(ByVal value As String)            M_ActiveStatus = value.Trim()        End Set    End Property
End Class