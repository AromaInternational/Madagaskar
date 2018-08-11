Imports SMARTtBR_DA
Imports SMARTtBR_BO
Imports SMARTtBR_CO
Imports SMARTtBR_BL.CommonBL
Imports SMARTtBR_CO.CommonClass
Public Class UserMasterBL
    Private M_UserID As Integer

    Public Function Save_Data(ByVal M_User As UserMasterBO, ByVal M_AllotedUnitSw As String, ByVal M_EntryMode As String, ByVal M_MenuID As Integer) As Integer
        Try
            Dim M_UserMasterDA As New UserMasterDA
            Dim UserTime As String
            If CheckUserRight(M_EntryMode, M_User.MakerID, M_MenuID) = True Then
                UserTime = Get_UserTime()
                M_UserID = M_UserMasterDA.Save_Data(M_User, M_AllotedUnitSw, M_EntryMode, M_MenuID, UserTime)
                Return M_UserID
                M_UserMasterDA = Nothing
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Locate_Data(ByVal M_UserID As Integer) As UserMasterBO
        Try

            Dim M_UserMasterDA As New UserMasterDA
            Return M_UserMasterDA.Locate_Data(M_UserID)
            M_UserMasterDA = Nothing

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Locate_DataWithName(ByVal M_UserName As String) As UserMasterBO
        Try

            Dim M_UserMasterDA As New UserMasterDA
            Return M_UserMasterDA.Locate_DataWithName(M_UserName)
            M_UserMasterDA = Nothing

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ValidateUser(ByVal M_UserMasterBO As UserMasterBO, ByVal M_Password As String, ByRef ReturnMsg As String) As Boolean
        Dim M_bln As Boolean

        M_bln = True
        ReturnMsg = ""

        With M_UserMasterBO
            If .ActiveStatus = "N" Then
                M_bln = False
                ReturnMsg = "Deactive user.... Can't Login...!"
            End If
            Select Case .UMTypeID
                Case 1, 2
                    If .UMPwd <> M_Password Then
                        M_bln = False
                        ReturnMsg = "Invalid Password.... Try Again...!"
                    End If
                Case 3
                    If .UMPwd <> M_Password Then
                        M_bln = False
                        ReturnMsg = "Invalid Password.... Try Again...!"
                    End If
            End Select
        End With

        Return M_bln
    End Function

    Public Function Check_UserNameExists(ByVal UserName As String) As Boolean

        Try
            Dim M_Return As Boolean
            Dim M_UserMasterDA As New UserMasterDA
            M_Return = M_UserMasterDA.Check_UserNameExists(UserName)
            M_UserMasterDA = Nothing
            Return M_Return

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function EncodeText(ByVal PlainText As String) As String
        Try

            Dim s As String = ""
            Dim i As Long
            Dim j As Long
            Const InText As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkl" & _
                                        "mnopqrstuvwxyz0123456789 .,?!"

            Const OUTCODE As String = "Kv iFyaehOVGpM.HfT60StRDBZ3XUmWdCo" & _
                                        "P8u2,cqIwj!J9sbLnQ?EAlz7rk41xg5NY"

            For i = 1 To Len(PlainText)
                j = InStr(InText, Mid$(PlainText, i, 1))
                If j Then
                    s = s & Mid$(OUTCODE, j, 1)
                Else
                    s = s & Mid$(PlainText, i, 1)
                End If
            Next i
            EncodeText = s

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function DecodeText(ByVal CodeText As String) As String
        Try


            Dim s As String = ""
            Dim i As Long
            Dim j As Long

            Const OUTTEXT As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkl" & _
                                        "mnopqrstuvwxyz0123456789 .,?!"
            Const INCODE As String = "Kv iFyaehOVGpM.HfT60StRDBZ3XUmWdCo" & _
                                        "P8u2,cqIwj!J9sbLnQ?EAlz7rk41xg5NY"
            For i = 1 To Len(CodeText)
                j = InStr(INCODE, Mid$(CodeText, i, 1))
                If j Then
                    s = s & Mid$(OUTTEXT, j, 1)
                Else
                    s = s & Mid$(CodeText, i, 1)
                End If
            Next i
            DecodeText = s
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class

