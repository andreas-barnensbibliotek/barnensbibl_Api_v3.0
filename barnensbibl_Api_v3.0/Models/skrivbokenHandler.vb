﻿Imports krypinSkrivboken
Public Class skrivbokenHandler

    Public Function handleskrivboken(cmdtyp As String, mainvalue As String, typevalue As String, approved As String, publish As String) As skrivbokenJsonContainerInfo
        Dim obj As New krypinSkrivbokenMainController

        Dim cmdsettings As New commandTypeInfo
        cmdsettings.GetPublishTyp = CInt(typevalue)
        cmdsettings.Approved = CInt(approved)
        cmdsettings.Publish = CInt(publish)

        Dim retobj As New skrivbokenJsonContainerInfo
        Try
            Select Case cmdtyp
                Case "ByUserID"
                    cmdsettings.Userid = CInt(mainvalue)
                    retobj = obj.getSkrivbokByUserid(cmdsettings)

                Case "ByCategory"
                    cmdsettings.Approved = 1
                    cmdsettings.Publish = 3
                    cmdsettings.Category = CInt(mainvalue)
                    retobj = obj.getSkrivbokByCategory(cmdsettings)

                Case "BySkrivid"
                    cmdsettings.Skrivid = CInt(mainvalue)
                    cmdsettings.Userid = CInt(typevalue)


                    retobj = obj.getSkrivbokBySkrivid(cmdsettings)

                Case Else
                    retobj.Status = "ERROR Ingen cmdtyp är angiven!"
            End Select
        Catch ex As Exception
            retobj.Status = "ERROR handleSkrivboken!"
        End Try

        Return retobj

    End Function

    Public Function handleCrudSkrivboken(cmdinfo As skrivbokenCommandInfo, skrivbokitem As skrivItemInfo) As skrivbokenJsonContainerInfo
        Dim obj As New krypinSkrivbokenMainController
        Dim retobj As New skrivbokenJsonContainerInfo
        Dim cmdsettings As New commandTypeInfo
        Try
            Select Case cmdinfo.Cmdtyp
                Case "addskrivboken"
                    retobj.Status = obj.CrudADDskrivboken(skrivbokitem)

                Case "editskrivboken"
                    retobj.Status = obj.CrudUpdateAllskrivboken(skrivbokitem)

                Case "deleteskrivbok"
                    retobj.Status = obj.CrudDeleteskrivboken(skrivbokitem)

                Case Else
                    retobj.Status = "ERROR Ingen cmdtyp är angiven!"
            End Select
        Catch ex As Exception
            retobj.Status = "ERROR handleSkrivbokItem!"
        End Try
        Return retobj
    End Function
End Class
