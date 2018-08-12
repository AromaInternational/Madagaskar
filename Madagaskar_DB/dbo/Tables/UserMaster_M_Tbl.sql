CREATE TABLE [dbo].[UserMaster_M_Tbl] (
    [UM_ID]               INT            CONSTRAINT [DF_UserMaster_M_Tbl_UM_ID] DEFAULT ((0)) NOT NULL,
    [UM_DepID]            INT            CONSTRAINT [DF_UserMaster_M_Tbl_UM_DepID] DEFAULT ((0)) NOT NULL,
    [UM_DesID]            INT            CONSTRAINT [DF_UserMaster_M_Tbl_UM_DesID] DEFAULT ((0)) NOT NULL,
    [UM_TypeID]           INT            CONSTRAINT [DF_UserMaster_M_Tbl_UM_TypeID] DEFAULT ((0)) NOT NULL,
    [UM_Name]             VARCHAR (50)   CONSTRAINT [DF_UserMaster_M_Tbl_UM_Name] DEFAULT ('') NOT NULL,
    [UM_Pwd]              VARBINARY (50) NOT NULL,
    [UM_UNID]             INT            CONSTRAINT [DF_UserMaster_M_Tbl_UM_UNID] DEFAULT ((0)) NOT NULL,
    [Active_Status]       CHAR (1)       CONSTRAINT [DF_UserMaster_M_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]            INT            CONSTRAINT [DF_UserMaster_M_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]         DATETIME       CONSTRAINT [DF_UserMaster_M_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]          INT            CONSTRAINT [DF_UserMaster_M_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time]       DATETIME       CONSTRAINT [DF_UserMaster_M_Tbl_Updating_Time] DEFAULT ('01/01/1900') NOT NULL,
    [UM_AutoLogOutPeriod] INT            CONSTRAINT [DF_UserMaster_M_Tbl_UM_AutoLogOutPeriod] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserMaster_M_Tbl] PRIMARY KEY CLUSTERED ([UM_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'DEPARTMENT', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserMaster_M_Tbl', @level2type = N'COLUMN', @level2name = N'UM_DepID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'DESIGNATION', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserMaster_M_Tbl', @level2type = N'COLUMN', @level2name = N'UM_DesID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TYPE', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserMaster_M_Tbl', @level2type = N'COLUMN', @level2name = N'UM_TypeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'NAME', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserMaster_M_Tbl', @level2type = N'COLUMN', @level2name = N'UM_Name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'UNIT', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserMaster_M_Tbl', @level2type = N'COLUMN', @level2name = N'UM_UNID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'STATUS', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'UserMaster_M_Tbl', @level2type = N'COLUMN', @level2name = N'Active_Status';

