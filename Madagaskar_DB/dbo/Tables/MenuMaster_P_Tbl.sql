CREATE TABLE [dbo].[MenuMaster_P_Tbl] (
    [MM_ID]                    INT           NOT NULL,
    [MM_MainID]                INT           CONSTRAINT [DF_MenuMaster_P_Tbl_MM_Code] DEFAULT ((0)) NOT NULL,
    [MM_SubID]                 INT           CONSTRAINT [DF_MenuMaster_P_Tbl_MM_SubID] DEFAULT ((0)) NOT NULL,
    [MM_SubChildID]            INT           CONSTRAINT [DF_MenuMaster_P_Tbl_MM_SubChildID] DEFAULT ((0)) NOT NULL,
    [MM_Name]                  VARCHAR (100) CONSTRAINT [DF_MenuMaster_P_Tbl_MM_Name] DEFAULT ('') NOT NULL,
    [MM_Caption]               VARCHAR (100) CONSTRAINT [DF_MenuMaster_P_Tbl_MM_Caption] DEFAULT ('') NOT NULL,
    [MM_FormName]              VARCHAR (100) CONSTRAINT [DF_MenuMaster_P_Tbl_MM_FormName] DEFAULT ('') NOT NULL,
    [MM_AllowMultipleInstance] CHAR (1)      CONSTRAINT [DF_MenuMaster_P_Tbl_MM_AllowMultipleInstance] DEFAULT ('Y') NOT NULL,
    [MM_Active]                CHAR (1)      CONSTRAINT [DF_MenuMaster_P_Tbl_MM_Active] DEFAULT ('Y') NOT NULL,
    [MM_ShortKey]              VARCHAR (10)  CONSTRAINT [DF_MenuMaster_P_Tbl_MM_ShortKey] DEFAULT ('') NOT NULL,
    [MM_ShowInMenu]            CHAR (1)      CONSTRAINT [DF_MenuMaster_P_Tbl_MM_ShowInMenu] DEFAULT ('Y') NOT NULL,
    CONSTRAINT [PK_MenuMaster_P_Tbl] PRIMARY KEY CLUSTERED ([MM_ID] ASC)
);

