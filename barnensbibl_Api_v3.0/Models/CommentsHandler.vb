Imports katalogenKommentarerLibrary
Public Class CommentsHandler

    Private _obj As New kommentarMainController

    Public Function getBookKommentarer(bookid As Integer) As mainkommentarInfo
        Dim retobj As New mainkommentarInfo
        Try
            retobj = _obj.getComments(bookid)

        Catch ex As Exception
            retobj.Status = "ERROR Fel vid hämtning av bokkommentarer!"
        End Try

        Return retobj
    End Function

    Public Function addBookKommentarer(comObj As kommentInfo) As mainkommentarInfo
        Dim retobj As New mainkommentarInfo
        Try
            retobj = _obj.addCommment(comObj)

        Catch ex As Exception
            retobj.Status = "ERROR Fel när bokkommentar skulle läggas till!"
        End Try

        Return retobj
    End Function

End Class
