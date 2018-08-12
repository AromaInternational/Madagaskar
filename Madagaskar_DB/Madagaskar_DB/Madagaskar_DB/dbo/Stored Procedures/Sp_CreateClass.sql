
--  Exec Sp_CreateClass 'PettyTranHeads_P_Tbl' ,'Pty_ID','M_PettyTranHeads', 'PettyTranHeads','bo'
CREATE Proc [dbo].[Sp_CreateClass] 
(
	@TabName			varchar(100),
	@Primary_Field		As Varchar(50),
	@VarName			varchar(100), -- Variable Name for Class
	@ClassName			varchar(100),
	@Return_Class		Varchar(2) --BL , BO, DA
)
as
set nocount on
Declare @Str		As	NVarchar(4000)
Declare @IdCol		As Varchar(100) -- Identity Field without Underscore
Declare @uId_Col	As Varchar(100) -- Identity Field with Underscore
Declare @Id_ColType	As Varchar(100) -- Identity Field with Underscore

If @Return_Class In ('BL','DA','UI')
Begin
	SELECT    @IdCol=replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') ,
			  @uId_Col=dbo.syscolumns.name,
			  @Id_ColType = replace(replace(replace(replace(replace(replace(replace(dbo.systypes.name ,'varchar','string'),'bigint','Long'),'float','double'),'datetime','date'),'int','integer'),'numeric','double'),'char','string')
	FROM         dbo.sysobjects INNER JOIN
						  dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id INNER JOIN
						  dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype
	WHERE     (dbo.sysobjects.name =  @TabName  and dbo.syscolumns.name = @Primary_Field )
End

-- Business Objects
If Upper(@Return_Class)='BO'
Begin
	select 'Public Class ' + @ClassName + 'BO'
	UNION ALL
	SELECT    'Private M_' +   replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') + ' as '+ 
	replace(replace(replace(replace(replace(replace(replace(replace(dbo.systypes.name ,'nvarchar','string'),'varchar','string'),'bigint','Long'),'float','double'),'datetime','date'),'int','integer'),'numeric','double'),'char','string')
	FROM         dbo.sysobjects INNER JOIN
						  dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id INNER JOIN
						  dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype
	WHERE     (dbo.sysobjects.name =  @TabName  )

	UNION ALL
	select  'Public Property  '+  
	replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') +'()'+  ' as '+
	replace(replace(replace(replace(replace(replace(replace(replace(dbo.systypes.name ,'nvarchar','string'),'varchar','string'),'bigint','Long'),'float','double'),'datetime','date'),'int','integer'),'numeric','double'),'char','string') + char(13)+'  ' +
			'Get' +char(13)+
				'Return M_' + replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') + Case When dbo.systypes.name in('nvarchar','varchar','char') Then '.Trim()' Else '' End + char(13) +
			'End Get' +char(13)+
			'Set(ByVal value As ' +  replace(replace(replace(replace(replace(replace(replace(replace(dbo.systypes.name ,'nvarchar','string'),'varchar','string'),'bigint','Long'),'float','double'),'datetime','date'),'int','integer'),'numeric','double'),'char','string') + ')' + char(13) +
				Case When dbo.systypes.name<>'varchar' or dbo.systypes.name<>'char' or dbo.systypes.name<>'nvarchar' Then
					'M_' + replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') + '= value' + Case When dbo.systypes.name in('nvarchar','varchar','char') Then '.Trim()' Else '' End + char(13) 
				Else 'M_' + replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') + '= Replace(Replace(value,"''","`"),";",",")' + Case When dbo.systypes.name in('nvarchar','varchar','char') Then '.Trim()' Else '' End + char(13) End +
			'End Set' + char(13) +
			'End Property'
	FROM         dbo.sysobjects INNER JOIN
						  dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id INNER JOIN
						  dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype
	WHERE     (dbo.sysobjects.name =  @TabName )
	UNION ALL
	SELECT 'End Class '
End
-- Business Logic
If Upper(@Return_Class)='BL'
Begin
	Set @Str=''
	
	Set @Str='Imports FINMaN_DA'+Char(13)+'Imports FINMaN_BO'+Char(13)+'Imports FINMaN_BL.CommonBL'+Char(13)+'Imports FINMaN_CO.CommonClass'+char(13)
	
	Set @Str=@Str+'Public Class ' + @ClassName + 'BL' +char(13)

	Set @Str=@Str+'Private M_' + @IdCol + ' as ' + @Id_ColType +Char(13)

	Set @Str=@Str+'Public Function Save_Data(ByVal '+@VarName+' As '+@ClassName + 'BO,ByVal M_EntryMode As String, ByVal M_MenuID As Integer) As ' + @Id_ColType
	Set @Str=@Str+Char(13)+ '  Try'+Char(13)+Char(13)
	Set @Str=@Str+'Dim M_'+@ClassName+'DA As New '+@ClassName+'DA'+Char(13)
	Set @Str=@Str+'Dim UserTime As String'+Char(13)
	Set @Str=@Str+'If CheckUserRight(M_EntryMode, '+@VarName+'.MakerID, M_MenuID) = True Then' +Char(13)
	Set @Str=@Str+'UserTime = Get_UserTime()'+Char(13)
	Set @Str=@Str+'M_'+@IdCol+' = M_'+@ClassName+'DA.Save_Data('+@VarName+',M_EntryMode,M_MenuID, UserTime)' +Char(13)
	Set @Str=@Str+'M_'+@ClassName+'DA = Nothing'+Char(13)
	Set @Str=@Str+'Return M_'+@IdCol+Char(13)
	Set @Str=@Str+'Else'+Char(13)
    Set @Str=@Str+'Return 0'+Char(13)
    Set @Str=@Str+'End If'+Char(13)+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)
	Set @Str=@Str+'Return 0'+Char(13)
	Set @Str=@Str+'End Try'+Char(13)
	Set @Str=@Str+'End Function'+Char(13)+Char(13)

	Set @Str=@Str+'Public Function Locate_Data(ByVal M_'+@IdCol+' As ' + @Id_ColType +') As '+@ClassName+'BO' +Char(13)
	Set @Str=@Str+'Try'+Char(13)+Char(13)
	Set @Str=@Str+'Dim M_'+@ClassName+'DA As New '+@ClassName+'DA'+Char(13)
	Set @Str=@Str+'Return M_'+@ClassName+'DA.Locate_Data(M_'+@IdCol+')'+Char(13)
	Set @Str=@Str+'M_'+@ClassName+'DA = Nothing'+Char(13)+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)
	Set @Str=@Str+'Return Nothing'+Char(13)
	Set @Str=@Str+'End Try'+Char(13)
	Set @Str=@Str+'End Function'+Char(13)+Char(13)
	Set @Str=@Str+'End Class '
	print @Str
End

-- Data Access
If Upper(@Return_Class)='DA'
Begin
	Set @Str=''	
	Set @Str='Imports FINMaN_DAL'+Char(13)+'Imports FINMaN_BO'+Char(13)+'Imports FINMaN_CO'++char(13)
	Set @Str=@Str+ 'Public Class ' + @ClassName + 'DA' +char(13)
	Set @Str=@Str+'Private M_DBConn As Connection'+Char(13)
	Set @Str=@Str+'Private M_' + @IdCol + ' as ' + @Id_ColType +Char(13)
	Set @Str=@Str+'Public Function Save_Data(ByVal '+@VarName+' As '+@ClassName + 'BO,ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As ' + @Id_ColType +Char(13)
	Set @Str=@Str+'  Try'+Char(13)
	Set @Str=@Str+'Dim M_Sql As String'+Char(13)+Char(13)
	Set @Str=@Str+'With '+@VarName+Char(13)
	Set @Str=@Str+'M_Sql = "Exec IUM_' + Left(@TabName , Len(@TabName)-6) +'_Sp "' + Char(13)
	Set @Str=@Str+'M_Sql = M_Sql & ' + '"''" & ' + 'M_EntryMode' + ' & "'',"' +Char(13)
	Set @Str=@Str+'M_Sql = M_Sql & ' + 'M_MenuID' + ' & ","' +Char(13)
	print @Str
	Set @Str=''

	select  'M_Sql = M_Sql & '+
	Case When dbo.systypes.name In ('tinyint','smallint','int','money','float','bit','decimal','numeric','smallmoney','bigint')
			Then '' Else '"''" & ' End + 
	Case When dbo.systypes.name In ('date','datetime') and dbo.syscolumns.name not in('Making_Time','Updating_Time')
			Then ' Format(' Else '' End + 
	Case When dbo.syscolumns.name ='Making_Time' then  'UserTime' 
		 When dbo.syscolumns.name ='Updating_Time' then 'IIf(M_EntryMode = "NEW", "01/01/1900",UserTime)'
	Else +'.'+  replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') End + 
	Case When dbo.systypes.name In ('date','datetime') and dbo.syscolumns.name not in('Making_Time','Updating_Time')
			Then ' ,"MM/dd/yyyy")' Else '' End + ' & ' +
	Case When (SELECT MAX(colid) FROM dbo.sysobjects INNER JOIN dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id INNER JOIN dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype WHERE(dbo.sysobjects.name =  @TabName )) <> colid 
			Then
				Case When dbo.systypes.name In ('tinyint','smallint','int','money','float','bit','decimal','numeric','smallmoney','bigint') Then '","' Else '"'',"' End
			Else	
				Case When dbo.systypes.name In ('tinyint','smallint','int','money','float','bit','decimal','numeric','smallmoney','bigint') Then '' Else '"''"' End
			End
	FROM         dbo.sysobjects INNER JOIN
						  dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id INNER JOIN
						  dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype
	WHERE     (dbo.sysobjects.name =  @TabName ) order by colid


	Set @Str=@Str+'End With' + Char(13)+Char(13)
	Set @Str=@Str+'M_'+@IdCol+' = M_DBConn.ExecuteScalar(M_Sql)'+ Char(13)+Char(13)
	Set @Str=@Str+'Return M_'+@IdCol+ Char(13)+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)
	Set @Str=@Str+'    MsgBox(ex.Message)'+Char(13)
	Set @Str=@Str+'    Return False'+Char(13)
	Set @Str=@Str+'End Try'+Char(13)+Char(13)
	Set @Str=@Str+'End Function'+Char(13)+Char(13)
	Print @Str

	Set @Str=''
	Set @Str=@Str+'Public Function Locate_Data(ByVal M_'+@IdCol+' As ' + @Id_ColType +') As '+@ClassName+'BO'+Char(13)
	Set @Str=@Str+'Try'+Char(13)
	Set @Str=@Str+'Dim M_Dt As New DataTable'+Char(13)
	Set @Str=@Str+'Dim '+@VarName+' As New '+@ClassName+'BO'+Char(13)
	Set @Str=@Str+'Dim Qry As String'+Char(13)
	Set @Str=@Str+'Qry = "Select * from '+@TabName+' where '+@uId_Col+' = " & M_'+@IdCol+Char(13)
	Set @Str=@Str+'M_DBConn.ExecuteDataTable(M_Dt, Qry)'+Char(13)
	Set @Str=@Str+'If M_Dt.Rows.Count > 0 Then'+Char(13)
	Set @Str=@Str+'With '+@VarName+Char(13)

	print @Str
	Set @Str=''

	select  '.'+  
	replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') + ' =M_Dt.Rows(0).Item("' +
	dbo.syscolumns.name+'")'
	FROM         dbo.sysobjects INNER JOIN
						  dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id INNER JOIN
						  dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype
	WHERE     (dbo.sysobjects.name =  @TabName )


	Set @Str=@Str+'End With'+Char(13)
	Set @Str=@Str+'End If'+Char(13)
	Set @Str=@Str+'Return '+@VarName+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)
	Set @Str=@Str+'Return Nothing'+Char(13)
	Set @Str=@Str+'End Try'+Char(13)
	Set @Str=@Str+'End Function'+Char(13)+Char(13)
	Set @Str=@Str+'Public Sub New()'+Char(13)
	Set @Str=@Str+'M_DBConn = New Connection'+Char(13)
	Set @Str=@Str+'End Sub'+Char(13)

	print @Str

	Set @Str='End Class '
	print @Str
End

-- User Interface
If Upper(@Return_Class)='UI'
Begin
	
	Set @Str=''	
	Set @Str='Imports FINMaN_DAL'+Char(13)+'Imports FINMaN_BO'+Char(13)+'Imports FINMaN_CO'+Char(13)+'Imports FINMaN_BL'+char(13)+'Imports FINMaN_CO.CommonClass'+char(13)+'Imports System.Windows.Forms'+Char(13)+Char(13)
	Set @Str=@Str+'Public Class ' + @ClassName + '_Frm'+Char(13)
	Print @Str

	Set @Str='Dim M_'+ @IdCol + ' As ' + @Id_ColType +Char(13)
	Set @Str=@Str+'Dim M_CommonBL As New CommonBL'+Char(13)
	Set @Str=@Str+'Dim M_EntryMode As String'+Char(13)
	Set @Str=@Str+'Dim M_'+@ClassName+'BL As New '+@ClassName+'BL'+Char(13)+Char(13)
	Print @Str

	Set @Str='Private Sub Clear_Controls()'+Char(13)
	Set @Str=@Str+'Try'+Char(13)
	Set @Str=@Str+'M_EntryMode = "NEW"'+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)
	Set @Str=@Str+'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)'+Char(13)
	Set @Str=@Str+'End Try'+Char(13)+'End Sub'+Char(13)+Char(13)
	Print @Str

	Set @Str='Private Sub Fill_Details()'+Char(13)
	Set @Str=@Str+'Try'+Char(13)
	Set @Str=@Str+'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor'+Char(13)+Char(13)
	Set @Str=@Str+'Call Fill_ActiveStatus(Cmb_ActveStatus)'+Char(13)
	Set @Str=@Str+'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default'+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)
	Set @Str=@Str+'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default'+Char(13)
	Set @Str=@Str+'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)'+Char(13)
	Set @Str=@Str+'End Try'+Char(13)+'End Sub'+Char(13)+Char(13)
	Print @Str


	Set @Str='Public Function ValidateControls() As Boolean'+Char(13)+Char(13)
	Set @Str=@Str+'Dim sMsg As String'+Char(13)+Char(13)
	Set @Str=@Str+'Try'+Char(13)
	Set @Str=@Str+'Return True '+Char(13)
	Set @Str=@Str+'Exit Function'+Char(13)
	Set @Str=@Str+'Invalid:'+Char(13)
    Set @Str=@Str+'If sMsg <> "" Then MsgBox(sMsg, MsgBoxStyle.Critical, "Could not Save")'+Char(13)
	Set @Str=@Str+'Return False'+Char(13)
	Set @Str=@Str+'Exit Function'+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)
	Set @Str=@Str+'Return False '+Char(13)
	Set @Str=@Str+'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)'+Char(13)
	Set @Str=@Str+'End Try'+Char(13)+'End Function'+Char(13)+Char(13)
	Print @Str

	Set @Str='Private Sub ' + @ClassName + '_Frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load'+Char(13)+Char(13)
	Set @Str=@Str+'Try'+Char(13)
    Set @Str=@Str+'Call Fill_Details()'+Char(13)
	Set @Str=@Str+'Call Clear_Controls()'+Char(13)
    Set @Str=@Str+'Txt_' + @IdCol +'.Focus()'+Char(13)+Char(13)
	
	Set @Str=@Str+'Catch ex As Exception'+Char(13)
	Set @Str=@Str+'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)'+Char(13)
	Set @Str=@Str+'End Try'+Char(13)+'End Function'+Char(13)+Char(13)
	Print @Str

	Set @Str='Private Sub Cmd_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Close.Click'+Char(13)
    Set @Str=@Str+'Me.Close()'+Char(13)
    Set @Str=@Str+'End Sub'+Char(13)+Char(13)
	Print @Str

	Set @Str='Private Sub ' + @ClassName + '_Frm_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress'+Char(13)+Char(13)
    Set @Str=@Str+'Call SendKeyTab(Me, e)'+Char(13)
    Set @Str=@Str+'End Sub'+Char(13)
	Print @Str

	Set @Str='Private Sub Cmd_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Save.Click' +Char(13)+Char(13)
	Set @Str=@Str+'Dim '+@VarName+' As New FINMaN_BO.'+@ClassName+'BO'+Char(13)+Char(13)
	
	Set @Str=@Str+'If ValidateControls()=False Then Exit Function '+Char(13)
	Set @Str=@Str+'With '+@VarName+Char(13)
	Print @Str
	Set @Str=''

	select '.'+  
		replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') + ' = ' + Case When dbo.syscolumns.name = 'Updater_ID' Then 'IIf(M_EntryMode = "NEW", 0, User_ID)' When dbo.syscolumns.name = 'Maker_ID' Then 'User_ID' Else 'M_' + replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') End
	FROM         dbo.sysobjects INNER JOIN
						  dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id INNER JOIN
						  dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype
	WHERE     (dbo.sysobjects.name =  @TabName ) AND dbo.syscolumns.name NOT IN('Making_Time','Updating_Time') ORDER BY dbo.syscolumns.id
	
	Set @Str='End With'+Char(13)+Char(13)
	Set @Str=@Str+'Try'+Char(13)
	Set @Str=@Str+'Dim M_'+@ClassName+'BL As New '+@ClassName+'BL'+Char(13)
	Set @Str=@Str+'M_'+@IdCol+' = M_'+@ClassName+'BL.Save_Data('+@VarName+', M_EntryMode, Me.Tag)'+Char(13)

	Set @Str=@Str+'If M_'+@IdCol+' > 0 Then'+Char(13)
	Set @Str=@Str+'MessageBox.Show("Data Saved... ID : " & M_' + @IdCol + ', "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)'+Char(13)
	Set @Str=@Str+'Call Clear_Controls()' + Char(13) + 'Call Fill_Details()'+Char(13)
	Set @Str=@Str+'M_'+@ClassName+'BL = Nothing'+Char(13)
    Set @Str=@Str+'Txt_' + @IdCol +'.Focus()'+Char(13)
	Set @Str=@Str+'End If'+Char(13)
	Set @Str=@Str+'M_'+@ClassName+'BL = Nothing'+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)+Char(13)
	Set @Str=@Str+'End Try'+Char(13)+'End Sub'+Char(13)+Char(13)
	
	Print @Str
	Set @Str=''
	
	Set @Str='Private Sub Locate_Data(ByVal '+@VarName+' As FINMaN_BO.'+@ClassName+'BO)' +Char(13)+Char(13)		
	Set @Str=@Str+'If '+@VarName+'.'+@IdCol+' = 0 Then'++Char(13)
	Set @Str=@Str+'M_EntryMode = "NEW"'+Char(13)
	Set @Str=@Str+'Call Clear_Controls()'+Char(13)
	Set @Str=@Str+'Exit Sub'+Char(13)
	Set @Str=@Str+'End If'+Char(13)
	Set @Str=@Str+'With '+@VarName+Char(13)

	Print @Str
	Set @Str=@Str + 'M_'+@IdCol+' = .' + @IdCol+Char(13)+Char(13)
	select 'M_' + replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_')+ '=.'+  
		replace(replace(replace(dbo.syscolumns.name,'_',''),' ','_'),'/','_') 
	FROM         dbo.sysobjects INNER JOIN
						  dbo.syscolumns ON dbo.sysobjects.id = dbo.syscolumns.id INNER JOIN
						  dbo.systypes ON dbo.syscolumns.xtype = dbo.systypes.xtype
	WHERE     (dbo.sysobjects.name =  @TabName )  ORDER BY dbo.syscolumns.id
	
	Set @Str=@Str+'End With'+Char(13)
	Set @Str=@Str+'M_EntryMode = "VIEW"'+Char(13)
	Set @Str=@Str+'End Sub'+Char(13)+Char(13)

	Print @Str
	Set @Str=''
	
	Set @Str='Private Sub Txt_' + @IdCol +'_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Txt_' + @IdCol +'.Validating'+Char(13)
	Set @Str=@Str+'If Txt_' + @IdCol +'.Text.Length = 0 Then'+Char(13)
	Set @Str=@Str+'Call Clear_Controls()'+Char(13)
	Set @Str=@Str+'M_EntryMode = "NEW"'+Char(13)
	Set @Str=@Str+'Else'+Char(13)
	Set @Str=@Str+'Try'+Char(13)
	Set @Str=@Str+'Dim '+@VarName+' As New FINMaN_BO.'+@ClassName+'BO'+Char(13)
	Set @Str=@Str+'Dim M_'+@ClassName+'BL As New '+@ClassName+'BL'+Char(13)
	Set @Str=@Str+@VarName+' = M_'+@ClassName+'BL.Locate_Data(Txt_' + @IdCol +'.Text)'+Char(13)
	Set @Str=@Str+'Call Locate_Data('+@VarName+')'+Char(13)
	Set @Str=@Str+'M_'+@ClassName+'BL = Nothing'+Char(13)
	Set @Str=@Str+'Catch ex As Exception'+Char(13)+Char(13)
	Set @Str=@Str+'End Try'+Char(13)
	Set @Str=@Str+'End If'+Char(13)
	Set @Str=@Str+'End Sub'+Char(13)

	Print @Str
	Set @Str=''
	
	Set @Str='End Class '
	print @Str		
End















