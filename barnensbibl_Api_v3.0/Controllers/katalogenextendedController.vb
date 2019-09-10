Imports System.Web.Http
Imports System.Web.Http.Cors

'Författare also write
'localhost:59015/Api_v3.1/katalogenextended/typ/faw/val/18720/devkey/alf/?type=json&callback=testar

<EnableCors("*", "*", "*")>
    Public Class katalogenextendedController
        Inherits ApiController

        Private _devkeyhandler As New devkeyhandler

    Public Function GetValues(cmdtyp As String, value As String, devkey As String) As Object
        Dim retobj As New Object
        Dim obj As New katalogenExtendedHandler

        If String.IsNullOrEmpty(value) Or value = "undefined" Then
            value = 0
        End If

        If _devkeyhandler.checkdevkey(devkey) Then
            Select Case cmdtyp
                Case "faw" 'forfattare Also Write = faw
                    retobj = obj.getForfattareAlsoWrite(CInt(value))

                Case Else
                    retobj = "fel anrop!"
            End Select


        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function


End Class

