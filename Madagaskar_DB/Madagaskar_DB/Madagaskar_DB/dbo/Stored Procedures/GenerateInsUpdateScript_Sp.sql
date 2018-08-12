
--Exec GenerateInsUpdateScript_Sp 'UserDetails_M_Tbl','User_ID'
CREATE PROCEDURE [dbo].[GenerateInsUpdateScript_Sp]
(
	@Objname_Main		As nvarchar(776),
	@Primary_Field		As Varchar(50)
)
AS
Begin

	SET NOCOUNT ON

	DECLARE @objid			int,
			@sysobj_type	char(2),
			@colname		sysname,
			@numtypes		nvarchar(80),
			@avoidlength	nvarchar(80),
			@IsString		nvarchar(80),
			@SyncQry		nvarchar(4000),
			@TempColName	nvarchar(4000),
			@TempValues		nvarchar(4000),
			@Name			sysname,
			@xtype			tinyint,
			@ForCasting		nvarchar(4000)


	CREATE TABLE #MyProc
	(
		pkey		INT NOT NULL IDENTITY (1, 1),
		ID			INT ,
		MyStatement NVARCHAR(4000)
	)

	SELECT @objid = id, @sysobj_type = xtype from sysobjects where id = object_id(@Objname_Main)
	SELECT @colname = name from syscolumns where id = @objid and name = @Primary_Field

	-- DISPLAY COLUMN IF TABLE / VIEW

	if @sysobj_type in ('S ','U ','V ','TF','IF')
	begin

		SELECT @numtypes = N'decimalreal,money,numeric,smallmoney'
		SELECT @avoidlength = N'int,smallint,datatime,smalldatetime,text,bit,float,bigint'
		SELECT @IsString = N'datatime,smalldatetime,text,nvarchar,char,varchar'
		SELECT @ForCasting = N'datatime,smalldatetime,decimalreal,money,float,numeric,smallmoney,int,smallint,bit,bigint'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 0, '-- Author       :PRADEEP.T.V'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 1, '-- Created Date :' + CONVERT(VARCHAR(24),GETDATE(),103)

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 2, '-- Exec IUM_'+ Left(@Objname_Main , Len(@Objname_Main)-6) +'_Sp'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 3, 'CREATE PROCEDURE IUM_' + Left(@Objname_Main , Len(@Objname_Main)-6) +'_Sp'+ CHAR(13) + '(' + CHAR(13) + '    @Entry_Mode VARCHAR(15),' + CHAR(13) + '    @MM_ID INT,' 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 4, '	@' + name + ' ' + 
			type_name(xusertype) + ' ' + case when charindex(type_name(xtype),@avoidlength) > 0
			then '' else
			case when charindex(type_name(xtype), @numtypes) <= 0 then '(' + convert(varchar(10), length) + ')' else '(' +
			case when charindex(type_name(xtype), @numtypes) > 0
			then convert(varchar(5),ColumnProperty(id, name, 'precision'))
			else '' end + case when charindex(type_name(xtype), @numtypes) > 0 then ',' else ' ' end + 
			case when charindex(type_name(xtype), @numtypes) > 0
			then convert(varchar(5),OdbcScale(xtype,xscale))
			else '' end + ')' end end + ', '
		FROM syscolumns where id = @objid and number = 0 order by colid

		update #MyProc set MyStatement = Replace(MyStatement,', ',' ') where 
		pkey = (SELECT max(pkey) from #MyProc)

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 5, ') AS '

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 6, 'BEGIN' 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 7, '	'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 8, '	Set Nocount ON '

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 9, ' Begin Try'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 10, '	Begin Tran X1'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 11, '	'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 12, '	Declare @NextID	As BigInt'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 13, '	IF @Entry_Mode =''NEW'''

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 14, '	BEGIN '

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 15, '		Exec GetNextID_Sp ''' + @Objname_Main + ''','''+  @Primary_Field + ''',@NextID  OUTPUT ' 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 16, '		SET @' + @colname + ' = @NextID '

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 17, '	'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 18, '		INSERT INTO dbo.' + @Objname_Main 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 19, '		('

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 20, '			' + name + ','

		from syscolumns where id = @objid and number = 0 order by colid


		update #MyProc set MyStatement = Replace(MyStatement,',','') where 
		pkey = (SELECT max(pkey) from #MyProc)


		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 21, '		)'



		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 22, '		VALUES'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 23, '		('


		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 24, '			@' + name + ','

		from syscolumns where id = @objid and number = 0 order by colid


		update #MyProc set MyStatement = Replace(MyStatement,',','') where 
		pkey = (SELECT max(pkey) from #MyProc)


		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 25, '		)'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 26, '	END'	

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 27, '	ELSE'
			
		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 28, '	BEGIN'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 29, '		--SELECT CURRENT DATA' 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 30, '		Declare @LogOldValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))' 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 31, '		INSERT INTO @LogOldValue_Tbl(ColID,ColName,ColDescription,Value)' 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 32, '		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp ''' + @Objname_Main + ''',''' + @colname + ''',@'+@colname 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 33, '		'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 34, '		UPDATE dbo.' + @Objname_Main + ' SET ' 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 35, '			' + name + ' = @' + name + ' ,'

		from syscolumns where id = @objid and number = 0 order by colid

		update #MyProc set MyStatement = Replace(MyStatement,',','') where 
		pkey = (SELECT max(pkey) from #MyProc)

		DELETE FROM #MyProc 
		WHERE ID = 35 and MyStatement like '%' + @colname + '%'

		DELETE FROM #MyProc 
		WHERE ID = 35 and MyStatement like '%Maker_ID%'

		DELETE FROM #MyProc 
		WHERE ID = 35 and MyStatement like '%Making_Time%'


		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 36, '		WHERE ' + @colname + '= @' + @colname 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 37, '		'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 37, '		--SELECT NEW DATA'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 38, '		Declare @LogNewValue_Tbl As Table(ColID Int,ColName varchar(100),ColDescription	varchar(100),Value varchar(Max))'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 39, '		INSERT INTO @LogNewValue_Tbl(ColID,ColName,ColDescription,Value)'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 40, '		Exec dbo.Proc_LogCurrent_ModifyDetails_Sp ''' + @Objname_Main + ''',''' + @colname + ''',@'+@colname 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 41, '		'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 41, '		Declare @LogDetailsXML	As Xml='''''

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 42, '		Set @LogDetailsXML=(Select O.ColID,O.ColName,O.ColDescription,O.Value OldValue, N.Value NewValue From @LogNewValue_Tbl N JOIN @LogOldValue_Tbl O ON N.ColID = O.ColID WHERE O.Value <> N.Value For XML Path(''Table''),Root(''NewDataSet''))'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 43, '		Exec dbo.IUM_LogMaster_Sp @LM_MMID = @MM_ID, @LM_MID = @'+@colname +', @Maker_ID = @Updater_ID, @Making_Time = @Updating_Time ,@LogDetailsXML	= @LogDetailsXML'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 44, '		'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 44,'	END'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 45,'	'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 46, '	SELECT @' + @colname + ' AS ID' 

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 47,'	'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 48,'	Commit Tran X1'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 49,'	Set Nocount ON'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 50,'	Return'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 51,' End Try'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 52,' Begin Catch'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 53,'Error_Point:'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 54,'		Declare @ErroMsg Varchar(1000)'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 55,'		Set @ErroMsg=''Proc: ''+ERROR_PROCEDURE()+'' Msg: ''+ERROR_MESSAGE()'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 56,'		RAISERROR(@ErroMsg, 16, 1)'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 57, '		SELECT 0 AS ID'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 58,'		Rollback Tran X1 '
			
		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 59,'		Return'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 60,'	End Catch'

		INSERT INTO #MyProc (ID, MyStatement)
		SELECT 61,'END'
		
		Declare @Str As nvarchar(4000)

		Declare Cur_Temp  Cursor LOCAL FAST_FORWARD READ_ONLY For Select MyStatement  from #MyProc ORDER BY ID 
		OPEN  Cur_Temp
		FETCH NEXT From Cur_Temp INTO @Str
		While @@Fetch_Status = 0
		Begin
			Print @Str
			FETCH NEXT From Cur_Temp INTO @Str
      	END							

		CLOSE 		Cur_Temp
		DEALLOCATE 	Cur_Temp


	end

End


