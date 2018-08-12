
-- Author       :PRADEEP.T.V
-- Created Date :17/09/2016
-- Exec IUM_UserPwdChange_Sp
CREATE PROCEDURE [dbo].[IUM_UserPwdChange_Sp]
(
    @Entry_Mode			VARCHAR(15),
    @MM_ID				INT, 
	@UP_ID				bigint , 
	@UP_UMID			int , 
	@UP_CurrPwd			varchar(50), 
	@UP_NewPwd			varchar(50), 
	@Maker_ID			int , 
	@Making_Time		datetime  
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @NextID	As BigInt, 
			@Sql	As NVarchar(4000) 
	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'UserPwdChange_M_Tbl','UP_ID',@NextID  OUTPUT 
		SET @UP_ID = @NextID 
	
		INSERT INTO dbo.UserPwdChange_M_Tbl
		(
			UP_ID,
			UP_UMID,
			UP_CurrPwd,
			UP_NewPwd,
			Maker_ID,
			Making_Time
		)
		SELECT
			@UP_ID,
			@UP_UMID,
			Cast(@UP_CurrPwd As Varbinary(50)),
			Cast(@UP_NewPwd As Varbinary(50)),
			@Maker_ID,
			@Making_Time
	END
	ELSE
	BEGIN
		UPDATE dbo.UserPwdChange_M_Tbl SET 
			UP_UMID = @UP_UMID ,
			UP_CurrPwd = Cast(@UP_CurrPwd As Varbinary(50)) ,
			UP_NewPwd = Cast(@UP_NewPwd As Varbinary(50)) 
		WHERE UP_ID= @UP_ID
	END
	

	UPDATE dbo.UserMaster_M_Tbl SET UM_Pwd  = Cast(@UP_NewPwd As Varbinary(50)) WHERE UM_ID = @UP_UMID 

	SELECT @UP_ID AS ID
	
	Commit Tran X1
	Set Nocount ON
	Return
 End Try
 Begin Catch
Error_Point:
		Declare @ErroMsg Varchar(1000)
		Set @ErroMsg='Proc: '+ERROR_PROCEDURE()+' Msg: '+ERROR_MESSAGE()
		RAISERROR(@ErroMsg, 16, 1)
		SELECT 0 AS ID
		Rollback Tran X1
		Return
	End Catch
END



