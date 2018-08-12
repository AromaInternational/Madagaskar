
-- Author       :PRADEEP.T.V
-- Created Date :21/09/2016
-- Exec IUM_ParaCode_Sp
CREATE PROCEDURE [dbo].[IUM_ParaCode_Sp]
(
    @Entry_Mode VARCHAR(15),
    @MM_ID INT,
	@PC_ID int , 
	@PC_Description varchar (100), 
	@PC_Type int , 
	@PC_Order int , 
	@PC_Locked char (1), 
	@Active_Status char (1), 
	@Maker_ID int , 
	@Making_Time datetime , 
	@Updater_Id int , 
	@Updating_Time datetime  
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @Sql		As NVarchar(Max),
			@Params		As NVarchar(500),
			@ID			As Varchar(50)

	IF @Entry_Mode ='NEW'
	BEGIN 
		Set @Sql = 'SELECT @ID= MAX(Cast(RIGHT(PC_ID,LEN(PC_ID)-LEN(PC_Type))As int)) FROM ParaCode_P_Tbl WHERE PC_Type = @PC_Type AND LEFT(PC_ID,LEN(PC_Type)) = PC_Type'
		Set @params='@PC_Type Int, @ID int OUTPUT'
		Exec sp_executesql @Sql,@Params ,@PC_Type = @PC_Type,@ID = @ID OUTPUT

		Set @ID = Cast(@PC_Type As Varchar(10)) +'0' + Cast(Cast(IsNull(@ID,0) As int)+1 As Varchar(50))
		Set @PC_ID = @ID
			
		INSERT INTO dbo.ParaCode_P_Tbl
		(
			PC_ID,
			PC_Description,
			PC_Type,
			PC_Order,
			PC_Locked,
			Active_Status,
			Maker_ID,
			Making_Time,
			Updater_Id,
			Updating_Time
		)
		VALUES
		(
			@PC_ID,
			@PC_Description,
			@PC_Type,
			@PC_Order,
			@PC_Locked,
			@Active_Status,
			@Maker_ID,
			@Making_Time,
			@Updater_Id,
			@Updating_Time
		)
	END
	ELSE
	BEGIN
		--SELECT CURRENT DATA
		Declare @LogOldValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogOldValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'ParaCode_P_Tbl','PC_ID',@PC_ID

		UPDATE dbo.ParaCode_P_Tbl SET 
			PC_Description = @PC_Description ,
			PC_Type = @PC_Type ,
			PC_Order = @PC_Order ,
			PC_Locked = @PC_Locked ,
			Active_Status = @Active_Status ,
			Updater_Id = @Updater_Id ,
			Updating_Time = @Updating_Time 
		WHERE PC_ID= @PC_ID

		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'ParaCode_P_Tbl','PC_ID',@PC_ID

		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @PC_ID, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
	END
	
	SELECT @PC_ID AS ID
	
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

