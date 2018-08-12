

CREATE VIEW [dbo].[UserUnitTreeCodeDetails_Vw]
AS
	WITH CTEUserUnitTreeCodeDetails
	AS
	(
		SELECT U.UM_ID, U.UM_Name, UM.Cmp_Code, UM.UN_ID, UM.Cmp_Name, UM.UN_Name, UM.TreeCode, UM.ParrentTreeCode, UM.SlNo FROM dbo.UserMaster_Vw AS U INNER JOIN dbo.UserUnitDetails_T_Tbl AS UET ON U.UM_ID = UET.UM_ID INNER JOIN dbo.UnitMasterTree_Vw AS UM ON UET.UN_TreeCode = UM.TreeCode
	)
	,
	CTE_UserUnitTreeCodeDetails_Group(UM_ID, UM_Name, Cmp_Code, UN_ID, Cmp_Name, UN_Name, TreeCode, ParrentTreeCode, SlNo)
	AS
	(
		SELECT UM_ID, UM_Name, Cmp_Code, UN_ID, Cmp_Name, UN_Name, TreeCode, ParrentTreeCode, SlNo
		FROM CTEUserUnitTreeCodeDetails GROUP BY UM_ID, UM_Name, Cmp_Code, UN_ID, Cmp_Name, UN_Name, TreeCode, ParrentTreeCode, SlNo
	)

	SELECT UM_ID, UM_Name, Cmp_Code, UN_ID, Cmp_Name, UN_Name, TreeCode, ParrentTreeCode, SlNo FROM CTE_UserUnitTreeCodeDetails_Group;


