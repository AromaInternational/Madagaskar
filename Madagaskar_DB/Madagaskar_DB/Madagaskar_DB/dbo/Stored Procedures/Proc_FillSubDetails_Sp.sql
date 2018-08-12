

-- Author       :PRADEEP.T.V
-- Created Date :14/12/2014
-- Exec dbo.Proc_FillSubDetails_Sp 6,2,3276,1
CREATE PROCEDURE [dbo].[Proc_FillSubDetails_Sp]
(
	@SubType			As int,
	@LinkType			As int,
	@LinkID				As bigint,
	@UserID				As Int
) AS 
BEGIN
	
	Set Nocount ON 

	If @SubType = 5 -- LOGS
	Begin
		SELECT ID, [Data Field], [Old Value], [New Value], [Modified By], [Modified Time]
		FROM LogDetails_Vw WHERE SourceID = @LinkType And MasterID = @LinkID ORDER BY ID DESC
	End
	Set Nocount OFF 
END


