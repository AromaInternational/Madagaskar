﻿Imports SMARTtBR_DAL
                M_Sql = M_Sql & "'" & .ProductName & "',"
                M_Sql = M_Sql & .AccountCode & ","
                M_Sql = M_Sql & "'" & .ProductCategory & "',"
                M_Sql = M_Sql & .Measurement1Value & ","
                M_Sql = M_Sql & "'" & .Measurement1Text & "',"
                M_Sql = M_Sql & .Measurement2Value & ","
                M_Sql = M_Sql & "'" & .Measurement2Text & "',"
                M_Sql = M_Sql & .Measurement3Value & ","
                M_Sql = M_Sql & "'" & .Measurement3Text & "',"
                M_Sql = M_Sql & "'" & .MeasurementFinalFormula & "',"
                M_Sql = M_Sql & "'" & .MeasurementFinalText & "',"
                M_Sql = M_Sql & .UpdaterId & ","
                M_Sql = M_Sql & .MakerID & ","
                M_Sql = M_Sql & "'" & UserTime & "',"
                M_Sql = M_Sql & "'" & IIf(M_EntryMode = "NEW", "01/01/1900", UserTime) & "'"

            End With
    Public Function Locate_Data(ByVal M_ProductID As Integer) As ProductMasterBO
                    .AccountCode = M_Dt.Rows(0).Item("Account_Code")
                    .UpdaterId = M_Dt.Rows(0).Item("Updater_Id")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .Measurement1Value = M_Dt.Rows(0).Item("Measurement1_Value")
                    .Measurement2Value = M_Dt.Rows(0).Item("Measurement2_Value")
                    .Measurement3Value = M_Dt.Rows(0).Item("Measurement3_Value")
                    .ProductName = M_Dt.Rows(0).Item("ProductName")
                    .ProductCategory = M_Dt.Rows(0).Item("ProductCategory")
                    .Measurement1Text = M_Dt.Rows(0).Item("Measurement1_Text")
                    .Measurement2Text = M_Dt.Rows(0).Item("Measurement2_Text")
                    .Measurement3Text = M_Dt.Rows(0).Item("Measurement3_Text")
                    .MeasurementFinalFormula = M_Dt.Rows(0).Item("MeasurementFinal_Formula")
                    .MeasurementFinalText = M_Dt.Rows(0).Item("MeasurementFinal_Text")

                End With
End Class