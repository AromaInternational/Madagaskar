

-- Author       :PRADEEP.T.V
-- Created Date :12/07/2016
-- Exec IUM_AccYearlyClosing_Sp 'NEW',2,0,'05/26/2018','18-19','Y',2,'05/26/2018 18:14:59',0,'01/01/1900'
CREATE PROCEDURE [dbo].[IUM_AccYearlyClosing_Sp]
(
    @Entry_Mode VARCHAR(15),
	@UN_ID int , 
	@AY_ID bigint , 
	@AY_Date datetime , 
	@AY_FinYear varchar (5), 
	@Active_Status char (1), 
	@Maker_ID int , 
	@Making_Time datetime , 
	@Updater_ID int , 
	@Updating_Time datetime  
) AS 
BEGIN
 Set Nocount ON 
 Begin Try
	
	Declare @Sql						NVarchar(MAX),
			@Cmp_Code					Int = (SELECT UN_CmpCode FROM UnitMaster_P_Tbl WHERE UN_ID = @UN_ID)
	Declare @TrDate						Date = (SELECT Fin_EndDate FROM dbo.FinYear_Details_Fn(@Cmp_Code,@AY_Date) Where Fin_Period = @AY_FinYear)

	Declare @FinYear_From				Date= Case When Month(@TrDate)< 4 Then Cast('04/01/'+ Cast((Year(@TrDate)-1) as varchar(4))AS Date) Else Cast('04/01/'+ Cast((Year(@TrDate)) as varchar(4))AS Date)End,
			@FinYear_To					Date= Case When Month(@TrDate)< 4 Then Cast('03/31/'+ Cast((Year(@TrDate)) as varchar(4))AS Date) Else Cast('03/31/'+ Cast((Year(@TrDate)+1) as varchar(4))AS Date)End

	If OBJECT_ID('TempDB.dbo.#TrDetails') Is Not Null Drop Table #TrDetails
	Create Table #TrDetails
	(	
		[SLNO]			[Int]			NULL,
		[UNID]			[Int]			NULL,
		[UNName]		[varchar](50)	NULL, 
		[ID]			[BigInt]		NULL,
		[Date]			[Date]			NULL, 
		[AccGroup]		[bigint]		NULL,
		[AccGroupName]	[varchar](50)	NULL, 
		[AccGroupSeqNo] [int]			NULL,
		[AccCode]		[bigint]		NULL,
		[AccName]		[varchar](50)	NULL, 
		[AccSeqNo]		[int]			NULL,
		[AccALIE]		[char](1)		NULL,  
		[AccPosition]	[varchar](2)	NULL,
		[Remarks]		[Varchar](250)	NULL,
		[TranType]		[Int]			NULL,
		[Debit]			[Numeric](18,2)	NULL,
		[Credit]		[Numeric](18,2)	NULL,
		[Amount]		[Numeric](18,2)	NULL
	)

	If OBJECT_ID('TempDB.dbo.#TrialBal_Tbl') Is Not Null Drop Table #TrialBal_Tbl
	Create Table #TrialBal_Tbl
	(	
		[SLNO]			[Int]			NULL,
		[AccCode]		[bigint]		NULL,
		[AccName]		[varchar](50)	NULL,
		[Debit]			[Numeric](18,2)	NULL,
		[Credit]		[Numeric](18,2)	NULL
	)

	--Crystal Reprt

	-- ========================================PROCESS TRIAL BALANCE START=====================================================================================================================
	Set @Sql = 'Insert InTo #TrDetails(SLNO,UNID,UNName,ID,Date,AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,AccALIE,AccPosition,Remarks,TranType,Debit,Credit,Amount)
	SELECT ROW_NUMBER() OVER(ORDER BY AccCode,Date,SLNO)SLNO, UNID,UNName,ID,Date,AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,AccALIE,AccPosition,Remarks,TranType,Debit,Credit,Amount
	FROM 
	(
		SELECT 1 SLNO,Acc_UNID UNID,UN_Name UNName,1 ID, DateAdd(Day,-1,''' + CAST(@FinYear_From as varchar(12)) + ''') Date,
			GP_ID AccGroup,GP_Name AccGroupName,GP_SeqNo AccGroupSeqNo, Acc_Code AccCode, Acc_Name AccName,Acc_SeqNo AccSeqNo,Acc_ALIE AccALIE,Acc_Position AccPosition, 
			''Opening Balance''Remarks,Acc_BalType TranType,SUM(Acc_DrBalance) Debit,SUM(Acc_CrBalance) Credit,SUM(Acc_Balance*Acc_BalType) As Amount
		FROM AccOpBal_Vw M WHERE Active_Status = ''Y'' AND Acc_ALIE IN(''A'',''L'') AND Acc_OpDate = DateAdd(Day,-1,''' + CAST(@FinYear_From as varchar(12)) + ''')  
			AND M.Acc_UNID = ' + Cast(@UN_ID As Varchar(20)) +' AND Cmp_Code =' + Cast(@Cmp_Code As Varchar(20)) +'   
		GROUP BY Acc_UNID,UN_Name,GP_ID,GP_Name,GP_SeqNo,Acc_Code,Acc_Name,Acc_SeqNo,Acc_BalType,Acc_ALIE,Acc_Position

		UNION ALL
		 
		SELECT ROW_NUMBER() OVER(ORDER BY Acc_Code,Acc_TrDate,Making_Time)SLNO,Acc_UNID UNID,UN_Name UNName, Acc_Id ID, Acc_TrDate Date,
			GP_ID AccGroup,GP_Name AccGroupName,GP_SeqNo AccGroupSeqNo,Acc_Code AccCode, Acc_Name AccName,Acc_SeqNo AccSeqNo,Acc_ALIE AccALIE,Acc_Position AccPosition,
			REPLACE(REPLACE(cast(Acc_Narration as nvarchar(max)), CHAR(13), ''''), CHAR(10), '''') Remarks, 
			Acc_TranType TranType,SUM(Acc_DrAmount) Debit,SUM(Acc_CrAmount) Credit,SUM(Acc_TranType*Acc_Amt) Amount 
		FROM AccLedgerDetails_Vw M WHERE Active_Status = ''Y'' AND Acc_ALIE IN(''A'',''L'') AND Cmp_Code =' + Cast(@Cmp_Code As Varchar(20)) + ' 
			AND Acc_TrDate Between ''' + CAST(@FinYear_From as varchar(12)) + ''' AND ''' + CAST(@FinYear_To as varchar(12)) + ''' 
			AND M.Acc_UNID = ' + Cast(@UN_ID As Varchar(20)) +'  
		GROUP BY Acc_UNID,UN_Name,Acc_Id,Acc_TrDate,GP_ID,GP_Name,GP_SeqNo,Acc_Code,Acc_Name,Acc_SeqNo,Acc_ALIE,Acc_Position,Acc_Narration,Acc_TranType,Making_Time
	) As A ORDER BY AccCode,Date,SLNO'
	Print @Sql
	Exec sp_executesql @Sql

	Insert InTo #TrialBal_Tbl(SLNO,AccCode,AccName,Debit,Credit)
	SELECT ROW_NUMBER() OVER(ORDER BY AccName)SLNO,AccCode,AccName,Debit,Credit
	FROM 
	(
		SELECT AccCode,AccName,
			Case When SUM(Debit) - SUM(Credit) > 0 Then SUM(Debit) - SUM(Credit) Else 0  End Debit,
			Case When SUM(Debit) - SUM(Credit) < 0 Then Abs(SUM(Debit) - SUM(Credit)) Else 0  End Credit
		FROM #TrDetails M GROUP BY AccCode,AccName
		HAVING SUM(Debit) - SUM(Credit) <> 0
	)As X ORDER BY AccCode

	-- ========================================PROCESS TRIAL BALANCE END=====================================================================================================================

	Declare @NextID						BigInt = 0,
			@AccCode					BigInt = 0,
			@Balance					Numeric(18,2) = 0,
			@BalType					Int = 1

	Begin Tran X1

	-- =================DELETE EXISTING DATA START =====================================================================================================================
	DELETE L FROM AccOpBal_M_Tbl L WHERE Acc_OpDate = @FinYear_To AND Acc_UNID = @UN_ID AND Acc_OpMode = 'P'
	-- =================DELETE EXISTING DATA END =====================================================================================================================
	
	--=================================INSERT BALANCE DETAILS STRAT========================================================================================
	Declare Cur_Temp  Cursor LOCAL FAST_FORWARD READ_ONLY For 
	Select  AccCode,Debit+Credit,Case When Debit > 0 then -1 Else 1 End
	From #TrialBal_Tbl S ORDER BY AccCode
	
	OPEN  Cur_Temp 
	
	FETCH NEXT From Cur_Temp INTO @AccCode, @Balance,@BalType
	While @@Fetch_Status = 0 
	Begin
		Exec GetNextID_Sp 'AccOpBal_M_Tbl','Acc_OpId',@NextID  OUTPUT 

		INSERT INTO dbo.AccOpBal_M_Tbl(Acc_OpId,Acc_UNID,Acc_Code,Acc_OpMode,Acc_OpDate,Acc_Balance,Acc_BalType,Active_Status,Maker_ID,Making_Time,Updater_ID,Updating_Time)
		SELECT @NextID,@UN_ID,@AccCode,'P',@FinYear_To,@Balance,@BalType,@Active_Status,@Maker_ID,@Making_Time,@Updater_ID,@Updating_Time

		FETCH NEXT From Cur_Temp INTO @AccCode, @Balance,@BalType
	End

	CLOSE 		Cur_Temp
	DEALLOCATE 	Cur_Temp

	--=================================INSERT BALANCE DETAILS END========================================================================================

	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'AccYearlyClosing_M_Tbl','AY_ID',@NextID  OUTPUT 
		SET @AY_ID = @NextID 

		INSERT INTO dbo.AccYearlyClosing_M_Tbl(AY_ID,AY_UNID,AY_Date,AY_FinYear,Active_Status,Maker_ID,Making_Time,Updater_ID,Updating_Time)VALUES(@AY_ID,@UN_ID,@AY_Date,@AY_FinYear,@Active_Status,@Maker_ID,@Making_Time,@Updater_ID,@Updating_Time)
	END
	ELSE
	BEGIN
		UPDATE dbo.AccYearlyClosing_M_Tbl SET AY_UNID = @UN_ID ,Updater_ID = @Updater_ID ,AY_Date = @AY_Date ,AY_FinYear = @AY_FinYear ,Active_Status = @Active_Status ,Updating_Time = @Updating_Time WHERE AY_ID= @AY_ID
	END
	
	SELECT @AY_ID AS ID
	
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


