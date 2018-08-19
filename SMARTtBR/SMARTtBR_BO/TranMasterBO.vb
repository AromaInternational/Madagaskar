Public Class TranMasterBO
    Private M_TrDate As Date
    Private M_InvoiceDate As Date
    Private M_TranID As Integer
    Private M_ClientID As Integer
    Private M_CurrencyEntryID As Integer
    Private M_MakerID As Integer
    Private M_UpdaterId As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_RoundOff As Decimal
    Private M_GrossAmount As Decimal
    Private M_NetAmount As Decimal
    Private M_Frieght As Decimal
    Private M_DiscountOnTotal As Decimal
    Private M_BillNo As String
    Private M_ShipmentAddress As String
    Private M_BillingAddress As String
    Private M_InvoiceNumber As String
    Private M_Remarks As String
    Private M_AutoRoundOff As String
    Public Property TrDate() As Date        Get            Return M_TrDate        End Get        Set(ByVal value As Date)            M_TrDate = value        End Set    End Property
    Public Property InvoiceDate() As Date        Get            Return M_InvoiceDate        End Get        Set(ByVal value As Date)            M_InvoiceDate = value        End Set    End Property
    Public Property TranID() As Integer        Get            Return M_TranID        End Get        Set(ByVal value As Integer)            M_TranID = value        End Set    End Property
    Public Property ClientID() As Integer        Get            Return M_ClientID        End Get        Set(ByVal value As Integer)            M_ClientID = value        End Set    End Property
    Public Property CurrencyEntryID() As Integer        Get            Return M_CurrencyEntryID        End Get        Set(ByVal value As Integer)            M_CurrencyEntryID = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property UpdaterId() As Integer        Get            Return M_UpdaterId        End Get        Set(ByVal value As Integer)            M_UpdaterId = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property RoundOff() As Decimal        Get            Return M_RoundOff        End Get        Set(ByVal value As Decimal)            M_RoundOff = value        End Set    End Property
    Public Property GrossAmount() As Decimal        Get            Return M_GrossAmount        End Get        Set(ByVal value As Decimal)            M_GrossAmount = value        End Set    End Property
    Public Property NetAmount() As Decimal        Get            Return M_NetAmount        End Get        Set(ByVal value As Decimal)            M_NetAmount = value        End Set    End Property
    Public Property Frieght() As Decimal        Get            Return M_Frieght        End Get        Set(ByVal value As Decimal)            M_Frieght = value        End Set    End Property
    Public Property DiscountOnTotal() As Decimal        Get            Return M_DiscountOnTotal        End Get        Set(ByVal value As Decimal)            M_DiscountOnTotal = value        End Set    End Property
    Public Property BillNo() As String        Get            Return M_BillNo.Trim()        End Get        Set(ByVal value As String)            M_BillNo = value.Trim()        End Set    End Property
    Public Property ShipmentAddress() As String        Get            Return M_ShipmentAddress.Trim()        End Get        Set(ByVal value As String)            M_ShipmentAddress = value.Trim()        End Set    End Property
    Public Property BillingAddress() As String        Get            Return M_BillingAddress.Trim()        End Get        Set(ByVal value As String)            M_BillingAddress = value.Trim()        End Set    End Property
    Public Property InvoiceNumber() As String        Get            Return M_InvoiceNumber.Trim()        End Get        Set(ByVal value As String)            M_InvoiceNumber = value.Trim()        End Set    End Property
    Public Property Remarks() As String        Get            Return M_Remarks.Trim()        End Get        Set(ByVal value As String)            M_Remarks = value.Trim()        End Set    End Property
    Public Property AutoRoundOff() As String        Get            Return M_AutoRoundOff.Trim()        End Get        Set(ByVal value As String)            M_AutoRoundOff = value.Trim()        End Set    End Property
End Class

