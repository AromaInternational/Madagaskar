'Imports Sockets.TcpClient
'Public Class Pop3

'    Dim Stream As Sockets.NetworkStream
'    Dim UsesSSL As Boolean = False
'    Dim SslStream As Security.SslStream
'    Dim SslStreamDisposed As Boolean = False
'    Public LastLineRead As String = vbNullString
'    Public Overloads Sub Connect(ByVal server As String, _
'                             ByVal username As String, _
'                             ByVal password As String, _
'                             Optional ByVal inport As Integer = 110, _
'                             Optional ByVal usessl As Boolean = False)
'        If Connected Then disconnect()
'        UsesSSL = usessl
'        MyBase.Connect(server, inport)
'        Stream = MyBase.GetStream()
'        If UsesSSL Then
'            SslStream = New Security.SslStream(Stream)
'            SslStream.AuthenticateAsClient(server)
'        End If
'        If Not checkresponse() Then Exit Sub
'        If CBool(Len(username)) Then
'            Me.Submit("user" & username & vbCrLf)
'            If Not checkresponse() Then Exit Sub
'        End If
'        If CBool(Len(password)) Then
'            Me.Submit("pass" & password & vbCrLf)
'            If Not checkresponse() Then Exit Sub
'        End If
'    End Sub
'    Public Function checkresponse() As Boolean
'        If Not IsConnected() Then Return False
'        LastLineRead = Me.Response
'        If (Left(LastLineRead, 3) <> "+ok") Then
'            Throw New POP3Exception(LastLineRead)
'            Return False
'        End If

'        Return True
'    End Function
'    Public Function IsConnected() As Boolean
'        If Not Connected Then
'            Throw New POP3Exception("Not Connected to an Pop3 Server")
'            Return False
'        End If
'        Return True


'    End Function
'    Public Function Response(Optional ByVal datasize As Integer = 1) As String
'        Dim enc As New ASCIIEncoding
'        Dim serverbufr() As Byte
'        Dim index As Integer = 0
'        If datasize > 1 Then
'            ReDim serverbufr(datasize - 1)
'            Dim dtsz As Integer = datasize
'            Dim sz As Integer
'            Do While index < datasize
'                If UsesSSL Then
'                    sz = SslStream.Read(serverbufr, index, dtsz)
'                Else
'                    sz = Stream.Read(serverbufr, index, dtsz)
'                End If
'                If sz = 0 Then Return vbNullString
'                index += sz
'                dtsz -= sz
'            Loop
'        Else
'            ReDim serverbufr(255)
'            Do
'                If UsesSSL Then
'                    serverbufr(index) = CByte(SslStream.ReadByte)
'                Else
'                    serverbufr(index) = CByte(Stream.ReadByte)
'                End If
'                If serverbufr(index) = -1 Then Exit Do
'                index += 1
'                If serverbufr(index - 1) = 10 Then Exit Do
'                If index > UBound(serverbufr) Then
'                    ReDim Preserve serverbufr(index + 256)

'                End If
'            Loop
'        End If
'        Return enc.GetString(serverbufr, 0, index)

'    End Function

'    Public Sub Submit(ByVal message As String)
'        Dim enc As New ASCIIEncoding
'        Dim WriteBuffer() As Byte = enc.GetBytes(message)
'        If UsesSSL Then
'            SslStream.Write(WriteBuffer, 0, WriteBuffer.Length)
'        Else
'            Stream.Write(WriteBuffer, 0, WriteBuffer.Length)
'        End If
'    End Sub

'    Public Sub disconnect()
'        Me.Submit("QUIT" & vbCrLf)
'        checkresponse()
'        If UsesSSL Then
'            SslStream.Dispose()
'            SslStreamDisposed = True
'        End If

'    End Sub
'    Public Function statistics() As Integer()
'        If Not IsConnected() Then Return Nothing
'        Me.Submit("STAT" & vbCrLf)
'        LastLineRead = Me.Response
'        If (Left(LastLineRead, 3) <> "+OK") Then
'            Throw New POP3Exception(LastLineRead)
'            Return Nothing
'        End If
'        Dim msgInfo() As String = Split(LastLineRead, " "c)
'        Dim result(1) As Integer
'        result(0) = Integer.Parse(msgInfo(1))
'        result(1) = Integer.Parse(msgInfo(2))
'        Return result

'    End Function

'    Public Function List() As ArrayList
'        If Not IsConnected() Then Return Nothing
'        Me.Submit("LIST" & vbCrLf)
'        If Not checkresponse() Then Return Nothing

'        Dim retval As New ArrayList
'        Do
'            Dim response As String = Me.Response
'            If (response = "." & vbCrLf) Then
'                Exit Do
'            End If
'            Dim msg As New Pop3Message
'            Dim msgInfo() As String = Split(response, " "c)
'            msg.number = Integer.Parse(msgInfo(0))
'            msg.bytes = Integer.Parse(msgInfo(1))
'            msg.Retrieved = False
'            retval.Add(msg)
'        Loop
'        Return retval
'    End Function

'    Public Function GetHeader(ByRef msg As Pop3Message, Optional ByVal BodyLines As Integer = 0) As Pop3Message
'        If Not IsConnected() Then Return Nothing
'        Me.Submit("TOP " & msg.number.ToString & " " & BodyLines.ToString & vbCrLf)
'        If Not checkresponse() Then Return Nothing
'        msg.Message = vbNullString

'        Do
'            Dim response As String = Me.Response
'            If response = "." & vbCrLf Then
'                Exit Do
'            End If
'            msg.Message &= response
'        Loop
'        Return msg

'    End Function
'    Public Function Retrieve(ByRef msg As Pop3Message) As Pop3Message
'        If Not IsConnected() Then Return Nothing
'        Me.Submit("RETR " & msg.number.ToString & vbCrLf)
'        If Not checkresponse() Then Return Nothing
'        msg.Message = Me.Response(msg.bytes)

'        Do
'            Dim S As String = Response()
'            If S = "." & vbCrLf Then
'                Exit Do
'            End If
'            msg.Message &= S
'        Loop
'        msg.bytes = Len(msg.Message)
'        Return msg
'    End Function

'    Public Sub Delete(ByVal msgHdr As Pop3Message)
'        If Not IsConnected() Then Exit Sub
'        Me.Submit("DELE " & msgHdr.number.ToString & vbCrLf)
'        checkresponse()
'    End Sub
'    Public Sub reset()
'        If Not IsConnected() Then Exit Sub
'        Me.Submit("RSET" & vbCrLf)
'        checkresponse()

'    End Sub
'    Public Function noop() As Boolean
'        If Not IsConnected() Then Return False
'        Me.Submit("NOOP")
'        Return checkresponse()
'    End Function

'    Protected Overrides Sub Finalize()
'        If SslStream IsNot Nothing AndAlso Not SslStreamDisposed Then
'            SslStream.Dispose()
'        End If
'        MyBase.Finalize()

'    End Sub
'    Public Function ReadPop3(ByVal Server As String, _
'                              ByVal username As String, _
'                              ByVal password As String, _
'                              Optional ByVal Inport As Integer = 110, _
'                              Optional ByVal usessl As Boolean = False) As ArrayList
'        Try
'            Dim inmail As New Pop3
'            inmail.Connect(Server, username, password, Inport, usessl)
'            Dim stats() As Integer = inmail.statistics()
'            If stats(0) = 0 Then
'                Return Nothing

'            End If
'            Dim locallist As New ArrayList
'            For Each msg As Pop3Message In inmail.List
'                locallist.Add(inmail.Retrieve(msg))
'            Next
'            inmail.disconnect()
'            Return locallist
'        Catch ex As POP3Exception
'            MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Error Encounted")

'        Catch e As Exception
'            MsgBox(e.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Error Encounted")
'        End Try
'        Return Nothing
'    End Function

'End Class

'Public Class Pop3Message
'    Public MailID As Integer = 0
'    Public ByteCount As Integer = 0
'    Public number As Integer = 0
'    Public bytes As Integer = 0
'    Public Retrieved As Boolean = False
'    Public Message As String = vbNullString

'    Public Overrides Function ToString() As String
'        Return Message
'    End Function
'End Class

'Public Class POP3Exception
'    Inherits ApplicationException

'    Public Sub New(ByVal str As String)
'        MyBase.New(str)
'    End Sub
'End Class