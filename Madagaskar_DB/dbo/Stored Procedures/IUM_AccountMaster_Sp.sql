-- Author       :PRADEEP.T.V
-- Created Date :26/02/2017
-- Exec IUM_AccountMaster_Sp
CREATE PROCEDURE [dbo].[IUM_AccountMaster_Sp](    @Entry_Mode VARCHAR(15),    @MM_ID INT,
	@Acc_Code int , 
	@Acc_Name varchar (100), 
	@Acc_CmpCode int,
	@Acc_GPID int , 
	@Acc_SeqNo int , 
	@Acc_BalType char (1), 
	@Acc_ALIE char (1), 
	@Acc_Position varchar (2), 
	@Acc_Statementtype char (1), 
	@Acc_BillBreakup char (1), 
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
		Exec GetNextID_Sp 'AccountMaster_P_Tbl','Acc_Code',@NextID  OUTPUT 
		SET @Acc_Code = @NextID 
	
		INSERT INTO dbo.AccountMaster_P_Tbl
		(
			Acc_Code,
			Acc_Name,
			Acc_CmpCode,
			Acc_GPID,
			Acc_SeqNo,
			Acc_BalType,
			Acc_ALIE,
			Acc_Position,
			Acc_Statementtype,
			Acc_BillBreakup,
			Active_Status,
			Maker_ID,
			Making_Time,
			Updater_ID,
			Updating_Time
		)
		VALUES
		(
			@Acc_Code,
			@Acc_Name,
			@Acc_CmpCode,
			@Acc_GPID,
			@Acc_SeqNo,
			@Acc_BalType,
			@Acc_ALIE,
			@Acc_Position,
			@Acc_Statementtype,
			@Acc_BillBreakup,
			@Active_Status,
			@Maker_ID,
			@Making_Time,
			@Updater_ID,
			@Updating_Time
		)
	END
	ELSE
	BEGIN
		--SELECT CURRENT DATA
		Declare @LogOldValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogOldValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccountMaster_P_Tbl','Acc_Code',@Acc_Code
		
		UPDATE dbo.AccountMaster_P_Tbl SET 
			Acc_Name = @Acc_Name ,
			Acc_CmpCode = @Acc_CmpCode,
			Acc_GPID = @Acc_GPID ,
			Acc_SeqNo = @Acc_SeqNo ,
			Acc_BalType = @Acc_BalType ,
			Acc_ALIE = @Acc_ALIE ,
			Acc_Position = @Acc_Position ,
			Acc_Statementtype = @Acc_Statementtype ,
			Acc_BillBreakup = @Acc_BillBreakup ,
			Active_Status = @Active_Status ,
			Updater_ID = @Updater_ID ,
			Updating_Time = @Updating_Time 
		WHERE Acc_Code= @Acc_Code
		
		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccountMaster_P_Tbl','Acc_Code',@Acc_Code
		
		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @Acc_Code, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
		
	END
	
	SELECT @Acc_Code AS ID
	
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
