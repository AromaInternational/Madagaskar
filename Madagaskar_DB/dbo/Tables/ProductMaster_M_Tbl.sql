CREATE TABLE [dbo].[ProductMaster_M_Tbl] (
    [ProductID]                INT             NOT NULL,
    [ProductName]              VARCHAR (200)   NOT NULL,
    [Account_Code]             INT             NOT NULL,
    [ProductCategory]          VARCHAR (50)    NOT NULL,
    [Measurement1_Value]       DECIMAL (18, 2) NOT NULL,
    [Measurement1_Text]        VARCHAR (50)    NOT NULL,
    [Measurement2_Value]       DECIMAL (18, 2) NOT NULL,
    [Measurement2_Text]        VARCHAR (50)    NOT NULL,
    [Measurement3_Value]       DECIMAL (18, 2) NOT NULL,
    [Measurement3_Text]        VARCHAR (50)    NOT NULL,
    [MeasurementFinal_Formula] VARCHAR (200)   NOT NULL,
    [MeasurementFinal_Text]    VARCHAR (50)    NOT NULL,
    [Updater_Id]               INT             NULL,
    [Maker_ID]                 INT             NULL,
    [Making_Time]              DATETIME        NULL,
    [Updating_Time]            DATETIME        NULL,
    CONSTRAINT [PK__ProductM__B40CC6ED2E951378] PRIMARY KEY CLUSTERED ([ProductID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'S: sale, P: Purchase, C: Poduction , seperated by |', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ProductMaster_M_Tbl', @level2type = N'COLUMN', @level2name = N'ProductCategory';

