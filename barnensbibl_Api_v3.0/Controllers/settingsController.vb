Imports System.Web.Http
Imports System.Web.Http.Cors
Imports KrypinSettings

'get användarens setting i lista:  commandtyp: get, required: userid
'localhost:59015/Api_v3.1/settings/cmdtyp/get/uid/7017/setid/0/setval/0/devkey/alf?type=json

'get användarens läserjust nu bok. får bookid och bookimage:    commandtyp: getlasernu, required: userid
'localhost:59015/Api_v3.1/settings/cmdtyp/getlasernu/uid/7017/setid/0/setval/0/devkey/alf?type=json

'get updatera setting:  commandtyp: settings, required: userid, setid, setval
' setid = använd settingsid för att avgöra vilken typ av setting som skall ändras, 
' setval= värdet som skall sparas
'localhost:59015/Api_v3.1/settings/cmdtyp/settings/uid/7017/setid/1/setval/17/devkey/alf?type=json

'kör en gång uppdatera alla krypin settings från krypintabellen
'localhost:59015//Api_v3.1/settings/cmdtyp/updaterasettings/uid/7017/setid/0/setval/0/devkey/alf?type=json


<EnableCors("*", "*", "*")>
Public Class settingsController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler
    Public Function GetValues(cmdtyp As String, userid As String, setid As String, setval As String, devkey As String) As ListUserSettingsInfo
        Dim retobj As New ListUserSettingsInfo
        Dim obj As New settingsHandler
        Dim cmdobj As New CmdSettingsInfo
        cmdobj.Userid = CInt(userid)
        cmdobj.SettingCmdtyp = cmdtyp
        cmdobj.SettingsIdValue = CInt(setid)
        cmdobj.SettingValue = setval

        If _devkeyhandler.checkdevkey(devkey) Then
            retobj = obj.getUserSettings(cmdobj)
        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function

End Class

