Imports MySql.Data.MySqlClient

Imports MonitorArquivos.MANIFESTO.DTO

Namespace MANIFESTO.DAL


    Public Class conhecimentosEmbarqueDAL

        Private Shared strcon As String
        Shared Sub New()
            strcon = StringBanco()
        End Sub

        Public Function SelecionaconhecimentoEmbarqueManifesto(ByVal num_manifesto As String) As DataTable

            Dim sql = "Select * from man_conhecimentosembarque where num_manifesto = @num_manifesto"
            Dim dt As New DataTable

            Dim con As New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@num_manifesto", num_manifesto)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)


                arq_erros.Close()

            Catch ex As Exception
                'MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

            End Try

            Return dt
        End Function
        Public Function SelecionaconhecimentoEmbarqueBL(ByVal num_bl As String) As DataTable

            Dim sql = "Select * from man_conhecimentosembarque where num_bl = @num_bl"
            Dim dt As New DataTable

            Dim con As New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@num_bl", num_bl)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)


                arq_erros.Close()

            Catch ex As Exception
                'MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

            End Try

            Return dt
        End Function
        Public Function SelecionaconhecimentoEmbarqueCE(ByVal num_CE_mercante As String) As DataTable

            Dim sql = "Select * from man_conhecimentosembarque where num_CE_mercante = @num_CE_mercante"
            Dim dt As New DataTable

            Dim con As New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@num_CE_mercante", num_CE_mercante)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)


                arq_erros.Close()

            Catch ex As Exception
                'MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

            End Try

            Return dt
        End Function
        Public Function SelecionaconhecimentoEmbarqueDUV(ByVal num_duv As String) As DataTable

            Dim sql = "Select * from man_conhecimentosembarque where num_duv = @num_duv"
            Dim dt As New DataTable

            Dim con As New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()

            Try

                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@num_duv", num_duv)

                Dim da As New MySqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)


                arq_erros.Close()

            Catch ex As Exception
                'MsgBox("Erro: : " & ex.Message, MsgBoxStyle.Critical)
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If

            End Try

            Return dt
        End Function



        Public Function insert(ByVal conhecimento As conhecimentosEmbarqueDTO) As Long
            Dim sql As String = " INSERT INTO `sigep2`.`man_conhecimentosembarque` " &
                                "( " &
                                "`num_manifesto`, " &
                                "`num_bl`, " &
                                "`num_CE_mercante`, " &
                                "`dt_emissao`, " &
                                "`tipo_conhecimento`, " &
                                "`consignatario`, " &
                                "`num_duv`) " &
                                "VALUES " &
                                "( @num_manifesto, " &
                                "@num_bl, " &
                                "@num_CE_mercante, " &
                                "@dt_emissao, " &
                                "@tipo_conhecimento, " &
                                "@consignatario, " &
                                "@num_duv); "


            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try


                cmd.Parameters.AddWithValue("@num_manifesto", conhecimento.num_manifesto)
                cmd.Parameters.AddWithValue("@num_bl", conhecimento.num_bl)
                cmd.Parameters.AddWithValue("@num_CE_mercante", conhecimento.num_CE_mercante)
                cmd.Parameters.AddWithValue("@dt_emissao", conhecimento.dt_emissao)
                cmd.Parameters.AddWithValue("@tipo_conhecimento", conhecimento.tipo_conhecimento)
                cmd.Parameters.AddWithValue("@consignatario", conhecimento.consignatario)
                cmd.Parameters.AddWithValue("@num_duv", conhecimento.num_duv)


                'Dim sqlrecid = "SELECT LAST_INSERT_ID() INTO @ID;"

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = cmd.LastInsertedId

                arq_erros.Close()

            Catch ex As Exception
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(cmd.CommandText)
                For i As Integer = 0 To cmd.Parameters.Count - 1
                    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                Next
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally
                cnn.Close()
            End Try
            Return id
        End Function


        Public Function deleteManifesto(ByVal num_manifesto As String) As Integer
            Dim sql As String = "delete from man_conhecimentosembarque " &
                                " WHERE (num_manifesto = @num_manifesto)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try



                cmd.Parameters.AddWithValue("@num_manifesto", num_manifesto)

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = 1

                arq_erros.Close()

            Catch ex As Exception
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(cmd.CommandText)
                For i As Integer = 0 To cmd.Parameters.Count - 1
                    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                Next
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally
                cnn.Close()
            End Try

            Return id
        End Function

        Public Function deleteBL(ByVal num_bl As String) As Integer
            Dim sql As String = "delete from man_conhecimentosembarque " &
                                " WHERE (num_bl = @num_bl)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try



                cmd.Parameters.AddWithValue("@num_bl", num_bl)

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = 1

                arq_erros.Close()

            Catch ex As Exception
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(cmd.CommandText)
                For i As Integer = 0 To cmd.Parameters.Count - 1
                    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                Next
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally
                cnn.Close()
            End Try

            Return id
        End Function

        Public Function deleteCEMercante(ByVal num_CE_mercante As String) As Integer
            Dim sql As String = "delete from man_conhecimentosembarque " &
                                " WHERE (num_CE_mercante = @num_CE_mercante)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try



                cmd.Parameters.AddWithValue("@num_CE_mercante", num_CE_mercante)

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = 1

                arq_erros.Close()

            Catch ex As Exception
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(cmd.CommandText)
                For i As Integer = 0 To cmd.Parameters.Count - 1
                    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                Next
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally
                cnn.Close()
            End Try

            Return id
        End Function

        Public Function deleteDUV(ByVal num_duv As String) As Integer
            Dim sql As String = "delete from man_conhecimentosembarque " &
                                " WHERE (num_duv = @num_duv)"

            Dim cnn As MySqlConnection = New MySqlConnection(strcon)
            Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
            Dim id As Integer = 0
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnn)

            Try



                cmd.Parameters.AddWithValue("@num_duv", num_duv)

                cnn.Open()
                cmd.ExecuteNonQuery()
                id = 1

                arq_erros.Close()

            Catch ex As Exception
                arq_erros.WriteLine(Date.Now)
                arq_erros.WriteLine(ex.Message)
                arq_erros.WriteLine(ex.StackTrace)
                arq_erros.WriteLine(cmd.CommandText)
                For i As Integer = 0 To cmd.Parameters.Count - 1
                    arq_erros.WriteLine(cmd.Parameters(i).ParameterName & "----> " & cmd.Parameters(i).Value)
                Next
                arq_erros.WriteLine(" ")
                arq_erros.Close()

            Finally
                cnn.Close()
            End Try

            Return id
        End Function


    End Class
End Namespace