
CREATE VIEW [dbo].[UnitMasterTree_Vw]
AS
	WITH UnitTree_CTE(Cmp_Code,UN_ID,Cmp_Name,UN_Name,TreeCode,ParrentTreeCode,Active_Status)
	AS
	(
		SELECT C.Cmp_Code,0 UN_ID,C.Cmp_Name, '' UN_Name,
			RIGHT('000' + Cast(C.Cmp_Code As Varchar(3)),3) + '00000'  As TreeCode, 
			RIGHT('000' + Cast(C.Cmp_Code As Varchar(3)),3) + '00000'  As ParrentTreeCode,'Y' Active_Status  
		FROM  CompanyProfile_P_Tbl AS C

		UNION ALL

		SELECT C.Cmp_Code,U.UN_ID,C.Cmp_Name, U.UN_Name,
			RIGHT('000' + Cast(C.Cmp_Code As Varchar(3)),3) + RIGHT('00000' + Cast(U.UN_ID As Varchar(4)),5) As TreeCode,
			RIGHT('000' + Cast(C.Cmp_Code As Varchar(3)),3) + '00000' As ParrentTreeCode,U.Active_Status 
		FROM  CompanyProfile_P_Tbl AS C INNER JOIN 
			UnitMaster_P_Tbl AS U ON C.Cmp_Code = U.UN_CmpCode 
		WHERE U.Active_Status = 'Y'
	)

	SELECT Cmp_Code,UN_ID,Cmp_Name,UN_Name,TreeCode,ParrentTreeCode,Active_Status,
				ROW_NUMBER() OVER(ORDER BY TreeCode) As SlNo
	FROM UnitTree_CTE;

