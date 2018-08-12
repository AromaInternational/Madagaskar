CREATE TABLE [dbo].[ParaType_P_Tbl] (
    [PT_ID]          INT          CONSTRAINT [DF_ParaType_P_Tbl_PT_ID] DEFAULT ((0)) NOT NULL,
    [PT_Description] VARCHAR (25) CONSTRAINT [DF_ParaType_P_Tbl_PT_Description] DEFAULT (' ') NOT NULL,
    [PT_ParentId]    INT          CONSTRAINT [DF_ParaType_P_Tbl_PT_ParentId] DEFAULT ((0)) NOT NULL,
    [PT_Locked]      CHAR (1)     CONSTRAINT [DF_ParaType_P_Tbl_PT_Locked] DEFAULT ('N') NOT NULL,
    [Active_Status]  CHAR (1)     CONSTRAINT [DF_ParaType_P_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    CONSTRAINT [PK_ParaType_P_Tbl] PRIMARY KEY CLUSTERED ([PT_ID] ASC)
);

