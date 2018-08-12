


CREATE VIEW [dbo].[AccOpBal_Vw]
AS
SELECT        M.Acc_OpId, U.UN_CmpCode AS Cmp_Code, U.Cmp_Name, M.Acc_UNID, U.UN_Name, M.Acc_OpMode, M.Acc_Code, A.Acc_Name, A.Acc_GPID AS GP_ID, A.GP_Name, 
                         M.Acc_OpDate, A.GP_SeqNo, A.Acc_SeqNo, A.Acc_Statementtype, A.Acc_ALIE, A.Acc_Position,
                             (SELECT        Fin_Period
                               FROM            dbo.FinYear_Details_Fn(1, DATEADD(Day, 1, M.Acc_OpDate)) AS FinYear_Details_Fn_1
                               WHERE        (Fin_OBDate = M.Acc_OpDate)) AS Fin_Period, 
							   M.Acc_Balance, M.Acc_BalType, CASE WHEN M.Acc_BalType = 1 THEN M.Acc_Balance ELSE 0 END AS Acc_CrBalance, 
                         CASE WHEN M.Acc_BalType = - 1 THEN M.Acc_Balance ELSE 0 END AS Acc_DrBalance, M.Active_Status, M.Maker_ID, M.Making_Time, M.Updater_ID, M.Updating_Time
FROM            dbo.AccOpBal_M_Tbl AS M INNER JOIN
                         dbo.AccountMaster_Vw AS A ON M.Acc_Code = A.Acc_Code INNER JOIN
                         dbo.UnitMaster_Vw AS U ON M.Acc_UNID = U.UN_ID




GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[50] 4[12] 2[21] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "M"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 437
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "U"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AccOpBal_Vw';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'AccOpBal_Vw';

