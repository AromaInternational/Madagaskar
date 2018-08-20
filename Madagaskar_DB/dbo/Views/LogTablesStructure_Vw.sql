
CREATE VIEW [dbo].[LogTablesStructure_Vw]
AS
SELECT ST.name AS TableName, CAST(SC.column_id AS Int) AS ColID, CAST(SC.name AS Varchar(100)) AS ColName, CAST(SST.name AS Varchar(100)) AS ColType, CAST(SP.value AS Varchar(100)) 
                         AS ColDescription
FROM            sys.tables AS ST INNER JOIN
                         sys.columns AS SC ON ST.object_id = SC.object_id INNER JOIN
                         sys.extended_properties AS SP ON ST.object_id = SP.major_id AND SC.column_id = SP.minor_id AND SP.name = 'MS_Description' INNER JOIN
                         sys.systypes AS SST ON SC.system_type_id = SST.xtype


