
-- Author       :PRADEEP.T.V
-- Created Date :05/08/2016
-- Exec ProcRpt_AccTrialBalanceReport_Sp 1,7004,31,1,'<NewDataSet />','02/28/2017','02/28/2017'
CREATE Procedure [dbo].[ProcRpt_AccTrialBalanceReport_Sp] 
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
	Declare @Qry				NVarchar(Max),
	        @RptName			Varchar(250) = '',
			@SubRptName			Varchar(1000) = '',
			@ParamFieldDefs		Varchar(1000) = '',
			@ReportHeading		Varchar(250) = 'ACCOUNT TRIAL BALANCE REPORT',
			@NoOfCopies			Int	= 1
	Declare @Sql		Nvarchar(3000)	= ''

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
		[AccGroup]		[bigint]		NOT NULL,
		[AccGroupName]	[varchar](50)	NOT NULL, 
		[AccCode]		[bigint]		NOT NULL,
		[AccName]		[varchar](50)	NOT NULL, 
		[Debit]			[Numeric](18,2)	NOT NULL,
		[Credit]		[Numeric](18,2)	NOT NULL
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
			AND Exists(Select 1 From ##UnitFilter_Tbl U where M.Acc_UNID = U.UN_ID)  
		GROUP BY Acc_UNID,UN_Name,Acc_Id,Acc_TrDate,GP_ID,GP_Name,Acc_Code,Acc_Name,Acc_Narration,Acc_TranType,Making_Time
	) As A ORDER BY AccCode,Date,SLNO'
	Print @Sql
	Exec sp_executesql @Sql

	--- INSERT DATA

	Insert InTo #Ledger(SLNO,AccGroup,AccGroupName,AccCode,AccName,Debit,Credit)
	SELECT ROW_NUMBER() OVER(ORDER BY AccName)SLNO,AccGroup,AccGroupName,AccCode,AccName,Debit,Credit
	FROM 
	(
		SELECT AccGroup,AccGroupName,AccCode,AccName,
			Case When SUM(Debit) - SUM(Credit) > 0 Then SUM(Debit) - SUM(Credit) Else 0  End Debit,
			Case When SUM(Debit) - SUM(Credit) < 0 Then Abs(SUM(Debit) - SUM(Credit)) Else 0  End Credit
		FROM #TrDetails M GROUP BY AccGroup,AccGroupName,AccCode,AccName HAVING SUM(Debit) - SUM(Credit) <> 0
	)As X ORDER BY AccGroup,AccCode

	SELECT * FROM #Ledger L ORDER BY AccName,SLNO

	Set Nocount OFF
End

