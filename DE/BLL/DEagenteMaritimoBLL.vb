
Imports MonitorArquivos.DE.DTO
Imports MonitorArquivos.DE.DAL

Namespace DE.BLL
    Public Class DEagenteMaritimoBLL

        Public Function InseriragenteMaritimo(ByVal agenteMaritimo As DEagenteMaritimoDTO) As Integer

            Dim da As New DEagenteMaritimoDAL

            Dim id As Integer = 0

            Try

                da.delete(agenteMaritimo.cnpjAgenciaNavegacao)
                da.insert(agenteMaritimo)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function




        Public Function SelecionaAgenteMaritimoCNPJ(ByVal CNPJ As String) As DEagenteMaritimoDTO

            Dim agenteDAL As New DEagenteMaritimoDAL
            Dim agenteDTO As New DEagenteMaritimoDTO

            Dim agenteDatable As DataTable = agenteDAL.SelecionaagenteMaritimoCNPJ(CNPJ)





            Try
                agenteDTO.cnpjAgenciaNavegacao = agenteDatable.Rows(0).Item("cnpjAgenciaNavegacao")
                agenteDTO.nomeAgencia = agenteDatable.Rows(0).Item("nomeAgencia")



            Catch ex As Exception

            End Try
            Return agenteDTO
        End Function



    End Class

End Namespace
