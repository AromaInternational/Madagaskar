﻿Imports SMARTtBR_CO.CommonClassPublic Class UserPwdChangeBO    Private M_UPUMID As Integer    Private M_MakerID As Integer    Private M_MakingTime As Date    Private M_UPID As Long    Private M_UPCurrPwd As String    Private M_UPNewPwd As String    Public Property UPUMID() As Integer        Get            Return M_UPUMID        End Get        Set(ByVal value As Integer)            M_UPUMID = value        End Set    End Property    Public Property MakerID() As Integer        Get            Return M_MakerID        End Get        Set(ByVal value As Integer)            M_MakerID = value        End Set    End Property    Public Property MakingTime() As Date        Get            Return M_MakingTime        End Get        Set(ByVal value As Date)            M_MakingTime = value        End Set    End Property    Public Property UPID() As Long        Get            Return M_UPID        End Get        Set(ByVal value As Long)            M_UPID = value        End Set    End Property    Public Property UPCurrPwd() As String        Get            Return M_UPCurrPwd        End Get        Set(ByVal value As String)            M_UPCurrPwd = value        End Set    End Property    Public Property UPNewPwd() As String        Get            Return M_UPNewPwd        End Get        Set(ByVal value As String)            M_UPNewPwd = value        End Set    End PropertyEnd Class