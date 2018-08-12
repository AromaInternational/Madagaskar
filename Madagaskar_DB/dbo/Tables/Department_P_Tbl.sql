CREATE TABLE [dbo].[Department_P_Tbl] (
    [Dep_ID]        INT          CONSTRAINT [DF_Department_P_Tbl_Dep_ID] DEFAULT ((0)) NOT NULL,
    [Dep_Name]      VARCHAR (50) CONSTRAINT [DF_Department_P_Tbl_Dep_Name] DEFAULT ('') NOT NULL,
    [Active_Status] CHAR (1)     CONSTRAINT [DF_Department_P_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]      INT          CONSTRAINT [DF_Department_P_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]   DATETIME     CONSTRAINT [DF_Department_P_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]    INT          CONSTRAINT [DF_Department_P_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time] DATETIME     CONSTRAINT [DF_Department_P_Tbl_Updating] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_Department_P_Tbl_1] PRIMARY KEY CLUSTERED ([Dep_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'NAME', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Department_P_Tbl', @level2type = N'COLUMN', @level2name = N'Dep_Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'STATUS', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Department_P_Tbl', @level2type = N'COLUMN', @level2name = N'Active_Status';

