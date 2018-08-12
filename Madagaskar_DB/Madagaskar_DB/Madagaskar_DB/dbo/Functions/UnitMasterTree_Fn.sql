
-- Author       :PRADEEP.T.V
-- Created Date :20/02/2016
-- SELECT * FROM  dbo.UnitMasterTree_Fn(1,1,'ID')
CREATE FUNCTION [dbo].[UnitMasterTree_Fn]
(	
	@CmpCode	Int,
	@UserID		Int,
	@SortType	Char(5) = 'ID'
)
RETURNS @Details Table 
(
	[Key]		Int,
	ID			VARCHAR(50),
	Name		Varchar(100),
	KeyParent	Int,
	UnderID		VARCHAR(50),
	ItemType	Varchar(10),
	[Status]	Char(1),
	[Level]		Int
)
AS
BEGIN
	
	IF @CmpCode > 0
	Begin
		INSERT INTO @Details([Key],ID,Name,KeyParent,UnderID,ItemType,[Status],[Level]) 
		SELECT ROW_NUMBER() Over (Order by TreeCode) [Key],TreeCode,
			Case 
				When UN_ID =0 Then Cmp_Name 
				When UN_ID >0 Then UN_Name 
			End Name , 0, ParrentTreeCode,Case When UN_ID > 0 Then 'HEAD' Else 'GROUP' End ,Active_Status,0
		From UnitMasterTree_Vw M WHERE 1 = 1
			AND Exists(SELECT 1 FROM  dbo.UserUnitTreeCode_Fn(@UserID) As R WHERE M.TreeCode = R.TreeCode)
			AND Cmp_Code = @CmpCode
		ORDER BY TreeCode
	End
	Else
	Begin
		INSERT INTO @Details([Key],ID,Name,KeyParent,UnderID,ItemType,[Status],[Level]) 
		SELECT ROW_NUMBER() Over (Order by TreeCode) [Key],TreeCode,
			Case 
				When UN_ID =0 Then Cmp_Name 
				When UN_ID >0 Then UN_Name 
			End Name , 0, ParrentTreeCode,Case When UN_ID > 0 Then 'HEAD' Else 'GROUP' End ,Active_Status,0
		From UnitMasterTree_Vw M WHERE 1 = 1
			AND Exists(SELECT 1 FROM  dbo.UserUnitTreeCode_Fn(@UserID) As R WHERE M.TreeCode = R.TreeCode)
		ORDER BY TreeCode
	End
	UPDATE M SET KeyParent = (SELECT TOP(1) P.[Key] FROM @Details P WHERE M.UnderID = P.ID) FROM @Details M 

    Return
END

