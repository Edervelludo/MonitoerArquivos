
Imports MonitorArquivos.AACDRJ
Imports MonitorArquivos.AACDRJ.DTO
Imports MySql.Data.MySqlClient

Namespace AACDRJ.DAL


    Public Class representanteLegalDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionaRepresentanteLegalDUV(ByVal DUV As String) As DataTable

            Dim sql = "Select * from aacdrj_representanteLegal where cnpjAgenciaNavegacao = @DUV"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            '  Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

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

        Public Function insert(ByVal representante As representanteLegalDTO) As String
            Dim sql As String = "INSERT INTO `aacdrj_representanteLegal` ( " &
                                "`identificador` , " &
                                "`numeroDUV` , " &
                                "`nomeRepresentante` " &
                                ") " &
                                "VALUES ( " &
                                "@identificador, @numeroDUV, @nomeRepresentante)"


            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            'Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0


            Try


                Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)
                cmd.Parameters.AddWithValue("@identificador", representante.identificador)
                cmd.Parameters.AddWithValue("@nomeRepresentante", representante.nomeRepresentante)
                cmd.Parameters.AddWithValue("@numeroDUV", representante.numeroDUV)




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
            Return representante.numeroDUV & "-> Representante: " & representante.nomeRepresentante
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

        Public Function delete(ByVal DUV As String) As Integer
            Dim sql As String = "delete from aacdrj_representanteLegal" &
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