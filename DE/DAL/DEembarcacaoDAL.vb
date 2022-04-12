
Imports MonitorArquivos.DE.DTO
Imports MySql.Data.MySqlClient

Namespace DE.DAL


    Public Class DEembarcacaoDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionaEmbarcacaonumeroIMO(ByVal IMO As String) As DataTable

            Dim sql = "Select * from de_embarcacao where numeroIMO = @IMO"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            '  Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@IMO", IMO)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)

                ' arq_erros.Close()

            Catch ex As Exception
                'MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
                'arq_erros.WriteLine(Date.Now)
                'arq_erros.WriteLine(ex.Message)
                'arq_erros.WriteLine(ex.StackTrace)
                'arq_erros.WriteLine(" ")
                'arq_erros.Close()

            Finally

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

            End Try

            Return dt
        End Function

        Public Function insert(ByVal embarcacao As DEembarcacaoDTO) As String
            Dim sql As String = "INSERT INTO `de_embarcacao` " &
                                "(`numeroIMO`, " &
                                "`nomeEmbarcacao`, " &
                                "`areaNavegacao`, " &
                                "`nomeSociedadeClassificacao`, " &
                                "`numeroInternacionalRegistro`, " &
                                "`portariaHomologacaoHeliponto`, " &
                                "`autonomiaRetencao`, " &
                                "`finalidade`, " &
                                "`tipoEmbarcacao`, " &
                                "`dataCertificadoRegistro`, " &
                                "`numeroProvisorioRegistro`, " &
                                "`numeroPRPM`, " &
                                "`numeroTie`, " &
                                "`numeroPreps`, " &
                                "`dataAdesaoPreps`, " &
                                "`inscricao`, " &
                                "`estadoBandeira`, " &
                                "`alturaBordaLivre`, " &
                                "`capacidadeEquipamentoBordaLivre`, " &
                                "`anoFabricacao`) " &
                                "VALUES " &
                                "(@numeroIMO , " &
                                "@nomeEmbarcacao , " &
                                "@areaNavegacao , " &
                                "@nomeSociedadeClassificacao , " &
                                "@numeroInternacionalRegistro , " &
                                "@portariaHomologacaoHeliponto , " &
                                "@autonomiaRetencao , " &
                                "@finalidade , " &
                                "@tipoEmbarcacao , " &
                                "@dataCertificadoRegistro , " &
                                "@numeroProvisorioRegistro , " &
                                "@numeroPRPM , " &
                                "@numeroTie , " &
                                "@numeroPreps , " &
                                "@dataAdesaoPreps , " &
                                "@inscricao , " &
                                "@estadoBandeira , " &
                                "@alturaBordaLivre , " &
                                "@capacidadeEquipamentoBordaLivre , " &
                                "@anoFabricacao ); "


            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0


            Try


                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@numeroIMO", embarcacao.numeroIMO)
                cmd.Parameters.AddWithValue("@nomeEmbarcacao", embarcacao.nomeEmbarcacao)
                cmd.Parameters.AddWithValue("@areaNavegacao", embarcacao.areaNavegacao)
                cmd.Parameters.AddWithValue("@nomeSociedadeClassificacao", embarcacao.nomeSociedadeClassificacao)
                cmd.Parameters.AddWithValue("@numeroInternacionalRegistro", embarcacao.numeroInternacionalRegistro)
                cmd.Parameters.AddWithValue("@portariaHomologacaoHeliponto", embarcacao.portariaHomologacaoHeliponto)
                cmd.Parameters.AddWithValue("@autonomiaRetencao", embarcacao.autonomiaRetencao)
                cmd.Parameters.AddWithValue("@finalidade", embarcacao.finalidade)
                cmd.Parameters.AddWithValue("@tipoEmbarcacao", embarcacao.tipoEmbarcacao)
                cmd.Parameters.AddWithValue("@dataCertificadoRegistro", embarcacao.dataCertificadoRegistro)
                cmd.Parameters.AddWithValue("@numeroProvisorioRegistro", embarcacao.numeroProvisorioRegistro)
                cmd.Parameters.AddWithValue("@numeroPRPM", embarcacao.numeroPRPM)
                cmd.Parameters.AddWithValue("@numeroTie", embarcacao.numeroTie)
                cmd.Parameters.AddWithValue("@numeroPreps", embarcacao.numeroPreps)
                cmd.Parameters.AddWithValue("@dataAdesaoPreps", embarcacao.dataAdesaoPreps)
                cmd.Parameters.AddWithValue("@inscricao", embarcacao.inscricao)
                cmd.Parameters.AddWithValue("@estadoBandeira", embarcacao.estadoBandeira)
                cmd.Parameters.AddWithValue("@alturaBordaLivre", embarcacao.alturaBordaLivre)
                cmd.Parameters.AddWithValue("@capacidadeEquipamentoBordaLivre", embarcacao.capacidadeEquipamentoBordaLivre)
                cmd.Parameters.AddWithValue("@anoFabricacao", embarcacao.anoFabricacao)



                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = cmd.LastInsertedId

                ' arq_erros.Close()

            Catch ex As Exception
                'arq_erros.WriteLine(Date.Now)
                'arq_erros.WriteLine(ex.Message)
                'arq_erros.WriteLine(ex.StackTrace)
                'arq_erros.WriteLine(" ")
                'arq_erros.Close()

            Finally
                cnn.Close()
            End Try
            Return embarcacao.nomeEmbarcacao & "-> IMO: " & embarcacao.numeroIMO
        End Function

        'Public Function updade(ByVal agencia As agenteMaritimoDTO) As Integer
        '    Dim sql As String = "UPDATE agenteagentemaritimo " & _
        '                        "SET " & _
        '                        "nomeAgencia = @nomeAgencia , " & _
        '                        "cnpjAgenciaNavegacao = @cnpjAgenciaNavegacao  " & _
        '                        " WHERE (cnpjAgenciaNavegacao = @cnpjAgenciaNavegacao)"

        '    Dim cnn As MySqlConnection = New MySqlConnection(strcon)
        '    Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        '    Dim id As Integer = 0

        '    Try


        '        Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
        '        cmd.Parameters.AddWithValue("@nomeAgencia", agencia.nomeAgencia)
        '        cmd.Parameters.AddWithValue("@cnpjAgenciaNavegacao", agencia.cnpjAgenciaNavegacao)






        '        cnn.Open()
        '        cmd.ExecuteNonQuery()
        '        id = 1

        '        arq_erros.Close()

        '    Catch ex As Exception
        '        arq_erros.WriteLine(Date.Now)
        '        arq_erros.WriteLine(ex.Message)
        '        arq_erros.WriteLine(ex.StackTrace)
        '        arq_erros.WriteLine(" ")
        '        arq_erros.Close()

        '    Finally
        '        cnn.Close()
        '    End Try

        '    Return id
        'End Function

        Public Function delete(ByVal IMO As String) As Integer
            Dim sql As String = "delete from de_embarcacao" &
                                " WHERE (numeroIMO = @numeroIMO)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            '  Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            '           Try



            cmd.Parameters.AddWithValue("@numeroIMO", IMO)

            cnn.Open()
            cmd.ExecuteNonQuery()
            id = 1

            '     arq_erros.Close()

            '   Catch ex As Exception
            'arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(cmd.CommandText)
            '    For i As Integer = 0 To cmd.Parameters.Count - 1
            '        arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
            '    Next
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()

            ' Finally
            cnn.Close()
            'End Try

            Return id
        End Function

    End Class
End Namespace