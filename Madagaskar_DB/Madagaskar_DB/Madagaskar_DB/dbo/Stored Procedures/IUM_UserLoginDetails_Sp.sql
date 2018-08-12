
-- Author       :PRADEEP.T.V
-- Created Date :20/09/2016
-- Exec IUM_UserLoginDetails_Sp
CREATE PROCEDURE [dbo].[IUM_UserLoginDetails_Sp]
(
    @Entry_Mode VARCHAR(15),
	@UL_ID bigint , 
	@UL_UMID int , 
	@UL_Terminal varchar (250), 
	@UL_InDate datetime , 
	@UL_OutDate datetime  
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @NextID	As BigInt, 
			@Sql	As NVarchar(4000) 
	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'UserLoginDetails_M_Tbl','UL_ID',@NextID  OUTPUT 
		SET @UL_ID = @NextID 
	
		INSERT INTO dbo.UserLoginDetails_M_Tbl
		(
			UL_ID,
			UL_UMID,
			UL_Terminal,
			UL_InDate,
			UL_OutDate
		)
		VALUES
		(
			@UL_ID,
			@UL_UMID,
			@UL_Terminal,
			@UL_InDate,
			@UL_OutDate
		)
	END
	ELSE
	BEGIN
		UPDATE dbo.UserLoginDetails_M_Tbl SET 
			UL_OutDate = @UL_OutDate 
		WHERE UL_ID= @UL_ID
	END
	
	SELECT @UL_ID AS ID
	
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

