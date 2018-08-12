



CREATE VIEW [dbo].[UserUnitsDetails_Vw]
AS
WITH CTEUserUnitsDetails
AS
(
	SELECT 1 UM_ID,'ADMIN' UM_Name,UN_CmpCode Cmp_Code, Cmp_Name,UN_ID, UN_Name, Active_Status 
	FROM UnitMaster_Vw
                     
	UNION ALL

	SELECT UT.UM_ID,UM_Name,Cmp_Code, Cmp_Name,UN_ID, UN_Name, UN.Active_Status 
	FROM UnitMasterTree_Vw UN JOIN UserUnitDetails_T_Tbl UT ON UN.TreeCode = UT.UN_TreeCode JOIN 
		UserMaster_M_Tbl UM ON UT.UM_ID = UM.UM_ID 
	WHERE UN_ID >0
)
SELECT 
	UM_ID, UM_Name,Cmp_Code, Cmp_Name,UN_ID, UN_Name, Active_Status
FROM CTEUserUnitsDetails









