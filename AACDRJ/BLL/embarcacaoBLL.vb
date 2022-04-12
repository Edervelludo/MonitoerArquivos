
Imports MonitorArquivos.AACDRJ.DAL
Imports MonitorArquivos.AACDRJ.DTO

Namespace AACDRJ.BLL
    Public Class embarcacaoBLL

        Public Function InserirEmbarcacao(ByVal embacacacao As embarcacaoDTO) As Integer

            Dim da As New embarcacaoDAL

            Dim id As Integer = 0

            Try

                da.delete(embacacacao.numeroDUV)
                da.insert(embacacacao)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        Public Function SelecionaEmbarcacaoIMO(ByVal IMO As String) As embarcacaoDTO

            Dim embDAL As New embarcacaoDAL
            Dim emDTO As New embarcacaoDTO

            Dim embarcacaoDatable As DataTable = embDAL.SelecionaEmbarcacaoIMO(IMO)

            ' tratamento para valores nulos na linha

            For i As Integer = 0 To embarcacaoDatable.Columns.Count - 1

                If embarcacaoDatable.Rows(0).Item(i) Is DBNull.Value Then
                    embarcacaoDatable.Rows(0).Item(i) = ""
                End If
            Next



            Try
                emDTO.numeroDUV = embarcacaoDatable.Rows(0).Item("numeroDUV")
                emDTO.numeroIMO = embarcacaoDatable.Rows(0).Item("numeroIMO")
                emDTO.inscricao = embarcacaoDatable.Rows(0).Item("inscricao")
                emDTO.nomeEmbarcacao = embarcacaoDatable.Rows(0).Item("nomeEmbarcacao")
                emDTO.estadoBandeira = embarcacaoDatable.Rows(0).Item("estadoBandeira")
                emDTO.caladoMaximo = embarcacaoDatable.Rows(0).Item("caladoMaximo")
                emDTO.caladoMaximo = embarcacaoDatable.Rows(0).Item("caladoEntradaProa")
                emDTO.caladoMaximo = embarcacaoDatable.Rows(0).Item("caladoEntradaPopa")
                emDTO.caladoMaximo = embarcacaoDatable.Rows(0).Item("caladoSaidaProa")
                emDTO.caladoMaximo = embarcacaoDatable.Rows(0).Item("caladoSaidaPopa")



            Catch ex As Exception

            End Try
            Return emDTO
        End Function



    End Class

End Namespace
