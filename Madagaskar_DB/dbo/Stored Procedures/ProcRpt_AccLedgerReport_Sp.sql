
-- Author       :PRADEEP.T.V
-- Created Date :15/10/2014
-- Exec ProcRpt_AccLedgerReport_Sp 13,0,0,0,'05/01/2016','07/22/2016',802,1
CREATE Procedure [dbo].[ProcRpt_AccLedgerReport_Sp] 
(
	@CompanyCode		As Int,
	@MMID				As Int,
	@RptID				As Int, 
	@UserID				As Int,	
	@Unit_Xml			As Xml,	
	@Acc_Xml			As Xml,
	@FromDate			As Datetime, 
	@ToDate				As Datetime
) As

Begin
	Set Nocount On
	Declare @Sql				NVarchar(Max),
	        @RptName			Varchar(250) = '',
			@SubRptName			Varchar(1000) = '',
			@ParamFieldDefs		Varchar(1000) = '',
			@ReportHeading		Varchar(250) = 'ACCOUNT LEDGER REPORT',
			@NoOfCopies			Int	= 1

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

	--============Set AccountFilter Tbl START===========================================================
	IF OBJECT_ID('Tempdb..##AccountFilter_Tbl') IS NOT NULL DROP TABLE Tempdb..##AccountFilter_Tbl
	Create Table ##AccountFilter_Tbl
	(
		[Acc_Code] [Int] NOT NULL,
	)
	If Exists (SELECT T.c.query('..') AS result
		FROM   @Acc_Xml.nodes('/NewDataSet/Table') T(c))
	Begin
		EXEC sp_xml_preparedocument @handle OUTPUT, @Acc_Xml

		IF OBJECT_ID('tempdb..#TempFilter_Tbl') IS NOT NULL DROP TABLE Tempdb..#TempFilter_Tbl
		SELECT * Into #TempFilter_Tbl FROM OPENXML (@handle, 'NewDataSet/Table', 2) WITH (ID Varchar(50))

		INSERT INTO ##AccountFilter_Tbl(Acc_Code) SELECT Cast(RIGHT(M.ID,5) As Int) FROM dbo.AccountMasterTree_Fn(@CompanyCode,'N','ID') M JOIN #TempFilter_Tbl T ON M.ID = T.ID WHERE M.ItemType = 'HEAD'
	End
	Else
	Begin
		INSERT INTO ##AccountFilter_Tbl(Acc_Code) SELECT Cast(RIGHT(M.ID,5) As Int) FROM dbo.AccountMasterTree_Fn(@CompanyCode,'N','ID') M WHERE M.ItemType = 'HEAD'
	End
	--============Set UnitFilter Tbl END===========================================================

	If OBJECT_ID('TempDB.dbo.#OpDetails') Is Not Null Drop Table #OpDetails
	Create Table #OpDetails
	(	
		[SLNO]			[Int]			NULL,
		[ID]			[BigInt]		NULL,
		[Date]			[Date]			NULL, 
		[AccGroup]		[bigint]		NULL,
		[AccGroupName]	[varchar](50)	NULL, 
		[AccCode]		[bigint]		NULL,
		[AccName]		[varchar](50)	NULL, 
		[Remarks]		[Varchar](250)	NULL,
		[TranType]		[Int]			NULL,
		[Debit]			[Numeric](18,2)	NULL,
		[Credit]		[Numeric](18,2)	NULL,
		[Amount]		[Numeric](18,2)	NULL
	)

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
		[AccCode]		[bigint]		NULL,
		[AccName]		[varchar](50)	NULL, 
		[Remarks]		[Varchar](250)	NULL,
		[TranType]		[Int]			NULL,
		[Debit]			[Numeric](18,2)	NULL,
		[Credit]		[Numeric](18,2)	NULL,
		[Amount]		[Numeric](18,2)	NULL
	)

	If OBJECT_ID('TempDB.dbo.#Ledger') Is Not Null Drop Table #Ledger
	Create Table #Ledger
	(	
		[SLNO]			[Int]			NOT NULL,
		[UNName]		[varchar](50)	NOT NULL, 
		[ID]			[BigInt]		NOT NULL,
		[Date]			[Date]			NOT NULL, 
		[AccGroup]		[bigint]		NOT NULL,
		[AccGroupName]	[varchar](50)	NOT NULL, 
		[AccCode]		[bigint]		NOT NULL,
		[AccName]		[varchar](50)	NOT NULL, 
		[Remarks]		[Varchar](250)	NOT NULL,
		[Amount]		[Numeric](18,2)	NOT NULL,
		[OpBal]			[Numeric](18,2)	NOT NULL,
		[Debit]			[Numeric](18,2)	NOT NULL,
		[Credit]		[Numeric](18,2)	NOT NULL,
		[ClBal]			[Numeric](18,2)	NOT NULL
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

	--OB DETAILS
	Set @Sql = 'Insert InTo #OpDetails(SLNO,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,TranType,Debit,Credit,Amount)
	SELECT SLNO,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,TranType,Debit,Credit,Amount
	FROM 
	(
		SELECT ROW_NUMBER() OVER(ORDER BY AccCode) SLNO,0 ID,Date,AccGroup,AccGroupName,AccCode,AccName,''Opening Balance'' Remarks,
			Case When SUM(Amount) >0 Then 1 Else -1 End TranType,0 Debit,0 Credit,SUM(Amount) Amount
		FROM
		(
			SELECT 1 SLNO,1 ID, DateAdd(Day,-1,''' + CAST(@FromDate as varchar(12)) + ''') Date,GP_ID AccGroup,GP_Name AccGroupName, Acc_Code AccCode, Acc_Name AccName, 
					0 Debit,0 Credit,SUM(Acc_Balance*Acc_BalType) As Amount
			FROM AccOpBal_Vw M WHERE Active_Status = ''Y'' AND Acc_OpDate = DateAdd(Day,-1,''' + CAST(@FinYear_From as varchar(12)) + ''')  
				AND Exists(Select 1 From ##UnitFilter_Tbl U where M.Acc_UNID = U.UN_ID) AND Exists(Select 1 From ##AccountFilter_Tbl A where M.Acc_Code = A.Acc_Code) AND Cmp_Code =' + Cast(@CompanyCode As Varchar(20)) +
			' GROUP BY GP_ID,GP_Name,Acc_Code,Acc_Name

			UNION ALL 

			SELECT 1 SLNO,1 ID, DateAdd(Day,-1,''' + CAST(@FromDate as varchar(12)) + ''') Date,GP_ID AccGroup,GP_Name AccGroupName, Acc_Code AccCode, Acc_Name AccName,
					0 Debit,0 Credit,SUM(Acc_TranType*Acc_Amt) Amount
			FROM AccLedgerDetails_Vw M WHERE Active_Status = ''Y'' AND Acc_TrDate >= ''' + CAST(@FinYear_From as varchar(12)) + ''' AND Acc_TrDate < ''' + CAST(@FromDate as varchar(12)) + ''' 
				AND Exists(Select 1 From ##UnitFilter_Tbl U where M.Acc_UNID = U.UN_ID) AND Exists(Select 1 From ##AccountFilter_Tbl A where M.Acc_Code = A.Acc_Code) AND Cmp_Code =' + Cast(@CompanyCode As Varchar(20)) + 
			' GROUP BY GP_ID,GP_Name,Acc_Code,Acc_Name
		) As X GROUP BY AccGroup,AccGroupName,AccCode,AccName,Date
	) As A '
	Print @Sql
	Exec sp_executesql @Sql

	-- TRANSACTION DETAILS
	Set @Sql = 'Insert InTo #TrDetails(SLNO,UNID,UNName,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,TranType,Debit,Credit,Amount)
	SELECT ROW_NUMBER() OVER(ORDER BY AccCode,Date,SLNO)SLNO, UNID,UNName,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,TranType,Debit,Credit,Amount
	FROM 
	(
		SELECT ROW_NUMBER() OVER(ORDER BY Acc_Code,Acc_TrDate,Making_Time)SLNO,Acc_UNID UNID,UN_Name UNName, Acc_Id ID, Acc_TrDate Date,
			GP_ID AccGroup,GP_Name AccGroupName,Acc_Code AccCode, Acc_Name AccName,REPLACE(REPLACE(cast(Acc_Narration as nvarchar(max)), CHAR(13), ''''), CHAR(10), '''') Remarks, 
			Acc_TranType TranType,SUM(Acc_DrAmount) Debit,SUM(Acc_CrAmount) Credit,SUM(Acc_TranType*Acc_Amt) Amount 
		FROM AccLedgerDetails_Vw M WHERE Active_Status = ''Y'' AND Cmp_Code =' + Cast(@CompanyCode As Varchar(20)) + ' 
			AND Acc_TrDate Between ''' + CAST(@FromDate as varchar(12)) + ''' AND ''' + CAST(@ToDate as varchar(12)) + ''' 
			AND Exists(Select 1 From ##UnitFilter_Tbl U where M.Acc_UNID = U.UN_ID) AND Exists(Select 1 From ##AccountFilter_Tbl A where M.Acc_Code = A.Acc_Code)  
		GROUP BY Acc_UNID,UN_Name,Acc_Id,Acc_TrDate,GP_ID,GP_Name,Acc_Code,Acc_Name,Acc_Narration,Acc_TranType,Making_Time
	) As A ORDER BY AccCode,Date,SLNO'
	Print @Sql
	Exec sp_executesql @Sql

	--- INSERT DATA
	IF @RptID IN(11,13)
	Begin
		Insert InTo #Ledger(SLNO,UNName,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,Amount,Debit,Credit,OpBal,ClBal)
		SELECT ROW_NUMBER() OVER(ORDER BY AccCode,Date,SLNO)SLNO,UNName,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,Amount,Debit,Credit,
				0 As OpBal,0 As ClBal
		FROM 
		(
			SELECT SLNO,'' UNName,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,Amount,0 Debit,0 Credit,
				0 As OpBal,0 As ClBal 
			FROM #OpDetails M

			UNION ALL

			SELECT ROW_NUMBER() OVER(ORDER BY SLNO)SLNO,UNName,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,Amount,Debit,Credit,
				0 As OpBal,0 As ClBal 
			FROM #TrDetails M
		)As X ORDER BY AccGroup,AccCode,Date,SLNO 

		--UPDATE CB
		UPDATE M SET ClBal = T.Bal
		FROM #Ledger M JOIN (Select SLNO,Sum(Amount) Over(Partition by AccCode Order By AccCode,SlNo) As Bal From #Ledger) T ON M.SLNO = T.SLNO 
	End
	Else IF @RptID = 12
	Begin
		Insert InTo #Ledger(SLNO,UNName,ID,Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,Amount,Debit,Credit,OpBal,ClBal)
		SELECT ROW_NUMBER() OVER(ORDER BY AccGroupName,AccName)SLNO,UNName,ROW_NUMBER() OVER(ORDER BY AccGroupName,AccName) ID,
				@ToDate Date,AccGroup,AccGroupName,AccCode,AccName,Remarks,SUM(Amount),SUM(Debit),SUM(Credit),
				0 As OpBal,0 As ClBal
		FROM 
		(
			SELECT SLNO,'' UNName,1 ID,AccGroup,AccGroupName,AccCode,AccName,'' Remarks,Amount,0 Debit,0 Credit,
				0 As OpBal,0 As ClBal 
			FROM #OpDetails M

			UNION ALL

			SELECT ROW_NUMBER() OVER(ORDER BY AccCode)SLNO,'' UNName,1 ID,AccGroup,AccGroupName,AccCode,AccName,'' Remarks,
				SUM(Amount) Amount,SUM(Debit) Amount,SUM(Credit) Amount,0 As OpBal,0 As ClBal 
			FROM #TrDetails M GROUP BY AccGroup,AccGroupName,AccCode,AccName
		)As X GROUP BY UNName,AccGroup,AccGroupName,AccCode,AccName,Remarks ORDER BY AccGroup,AccCode

		--UPDATE CB
		UPDATE M SET ClBal = M.Amount, OpBal = (Amount + Debit) - (Credit)
		FROM #Ledger M
	End

	SELECT * FROM #Ledger L ORDER BY AccGroupName,AccName,SLNO

	Set Nocount OFF
End



