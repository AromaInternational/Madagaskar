-- Author       :PRADEEP.T.V
-- Created Date :05/08/2016
-- Exec ProcRpt_AccPandLReport_Sp 13,18,'05/01/2016','07/22/2016',821,1
CREATE Procedure [dbo].[ProcRpt_AccPandLReport_Sp] 
(
	@CompanyCode		As Int,
	@MMID				As Int,
	@RptID				As Int, 
	@UserID				As Int,	
	@Unit_Xml			As Xml,	
	@FromDate			As Datetime, 
	@ToDate				As Datetime
) As

Begin
	Set Nocount On
	Declare @Sql				NVarchar(Max),
	        @RptName			Varchar(250) = '',
			@SubRptName			Varchar(1000) = '',
			@ParamFieldDefs		Varchar(1000) = '',
			@ReportHeading		Varchar(250) = 'ACCOUNT P & L REPORT',
			@NoOfCopies			Int	= 1 

	Declare @OpeningStock		Numeric(18,2)= 0,
			@ClosingStock		Numeric(18,2)= 0

	Declare @FinYear_From		Date= Case When Month(@FromDate)< 4 Then Cast('04/01/'+ Cast((Year(@FromDate)-1) as varchar(4))AS Date) Else Cast('04/01/'+ Cast((Year(@FromDate)) as varchar(4))AS Date)End,
			@FinYear_To			Date= Case When Month(@FromDate)< 4 Then Cast('03/31/'+ Cast((Year(@FromDate)) as varchar(4))AS Date) Else Cast('03/31/'+ Cast((Year(@FromDate)+1) as varchar(4))AS Date)End

	Declare @handle				As INT
	--============Set UnitFilter Tbl START===========================================================
	IF OBJECT_ID('Tempdb..##UnitFilter_Tbl') IS NOT NULL DROP TABLE Tempdb..##UnitFilter_Tbl
	Create Table ##UnitFilter_Tbl
	(
		[UN_ID] [Int] NOT NULL,
	)
	If Exists (SELECT T.c.query('..') AS result
		FROM   @Unit_Xml.nodes('/NewDataSet/Table') T(c))
	Begin
		EXEC sp_xml_preparedocument @handle OUTPUT, @Unit_Xml

		IF OBJECT_ID('tempdb..#TempFilter_U_Tbl') IS NOT NULL DROP TABLE Tempdb..#TempFilter_U_Tbl
		SELECT * Into #TempFilter_U_Tbl FROM OPENXML (@handle, 'NewDataSet/Table', 2) WITH (ID Varchar(50))

		INSERT INTO ##UnitFilter_Tbl(UN_ID) SELECT UN_ID FROM dbo.UserUnitTreeCodeRight_Fn(@UserID) M JOIN #TempFilter_U_Tbl T ON M.TreeCode = T.ID WHERE UN_ID > 0 And Cast(Left(M.TreeCode,3) As Int)  = @CompanyCode
	End
	Else
	Begin
		INSERT INTO ##UnitFilter_Tbl(UN_ID) SELECT UN_ID FROM dbo.UserUnitTreeCodeRight_Fn(@UserID) M WHERE UN_ID > 0 And Cast(Left(M.TreeCode,3) As Int)  = @CompanyCode
	End
	--============Set UnitFilter Tbl END===========================================================

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
		[AccGroup]		[bigint]		NULL,
		[AccGroupName]	[varchar](50)	NULL, 
		[AccGroupSeqNo] [int]			NULL,
		[AccCode]		[bigint]		NULL,
		[AccName]		[varchar](50)	NULL, 
		[AccSeqNo]		[int]			NULL,
		[AccALIE]		[char](1)		NULL,  
		[AccPosition]	[varchar](2)	NULL,
		[Debit]			[Numeric](18,2)	NULL,
		[Credit]		[Numeric](18,2)	NULL
	)

	Set @ParamFieldDefs = (Select 'Company|' + C.Cmp_Name +'|Address|' + C.Cmp_Address From CompanyProfile_P_Tbl C Where C.Cmp_Code = @CompanyCode) + '|Heading|' + @ReportHeading

	Set @RptName = IsNull((Select RN_Name from ReportNames_P_Tbl WHERE RN_Id = @RptID ),'NotSet')

	-- Setting Table
	Select 1 As SlNO,'Grid' As Descrption,@RptName As RptName,@SubRptName As SubRptName ,@ParamFieldDefs As ParamFieldDefs , @ReportHeading As ReportHeading, @NoOfCopies As NoOfCopies
	Union All
	Select 2 As SlNO,'Report' As Descrption,@RptName As RptName,@SubRptName As SubRptName ,@ParamFieldDefs As ParamFieldDefs , @ReportHeading As ReportHeading, @NoOfCopies As NoOfCopies
	
	-- Grid
	SELECT 1 AS A

	-- Report
	Set @Sql = ''

	-- ========================================PROCESS TRIAL BALANCE START=====================================================================================================================
	Set @Sql = 'Insert InTo #TrDetails(SLNO,UNID,UNName,ID,Date,AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,AccALIE,AccPosition,Remarks,TranType,Debit,Credit,Amount)
	SELECT ROW_NUMBER() OVER(ORDER BY AccCode,Date,SLNO)SLNO, UNID,UNName,ID,Date,AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,AccALIE,AccPosition,Remarks,TranType,Debit,Credit,Amount
	FROM 
	(
		SELECT ROW_NUMBER() OVER(ORDER BY Acc_Code,Acc_TrDate,Making_Time)SLNO,Acc_UNID UNID,UN_Name UNName, Acc_Id ID, Acc_TrDate Date,
			GP_ID AccGroup,GP_Name AccGroupName,GP_SeqNo AccGroupSeqNo,Acc_Code AccCode, Acc_Name AccName,Acc_SeqNo AccSeqNo,Acc_ALIE AccALIE,Acc_Position AccPosition,
			REPLACE(REPLACE(cast(Acc_Narration as nvarchar(max)), CHAR(13), ''''), CHAR(10), '''') Remarks, 
			Acc_TranType TranType,SUM(Acc_DrAmount) Debit,SUM(Acc_CrAmount) Credit,SUM(Acc_TranType*Acc_Amt) Amount 
		FROM AccLedgerDetails_Vw M WHERE Active_Status = ''Y'' AND Cmp_Code =' + Cast(@CompanyCode As Varchar(20)) + ' 
			AND Acc_TrDate Between ''' + CAST(@FromDate as varchar(12)) + ''' AND ''' + CAST(@ToDate as varchar(12)) + ''' 
			AND Exists(Select 1 From ##UnitFilter_Tbl U where M.Acc_UNID = U.UN_ID) 
		GROUP BY Acc_UNID,UN_Name,Acc_Id,Acc_TrDate,GP_ID,GP_Name,GP_SeqNo,Acc_Code,Acc_Name,Acc_SeqNo,Acc_ALIE,Acc_Position,Acc_Narration,Acc_TranType,Making_Time
	) As A ORDER BY AccCode,Date,SLNO'
	Print @Sql
	Exec sp_executesql @Sql

	Insert InTo #TrialBal_Tbl(SLNO,AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,AccALIE,AccPosition,Debit,Credit)
	SELECT ROW_NUMBER() OVER(ORDER BY AccName)SLNO,AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,AccALIE,AccPosition,Debit,Credit
	FROM 
	(
		SELECT AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,AccALIE,AccPosition,
			Case When SUM(Debit) - SUM(Credit) > 0 Then SUM(Debit) - SUM(Credit) Else 0  End Debit,
			Case When SUM(Debit) - SUM(Credit) < 0 Then Abs(SUM(Debit) - SUM(Credit)) Else 0  End Credit
		FROM #TrDetails M GROUP BY AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,AccALIE,AccPosition
		HAVING SUM(Debit) - SUM(Credit) <> 0
	)As X ORDER BY AccGroup,AccCode

	-- ========================================PROCESS TRIAL BALANCE END=====================================================================================================================


	-- ========================================PROCESS P AND L DEBIT(EXPENSE)SIDE START======================================================================================================
	If OBJECT_ID('TempDB.dbo.#PandL_Statement_Debit') Is Not Null Drop Table #PandL_Statement_Debit
	Create Table #PandL_Statement_Debit
	(
		[SLNO]				[INT] IDENTITY(1,1),
		[AccGroup]			[bigint]		NULL,
		[AccGroupName]		[varchar](50)	NULL, 
		[AccGroupSeqNo]		[int]			NULL,
		[AccCode]			[bigint]		NULL,
		[AccName]			[varchar](50)	NULL, 
		[AccSeqNo]			[int]			NULL,
		[Balance]			[Numeric](18,2)	NULL DEFAULT (0),
		[GroupTotal]		[Numeric](18,2)	NULL,
		[Exp_Liab]			[char](1)		NULL
	)

	If OBJECT_ID('TempDB.dbo.#T_Debit') Is Not Null Drop Table #T_Debit
	Create Table #T_Debit
	(
		[SLNO]				[INT] IDENTITY(1,1),
		[AccGroup]			[bigint]		NULL,
		[AccGroupName]		[varchar](50)	NULL, 
		[AccGroupSeqNo]		[int]			NULL,
		[AccCode]			[bigint]		NULL,
		[AccName]			[varchar](50)	NULL, 
		[AccSeqNo]			[int]			NULL,
		[Balance]			[Numeric](18,2)	NULL DEFAULT (0),
		[GroupTotal]		[Numeric](18,2)	NULL,
		[Exp_Liab]			[char](1)		NULL
	)
	
	INSERT INTO #T_Debit(AccGroup,AccGroupName,Exp_Liab)
	SELECT AccGroup,AccGroupName,'E' Exp_Liab FROM #TrialBal_Tbl WHERE AccALIE IN ('E', 'I') GROUP BY AccGroup,AccGroupName HAVING SUM(Debit)>0

	INSERT INTO #T_Debit(AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Exp_Liab)
	SELECT AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Debit Balance,0 GroupTotal,'E' Exp_Liab
	FROM #TrialBal_Tbl WHERE AccALIE IN ('E', 'I') AND Debit > 0

	INSERT INTO #T_Debit(AccGroup,AccGroupName,GroupTotal,Exp_Liab)
	SELECT AccGroup,AccGroupName,SUM(Balance) GroupTotal,Exp_Liab FROM #T_Debit GROUP BY AccGroup,AccGroupName,Exp_Liab ORDER BY AccGroupName 

	---OPENING STOCK VALUE
	IF IsNull(@OpeningStock,0)<= 0 Set @OpeningStock = 0

	IF @OpeningStock >0 
	Begin
		INSERT INTO #PandL_Statement_Debit(AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Exp_Liab)
		SELECT 0 AccGroup,'Opening Stock' AccGroupName,1 AccGroupSeqNo,0 AccCode,'' AccName,1 AccSeqNo,0 Balance,0 GroupTotal,'E' Exp_Liab 

		INSERT INTO #PandL_Statement_Debit(AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Exp_Liab)
		SELECT 0 AccGroup,'Opening Stock' AccGroupName,1 AccGroupSeqNo,0 AccCode,'' AccName,1 AccSeqNo,0 Balance,@OpeningStock GroupTotal,'E' Exp_Liab 
	End

	INSERT INTO #PandL_Statement_Debit(AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Exp_Liab)
	SELECT AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Exp_Liab FROM #T_Debit ORDER BY AccGroupName,SLNO
	-- ========================================PROCESS P AND L DEBIT(EXPENSE)SIDE START=====================================================================================================================

	-- ========================================PROCESS P AND L CREDIT(INCOME)SIDE START=====================================================================================================================
	If OBJECT_ID('TempDB.dbo.#PandL_Statement_Credit') Is Not Null Drop Table #PandL_Statement_Credit
	Create Table #PandL_Statement_Credit
	(
		[SLNO]				[INT] IDENTITY(1,1),
		[AccGroup]			[bigint]		NULL,
		[AccGroupName]		[varchar](50)	NULL, 
		[AccGroupSeqNo]		[int]			NULL,
		[AccCode]			[bigint]		NULL,
		[AccName]			[varchar](50)	NULL, 
		[AccSeqNo]			[int]			NULL,
		[Balance]			[Numeric](18,2)	NULL DEFAULT (0),
		[GroupTotal]		[Numeric](18,2)	NULL,
		[Inc_Asset]			[char](1)		NULL
	)

	If OBJECT_ID('TempDB.dbo.#T_Credit') Is Not Null Drop Table #T_Credit
	Create Table #T_Credit
	(
		[SLNO]				[INT] IDENTITY(1,1),
		[AccGroup]			[bigint]		NULL,
		[AccGroupName]		[varchar](50)	NULL, 
		[AccGroupSeqNo]		[int]			NULL,
		[AccCode]			[bigint]		NULL,
		[AccName]			[varchar](50)	NULL, 
		[AccSeqNo]			[int]			NULL,
		[Balance]			[Numeric](18,2)	NULL DEFAULT (0),
		[GroupTotal]		[Numeric](18,2)	NULL,
		[Inc_Asset]			[char](1)		NULL
	)

	INSERT INTO #T_Credit(AccGroup,AccGroupName,Inc_Asset)
	SELECT AccGroup,AccGroupName,'I' Inc_Asset FROM #TrialBal_Tbl WHERE AccALIE IN ('E', 'I') GROUP BY AccGroup,AccGroupName HAVING SUM(Credit)>0

	INSERT INTO #T_Credit(AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Inc_Asset)
	SELECT AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Credit Balance,0 GroupTotal,'I' Inc_Asset
	FROM #TrialBal_Tbl WHERE AccALIE IN ('E', 'I') AND Credit > 0

	INSERT INTO #T_Credit(AccGroup,AccGroupName,GroupTotal,Inc_Asset)
	SELECT AccGroup,AccGroupName,SUM(Balance) GroupTotal,Inc_Asset FROM #T_Credit GROUP BY AccGroup,AccGroupName,Inc_Asset ORDER BY AccGroupName

	---CLOSING STOCK VALUE
	IF IsNull(@ClosingStock,0)<= 0 Set @ClosingStock = 0

	INSERT INTO #PandL_Statement_Credit(AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Inc_Asset)
	SELECT AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Inc_Asset FROM #T_Credit ORDER BY AccGroupName, SLNO

	IF @ClosingStock >0 
	Begin
		INSERT INTO #PandL_Statement_Credit(AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Inc_Asset)
		SELECT 0 AccGroup,'Closing Stock' AccGroupName,1 AccGroupSeqNo,0 AccCode,'' AccName,1 AccSeqNo,0 Balance,0 GroupTotal,'I' Exp_Liab 

		INSERT INTO #PandL_Statement_Credit(AccGroup,AccGroupName,AccGroupSeqNo,AccCode,AccName,AccSeqNo,Balance,GroupTotal,Inc_Asset)
		SELECT 0 AccGroup,'Closing Stock' AccGroupName,1 AccGroupSeqNo,0 AccCode,'' AccName,1 AccSeqNo,0 Balance,@ClosingStock GroupTotal,'I' Exp_Liab
	End
	-- ========================================PROCESS P AND L CREDIT(INCOME)SIDE END====================================================================================================

	-- ========================================PROCESS P AND L FINAL=====================================================================================================================
	If OBJECT_ID('TempDB.dbo.#PandL_Statements_Tbl') Is Not Null Drop Table #PandL_Statements_Tbl
	Create Table #PandL_Statements_Tbl
	(
		[SLNO]					[INT] IDENTITY(1,1),
		[AccGroup_Dr]			[bigint]		NOT NULL DEFAULT (0),
		[AccGroupName_Dr]		[varchar](50)	NOT NULL DEFAULT (''), 
		[AccGroupSeqNo_Dr]		[int]			NOT NULL DEFAULT (0),
		[AccCode_Dr]			[bigint]		NOT NULL DEFAULT (0),
		[AccName_Dr]			[varchar](50)	NOT NULL DEFAULT (''), 
		[AccSeqNo_Dr]			[int]			NOT NULL DEFAULT (0),
		[Balance_Dr]			[Numeric](18,2)	NOT NULL DEFAULT (0),
		[GroupTotal_Dr]			[Numeric](18,2)	NOT NULL DEFAULT (0),
		[Exp_Liab]				[char](1)		NOT NULL DEFAULT ('E'),
		[AccGroup_Cr]			[bigint]		NOT NULL DEFAULT (0),
		[AccGroupName_Cr]		[varchar](50)	NOT NULL DEFAULT (''), 
		[AccGroupSeqNo_Cr]		[int]			NOT NULL DEFAULT (0),
		[AccCode_Cr]			[bigint]		NOT NULL DEFAULT (0),
		[AccName_Cr]			[varchar](50)	NOT NULL DEFAULT (''), 
		[AccSeqNo_Cr]			[int]			NOT NULL DEFAULT (0),
		[Balance_Cr]			[Numeric](18,2)	NOT NULL DEFAULT (0),
		[GroupTotal_Cr]			[Numeric](18,2)	NOT NULL DEFAULT (0),
		[Inc_Asset]				[char](1)		NOT NULL DEFAULT ('I')
	)

	IF ISNULL((SELECT COUNT(*) FROM #PandL_Statement_Debit),0) > ISNULL((SELECT COUNT(*) FROM #PandL_Statement_Credit),0)
	Begin
		INSERT INTO #PandL_Statements_Tbl
		(
			AccGroup_Dr,AccGroupName_Dr,AccGroupSeqNo_Dr,AccCode_Dr,AccName_Dr,AccSeqNo_Dr,Balance_Dr,GroupTotal_Dr,Exp_Liab,
			AccGroup_Cr,AccGroupName_Cr,AccGroupSeqNo_Cr,AccCode_Cr,AccName_Cr,AccSeqNo_Cr,Balance_Cr,GroupTotal_Cr,Inc_Asset
		)
		SELECT IsNull(D.AccGroup,0),IsNull(D.AccGroupName,''),IsNull(D.AccGroupSeqNo,0),IsNull(D.AccCode,0),IsNull(D.AccName,''),IsNull(D.AccSeqNo,0),IsNull(D.Balance,0),IsNull(D.GroupTotal,0),IsNull(D.Exp_Liab,'E'),
			   IsNull(C.AccGroup,0),IsNull(C.AccGroupName,''),IsNull(C.AccGroupSeqNo,0),IsNull(C.AccCode,0),IsNull(C.AccName,''),IsNull(C.AccSeqNo,0),IsNull(C.Balance,0),IsNull(C.GroupTotal,0),IsNull(C.Inc_Asset,'I')
		FROM  #PandL_Statement_Debit AS D LEFT OUTER JOIN #PandL_Statement_Credit AS C
		ON D.SLNO = C.SLNO ORDER BY D.SLNO
	End
	Else
	Begin
		INSERT INTO #PandL_Statements_Tbl
		(
			AccGroup_Dr,AccGroupName_Dr,AccGroupSeqNo_Dr,AccCode_Dr,AccName_Dr,AccSeqNo_Dr,Balance_Dr,GroupTotal_Dr,Exp_Liab,
			AccGroup_Cr,AccGroupName_Cr,AccGroupSeqNo_Cr,AccCode_Cr,AccName_Cr,AccSeqNo_Cr,Balance_Cr,GroupTotal_Cr,Inc_Asset
		)
		SELECT IsNull(D.AccGroup,0),IsNull(D.AccGroupName,''),IsNull(D.AccGroupSeqNo,0),IsNull(D.AccCode,0),IsNull(D.AccName,''),IsNull(D.AccSeqNo,0),IsNull(D.Balance,0),IsNull(D.GroupTotal,0),IsNull(D.Exp_Liab,'E'),
			   IsNull(C.AccGroup,0),IsNull(C.AccGroupName,''),IsNull(C.AccGroupSeqNo,0),IsNull(C.AccCode,0),IsNull(C.AccName,''),IsNull(C.AccSeqNo,0),IsNull(C.Balance,0),IsNull(C.GroupTotal,0),IsNull(C.Inc_Asset,'I')
		FROM  #PandL_Statement_Credit AS C LEFT OUTER JOIN #PandL_Statement_Debit AS D
		ON D.SLNO = C.SLNO ORDER BY C.SLNO
	End


	UPDATE #PandL_Statements_Tbl SET AccGroupName_Cr = '' WHERE AccName_Cr <>''
	UPDATE #PandL_Statements_Tbl SET AccGroupName_Dr = '' WHERE AccName_Dr <>''

	UPDATE #PandL_Statements_Tbl SET AccGroupName_Cr = '' WHERE GroupTotal_Cr > 0 
	UPDATE #PandL_Statements_Tbl SET AccGroupName_Dr = '' WHERE GroupTotal_Dr > 0 


	DECLARE @TotalIncome	As Numeric(18,2),
			@TotalExp		As Numeric(18,2),
			@PORL			As Numeric(18,2)

	SET @TotalIncome = ISNULL((SELECT SUM(GroupTotal_Cr) FROM #PandL_Statements_Tbl WHERE Inc_Asset = 'I'),0)
	SET @TotalExp = ISNULL((SELECT SUM(GroupTotal_Dr) FROM #PandL_Statements_Tbl WHERE Exp_Liab = 'E'),0)

	SET @PORL = @TotalIncome-@TotalExp

	IF @PORL<0
	BEGIN
		INSERT INTO #PandL_Statements_Tbl(AccGroupName_Cr,GroupTotal_Cr,Inc_Asset,Exp_Liab)
		VALUES('Net Loss',ABS(@PORL),'I','E')
	END
	ELSE
	BEGIN
		INSERT INTO #PandL_Statements_Tbl(AccGroupName_Dr,GroupTotal_Dr,Inc_Asset,Exp_Liab)
		VALUES('Net Profit',@PORL,'I','E')
	END
	-- ========================================PROCESS P AND L FINAL=====================================================================================================================

	SELECT * FROM #PandL_Statements_Tbl L ORDER BY SLNO

	Set Nocount OFF
End
