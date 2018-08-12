CREATE TABLE [dbo].[ReportNames_P_Tbl] (
    [RN_Id]          INT           CONSTRAINT [DF_ReportNames_P_Tbl_RN_Id] DEFAULT ((0)) NOT NULL,
    [RN_Description] VARCHAR (100) CONSTRAINT [DF_ReportNames_P_Tbl_RN_Description] DEFAULT ('') NOT NULL,
    [RN_Name]        VARCHAR (100) CONSTRAINT [DF_ReportNames_P_Tbl_RN_Name] DEFAULT ('') NOT NULL,
    [RN_Type]        INT           CONSTRAINT [DF_ReportNames_P_Tbl_RN_Type] DEFAULT ((0)) NOT NULL,
    [RN_Order]       INT           CONSTRAINT [DF_ReportNames_P_Tbl_RN_Order] DEFAULT ((1)) NOT NULL,
    [Active_Status]  CHAR (1)      CONSTRAINT [DF_ReportNames_P_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    CONSTRAINT [PK_ReportNames_P_Tbl] PRIMARY KEY CLUSTERED ([RN_Id] ASC)
);

