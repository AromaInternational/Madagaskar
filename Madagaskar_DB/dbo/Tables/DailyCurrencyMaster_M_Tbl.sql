CREATE TABLE [dbo].[DailyCurrencyMaster_M_Tbl] (
    [EntryID]       INT NOT NULL,
    [EntryDateTime] AS  (getdate()),
    [MakerID]       INT NOT NULL,
    CONSTRAINT [PK_DailyCurrencyMaster_M_Tbl] PRIMARY KEY CLUSTERED ([EntryID] ASC)
);

