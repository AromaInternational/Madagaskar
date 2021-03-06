﻿CREATE TABLE [dbo].[ClientMaster_M_Tbl] (
    [Br_Code]              INT           NOT NULL,
    [CM_ID]                BIGINT        NOT NULL,
    [CM_TypeID]            INT           NOT NULL,
    [CM_RefferType]        INT           NOT NULL,
    [CM_Name]              VARCHAR (50)  NOT NULL,
    [CM_FormalName]        VARCHAR (50)  NOT NULL,
    [CM_TitleID]           INT           NOT NULL,
    [CM_ReferID]           BIGINT        NOT NULL,
    [CM_PrAdrs1]           VARCHAR (50)  NOT NULL,
    [CM_PrAdrs2]           VARCHAR (50)  NOT NULL,
    [CM_PrAdrs3]           VARCHAR (50)  NOT NULL,
    [CM_PrCity]            VARCHAR (50)  NOT NULL,
    [CM_PrPin]             VARCHAR (7)   NOT NULL,
    [CM_PrState]           VARCHAR (100) NOT NULL,
    [CM_PrStateCode]       VARCHAR (25)  NOT NULL,
    [CM_PmAdrs1]           VARCHAR (50)  NOT NULL,
    [CM_PmAdrs2]           VARCHAR (50)  NOT NULL,
    [CM_PmAdrs3]           VARCHAR (50)  NOT NULL,
    [CM_PmCity]            VARCHAR (50)  NOT NULL,
    [CM_PmPin]             VARCHAR (7)   NOT NULL,
    [CM_PmState]           VARCHAR (100) NOT NULL,
    [CM_PmStateCode]       VARCHAR (25)  NOT NULL,
    [CM_EMail]             VARCHAR (50)  NOT NULL,
    [CM_PANNO]             VARCHAR (15)  NOT NULL,
    [CM_KSTNO]             VARCHAR (15)  NOT NULL,
    [CM_CSTNO]             VARCHAR (15)  NOT NULL,
    [CM_TIN]               VARCHAR (15)  NOT NULL,
    [CM_Occupation]        INT           NOT NULL,
    [CM_Class]             INT           NOT NULL,
    [CM_CreditPeriod]      INT           NOT NULL,
    [CM_Narration]         VARCHAR (500) NOT NULL,
    [CM_LandMark]          VARCHAR (500) NOT NULL,
    [CM_PhoneNo]           VARCHAR (40)  NOT NULL,
    [CM_PhoneResidency]    VARCHAR (40)  NOT NULL,
    [CM_DiscTypeID]        INT           NOT NULL,
    [CM_LocationID]        INT           NOT NULL,
    [CM_DOB]               DATETIME      NOT NULL,
    [CM_MemberWithAbove65] INT           NOT NULL,
    [CM_MemberWithBelow10] INT           NOT NULL,
    [CM_TotalNoOfMembers]  INT           NOT NULL,
    [CM_AccCode]           INT           NOT NULL,
    [CM_CreditEnabled]     CHAR (1)      NOT NULL,
    [CM_GSTIN]             VARCHAR (15)  NOT NULL,
    [Active_Status]        CHAR (1)      NOT NULL,
    [Maker_ID]             INT           NOT NULL,
    [Making_Time]          DATETIME      NOT NULL,
    [Updater_ID]           INT           NOT NULL,
    [Updating_Time]        DATETIME      NOT NULL
);

