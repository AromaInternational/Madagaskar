

-- Author       :PRADEEP.T.V
-- Created Date :30/08/2014
-- Exec UserUnitDetails_Fn
CREATE FUNCTION [dbo].[UserUnitDetails_Fn]
(	
	@User_ID		BigInt,
	@Filter_UNID	Int = 0
)
RETURNS @UnitDetails Table 
(
	UN_ID			Int,
	Active_Status	Char(1)
)
AS
BEGIN
	IF @User_ID = 1
	Begin
		Insert Into @UnitDetails (UN_ID,Active_Status) 
		SELECT UN_ID,Active_Status FROM UnitMaster_P_Tbl
	End
	Else
	Begin
		Insert Into @UnitDetails (UN_ID,Active_Status) 
		SELECT UN_ID,Active_Status FROM UnitMaster_P_Tbl B
		WHERE Exists(Select 1 From UserUnitDetails_T_Tbl U Where UM_ID = @User_Id And B.UN_ID = U.UN_ID)
	End
		
	IF @Filter_UNID >0 
	Begin
		Delete From @UnitDetails Where UN_ID <> @Filter_UNID 
	End

    Return
END



