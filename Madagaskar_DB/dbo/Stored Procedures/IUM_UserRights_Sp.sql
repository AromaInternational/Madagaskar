
CREATE Procedure [dbo].[IUM_UserRights_Sp]
(
	@Entry_Mode		VARCHAR(15),
    @MM_ID			INT, 
	@UMID			Int, 
	@Maker_ID		int , 
	@Right_XML		AS XML=''
) As
Begin
	Declare @handle					INT,
			@Making_Time			Datetime,
			@Updating_Time			Datetime,
			@Updater_ID				Int,
			@Sql					As NVarchar(MAX)

	Set Nocount On

	Begin Try
	Begin Tran X1
	
	-- View
	If Exists(Select 1 From UserRights_M_Tbl Where UR_UMID=@UMID)
	BEGIN 
		SELECT Top 1 @Making_Time=Making_Time,@Updating_Time = GETDATE(),@Updater_ID = @Maker_ID
		From UserRights_M_Tbl Where UR_UMID=@UMID

		SELECT Top 1 @Maker_ID=Maker_ID
		From UserRights_M_Tbl Where UR_UMID=@UMID
		
	End
	Else --NEW
	Begin
		SELECT @Making_Time=Getdate(),@Updating_Time = '01/01/1900',@Updater_ID = 0
	End
	
	If Exists (SELECT T.c.query('..') AS result
		FROM   @Right_XML.nodes('/NewDataSet/Table') T(c))
	Begin
		EXEC sp_xml_preparedocument @handle OUTPUT, @Right_XML

		IF OBJECT_ID('tempdb..#UserRights') IS NOT NULL DROP TABLE Tempdb..#UserRights
		
		SELECT * Into #UserRights FROM OPENXML (@handle, 'NewDataSet/Table', 2) WITH 
		  (	
			MM_ID int,
			UR_View Char(1),
			UR_Add Char(1),
			UR_Edit Char(1),
			UR_Delete Char(1),
			UR_Print Char(1),
			UR_Authn Char(1)
		  )
		
		Delete From UserRights_M_Tbl Where UR_UMID=@UMID
		
		Insert Into UserRights_M_Tbl
			(
				UR_MMID, UR_UMID, UR_View, UR_Add, UR_Edit, UR_Delete, UR_Print, UR_Authn,
				Maker_ID, Making_Time, Updater_ID, Updating_Time
			)
		Select MM_ID UR_MMID, @UMID UR_UMID, UR_View, UR_Add, UR_Edit, UR_Delete, UR_Print, UR_Authn,
				@Maker_ID, @Making_Time, @Updater_ID, @Updating_Time
		From #UserRights

	End

	Commit Tran X1
	SELECT @UMID AS ID
	End Try
	Begin Catch
		Declare @ErroMsg Varchar(1000)
		Set @ErroMsg='Proc: '+ERROR_PROCEDURE()+' Msg: '+ERROR_MESSAGE()
		RAISERROR(@ErroMsg, 16, 1)
		Rollback Tran X1
		SELECT 0 AS ID
	End Catch
End



