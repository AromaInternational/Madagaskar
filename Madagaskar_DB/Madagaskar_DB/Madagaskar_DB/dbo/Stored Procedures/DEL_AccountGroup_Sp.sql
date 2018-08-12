-- Author       :PRADEEP.T.V
-- Created Date :05/12/2015
-- Exec DEL_AccountGroup_Sp 'P',1011,1,'01/01/1900'
CREATE PROCEDURE [dbo].[DEL_AccountGroup_Sp]
(
	@Type			Char(1),
	@ID				bigint , 
	@Deleter_ID		int , 
	@Deleter_Time	datetime
) AS 
BEGIN
	Declare @Sql		As NVarchar(4000),
			@Message	Varchar(200)='Unable to Delete....',
			@DelStatus	Char(1)		='Y'
	Set Nocount ON 
	IF @Type = 'A'
	Begin
		IF EXISTS(SELECT 1 FROM AccLedger_T_Tbl WHERE Acc_Code = @ID) Or EXISTS(SELECT 1 FROM AccOpBal_M_Tbl WHERE Acc_Code = @ID)
		Begin
			Set @DelStatus = 'N'
			SELECT 'Unable to Delete This Account Head ........ Account Head is using for taransaction' R_Message, 'N' R_Status 
		End
	End
	Else If @Type = 'G'
	Begin
		IF EXISTS(SELECT 1 FROM AccountMaster_P_Tbl WHERE Acc_GPID = @ID)
		Begin
			Set @DelStatus = 'N'
			SELECT 'Unable to Delete........ Some of Account Heads are Under This Group' R_Message, 'N' R_Status 
		End

		IF EXISTS(SELECT 1 FROM AccountGroup_P_Tbl WHERE GP_ID <> @ID AND GP_ParentId = @ID)
		Begin
			Set @DelStatus = 'N'
			SELECT 'Unable to Delete........ Some of the Account Heads are Under This Group' R_Message, 'N' R_Status 
		End
	End

	IF @DelStatus = 'Y'
	BEGIN
		Begin Try
			Begin Tran X1

				-- Delete Existing Data
				IF @Type = 'A'
				Begin
					DELETE U From AccountMaster_P_Tbl U Where Acc_Code = @ID
					SELECT 'The Account Head deleted....' R_Message, 'Y' R_Status
				End
				Else IF @Type = 'G'
				Begin
					DELETE U From AccountGroup_P_Tbl U Where GP_ID = @ID 
					SELECT 'The Account Group deleted....' R_Message, 'Y' R_Status
				End

			Commit Tran X1
			Set Nocount ON
		End Try
		Begin Catch
			Declare @ErroMsg Varchar(1000)
			Set @ErroMsg='Proc: '+ERROR_PROCEDURE()+' Msg: '+ERROR_MESSAGE()
			RAISERROR(@ErroMsg, 16, 1)
			Select 'Error Occured....' + @ErroMsg As R_Message ,'N' R_Status
			Rollback Tran X1
		End Catch
	END
END
