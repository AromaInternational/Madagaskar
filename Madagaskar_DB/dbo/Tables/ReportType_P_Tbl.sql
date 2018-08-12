CREATE TABLE [dbo].[ReportType_P_Tbl] (
    [RT_Code]        INT          CONSTRAINT [DF_ReportType_P_Tbl_RT_Code] DEFAULT ((0)) NOT NULL,
    [RT_Description] VARCHAR (50) CONSTRAINT [DF_ReportType_P_Tbl_RT_Description] DEFAULT ('') NOT NULL,
    [Active_Status]  CHAR (1)     CONSTRAINT [DF_ReportType_P_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    CONSTRAINT [PK_ReportType_P_Tbl] PRIMARY KEY CLUSTERED ([RT_Code] ASC)
);

