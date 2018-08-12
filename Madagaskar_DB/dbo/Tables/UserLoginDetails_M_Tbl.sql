CREATE TABLE [dbo].[UserLoginDetails_M_Tbl] (
    [UL_ID]       BIGINT        CONSTRAINT [DF_LogTeminal_M_Tbl_UL_ID] DEFAULT ((0)) NOT NULL,
    [UL_UMID]     INT           CONSTRAINT [DF_UserLoginDetails_M_Tbl_UL_UMID] DEFAULT ((0)) NOT NULL,
    [UL_Terminal] VARCHAR (250) CONSTRAINT [DF_UserLoginDetails_M_Tbl_UL_Terminal] DEFAULT ('') NOT NULL,
    [UL_InDate]   DATETIME      CONSTRAINT [DF_UserLoginDetails_M_Tbl_UL_InDate] DEFAULT ('01/01/1900') NOT NULL,
    [UL_OutDate]  DATETIME      CONSTRAINT [DF_UserLoginDetails_M_Tbl_UL_OutDate] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_LogTeminal_M_Tbl] PRIMARY KEY CLUSTERED ([UL_ID] ASC)
);

