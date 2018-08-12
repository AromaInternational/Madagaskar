
-- Author       :PRADEEP.T.V
-- Created Date :17/11/2016
-- Exec dbo.Proc_LogCurrent_ModifyDetails_Sp 'AccountsMaster_M_Tbl','AM_ID','1'
CREATE PROCEDURE [dbo].[Proc_LogCurrent_ModifyDetails_Sp]
(	
	@Filter_Tbl		varchar(100),
	@Filter_Col		varchar(100),
	@Filter_ID		Varchar(100)
)
AS
BEGIN
	Set Nocount ON 
	Declare		@ID			As Int,
				@ColName	As Varchar(100),
				@ColType	As varchar(100),
				@Sql		As Nvarchar(400),
				@Params		As Nvarchar(500),
				@Value		As Varchar(max)

	Declare @LogDetails_Tbl As Table
	(
		ColID			Int,
		ColName			varchar(100),
		ColType			varchar(100),
		ColDescription	varchar(100),
		Value			varchar(max)
	)
	
	INSERT INTO @LogDetails_Tbl(ColID,ColName,ColType,ColDescription,Value) 
	SELECT Cast(ColID As Int) ColID,Cast(ColName As Varchar(100))[ColName],Cast(ColType As Varchar(100)) ColType,
		Cast(ColDescription As Varchar(100)) ColDescription, '' Value
	FROM dbo.LogTablesStructure_Vw M
	WHERE (TableName =  @Filter_Tbl) ORDER BY ColID

	Declare Cur_Temp  Cursor LOCAL FAST_FORWARD READ_ONLY For 
		Select ColID,ColName,ColType 
	From @LogDetails_Tbl ORDER BY ColID 
	
	OPEN  Cur_Temp 
		
	FETCH NEXT From Cur_Temp INTO @ID,@ColName,@ColType
	While @@Fetch_Status = 0 
	Begin
		if @ColType in('datetime','date')
		Begin
			Set @Sql = 'SELECT @Value= CONVERT(VARCHAR(24),' + @ColName + ',113) FROM ' + @Filter_Tbl + ' WHERE ' + @Filter_Col + ' = ' + @Filter_ID
			Set @params='@Value Varchar(max) OUTPUT'
			Exec sp_executesql @Sql,@Params,@Value = @Value OUTPUT
		End
		Else
		Begin
			Set @Sql = 'SELECT @Value= ' + @ColName + ' FROM ' + @Filter_Tbl + ' WHERE ' + @Filter_Col + ' = ' + @Filter_ID
			Set @params='@Value Varchar(max) OUTPUT'
			Exec sp_executesql @Sql,@Params,@Value = @Value OUTPUT
		End

		UPDATE @LogDetails_Tbl SET Value = @Value WHERE ColName = @ColName
		FETCH NEXT From Cur_Temp INTO @ID,@ColName,@ColType
	End

	CLOSE 		Cur_Temp
	DEALLOCATE 	Cur_Temp

	SELECT ColID,ColName,ColDescription,Value FROM @LogDetails_Tbl Order by ColID
END


