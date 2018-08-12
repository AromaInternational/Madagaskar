CREATE TABLE [dbo].[AccOpBal_M_Tbl] (
    [Acc_OpId]      INT             CONSTRAINT [DF_AccOpBal_M_Tbl_Acc_OpId] DEFAULT ((0)) NOT NULL,
    [Acc_UNID]      INT             CONSTRAINT [DF_AccOpBal_M_Tbl_Acc_UNID] DEFAULT ((0)) NOT NULL,
    [Acc_Code]      INT             CONSTRAINT [DF_AccOpBal_M_Tbl_Acc_Code] DEFAULT ((0)) NOT NULL,
    [Acc_OpMode]    CHAR (1)        CONSTRAINT [DF_AccOpBal_M_Tbl_Acc_OpMode] DEFAULT ('T') NOT NULL,
    [Acc_OpDate]    DATETIME        CONSTRAINT [DF_AccOpBal_M_Tbl_Acc_OpDate] DEFAULT ('01/01/1900') NOT NULL,
    [Acc_Balance]   NUMERIC (18, 2) CONSTRAINT [DF_AccOpBal_M_Tbl_Acc_Balance] DEFAULT ((0)) NOT NULL,
    [Acc_BalType]   INT             CONSTRAINT [DF_AccOpBal_M_Tbl_Acc_BalType] DEFAULT ((1)) NOT NULL,
    [Active_Status] CHAR (1)        CONSTRAINT [DF_AccOpBal_M_Tbl_Active_Status] DEFAULT ('Y') NOT NULL,
    [Maker_ID]      INT             CONSTRAINT [DF_AccOpBal_M_Tbl_Maker_ID] DEFAULT ((0)) NOT NULL,
    [Making_Time]   DATETIME        CONSTRAINT [DF_AccOpBal_M_Tbl_Making_Time] DEFAULT ('01/01/1900') NOT NULL,
    [Updater_ID]    INT             CONSTRAINT [DF_AccOpBal_M_Tbl_Updater_ID] DEFAULT ((0)) NOT NULL,
    [Updating_Time] DATETIME        CONSTRAINT [DF_AccOpBal_M_Tbl_Updating_Time] DEFAULT ('01/01/1900') NOT NULL,
    CONSTRAINT [PK_AccOpBal_M_Tbl] PRIMARY KEY CLUSTERED ([Acc_OpId] ASC)
);

