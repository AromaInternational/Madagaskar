
-- Author       :PRADEEP.T.V
-- Created Date :19/08/2018
-- Exec IUM_TransactionMaster_Sp
CREATE PROCEDURE [dbo].[IUM_TransactionMaster_Sp]
(
    @Entry_Mode VARCHAR(15),
    @MM_ID INT,
	@TranID int , 
	@BillNo varchar (30), 
	@TrDate date , 
	@ClientID int , 
	@ShipmentAddress varchar (300), 
	@BillingAddress varchar (300), 
	@InvoiceDate date , 
	@InvoiceNumber varchar (50), 
	@RoundOff decimal (18,2), 
	@GrossAmount decimal (18,2), 
	@NetAmount decimal (18,2), 
	@Frieght decimal (18,2), 
	@DiscountOnTotal decimal (18,2), 
	@CurrencyEntryID int , 
	@Remarks varchar (300), 
	@AutoRoundOff char (1), 
	@Maker_ID int , 
	@Making_Time datetime , 
	@Updater_Id int , 
	@Updating_Time datetime , 
	@Tran_XML AS XML=''
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @NextID				As BigInt
	Declare @handle				As INT

	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'TransactionMaster_T_Tbl','TranID',@NextID  OUTPUT 
		SET @TranID = @NextID 
		SET @BillNo=@NextID  -- To DO

		SELECT @CurrencyEntryID=MAX(EntryID) FROM DailyCurrencyMaster_M_Tbl
	
		INSERT INTO dbo.TransactionMaster_T_Tbl
		(
			TranID,
			BillNo,
			TrDate,
			ClientID,
			ShipmentAddress,
			BillingAddress,
			InvoiceDate,
			InvoiceNumber,
			RoundOff,
			GrossAmount,
			NetAmount,
			Frieght,
			DiscountOnTotal,
			CurrencyEntryID,
			Remarks,
			AutoRoundOff,
			Maker_ID,
			Making_Time,
			Updater_Id,
			Updating_Time
		)
		VALUES
		(
			@TranID,
			@BillNo,
			@TrDate,
			@ClientID,
			@ShipmentAddress,
			@BillingAddress,
			@InvoiceDate,
			@InvoiceNumber,
			@RoundOff,
			@GrossAmount,
			@NetAmount,
			@Frieght,
			@DiscountOnTotal,
			@CurrencyEntryID,
			@Remarks,
			@AutoRoundOff,
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
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'TransactionMaster_T_Tbl','TranID',@TranID
		
		UPDATE dbo.TransactionMaster_T_Tbl SET 
			BillNo = @BillNo ,
			TrDate = @TrDate ,
			ClientID = @ClientID ,
			ShipmentAddress = @ShipmentAddress ,
			BillingAddress = @BillingAddress ,
			InvoiceDate = @InvoiceDate ,
			InvoiceNumber = @InvoiceNumber ,
			RoundOff = @RoundOff ,
			GrossAmount = @GrossAmount ,
			NetAmount = @NetAmount ,
			Frieght = @Frieght ,
			DiscountOnTotal = @DiscountOnTotal ,
			CurrencyEntryID = @CurrencyEntryID ,
			Remarks = @Remarks ,
			AutoRoundOff = @AutoRoundOff ,
			Updater_Id = @Updater_Id ,
			Updating_Time = @Updating_Time 
		WHERE TranID= @TranID
		
		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'TransactionMaster_T_Tbl','TranID',@TranID
		
		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @TranID, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
		
	END
	
	--##### Tran Tbl #################
	If Exists (SELECT T.c.query('..') AS result
		FROM   @Tran_XML.nodes('/NewDataSet/Table') T(c))
	Begin
		EXEC sp_xml_preparedocument @handle OUTPUT, @Tran_XML

		IF OBJECT_ID('tempdb..#TempTran') IS NOT NULL DROP TABLE Tempdb..#TempTran
			
		SELECT * Into #TempTran FROM OPENXML (@handle, 'NewDataSet/Table', 2) WITH 
			(	
			ProductID int,
			TranSeqNo int,
			MeasurementFinal_Value decimal(18, 2) ,
			Quantity decimal(18, 2) ,
			Rate decimal(18, 2) ,
			Price decimal(18, 2) ,
			DiscountType char(1),
			DiscountPercent decimal(18, 2) ,
			DiscountAmount decimal(18, 2) ,
			Description varchar(300) 
			)

		EXEC sp_xml_removedocument @handle 

		DELETE FROM TransactionDetails_T_Tbl WHERE TranID=@TranID

		INSERT INTO [dbo].[TransactionDetails_T_Tbl]
			([TranID]
			,[ProductID]
			,[TranSeqNo]
			,[MeasurementFinal_Value]
			,[Quantity]
			,[Rate]
			,[Price]
			,[DiscountType]
			,[DiscountPercent]
			,[DiscountAmount]
			,[Description])
		SELECT @TranID
			,[ProductID]
			,[TranSeqNo]
			,[MeasurementFinal_Value]
			,[Quantity]
			,[Rate]
			,[Price]
			,[DiscountType]
			,[DiscountPercent]
			,[DiscountAmount]
			,[Description]
		FROM #TempTran
	END

	SELECT @TranID AS ID
	
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