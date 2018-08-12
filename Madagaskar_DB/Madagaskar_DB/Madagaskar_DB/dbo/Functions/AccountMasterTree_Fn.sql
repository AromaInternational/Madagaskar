

-- Author       :PRADEEP.T.V
-- Created Date :15/11/2014
-- SELECT * FROM  dbo.AccountMasterTree_Fn(1,'Y','ID')
CREATE FUNCTION [dbo].[AccountMasterTree_Fn]
(	
	@CmpCode	Int,
	@WithHead	Char(1) = 'N',
	@SortType	Char(5) = 'ID'
)
RETURNS @Details Table 
(
	[Key]		Int,
	ID			varchar(10),
	Name		Varchar(100),
	KeyParent	Int,
	UnderID		Varchar(10),
	ItemType	Varchar(10),
	[Status]	char(1),
	[Level]		Int
)
AS
BEGIN
	IF @WithHead = 'N'
	Begin
		IF @CmpCode > 0
		Begin
			INSERT INTO @Details([Key],ID,Name,KeyParent,UnderID,ItemType,[Status],[Level]) 
			SELECT ROW_NUMBER() Over (Order by TreeCode) [Key],TreeCode,
				Case 
					When Acc_Code =0 Then GP_Name 
					When Acc_Code >0 Then Acc_Name 
				End Name , 0, ParrentTreeCode,Case When Acc_Code > 0 Then 'HEAD' Else 'GROUP' End ,Active_Status,0
			From AccountMasterTree_Vw M WHERE Cmp_Code = @CmpCode
			ORDER BY TreeCode
		End
		Else
		Begin
			INSERT INTO @Details([Key],ID,Name,KeyParent,UnderID,ItemType,[Status],[Level]) 
			SELECT ROW_NUMBER() Over (Order by TreeCode) [Key],TreeCode,
				Case 
					When Acc_Code =0 Then GP_Name 
					When Acc_Code >0 Then Acc_Name
				End Name , 0, ParrentTreeCode,Case When Acc_Code > 0 Then 'HEAD' Else 'GROUP' End ,Active_Status,0
			From AccountMasterTree_Vw M 
			ORDER BY TreeCode
		End
	End
	Else
	Begin
		IF @CmpCode > 0
		Begin
			INSERT INTO @Details([Key],ID,Name,KeyParent,UnderID,ItemType,[Status],[Level]) 
			SELECT ROW_NUMBER() Over (Order by TreeCode) [Key],TreeCode,
				Case 
					When Acc_Code =0 Then GP_Name 
					When Acc_Code >0 Then Acc_Name 
				End Name , 0, ParrentTreeCode,Case When Acc_Code > 0 Then 'HEAD' Else 'GROUP' End ,Active_Status,0
			From AccountMasterTree_Vw M WHERE Cmp_Code = @CmpCode
				AND Exists(SELECT 1 FROM AccountMaster_Vw A WHERE A.Acc_GPID = M.GP_ID)
			ORDER BY TreeCode
		End
		Else
		Begin
			INSERT INTO @Details([Key],ID,Name,KeyParent,UnderID,ItemType,[Status],[Level]) 
			SELECT ROW_NUMBER() Over (Order by TreeCode) [Key],TreeCode,
				Case 
					When Acc_Code =0 Then GP_Name 
					When Acc_Code >0 Then Acc_Name
				End Name , 0, ParrentTreeCode,Case When Acc_Code > 0 Then 'HEAD' Else 'GROUP' End ,Active_Status,0
			From AccountMasterTree_Vw M WHERE Exists(SELECT 1 FROM AccountMaster_Vw A WHERE A.Acc_GPID = M.GP_ID)
			ORDER BY TreeCode
		End
	End


	UPDATE M SET KeyParent = (SELECT TOP(1) P.[Key] FROM @Details P WHERE M.UnderID = P.ID) FROM @Details M 

    Return
END



