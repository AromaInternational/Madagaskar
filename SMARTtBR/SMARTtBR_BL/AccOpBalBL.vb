﻿Imports SMARTtBR_DAImports SMARTtBR_BOImports SMARTtBR_BL.CommonBLImports SMARTtBR_CO.CommonClassPublic Class AccOpBalBL    Private M_AccOpId As Integer    Public Function Save_Data(ByVal M_AccOpBal As AccOpBalBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer) As Integer        Try            Dim M_AccOpBalDA As New AccOpBalDA            Dim UserTime As String            If CheckUserRight(M_EntryMode, M_AccOpBal.MakerID, M_MenuID) = True Then                UserTime = Get_UserTime()                M_AccOpId = M_AccOpBalDA.Save_Data(M_AccOpBal, M_EntryMode, M_MenuID, UserTime)                M_AccOpBalDA = Nothing                Return M_AccOpId            Else                Return 0            End If        Catch ex As Exception            Return 0        End Try    End Function    Public Function Locate_Data(ByVal M_AccOpId As Integer) As AccOpBalBO        Try            Dim M_AccOpBalDA As New AccOpBalDA            Return M_AccOpBalDA.Locate_Data(M_AccOpId)            M_AccOpBalDA = Nothing        Catch ex As Exception            Return Nothing        End Try    End FunctionEnd Class