﻿Imports SMARTtBR_DAImports SMARTtBR_BOImports SMARTtBR_BL.CommonBLImports SMARTtBR_CO.CommonClassPublic Class ProductMasterBL    Private M_ProductID As Integer    Public Function Save_Data(ByVal M_ProductMaster As ProductMasterBO, ByVal M_EntryMode As String, ByVal M_MenuID As Integer) As Integer        Try            Dim M_ProductMasterDA As New ProductMasterDA            Dim UserTime As String            If CheckUserRight(M_EntryMode, M_ProductMaster.MakerID, M_MenuID) = True Then                UserTime = Get_UserTime()                M_ProductID = M_ProductMasterDA.Save_Data(M_ProductMaster, M_EntryMode, M_MenuID, UserTime)                M_ProductMasterDA = Nothing                Return M_ProductID            Else                Return 0            End If        Catch ex As Exception            Return 0        End Try    End Function    Public Function Locate_Data(ByVal M_ProductID As Integer) As ProductMasterBO        Try            Dim M_ProductMasterDA As New ProductMasterDA            Return M_ProductMasterDA.Locate_Data(M_ProductID)            M_ProductMasterDA = Nothing        Catch ex As Exception            Return Nothing        End Try    End FunctionEnd Class
