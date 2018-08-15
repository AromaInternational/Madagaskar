
CREATE VIEW [dbo].[ClientMaster_Vw]
AS
SELECT      B.Cmp_Code, C.Br_Code, C.CM_TypeID, C.CM_ID, C.CM_Name, C.CM_FormalName, C.CM_TitleID, C.CM_ReferID, C.CM_RefferType, C.CM_PrAdrs1, C.CM_PrAdrs2, C.CM_PrAdrs3, C.CM_PrCity, C.CM_PrPin,C.CM_PrState,C.CM_PrStateCode,
			(CM_PrAdrs1 + Case When Len(CM_PrAdrs1)>0 And Len(CM_PrAdrs2)>0 Then ',' Else '' End + CM_PrAdrs2 + Case When Len(CM_PrAdrs1+CM_PrAdrs2)>0 And Len(CM_PrAdrs3)>0 Then ',' Else '' End + CM_PrAdrs3 + Case When Len(CM_PrAdrs1+CM_PrAdrs2+CM_PrAdrs3)>0 And Len(CM_PrPin)>0 Then ',' Else '' End + Cast(CM_PrPin As Varchar(100))) CM_PresentAddress, 
            C.CM_PmAdrs1, C.CM_PmAdrs2, C.CM_PmAdrs3, C.CM_PmCity,C.CM_PmPin,C.CM_PmState,C.CM_PmStateCode,
			(CM_PmAdrs1 + Case When Len(CM_PmAdrs1)>0 And Len(CM_PmAdrs2)>0 Then ',' Else '' End + CM_PmAdrs2 + Case When Len(CM_PmAdrs1+CM_PmAdrs2)>0 And Len(CM_PmAdrs3)>0 Then ',' Else '' End + CM_PmAdrs3 + Case When Len(CM_PmAdrs1+CM_PmAdrs2+CM_PmAdrs3)>0 And Len(CM_PmPin)>0 Then ',' Else '' End + Cast(CM_PmPin As Varchar(100))) CM_PermanentAddress, 
			C.CM_EMail, C.CM_PANNO, C.CM_KSTNO, C.CM_CSTNO, C.CM_TIN,C.CM_GSTIN, C.CM_Occupation, C.CM_Class, C.CM_CreditPeriod, 
            C.CM_Narration, C.CM_LandMark, C.CM_PhoneNo, C.CM_PhoneResidency, C.CM_DiscTypeID, C.CM_LocationID, C.CM_DOB, C.CM_MemberWithAbove65, C.CM_MemberWithBelow10, C.CM_TotalNoOfMembers, 
            C.CM_AccCode,C.CM_CreditEnabled, C.Maker_ID, C.Active_Status, C.Making_Time, C.Updater_ID, C.Updating_Time
FROM            dbo.ClientMaster_M_Tbl AS C INNER JOIN
                         dbo.BranchDetails_P_Tbl AS B ON C.Br_Code = B.Br_Code