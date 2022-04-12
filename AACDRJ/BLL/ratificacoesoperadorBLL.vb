
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class ratificacaooperadorBLL

        Public Function Inserirratificacaooperador(ByVal ratificacaooperador As ratificacaoOperadorDTO) As Integer

            Dim da As New ratificacaoOperadorDAL

            Dim id As Integer = 0

            ' Try

            da.delete(ratificacaooperador.numeroDuv)
                da.insert(ratificacaooperador)



                id = 1

            '  Catch ex As Exception
            '  Throw ex
            '  End Try
            Return id
        End Function




        Public Function SelecionaratificacaooperadorDUV(ByVal DUV As String) As ratificacaoOperadorDTO()

            Dim ratificacaoDAL As New ratificacaoOperadorDAL
            Dim ratificacaoDTO As New ratificacaoOperadorDTO

            Dim ratificacaoDatatable As DataTable = ratificacaoDAL.SelecionaratificacaoOperador(DUV)

            Dim i As Integer = 0

            Dim ratificacoesDTO(ratificacaoDatatable.Rows.Count) As ratificacaoOperadorDTO



            Try

                For Each linha As DataRow In ratificacaoDatatable.Rows


                    ratificacaoDTO.numeroDuv = linha.Item("numeroDuv")
                    ratificacaoDTO.contratoCodesp = linha.Item("contratoCodesp")
                    ratificacaoDTO.destinoProcedenciaCarga = linha.Item("destinoProcedenciaCarga")
                    ratificacaoDTO.embalagem = linha.Item("embalagem")
                    ratificacaoDTO.mercadoria = linha.Item("mercadoria")
                    ratificacaoDTO.nomeOperador = linha.Item("nomeOperador")
                    ratificacaoDTO.numeroContrato = linha.Item("numeroContrato")
                    ratificacaoDTO.operacaoContratada = linha.Item("operacaoContratada")
                    ratificacaoDTO.operador = linha.Item("operador")
                    ratificacaoDTO.qtdeConteineres = linha.Item("qtdeConteineres")
                    ratificacaoDTO.qtdePeriodos = linha.Item("qtdePeriodos")
                    ratificacaoDTO.peso = linha.Item("embalagem")


                    ratificacoesDTO(i) = ratificacaoDTO
                    i = i + 1
                Next



            Catch ex As Exception

            End Try
            Return ratificacoesDTO
        End Function



    End Class

End Namespace
