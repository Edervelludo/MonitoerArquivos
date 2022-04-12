Imports System.IO
Imports System.IO.Compression
Imports MonitorArquivos.CHEGADASAIDA.BLL
Imports MonitorArquivos.CHEGADASAIDA.DTO


Module CHEGADASAIDAEXE


    Public Function GravarCHEGADASAIDA(ByVal args As String) As String

        Dim retorno As String = ""

        Dim arquivo As String = args.Split(".")(0)
        Dim ano = arquivo.Split("-")(1).Substring(6, 4)
        Dim duv = arquivo.Split("-")(1).Substring(0, 6)
        'pegar duv 0403992021
        Dim anoduv As String = ano & duv

        ''chegadaSaida-dadosDuv.csv
        'Dim chegadaSaidadadosDuv As String = arquivo & "\" & "chegadaSaida-dadosDuv.csv"




        Using fs As FileStream = New FileStream(args, FileMode.Open, FileAccess.ReadWrite)

            Using archive As ZipArchive = New ZipArchive(fs, ZipArchiveMode.Read)
                'Using archive As ZipArchive = ZipFile.Open(args, ZipArchiveMode.Update)


                ''chegadaSaida-dadosDuv.csv
                For Each item As ZipArchiveEntry In archive.Entries

                    If item.Name = "chegadaSaida-dadosDuv.csv" Then
                        Using tr As StreamReader = New StreamReader(item.Open)
                            retorno += item.Name & "-"
                            retorno += GravaTabelachegadaSaidadadosDuv(tr.ReadToEnd(), anoduv) & vbCrLf
                            tr.Close()
                        End Using

                    Else
                        If item.Name = "chegadaSaida.csv" Then
                            Using tr1 As StreamReader = New StreamReader(item.Open)
                                retorno += item.Name & "-"
                                retorno += GravaTabelachegadaSaida(tr1.ReadToEnd(), anoduv) & vbCrLf
                                tr1.Close()
                            End Using

                        End If
                    End If



                Next
                fs.Close()
            End Using

        End Using

        'Dim fs As FileStream = New FileStream(chegadaSaidadadosDuv, FileMode.Open, FileAccess.Read)

        'Dim br As BinaryReader = New BinaryReader(fs)

        'Dados = br.ReadBytes(CType(fs.Length, Integer))

        'Return GravaTabelachegadaSaidadadosDuv(Dados, duv)

        ' 


        ''chegadaSaida.csv


        'Using fs1 As FileStream = New FileStream(args, FileMode.Open, FileAccess.ReadWrite)

        '    Using archive1 As ZipArchive = New ZipArchive(fs1, ZipArchiveMode.Read)
        '        'Using archive As ZipArchive = ZipFile.Open(args, ZipArchiveMode.Update)
        '        Dim chegadaSaidacsv As ZipArchiveEntry = archive1.Entries(1)

        ''        Using tr1 As StreamReader = New StreamReader(chegadaSaidacsv.Open)

        ''            retorno += chegadaSaidacsv.FullName & "-" & GravaTabelachegadaSaida(tr1.ReadToEnd(), anoduv)
        ''        End Using

        ''    End Using
        ''    fs1.Close()
        ''End Using

        ''chegadaSaida.csv
        'Dim chegadaSaida As String = arquivo & "\" & "chegadaSaida.csv"


        Return retorno


    End Function

    Private Function GravaTabelachegadaSaida(Dados As String, anoduv As String) As String
        Dim id As String = 0
        '  Dim DUV As String = DUV
        Dim retorno As String = ""


        'Do While srcsv.Peek >= 0
        'Loop

        Dim dadosvet() As String = Dados.Split(vbCrLf)

        Dim chegadaSaidaBLL As New chegadasaidaBLL
        chegadaSaidaBLL.Deletechegadasaida(anoduv)

        For Each linha As String In dadosvet

            If linha.Split(";")(0) <> "Id" Then
                Dim vet As List(Of String) = linha.Split(";").ToList

                Dim total As Integer = linha.Split(";").Count
                If total < 19 Then

                    For i As Integer = 0 To 19 - total
                        vet.Add("")

                    Next
                End If

                Dim chegadaSaida As New chegadasaidaDTO
                chegadaSaida.numeroDuv = anoduv

                chegadaSaida.id = vet(0)
                chegadaSaida.ProximoId = vet(1)
                chegadaSaida.movimentacao = vet(2)
                chegadaSaida.acao = vet(3)
                chegadaSaida.dataHora = vet(4)
                chegadaSaida.motivo = vet(5)
                chegadaSaida.SituacaoAtual = vet(6)
                chegadaSaida.motivoCancelamento = vet(7)
                chegadaSaida.caladoVante = vet(8)
                chegadaSaida.caladoRe = vet(9)
                chegadaSaida.manobraPratico = vet(10)
                chegadaSaida.motivoNaoManobraPratico = vet(11)
                chegadaSaida.observacao = vet(12)
                chegadaSaida.dataHoraRegistro = vet(13)
                chegadaSaida.Responsavel = vet(14)
                chegadaSaida.PerfilResponsavel = vet(15)
                chegadaSaida.observacao = vet(16)
                chegadaSaida.local = vet(17)
                chegadaSaida.distanciaVante = vet(18)
                chegadaSaida.distanciaRe = vet(19)
                ' id += linha


                If (chegadaSaida.numeroDuv <> "") And ((chegadaSaida.id <> "") Or (chegadaSaida.id <> " ")) Then
                    chegadaSaidaBLL.Inserirchegadasaida(chegadaSaida)
                    retorno += chegadaSaida.dataHora & "-" & chegadaSaida.acao & vbCrLf

                End If
                'retorno += vet.ToString
            End If
        Next

        Return retorno
    End Function

    Private Function GravaTabelachegadaSaidadadosDuv(Dados As String, duv As String) As String
        Dim id As Integer = 0
        '  Dim DUV As String = DUV
        Dim retorno As String = ""


        'Do While srcsv.Peek >= 0
        'Loop
        'retorno = Dados
        Dim linha As String = Dados.Split(vbCrLf)(1)


        Dim chegadaSaidadados As New chegadasaidadadosDuvDTO
        chegadaSaidadados.numeroduv = duv
        chegadaSaidadados.porto = linha.Split(";")(0)
        chegadaSaidadados.NumeroImo = linha.Split(";")(1)
        chegadaSaidadados.NumeroInscricao = linha.Split(";")(2)
        chegadaSaidadados.NomeEmbarcacao = linha.Split(";")(3)
        chegadaSaidadados.Bandeira = linha.Split(";")(4)
        chegadaSaidadados.BandeiraCodigo = linha.Split(";")(5)
        chegadaSaidadados.TipoEmbarcacao = linha.Split(";")(6)
        chegadaSaidadados.indicativodechamadaIRIN = linha.Split(";")(7)
        chegadaSaidadados.ArqueacaoBruta = linha.Split(";")(8)
        chegadaSaidadados.NomeAfretador = linha.Split(";")(9)
        chegadaSaidadados.nomeSociedadeClassificadora = linha.Split(";")(10)
        chegadaSaidadados.paisescala = linha.Split(";")(11)
        chegadaSaidadados.paisescalaCodigo = linha.Split(";")(12)
        chegadaSaidadados.portosescala = linha.Split(";")(13)
        chegadaSaidadados.dataescala = linha.Split(";")(14)
        chegadaSaidadados.agencia = linha.Split(";")(15)
        chegadaSaidadados.cnpjgencia = linha.Split(";")(16)
        chegadaSaidadados.logradouro = linha.Split(";")(17)
        chegadaSaidadados.bairro = linha.Split(";")(18)
        chegadaSaidadados.cidade = linha.Split(";")(19)
        chegadaSaidadados.UF = linha.Split(";")(20)
        chegadaSaidadados.cep = linha.Split(";")(21)
        chegadaSaidadados.telefone = linha.Split(";")(22)
        chegadaSaidadados.email = linha.Split(";")(23)
        chegadaSaidadados.operadores = linha.Split(";")(24)
        chegadaSaidadados.cnpjOperadores = linha.Split(";")(25)

        Dim chegadaSaidadadosBLL As New chegadasaidadadosDuvBLL
        If (chegadaSaidadados.numeroduv <> "") And
           (chegadaSaidadados.NomeEmbarcacao <> "") Then

            id = chegadaSaidadadosBLL.InserirchegadasaidadadosDuv(chegadaSaidadados)
            retorno += chegadaSaidadados.numeroduv & "-" & chegadaSaidadados.NomeEmbarcacao


        End If

        'Return "entrou em GravaTabelachegadaSaidadadosDuv" & linha
        Return retorno
    End Function



    Private Function UnicodeBytesToString(ByVal bytes() As Byte) As String
        Return System.Text.Encoding.UTF8.GetString(bytes)
    End Function

End Module
