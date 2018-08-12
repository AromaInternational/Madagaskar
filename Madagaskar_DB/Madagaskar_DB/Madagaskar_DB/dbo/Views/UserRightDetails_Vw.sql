
CREATE VIEW [dbo].[UserRightDetails_Vw]
AS
WITH CTEUserRightDetails
AS
(
	SELECT 1 UM_ID,'ADMIN' UM_Name, MM.MM_ID, MM.MM_MainID, MM.MM_SubID, MM.MM_SubChildID, MM.MM_Name,MM.MM_ShortKey, MM.MM_Caption, MM.MM_FormName, 
		MM.MM_AllowMultipleInstance, MM.MM_Active,MM.MM_ShowInMenu,'Y' UR_View, 'Y'UR_Add, 'Y' UR_Edit,'Y' UR_Delete, 'Y' UR_Print, 'Y' UR_Authn,
		Case When (SELECT COUNT(MM_ID) FROM MenuMaster_P_Tbl S WHERE S.MM_SubID = MM.MM_SubID AND S.MM_MainID = MM.MM_MainID AND MM.MM_SubChildID =0 )>1 Then 'Y' Else 'N' End As HasChild
	FROM dbo.MenuMaster_P_Tbl AS MM
                         
	UNION ALL

	SELECT UM.UM_ID, UM.UM_Name, MM.MM_ID, MM.MM_MainID, MM.MM_SubID, MM.MM_SubChildID, MM.MM_Name,MM.MM_ShortKey, MM.MM_Caption,MM.MM_FormName, 
		MM.MM_AllowMultipleInstance, MM.MM_Active,MM.MM_ShowInMenu, IsNull(UR.UR_View,'N') UR_View, IsNull(UR.UR_Add,'N') UR_Add, IsNull(UR.UR_Edit,'N') UR_Edit, 
		IsNull(UR.UR_Delete,'N') UR_Delete, IsNull(UR.UR_Print,'N') UR_Print,IsNull(UR.UR_Authn,'N') UR_Authn,
		Case When (SELECT COUNT(MM_ID) FROM MenuMaster_P_Tbl S WHERE S.MM_SubID = MM.MM_SubID AND S.MM_MainID = MM.MM_MainID AND MM.MM_SubChildID =0 )>1 Then 'Y' Else 'N' End As HasChild
	FROM dbo.UserMaster_M_Tbl AS UM CROSS JOIN dbo.MenuMaster_P_Tbl AS MM LEFT JOIN dbo.UserRights_M_Tbl AS UR ON UR.UR_MMID = MM.MM_ID AND UM.UM_ID = UR.UR_UMID 
)
SELECT 
	UM_ID, UM_Name, MM_ID, MM_MainID, MM_SubID, MM_SubChildID,HasChild, MM_Name,MM_ShortKey, MM_Caption, MM_FormName, MM_AllowMultipleInstance, MM_Active,MM_ShowInMenu, UR_View, UR_Add, UR_Edit,UR_Delete,UR_Print,UR_Authn
FROM CTEUserRightDetails







