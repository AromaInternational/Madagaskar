Public Class UserMasterBO
    Private M_UMID As Integer
    Private M_UMDepID As Integer
    Private M_UMDesID As Integer
    Private M_UMTypeID As Integer
    Private M_UMUNID As Integer
    Private M_UMAutoLogOutPeriod As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_UMPwd As String
    Private M_UMDepartment As String
    Private M_UMDesignation As String
    Private M_UMName As String
    Private M_UMUnit As String
    Private M_ActiveStatus As String
    Public Property UMID() As Integer        Get            Return M_UMID        End Get        Set(ByVal value As Integer)            M_UMID = value        End Set    End Property
    Public Property UMDepID() As Integer        Get            Return M_UMDepID        End Get        Set(ByVal value As Integer)            M_UMDepID = value        End Set    End Property
    Public Property UMDesID() As Integer        Get            Return M_UMDesID        End Get        Set(ByVal value As Integer)            M_UMDesID = value        End Set    End Property
    Public Property UMTypeID() As Integer        Get            Return M_UMTypeID        End Get        Set(ByVal value As Integer)            M_UMTypeID = value        End Set    End Property
    Public Property UMUNID() As Integer        Get            Return M_UMUNID        End Get        Set(ByVal value As Integer)            M_UMUNID = value        End Set    End Property
    Public Property UMAutoLogOutPeriod() As Integer        Get            Return M_UMAutoLogOutPeriod        End Get        Set(ByVal value As Integer)            M_UMAutoLogOutPeriod = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property UpdaterID() As Integer        Get            Return M_UpdaterID        End Get        Set(ByVal value As Integer)            M_UpdaterID = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property UMPwd() As String        Get            Return M_UMPwd        End Get        Set(ByVal value As String)            M_UMPwd = value        End Set    End Property
    Public Property UMDepartment() As String        Get            Return M_UMDepartment.Trim()        End Get        Set(ByVal value As String)            M_UMDepartment = value.Trim()        End Set    End Property
    Public Property UMDesignation() As String        Get            Return M_UMDesignation.Trim()        End Get        Set(ByVal value As String)            M_UMDesignation = value.Trim()        End Set    End Property
    Public Property UMName() As String        Get            Return M_UMName.Trim()        End Get        Set(ByVal value As String)            M_UMName = value.Trim()        End Set    End Property
    Public Property UMUnit() As String        Get            Return M_UMUnit.Trim()        End Get        Set(ByVal value As String)            M_UMUnit = value.Trim()        End Set    End Property
    Public Property ActiveStatus() As String        Get            Return M_ActiveStatus.Trim()        End Get        Set(ByVal value As String)            M_ActiveStatus = value.Trim()        End Set    End Property
End Class