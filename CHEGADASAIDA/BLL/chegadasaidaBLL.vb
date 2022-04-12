
Imports MonitorArquivos.CHEGADASAIDA.DAL
Imports MonitorArquivos.CHEGADASAIDA.DTO


Namespace CHEGADASAIDA.BLL
    Public Class chegadasaidaBLL

        Public Function Inserirchegadasaida(ByVal chegadasaida As chegadasaidaDTO) As Integer

            Dim da As New chegadasaidaDAL

            Dim id As Integer = 0

            '  Try

            '  da.delete(chegadasaida.numeroDuv)
            da.insert(chegadasaida)



            id = 1

            ' Catch ex As Exception
            ' Throw ex
            ' End Try
            Return id
        End Function



        Public Function Deletechegadasaida(ByVal duv As String) As Integer

            Dim da As New chegadasaidaDAL

            Dim id As Integer = 0

            '  Try

            da.delete(duv)
            'da.insert(chegadasaida)



            id = 1

            ' Catch ex As Exception
            ' Throw ex
            ' End Try
            Return id
        End Function


    End Class

End Namespace
