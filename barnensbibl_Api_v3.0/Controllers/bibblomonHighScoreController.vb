Imports System.Web.Http
Imports System.Web.Http.Cors
Imports BibblomonLibrary

'get bibblomon highscorelist
'localhost:59015/Api_v3.1/bibblomonHighScore/typ/Highscore/devkey/alf?type=json
<EnableCors("*", "*", "*")>
Public Class bibblomonHighScoreController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler
    Public Function GetValues(cmdtyp As String, devkey As String) As bibblomonHighscoreInfo
        Dim objHandler As New bibblomonHandler
        Dim cmdobj As New bibblomonCommandInfo
        Dim retobj As New bibblomonHighscoreInfo

        If _devkeyhandler.checkdevkey(devkey) Then
            cmdobj.Cmdtyp = cmdtyp

            retobj = objHandler.getbokemonHighScoredata(cmdobj)

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function

End Class
