﻿Imports System.Web.Http
Imports System.Web.Http.Cors
Imports BibbloMoney
Imports QuestLibrary

'get användarens bokmärkleser i lista:  byuserid
'localhost:59015/Api_v3.1/award/cmdtyp/byuserid/uid/7017/ag/0/devkey/alf?type=json
'get användarens bokmärkleser från vald awardgroup i lista:  byuserid, awardGroupID (exempel:boktips = 2)
'localhost:59015/Api_v3.1/award/cmdtyp/awardGroupID/uid/7017/ag/2/devkey/alf?type=json

<EnableCors("*", "*", "*")>
Public Class awardController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler
    Public Function GetValues(cmdtyp As String, userid As String, awardgroup As String, devkey As String) As bokmarkelserReturnInfo
        Dim retobj As New bokmarkelserReturnInfo
        Dim obj As New AwardHandler

        If _devkeyhandler.checkdevkey(devkey) Then
            retobj = obj.getawards(cmdtyp, CInt(userid), CInt(awardgroup))
        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function

    Public Function PostValue(cmdtyp As String, devkey As String, <FromBody> questinfo As cmdInfo) As UserQuestInfo
        Dim retobj As New UserQuestInfo
        Dim cmdobj As New cmdInfo

        If _devkeyhandler.checkdevkey(devkey) Then
            cmdobj.Cmdtyp = cmdtyp
            cmdobj.QTriggerID = questinfo.QTriggerID
            cmdobj.QuestID = questinfo.QuestID
            cmdobj.Svar = questinfo.Svar
            cmdobj.uQuestID = questinfo.uQuestID
            cmdobj.Userid = questinfo.Userid



        Else
            'retobj.Boktips.Add(New boktipsInfo)
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj
        'exempel på cmd= byStatus,bySearch

    End Function
End Class
