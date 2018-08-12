CREATE TABLE [dbo].[UserUnitDetails_T_Tbl] (
    [UM_ID]       INT         CONSTRAINT [DF_UserUnitDetails_T_Tbl_UM_ID] DEFAULT ((0)) NOT NULL,
    [UN_TreeCode] VARCHAR (8) CONSTRAINT [DF_UserUnitDetails_T_Tbl_UN_TreeCode] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserUnitDetails_T_Tbl] PRIMARY KEY CLUSTERED ([UM_ID] ASC, [UN_TreeCode] ASC)
);

