Imports MonitorArquivos.MANIFESTO.DAL
Imports MonitorArquivos.MANIFESTO.DTO

Namespace MANIFESTO.BLL
    Public Class InformacoesGeraisManifestoBLL

        Public Function InserirInformacoesGeraisManifesto(ByVal informacoes As InformacoesGeraisManifestoDTO) As Integer

            Dim da As New InformacoesGeraisManifestoDAL

            Dim id As Integer = 0

            Try

                'da.delete(locat.id_loc_atrac)
                da.insert(informacoes)
                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        Public Function SelecionaInformacoesGeraisManifesto(ByVal num_manifesto As String) As InformacoesGeraisManifestoDTO()

            Dim informacoesDAL As New InformacoesGeraisManifestoDAL
            Dim informacoesDTO As New InformacoesGeraisManifestoDTO


            Dim informacoesDatable As DataTable = informacoesDAL.SelecionaInformacoesGeraisManifesto(num_manifesto)
            Dim i As Integer = 0

            Dim informacoesDTOs(informacoesDatable.Rows.Count) As InformacoesGeraisManifestoDTO


            Try

                For Each linha As DataRow In informacoesDatable.Rows

                    informacoesDTO.id_InfoGeraisMan = linha.Item("id_inforgeraisman")
                    informacoesDTO.num_manifesto = linha.Item("num_manifesto")
                    informacoesDTO.ag_resp = linha.Item("ag_resp")
                    informacoesDTO.ag_resp_origem = linha.Item("ag_resp_origem")
                    informacoesDTO.cod_empresa_nav = linha.Item("cod_empresa_nav")
                    informacoesDTO.tipo_trafego = linha.Item("tipo_trafego")
                    informacoesDTO.dt_op = linha.Item("dt_op")
                    informacoesDTO.n_IMO = linha.Item("n_IMO")
                    informacoesDTO.n_vg_agencia = linha.Item("n_vg_agencia")
                    informacoesDTO.pais_emissao = linha.Item("pais_emissao")
                    informacoesDTO.porto_emissao = linha.Item("porto_emissao")
                    informacoesDTO.pais_carregamento = linha.Item("pais_carregamento")
                    informacoesDTO.porto_carregamento = linha.Item("porto_carregamento")
                    informacoesDTO.pais_descarregamento = linha.Item("pais_descarregamento")
                    informacoesDTO.terminal_carregamento = linha.Item("terminal_carregamento")
                    informacoesDTO.dt_encerramento_man = linha.Item("dt_encerramento_man")
                    informacoesDTO.data_hora_atualizacao = linha.Item("data_hora_atualizacao")
                    informacoesDTO.pais_descarregamento = linha.Item("pais_descarregamento")
                    informacoesDTO.terminal_descarregamento = linha.Item("terminal_descarregamento")
                    informacoesDTO.Porto_descarregamento = linha.Item("Porto_descarregamento")
                    informacoesDTO.dt_encerramento_man = linha.Item("dt_encerramento_man")
                    informacoesDTO.data_hora_atualizacao = linha.Item("data_hora_atualizacao")
                    informacoesDTO.num_duv = linha.Item("num_duv")



                    informacoesDTOs(i) = informacoesDTO
                    i = i + 1
                Next





            Catch ex As Exception

            End Try
            Return informacoesDTOs
        End Function

        Sub delete(num_manifesto As String)
            Dim locatDAL As New InformacoesGeraisManifestoDAL



            Try

                locatDAL.delete(num_manifesto)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub



    End Class

End Namespace
