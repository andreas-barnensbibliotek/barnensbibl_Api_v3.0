Imports krypinBoktips
Public Class boktipsHandler
    Public Function handleBoktips(cmdinfo As boktipsCommandInfo) As krypinBoktipsInfo
        Dim obj As New krypinBoktipsMainController
        Dim retobj As New krypinBoktipsInfo
        Try
            Select Case cmdinfo.Cmdtyp
                Case "ByAuthor"
                    retobj = obj.BookTipsByAuthor(cmdinfo.textValue)
                Case "ByCategory"
                    retobj = obj.BookTipsByCategory(cmdinfo.value)
                Case "ByRndInCategory"
                    retobj = obj.BookTipsByRandomInCategory(cmdinfo.value, CInt(cmdinfo.textValue))
                Case "ByRandom"
                    retobj = obj.BookTipsByRandom(cmdinfo.value)
                Case "ByAge"
                    retobj = obj.BooktTipsByAgeInterval(cmdinfo.value)
                Case "Latest"
                    retobj = obj.BookTipsLatest(cmdinfo.value)
                Case "BySearch"
                    retobj = obj.BookTipsBySearch(cmdinfo.textValue)
                Case "ByTitle"
                    retobj = obj.BookTipsByTitle(cmdinfo.textValue)
                Case "ByTipId"
                    retobj = obj.booktipByTipId(cmdinfo.value)
                Case Else
                    retobj.Status = "ERROR Ingen cmdtyp är angiven!"
            End Select
        Catch ex As Exception
            retobj.Status = "ERROR handleBookToUserBooklist!"
        End Try
        Return retobj

    End Function

    Public Function handleCrudBoktips(cmdinfo As boktipsCommandInfo, boktips As boktipsInfo) As krypinBoktipsInfo
        Dim obj As New krypinBoktipsMainCRUDController
        Dim retobj As New krypinBoktipsInfo
        Try
            Select Case cmdinfo.Cmdtyp
                Case "addboktips"
                    retobj = obj.addbooktip(boktips)

                Case "editboktips"
                    retobj = obj.editbooktip(boktips)

                Case "deleteboktips"
                    retobj = obj.deletebooktip(boktips)

                Case Else
                    retobj.Status = "ERROR Ingen cmdtyp är angiven!"
            End Select
        Catch ex As Exception
            retobj.Status = "ERROR handleBookToUserBooklist!"
        End Try
        Return retobj
    End Function
End Class
