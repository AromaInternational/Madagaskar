
-- Author       :PRADEEP.T.V
-- Created Date :20/09/2016
-- Exec IUM_Department_Sp
CREATE PROCEDURE [dbo].[IUM_Department_Sp]
(
    @Entry_Mode VARCHAR(15),
    @MM_ID INT,
	@Dep_ID int , 
	@Dep_Name varchar (50), 
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
	
	Declare @NextID	As BigInt, 
			@Sql	As NVarchar(4000) 
	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'Department_P_Tbl','Dep_ID',@NextID  OUTPUT 
		SET @Dep_ID = @NextID 
	
		INSERT INTO dbo.Department_P_Tbl
		(
			Dep_ID,
			Dep_Name,
			Active_Status,
			Maker_ID,
			Making_Time,
			Updater_ID,
			Updating_Time
		)
		VALUES
		(
			@Dep_ID,
			@Dep_Name,
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
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'Department_P_Tbl','Dep_ID',@Dep_ID

		UPDATE dbo.Department_P_Tbl SET 
			Dep_Name = @Dep_Name ,
			Active_Status = @Active_Status ,
			Updater_ID = @Updater_ID ,
			Updating_Time = @Updating_Time 
		WHERE Dep_ID= @Dep_ID

		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'Department_P_Tbl','Dep_ID',@Dep_ID

		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @Dep_ID, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
	END
	
	SELECT @Dep_ID AS ID
	
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

