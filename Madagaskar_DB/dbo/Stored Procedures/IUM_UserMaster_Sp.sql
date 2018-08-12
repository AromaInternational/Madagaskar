
-- Author       :PRADEEP.T.V
-- Created Date :09/09/2016
-- Exec IUM_UserMaster_Sp
CREATE PROCEDURE [dbo].[IUM_UserMaster_Sp]
(
    @Entry_Mode			VARCHAR(15),
    @MM_ID				INT,
	@UM_ID				int , 
	@UM_DepID			int , 
	@UM_DesID			int , 
	@UM_TypeID			int , 
	@UM_Name			varchar (50), 
	@UM_Pwd				varchar (50),
	@UM_UNID			int , 
	@UM_AutoLogOutPeriod int , 
	@Active_Status		char (1), 
	@Maker_ID			int , 
	@Making_Time		datetime , 
	@Updater_ID			int , 
	@Updating_Time		datetime,
	@UnitDetails		XML = ''  
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @NextID	As BigInt, 
			@Sql	As NVarchar(4000),
			@handle INT 
	IF @Entry_Mode ='NEW'
	BEGIN 
		Exec GetNextID_Sp 'UserMaster_M_Tbl','UM_ID',@NextID  OUTPUT 
		SET @UM_ID = Case When @NextID = 1 Then 2 Else @NextID End
	
		INSERT INTO dbo.UserMaster_M_Tbl
		(
			UM_ID,
			UM_DepID,
			UM_DesID,
			UM_TypeID,
			UM_Name,
			UM_Pwd,
			UM_UNID,
			UM_AutoLogOutPeriod,
			Active_Status,
			Maker_ID,
			Making_Time,
			Updater_ID,
			Updating_Time
		)
		VALUES
		(
			@UM_ID,
			@UM_DepID,
			@UM_DesID,
			@UM_TypeID,
			@UM_Name,
			Cast(@UM_Pwd As varbinary(50)) ,
			@UM_UNID,
			@UM_AutoLogOutPeriod,
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
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'UserMaster_M_Tbl','UM_ID',@UM_ID

		UPDATE dbo.UserMaster_M_Tbl SET 
			UM_DepID = @UM_DepID ,
			UM_DesID = @UM_DesID ,
			UM_TypeID = @UM_TypeID ,
			UM_Name = @UM_Name ,
			UM_Pwd = Cast(@UM_Pwd As varbinary(50)) ,
			UM_UNID = @UM_UNID ,
			UM_AutoLogOutPeriod = @UM_AutoLogOutPeriod ,
			Active_Status = @Active_Status ,
			Updater_ID = @Updater_ID ,
			Updating_Time = @Updating_Time 
		WHERE UM_ID= @UM_ID

		--SELECT NEW DATA
		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))
		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)
		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'UserMaster_M_Tbl','UM_ID',@UM_ID

		Declare @LogDetailsXML	As Xml=''
		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path('Table'),Root('NewDataSet'))
		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @UM_ID, @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML
	END
	
	DELETE FROM UserUnitDetails_T_Tbl WHERE UM_ID= @UM_ID

	If Exists (SELECT T.c.query('..') AS result
		FROM   @UnitDetails.nodes('/NewDataSet/Table') T(c))
	Begin
		EXEC sp_xml_preparedocument @handle OUTPUT, @UnitDetails

		IF OBJECT_ID('tempdb..#TempEmp_Tbl') IS NOT NULL DROP TABLE Tempdb..#TempEmp_Tbl
			
		SELECT * Into #TempEmp_Tbl FROM OPENXML (@handle, 'NewDataSet/Table', 2) WITH 
			(	 
				ID			Varchar(10)
			)      
		Insert Into UserUnitDetails_T_Tbl(UM_ID, UN_TreeCode) Select @UM_ID,ID From #TempEmp_Tbl
	End

	SELECT @UM_ID AS ID
	
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

