﻿Public Class TranMasterBO
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
    Public Property TrDate() As Date
    Public Property InvoiceDate() As Date
    Public Property TranID() As Integer
    Public Property ClientID() As Integer
    Public Property CurrencyEntryID() As Integer
    Public Property MakerID() As Integer
    Public Property UpdaterId() As Integer
    Public Property MakingTime() As Date
    Public Property UpdatingTime() As Date
    Public Property RoundOff() As Decimal
    Public Property GrossAmount() As Decimal
    Public Property NetAmount() As Decimal
    Public Property Frieght() As Decimal
    Public Property DiscountOnTotal() As Decimal
    Public Property BillNo() As String
    Public Property ShipmentAddress() As String
    Public Property BillingAddress() As String
    Public Property InvoiceNumber() As String
    Public Property Remarks() As String
    Public Property AutoRoundOff() As String
End Class
