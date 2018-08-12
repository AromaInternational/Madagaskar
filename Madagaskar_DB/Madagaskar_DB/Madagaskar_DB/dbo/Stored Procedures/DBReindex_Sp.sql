
-- Author       :PRADEEP.T.V
-- Created Date :04/06/2015
-- Exec DBReindex_Sp
CREATE PROCEDURE [dbo].[DBReindex_Sp]
AS 
BEGIN

	Declare @Tblname varchar(500),
			@Qrystr nvarchar(3000)
	Declare Cur_reindex cursor for 
	Select table_name from INFORMATION_SCHEMA.tables where table_type='BASE TABLE' ORDER BY table_name
	Open Cur_reindex
	Fetch Next From Cur_reindex InTo  @tblname
	While @@fetch_Status = 0
	Begin
		Set @Qrystr='DBCC DBREINDEX ('''+@tblname+''')'
		Print @Qrystr
		Exec sp_executesql @Qrystr
		Fetch Next From Cur_reindex InTo  @tblname
	End
	Close Cur_reindex
	Deallocate Cur_reindex

	Declare @DbName Varchar(500),
			@I		Int
	Select @DbName =DB_NAME(),@I=0

	While @I<=5
	Begin
		DBCC SHRINKDATABASE (@DbName, 0);
		Set @I=@I+1
	End

END



