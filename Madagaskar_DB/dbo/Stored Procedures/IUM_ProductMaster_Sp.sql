-- Author       :PRADEEP.T.V
-- Created Date :15/08/2018
-- Exec IUM_ProductMaster_Sp
CREATE PROCEDURE IUM_ProductMaster_Sp(    @Entry_Mode VARCHAR(15),    @MM_ID INT,
	@ProductID int , 
	@ProductName varchar (200), 
	@Account_Code int , 
	@ProductCategory varchar (50), 
	@Measurement1_Value decimal (18,2), 
	@Measurement1_Text varchar (50), 
	@Measurement2_Value decimal (18,2), 
	@Measurement2_Text varchar (50), 
	@Measurement3_Value decimal (18,2), 
	@Measurement3_Text varchar (50), 
	@MeasurementFinal_Formula varchar (200), 
	@MeasurementFinal_Text varchar (50), 
	@Updater_Id int , 
	@Maker_ID int , 
	@Making_Time datetime , 
	@Updating_Time datetime  
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @NextID	As BigInt
	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'ProductMaster_M_Tbl','ProductID',@NextID  OUTPUT 
		SET @ProductID = @NextID 
	
		INSERT INTO dbo.ProductMaster_M_Tbl
		(
			ProductID,
			ProductName,
			Account_Code,
			ProductCategory,
			Measurement1_Value,
			Measurement1_Text,
			Measurement2_Value,
			Measurement2_Text,
			Measurement3_Value,
			Measurement3_Text,
			MeasurementFinal_Formula,
			MeasurementFinal_Text,
			Updater_Id,
			Maker_ID,
			Making_Time,
			Updating_Time
		)
		VALUES
		(
			@ProductID,
			@ProductName,
			@Account_Code,
			@ProductCategory,
			@Measurement1_Value,
			@Measurement1_Text,
			@Measurement2_Value,
			@Measurement2_Text,
			@Measurement3_Value,
			@Measurement3_Text,
			@MeasurementFinal_Formula,
			@MeasurementFinal_Text,
			@Updater_Id,
			@Maker_ID,
			@Making_Time,
			@Updating_Time
		)
	END
	ELSE
	BEGIN
		--SELECT CURRENT DATA
		Declare @LogOldValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogOldValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'ProductMaster_M_Tbl','ProductID',@ProductID
		
		UPDATE dbo.ProductMaster_M_Tbl SET 
			ProductName = @ProductName ,
			Account_Code = @Account_Code ,
			ProductCategory = @ProductCategory ,
			Measurement1_Value = @Measurement1_Value ,
			Measurement1_Text = @Measurement1_Text ,
			Measurement2_Value = @Measurement2_Value ,
			Measurement2_Text = @Measurement2_Text ,
			Measurement3_Value = @Measurement3_Value ,
			Measurement3_Text = @Measurement3_Text ,
			MeasurementFinal_Formula = @MeasurementFinal_Formula ,
			MeasurementFinal_Text = @MeasurementFinal_Text ,
			Updater_Id = @Updater_Id ,
			Updating_Time = @Updating_Time 
		WHERE ProductID= @ProductID
		
		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'ProductMaster_M_Tbl','ProductID',@ProductID
		
		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @ProductID, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
		
	END
	
	SELECT @ProductID AS ID
	
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