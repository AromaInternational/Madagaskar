
-- Author       :PRADEEP.T.V
-- Created Date :17/11/2016
-- Exec IUM_LogMaster_Sp
CREATE PROCEDURE [dbo].[IUM_LogMaster_Sp]
(
	@LM_MMID		int , 
	@LM_MID			int , 
	@Maker_ID		int , 
	@Making_Time	datetime,
	@LogDetailsXML	Xml='' 
) AS 
BEGIN
	
	Set Nocount ON 
 Begin Try
	Begin Tran X1
	
	Declare @ID			As BigInt,
			@handle		As int

	Declare @LogDetails_Tbl As Table
	(
		ColID			Int,
		ColName			varchar(100),
		ColDescription	varchar(100),
		OldValue		varchar(max),
		NewValue		varchar(max)
	)

	If Exists (SELECT T.c.query('..') AS result
		FROM   @LogDetailsXML.nodes('/NewDataSet/Table') T(c))
	Begin
		-- INSERT MASTER DETAILS
		Exec GetNextID_Sp 'LogMaster_M_Tbl','LM_ID',@ID  OUTPUT 
		INSERT INTO dbo.LogMaster_M_Tbl(LM_ID,LM_MMID,LM_MID,Maker_ID,Making_Time) VALUES(@ID,@LM_MMID,@LM_MID,@Maker_ID,@Making_Time)
		
		-- EXTRACT LOG DETAILS
		EXEC sp_xml_preparedocument @handle OUTPUT, @LogDetailsXML
		INSERT INTO @LogDetails_Tbl(ColID,ColName,ColDescription,OldValue,NewValue) 
		SELECT ColID,ColName,ColDescription,OldValue,NewValue
		FROM OPENXML (@handle, 'NewDataSet/Table', 2) WITH 
		  (	
			ColID			Int,
			ColName			varchar(100),
			ColDescription	varchar(100),
			OldValue		varchar(max),
			NewValue		varchar(max)
		  )
		
		--INSERT LOG DETAILS
		INSERT INTO LogDetails_T_Tbl(LD_LMID, LD_FILELDNAME, LD_FILELD, LD_OLDVALUE, LD_NEWVALUE)
		SELECT @ID,ColName,ColDescription,OldValue,NewValue FROM @LogDetails_Tbl 
	End
	
	Commit Tran X1
	Set Nocount ON
	Return
 End Try
 Begin Catch
Error_Point:
		Declare @ErroMsg Varchar(1000)
		Set @ErroMsg='Proc: '+ERROR_PROCEDURE()+' Msg: '+ERROR_MESSAGE()
		RAISERROR(@ErroMsg, 16, 1)
		Rollback Tran X1 
		Return
	End Catch
END

