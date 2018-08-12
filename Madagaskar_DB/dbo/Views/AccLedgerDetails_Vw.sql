


CREATE VIEW [dbo].[AccLedgerDetails_Vw]
AS
SELECT  M.Acc_Id,U.UN_CmpCode AS Cmp_Code, U.Cmp_Name, M.Acc_UNID, U.UN_Name, M.Acc_VrNo, M.Acc_VrTyp, M.Acc_FinYear, M.Acc_Type, M.Acc_TrDate, M.Acc_ChqNo, M.Acc_OrgFrom, M.Acc_Narration, 
                         M.Acc_ChqDate,  T.Acc_SlNo, T.Acc_Code, A.Acc_Name, A.GP_Name, A.Acc_GPID AS GP_ID, A.GP_SeqNo, A.Acc_SeqNo, A.Acc_Statementtype, A.Acc_BalType, A.Acc_ALIE, A.Acc_Position, 
                         T.Acc_TranType, T.Acc_Amt, CASE WHEN T .Acc_TranType = 1 THEN 'Cr' ELSE 'Dr' END AS Acc_TrType, CASE WHEN T .Acc_TranType = 1 THEN T .Acc_Amt ELSE 0 END AS Acc_CrAmount, 
                         CASE WHEN T .Acc_TranType = - 1 THEN T .Acc_Amt ELSE 0 END AS Acc_DrAmount, M.Active_Status, M.Maker_ID, M.Making_Time, M.Updater_ID, M.Updating_Time
FROM            dbo.AccLedger_M_Tbl AS M INNER JOIN
                         dbo.AccLedger_T_Tbl AS T ON M.Acc_Id = T.Acc_Id INNER JOIN
                         dbo.AccountMaster_Vw AS A ON T.Acc_Code = A.Acc_Code INNER JOIN
                         dbo.UnitMaster_Vw AS U ON M.Acc_UNID = U.UN_ID 



