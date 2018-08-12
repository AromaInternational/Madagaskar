-- Author       :PRADEEP.T.V
-- Created Date :25/02/2017
-- Exec IUM_AccLedger_Sp
CREATE PROCEDURE [dbo].[IUM_AccLedger_Sp](    @Entry_Mode			VARCHAR(15),    @MM_ID				INT,
	@Acc_Id				bigint , 
	@Acc_UNID			int , 
	@Acc_VrTyp			varchar (10), 
	@Acc_VrNo			int , 
	@Acc_FinYear		varchar (5), 
	@Acc_Type			char (1), 
	@Acc_TrDate			datetime , 
	@Acc_ChqNo			varchar (100), 
	@Acc_OrgFrom		varchar (10), 
	@Acc_Narration		varchar (250), 
	@Acc_ChqDate		datetime , 
	@Active_Status		char (1), 
	@Maker_ID			int , 
	@Making_Time		datetime , 
	@Updater_ID			int , 
	@Updating_Time		datetime,
	@TranDetails		Xml,
	@ReqSelct			Char(1)='N'  
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @NextID			BigInt,
			@handle			Int,
			@VrNo			Int
	
	Set @Acc_FinYear	= (case when datepart(month,@Acc_TrDate)<(4) then (Right(CONVERT([varchar](4),datepart(year,@Acc_TrDate)-(1)),2)+'-')+Right(CONVERT([varchar](4),datepart(year,@Acc_TrDate)),2) else (Right(CONVERT([varchar](4),datepart(year,@Acc_TrDate)),2)+'-')+Right(CONVERT([varchar](4),datepart(year,@Acc_TrDate)+(1)),2) end)

	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'AccLedger_M_Tbl','Acc_ID',@NextID  OUTPUT 
		SET @Acc_Id = @NextID 
		
		Exec Get_NextAccVrNo_Sp @Acc_UNID,@Acc_VrTyp,@Acc_FinYear,@VrNo OUTPUT 
		SET @Acc_VrNo = @VrNo 

		INSERT INTO dbo.AccLedger_M_Tbl
		(
			Acc_Id,
			Acc_UNID,
			Acc_VrTyp,
			Acc_VrNo,
			Acc_FinYear,
			Acc_Type,
			Acc_TrDate,
			Acc_ChqNo,
			Acc_OrgFrom,
			Acc_Narration,
			Acc_ChqDate,
			Active_Status,
			Maker_ID,
			Making_Time,
			Updater_ID,
			Updating_Time
		)
		VALUES
		(
			@Acc_Id,
			@Acc_UNID,
			@Acc_VrTyp,
			@Acc_VrNo,
			@Acc_FinYear,
			@Acc_Type,
			@Acc_TrDate,
			@Acc_ChqNo,
			@Acc_OrgFrom,
			@Acc_Narration,
			@Acc_ChqDate,
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
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccLedger_M_Tbl','Acc_Id',@Acc_Id
		
		UPDATE dbo.AccLedger_M_Tbl SET 
			Acc_UNID = @Acc_UNID ,
			Acc_VrTyp = @Acc_VrTyp ,
			Acc_VrNo = @Acc_VrNo ,
			Acc_FinYear = @Acc_FinYear ,
			Acc_Type = @Acc_Type ,
			Acc_TrDate = @Acc_TrDate ,
			Acc_ChqNo = @Acc_ChqNo ,
			Acc_OrgFrom = @Acc_OrgFrom ,
			Acc_Narration = @Acc_Narration ,
			Acc_ChqDate = @Acc_ChqDate ,
			Active_Status = @Active_Status ,
			Updater_ID = @Updater_ID ,
			Updating_Time = @Updating_Time 
		WHERE Acc_Id= @Acc_Id
		
		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccLedger_M_Tbl','Acc_Id',@Acc_Id
		
		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @Acc_Id, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
		
	END
	
	--##### Tran Tbl #################
	DELETE FROM AccLedger_T_Tbl WHERE Acc_Id= @Acc_Id

	If Exists (SELECT T.c.query('..') AS result FROM  @TranDetails.nodes('/NewDataSet/Table') T(c))
	Begin
		EXEC sp_xml_preparedocument @handle OUTPUT, @TranDetails

		IF OBJECT_ID('tempdb..#AccTran_Tbl') IS NOT NULL DROP TABLE Tempdb..#AccTran_Tbl
			
		SELECT * Into #AccTran_Tbl FROM OPENXML (@handle, 'NewDataSet/Table', 2) WITH 
			(	
				Acc_SlNo		Int , 
				Acc_Code		Int , 
				Acc_TranType	Int ,
				Acc_Amt			Numeric(18,3)
			)

		Insert Into AccLedger_T_Tbl(Acc_Id, Acc_SlNo, Acc_Code, Acc_TranType, Acc_Amt)
		Select @Acc_Id,Acc_SlNo, Acc_Code, Acc_TranType,Acc_Amt From #AccTran_Tbl Order by Acc_SlNo
	End


	IF @ReqSelct = 'Y' SELECT @Acc_Id AS ID

	SELECT @Acc_Id AS ID
	
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
