
-- Author       :PRADEEP.T.V
-- Created Date :05/04/2016
-- SELECT * FROM  dbo.FinYear_Details_Fn(1,'04/01/2016')
CREATE FUNCTION [dbo].[FinYear_Details_Fn]
(	
	@CmpCode	As Int,
	@TransDate	As Date
)
RETURNS @Fin_Tbl Table 
(
	[Fin_ID]			Int	NULL,
	[Fin_Period]		Varchar(25) NULL,
	[Fin_OBDate]		Date NULL,
	[Fin_StartDate]		Date NULL,
	[Fin_EndDate]		Date NULL,
	[Current_Fin]		Char(1) NULL
)
AS
BEGIN
	Declare @FirstDate		DateTime,
			@LastDate		DateTime,	
			@FinID			Int = 0,
			@Fin_Year		Varchar(25),
			@Fin_OBDate		Date,
			@Fin_StartDate	Date,
			@Fin_EndDate	Date
	Declare @Cur_FinYearFrom	Date= Case When Month(@TransDate)< 4 Then Cast('04/01/'+ Cast((Year(@TransDate)-1) as varchar(4))AS Date) Else Cast('04/01/'+ Cast((Year(@TransDate)) as varchar(4))AS Date)End

	IF @CmpCode > 0 
	Begin
		Set @FirstDate = DATEADD(DAY,-1,@TransDate)
		Set @LastDate  = @TransDate
	End
	Else
	Begin
		Set @FirstDate = '01/01/2017'
		Set @LastDate  = @TransDate
	End

	While NOT @FirstDate >= @LastDate
	Begin
		Set @FinID = @FinID + 1
		Select @Fin_Year = CASE WHEN MONTH(@FirstDate) < 4 THEN CAST(RIGHT('00' + YEAR(@FirstDate), 2) - 1 AS Varchar(2)) + '-' + CAST(RIGHT('00' + YEAR(@FirstDate), 2) AS Varchar(2)) ELSE CAST(RIGHT(YEAR(@FirstDate), 2) AS Varchar(2)) + '-' + CAST(RIGHT(YEAR(@FirstDate), 2) + 1 AS Varchar(2)) END
		Select @Fin_StartDate = Case When Month(@FirstDate)< 4 Then Cast('04/01/'+ Cast((Year(@FirstDate)-1) as varchar(4))AS Date) Else Cast('04/01/'+ Cast((Year(@FirstDate)) as varchar(4))AS Date)End
		Select @Fin_EndDate = Case When Month(@FirstDate)< 4 Then Cast('03/31/'+ Cast((Year(@FirstDate)) as varchar(4))AS Date) Else Cast('03/31/'+ Cast((Year(@FirstDate)+1) as varchar(4))AS Date)End
		Select @Fin_OBDate = DateAdd(Day,-1,@Fin_StartDate)
		Insert InTo @Fin_Tbl(Fin_ID,Fin_Period,Fin_OBDate,Fin_StartDate,Fin_EndDate,Current_Fin) Values (@FinID,@Fin_Year,@Fin_OBDate,@Fin_StartDate,@Fin_EndDate,'N')

		SET @FirstDate = DATEADD(YEAR,1,@FirstDate)
		IF @FirstDate >= @LastDate
		Begin
			Set @FinID = @FinID + 1
			Select @Fin_Year = CASE WHEN MONTH(@FirstDate) < 4 THEN CAST(RIGHT('00' + YEAR(@FirstDate), 2) - 1 AS Varchar(2)) + '-' + CAST(RIGHT('00' + YEAR(@FirstDate), 2) AS Varchar(2)) ELSE CAST(RIGHT(YEAR(@FirstDate), 2) AS Varchar(2)) + '-' + CAST(RIGHT(YEAR(@FirstDate), 2) + 1 AS Varchar(2)) END 
			Select @Fin_StartDate = Case When Month(@FirstDate)< 4 Then Cast('04/01/'+ Cast((Year(@FirstDate)-1) as varchar(4))AS Date) Else Cast('04/01/'+ Cast((Year(@FirstDate)) as varchar(4))AS Date)End
			Select @Fin_EndDate = Case When Month(@FirstDate)< 4 Then Cast('03/31/'+ Cast((Year(@FirstDate)) as varchar(4))AS Date) Else Cast('03/31/'+ Cast((Year(@FirstDate)+1) as varchar(4))AS Date)End
			Select @Fin_OBDate = DateAdd(Day,-1,@Fin_StartDate)
			Insert InTo @Fin_Tbl(Fin_ID,Fin_Period,Fin_OBDate,Fin_StartDate,Fin_EndDate,Current_Fin) Values (@FinID,@Fin_Year,@Fin_OBDate,@Fin_StartDate,@Fin_EndDate,'N')
		End
	End

	UPDATE W SET Current_Fin = 'Y' FROM @Fin_Tbl W WHERE Fin_StartDate = @Cur_FinYearFrom

    Return
END

