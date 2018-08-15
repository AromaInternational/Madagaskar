CREATE TABLE [dbo].[ProductMaster_Tbl]
(
	[ProductID] INT NOT NULL PRIMARY KEY, 
    [ProductName] VARCHAR(200) NOT NULL, 
    [Account_Code] INT NOT NULL, 
    [ProductCategory] VARCHAR(50) NOT NULL, 
    [Measurement1_Value] DECIMAL(18, 2) NOT NULL, 
    [Measurement1_Text] VARCHAR(50) NOT NULL, 
    [Measurement2_Value] DECIMAL(18, 2) NOT NULL, 
    [Measurement2_Text] VARCHAR(50) NOT NULL, 
    [Measurement3_Value] DECIMAL(18, 2) NOT NULL, 
    [Measurement3_Text] VARCHAR(50) NOT NULL, 
    [MeasurementFinal_Formula] VARCHAR(200) NOT NULL, 
    [MeasurementFinal_Text] VARCHAR(50) NOT NULL
)

GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'S: sale, P: Purchase, C: Poduction , seperated by |',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ProductMaster_Tbl',
    @level2type = N'COLUMN',
    @level2name = N'ProductCategory'