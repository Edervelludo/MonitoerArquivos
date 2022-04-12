
Imports MonitorArquivos.DE.DAL
Imports MonitorArquivos.DE.DTO

Namespace DE.BLL
    Public Class fichaDadosEmbarcacaoBLL

        Public Function InserirfichaDadosEmbarcacao(ByVal fichaDadosEmbarcacao As fichaDadosEmbarcacaoDTO) As Integer

            Dim da As New fichaDadosEmbarcacaoDAL

            Dim id As Integer = 0

            Try

                da.delete(fichaDadosEmbarcacao.numeroDUV)
                da.insert(fichaDadosEmbarcacao)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function

        Friend Function AtualizacnpjAgenciaNavegacao(dUV As String, cnpjAgencia As String) As Integer

            Dim da As New fichaDadosEmbarcacaoDAL

            Dim id As Integer = 0

            Try



                id = da.updadecnpjAgenciaNavegacao(cnpjAgencia, dUV)

            Catch ex As Exception
                Throw ex
            End Try
            Return id

        End Function

        Friend Function AtualizaNumeroIMO(dUV As String, numeroIMO As String) As Integer
            Dim da As New fichaDadosEmbarcacaoDAL

            Dim id As Integer = 0

            Try



                id = da.updadenumeroIMO(numeroIMO, dUV)

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        'Public Function SelecionaEmbarcacaoIMO(ByVal IMO As String) As fichaDadosEmbarcacaoDTO

        '    Dim embDAL As New fichaDadosEmbarcacaoDAL
        '    Dim emDTO As New fichaDadosEmbarcacaoDTO

        '    Dim embarcacaoDatable As DataTable = embDAL.SelecionaEmbarcacaoIMO(IMO)

        '    ' tratamento para valores nulos na linha

        '    For i As Integer = 0 To embarcacaoDatable.Columns.Count - 1

        '        If embarcacaoDatable.Rows(0).Item(i) Is DBNull.Value Then
        '            embarcacaoDatable.Rows(0).Item(i) = ""
        '        End If
        '    Next



        '    Try
        '        emDTO.numeroDUV = embarcacaoDatable.Rows(0).Item("numeroDUV")
        '        emDTO.dataHoraPrevistaAtracacao = embarcacaoDatable.Rows(0).Item("numeroIMO")
        '        emDTO.dataHoraPrevistaDesatracacao = embarcacaoDatable.Rows(0).Item("inscricao")
        '        emDTO.cnpjAgenciaNavegacao = ""
        '        emDTO.numeroDUV = ""



        '    Catch ex As Exception

        '    End Try
        '    Return emDTO
        'End Function





    End Class

End Namespace
