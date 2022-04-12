Imports MySql.Data.MySqlClient

Imports MonitorArquivos.CHEGADASAIDA.DTO

Namespace CHEGADASAIDA.DAL


    Public Class chegadasaidadadosDuvDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionachegadasaidadadosDuv(ByVal DUV As String) As DataTable

            Dim sql = "Select * from chegadasaida_chegadasaidadadosduv where numeroDuv = @DUV"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@DUV", DUV)

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

        Public Function insert(ByVal chagadasaidadados As chegadasaidadadosDuvDTO) As String
            Dim sql As String = "INSERT INTO `chegadasaida_chegadasaidadadosduv` ( " &
                                "`numeroduv` , " &
                                "`porto` , " &
                                "`NumeroImo` , " &
                                "`NumeroInscricao` , " &
                                "`NomeEmbarcacao` , " &
                                "`Bandeira` , " &
                                "`BandeiraCodigo` , " &
                                "`TipoEmbarcacao` , " &
                                "`indicativodechamadaIRIN` , " &
                                "`ArqueacaoBruta` , " &
                                "`nomeSociedadeClassificadora` , " &
                                "`paisescala` , " &
                                "`paisescalaCodigo` , " &
                                "`portosescala` , " &
                                "`dataescala` , " &
                                "`agencia` , " &
                                "`cnpjgencia` , " &
                                "`logradouro` , " &
                                "`bairro` , " &
                                "`cidade` , " &
                                "`UF` , " &
                                "`cep` , " &
                                "`telefone` , " &
                                "`email` , " &
                                "`operadores` , " &
                                "`cnpjOperadores`  " &
                                ") " &
                                "VALUES ( " &
                                "@numeroDuv, @porto, @NumeroImo, @NumeroInscricao, @NomeEmbarcacao, 
                                @Bandeira, @BandeiraCodigo, @TipoEmbarcacao, @indicativodechamadaIRIN, @ArqueacaoBruta, 
                                @nomeSociedadeClassificadora, @paisescala, @paisescalaCodigo,  @portosescala, @dataescala, 
                                @agencia, @cnpjgencia, @logradouro, @bairro, @cidade, @UF, @cep, @telefone, @email, 
                                @operadores, @cnpjOperadores)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0


            Try


                'Dim perigosa As Integer = 0

                'If aviso.cargaPerigosa Then
                '    perigosa = 1
                'Else
                '    perigosa = 0
                'End If


                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@numeroduv", chagadasaidadados.numeroduv)
                cmd.Parameters.AddWithValue("@porto", chagadasaidadados.porto)
                cmd.Parameters.AddWithValue("@NumeroImo", chagadasaidadados.NumeroImo)
                cmd.Parameters.AddWithValue("@NumeroInscricao", chagadasaidadados.NumeroInscricao)
                cmd.Parameters.AddWithValue("@NomeEmbarcacao", chagadasaidadados.NomeEmbarcacao)
                cmd.Parameters.AddWithValue("@Bandeira", chagadasaidadados.Bandeira)
                cmd.Parameters.AddWithValue("@BandeiraCodigo", chagadasaidadados.BandeiraCodigo)
                cmd.Parameters.AddWithValue("@TipoEmbarcacao", chagadasaidadados.TipoEmbarcacao)
                cmd.Parameters.AddWithValue("@indicativodechamadaIRIN", chagadasaidadados.indicativodechamadaIRIN)
                cmd.Parameters.AddWithValue("@ArqueacaoBruta", chagadasaidadados.ArqueacaoBruta)
                cmd.Parameters.AddWithValue("@nomeSociedadeClassificadora", chagadasaidadados.nomeSociedadeClassificadora)
                cmd.Parameters.AddWithValue("@paisescala", chagadasaidadados.paisescala)
                cmd.Parameters.AddWithValue("@paisescalaCodigo", chagadasaidadados.paisescalaCodigo)
                cmd.Parameters.AddWithValue("@portosescala", chagadasaidadados.portosescala)
                cmd.Parameters.AddWithValue("@dataescala", chagadasaidadados.dataescala)
                cmd.Parameters.AddWithValue("@agencia", chagadasaidadados.agencia)
                cmd.Parameters.AddWithValue("@cnpjgencia", chagadasaidadados.cnpjgencia)
                cmd.Parameters.AddWithValue("@logradouro", chagadasaidadados.logradouro)
                cmd.Parameters.AddWithValue("@bairro", chagadasaidadados.bairro)
                cmd.Parameters.AddWithValue("@cidade", chagadasaidadados.cidade)
                cmd.Parameters.AddWithValue("@UF", chagadasaidadados.UF)
                cmd.Parameters.AddWithValue("@cep", chagadasaidadados.cep)
                cmd.Parameters.AddWithValue("@telefone", chagadasaidadados.telefone)
                cmd.Parameters.AddWithValue("@email", chagadasaidadados.email)
                cmd.Parameters.AddWithValue("@operadores", chagadasaidadados.operadores)
                cmd.Parameters.AddWithValue("@cnpjOperadores", chagadasaidadados.cnpjOperadores)



                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = cmd.LastInsertedId

                '   arq_erros.Close()

            Catch ex As Exception
                '    arq_erros.WriteLine(Date.Now)
                '    arq_erros.WriteLine(ex.Message)
                '    arq_erros.WriteLine(ex.StackTrace)
                '    arq_erros.WriteLine(" ")
                '    arq_erros.Close()

            Finally
                cnn.Close()
            End Try
            Return id
        End Function

        'Public Function updade(ByVal aviso As avisoatracacaoDTO) As Integer
        '    Dim sql As String = "UPDATE avisoatracacao " & _
        '                        "SET " & _
        '                        "numeroDuv = @numeroDuv , " & _
        '                        "dataHoraEsperada = @dataHoraEsperada , " & _
        '                        "cargaPerigosa = @cargaPerigosa , " & _
        '                        "qtdeConteineres = @qtdeConteineres , " & _
        '                        "pesoCarga = @pesoCarga  " & _
        '                        " WHERE (numeroDuv = @numeroDuv)"

        '    Dim cnn As MySqlConnection = New MySqlConnection(strcon)
        '    Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        '    Dim id As Integer = 0
        '    Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
        '    Dim perigosa As Integer = 0

        '    Try

        '        If aviso.cargaPerigosa Then
        '            perigosa = 1
        '        Else
        '            perigosa = 0
        '        End If


        '        cmd.Parameters.AddWithValue("@numeroDuv", aviso.numeroDuv)
        '        cmd.Parameters.AddWithValue("@dataHoraEsperada", aviso.dataHoraEsperada)
        '        cmd.Parameters.AddWithValue("@cargaPerigosa", perigosa)
        '        cmd.Parameters.AddWithValue("@qtdeConteineres", aviso.qtdeConteineres)
        '        cmd.Parameters.AddWithValue("@pesoCarga", aviso.pesoCarga)





        '        cnn.Open()
        '        cmd.ExecuteNonQuery()
        '        id = 1

        '        arq_erros.Close()

        '    Catch ex As Exception
        '        arq_erros.WriteLine(Date.Now)
        '        arq_erros.WriteLine(ex.Message)
        '        arq_erros.WriteLine(ex.StackTrace)
        '        arq_erros.WriteLine(cmd.CommandText)
        '        For i As Integer = 0 To cmd.Parameters.Count - 1
        '            arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
        '        Next
        '        arq_erros.WriteLine(" ")
        '        arq_erros.Close()

        '    Finally
        '        cnn.Close()
        '    End Try

        '    Return id
        ' End Function

        Public Function delete(ByVal DUV As String) As Integer
            Dim sql As String = "delete from chegadasaida_chegadasaidadadosduv" &
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