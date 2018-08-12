
-- Author       :PRADEEP.T.V
-- Created Date :30/08/2014
-- Exec Fill_UserUnitDetails_Fn
CREATE FUNCTION [dbo].[Fill_UserUnitDetails_Fn]
(	
	@User_Id		BigInt,
	@Filter_UNID	Int = 0
)
RETURNS @UnitDetails Table 
(
	Cmp_Code		Int,
	UN_ID			Int,
	Active_Status	Char(1)
)
AS
BEGIN
	IF @User_Id = 1
	Begin
		Insert Into @UnitDetails (Cmp_Code,UN_ID,Active_Status) 
		SELECT UN_CmpCode,UN_ID,Active_Status FROM UnitMaster_P_Tbl
	End
	Else
	Begin
		Insert Into @UnitDetails (Cmp_Code,UN_ID,Active_Status) 
		SELECT UN_CmpCode,UN_ID,Active_Status FROM UnitMaster_P_Tbl M
		WHERE Exists(Select 1 From UserUnitsDetails_Vw U Where UM_ID = @User_Id And M.UN_ID = U.UN_ID)
	End
		
	IF @Filter_UNID >0 
	Begin
		Delete From @UnitDetails Where UN_ID <> @Filter_UNID 
	End

    Return
END

