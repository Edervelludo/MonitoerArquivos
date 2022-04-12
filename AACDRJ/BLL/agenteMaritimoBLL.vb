
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class agenteMaritimoBLL

        Public Function InseriragenteMaritimo(ByVal agenteMaritimo As agenteMaritimoDTO) As Integer

            Dim da As New agenteMaritimoDAL

            Dim id As Integer = 0

            Try

                da.delete(agenteMaritimo.numeroDUV)
                da.insert(agenteMaritimo)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function




        Public Function SelecionaAgenteMaritimoCNPJ(ByVal CNPJ As String) As agenteMaritimoDTO

            Dim agenteDAL As New agenteMaritimoDAL
            Dim agenteDTO As New agenteMaritimoDTO

            Dim agenteDatable As DataTable = agenteDAL.SelecionaagenteMaritimoCNPJ(CNPJ)





            Try
                agenteDTO.cnpjAgenciaNavegacao = agenteDatable.Rows(0).Item("cnpjAgenciaNavegacao")
                agenteDTO.nomeAgencia = agenteDatable.Rows(0).Item("nomeAgencia")
                agenteDTO.numeroDUV = agenteDatable.Rows(0).Item("numeroDUV")



            Catch ex As Exception

            End Try
            Return agenteDTO
        End Function



    End Class

End Namespace
