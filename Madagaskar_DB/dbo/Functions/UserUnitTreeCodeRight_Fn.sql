

-- Author       :PRADEEP.T.V
-- Created Date :20/02/2016
-- SELECT * FROM  dbo.UserUnitTreeCodeRight_Fn(130104)
CREATE FUNCTION [dbo].[UserUnitTreeCodeRight_Fn]
(	
	@UserID		Int
)
RETURNS @Details Table 
(
	UN_ID				Int,
	TreeCode			Varchar(50)
)
AS
BEGIN
	
	IF @UserID = 1 
	Begin
		INSERT INTO @Details(UN_ID,TreeCode)
		SELECT UN_ID,A.TreeCode FROM UnitMasterTree_Vw A 
	End
	Else
	Begin
		WITH CTEUserUnitTreeCodeRight
		AS
		(
			SELECT  A.UN_ID,A.TreeCode FROM UnitMasterTree_Vw A JOIN UserUnitTreeCodeDetails_Vw B ON A.Cmp_Code = B.Cmp_Code WHERE B.UM_ID = @UserID AND A.Cmp_Code > 0 AND A.UN_ID =0 
			UNION ALL
			SELECT  A.UN_ID,A.TreeCode FROM UnitMasterTree_Vw A JOIN UserUnitTreeCodeDetails_Vw B ON A.Cmp_Code = B.Cmp_Code AND A.UN_ID = B.UN_ID  WHERE B.UM_ID = @UserID AND A.Cmp_Code > 0 AND A.UN_ID > 0
		)
		,
		CTE_UserUnitTreeCodeRight_Group(UN_ID,TreeCode)
		AS
		(
			SELECT UN_ID,TreeCode
			FROM CTEUserUnitTreeCodeRight GROUP BY UN_ID,TreeCode
		)

		INSERT INTO @Details(UN_ID,TreeCode)
		SELECT UN_ID,TreeCode FROM CTE_UserUnitTreeCodeRight_Group;
	End

    Return
END


