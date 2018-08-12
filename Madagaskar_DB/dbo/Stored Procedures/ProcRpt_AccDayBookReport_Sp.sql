

-- Author       :PRADEEP.T.V
-- Created Date :05/08/2016
-- Exec ProcRpt_AccDayBookReport_Sp 1,7001,31,1,'<NewDataSet />','06/01/2018','07/05/2018'
CREATE Procedure [dbo].[ProcRpt_AccDayBookReport_Sp] 
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
			@ReportHeading		Varchar(250) = 'ACCOUNT DAYBOOK REPORT',
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

	Set @ParamFieldDefs = (Select 'Company|' + C.Cmp_Name +'|Address|' + C.Cmp_Address From CompanyProfile_P_Tbl C Where C.Cmp_Code = @CompanyCode) + '|Heading|' + @ReportHeading

	Set @RptName = IsNull((Select RN_Name from ReportNames_P_Tbl WHERE RN_Id = @RptID ),'NotSet')

	-- Setting Table
	Select 1 As SlNO,'Grid' As Descrption,@RptName As RptName,@SubRptName As SubRptName ,@ParamFieldDefs As ParamFieldDefs , @ReportHeading As ReportHeading, @NoOfCopies As NoOfCopies
	Union All
	Select 2 As SlNO,'Report' As Descrption,@RptName As RptName,@SubRptName As SubRptName ,@ParamFieldDefs As ParamFieldDefs , @ReportHeading As ReportHeading, @NoOfCopies As NoOfCopies
	
	-- Grid
	SELECT 1 AS A

	-- Report

	SELECT Acc_Id, Cmp_Code, Cmp_Name, Acc_UNID, UN_Name, Acc_VrNo, Acc_VrTyp, Acc_FinYear, Acc_Type, Acc_TrDate, Acc_ChqNo, Acc_OrgFrom, Acc_Narration, Acc_ChqDate, Acc_SlNo, Acc_Code, Acc_Name, GP_Name, GP_ID, 
        GP_SeqNo, Acc_SeqNo, Acc_Statementtype, Acc_BalType, Acc_ALIE, Acc_Position, Acc_TranType, Acc_Amt, Acc_TrType, Acc_CrAmount, Acc_DrAmount, Active_Status, Maker_ID, Making_Time, Updater_ID, Updating_Time
	FROM AccLedgerDetails_Vw M WHERE Active_Status = 'Y' AND Cmp_Code = @CompanyCode  
		AND Acc_TrDate Between @FromDate AND @ToDate
		AND Exists(Select 1 From ##UnitFilter_Tbl U where M.Acc_UNID = U.UN_ID)
	ORDER BY Acc_Id

	Set Nocount OFF
End


