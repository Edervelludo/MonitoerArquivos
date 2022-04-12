
Imports MonitorArquivos.CHEGADASAIDA.DAL
Imports MonitorArquivos.CHEGADASAIDA.DTO


Namespace CHEGADASAIDA.BLL
    Public Class chegadasaidadadosDuvBLL

        Public Function InserirchegadasaidadadosDuv(ByVal chegadasaidadadosDuv As chegadasaidadadosDuvDTO) As Integer

            Dim da As New chegadasaidadadosDuvDAL

            Dim id As Integer = 0

            '  Try

            da.delete(chegadasaidadadosDuv.numeroduv)
            da.insert(chegadasaidadadosDuv)



            id = 1

            ' Catch ex As Exception
            ' Throw ex
            ' End Try
            Return id
        End Function






    End Class

End Namespace
