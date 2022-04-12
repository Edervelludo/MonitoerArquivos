Imports MySql.Data.MySqlClient

Imports MonitorArquivos.AACDRJ.DTO

Namespace AACDRJ.DAL


    Public Class fichaAvisoAtracacaoDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionafichaAvisoAtracacaoDUV(ByVal DUV As String) As DataTable

            Dim sql = "Select * from aacdrj_fichaavisoatracacao where numeroDuv = @DUV"
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

            If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            '  arq_erros.Close()
            '  End Try

            Return dt
        End Function

        Public Function insert(ByVal ficha As fichaavisoatracacaoDTO) As Integer
            Dim sql As String = "INSERT INTO `arquivos_psp`.`aacdrj_fichaavisoatracacao` ( " &
                                "`numeroDuv` , " &
                                "`dataHoraSistema` , " &
                                "`portoEstadia` , " &
                                "`assumeEstadia` , " &
                                "`dataHoraAssumirEstadia` , " &
                                "`duracaoInferior24h` , " &
                                "`dataHoraPrevistaAtracacao` , " &
                                "`dataHoraPrevistaDesatracacao` , " &
                                "`ultimoPortoEscala` , " &
                                "`proximoPortoEscala` , " &
                                "`cnpjArrendatario`  ," &
                                "`datagravacao`  " &
                                ") " &
                                "VALUES ( " &
                                "@numeroDuv, @dataHoraSistema, @portoEstadia, @assumeEstadia, @dataHoraAssumirEstadia , " &
                                "@duracaoInferior24h, @dataHoraPrevistaAtracacao, @dataHoraPrevistaDesatracacao, @ultimoPortoEscala, " &
                                "@proximoPortoEscala, @cnpjArrendatario , @datagravacao)"


            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0


            '            Try


            Dim assume As Integer = 0
                Dim duracao As Integer = 0

                If ficha.assumeEstadia Then
                    assume = 1
                Else
                    assume = 0
                End If

                If ficha.duracaoInferior24h Then
                    duracao = 1
                Else
                    duracao = 0
                End If


                Dim dataHoraAssumirEstadia
                If ficha.dataHoraAssumirEstadia = Nothing Then
                    dataHoraAssumirEstadia = ""
                Else
                    dataHoraAssumirEstadia = ficha.dataHoraAssumirEstadia
                End If

                Dim dataHoraPrevistaDesatracacao
                If ficha.dataHoraPrevistaDesatracacao = Nothing Then
                    dataHoraPrevistaDesatracacao = ""
                Else
                    dataHoraPrevistaDesatracacao = ficha.dataHoraPrevistaDesatracacao
                End If


                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@numeroDuv", ficha.numeroDuv)
                cmd.Parameters.AddWithValue("@dataHoraSistema", ficha.dataHoraSistema)
                cmd.Parameters.AddWithValue("@portoEstadia", ficha.portoEstadia)
                cmd.Parameters.AddWithValue("@assumeEstadia", ficha.assumeEstadia)
                cmd.Parameters.AddWithValue("@dataHoraAssumirEstadia", ficha.dataHoraAssumirEstadia)
                cmd.Parameters.AddWithValue("@duracaoInferior24h", ficha.duracaoInferior24h)
                cmd.Parameters.AddWithValue("@dataHoraPrevistaAtracacao", ficha.dataHoraPrevistaAtracacao)
                cmd.Parameters.AddWithValue("@dataHoraPrevistaDesatracacao", ficha.dataHoraPrevistaDesatracacao)
                cmd.Parameters.AddWithValue("@ultimoPortoEscala", ficha.ultimoPortoEscala)
                cmd.Parameters.AddWithValue("@proximoPortoEscala", ficha.proximoPortoEscala)
                cmd.Parameters.AddWithValue("@cnpjArrendatario", ficha.cnpjArrendatario)
                cmd.Parameters.AddWithValue("@datagravacao", ficha.datagravacao)



                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = cmd.LastInsertedId

            '    arq_erros.Close()
            '    arq_erros.Dispose()

            'Catch ex As Exception
            '    arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()
            '    arq_erros.Dispose()
            'Finally
            cnn.Close()
            '    arq_erros.Close()
            '    arq_erros.Dispose()
            'End Try
            Return id
        End Function

        Public Function updade(ByVal ficha As fichaavisoatracacaoDTO) As Integer
            Dim sql As String = "UPDATE aacdrj_fichaavisoatracacao " &
                                "SET " &
                                "numeroDuv = @numeroDuv , " &
                                "dataHoraSistema = @dataHoraSistema , " &
                                "portoEstadia = @portoEstadia , " &
                                "assumeEstadia = @assumeEstadia , " &
                                "dataHoraAssumirEstadia = @dataHoraAssumirEstadia , " &
                                "duracaoInferior24h = @duracaoInferior24h , " &
                                "dataHoraPrevistaAtracacao = @dataHoraPrevistaAtracacao , " &
                                "dataHoraPrevistaDesatracacao = @dataHoraPrevistaDesatracacao , " &
                                "ultimoPortoEscala = @ultimoPortoEscala , " &
                                "proximoPortoEscala = @proximoPortoEscala , " &
                                "cnpjArrendatario = @cnpjArrendatario  ," &
                                "datagravacao  = @datagravacao " &
                                " WHERE (numeroDuv = @numeroDuv)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0

            'Try

            Dim assume As Integer = 0
                Dim duracao As Integer = 0

                If ficha.assumeEstadia Then
                    assume = 1
                Else
                    assume = 0
                End If

                If ficha.duracaoInferior24h Then
                    duracao = 1
                Else
                    duracao = 0
                End If

                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@numeroDuv", ficha.numeroDuv)
                cmd.Parameters.AddWithValue("@dataHoraSistema", ficha.dataHoraSistema)
                cmd.Parameters.AddWithValue("@portoEstadia", ficha.portoEstadia)
                cmd.Parameters.AddWithValue("@assumeEstadia", assume)
                cmd.Parameters.AddWithValue("@dataHoraAssumirEstadia", ficha.dataHoraAssumirEstadia)
                cmd.Parameters.AddWithValue("@duracaoInferior24h", duracao)
                cmd.Parameters.AddWithValue("@dataHoraPrevistaAtracacao", ficha.dataHoraPrevistaAtracacao)
                cmd.Parameters.AddWithValue("@dataHoraPrevistaDesatracacao", ficha.dataHoraPrevistaDesatracacao)
                cmd.Parameters.AddWithValue("@ultimoPortoEscala", ficha.ultimoPortoEscala)
                cmd.Parameters.AddWithValue("@proximoPortoEscala", ficha.proximoPortoEscala)
                cmd.Parameters.AddWithValue("@cnpjArrendatario", ficha.cnpjArrendatario)
                cmd.Parameters.AddWithValue("@datagravacao", ficha.datagravacao)





                cnn.Open()
                cmd.ExecuteNonQuery()
                id = 1

            '    arq_erros.Close()
            '    arq_erros.Dispose()
            'Catch ex As Exception
            '    arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()
            '    arq_erros.Dispose()
            'Finally
            cnn.Close()
            '    arq_erros.Close()
            '    arq_erros.Dispose()
            'End Try

            Return id
        End Function


    End Class
End Namespace