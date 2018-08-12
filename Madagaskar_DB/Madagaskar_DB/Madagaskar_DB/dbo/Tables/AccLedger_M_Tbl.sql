CREATE TABLE [dbo].[AccLedger_M_Tbl] (
    [Acc_Id]        BIGINT        CONSTRAINT [DF_AccLedger_M_Tbl_Acc_Id] DEFAULT ((0)) NOT NULL,
    [Acc_UNID]      INT           CONSTRAINT [DF_AccLedger_M_Tbl_Acc_UNID] DEFAULT ((0)) NOT NULL,
    [Acc_VrTyp]     VARCHAR (10)  CONSTRAINT [DF_AccLedger_M_Tbl_Acc_VrTyp] DEFAULT ('') NOT NULL,
    [Acc_VrNo]      INT           CONSTRAINT [DF_AccLedger_M_Tbl_Acc_VrNo] DEFAULT ((0)) NOT NULL,
    [Acc_FinYear]   VARCHAR (5)   CONSTRAINT [DF_Table_1_Fin_Year] DEFAULT ('00-00') NOT NULL,
    [Acc_Type]      CHAR (1)      CONSTRAINT [DF_AccLedger_M_Tbl_Acc_Type] DEFAULT ('T') NOT NULL,
    [Acc_TrDate]    DATETIME      CONSTRAINT [DF_AccLedger_M_Tbl_Acc_TrDate] DEFAULT ('01/01/1900') NOT NULL,
    [Acc_ChqNo]     VARCHAR (100) CONSTRAINT [DF_AccLedger_M_Tbl_Acc_ChqNo] DEFAULT ('') NOT NULL,
    [Acc_OrgFrom]   VARCHAR (10)  CONSTRAINT [DF_AccLedger_M_Tbl_Acc_OrgFrom] DEFAULT ('VOUCHER') NOT NULL,
    [Acc_Narration] VARCHAR (250) CONSTRAINT [DF_AccLedger_M_Tbl_Acc_Narration] DEFAULT ('') NOT NULL,
    [Acc_ChqDate]   DATETIME      CONSTRAINT [DF_AccLedger_M_Tbl_Acc_ChqDate] DEFAULT ('01/01/1900') NOT NULL,
    [Active_Status] CHAR (1)      CONSTRAINT [DF_AccLedger_M_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]      INT           CONSTRAINT [DF_AccLedger_M_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]   DATETIME      CONSTRAINT [DF_AccLedger_M_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]    INT           CONSTRAINT [DF_AccLedger_M_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time] DATETIME      CONSTRAINT [DF_AccLedger_M_Tbl_Updating_Time] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_AccLedger_M_Tbl] PRIMARY KEY CLUSTERED ([Acc_Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'O for opening and T For transaction', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccLedger_M_Tbl', @level2type = N'COLUMN', @level2name = N'Acc_Type';

