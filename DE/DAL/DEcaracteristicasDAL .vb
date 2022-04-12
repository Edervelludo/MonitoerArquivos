
Imports MonitorArquivos.DE.DTO
Imports MySql.Data.MySqlClient

Namespace DE.DAL


    Public Class DEcaracteristicasDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionacaracteristicasnumeroIMO(ByVal IMO As String) As DataTable

            Dim sql = "Select * from de_caracteristicas where numeroIMO = @IMO"
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

        Public Function insert(ByVal embarcacao As DEcaracteristicasDTO) As String
            Dim sql As String = "INSERT INTO `arquivos_psp`.`de_caracteristicas`  " &
                                "(`numeroIMO`, " &
                                "`largura`, " &
                                "`comprimento`, " &
                                "`altura`, " &
                                "`caladoMaximo`, " &
                                "`caladoMinimo`, " &
                                "`capacidadeMaximaAgua`, " &
                                "`arqueacaoBruta`, " &
                                "`dwt`, " &
                                "`capacidadeAguaLastro`, " &
                                "`arqueacaoLiquida`, " &
                                "`velocidadeMaxima`, " &
                                "`capacidadeMaximaEfluentes`, " &
                                "`numeroCozinhas`, " &
                                "`numeroTanquesLastro`, " &
                                "`corCasco`, " &
                                "`tipoCasco`, " &
                                "`corSuperestrutura`, " &
                                "`tipoSuperestrutura`, " &
                                "`camarasRefrigeradas`, " &
                                "`numeroLeitosHospital`, " &
                                "`numeroPiscinaAdulto`, " &
                                "`numeroPiscinaInfantil`, " &
                                "`numeroRestaurantes`, " &
                                "`unidadesArCondicionado`, " &
                                "`banheirasHidromassagem`, " &
                                "`totalTanques`, " &
                                "`numeroPoroes`) " &
                                "VALUES " &
                                "(@numeroIMO ,  " &
                                "@largura , " &
                                "@comprimento , " &
                                "@altura , " &
                                "@caladoMaximo , " &
                                "@caladoMinimo , " &
                                "@capacidadeMaximaAgua , " &
                                "@arqueacaoBruta , " &
                                "@dwt , " &
                                "@capacidadeAguaLastro , " &
                                "@arqueacaoLiquida , " &
                                "@velocidadeMaxima , " &
                                "@capacidadeMaximaEfluentes , " &
                                "@numeroCozinhas , " &
                                "@numeroTanquesLastro , " &
                                "@corCasco , " &
                                "@tipoCasco , " &
                                "@corSuperestrutura , " &
                                "@tipoSuperestrutura , " &
                                "@camarasRefrigeradas , " &
                                "@numeroLeitosHospital , " &
                                "@numeroPiscinaAdulto , " &
                                "@numeroPiscinaInfantil , " &
                                "@numeroRestaurantes , " &
                                "@unidadesArCondicionado , " &
                                "@banheirasHidromassagem , " &
                                "@totalTanques , " &
                                "@numeroPoroes ); "


            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0


            Try


                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@numeroIMO", embarcacao.numeroIMO)

                cmd.Parameters.AddWithValue("@largura", embarcacao.largura)
                cmd.Parameters.AddWithValue("@comprimento", embarcacao.comprimento)
                cmd.Parameters.AddWithValue("@altura", embarcacao.altura)
                cmd.Parameters.AddWithValue("@caladoMaximo", embarcacao.caladoMaximo)
                cmd.Parameters.AddWithValue("@caladoMinimo", embarcacao.caladoMinimo)
                cmd.Parameters.AddWithValue("@capacidadeMaximaAgua", embarcacao.capacidadeMaximaAgua)
                cmd.Parameters.AddWithValue("@arqueacaoBruta", embarcacao.arqueacaoBruta)
                cmd.Parameters.AddWithValue("@dwt", embarcacao.dwt)
                cmd.Parameters.AddWithValue("@capacidadeAguaLastro", embarcacao.capacidadeAguaLastro)
                cmd.Parameters.AddWithValue("@arqueacaoLiquida", embarcacao.arqueacaoLiquida)
                cmd.Parameters.AddWithValue("@velocidadeMaxima", embarcacao.velocidadeMaxima)
                cmd.Parameters.AddWithValue("@capacidadeMaximaEfluentes", embarcacao.capacidadeMaximaEfluentes)
                cmd.Parameters.AddWithValue("@numeroCozinhas", embarcacao.numeroCozinhas)
                cmd.Parameters.AddWithValue("@numeroTanquesLastro", embarcacao.numeroTanquesLastro)
                cmd.Parameters.AddWithValue("@corCasco", embarcacao.corCasco)
                cmd.Parameters.AddWithValue("@tipoCasco", embarcacao.tipoCasco)
                cmd.Parameters.AddWithValue("@corSuperestrutura", embarcacao.corSuperestrutura)
                cmd.Parameters.AddWithValue("@tipoSuperestrutura", embarcacao.tipoSuperestrutura)
                cmd.Parameters.AddWithValue("@camarasRefrigeradas", embarcacao.camarasRefrigeradas)
                cmd.Parameters.AddWithValue("@numeroLeitosHospital", embarcacao.numeroLeitosHospital)
                cmd.Parameters.AddWithValue("@numeroPiscinaAdulto", embarcacao.numeroPiscinaAdulto)
                cmd.Parameters.AddWithValue("@numeroPiscinaInfantil", embarcacao.numeroPiscinaInfantil)
                cmd.Parameters.AddWithValue("@numeroRestaurantes", embarcacao.numeroRestaurantes)
                cmd.Parameters.AddWithValue("@unidadesArCondicionado", embarcacao.unidadesArCondicionado)
                cmd.Parameters.AddWithValue("@banheirasHidromassagem", embarcacao.banheirasHidromassagem)
                cmd.Parameters.AddWithValue("@totalTanques", embarcacao.totalTanques)
                cmd.Parameters.AddWithValue("@numeroPoroes", embarcacao.numeroPoroes)




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
            Return "Numero IMO : " & embarcacao.numeroIMO
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
            Dim sql As String = "delete from de_caracteristicas" &
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