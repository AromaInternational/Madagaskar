
-- Author       :PRADEEP.T.V
-- Created Date :02/08/2016
-- Exec GetNextID_Sp 'UserDetails_M_Tbl','USER_ID',@NextID OUT
CREATE PROCEDURE [dbo].[GetNextID_Sp]
(
    @Objname			As Nvarchar(776),
	@Primary_Field		As Varchar(50),
    @NextID				As BigInt Output
)
AS
BEGIN

	Set NoCount On
    Declare @ID			As Varchar(50),
			@Sql		As Nvarchar(4000),
			@Params nvarchar(500)
    Begin
		Set @Sql = 'SELECT @ID= MAX(' + @Primary_Field + ') FROM ' + @Objname
		Set @params='@ID Bigint OUTPUT'
		Exec sp_executesql @Sql,@Params,@ID = @ID OUTPUT

		Set @ID = IsNull(@ID,0) +1 
		Set @NextID = @ID
	End
    Set NoCount Off

END



