Imports MySql.Data.MySqlClient

Imports MonitorArquivos.AACDRJ.DTO

Namespace AACDRJ.DAL


    Public Class fundeadourosprevistosatracacaoDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionafundeadourosprevistosatracacaoDUV(ByVal DUV As String) As DataTable

            Dim sql = "Select * from aacdrj_fundeadourosprevistosatracacao where numeroDuv = @DUV"
            Dim dt As New DataTable
            Dim con As New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            'Try

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

            'Finally

            '    If con.State = ConnectionState.Open Then
            con.Close()
            ' End If

            'End Try

            Return dt
        End Function

        Public Function insert(ByVal fundat As fundeadourosprevistosatracacaoDTO) As String
            Dim sql As String = "INSERT INTO `aacdrj_fundeadourosprevistosatracacao` ( " &
                                "`numeroDuv` , " &
                                "`fundeadouro` , " &
                                "`boiaAmarracao` " &
                                ") " &
                                "VALUES ( " &
                                "@numeroDuv, @fundeadouro, @boiaAmarracao)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try


                cmd.Parameters.AddWithValue("@numeroDuv", fundat.numeroDuv)
                cmd.Parameters.AddWithValue("@fundeadouro", fundat.fundeadouro)
                cmd.Parameters.AddWithValue("@boiaAmarracao", fundat.boiaAmarracao)



                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
                'id = cmd.LastInsertedId

                'arq_erros.Close()

            Catch ex As Exception
                'arq_erros.WriteLine(Date.Now)
                'arq_erros.WriteLine(ex.Message)
                'arq_erros.WriteLine(ex.StackTrace)
                'arq_erros.WriteLine(cmd.CommandText)
                'For i As Integer = 0 To cmd.Parameters.Count - 1
                '    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                'Next
                'arq_erros.WriteLine(" ")
                'arq_erros.Close()

            Finally
                cnn.Close()
            End Try
            Return fundat.numeroDuv
        End Function

        'Public Function updade(ByVal fundat As fundeadourosprevistosatracacaoDTO) As String
        '    Dim sql As String = "UPDATE fundeadourosprevistosatracacao " &
        '                        "SET " &
        '                        "numeroDuv = @numeroDuv , " &
        '                        "fundeadouro = @fundeadouro , " &
        '                        "boiaAmarracao = @boiaAmarracao  " &
        '                        " WHERE (id_fund_atrac = @id_fund_atrac)"

        '    Dim cnn As MySqlConnection = New MySqlConnection(strcon)
        '    ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        '    Dim id As Integer = 0
        '    Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

        '    Try



        '        cmd.Parameters.AddWithValue("@numeroDuv", fundat.numeroDuv)
        '        cmd.Parameters.AddWithValue("@fundeadouro", fundat.fundeadouro)
        '        cmd.Parameters.AddWithValue("@boiaAmarracao", fundat.boiaAmarracao)


        '        cnn.Open()
        '        cmd.ExecuteNonQuery()
        '        '   id = 1

        '        '  arq_erros.Close()

        '    Catch ex As Exception
        '        'arq_erros.WriteLine(Date.Now)
        '        'arq_erros.WriteLine(ex.Message)
        '        'arq_erros.WriteLine(ex.StackTrace)
        '        'arq_erros.WriteLine(cmd.CommandText)
        '        'For i As Integer = 0 To cmd.Parameters.Count - 1
        '        '    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
        '        'Next
        '        'arq_erros.WriteLine(" ")
        '        'arq_erros.Close()

        '    Finally
        '        cnn.Close()
        '    End Try

        '    Return fundat.numeroDuv
        'End Function


        Public Function delete(ByVal numeroDuv As String) As Integer
            Dim sql As String = "delete from  aacdrj_fundeadourosprevistosatracacao " &
                                " WHERE (numeroDuv = @numeroDuv)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            ' Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try



                cmd.Parameters.AddWithValue("@numeroDuv", numeroDuv)

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = 1

                ' arq_erros.Close()

            Catch ex As Exception
                'arq_erros.WriteLine(Date.Now)
                'arq_erros.WriteLine(ex.Message)
                'arq_erros.WriteLine(ex.StackTrace)
                'arq_erros.WriteLine(cmd.CommandText)
                'For i As Integer = 0 To cmd.Parameters.Count - 1
                '    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                'Next
                'arq_erros.WriteLine(" ")
                'arq_erros.Close()

            Finally
                cnn.Close()
            End Try

            Return id
        End Function

    End Class
End Namespace