Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors


<EnableCors("*", "*", "*")>
    Public Class skrivbokenController
        Inherits ApiController

    Private devkeyhandler As New devkeyhandler


    'localhost:59015/Api_v3.1/skrivboken/devkey/alf/?type=jsonp&callback=testar
    Public Function GetValues(devkey As String) As funkarInfo

        Dim testar As funkarInfo = New funkarInfo
        If devkeyhandler.checkdevkey(devkey) Then
            testar.namn = "Andreas build2"
            testar.devkey = "inga värden" & devkeyhandler.Statusmessage
        Else
            testar.namn = ""
            testar.devkey = devkeyhandler.Statusmessage
        End If

        Return testar

    End Function


End Class
