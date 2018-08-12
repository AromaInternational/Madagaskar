
CREATE VIEW [dbo].[ReportNames_Vw]
AS
SELECT        RN.RN_Id, RN.RN_Description, RN.RN_Name, RN.RN_Type, RT.RT_Description, RN.RN_Order, RN.Active_Status
FROM            dbo.ReportNames_P_Tbl AS RN INNER JOIN
                         dbo.ReportType_P_Tbl AS RT ON RN.RN_Type = RT.RT_Code

