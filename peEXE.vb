Imports System.IO
Imports MonitorArquivos.PE.DTO

Module peEXE

    Public Function GravarPE(ByVal args As String) As String

        Dim arquivo As String = args



        Dim Dados() As Byte
        Dim fs As FileStream = New FileStream(arquivo, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)

        Dados = br.ReadBytes(CType(fs.Length, Integer))

        'Console.WriteLine(GravaTabelasArquivoAACDRJ(Dados))

        Return GravaTabelasArquivoPE(Dados)

    End Function


    Public Function GravaTabelasArquivoPE(Dados As Byte()) As String
        Dim retorno As String = ""
        Dim xml As String = UnicodeBytesToString(Dados)

        Dim srXml As New System.IO.StringReader(xml)
        Dim dsXml As New DataSet
        dsXml.ReadXml(srXml)
        Dim DUV As String = ""

        For Each nome As DataTable In dsXml.Tables



            Select Case nome.TableName
                Case "fichaPrevisaoEstadia"
                    DUV = GravafichaPrevisaoEstadia(nome)
                    retorno += " fichaPrevisaoEstadia-> DUV:" & DUV
                    'Case "localPrevistoAtracacao"
                    '    retorno += " localPrevistoAtracacao-> DUV:" & DUV & "->" & GravalocaisPrevistosAtracacao(nome, DUV)


                Case Else

            End Select




        Next

        Return retorno
    End Function

    Private Function GravafichaPrevisaoEstadia(nome As DataTable) As String
        Return ""
    End Function

    Private Function UnicodeBytesToString(ByVal bytes() As Byte) As String
        Return System.Text.Encoding.UTF8.GetString(bytes)
    End Function

End Module
