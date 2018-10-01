Imports System.Web.Http
Imports System.Web.Http.Cors
Imports BibblomonLibrary

'get alla monster: allmon, userid
'localhost:59015/Api_v3.1/bibblomon/cmdtyp/allmon/uid/7017/monid/0/devkey/alf?type=json
'get användarens alla monster: allmon, userid
'localhost:59015/Api_v3.1/bibblomon/cmdtyp/usrmon/uid/7017/monid/0/devkey/alf?type=json
'lägg till en bibblomon eller uppgradera befintlig bibblomon
'localhost:59015/Api_v3.1/bibblomon/cmdtyp/addmon/uid/7071/monid/7/devkey/alf?type=json
'hämta alla drakar i lista
'localhost:59015/Api_v3.1/bibblomon/cmdtyp/alldrakar/uid/0/monid/0/devkey/alf?type=json
'gameplaywin when bibblomon win a battle
'localhost:59015/Api_v3.1/bibblomon/cmdtyp/gameplaywin/uid/0/monid/0/devkey/alf?type=json
'gameplaylose when bibblomon loose a battle
'localhost:59015/Api_v3.1/bibblomon/cmdtyp/gameplaylose/uid/7017/monid/2/devkey/alf?type=json


<EnableCors("*", "*", "*")>
Public Class bibblomonController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler
    Public Function GetValues(cmdtyp As String, userid As String, monid As String, devkey As String) As bokemonInfo
        Dim objHandler As New bibblomonHandler
        Dim cmdobj As New bibblomonCommandInfo
        Dim retobj As New bokemonInfo

        If _devkeyhandler.checkdevkey(devkey) Then
            cmdobj.Cmdtyp = cmdtyp
            cmdobj.Userid = CInt(userid)
            cmdobj.Monsterid = CInt(monid)

            retobj = objHandler.getbokemondata(cmdobj)

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function


End Class
