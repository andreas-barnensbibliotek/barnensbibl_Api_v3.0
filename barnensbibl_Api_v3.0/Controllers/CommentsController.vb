
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports katalogenKommentarerLibrary

'Get kommentar via bookid
'localhost:59015/Api_v3.1/Comments/typ/getcom/val/6533/devkey/alf/?type=json&callback=testar

'Main add kommentar
'localhost:59015/Api_v3.1/Comments/typ/addcom/devkey/alf/?type=json&callback=testar
'POST:
'{
'"bookid" : "6533",
'"CommentNamn" : "Andreas J",
'"CommentAlder" : "21",
'"CommentInlagg" : "testar via API",
'"Approved" : "1",
'"CommentNewID":"0"
'}
'values: typ/cmdtyp: addcom 


<EnableCors("*", "*", "*")>
Public Class CommentsController
    Inherits ApiController

    Private _devkeyhandler As New devkeyhandler

    Public Function GetValues(cmdtyp As String, value As String, devkey As String) As Object
        Dim retobj As New Object
        Dim obj As New CommentsHandler


        If _devkeyhandler.checkdevkey(devkey) Then
            If Not String.IsNullOrEmpty(value) Or value = "undefined" Then

                Select Case cmdtyp
                    Case "getcom"
                        retobj = obj.getBookKommentarer(CInt(value))
                End Select

            Else
                retobj.Status = "ERROR Inget Bookid angivet!!"

            End If

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function


    Public Function PostValue(cmdtyp As String, devkey As String, <FromBody> commentForm As kommentInfo) As Object
        Dim retobj As New Object
        Dim obj As New CommentsHandler

        If _devkeyhandler.checkdevkey(devkey) Then

            Select Case cmdtyp
                Case "addcom"
                    retobj = obj.addBookKommentarer(commentForm)
            End Select

        Else
            retobj.Status = _devkeyhandler.Statusmessage
        End If

        Return retobj

    End Function


End Class

