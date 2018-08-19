
CREATE VIEW Transaction_Vw 
AS

Select 
M.TranID,M.BillNo,M.TrDate,M.ClientID,M.ShipmentAddress,M.BillingAddress,M.InvoiceDate,M.InvoiceNumber,M.RoundOff
,M.GrossAmount,M.NetAmount,M.Frieght,M.DiscountOnTotal,M.CurrencyEntryID,M.Remarks,M.AutoRoundOff
,D.ProductID,D.TranSeqNo,D.MeasurementFinal_Value
,D.Quantity,D.Rate,D.Price,D.DiscountType,D.DiscountPercent,D.DiscountAmount,D.Description
,P.ProductName,P.ProductName_Detailed
FROM TransactionMaster_T_Tbl M
JOIN TransactionDetails_T_Tbl D ON D.TranID=M.TranID
JOIN ProductMaser_Vw P ON P.ProductID=D.ProductID