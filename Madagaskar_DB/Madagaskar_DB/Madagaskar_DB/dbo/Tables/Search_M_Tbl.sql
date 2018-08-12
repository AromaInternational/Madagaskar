CREATE TABLE [dbo].[Search_M_Tbl] (
    [S_ID]          INT            CONSTRAINT [DF_Search_M_Tbl_S_ID] DEFAULT ((0)) NOT NULL,
    [S_Discription] VARCHAR (50)   CONSTRAINT [DF_Search_M_Tbl_S_Discription] DEFAULT ('') NOT NULL,
    [S_Qry]         VARCHAR (1000) CONSTRAINT [DF_Search_M_Tbl_S_Qry] DEFAULT ('') NOT NULL,
    [S_Order]       VARCHAR (100)  CONSTRAINT [DF_Search_M_Tbl_S_Order] DEFAULT ('') NOT NULL,
    [S_Heading]     VARCHAR (1000) CONSTRAINT [DF_Search_M_Tbl_S_Heading] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_Search_M_Tbl] PRIMARY KEY CLUSTERED ([S_ID] ASC)
);

