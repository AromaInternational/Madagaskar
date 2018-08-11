Public Class AccLedgerBO
    Private M_AccUNID As Integer
    Private M_AccVrNo As Integer
    Private M_MakerID As Integer
    Private M_UpdaterID As Integer
    Private M_AccTrDate As Date
    Private M_AccChqDate As Date
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_AccId As Long
    Private M_AccVrTyp As String
    Private M_AccFinYear As String
    Private M_AccChqNo As String
    Private M_AccOrgFrom As String
    Private M_AccNarration As String
    Private M_AccType As String
    Private M_ActiveStatus As String
    Public Property AccUNID() As Integer        Get            Return M_AccUNID        End Get        Set(ByVal value As Integer)            M_AccUNID = value        End Set    End Property
    Public Property AccVrNo() As Integer        Get            Return M_AccVrNo        End Get        Set(ByVal value As Integer)            M_AccVrNo = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property UpdaterID() As Integer        Get            Return M_UpdaterID        End Get        Set(ByVal value As Integer)            M_UpdaterID = value        End Set    End Property
    Public Property AccTrDate() As Date        Get            Return M_AccTrDate        End Get        Set(ByVal value As Date)            M_AccTrDate = value        End Set    End Property
    Public Property AccChqDate() As Date        Get            Return M_AccChqDate        End Get        Set(ByVal value As Date)            M_AccChqDate = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property AccId() As Long        Get            Return M_AccId        End Get        Set(ByVal value As Long)            M_AccId = value        End Set    End Property
    Public Property AccVrTyp() As String        Get            Return M_AccVrTyp.Trim()        End Get        Set(ByVal value As String)            M_AccVrTyp = value.Trim()        End Set    End Property
    Public Property AccFinYear() As String        Get            Return M_AccFinYear.Trim()        End Get        Set(ByVal value As String)            M_AccFinYear = value.Trim()        End Set    End Property
    Public Property AccChqNo() As String        Get            Return M_AccChqNo.Trim()        End Get        Set(ByVal value As String)            M_AccChqNo = value.Trim()        End Set    End Property
    Public Property AccOrgFrom() As String        Get            Return M_AccOrgFrom.Trim()        End Get        Set(ByVal value As String)            M_AccOrgFrom = value.Trim()        End Set    End Property
    Public Property AccNarration() As String        Get            Return M_AccNarration.Trim()        End Get        Set(ByVal value As String)            M_AccNarration = value.Trim()        End Set    End Property
    Public Property AccType() As String        Get            Return M_AccType.Trim()        End Get        Set(ByVal value As String)            M_AccType = value.Trim()        End Set    End Property
    Public Property ActiveStatus() As String        Get            Return M_ActiveStatus.Trim()        End Get        Set(ByVal value As String)            M_ActiveStatus = value.Trim()        End Set    End Property
End Class