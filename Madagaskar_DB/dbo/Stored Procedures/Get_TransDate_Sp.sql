
--Exec Get_TransDate_Sp 13,'01/01/1900'
CREATE Proc [dbo].[Get_TransDate_Sp]
(	
	@Trans_Date		As Date	= '01/01/1900'
)
as
Begin
	Declare @TrDate		Date

	IF @Trans_Date = '01/01/1900'
	Begin
		SELECT @TrDate = Cast(GETDATE() As Date)
	End
	Else
	Begin
		SELECT @TrDate = @Trans_Date
	End

	Select @TrDate AS TransDate
End







