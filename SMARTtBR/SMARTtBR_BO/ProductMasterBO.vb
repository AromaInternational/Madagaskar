Public Class ProductMasterBO
    Private M_ProductID As Integer
    Private M_AccountCode As Integer
    Private M_UpdaterId As Integer
    Private M_MakerID As Integer
    Private M_MakingTime As Date
    Private M_UpdatingTime As Date
    Private M_Measurement1Value As Decimal
    Private M_Measurement2Value As Decimal
    Private M_Measurement3Value As Decimal
    Private M_ProductName As String
    Private M_ProductCategory As String
    Private M_Measurement1Text As String
    Private M_Measurement2Text As String
    Private M_Measurement3Text As String
    Private M_MeasurementFinalFormula As String
    Private M_MeasurementFinalText As String
    Public Property ProductID() As Integer        Get            Return M_ProductID        End Get        Set(ByVal value As Integer)            M_ProductID = value        End Set    End Property
    Public Property AccountCode() As Integer        Get            Return M_AccountCode        End Get        Set(ByVal value As Integer)            M_AccountCode = value        End Set    End Property
    Public Property UpdaterId() As Integer        Get            Return M_UpdaterId        End Get        Set(ByVal value As Integer)            M_UpdaterId = value        End Set    End Property
    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property
    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property
    Public Property UpdatingTime() As Date        Get            Return M_UpdatingTime        End Get        Set(ByVal value As Date)            M_UpdatingTime = value        End Set    End Property
    Public Property Measurement1Value() As Decimal        Get            Return M_Measurement1Value        End Get        Set(ByVal value As Decimal)            M_Measurement1Value = value        End Set    End Property
    Public Property Measurement2Value() As Decimal        Get            Return M_Measurement2Value        End Get        Set(ByVal value As Decimal)            M_Measurement2Value = value        End Set    End Property
    Public Property Measurement3Value() As Decimal        Get            Return M_Measurement3Value        End Get        Set(ByVal value As Decimal)            M_Measurement3Value = value        End Set    End Property
    Public Property ProductName() As String        Get            Return M_ProductName.Trim()        End Get        Set(ByVal value As String)            M_ProductName = value.Trim()        End Set    End Property
    Public Property ProductCategory() As String        Get            Return M_ProductCategory.Trim()        End Get        Set(ByVal value As String)            M_ProductCategory = value.Trim()        End Set    End Property
    Public Property Measurement1Text() As String        Get            Return M_Measurement1Text.Trim()        End Get        Set(ByVal value As String)            M_Measurement1Text = value.Trim()        End Set    End Property
    Public Property Measurement2Text() As String        Get            Return M_Measurement2Text.Trim()        End Get        Set(ByVal value As String)            M_Measurement2Text = value.Trim()        End Set    End Property
    Public Property Measurement3Text() As String        Get            Return M_Measurement3Text.Trim()        End Get        Set(ByVal value As String)            M_Measurement3Text = value.Trim()        End Set    End Property
    Public Property MeasurementFinalFormula() As String        Get            Return M_MeasurementFinalFormula.Trim()        End Get        Set(ByVal value As String)            M_MeasurementFinalFormula = value.Trim()        End Set    End Property
    Public Property MeasurementFinalText() As String        Get            Return M_MeasurementFinalText.Trim()        End Get        Set(ByVal value As String)            M_MeasurementFinalText = value.Trim()        End Set    End Property

End Class
