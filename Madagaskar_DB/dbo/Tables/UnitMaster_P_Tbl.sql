CREATE TABLE [dbo].[UnitMaster_P_Tbl] (
    [UN_ID]         INT          CONSTRAINT [DF_UnitMaster_P_Tbl_UN_ID] DEFAULT ((0)) NOT NULL,
    [UN_Name]       VARCHAR (50) CONSTRAINT [DF_UnitMaster_P_Tbl_UN_Name] DEFAULT ('') NOT NULL,
    [UN_CmpCode]    INT          CONSTRAINT [DF_UnitMaster_P_Tbl_UN_CmpCode] DEFAULT ((0)) NOT NULL,
    [Active_Status] CHAR (1)     CONSTRAINT [DF_UnitMaster_P_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]      INT          CONSTRAINT [DF_UnitMaster_P_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]   DATETIME     CONSTRAINT [DF_UnitMaster_P_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]    INT          CONSTRAINT [DF_UnitMaster_P_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time] DATETIME     CONSTRAINT [DF_UnitMaster_P_Tbl_Updating] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_UnitMaster_P_Tbl_1] PRIMARY KEY CLUSTERED ([UN_ID] ASC)
);

