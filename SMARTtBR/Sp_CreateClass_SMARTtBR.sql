USE FIN_MaN

--Exec GenerateInsUpdateScript_Sp 'UnitMaster_P_Tbl','UN_ID'

--Exec Sp_CreateClass 'UnitMaster_P_Tbl' ,'UN_ID','M_UnitMaster', 'UnitMaster','DA'






Exec GenerateInsUpdateScript_Sp 'ProductMaster_Tbl','ProductID'
Exec GenerateInsUpdateScript_Sp 'M', 'ProductMaster_Tbl','ProductID'--,'UserRights','UserRights_M_Tbl'


Name	Schema	Create Date	Policy Health State	Row Count
ProductMaster_Tbl	dbo	13-08-2018 08:40		2
