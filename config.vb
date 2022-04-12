Imports System.IO
Imports System.IO.Compression

Module config

    Public usuario As String
    Public Function LeParametrosBanco(ByVal parametro As String) As String

        Dim arq_banco As System.IO.StreamReader = retornaArquivoBANCO()
        Dim linhaTexto = arq_banco.ReadLine()
        Dim valor As String = ""

        While linhaTexto <> Nothing
            If linhaTexto.ToString.Split("=")(0) = parametro Then
                valor = linhaTexto.ToString.Split("=")(1)
            End If
            linhaTexto = arq_banco.ReadLine
        End While
        arq_banco.Close()
        arq_banco.Dispose()
        'If valor = "" Then
        '    Return ""
        'Else
        Return valor
        'End If


    End Function

    Public Function LeParametros(ByVal parametro As String) As String

        Dim arq_banco As System.IO.StreamReader = retornaArquivoPAR()
        Dim linhaTexto = arq_banco.ReadLine
        Dim valor As String = ""

        While linhaTexto <> Nothing
            If linhaTexto.ToString.Split("=")(0) = parametro Then
                valor = linhaTexto.ToString.Split("=")(1)
            End If
            linhaTexto = arq_banco.ReadLine
        End While
        arq_banco.Close()
        arq_banco.Dispose()
        'If valor = "" Then
        '    Return ""
        'Else
        Return valor
        'End If


    End Function


    Public Function retornaArquivoBANCO() As System.IO.StreamReader

        Dim banco As StreamReader
        If IO.File.Exists("C:\MonitorArquivosPSP\sgusr") Then
            banco = New IO.StreamReader("C:\MonitorArquivosPSP\sgusr", True)

            Return banco
        Else
            Return criarArquivoBANCO()
        End If

    End Function

    Public Function retornaArquivoPAR() As System.IO.StreamReader

        Dim par As StreamReader
        If IO.File.Exists("C:\MonitorArquivosPSP\param.txt") Then
            par = New IO.StreamReader("C:\MonitorArquivosPSP\param.txt", True)

            Return par
        Else
            Return criarArquivoParametros()
        End If

    End Function

    Public Function criarArquivoBANCO() As System.IO.StreamReader

        Dim escreve As IO.StreamWriter

        escreve = IO.File.CreateText("C:\MonitorArquivosPSP\sgusr")
        escreve.WriteLine("SERVIDOR=LOCALHOST")
        escreve.WriteLine("SERVIDOR_BANCO=arquivos_psp")
        escreve.WriteLine("SERVIDOR_PORTA=3306")
        escreve.WriteLine("SERVIDOR_USR=root")
        escreve.WriteLine("SERVIDOR_SENHA=1qaz2wsx")
        escreve.Close()
        escreve.Dispose()

        Return New IO.StreamReader("C:\MonitorArquivosPSP\sgusr", True)


    End Function

    Public Function criarArquivoLOG() As System.IO.StreamWriter

        Dim escreve As IO.StreamWriter

        escreve = IO.File.CreateText("C:\MonitorArquivosPSP\log.txt")

        escreve.Close()
        escreve.Dispose()

        Return New IO.StreamWriter("C:\MonitorArquivosPSP\log.txt", True)


    End Function

    Public Function retornaArquivoLOG() As System.IO.StreamWriter
        Dim log As StreamWriter
        If IO.File.Exists("C:\MonitorArquivosPSP\log.txt") Then

            log = New IO.StreamWriter("C:\MonitorArquivosPSP\log.txt", True)

            Return log
        Else
            Return criarArquivoLOG()
        End If

    End Function



    Public Function criarArquivoParametros() As System.IO.StreamReader

        Dim escreve As IO.StreamWriter

        escreve = IO.File.CreateText("C:\MonitorArquivosPSP\param.txt")
        escreve.WriteLine("CAMINHO_FONTE=C:\MonitorArquivosPSP\Arquivos\")
        escreve.WriteLine("FILTRO=*.xml")
        escreve.WriteLine("SUBDIRETORIOS=true")
        escreve.Close()
        escreve.Dispose()
        Return New IO.StreamReader("C:\MonitorArquivosPSP\param.txt", True)


    End Function

    Public Function StringBanco() As String

        Dim servidor As String = LeParametrosBanco("SERVIDOR")
        Dim porta As String = LeParametrosBanco("SERVIDOR_PORTA")
        Dim banco As String = LeParametrosBanco("SERVIDOR_BANCO")
        Dim usuario As String = LeParametrosBanco("SERVIDOR_USR")
        Dim senha As String = LeParametrosBanco("SERVIDOR_SENHA")

        Return "server=" & servidor & "; Port=" & porta & "; user id=" & usuario & "; password=" & senha & "; database=" & banco & ";convert zero datetime=True"
    End Function

    Public Function FormataTEL(text As String) As String


        If text.Length <= 2 Then
            Return text

        ElseIf text.Length > 2 And text.Length < 7 Then

            text = text.Substring(0, 2) & " " & text.Substring(2, text.Length - 2)

        ElseIf text.Length = 8 Then

            text = text.Substring(0, 4) & " " & text.Substring(4, 4)

        ElseIf text.Length = 9 Then

            text = text.Substring(0, 5) & " " & text.Substring(4, 4)

        ElseIf text.Length >= 7 And text.Length <= 10 Then

            text = text.Substring(0, 2) & " " & text.Substring(2, 4) & " " & text.Substring(6, text.Length - 6)

        ElseIf text.Length = 11 And text.StartsWith("0") Then

            text = text.Substring(0, 4) & " " & text.Substring(4, 3) & " " & text.Substring(7, 2) & " " & text.Substring(9, 2)

        ElseIf text.Length = 11 And Not text.StartsWith("0") Then

            text = text.Substring(0, 2) & " " & text.Substring(2, 5) & " " & text.Substring(7, 4)

        ElseIf text.Length = 12 And Not text.StartsWith("0") Then

            text = text.Substring(0, 2) & " " & text.Substring(2, 5) & " " & text.Substring(7, 4)

        ElseIf text.Length = 12 Then

            text = text.Substring(0, 4) & " " & text.Substring(4, 3) & " " & text.Substring(7, 2) & " " & text.Substring(9, 2)

        ElseIf text.Length = 13 Then

            text = text.Substring(0, 2) & " " & text.Substring(2, 4) & " " & text.Substring(6, 3) & " " & text.Substring(9, 2) & " " & text.Substring(11, 2)

        End If


        Return text

    End Function

    Public Function ExibirArquivosDir(ByVal dir As String, data As DateTime) As String()

        Dim nome As String
        Dim arquivos() As String

        Dim indice As Integer = Directory.GetFiles(dir).Length

        ReDim Preserve arquivos(indice)

        Dim f As FileInfo

        Dim i As Integer = 0
        Try

            For Each nome In Directory.GetFiles(dir)


                f = New FileInfo(nome)
                'If (DateTime.Compare(f.CreationTime, data) > 0) Then

                arquivos(i) = New String(nome)
                i = i + 1

                ' End If



            Next



        Catch

            MsgBox("<<ERRO>> Não é possivel careegar os arquivos !", MsgBoxStyle.Critical)

        End Try

        Return arquivos

    End Function


    Public Function BarradeProgresso(progress As Integer, total As Integer, porcentagem As Integer, tipo As String) As Integer

        Console.CursorLeft = 0
        Console.Write("[")
        Console.CursorLeft = 32
        Console.Write("]")
        Console.CursorLeft = 1
        Dim onechunk As Decimal = 30 / total


        Dim position As Integer = 1
        For i As Integer = 0 To i < onechunk * progress
            Console.BackgroundColor = ConsoleColor.Gray
            position = position + 1
            Console.CursorLeft = position
            Console.Write(" ")
        Next

        For i As Integer = position To i <= 31
            Console.BackgroundColor = ConsoleColor.Green
            position = position + 1
            Console.CursorLeft = position
            Console.Write(" ")
        Next


        'Console.BackgroundColor = ConsoleColor.Green
        'position = position + 1
        'Console.CursorLeft = position
        'Console.Write(" ")



        'Console.CursorLeft = 35
        ' Console.BackgroundColor = ConsoleColor.Black
        Console.Write(progress.ToString() & " de " & total.ToString() & "    " & porcentagem & "% Concluido -> " & tipo)
        Return 1
    End Function



    Public Function LerExeTipoArquivo(ByVal parametro As String) As String

        Dim arq_banco As System.IO.StreamReader = retornaArquivoArqEXE()
        Dim linhaTexto = arq_banco.ReadLine
        Dim valor As String = ""

        While linhaTexto <> Nothing
            If linhaTexto.ToString.Split("=")(0) = parametro Then
                valor = linhaTexto.ToString.Split("=")(1)
            End If
            linhaTexto = arq_banco.ReadLine
        End While
        arq_banco.Close()
        'If valor = "" Then
        '    Return ""
        'Else
        Return valor
        'End If


    End Function


    Public Function retornaArquivoArqEXE() As System.IO.StreamReader

        Dim par As StreamReader
        If IO.File.Exists("C:\MonitorArquivosPSP\arqexe.txt") Then
            par = New IO.StreamReader("C:\MonitorArquivosPSP\arqexe.txt", True)

            Return par
        Else
            Return criarArquivoArqEXE()
        End If

    End Function


    Public Function criarArquivoArqEXE() As System.IO.StreamReader

        Dim escreve As IO.StreamWriter

        escreve = IO.File.CreateText("C:\MonitorArquivosPSP\Arquivos\arqexe.txt")
        escreve.WriteLine("AACDRJ=C:\MonitorArquivosPSP\Arquivos\AACDRJ.EXE")
        escreve.Close()
        escreve.Dispose()

        Return New IO.StreamReader("C:\MonitorArquivosPSP\Arquivos\arqexe.txt", True)


    End Function


    Public Function ExtrairZIP(caminho As String) As String

        Dim dir As String = caminho.Split(".")(0).Trim().Replace("-", "")
        Try

            If File.Exists(caminho) Then
                'Dim d As New DirectoryInfo(caminho.Split(".")(0))
                'd.Delete()
                'd.CreateSubdirectory(caminho.Split(".")(0))

                'ZipFile.ExtractToDirectory(caminho, dir)
                'ZipFile.OpenRead(caminho)
            End If


            Return dir
        Catch ex As ArgumentException
            Throw ex
        Finally

        End Try




        'caminho.Split(".")(0))
        ' MsgBox("ArquivDIM os ZIP extraidos com sucesso", "Extrair ZIP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Return ".\Arquivos\" & caminho.Split(".")(0).Split("\")(3)

        '       Else

        '   Return "erro"
        'MsgBox("Arquivo ZIP não existe no local", "Não Existe ZIP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''    End If
        '    Catch ex As Exception
        '    ' MsgBox("Erro : " & ex.Message, "Erro Arquivo ZIP", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '   Return "erro"
        '   End Try

    End Function

End Module

