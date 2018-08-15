CREATE TABLE [dbo].[TransactionMaster_T_Tbl] (
    [TranID]          INT             NOT NULL,
    [BillNo]          VARCHAR (30)    NOT NULL,
    [TrDate]          DATE            NOT NULL,
    [ClientID]        INT             NOT NULL,
    [ShipmentAddress] VARCHAR (300)   NOT NULL,
    [BillingAddress]  VARCHAR (300)   NOT NULL,
    [InvoiceDate]     DATE            NOT NULL,
    [InvoiceNumber]   VARCHAR (50)    NOT NULL,
    [RoundOff]        DECIMAL (18, 2) NOT NULL,
    [GrossAmount]     DECIMAL (18, 2) NOT NULL,
    [NetAmount]       DECIMAL (18, 2) NOT NULL,
    [Frieght]         DECIMAL (18, 2) NOT NULL,
    [DiscountOnTotal] DECIMAL (18, 2) NOT NULL,
    [CurrencyEntryID] INT             NOT NULL,
    [Remarks]         VARCHAR (300)   NOT NULL,
    [AutoRoundOff]    CHAR (1)        DEFAULT ('N') NOT NULL,
    [Maker_ID]        INT             NULL,
    [Making_Time]     DATETIME        NULL,
    [Updater_Id]      INT             NULL,
    [Updating_Time]   DATETIME        NULL,
    CONSTRAINT [PK_TransactionMaster_T_Tbl] PRIMARY KEY CLUSTERED ([TranID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'For Currency Conversion', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TransactionMaster_T_Tbl', @level2type = N'COLUMN', @level2name = N'CurrencyEntryID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Purchae - Supplier ID, Sale - Customer ID, Production Both', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'TransactionMaster_T_Tbl', @level2type = N'COLUMN', @level2name = N'ClientID';

