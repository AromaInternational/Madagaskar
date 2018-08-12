


CREATE VIEW [dbo].[AccLedgerMaster_Vw]
AS
SELECT        M.Acc_Id,U.UN_CmpCode AS Cmp_Code, U.Cmp_Name, M.Acc_UNID, U.UN_Name,M.Acc_VrNo, M.Acc_VrTyp, V.VR_TYPE, M.Acc_FinYear, M.Acc_Type, M.Acc_TrDate, M.Acc_ChqNo, M.Acc_OrgFrom, M.Acc_Narration, 
                         M.Acc_ChqDate, M.Active_Status, M.Maker_ID, 
                         M.Making_Time, M.Updater_ID, M.Updating_Time
FROM            dbo.AccLedger_M_Tbl AS M  INNER JOIN
                         dbo.UnitMaster_Vw AS U ON M.Acc_UNID = U.UN_ID CROSS APPLY
						 dbo.Fill_AccVrType_Fn(U.UN_CmpCode,'N','S')As V WHERE V.VR_ID = M.Acc_VrTyp



