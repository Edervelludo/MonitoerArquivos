Imports MySql.Data.MySqlClient
Imports MySql.Data

Module banco
    Function ConsultaSQL(ByVal Sql As String) As DataTable

        Dim conexaoMySQL As New MySqlConnection
        Dim daMySQL As New MySql.Data.MySqlClient.MySqlDataAdapter

        Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        Dim consulta As New DataTable
        Try
            conexaoMySQL = New MySqlConnection(StringBanco)
            conexaoMySQL.Open()

            Dim ds As New DataSet
            Dim adapter As New MySqlDataAdapter(Sql, conexaoMySQL)
            adapter.Fill(ds, "resultado")
            consulta = ds.Tables("resultado")
            arq_erros.Close()

        Catch ex As Exception
            arq_erros.WriteLine(Date.Now)
            arq_erros.WriteLine(ex.Message)
            arq_erros.WriteLine(" ")
            arq_erros.Close()
            MsgBox("Erro ao executar consulta no Banco de Dados : " & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return consulta
    End Function

    Function ExecutaSQL(ByVal Sql As String) As Integer

        Dim conexaoMySQL As New MySqlConnection
        Dim daMySQL As New MySql.Data.MySqlClient.MySqlDataAdapter

        Dim arq_erros As System.IO.StreamWriter = retornaArquivoErro()
        Dim retorno As Integer

        Try
            conexaoMySQL = New MySqlConnection(StringBanco)
            conexaoMySQL.Open()

            Dim comando As MySqlClient.MySqlCommand = conexaoMySQL.CreateCommand()
            comando.CommandTimeout = 0
            comando.CommandText = Sql
            retorno = comando.ExecuteNonQuery()
            arq_erros.Close()

        Catch ex As Exception
            arq_erros.WriteLine(Date.Now)
            arq_erros.WriteLine(ex.Message)
            arq_erros.WriteLine(" ")
            arq_erros.Close()
            'MsgBox("Erro ao executar comando no Banco de Dados : " & ex.Message, MsgBoxStyle.Critical)
        End Try
        conexaoMySQL.Close()
        Return retorno
    End Function

    Function retornaArquivoErro() As System.IO.StreamWriter

        'Dim escreve As IO.StreamWriter
        If IO.File.Exists("C:\MonitorArquivosPSP\err.txt") Then
            'escreve = New IO.StreamWriter("C:\MonitorArquivosPSP\err.txt", True)
            'escreve.Close()
            'escreve.Dispose()
            Return New IO.StreamWriter("C:\MonitorArquivosPSP\err.txt", True)
        Else
            Return criarArquivoErros()
        End If


    End Function

    Function criarArquivoErros() As System.IO.StreamWriter


        Dim escreve As IO.StreamWriter

        escreve = IO.File.CreateText("C:\MonitorArquivosPSP\err.txt")
        escreve.WriteLine("######## NOVO ARQUIVO CRIADO EM:" & Date.Now & "###########")
        escreve.WriteLine("")

        escreve.Close()
        escreve.Dispose()
        Return New IO.StreamWriter("C:\MonitorArquivosPSP\err.txt", True)

    End Function

    Function SetULtimaData() As DateTime
        Dim ultima_data As DateTime
        Dim tabela As New DataTable()
        Dim sql As String = "SELECT max(data_arquivo) as data_processo  FROM `arquivos_psp`"

        tabela = ConsultaSQL(sql)

        If Not IsDBNull(tabela.Rows.Item(0).Item("data_processo")) Then
            ultima_data = tabela.Rows.Item(0).Item("data_processo")
            ' Console.WriteLine(ultima_data)
            ' Console.ReadKey()
        Else
            ultima_data = Date.MinValue


        End If

        '  ultima_data = tabela.Rows.Item(0).Item("data_processo")

        Return ultima_data

    End Function


End Module
