

-- Author       :PRADEEP.T.V
-- Created Date :20/02/2016
-- SELECT * FROM  dbo.UserUnitTreeCode_Fn(130104) ORDER BY TreeCode
CREATE FUNCTION [dbo].[UserUnitTreeCode_Fn]
(	
	@UserID		Int
)
RETURNS @Details Table 
(
	TreeCode			Varchar(50)
)
AS
BEGIN
	
	IF @UserID = 1 
	Begin
		INSERT INTO @Details(TreeCode)
		SELECT A.TreeCode FROM UnitMasterTree_Vw A 
	End
	Else
	Begin
		WITH CTEUserUnitTreeCode
		AS
		(
			SELECT A.TreeCode FROM UnitMasterTree_Vw A JOIN UserUnitTreeCodeDetails_Vw B ON A.Cmp_Code = B.Cmp_Code WHERE B.UM_ID = @UserID AND A.Cmp_Code > 0 AND A.UN_ID =0 
			UNION ALL
			SELECT A.TreeCode FROM UnitMasterTree_Vw A JOIN UserUnitTreeCodeDetails_Vw B ON A.Cmp_Code = B.Cmp_Code AND A.UN_ID = B.UN_ID  WHERE B.UM_ID = @UserID AND A.Cmp_Code > 0 AND A.UN_ID > 0
			UNION ALL
			SELECT A.TreeCode FROM UnitMasterTree_Vw A Where Exists (SELECT 1 FROM UserUnitTreeCodeDetails_Vw B WHERE A.ParrentTreeCode = B.TreeCode And B.UM_ID = @UserID)
			UNION ALL
			SELECT A.TreeCode FROM UnitMasterTree_Vw A Where Exists (SELECT 1 FROM UnitMasterTree_Vw B Where A.ParrentTreeCode = B.TreeCode And Exists (SELECT 1 FROM UserUnitTreeCodeDetails_Vw C WHERE B.ParrentTreeCode = C.TreeCode And C.UM_ID = @UserID))
			UNION ALL
			SELECT A.TreeCode FROM UnitMasterTree_Vw A Where Exists (SELECT 1 FROM UnitMasterTree_Vw B Where A.ParrentTreeCode = B.TreeCode And Exists (SELECT 1 FROM UnitMasterTree_Vw C Where B.ParrentTreeCode = C.TreeCode And Exists (SELECT 1 FROM UserUnitTreeCodeDetails_Vw D WHERE C.ParrentTreeCode = D.TreeCode And D.UM_ID = @UserID)) )
		)
		,
		CTE_UserUnitTreeCode_Group(TreeCode)
		AS
		(
			SELECT TreeCode
			FROM CTEUserUnitTreeCode GROUP BY TreeCode
		)

		INSERT INTO @Details(TreeCode)
		SELECT TreeCode FROM CTE_UserUnitTreeCode_Group;
	End

    Return
END


