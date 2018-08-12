
CREATE VIEW [dbo].[LogDetails_Vw]
AS
SELECT        LM.LM_ID ID, LM.LM_MMID SourceID,MM.MM_Caption [Source Name] ,LM.LM_MID MasterID, LD.LD_FILELD [Data Field],LD.LD_FILELDNAME [Field Name], LD.LD_OLDVALUE [Old Value], LD.LD_NEWVALUE [New Value], IsNull(LM.Maker_ID,1) [Modifier ID], IsNull(UM.UM_Name,'ADMIN') [Modified By], LM.Making_Time [Modified Time]
FROM            dbo.LogMaster_M_Tbl AS LM JOIN 
						 dbo.MenuMaster_P_Tbl AS MM ON MM.MM_ID = LM.LM_MMID JOIN
                         dbo.LogDetails_T_Tbl AS LD ON LM.LM_ID = LD.LD_LMID LEFT JOIN
                         dbo.UserMaster_M_Tbl AS UM ON LM.Maker_ID = UM.UM_ID



