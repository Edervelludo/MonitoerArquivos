Imports MySql.Data.MySqlClient

Imports MonitorArquivos.AACDRJ.DTO

Namespace AACDRJ.DAL


    Public Class ratificacaoOperadorDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionaratificacaoOperador(ByVal DUV As String) As DataTable

            Dim sql = "Select * from aacdrj_ratificacoesoperador where numeroDuv = @DUV"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            '  Try

            Dim cmd As New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@DUV", DUV)

            Dim da As New MySqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(dt)

            '     arq_erros.Close()

            '  Catch ex As Exception
            'MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
            'arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()

            '  Finally

            ' If con.State = ConnectionState.Open Then
            con.Close()
            'End If
            '  arq_erros.Close()
            '  End Try

            Return dt
        End Function

        Public Function insert(ByVal ratificacao As ratificacaoOperadorDTO) As String
            'Dim sql As String = "INSERT INTO `aacdrj_ratificacoesoperador` ( " &
            '                    "`numeroDuv` , " &
            '                    "`operador` , " &
            '                    "`nomeOperador` , " &
            '                    "`operacaoContratada` , " &
            '                    "`contratoCodesp` , " &
            '                    "`numeroContrato` , " &
            '                    "`qtdePeriodos` , " &
            '                    "`embalagem` , " &
            '                    "`mercadoria` , " &
            '                    "`peso` , " &
            '                    "`destinoProcedenciaCarga`  ," &
            '                    "`qtdeConteineres`  " &
            '                    ") " &
            '                    "VALUES ( " &
            '                    "@numeroDuv, @operador, @nomeOperador, @operacaoContratada, @contratoCodesp, " &
            '                    "@numeroContrato, @qtdePeriodos, @embalagem, @mercadoria, " &
            '                    "@peso, @destinoProcedenciaCarga , @qtdeConteineres)"


            Dim sql As String = "insert INTO `arquivos_psp`.`aacdrj_ratificacoesoperador` " &
                                "(`operador`, " &
                                "`nomeOperador`, " &
                                "`operacaoContratada`, " &
                                "`contratoCodesp`, " &
                                "`numeroContrato`, " &
                                "`qtdePeriodos`, " &
                                "`destinoProcedenciaCarga`, " &
                                "`embalagem`, " &
                                "`mercadoria`, " &
                                "`qtdeConteineres`, " &
                                "`peso`, " &
                                "`numeroDuv`) " &
                                "VALUES " &
                                "(@operador, " &
                                "@nomeOperador,  " &
                                "@operacaoContratada,  " &
                                "@contratoCodesp,  " &
                                "@numeroContrato,  " &
                                "@qtdePeriodos,  " &
                                "@destinoProcedenciaCarga,  " &
                                "@embalagem,  " &
                                "@mercadoria,  " &
                                "@qtdeConteineres,  " &
                                "@peso,  " &
                                "@numeroDuv) "




            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0

            ' Try

            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
            cmd.Parameters.AddWithValue("@numeroDuv", ratificacao.numeroDuv)
            cmd.Parameters.AddWithValue("@operador", ratificacao.operador)
            cmd.Parameters.AddWithValue("@nomeOperador", ratificacao.nomeOperador)
            cmd.Parameters.AddWithValue("@operacaoContratada", ratificacao.operacaoContratada)
            cmd.Parameters.AddWithValue("@contratoCodesp", ratificacao.contratoCodesp)
            cmd.Parameters.AddWithValue("@numeroContrato", ratificacao.numeroContrato)
            cmd.Parameters.AddWithValue("@qtdePeriodos", ratificacao.qtdePeriodos)
            cmd.Parameters.AddWithValue("@embalagem", ratificacao.embalagem)
            cmd.Parameters.AddWithValue("@mercadoria", ratificacao.mercadoria)
            cmd.Parameters.AddWithValue("@peso", ratificacao.peso)
            cmd.Parameters.AddWithValue("@destinoProcedenciaCarga", ratificacao.destinoProcedenciaCarga)
            cmd.Parameters.AddWithValue("@qtdeConteineres", ratificacao.qtdeConteineres)

            'Dim escreve As IO.StreamWriter
            'escreve = IO.File.CreateText("C:\MonitorArquivosPSP\erros.txt")

            'escreve.WriteLine(cmd.CommandText & cmd.Parameters.Item("@operador").Value & " " & cmd.Parameters.Item("@nomeOperador").Value & " " & cmd.Parameters.Item("@operacaoContratada").Value & " " & cmd.Parameters.Item("@numeroDuv").Value)
            'escreve.Close()
            'escreve.Dispose()




            'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"


            cnn.Open()
            cmd.ExecuteNonQuery()
            'id = cmd.LastInsertedId

            '    arq_erros.Close()
            '    arq_erros.Dispose()

            'Catch ex As Exception
            '    arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()
            '    arq_erros.Dispose()
            ' Finally
            cnn.Close()
            '    arq_erros.Close()
            '    arq_erros.Dispose()
            '  End Try
            Return ratificacao.nomeOperador & "-> CNPJ: " & ratificacao.operador
        End Function

        'Public Function updade(ByVal ficha As fichaavisoatracacaoDTO) As Integer
        '    Dim sql As String = "UPDATE aacdrj_fichaavisoatracacao " &
        '                        "SET " &
        '                        "numeroDuv = @numeroDuv , " &
        '                        "dataHoraSistema = @dataHoraSistema , " &
        '                        "portoEstadia = @portoEstadia , " &
        '                        "assumeEstadia = @assumeEstadia , " &
        '                        "dataHoraAssumirEstadia = @dataHoraAssumirEstadia , " &
        '                        "duracaoInferior24h = @duracaoInferior24h , " &
        '                        "dataHoraPrevistaAtracacao = @dataHoraPrevistaAtracacao , " &
        '                        "dataHoraPrevistaDesatracacao = @dataHoraPrevistaDesatracacao , " &
        '                        "ultimoPortoEscala = @ultimoPortoEscala , " &
        '                        "proximoPortoEscala = @proximoPortoEscala , " &
        '                        "cnpjArrendatario = @cnpjArrendatario  ," &
        '                        "datagravacao  = @datagravacao " &
        '                        " WHERE (numeroDuv = @numeroDuv)"

        '    Dim cnn As MySqlConnection = New MySqlConnection(strcon)
        '    ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        '    Dim id As Integer = 0

        '    'Try


        '    Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
        '    cmd.Parameters.AddWithValue("@numeroDuv", ficha.numeroDuv)
        '    cmd.Parameters.AddWithValue("@dataHoraSistema", ficha.dataHoraSistema)
        '    cmd.Parameters.AddWithValue("@portoEstadia", ficha.portoEstadia)
        '    cmd.Parameters.AddWithValue("@assumeEstadia", assume)
        '    cmd.Parameters.AddWithValue("@dataHoraAssumirEstadia", ficha.dataHoraAssumirEstadia)
        '    cmd.Parameters.AddWithValue("@duracaoInferior24h", duracao)
        '    cmd.Parameters.AddWithValue("@dataHoraPrevistaAtracacao", ficha.dataHoraPrevistaAtracacao)
        '    cmd.Parameters.AddWithValue("@dataHoraPrevistaDesatracacao", ficha.dataHoraPrevistaDesatracacao)
        '    cmd.Parameters.AddWithValue("@ultimoPortoEscala", ficha.ultimoPortoEscala)
        '    cmd.Parameters.AddWithValue("@proximoPortoEscala", ficha.proximoPortoEscala)
        '    cmd.Parameters.AddWithValue("@cnpjArrendatario", ficha.cnpjArrendatario)
        '    cmd.Parameters.AddWithValue("@datagravacao", ficha.datagravacao)




        '    cnn.Open()
        '    cmd.ExecuteNonQuery()
        '    id = 1

        '    '    arq_erros.Close()
        '    '    arq_erros.Dispose()
        '    'Catch ex As Exception
        '    '    arq_erros.WriteLine(Date.Now)
        '    '    arq_erros.WriteLine(ex.Message)
        '    '    arq_erros.WriteLine(ex.StackTrace)
        '    '    arq_erros.WriteLine(" ")
        '    '    arq_erros.Close()
        '    '    arq_erros.Dispose()
        '    'Finally
        '    cnn.Close()
        '    '    arq_erros.Close()
        '    '    arq_erros.Dispose()
        '    'End Try

        '    Return id
        'End Function


        Public Function delete(ByVal DUV As String) As Integer
            Dim sql As String = "delete from aacdrj_ratificacoesoperador" &
                                " WHERE (numeroDuv = @numeroDuv)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            '  Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            '           Try



            cmd.Parameters.AddWithValue("@numeroDuv", DUV)

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