CREATE TABLE [dbo].[UserPwdChange_M_Tbl] (
    [UP_ID]       BIGINT         CONSTRAINT [DF_UserPwdChange_M_Tbl_UP_ID] DEFAULT ((0)) NOT NULL,
    [UP_UMID]     INT            CONSTRAINT [DF_UserPwdChange_M_Tbl_UP_UMID] DEFAULT ((0)) NOT NULL,
    [UP_CurrPwd]  VARBINARY (50) NOT NULL,
    [UP_NewPwd]   VARBINARY (50) NOT NULL,
    [Maker_ID]    INT            CONSTRAINT [DF_UserPwdChange_M_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time] DATETIME       CONSTRAINT [DF_UserPwdChange_M_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_UserPwdChange_M_Tbl] PRIMARY KEY CLUSTERED ([UP_ID] ASC)
);

