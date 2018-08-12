

-- Author       :PRADEEP.T.V
-- Created Date :30/08/2014
-- Exec SplitString_Fn
CREATE FUNCTION [dbo].[SplitString_Fn]
(    
      @Input		Varchar(MAX),
      @Seperator	CHAR(1)
)
RETURNS @Output Table 
(
	Item VARCHAR(MAX)
)
AS
BEGIN
      DECLARE @StartIndex INT, @EndIndex INT
 
      SET @StartIndex = 1
      IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Seperator
      BEGIN
            SET @Input = @Input + @Seperator
      END
 
      WHILE CHARINDEX(@Seperator, @Input) > 0
      BEGIN
            SET @EndIndex = CHARINDEX(@Seperator, @Input)
           
            INSERT INTO @Output(Item)
            SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)
           
            SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))
      END
 
      RETURN
END



