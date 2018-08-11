Imports SMARTtBR_CO.CommonClass
Public Class CommonSettingsBO
    Private M_OnBrCode As Integer
    Private M_CSID As Integer
    Private M_CSDisplayName As String
    Private M_CSTableName As String
    Private M_CSFieldName As String
    Private M_CSDataLength As String
    Private M_CSFilterField As String
    Private M_CSDataType As String
    Private M_CSISUserDefind As String
    Private M_CSValue As Object

    Public Property CSValue() As Object
        Get
            Return M_CSValue
        End Get
        Set(ByVal value As Object)
            M_CSValue = value
        End Set
    End Property

    Public Property CSID() As Integer
        Get
            Return M_CSID
        End Get
        Set(ByVal value As Integer)
            M_CSID = value
        End Set
    End Property

    Public Property CSDisplayName() As String
        Get
            Return M_CSDisplayName
        End Get
        Set(ByVal value As String)
            M_CSDisplayName = value
        End Set
    End Property
    Public Property CSTableName() As String
        Get
            Return M_CSTableName
        End Get
        Set(ByVal value As String)
            M_CSTableName = value
        End Set
    End Property
    Public Property CSFieldName() As String
        Get
            Return M_CSFieldName
        End Get
        Set(ByVal value As String)
            M_CSFieldName = value
        End Set
    End Property
    Public Property CSDataLength() As String
        Get
            Return M_CSDataLength
        End Get
        Set(ByVal value As String)
            M_CSDataLength = value
        End Set
    End Property
    Public Property CSFilterField() As String
        Get
            Return M_CSFilterField
        End Get
        Set(ByVal value As String)
            M_CSFilterField = value
        End Set
    End Property
    Public Property CSDataType() As String
        Get
            Return M_CSDataType
        End Get
        Set(ByVal value As String)
            M_CSDataType = value
        End Set
    End Property
    Public Property CSISUserDefind() As String
        Get
            Return M_CSISUserDefind
        End Get
        Set(ByVal value As String)
            M_CSISUserDefind = value
        End Set
    End Property

End Class