CREATE TABLE [dbo].[ParaCode_P_Tbl] (
    [PC_ID]          INT           CONSTRAINT [DF_ParaCode_P_Tbl_PC_ID] DEFAULT ((0)) NOT NULL,
    [PC_Description] VARCHAR (100) CONSTRAINT [DF_ParaCode_P_Tbl_PC_Description] DEFAULT ('') NOT NULL,
    [PC_Type]        INT           CONSTRAINT [DF_ParaCode_P_Tbl_PC_Type] DEFAULT ((0)) NOT NULL,
    [PC_Order]       INT           CONSTRAINT [DF_ParaCode_P_Tbl_PC_Order] DEFAULT ((1)) NOT NULL,
    [PC_Locked]      CHAR (1)      CONSTRAINT [DF_ParaCode_P_Tbl_PC_Locked] DEFAULT ('N') NOT NULL,
    [Active_Status]  CHAR (1)      CONSTRAINT [DF_ParaCode_P_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]       INT           CONSTRAINT [DF_ParaCode_P_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]    DATETIME      CONSTRAINT [DF_ParaCode_P_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_Id]     INT           CONSTRAINT [DF_ParaCode_P_Tbl_Updater_Id] DEFAULT ((0)) NOT NULL,
    [Updating_Time]  DATETIME      CONSTRAINT [DF_ParaCode_P_Tbl_Updating_Time] DEFAULT ('01/01/1900') NOT NULL,
    [NEW_ID]         INT           CONSTRAINT [DF_ParaCode_P_Tbl_NEW_ID] DEFAULT ((0)) NOT NULL,
    [OLD_ID]         INT           CONSTRAINT [DF_ParaCode_P_Tbl_OLD_ID] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ParaCode_P_Tbl] PRIMARY KEY CLUSTERED ([PC_ID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'DECRIPTION', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParaCode_P_Tbl', @level2type = N'COLUMN', @level2name = N'PC_Description';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'TYPE', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParaCode_P_Tbl', @level2type = N'COLUMN', @level2name = N'PC_Type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ORDER', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParaCode_P_Tbl', @level2type = N'COLUMN', @level2name = N'PC_Order';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'LOCKED', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParaCode_P_Tbl', @level2type = N'COLUMN', @level2name = N'PC_Locked';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'STATUS', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ParaCode_P_Tbl', @level2type = N'COLUMN', @level2name = N'Active_Status';

