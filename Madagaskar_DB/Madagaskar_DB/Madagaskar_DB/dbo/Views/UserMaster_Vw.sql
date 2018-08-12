
CREATE VIEW [dbo].[UserMaster_Vw]
AS
SELECT        UM.UM_ID, UM.UM_DepID, IsNull(Dep.Dep_Name,'') UM_Department, UM.UM_DesID, IsNull(Desg.Des_Name,'') UM_Designation, UM.UM_TypeID, UM.UM_Name, UM.UM_Pwd, CONVERT(varchar(50), UM.UM_Pwd) AS PWD, UM.UM_UNID, IsNull(UnM.UN_Name,'') UM_Unit,UM.UM_AutoLogOutPeriod,UM.Active_Status,UM.Maker_ID,UM.Making_Time,UM.Updater_ID,UM.Updating_Time
FROM            dbo.UserMaster_M_Tbl AS UM LEFT JOIN
                         dbo.Department_P_Tbl AS Dep ON UM.UM_DepID = Dep.Dep_ID LEFT JOIN
                         dbo.Designation_P_Tbl AS Desg ON UM.UM_DesID = Desg.Des_ID LEFT JOIN
                         dbo.UnitMaster_P_Tbl AS UnM ON UM.UM_UNID = UnM.UN_ID


