
CREATE VIEW ProductMaser_Vw 
AS
Select *,
	ProductName
	+Case WHEN LEN(Measurement1_Text)>0 Then ' '+Measurement1_Text+': '+CAST(Measurement1_Value AS VARCHAR(20))+' cm' ELSE '' End 
	+Case WHEN LEN(Measurement2_Text)>0 Then ', ' +Measurement2_Text+': '+CAST(Measurement2_Value AS VARCHAR(20))+' cm' ELSE '' End 
	+Case WHEN LEN(Measurement3_Text)>0 Then ', ' +Measurement3_Text+': '+CAST(Measurement3_Value AS VARCHAR(20))+' cm' ELSE '' End 
	+Case WHEN LEN(MeasurementFinal_Text)>0 Then ', ' +MeasurementFinal_Text+': '+CAST(MeasurementFinal_Value AS VARCHAR(20))+' cm' ELSE '' End 
	AS ProductName_Detailed 
FROM ProductMaster_M_Tbl