Public Class AccountMasterBO
    Private M_AccCode As Integer
    Private M_AccCmpCode As Integer
    Private M_AccGPID As Integer
    Private M_GPSeqNo As Integer
    Private M_AccSeqNo As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_AccName As String
    Private M_GPName As String
    Private M_AccPosition As String
    Private M_AccBalType As String
    Private M_AccALIE As String
    Private M_AccStatementtype As String
    Private M_AccBillBreakup As String
    Private M_ActiveStatus As String
    Public Property AccCode() As Integer        Get            Return M_AccCode        End Get        Set(ByVal value As Integer)            M_AccCode = value        End Set    End Property
    Public Property AccCmpCode() As Integer        Get            Return M_AccCmpCode        End Get        Set(ByVal value As Integer)            M_AccCmpCode = value        End Set    End Property
    Public Property AccGPID() As Integer        Get            Return M_AccGPID        End Get        Set(ByVal value As Integer)            M_AccGPID = value        End Set    End Property
    Public Property GPSeqNo() As Integer        Get            Return M_GPSeqNo        End Get        Set(ByVal value As Integer)            M_GPSeqNo = value        End Set    End Property
    Public Property AccSeqNo() As Integer        Get            Return M_AccSeqNo        End Get        Set(ByVal value As Integer)            M_AccSeqNo = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property UpdaterID() As Integer        Get            Return M_UpdaterID        End Get        Set(ByVal value As Integer)            M_UpdaterID = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property AccName() As String        Get            Return M_AccName.Trim()        End Get        Set(ByVal value As String)            M_AccName = value.Trim()        End Set    End Property
    Public Property GPName() As String        Get            Return M_GPName.Trim()        End Get        Set(ByVal value As String)            M_GPName = value.Trim()        End Set    End Property
    Public Property AccPosition() As String        Get            Return M_AccPosition.Trim()        End Get        Set(ByVal value As String)            M_AccPosition = value.Trim()        End Set    End Property
    Public Property AccBalType() As String        Get            Return M_AccBalType.Trim()        End Get        Set(ByVal value As String)            M_AccBalType = value.Trim()        End Set    End Property
    Public Property AccALIE() As String        Get            Return M_AccALIE.Trim()        End Get        Set(ByVal value As String)            M_AccALIE = value.Trim()        End Set    End Property
    Public Property AccStatementtype() As String        Get            Return M_AccStatementtype.Trim()        End Get        Set(ByVal value As String)            M_AccStatementtype = value.Trim()        End Set    End Property
    Public Property AccBillBreakup() As String        Get            Return M_AccBillBreakup.Trim()        End Get        Set(ByVal value As String)            M_AccBillBreakup = value.Trim()        End Set    End Property
    Public Property ActiveStatus() As String        Get            Return M_ActiveStatus.Trim()        End Get        Set(ByVal value As String)            M_ActiveStatus = value.Trim()        End Set    End Property
End Class