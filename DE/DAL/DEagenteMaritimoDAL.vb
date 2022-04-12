
Imports MonitorArquivos.DE.DTO
Imports MySql.Data.MySqlClient

Namespace DE.DAL


    Public Class DEagenteMaritimoDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionaagenteMaritimoCNPJ(ByVal CNPJ As String) As DataTable

            Dim sql = "Select * from de_agentemaritimo where cnpjAgenciaNavegacao = @CNPJ"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            '  Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@CNPJ", CNPJ)

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

        Public Function insert(ByVal agencia As DEagenteMaritimoDTO) As String
            Dim sql As String = "INSERT INTO `de_agentemaritimo` ( " &
                                "`nomeAgencia` , " &
                               "`cnpjAgenciaNavegacao` " &
                                ") " &
                                "VALUES ( " &
                                "@nomeAgencia,  @cnpjAgenciaNavegacao)"


            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0


            Try


                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@nomeAgencia", agencia.nomeAgencia)
                cmd.Parameters.AddWithValue("@cnpjAgenciaNavegacao", agencia.cnpjAgenciaNavegacao)




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
            Return agencia.nomeAgencia & "-> CNPJ: " & agencia.cnpjAgenciaNavegacao
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

        Public Function delete(ByVal cnpjAgenciaNavegacao As String) As Integer
            Dim sql As String = "delete from de_agentemaritimo" &
                                " WHERE (cnpjAgenciaNavegacao = @cnpjAgenciaNavegacao)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            '  Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            '           Try



            cmd.Parameters.AddWithValue("@cnpjAgenciaNavegacao", cnpjAgenciaNavegacao)

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