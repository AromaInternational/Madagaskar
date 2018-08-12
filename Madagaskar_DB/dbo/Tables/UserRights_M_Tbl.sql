CREATE TABLE [dbo].[UserRights_M_Tbl] (
    [UR_MMID]       INT      CONSTRAINT [DF_UserRights_M_Tbl_UR_MMID] DEFAULT ((0)) NOT NULL,
    [UR_UMID]       INT      CONSTRAINT [DF_UserRights_M_Tbl_UR_UMID] DEFAULT ((0)) NOT NULL,
    [UR_View]       CHAR (1) CONSTRAINT [DF_UserRights_M_Tbl_UR_View] DEFAULT ('N') NOT NULL,
    [UR_Add]        CHAR (1) CONSTRAINT [DF_UserRights_M_Tbl_UR_Add] DEFAULT ('N') NOT NULL,
    [UR_Edit]       CHAR (1) CONSTRAINT [DF_UserRights_M_Tbl_UR_Edit] DEFAULT ('N') NOT NULL,
    [UR_Delete]     CHAR (1) CONSTRAINT [DF_UserRights_M_Tbl_UR_Delete] DEFAULT ('N') NOT NULL,
    [UR_Print]      CHAR (1) CONSTRAINT [DF_UserRights_M_Tbl_UR_Print] DEFAULT ('N') NOT NULL,
    [UR_Authn]      CHAR (1) CONSTRAINT [DF_UserRights_M_Tbl_UR_Authn] DEFAULT ('N') NOT NULL,
    [Maker_ID]      INT      CONSTRAINT [DF_UserRights_M_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]   DATETIME CONSTRAINT [DF_UserRights_M_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]    INT      CONSTRAINT [DF_UserRights_M_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time] DATETIME CONSTRAINT [DF_UserRights_M_Tbl_Updating_Time] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_UserRights_M_Tbl] PRIMARY KEY CLUSTERED ([UR_MMID] ASC, [UR_UMID] ASC)
);

