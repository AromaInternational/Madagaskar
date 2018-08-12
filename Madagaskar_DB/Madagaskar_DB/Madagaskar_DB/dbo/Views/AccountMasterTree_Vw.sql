


CREATE VIEW [dbo].[AccountMasterTree_Vw]
AS
	WITH AccountTree_CTE(Cmp_Code,Cmp_Name,GP_ID,GP_Name,Acc_Code,Acc_Name,TreeCode,ParrentTreeCode,Active_Status)
	AS
	(
		SELECT Cmp_Code,Cmp_Name,GP_ID,GP_Name,0 Acc_Code, '' Acc_Name,
			RIGHT('000' + Cast(G.GP_ID As Varchar(3)),3) + '00000'  As TreeCode, 
			RIGHT('000' + Cast(G.GP_ID As Varchar(3)),3) + '00000'  As ParrentTreeCode,Active_Status  
		FROM  AccountGroup_P_Tbl AS G CROSS APPLY 
				CompanyProfile_P_Tbl C 

		UNION ALL

		SELECT Cmp_Code,Cmp_Name,GP_ID,GP_Name,Acc_Code,Acc_Name,
			RIGHT('000' + Cast(GP_ID As Varchar(3)),3) + RIGHT('00000' + Cast(A.Acc_Code As Varchar(4)),5) As TreeCode,
			RIGHT('000' + Cast(GP_ID As Varchar(3)),3) + '00000' As ParrentTreeCode,A.Active_Status 
		FROM  AccountGroup_P_Tbl AS G INNER JOIN 
			AccountMaster_P_Tbl AS A ON A.Acc_GPID = G.GP_ID INNER JOIN
			CompanyProfile_P_Tbl C ON A.Acc_CmpCode = C.Cmp_Code 
		WHERE A.Active_Status = 'Y' AND G.Active_Status = 'Y'
	)

	SELECT Cmp_Code,Cmp_Name,GP_ID,GP_Name,Acc_Code,Acc_Name,TreeCode,ParrentTreeCode,Active_Status,
				ROW_NUMBER() OVER(ORDER BY TreeCode) As SlNo
	FROM AccountTree_CTE;



