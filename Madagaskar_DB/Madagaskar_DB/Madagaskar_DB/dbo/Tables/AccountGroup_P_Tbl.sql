CREATE TABLE [dbo].[AccountGroup_P_Tbl] (
    [GP_ID]         INT           CONSTRAINT [DF_AccountGroup_P_Tbl_GP_ID] DEFAULT ((0)) NOT NULL,
    [GP_Name]       VARCHAR (100) CONSTRAINT [DF_AccountGroup_P_Tbl_GP_Name] DEFAULT ('') NOT NULL,
    [GP_SeqNo]      INT           CONSTRAINT [DF_AccountGroup_P_Tbl_GP_SeqNo] DEFAULT ((0)) NOT NULL,
    [GP_ParentId]   INT           CONSTRAINT [DF_AccountGroup_P_Tbl_GP_ParentId] DEFAULT ((0)) NOT NULL,
    [Active_Status] CHAR (1)      CONSTRAINT [DF_AccountGroup_P_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]      INT           CONSTRAINT [DF_AccountGroup_P_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]   DATETIME      CONSTRAINT [DF_AccountGroup_P_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]    INT           CONSTRAINT [DF_AccountGroup_P_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time] DATETIME      CONSTRAINT [DF_AccountGroup_P_Tbl_Updating_Time] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_AccountGroup_P_Tbl] PRIMARY KEY CLUSTERED ([GP_ID] ASC)
);

