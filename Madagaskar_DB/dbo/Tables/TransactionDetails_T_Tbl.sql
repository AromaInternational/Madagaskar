CREATE TABLE [dbo].[TransactionDetails_T_Tbl] (
    [TranID]                 INT             NOT NULL,
    [ProductID]              INT             NOT NULL,
    [TranSeqNo]              INT             NOT NULL,
    [Measurement1_Value]     DECIMAL (18, 2) NOT NULL,
    [Measurement2_Value]     DECIMAL (18, 2) NOT NULL,
    [Measurement3_Value]     DECIMAL (18, 2) NOT NULL,
    [MeasurementFinal_Value] DECIMAL (18, 2) NOT NULL,
    [Quantity]               DECIMAL (18, 2) NOT NULL,
    [Rate]                   DECIMAL (18, 2) NOT NULL,
    [Price]                  DECIMAL (18, 2) NOT NULL,
    [DiscountType]           CHAR (1)        NOT NULL,
    [DiscountPercent]        DECIMAL (3, 2)  NOT NULL,
    [DiscountAmount]         DECIMAL (18, 2) NOT NULL,
    [Description]            VARCHAR (300)   NULL,
    CONSTRAINT [PK_TransactionDetails_T_Tbl] PRIMARY KEY CLUSTERED ([TranID] ASC, [ProductID] ASC, [TranSeqNo] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'P: Percent, A: Amount', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TransactionDetails_T_Tbl', @level2type = N'COLUMN', @level2name = N'DiscountType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Order or entry', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TransactionDetails_T_Tbl', @level2type = N'COLUMN', @level2name = N'TranSeqNo';

