Imports MySql.Data.MySqlClient

Imports MonitorArquivos.MANIFESTO.DTO

Namespace MANIFESTO.DAL


    Public Class InformacoesGeraisManifestoDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionaInformacoesGeraisManifesto(ByVal num_manifesto As String) As DataTable

            Dim sql = "Select * from InformacoesGeraisManifesto where num_manifesto = @num_manifesto"
            Dim dt As New DataTable

            Dim con As New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@num_manifesto", num_manifesto)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)


                arq_erros.Close()

            Catch ex As Exception
                'MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

            End Try

            Return dt
        End Function


        Public Function insert(ByVal informacoes As InformacoesGeraisManifestoDTO) As Long
            Dim sql As String = "INSERT INTO `sigep2`.`man_informacoesgeraismanifesto` " &
                                "(`num_manifesto`, " &
                                "`ag_resp`, " &
                                "`ag_resp_origem`, " &
                                "`tipo_trafego`, " &
                                "`dt_op`, " &
                                "`n_IMO`, " &
                                "`n_vg_agencia`, " &
                                "`pais_emissao`, " &
                                "`porto_emissao`, " &
                                "`pais_carregamento`, " &
                                "`porto_carregamento`, " &
                                "`pais_descarregamento`, " &
                                "`Porto_descarregamento`, " &
                                "`terminal_carregamento`, " &
                                "`terminal_descarregamento`, " &
                                "`dt_encerramento_man`, " &
                                "`data_hora_atualizacao`, " &
                                "`num_duv`, " &
                                "`cod_empresa_nav`) " &
                                "VALUES " &
                                "( " &
                                "@num_manifesto , " &
                                "@ag_resp , " &
                                "@ag_resp_origem , " &
                                "@tipo_trafego , " &
                                "@dt_op , " &
                                "@n_IMO , " &
                                "@n_vg_agencia , " &
                                "@pais_emissao , " &
                                "@porto_emissao , " &
                                "@pais_carregamento , " &
                                "@porto_carregamento , " &
                                "@pais_descarregamento , " &
                                "@Porto_descarregamento , " &
                                "@terminal_carregamento , " &
                                "@terminal_descarregamento , " &
                                "@dt_encerramento_man , " &
                                "@data_hora_atualizacao , " &
                                "@num_duv , " &
                                "@cod_empresa_nav ); "


            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try


                cmd.Parameters.AddWithValue("@num_manifesto", informacoes.num_manifesto)
                cmd.Parameters.AddWithValue("@ag_resp", informacoes.ag_resp)
                cmd.Parameters.AddWithValue("@ag_resp_origem", informacoes.ag_resp_origem)
                cmd.Parameters.AddWithValue("@tipo_trafego", informacoes.tipo_trafego)
                cmd.Parameters.AddWithValue("@dt_op", informacoes.dt_op)
                cmd.Parameters.AddWithValue("@n_IMO", informacoes.n_IMO)
                cmd.Parameters.AddWithValue("@n_vg_agencia", informacoes.n_vg_agencia)
                cmd.Parameters.AddWithValue("@pais_emissao", informacoes.pais_emissao)
                cmd.Parameters.AddWithValue("@porto_emissao", informacoes.porto_emissao)
                cmd.Parameters.AddWithValue("@pais_carregamento", informacoes.pais_carregamento)
                cmd.Parameters.AddWithValue("@porto_carregamento", informacoes.porto_carregamento)
                cmd.Parameters.AddWithValue("@pais_descarregamento", informacoes.pais_descarregamento)
                cmd.Parameters.AddWithValue("@Porto_descarregamento", informacoes.Porto_descarregamento)
                cmd.Parameters.AddWithValue("@terminal_carregamento", informacoes.terminal_carregamento)
                cmd.Parameters.AddWithValue("@terminal_descarregamento", informacoes.terminal_descarregamento)
                cmd.Parameters.AddWithValue("@dt_encerramento_man", informacoes.dt_encerramento_man)
                cmd.Parameters.AddWithValue("@data_hora_atualizacao", informacoes.data_hora_atualizacao)
                cmd.Parameters.AddWithValue("@num_duv", informacoes.num_duv)
                cmd.Parameters.AddWithValue("@cod_empresa_nav", informacoes.cod_empresa_nav)


                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = cmd.LastInsertedId

                arq_erros.Close()

            Catch ex As Exception
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(cmd.CommandText)
                For i As Integer = 0 To cmd.Parameters.Count - 1
                    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                Next
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally
                cnn.Close()
            End Try
            Return id
        End Function


        Public Function delete(ByVal num_manifesto As String) As Integer
            Dim sql As String = "delete from InformacoesGeraisManifesto " &
                                " WHERE (num_manifesto = @num_manifesto)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try



                cmd.Parameters.AddWithValue("@num_manifesto", num_manifesto)

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = 1

                arq_erros.Close()

            Catch ex As Exception
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(cmd.CommandText)
                For i As Integer = 0 To cmd.Parameters.Count - 1
                    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                Next
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally
                cnn.Close()
            End Try

            Return id
        End Function


    End Class
End Namespace