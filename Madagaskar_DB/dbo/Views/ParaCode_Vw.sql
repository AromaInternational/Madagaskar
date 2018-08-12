
CREATE VIEW [dbo].[ParaCode_Vw]
AS
SELECT        PC.PC_ID, PC.PC_Description, PC.PC_Type, PT.PT_Description, PC.PC_Order, PC.PC_Locked, PC.Active_Status, PC.Maker_ID, PC.Making_Time, PC.Updater_Id, PC.Updating_Time
FROM            dbo.ParaCode_P_Tbl AS PC INNER JOIN
                         dbo.ParaType_P_Tbl AS PT ON PC.PC_Type = PT.PT_ID

