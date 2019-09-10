Imports ForfattareLibrary
Public Class katalogenExtendedHandler
    Public Function getForfattareAlsoWrite(creatrorid As Integer) As forfattareWriteInfo
        Dim obj As New forfattareMainController

        Dim retobj As New forfattareWriteInfo
        Try
            retobj = obj.GetExtraforfattarData(creatrorid)

        Catch ex As Exception
            retobj.status = "ERROR Fel vid hämtning av författare also write id: " & creatrorid
        End Try

        Return retobj
    End Function
End Class
