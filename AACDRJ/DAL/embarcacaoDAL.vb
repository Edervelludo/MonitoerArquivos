Imports MySql.Data.MySqlClient

Imports MonitorArquivos.AACDRJ.DTO

Namespace AACDRJ.DAL


    Public Class embarcacaoDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionaEmbarcacaoIMO(ByVal IMO As String) As DataTable

            Dim sql = "Select * from aacdrj_embarcacao where numeroIMO = @IMO"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@IMO", IMO)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)

                '      arq_erros.Close()

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

        Public Function insert(ByVal embarcacao As embarcacaoDTO) As Long
            Dim sql As String = "INSERT INTO `aacdrj_embarcacao` " &
                                "(`numeroDUV`, `numeroIMO`, `inscricao`, `nomeEmbarcacao`, `estadoBandeira`, `caladoMaximo`, `caladoEntradaProa`, `caladoEntradaPopa`, `caladoSaidaProa`, `caladoSaidaPopa` ) " &
                                " VALUES (@numeroDUV, @numeroIMO, @inscricao, @nomeEmbarcacao, @estadoBandeira, @caladoMaximo, @caladoEntradaProa, @caladoEntradaPopa, @caladoSaidaProa, @caladoSaidaPopa);"


            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0

            Try
                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@numeroDUV", embarcacao.numeroDUV)
                cmd.Parameters.AddWithValue("@numeroIMO", embarcacao.numeroIMO)
                cmd.Parameters.AddWithValue("@inscricao", embarcacao.inscricao)
                cmd.Parameters.AddWithValue("@nomeEmbarcacao", embarcacao.nomeEmbarcacao)
                cmd.Parameters.AddWithValue("@estadoBandeira", embarcacao.estadoBandeira)
                cmd.Parameters.AddWithValue("@caladoMaximo", embarcacao.caladoMaximo)
                cmd.Parameters.AddWithValue("@caladoEntradaProa", embarcacao.caladoEntradaProa)
                cmd.Parameters.AddWithValue("@caladoEntradaPopa", embarcacao.caladoEntradaPopa)
                cmd.Parameters.AddWithValue("@caladoSaidaProa", embarcacao.caladoSaidaProa)
                cmd.Parameters.AddWithValue("@caladoSaidaPopa", embarcacao.caladoSaidaPopa)



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

        'Public Function updade(ByVal embarcacao As embarcacaoDTO) As Integer
        '    Dim sql As String = "UPDATE embarcacao " & _
        '                        "SET " & _
        '                        "numeroIMO = @numeroIMO ," & _
        '                        "inscricao= @inscricao ," & _
        '                        "nomeEmbarcacao= @nomeEmbarcacao  ," & _
        '                        "estadoBandeira= @estadoBandeira  ," & _
        '                        "caladoMaximo= @caladoMaximo  " & _
        '                        "WHERE (numeroIMO = @numeroIMO)"

        '    Dim cnn As MySqlConnection = New MySqlConnection(strcon)
        '    Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        '    Dim id As Integer = 0

        '    Try
        '        Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
        '        'cmd.Parameters.AddWithValue("@id_embarcacao", embarcacao.id_embarcacao)
        '        cmd.Parameters.AddWithValue("@numeroIMO", embarcacao.numeroIMO)
        '        cmd.Parameters.AddWithValue("@inscricao", embarcacao.inscricao)
        '        cmd.Parameters.AddWithValue("@nomeEmbarcacao", embarcacao.nomeEmbarcacao)
        '        cmd.Parameters.AddWithValue("@estadoBandeira", embarcacao.estadoBandeira)
        '        cmd.Parameters.AddWithValue("@caladoMaximo", embarcacao.caladoMaximo)

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
            Dim sql As String = "delete from aacdrj_embarcacao" &
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