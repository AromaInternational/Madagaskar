-- Author       :PRADEEP.T.V
-- Created Date :25/02/2017
-- Exec IUM_AccOpBal_Sp
CREATE PROCEDURE IUM_AccOpBal_Sp(    @Entry_Mode VARCHAR(15),    @MM_ID INT,
	@Acc_OpId int , 
	@Acc_UNID int , 
	@Acc_Code int , 
	@Acc_OpMode char (1) , 
	@Acc_OpDate datetime , 
	@Acc_Balance numeric (18,2), 
	@Acc_BalType int , 
	@Active_Status char (1), 
	@Maker_ID int , 
	@Making_Time datetime , 
	@Updater_ID int , 
	@Updating_Time datetime 
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @NextID	As BigInt
	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'AccOpBal_M_Tbl','Acc_OpId',@NextID  OUTPUT 
		SET @Acc_OpId = @NextID 
	
		INSERT INTO dbo.AccOpBal_M_Tbl
		(
			Acc_OpId,
			Acc_UNID,
			Acc_Code,
			Acc_OpDate,
			Acc_Balance,
			Acc_BalType,
			Active_Status,
			Maker_ID,
			Making_Time,
			Updater_ID,
			Updating_Time,
			Acc_OpMode
		)
		VALUES
		(
			@Acc_OpId,
			@Acc_UNID,
			@Acc_Code,
			@Acc_OpDate,
			@Acc_Balance,
			@Acc_BalType,
			@Active_Status,
			@Maker_ID,
			@Making_Time,
			@Updater_ID,
			@Updating_Time,
			@Acc_OpMode
		)
	END
	ELSE
	BEGIN
		--SELECT CURRENT DATA
		Declare @LogOldValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogOldValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccOpBal_M_Tbl','Acc_OpId',@Acc_OpId
		
		UPDATE dbo.AccOpBal_M_Tbl SET 
			Acc_OpMode = @Acc_OpMode, 
			Acc_UNID = @Acc_UNID ,
			Acc_Code = @Acc_Code ,
			Acc_OpDate = @Acc_OpDate ,
			Acc_Balance = @Acc_Balance ,
			Acc_BalType = @Acc_BalType ,
			Active_Status = @Active_Status ,
			Updater_ID = @Updater_ID ,
			Updating_Time = @Updating_Time
		WHERE Acc_OpId= @Acc_OpId
		
		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccOpBal_M_Tbl','Acc_OpId',@Acc_OpId
		
		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @Acc_OpId, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
		
	END
	
	SELECT @Acc_OpId AS ID
	
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
