Imports MySql.Data.MySqlClient

Imports MonitorArquivos.AACDRJ.DTO

Namespace AACDRJ.DAL


    Public Class estadiaEmbarcacaoDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionaestadiaEmbarcacaoDUV(ByVal DUV As String) As DataTable

            Dim sql = "Select * from estadiaEmbarcacao where numeroDuv = @DUV"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@DUV", DUV)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)

                '    arq_erros.Close()

            Catch ex As Exception
                ''MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
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

        Public Function insert(ByVal estadia As estadiaEmbarcacaoDTO) As Long
            Dim sql As String = "INSERT INTO `aacdrj_estadiaEmbarcacao` ( " &
                                "`numeroDuv` , " &
                                "`prioridadePretendida` , " &
                                "`qtdeDiasPrevistosOperacao` , " &
                                "`numeroViagemAgencia` , " &
                                "`tipoViagemOrigem`  ," &
                                "`tipoViagemDestino`  ," &
                                "`tipoCarga` , " &
                                "`destinoCarga` , " &
                                "`quantidadeFlutuantes` , " &
                                "`quantidadePranchas` , " &
                                "`terminal` " &
                                ") " &
                                "VALUES ( " &
                                "@numeroDuv, @prioridadePretendida, @qtdeDiasPrevistosOperacao, " &
                                "@numeroViagemAgencia, @tipoViagemOrigem, @tipoViagemDestino, @tipoCarga , @destinoCarga, @quantidadeFlutuantes,   " &
                                "@quantidadePranchas, @terminal )"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0


            Try


                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@numeroDuv", estadia.numeroDuv)
                cmd.Parameters.AddWithValue("@prioridadePretendida", estadia.prioridadePretendida)
                cmd.Parameters.AddWithValue("@qtdeDiasPrevistosOperacao", estadia.qtdeDiasPrevistosOperacao)
                cmd.Parameters.AddWithValue("@numeroViagemAgencia", estadia.numeroViagemAgencia)
                cmd.Parameters.AddWithValue("@tipoViagemOrigem", estadia.tipoViagemOrigem)
                cmd.Parameters.AddWithValue("@tipoViagemDestino", estadia.tipoViagemDestino)
                cmd.Parameters.AddWithValue("@destinoCarga", estadia.destinoCarga)
                cmd.Parameters.AddWithValue("@quantidadeFlutuantes", estadia.quantidadeFlutuantes)
                cmd.Parameters.AddWithValue("@quantidadePranchas", estadia.quantidadePranchas)
                cmd.Parameters.AddWithValue("@terminal", estadia.terminal)
                cmd.Parameters.AddWithValue("@tipoCarga", estadia.tipoCarga)




                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = cmd.LastInsertedId

                'arq_erros.Close()

            Catch ex As Exception
                'arq_erros.WriteLine(Date.Now)
                'arq_erros.WriteLine(ex.Message)
                'arq_erros.WriteLine(ex.StackTrace)
                'arq_erros.WriteLine(" ")
                'arq_erros.Close()

            Finally
                cnn.Close()
            End Try
            Return id
        End Function

        'Public Function updade(ByVal estadia As estadiaEmbarcacaoDTO) As Integer
        '    Dim sql As String = "UPDATE  estadiaEmbarcacao " &
        '                        "SET " &
        '                        "numeroDuv =  @numeroDuv, " &
        '                        "prioridadePretendida = @prioridadePretendida, " &
        '                        "qtdeDiasPrevistosOperacao = @qtdeDiasPrevistosOperacao, " &
        '                        "numeroViagemAgencia = @numeroViagemAgencia , " &
        '                        "tipoViagemOrigem = @tipoViagemOrigem ," &
        '                        "tipoViagemDestino = @tipoViagemDestino ," &
        '                        "tipoCarga = @tipoCarga , " &
        '                        "destinoCarga = @destinoCarga , " &
        '                        "quantidadeFlutuantes = @quantidadeFlutuantes , " &
        '                        "quantidadePranchas = @quantidadePranchas ,  " &
        '                        "terminal= @terminal " &
        '                        "WHERE (numeroDuv = @numeroDuv)"

        '    Dim cnn As MySqlConnection = New MySqlConnection(strcon)
        '    Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        '    Dim id As Integer = 0

        '    Try



        '        Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
        '        cmd.Parameters.AddWithValue("@numeroDuv", estadia.numeroDuv)
        '        cmd.Parameters.AddWithValue("@prioridadePretendida", estadia.prioridadePretendida)
        '        cmd.Parameters.AddWithValue("@qtdeDiasPrevistosOperacao", estadia.qtdeDiasPrevistosOperacao)
        '        cmd.Parameters.AddWithValue("@numeroViagemAgencia", estadia.numeroViagemAgencia)
        '        cmd.Parameters.AddWithValue("@tipoViagemOrigem", estadia.tipoViagemOrigem)
        '        cmd.Parameters.AddWithValue("@tipoViagemDestino", estadia.tipoViagemDestino)
        '        cmd.Parameters.AddWithValue("@destinoCarga", estadia.destinoCarga)
        '        cmd.Parameters.AddWithValue("@quantidadeFlutuantes", estadia.quantidadeFlutuantes)
        '        cmd.Parameters.AddWithValue("@quantidadePranchas", estadia.quantidadePranchas)
        '        cmd.Parameters.AddWithValue("@terminal", estadia.terminal)
        '        cmd.Parameters.AddWithValue("@tipoCarga", estadia.tipoCarga)


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

        Public Function delete(ByVal DUV As String) As Integer
            Dim sql As String = "delete from aacdrj_estadiaembarcacao" &
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