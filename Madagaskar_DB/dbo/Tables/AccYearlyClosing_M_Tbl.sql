CREATE TABLE [dbo].[AccYearlyClosing_M_Tbl] (
    [AY_ID]         BIGINT      CONSTRAINT [DF_AccYearlyClosing_M_Tbl_AY_ID] DEFAULT ((0)) NOT NULL,
    [AY_UNID]       INT         CONSTRAINT [DF_AccYearlyClosing_M_Tbl_AY_UNID] DEFAULT ((0)) NOT NULL,
    [AY_Date]       DATETIME    CONSTRAINT [DF_AccYearlyClosing_M_Tbl_AY_Date] DEFAULT ('01/01/1900') NOT NULL,
    [AY_FinYear]    VARCHAR (5) CONSTRAINT [DF_AccYearlyClosing_M_Tbl_AY_FinYear] DEFAULT ('00-00') NOT NULL,
    [Active_Status] CHAR (1)    CONSTRAINT [DF_AccYearlyClosing_M_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]      INT         CONSTRAINT [DF_AccYearlyClosing_M_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]   DATETIME    CONSTRAINT [DF_AccYearlyClosing_M_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]    INT         CONSTRAINT [DF_AccYearlyClosing_M_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time] DATETIME    CONSTRAINT [DF_AccYearlyClosing_M_Tbl_Updating_Time] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_AccYearlyClosing_M_Tbl] PRIMARY KEY CLUSTERED ([AY_ID] ASC)
);

