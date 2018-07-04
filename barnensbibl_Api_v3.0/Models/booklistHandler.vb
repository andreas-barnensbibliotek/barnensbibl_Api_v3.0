Imports krypinBoklistor

Public Class booklistHandler
    Public Function getuserboklists(userid As Integer) As krypinBookListInfo
        Dim obj As New krypinBoklistorMainController
        Return obj.getAllUserBooklists(userid)

    End Function

    Public Function handleBookToUserBooklist(cmdinfo As booklistCommandInfo) As krypinBookListInfo
        Dim obj As New krypinBoklistorMainController
        Dim retobj As New krypinBookListInfo
        Try
            Select Case cmdinfo.Cmdtyp
                Case "addbooklist"
                    retobj = obj.addBooklist(cmdinfo.userid, cmdinfo.value)
                Case "delbooklist"
                    retobj = obj.delBooklist(cmdinfo.Boklistid, cmdinfo.userid)
                Case "editbooklist"
                    retobj = obj.editBooklist(cmdinfo.Boklistid, cmdinfo.userid, cmdinfo.value)
                Case "addbook"
                    retobj = obj.addBookidToBooklist(cmdinfo.Boklistid, cmdinfo.userid, CInt(cmdinfo.value))
                Case "delbook"
                    retobj = obj.delBookidFromBooklist(cmdinfo.Boklistid, CInt(cmdinfo.value), cmdinfo.userid)
                Case Else
                    retobj.Status = "ERROR Ingen cmdtyp är angiven!"
            End Select
        Catch ex As Exception
            retobj.Status = "ERROR handleBookToUserBooklist!"
        End Try
        Return retobj

    End Function
End Class
