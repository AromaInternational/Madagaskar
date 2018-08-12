CREATE TABLE [dbo].[LogMaster_M_Tbl] (
    [LM_ID]       BIGINT   CONSTRAINT [DF_LogMaster_M_Tbl_LM_ID] DEFAULT ((0)) NOT NULL,
    [LM_MMID]     INT      CONSTRAINT [DF_LogMaster_M_Tbl_LM_MMID] DEFAULT ((0)) NOT NULL,
    [LM_MID]      INT      CONSTRAINT [DF_LogMaster_M_Tbl_LM_MID] DEFAULT ((0)) NOT NULL,
    [Maker_ID]    INT      CONSTRAINT [DF_LogMaster_M_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time] DATETIME CONSTRAINT [DF_LogMaster_M_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_LogMaster_M_Tbl] PRIMARY KEY CLUSTERED ([LM_ID] ASC)
);

