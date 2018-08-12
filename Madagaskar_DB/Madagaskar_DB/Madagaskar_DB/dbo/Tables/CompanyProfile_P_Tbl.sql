CREATE TABLE [dbo].[CompanyProfile_P_Tbl] (
    [Cmp_Code]    INT           CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Code] DEFAULT ((0)) NOT NULL,
    [Cmp_Name]    VARCHAR (100) CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Name] DEFAULT ('') NOT NULL,
    [Cmp_Address] VARCHAR (200) CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Address] DEFAULT ('') NOT NULL,
    [Cmp_EstDate] DATETIME      CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_EstDate] DEFAULT ('') NOT NULL,
    [Cmp_RegNo]   VARCHAR (20)  CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_RegNo] DEFAULT ('') NOT NULL,
    [Cmp_Founder] VARCHAR (100) CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Founder] DEFAULT ('') NULL,
    [Cmp_Phone1]  VARCHAR (15)  CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Phone1] DEFAULT ('') NOT NULL,
    [Cmp_Phone2]  VARCHAR (15)  CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Phone2] DEFAULT ('') NULL,
    [Cmp_Phone3]  VARCHAR (15)  CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Phone3] DEFAULT ('') NULL,
    [Cmp_FaxNo]   VARCHAR (15)  CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_FaxNo] DEFAULT ('') NULL,
    [Cmp_Email]   VARCHAR (50)  CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Email] DEFAULT ('') NULL,
    [Cmp_Website] VARCHAR (100) CONSTRAINT [DF_CompanyProfile_P_Tbl_Cmp_Website] DEFAULT ('') NULL,
    CONSTRAINT [PK_CompanyProfile_P_Tbl] PRIMARY KEY CLUSTERED ([Cmp_Code] ASC)
);

