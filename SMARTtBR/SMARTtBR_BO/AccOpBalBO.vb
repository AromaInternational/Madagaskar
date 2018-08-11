Public Class AccOpBalBO
    Private M_AccOpId As Integer
    Private M_AccUNID As Integer
    Private M_AccCode As Integer
    Private M_GPID As Integer
    Private M_GPSeqNo As Integer
    Private M_AccSeqNo As Integer
    Private M_FinPeriod As String
    Private M_AccBalType As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_Expr1 As Integer
    Private M_AccOpDate As Date
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_AccBalance As Double
    Private M_AccCrBalance As Double
    Private M_AccDrBalance As Double
    Private M_AccName As String
    Private M_GPName As String
    Private M_AccPosition As String
    Private M_AccOpMode As String
    Private M_AccStatementtype As String
    Private M_AccALIE As String
    Private M_ActiveStatus As String
    Public Property AccOpId() As Integer        Get            Return M_AccOpId        End Get        Set(ByVal value As Integer)            M_AccOpId = value        End Set    End Property
    Public Property AccUNID() As Integer        Get            Return M_AccUNID        End Get        Set(ByVal value As Integer)            M_AccUNID = value        End Set    End Property
    Public Property AccCode() As Integer        Get            Return M_AccCode        End Get        Set(ByVal value As Integer)            M_AccCode = value        End Set    End Property
    Public Property GPID() As Integer        Get            Return M_GPID        End Get        Set(ByVal value As Integer)            M_GPID = value        End Set    End Property
    Public Property GPSeqNo() As Integer        Get            Return M_GPSeqNo        End Get        Set(ByVal value As Integer)            M_GPSeqNo = value        End Set    End Property
    Public Property AccSeqNo() As Integer        Get            Return M_AccSeqNo        End Get        Set(ByVal value As Integer)            M_AccSeqNo = value        End Set    End Property
    Public Property FinPeriod() As String        Get            Return M_FinPeriod        End Get        Set(ByVal value As String)            M_FinPeriod = value        End Set    End Property
    Public Property AccBalType() As Integer        Get            Return M_AccBalType        End Get        Set(ByVal value As Integer)            M_AccBalType = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property UpdaterID() As Integer        Get            Return M_UpdaterID        End Get        Set(ByVal value As Integer)            M_UpdaterID = value        End Set    End Property
    Public Property AccOpDate() As Date        Get            Return M_AccOpDate        End Get        Set(ByVal value As Date)            M_AccOpDate = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property AccBalance() As Double        Get            Return M_AccBalance        End Get        Set(ByVal value As Double)            M_AccBalance = value        End Set    End Property
    Public Property AccCrBalance() As Double        Get            Return M_AccCrBalance        End Get        Set(ByVal value As Double)            M_AccCrBalance = value        End Set    End Property
    Public Property AccDrBalance() As Double        Get            Return M_AccDrBalance        End Get        Set(ByVal value As Double)            M_AccDrBalance = value        End Set    End Property
    Public Property AccName() As String        Get            Return M_AccName.Trim()        End Get        Set(ByVal value As String)            M_AccName = value.Trim()        End Set    End Property
    Public Property GPName() As String        Get            Return M_GPName.Trim()        End Get        Set(ByVal value As String)            M_GPName = value.Trim()        End Set    End Property
    Public Property AccPosition() As String        Get            Return M_AccPosition.Trim()        End Get        Set(ByVal value As String)            M_AccPosition = value.Trim()        End Set    End Property
    Public Property AccOpMode() As String        Get            Return M_AccOpMode.Trim()        End Get        Set(ByVal value As String)            M_AccOpMode = value.Trim()        End Set    End Property
    Public Property AccStatementtype() As String        Get            Return M_AccStatementtype.Trim()        End Get        Set(ByVal value As String)            M_AccStatementtype = value.Trim()        End Set    End Property
    Public Property AccALIE() As String        Get            Return M_AccALIE.Trim()        End Get        Set(ByVal value As String)            M_AccALIE = value.Trim()        End Set    End Property
    Public Property ActiveStatus() As String        Get            Return M_ActiveStatus.Trim()        End Get        Set(ByVal value As String)            M_ActiveStatus = value.Trim()        End Set    End Property

    Property Expr1 As Object

End Class