
Imports MonitorArquivos.AACDRJ.DAL
Imports MonitorArquivos.AACDRJ.DTO

Namespace AACDRJ.BLL
    Public Class fichaAvisoAtracacaoBLL

        Public Function InserirfichaAvisoAtracacao(ByVal fichaAvisoAtracacao As fichaavisoatracacaoDTO) As Integer

            Dim da As New fichaAvisoAtracacaoDAL
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0

            ' Try
            If da.SelecionafichaAvisoAtracacaoDUV(fichaAvisoAtracacao.numeroDuv).Rows.Count <= 0 Then
                    id = da.insert(fichaAvisoAtracacao)
                Else
                    id = da.updade(fichaAvisoAtracacao)
                End If



            'Catch ex As Exception
            '    arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()
            '    arq_erros.Dispose()
            'Finally

            '    arq_erros.Close()
            '    arq_erros.Dispose()
            'End Try

            Return id
        End Function



        Public Function SelecionafichaAvisoAtracacaoDUV(ByVal DUV As String) As fichaavisoatracacaoDTO

            Dim fichaDAL As New fichaAvisoAtracacaoDAL
            Dim fichaDTO As New fichaavisoatracacaoDTO
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim fichaAvisoAtracacaoDatable As DataTable = fichaDAL.SelecionafichaAvisoAtracacaoDUV(DUV)





            ' Try
            fichaDTO.numeroDuv = fichaAvisoAtracacaoDatable.Rows(0).Item("numeroDuv")
                fichaDTO.dataHoraSistema = fichaAvisoAtracacaoDatable.Rows(0).Item("dataHoraSistema")
                fichaDTO.portoEstadia = fichaAvisoAtracacaoDatable.Rows(0).Item("portoEstadia")
                fichaDTO.assumeEstadia = fichaAvisoAtracacaoDatable.Rows(0).Item("assumeEstadia")
                fichaDTO.dataHoraAssumirEstadia = fichaAvisoAtracacaoDatable.Rows(0).Item("dataHoraAssumirEstadia")
                fichaDTO.duracaoInferior24h = fichaAvisoAtracacaoDatable.Rows(0).Item("duracaoInferior24h")
                fichaDTO.dataHoraPrevistaAtracacao = fichaAvisoAtracacaoDatable.Rows(0).Item("dataHoraPrevistaAtracacao")
                fichaDTO.dataHoraPrevistaDesatracacao = fichaAvisoAtracacaoDatable.Rows(0).Item("dataHoraPrevistaDesatracacao")
                fichaDTO.ultimoPortoEscala = fichaAvisoAtracacaoDatable.Rows(0).Item("ultimoPortoEscala")
                fichaDTO.proximoPortoEscala = fichaAvisoAtracacaoDatable.Rows(0).Item("proximoPortoEscala")

                fichaDTO.cnpjArrendatario = fichaAvisoAtracacaoDatable.Rows(0).Item("cnpjArrendatario")
                fichaDTO.datagravacao = fichaAvisoAtracacaoDatable.Rows(0).Item("datagravacao")


                'Catch ex As Exception
                'arq_erros.WriteLine(Date.Now)
                'arq_erros.WriteLine(ex.Message)
                'arq_erros.WriteLine(ex.StackTrace)
                'arq_erros.WriteLine(" ")
                'arq_erros.Close()
                'arq_erros.Dispose()
                ' End Try
                Return fichaDTO
        End Function



    End Class

End Namespace
