-- Author       :PRADEEP.T.V
-- Created Date :25/02/2017
-- Exec IUM_AccountGroup_Sp
CREATE PROCEDURE IUM_AccountGroup_Sp(    @Entry_Mode VARCHAR(15),    @MM_ID INT,
	@GP_ID int , 
	@GP_Name varchar (100), 
	@GP_SeqNo int , 
	@GP_ParentId int , 
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
		Exec GetNextID_Sp 'AccountGroup_P_Tbl','GP_ID',@NextID  OUTPUT 
		SET @GP_ID = @NextID 
	
		INSERT INTO dbo.AccountGroup_P_Tbl
		(
			GP_ID,
			GP_Name,
			GP_SeqNo,
			GP_ParentId,
			Active_Status,
			Maker_ID,
			Making_Time,
			Updater_ID,
			Updating_Time
		)
		VALUES
		(
			@GP_ID,
			@GP_Name,
			@GP_SeqNo,
			@GP_ParentId,
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
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccountGroup_P_Tbl','GP_ID',@GP_ID
		
		UPDATE dbo.AccountGroup_P_Tbl SET 
			GP_Name = @GP_Name ,
			GP_SeqNo = @GP_SeqNo ,
			GP_ParentId = @GP_ParentId ,
			Active_Status = @Active_Status ,
			Updater_ID = @Updater_ID ,
			Updating_Time = @Updating_Time 
		WHERE GP_ID= @GP_ID
		
		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccountGroup_P_Tbl','GP_ID',@GP_ID
		
		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @GP_ID, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
		
	END
	
	SELECT @GP_ID AS ID
	
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
