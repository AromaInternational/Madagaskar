-- Author       :PRADEEP.T.V
-- Created Date :26/06/2016
-- Exec Proc_AccTranSearch_Sp 1,'16-17','RECEIPT',18,'04/01/2016','06/26/2016',1,500,0,100000,1,0,'',1
CREATE Procedure [dbo].[Proc_AccTranSearch_Sp] 
(
	@CmpCode	As Int,
	@FinYear	As varchar(5),
	@VrType		As Varchar(25),
	@UNID		As Int,
	@FromDt		As Date,
	@ToDt		As Date,
	@VrNoFrom	As Int,
	@VrNoTo		As Int,
	@AmountFrom	As Numeric(18,2),
	@AmountTo	As Numeric(18,2),
	@TrType		As Int,
	@AccCode	As Int,
	@Remarks	Varchar(100),
	@UserID		As Int
) As

Begin
	Set Nocount On
	Declare @Sql		As Nvarchar(3000)	= ''

	--===========ALTER TEMP TABLE & FILTER #Unit_Tbl========================
	If OBJECT_ID('TempDB.dbo.#Unit_Tbl') Is Not Null Drop Table #Unit_Tbl
	Create Table #Unit_Tbl
	(	
		[UN_ID]		BigInt	NULL,
	)
	INSERT INTO #Unit_Tbl Select UN_ID From dbo.Fill_UserUnitDetails_Fn(@UserID,@UNID) Where Cmp_Code = @CmpCode
	--==========================================================================

	Set @Sql = 'Select Acc_Id From AccLedgerMaster_Vw M '
	Set @Sql = @Sql +'WHERE Cmp_Code = ' + Cast(@CmpCode As Varchar(25)) +' AND Exists(Select 1 From #Unit_Tbl B where M.Acc_UNID = B.UN_ID) '
	Set @Sql = @Sql +'AND Acc_FinYear = ''' + @FinYear + ''' '
	IF @VrType <> '' Set @Sql = @Sql +' And M.Acc_VrTyp =''' + @VrType + ''' ' 
	IF @Remarks <> '' Set @Sql = @Sql +' And M.Acc_Narration Like ''%' + @Remarks + '%'' ' 

	Set @Sql = @Sql +'AND Exists(Select 1 From AccLedgerDetails_Vw D WHERE M.Acc_Id = D.Acc_Id '
	IF @ToDt > '01/01/1900' Set @Sql = @Sql +'And D.Acc_TrDate Between ''' + CAST(@FromDt as varchar(12)) + ''' AND ''' + CAST(@ToDt as varchar(12)) + ''''
	IF @VrNoTo > 0 Set @Sql = @Sql +' AND D.Acc_VrNo Between ' + Cast( @VrNoFrom As Varchar(25)) + ' AND ' + Cast( @VrNoTo As Varchar(25))
	IF @AmountTo > 0 Set @Sql = @Sql +' AND D.Acc_Amt Between ' + Cast( @AmountFrom As Varchar(25)) + ' AND ' + Cast( @AmountTo As Varchar(25))
	IF @TrType <> 0 Set @Sql = @Sql +' And D.Acc_TranType = ' +Cast(@TrType As Varchar(20)) 
	IF @AccCode > 0 Set @Sql = @Sql +' And D.Acc_Code = ' +Cast(@AccCode As Varchar(20)) 
	Set @Sql = @Sql +  ') ORDER BY Acc_TrDate Desc,Acc_VrTyp ASC,Acc_VrNo Desc'

	print @Sql
	Exec sp_executesql @Sql
	
End
