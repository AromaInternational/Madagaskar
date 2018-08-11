Public MustInherit Class ConnectionType
    Private Const KSQL As String = "SQL"
    Private Const KODBC As String = "ODBC"
    Private Const KOLEDB As String = "OLEDB"
    Private Const KORACLE As String = "ORACLE"

    Public ReadOnly Property SQL() As String
        Get
            Return KSQL
        End Get
    End Property

    Public ReadOnly Property ODBC() As String
        Get
            Return KODBC
        End Get
    End Property

    Public ReadOnly Property OLEDB() As String
        Get
            Return KOLEDB
        End Get
    End Property

    Public ReadOnly Property ORACLE() As String
        Get
            Return KORACLE
        End Get
    End Property

End Class
