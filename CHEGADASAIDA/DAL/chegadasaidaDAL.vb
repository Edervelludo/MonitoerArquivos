Imports MySql.Data.MySqlClient

Imports MonitorArquivos.CHEGADASAIDA.DTO

Namespace CHEGADASAIDA.DAL


    Public Class chegadasaidaDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionachegadasaidaDUV(ByVal DUV As String) As DataTable

            Dim sql = "Select * from chegadasaida_chegadasaida where numeroDuv = @DUV"
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

        Public Function insert(ByVal chagadasaida As chegadasaidaDTO) As String
            Dim sql As String = "INSERT INTO `chegadasaida_chegadasaida`  " &
                                "(`numeroDuv`, " &
                                "`id`, " &
                                "`ProximoId`, " &
                                "`movimentacao`, " &
                                "`acao`, " &
                                "`dataHora`, " &
                                "`motivo`, " &
                                "`SituacaoAtual`, " &
                                "`motivoCancelamento`, " &
                                "`caladoVante`, " &
                                "`caladoRe`, " &
                                "`manobraPratico`, " &
                                "`motivoNaoManobraPratico`, " &
                                "`observacao`, " &
                                "`dataHoraRegistro`, " &
                                "`Responsavel`, " &
                                "`PerfilResponsavel`, " &
                                "`operacao`, " &
                                "`local`, " &
                                "`distanciaVante`, " &
                                "`distanciaRe`) " &
                                "VALUES " &
                                "(@numeroDuv, " &
                                "@id, " &
                                "@ProximoId, " &
                                "@movimentacao, " &
                                "@acao, " &
                                "@dataHora, " &
                                "@motivo, " &
                                "@SituacaoAtual, " &
                                "@motivoCancelamento, " &
                                "@caladoVante, " &
                                "@caladoRe, " &
                                "@manobraPratico, " &
                                "@motivoNaoManobraPratico, " &
                                "@observacao, " &
                                "@dataHoraRegistro, " &
                                "@Responsavel, " &
                                "@PerfilResponsavel, " &
                                "@operacao, " &
                                "@local, " &
                                "@distanciaVante, " &
                                "@distanciaRe )"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0


            'Try


            'Dim perigosa As Integer = 0

            'If aviso.cargaPerigosa Then
            '    perigosa = 1
            'Else
            '    perigosa = 0
            'End If


            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@numeroDuv", chagadasaida.numeroDuv)
                cmd.Parameters.AddWithValue("@id", chagadasaida.id)
                cmd.Parameters.AddWithValue("@ProximoId", chagadasaida.ProximoId)
                cmd.Parameters.AddWithValue("@movimentacao", chagadasaida.movimentacao)
                cmd.Parameters.AddWithValue("@acao", chagadasaida.acao)
                cmd.Parameters.AddWithValue("@dataHora", chagadasaida.dataHora)
                cmd.Parameters.AddWithValue("@motivo", chagadasaida.motivo)
                cmd.Parameters.AddWithValue("@SituacaoAtual", chagadasaida.SituacaoAtual)
                cmd.Parameters.AddWithValue("@motivoCancelamento", chagadasaida.motivoCancelamento)
                cmd.Parameters.AddWithValue("@caladoVante", chagadasaida.caladoVante)
                cmd.Parameters.AddWithValue("@caladoRe", chagadasaida.caladoRe)
                cmd.Parameters.AddWithValue("@manobraPratico", chagadasaida.manobraPratico)
                cmd.Parameters.AddWithValue("@motivoNaoManobraPratico", chagadasaida.motivoNaoManobraPratico)
                cmd.Parameters.AddWithValue("@observacao", chagadasaida.observacao)
                cmd.Parameters.AddWithValue("@dataHoraRegistro", chagadasaida.dataHoraRegistro)
                cmd.Parameters.AddWithValue("@Responsavel", chagadasaida.Responsavel)
                cmd.Parameters.AddWithValue("@PerfilResponsavel", chagadasaida.PerfilResponsavel)
                cmd.Parameters.AddWithValue("@operacao", chagadasaida.operacao)
            cmd.Parameters.AddWithValue("@local", chagadasaida.local)
            cmd.Parameters.AddWithValue("@distanciaVante", chagadasaida.distanciaVante)
                cmd.Parameters.AddWithValue("@distanciaRe", chagadasaida.distanciaRe)



                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
            ' id = cmd.LastInsertedId

            '   arq_erros.Close()

            'Catch ex As Exception
            '    arq_erros.WriteLine(Date.Now)
            '    arq_erros.WriteLine(ex.Message)
            '    arq_erros.WriteLine(ex.StackTrace)
            '    arq_erros.WriteLine(" ")
            '    arq_erros.Close()

            'Finally
            cnn.Close()
            'End Try
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
            Dim sql As String = "delete from chegadasaida_chegadasaida" &
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