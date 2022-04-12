
Imports MonitorArquivos.DE.DAL
Imports MonitorArquivos.DE.DTO

Namespace DE.BLL
    Public Class DEcaracteristicasBLL

        Public Function InserirCaracteristicas(ByVal embarcacao As DEcaracteristicasDTO) As Integer

            Dim da As New DEcaracteristicasDAL

            Dim id As Integer = 0

            Try

                da.delete(embarcacao.numeroIMO)
                da.insert(embarcacao)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function






    End Class

End Namespace
