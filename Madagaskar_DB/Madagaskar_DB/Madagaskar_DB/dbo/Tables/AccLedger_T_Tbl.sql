CREATE TABLE [dbo].[AccLedger_T_Tbl] (
    [Acc_Id]       BIGINT          CONSTRAINT [DF_AccLedger_T_Tbl_Acc_Id] DEFAULT ((0)) NOT NULL,
    [Acc_SlNo]     INT             CONSTRAINT [DF_AccLedger_T_Tbl_Acc_SlNo] DEFAULT ((0)) NOT NULL,
    [Acc_Code]     INT             CONSTRAINT [DF_AccLedger_T_Tbl_Acc_Code] DEFAULT ((0)) NOT NULL,
    [Acc_TranType] INT             CONSTRAINT [DF_AccLedger_T_Tbl_Acc_TranType] DEFAULT ((1)) NOT NULL,
    [Acc_Amt]      NUMERIC (18, 2) CONSTRAINT [DF_AccLedger_T_Tbl_Acc_Amt] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_AccLedger_T_Tbl] PRIMARY KEY CLUSTERED ([Acc_Id] ASC, [Acc_SlNo] ASC, [Acc_Code] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1 for Credit , 2 for Debit', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccLedger_T_Tbl', @level2type = N'COLUMN', @level2name = N'Acc_TranType';

