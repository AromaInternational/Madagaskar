CREATE TABLE [dbo].[DailyCurrency_T_Tbl] (
    [EntryID]    INT             NOT NULL,
    [CurrencyID] INT             NOT NULL,
    [Rate]       DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_DailyCurrency_T_Tbl] PRIMARY KEY CLUSTERED ([EntryID] ASC, [CurrencyID] ASC)
);

