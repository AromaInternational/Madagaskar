CREATE TABLE [dbo].[AccountMaster_P_Tbl] (
    [Acc_Code]          INT           CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_Code] DEFAULT ((0)) NOT NULL,
    [Acc_Name]          VARCHAR (100) CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_Name] DEFAULT ('') NOT NULL,
    [Acc_CmpCode]       INT           CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_CmpCode] DEFAULT ((0)) NOT NULL,
    [Acc_GPID]          INT           CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_GPID] DEFAULT ((0)) NOT NULL,
    [Acc_SeqNo]         INT           CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_SeqNo] DEFAULT ((0)) NOT NULL,
    [Acc_BalType]       CHAR (1)      CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_BalType] DEFAULT ('D') NOT NULL,
    [Acc_ALIE]          CHAR (1)      CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_ALIE] DEFAULT ('A') NOT NULL,
    [Acc_Position]      VARCHAR (2)   CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_Position] DEFAULT ('B') NOT NULL,
    [Acc_Statementtype] CHAR (1)      CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_Statementtype] DEFAULT ('D') NOT NULL,
    [Acc_BillBreakup]   CHAR (1)      CONSTRAINT [DF_AccountMaster_P_Tbl_Acc_BillBreakup] DEFAULT ('N') NOT NULL,
    [Active_Status]     CHAR (1)      CONSTRAINT [DF_AccountMaster_P_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]          INT           CONSTRAINT [DF_AccountMaster_P_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]       DATETIME      CONSTRAINT [DF_AccountMaster_P_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]        INT           CONSTRAINT [DF_AccountMaster_P_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time]     DATETIME      CONSTRAINT [DF_AccountMaster_P_Tbl_Updating_Time] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_AccountMaster_P_Tbl] PRIMARY KEY CLUSTERED ([Acc_Code] ASC)
);

