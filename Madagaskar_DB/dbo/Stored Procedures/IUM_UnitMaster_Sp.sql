-- Author       :PRADEEP.T.V
-- Created Date :27/02/2017
-- Exec IUM_UnitMaster_Sp
CREATE PROCEDURE IUM_UnitMaster_Sp(    @Entry_Mode VARCHAR(15),    @MM_ID INT,
	@UN_ID int , 
	@UN_Name varchar (50), 
	@UN_CmpCode int , 
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
		Exec GetNextID_Sp 'UnitMaster_P_Tbl','UN_ID',@NextID  OUTPUT 
		SET @UN_ID = @NextID 
	
		INSERT INTO dbo.UnitMaster_P_Tbl
		(
			UN_ID,
			UN_Name,
			UN_CmpCode,
			Active_Status,
			Maker_ID,
			Making_Time,
			Updater_ID,
			Updating_Time
		)
		VALUES
		(
			@UN_ID,
			@UN_Name,
			@UN_CmpCode,
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
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'UnitMaster_P_Tbl','UN_ID',@UN_ID
		
		UPDATE dbo.UnitMaster_P_Tbl SET 
			UN_Name = @UN_Name ,
			UN_CmpCode = @UN_CmpCode ,
			Active_Status = @Active_Status ,
			Updater_ID = @Updater_ID ,
			Updating_Time = @Updating_Time 
		WHERE UN_ID= @UN_ID
		
		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'UnitMaster_P_Tbl','UN_ID',@UN_ID
		
		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @UN_ID, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
		
	END
	
	SELECT @UN_ID AS ID
	
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
