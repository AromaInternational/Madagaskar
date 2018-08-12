
-- Author       :PRADEEP.T.V
-- Created Date :25/02/2014
-- Exec Get_NextAccVrNo_Sp 1,'PRCH','15-16',@VrNo
CREATE PROCEDURE [dbo].[Get_NextAccVrNo_Sp]
(
    @UNID		As Int,
    @VrTyp		As varchar(10),
	@FinYear	As Varchar(5),
    @VrNo		As BigInt Output
)
AS
BEGIN
	Set NoCount On
    Declare @ID			As Int
    Begin
		SELECT TOP(1) @ID = Acc_VrNo FROM AccLedger_M_Tbl Where Acc_VrTyp = @VrTyp 
			And Acc_UNID = @UNID And Acc_FinYear = @FinYear 
		ORDER BY Acc_VrNo DESC

		Set @ID = IsNull(@ID,0) +1 
		Set @VrNo = @ID
	End
    Set NoCount Off
END



