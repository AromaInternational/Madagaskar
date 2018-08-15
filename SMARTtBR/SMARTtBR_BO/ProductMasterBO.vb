﻿Public Class ProductMasterBO
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
    Public Property ProductID() As Integer
    Public Property AccountCode() As Integer
    Public Property UpdaterId() As Integer
    Public Property MakerID() As Integer
    Public Property MakingTime() As Date
    Public Property UpdatingTime() As Date
    Public Property Measurement1Value() As Decimal
    Public Property Measurement2Value() As Decimal
    Public Property Measurement3Value() As Decimal
    Public Property ProductName() As String
    Public Property ProductCategory() As String
    Public Property Measurement1Text() As String
    Public Property Measurement2Text() As String
    Public Property Measurement3Text() As String
    Public Property MeasurementFinalFormula() As String
    Public Property MeasurementFinalText() As String

End Class