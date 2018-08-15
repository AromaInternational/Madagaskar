
-- Author       :PRADEEP.T.V
-- Created Date :10/06/2014
-- Exec Proc_LocateCustData_Sp
CREATE PROCEDURE [dbo].[Proc_LocateCustData_Sp]
(
	@M_CmpCode			As Varchar(25),
    @M_CMID				As Varchar(25),
    @M_CMPhoneNo		As varchar(25),
	@M_TypeID			As Int
)
AS
BEGIN
	Declare @Sql			As NVarchar(MAX),
			@Filter			As Nvarchar(MAX)

	Set NoCount On

	Set @Filter = ' AND CM_TypeID='+CAST(@M_TypeID AS VARCHAR(10))

	IF LEN(@M_CMPhoneNo)>0 
	Begin
		Set @Sql = 'Select C.* from ClientMaster_Vw C Where C.Cmp_Code = ' + @M_CmpCode + ' AND C.CM_PhoneNo = ''' + @M_CMPhoneNo +''''
		Set @Sql = @Sql + @Filter
	End
	Else
	Begin
		Set @Sql = 'Select C.* from ClientMaster_Vw C Where C.Cmp_Code = ' + @M_CmpCode + ' AND C.CM_ID =' + @M_CMID
		Set @Sql = @Sql + @Filter
	End

	PRINT @Sql
	Exec Sp_executeSQL @Sql

    Set NoCount Off
END