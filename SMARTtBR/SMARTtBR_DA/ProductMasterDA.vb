Imports SMARTtBR_DAL
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Public Class ProductMasterDA
    Private M_DBConn As Connection
    Private M_ProductID As Integer
    Public Function Save_Data(ByVal M_ProductMaster As ProductMasterBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer, ByVal UserTime As String) As Integer
        Try
            Dim M_Sql As String

            With M_ProductMaster
                M_Sql = "Exec IUM_ProductMaster_Sp "
                M_Sql = M_Sql & "'" & M_EntryMode & "',"
                M_Sql = M_Sql & M_MenuID & ","
                M_Sql = M_Sql & .ProductID & ","
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

            M_ProductID = M_DBConn.ExecuteScalar(M_Sql)

            Return M_ProductID

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function


    Public Function Locate_Data(ByVal M_ProductID As Integer) As ProductMasterBO
        Try
            Dim M_Dt As New DataTable
            Dim M_ProductMaster As New ProductMasterBO
            Dim Qry As String
            Qry = "Select * from ProductMaser_Vw where ProductID = " & M_ProductID
            M_DBConn.ExecuteDataTable(M_Dt, Qry)
            If M_Dt.Rows.Count > 0 Then
                With M_ProductMaster
                    .ProductID = M_Dt.Rows(0).Item("ProductID")
                    .AccountCode = M_Dt.Rows(0).Item("Account_Code")
                    .UpdaterId = M_Dt.Rows(0).Item("Updater_Id")
                    .MakerID = M_Dt.Rows(0).Item("Maker_ID")
                    .MakingTime = M_Dt.Rows(0).Item("Making_Time")
                    .UpdatingTime = M_Dt.Rows(0).Item("Updating_Time")
                    .Measurement1Value = M_Dt.Rows(0).Item("Measurement1_Value")
                    .Measurement2Value = M_Dt.Rows(0).Item("Measurement2_Value")
                    .Measurement3Value = M_Dt.Rows(0).Item("Measurement3_Value")
                    .ProductName = M_Dt.Rows(0).Item("ProductName")
                    .ProductNameDetailed = M_Dt.Rows(0).Item("ProductName_Detailed")
                    .ProductCategory = M_Dt.Rows(0).Item("ProductCategory")
                    .Measurement1Text = M_Dt.Rows(0).Item("Measurement1_Text")
                    .Measurement2Text = M_Dt.Rows(0).Item("Measurement2_Text")
                    .Measurement3Text = M_Dt.Rows(0).Item("Measurement3_Text")
                    .MeasurementFinalFormula = M_Dt.Rows(0).Item("MeasurementFinal_Formula")
                    .MeasurementFinalText = M_Dt.Rows(0).Item("MeasurementFinal_Text")

                End With
            End If
            Return M_ProductMaster
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub New()
        M_DBConn = New Connection
    End Sub

End Class
