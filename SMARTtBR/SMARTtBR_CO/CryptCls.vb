Public Class CryptCls
    Public Function Encrypt(ByVal sCrypt As String) As String
        Dim tmp As String = ""
        Dim sVal As String
        Dim l As Long
        Encrypt = ""
        Try
            For l = 1 To Len(sCrypt)
                sVal = HexValue(Mid(sCrypt, l, 1))
                If Len(sVal) > 4 Then
                    If Left(sVal, 4) = "ERR:" Then
                        tmp = sVal
                        Exit For
                    End If
                End If
                If Len(sVal) = 1 Then sVal = "0" & sVal
                tmp = tmp & sVal
            Next l
            Encrypt = tmp
        Catch ex As Exception
            Logger.LogInfo(ex)
        End Try
    End Function

    Public Function Decrypt(ByVal sCrypt As String) As String
        Dim tmp As String = ""
        Dim sVal As String
        Dim str As String
        Decrypt = ""

        Try
            sVal = UCase(sCrypt)
            Do Until sVal = ""
                If Len(sVal) < 2 Then
                    str = ChrValue(sVal)
                    If Len(str) > 4 Then
                        If Left(str, 4) = "ERR:" Then
                            tmp = str
                            Exit Do
                        End If
                    End If
                    tmp = tmp & str
                    sVal = ""
                Else
                    str = Left(sVal, 2)
                    If Left(str, 1) = "0" Then str = Right(str, 1)
                    str = ChrValue(str)
                    If Len(str) > 4 Then
                        If Left(str, 4) = "ERR:" Then
                            tmp = str
                            Exit Do
                        End If
                    End If
                    tmp = tmp & str
                    sVal = Right(sVal, Len(sVal) - 2)
                End If
            Loop
            Decrypt = tmp
        Catch ex As Exception
            Logger.LogInfo(ex)
        End Try
    End Function

    Private Function HexValue(ByVal sChr As String) As String
        Dim iDec As Integer
        iDec = Asc(sChr)
        HexValue = Hex(iDec)
    End Function

    Private Function ChrValue(ByVal sHex As String) As String
        Dim sChr As String
        Dim dblVal As Double
        Dim i As Integer
        Const cIdx = 16
        ChrValue = ""
        Try
            For i = 1 To Len(sHex)
                sChr = Mid(sHex, i, 1)
                If sChr <> " " Then
                    If sChr <= "9" Then
                        dblVal = dblVal + CInt(sChr)
                    Else
                        dblVal = dblVal + ((Asc(sChr) - 55) Mod 32)
                    End If
                    If i < Len(sHex) Then dblVal = dblVal * cIdx
                End If
            Next i
            ChrValue = Chr(dblVal)
        Catch ex As Exception
            Logger.LogInfo(ex)
        End Try
    End Function
End Class
