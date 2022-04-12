
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class estadiaEmbarcacaoBLL

        Public Function InserirestadiaEmbarcacao(ByVal estadia As estadiaEmbarcacaoDTO) As Integer

            Dim da As New estadiaEmbarcacaoDAL

            Dim id As Integer = 0

            Try

                da.delete(estadia.numeroDuv)
                da.insert(estadia)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function

        Public Function SelecionaestadiaEmbarcacaoDUV(ByVal DUV As String) As estadiaEmbarcacaoDTO

            Dim estadiaDAL As New estadiaEmbarcacaoDAL
            Dim estadiaDTO As New estadiaEmbarcacaoDTO

            Dim avisoDatable As DataTable = estadiaDAL.SelecionaestadiaEmbarcacaoDUV(DUV)





            Try

                estadiaDTO.numeroDuv = avisoDatable.Rows(0).Item("numeroDuv")
                estadiaDTO.prioridadePretendida = avisoDatable.Rows(0).Item("prioridadePretendida")
                estadiaDTO.qtdeDiasPrevistosOperacao = avisoDatable.Rows(0).Item("qtdeDiasPrevistosOperacao")
                estadiaDTO.numeroViagemAgencia = avisoDatable.Rows(0).Item("numeroViagemAgencia")
                estadiaDTO.tipoViagemOrigem = avisoDatable.Rows(0).Item("tipoViagemOrigem")
                estadiaDTO.tipoViagemDestino = avisoDatable.Rows(0).Item("tipoViagemDestino")
                estadiaDTO.destinoCarga = avisoDatable.Rows(0).Item("destinoCarga")
                estadiaDTO.quantidadeFlutuantes = avisoDatable.Rows(0).Item("quantidadeFlutuantes")
                estadiaDTO.quantidadePranchas = avisoDatable.Rows(0).Item("quantidadePranchas")
                estadiaDTO.terminal = avisoDatable.Rows(0).Item("terminal")
                estadiaDTO.tipoCarga = avisoDatable.Rows(0).Item("tipoCarga")


            Catch ex As Exception

            End Try
            Return estadiaDTO
        End Function



    End Class

End Namespace
