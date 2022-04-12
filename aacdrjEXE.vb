Imports System.IO
Imports MonitorArquivos.AACDRJ.BLL
Imports MonitorArquivos.AACDRJ.DTO

Module aacdrjEXE

    Public Function GravarAACDRJ(ByVal args As String) As String

        Dim arquivo As String = args



        Dim Dados() As Byte
        Dim fs As FileStream = New FileStream(arquivo, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)

        Dados = br.ReadBytes(CType(fs.Length, Integer))

        'Console.WriteLine(GravaTabelasArquivoAACDRJ(Dados))

        Return GravaTabelasArquivoAACDRJ(Dados)

    End Function


    Public Function GravaTabelasArquivoAACDRJ(Dados As Byte()) As String
        Dim retorno As String = ""
        Dim xml As String = UnicodeBytesToString(Dados)

        Dim srXml As New System.IO.StringReader(xml)
        Dim dsXml As New DataSet
        dsXml.ReadXml(srXml)
        Dim DUV As String = ""

        For Each nome As DataTable In dsXml.Tables



            Select Case nome.TableName
                Case "fichaAvisoAtracacao"
                    DUV = GravaFichaAvisoAtracacao(nome)
                    retorno += " fichaAvisoAtracacao-> DUV:" & DUV
                Case "localPrevistoAtracacao"
                    retorno += " localPrevistoAtracacao-> DUV:" & DUV & "->" & GravalocaisPrevistosAtracacao(nome, DUV)
                Case "fundeadouroPrevistoAtracacao"
                    retorno += " fundeadouroPrevistoAtracacao-> DUV:" & DUV & "->" & GravafundeadouroPrevistoAtracacao(nome, DUV)
                Case "agenteMaritimo"
                    retorno += " agenteMaritimo-> DUV:" & DUV & "->" & GravaAgenteMaritimo(nome, DUV)
                Case "avisoAtracacao"
                    retorno += " avisoAtracacao-> DUV:" & DUV & "->" & GravaAvisoAtracacao(nome, DUV)
                Case "embarcacao"
                    retorno += " embarcacao-> DUV:" & DUV & "->" & Gravaembarcacao(nome, DUV)
                Case "estadiaEmbarcacao"
                    retorno += " estadiaEmbarcacao-> DUV:" & DUV & "->" & GravaestadiaEmbarcacao(nome, DUV)
                Case "representanteLegal"
                    retorno += " representanteLegal-> DUV:" & DUV & "->" & GravarepresentanteLegal(nome, DUV)
                Case "ratificacaoOperador"
                    retorno += " ratificacaoOperador-> DUV:" & DUV & "->" & GravarRatificacaoOperador(nome, DUV)
                Case "localOperacaoPorto"
                    retorno += " localOperacaoPorto-> DUV:" & DUV & "->" & GravarlocalOperacaoPorto(nome, DUV)
                Case "fundeadouroOperacaoPorto"
                    retorno += " fundeadouroOperacaoPorto-> DUV:" & DUV & "->" & GravarfundeadouroOperacaoPorto(nome, DUV)
                Case "tipoFaturamentoOperador"
                    retorno += " tipoFaturamentoOperador-> DUV:" & DUV & "->" & GravartipoFaturamentoOperador(nome, DUV)
                Case "tipoFaturamentoAgencia"
                    retorno += " tipoFaturamentoAgencia-> DUV:" & DUV & "->" & GravartipoFaturamentoAgencia(nome, DUV)
                Case "tipoFaturamentoArmador"
                    retorno += " tipoFaturamentoArmador-> DUV:" & DUV & "->" & GravartipoFaturamentoArmador(nome, DUV)
                Case "tipoFaturamentoRecebedor"
                    retorno += " tipoFaturamentoRecebedor-> DUV:" & DUV & "->" & GravartipoFaturamentoRecebedor(nome, DUV)

                Case Else

            End Select




        Next

        Return retorno
    End Function

    Private Function GravartipoFaturamentoRecebedor(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim tfrcdto As New tipoFaturamentoRecebedorDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        tfrcdto.numeroDUV = dUV
        If nome.Columns.Contains("tipoFaturamentoRecebedor") Then tfrcdto.tipoFaturamentoRecebedor = nome.Rows(0).Item("tipoFaturamentoRecebedor") Else tfrcdto.tipoFaturamentoRecebedor = ""




        Dim tfrcbll As New tipoFaturamentoRecebedorBLL
        If (tfrcdto.numeroDUV <> "") And
           (tfrcdto.tipoFaturamentoRecebedor <> "") Then

            id = tfrcbll.InserirtipoFaturamentoRecebedor(tfrcdto)
            Return tfrcdto.numeroDUV & "-" & tfrcdto.tipoFaturamentoRecebedor

        Else
            Return tfrcdto.numeroDUV & "-" & tfrcdto.tipoFaturamentoRecebedor & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravartipoFaturamentoArmador(nome As DataTable, dUV As String) As String

        Dim id As Integer = 0
        Dim tfardto As New tipoFaturamentoArmadorDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        tfardto.numeroDUV = dUV
        If nome.Columns.Contains("tipoFaturamentoArmador") Then tfardto.tipoFaturamentoArmador = nome.Rows(0).Item("tipoFaturamentoArmador") Else tfardto.tipoFaturamentoArmador = ""




        Dim tfarbll As New tipoFaturamentoArmadorBLL
        If (tfardto.numeroDUV <> "") And
           (tfardto.tipoFaturamentoArmador <> "") Then

            id = tfarbll.InserirtipoFaturamentoArmador(tfardto)
            Return tfardto.numeroDUV & "-" & tfardto.tipoFaturamentoArmador

        Else
            Return tfardto.numeroDUV & "-" & tfardto.tipoFaturamentoArmador & "- Não inserido DUV = """
        End If

    End Function

    Private Function GravartipoFaturamentoAgencia(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim tfagdto As New tipoFaturamentoAgenciaDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        tfagdto.numeroDUV = dUV
        If nome.Columns.Contains("tipoFaturamentoAgencia") Then tfagdto.tipoFaturamentoAgencia = nome.Rows(0).Item("tipoFaturamentoAgencia") Else tfagdto.tipoFaturamentoAgencia = ""




        Dim tfopbll As New tipoFaturamentoAgenciaBLL
        If (tfagdto.numeroDUV <> "") And
           (tfagdto.tipoFaturamentoAgencia <> "") Then

            id = tfopbll.InserirtipoFaturamentoAgencia(tfagdto)
            Return tfagdto.numeroDUV & "-" & tfagdto.tipoFaturamentoAgencia

        Else
            Return tfagdto.numeroDUV & "-" & tfagdto.tipoFaturamentoAgencia & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravartipoFaturamentoOperador(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim tfopdto As New tipoFaturamentoOperadorDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        tfopdto.numeroDUV = dUV
        If nome.Columns.Contains("tipoFaturamentoOperador") Then tfopdto.tipoFaturamentoOperador = nome.Rows(0).Item("tipoFaturamentoOperador") Else tfopdto.tipoFaturamentoOperador = ""




        Dim tfopbll As New TipofaturamentoOperadorBLL
        If (tfopdto.numeroDUV <> "") And
           (tfopdto.tipoFaturamentoOperador <> "") Then

            id = tfopbll.Inserirtiposfaturamentooperador(tfopdto)
            Return tfopdto.numeroDUV & "-" & tfopdto.tipoFaturamentoOperador

        Else
            Return tfopdto.numeroDUV & "-" & tfopdto.tipoFaturamentoOperador & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravarfundeadouroOperacaoPorto(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim localOP As New fundeadourosOperacaoPortoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        localOP.numeroDuv = dUV
        If nome.Columns.Contains("fundeadouro") Then localOP.fundeadouro = nome.Rows(0).Item("fundeadouro") Else localOP.fundeadouro = ""
        If nome.Columns.Contains("boiaAmarracao") Then localOP.boiaAmarracao = nome.Rows(0).Item("boiaAmarracao") Else localOP.boiaAmarracao = ""



        Dim locopBLL As New fundeadourosOperacaoPortoBLL
        If (localOP.numeroDuv <> "") And
           (localOP.fundeadouro <> "") And
           (localOP.boiaAmarracao <> "") Then

            id = locopBLL.InserirfundeadourosOperacaoPorto(localOP)
            Return localOP.fundeadouro & "-" & localOP.boiaAmarracao

        Else
            Return localOP.fundeadouro & "-" & localOP.boiaAmarracao & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravarlocalOperacaoPorto(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim localOP As New locaisOperacaoPortoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        localOP.numeroDuv = dUV
        If nome.Columns.Contains("areaPorto") Then localOP.areaPorto = nome.Rows(0).Item("areaPorto") Else localOP.areaPorto = ""
        If nome.Columns.Contains("berco") Then localOP.berco = nome.Rows(0).Item("berco") Else localOP.berco = ""
        If nome.Columns.Contains("cnpjArrendatario") Then localOP.cnpjArrendatario = nome.Rows(0).Item("cnpjArrendatario") Else localOP.cnpjArrendatario = ""



        Dim locopBLL As New locaisoperacaoportoBLL
        If (localOP.numeroDuv <> "") And
           (localOP.areaPorto <> "") And
           (localOP.cnpjArrendatario <> "") Then

            id = locopBLL.Inserirlocaisoperacaoporto(localOP)
            Return localOP.berco & "-" & localOP.areaPorto

        Else
            Return localOP.berco & "-" & localOP.areaPorto & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravarRatificacaoOperador(nome As DataTable, DUV As String) As String
        Dim id As Integer = 0
        Dim ratificacao As New ratificacaoOperadorDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        ratificacao.numeroDuv = DUV
        If nome.Columns.Contains("operador") Then ratificacao.operador = nome.Rows(0).Item("operador") Else ratificacao.operador = ""
        If nome.Columns.Contains("nomeOperador") Then ratificacao.nomeOperador = nome.Rows(0).Item("nomeOperador") Else ratificacao.nomeOperador = ""
        If nome.Columns.Contains("operacaoContratada") Then ratificacao.operacaoContratada = nome.Rows(0).Item("operacaoContratada") Else ratificacao.operacaoContratada = ""
        If nome.Columns.Contains("contratoCodesp") Then ratificacao.contratoCodesp = nome.Rows(0).Item("contratoCodesp") Else ratificacao.contratoCodesp = ""
        If nome.Columns.Contains("numeroContrato") Then ratificacao.numeroContrato = nome.Rows(0).Item("numeroContrato") Else ratificacao.numeroContrato = ""
        If nome.Columns.Contains("qtdePeriodos") Then ratificacao.qtdePeriodos = nome.Rows(0).Item("qtdePeriodos") Else ratificacao.qtdePeriodos = ""
        If nome.Columns.Contains("destinoProcedenciaCarga") Then ratificacao.destinoProcedenciaCarga = nome.Rows(0).Item("destinoProcedenciaCarga") Else ratificacao.destinoProcedenciaCarga = ""
        If nome.Columns.Contains("embalagem") Then ratificacao.embalagem = nome.Rows(0).Item("embalagem") Else ratificacao.embalagem = ""
        If nome.Columns.Contains("mercadoria") Then ratificacao.mercadoria = nome.Rows(0).Item("mercadoria") Else ratificacao.mercadoria = ""
        If nome.Columns.Contains("qtdeConteineres") Then ratificacao.qtdeConteineres = nome.Rows(0).Item("qtdeConteineres") Else ratificacao.qtdeConteineres = ""
        If nome.Columns.Contains("peso") Then ratificacao.peso = nome.Rows(0).Item("peso") Else ratificacao.peso = ""



        Dim ratificacaoBLL As New ratificacaooperadorBLL
        If (ratificacao.numeroDuv <> "") And
           (ratificacao.operador <> "") And
           (ratificacao.nomeOperador <> "") Then

            id = ratificacaoBLL.Inserirratificacaooperador(ratificacao)
            Return ratificacao.operador & "-" & ratificacao.nomeOperador

        Else
            Return ratificacao.operador & "-" & ratificacao.nomeOperador & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravarepresentanteLegal(nome As DataTable, DUV As String) As String
        Dim id As Integer = 0
        Dim representante As New representanteLegalDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        representante.numeroDUV = DUV
        If nome.Columns.Contains("identificador") Then representante.identificador = nome.Rows(0).Item("identificador") Else representante.identificador = ""
        If nome.Columns.Contains("nomeRepresentante") Then representante.nomeRepresentante = nome.Rows(0).Item("nomeRepresentante") Else representante.nomeRepresentante = ""

        Dim representanteBLL As New representanteLegalBLL
        If (representante.numeroDUV <> "") And
           (representante.identificador <> "") And
           (representante.nomeRepresentante <> "") Then

            id = representanteBLL.InserirrepresentanteLegal(representante)
            Return representante.nomeRepresentante & "-" & representante.identificador

        Else
            Return representante.nomeRepresentante & "-" & representante.identificador & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravaestadiaEmbarcacao(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim estadia As New estadiaEmbarcacaoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        estadia.numeroDuv = dUV
        If nome.Columns.Contains("prioridadePretendida") Then estadia.prioridadePretendida = nome.Rows(0).Item("prioridadePretendida") Else estadia.prioridadePretendida = ""
        If nome.Columns.Contains("qtdeDiasPrevistosOperacao") Then estadia.qtdeDiasPrevistosOperacao = nome.Rows(0).Item("qtdeDiasPrevistosOperacao") Else estadia.qtdeDiasPrevistosOperacao = ""
        If nome.Columns.Contains("numeroViagemAgencia") Then estadia.numeroViagemAgencia = nome.Rows(0).Item("numeroViagemAgencia") Else estadia.numeroViagemAgencia = ""
        If nome.Columns.Contains("tipoViagemOrigem") Then estadia.tipoViagemOrigem = nome.Rows(0).Item("tipoViagemOrigem") Else estadia.tipoViagemOrigem = ""
        If nome.Columns.Contains("tipoViagemDestino") Then estadia.tipoViagemDestino = nome.Rows(0).Item("tipoViagemDestino") Else estadia.tipoViagemDestino = ""
        If nome.Columns.Contains("tipoCarga") Then estadia.tipoCarga = nome.Rows(0).Item("tipoCarga") Else estadia.tipoCarga = ""
        If nome.Columns.Contains("quantidadeFlutuantes") Then estadia.quantidadeFlutuantes = nome.Rows(0).Item("quantidadeFlutuantes") Else estadia.quantidadeFlutuantes = ""
        If nome.Columns.Contains("quantidadePranchas") Then estadia.quantidadePranchas = nome.Rows(0).Item("quantidadePranchas") Else estadia.quantidadePranchas = ""
        If nome.Columns.Contains("terminal") Then estadia.terminal = nome.Rows(0).Item("terminal") Else estadia.terminal = ""


        Dim estadiabll As New estadiaEmbarcacaoBLL
        If (estadia.numeroDuv <> "") And
           (estadia.tipoViagemOrigem <> "") And
           (estadia.tipoCarga <> "") Then

            id = estadiabll.InserirestadiaEmbarcacao(estadia)
            Return estadia.numeroDuv

        Else
            Return estadia.numeroDuv & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravaEmbarcacao(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim embarcacao As New embarcacaoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        embarcacao.numeroDUV = dUV
        If nome.Columns.Contains("numeroIMO") Then embarcacao.numeroIMO = nome.Rows(0).Item("numeroIMO") Else embarcacao.numeroIMO = ""
        If nome.Columns.Contains("inscricao") Then embarcacao.inscricao = nome.Rows(0).Item("inscricao") Else embarcacao.inscricao = ""
        If nome.Columns.Contains("nomeEmbarcacao") Then embarcacao.nomeEmbarcacao = nome.Rows(0).Item("nomeEmbarcacao") Else embarcacao.nomeEmbarcacao = ""
        If nome.Columns.Contains("estadoBandeira") Then embarcacao.estadoBandeira = nome.Rows(0).Item("estadoBandeira") Else embarcacao.estadoBandeira = ""
        If nome.Columns.Contains("caladoMaximo") Then embarcacao.caladoMaximo = nome.Rows(0).Item("caladoMaximo") Else embarcacao.nomeEmbarcacao = ""
        If nome.Columns.Contains("caladoEntradaProa") Then embarcacao.caladoEntradaProa = nome.Rows(0).Item("caladoEntradaProa") Else embarcacao.caladoEntradaProa = ""
        If nome.Columns.Contains("caladoEntradaPopa") Then embarcacao.caladoEntradaPopa = nome.Rows(0).Item("caladoEntradaPopa") Else embarcacao.caladoEntradaPopa = ""
        If nome.Columns.Contains("caladoSaidaProa") Then embarcacao.caladoEntradaProa = nome.Rows(0).Item("caladoEntradaProa") Else embarcacao.caladoEntradaProa = ""
        If nome.Columns.Contains("caladoSaidaPopa") Then embarcacao.caladoEntradaPopa = nome.Rows(0).Item("caladoEntradaPopa") Else embarcacao.caladoEntradaPopa = ""


        Dim avisoBLL As New embarcacaoBLL
        If (embarcacao.numeroDUV <> "") And
           (embarcacao.nomeEmbarcacao <> "") And
           (embarcacao.numeroIMO <> "") Then

            id = avisoBLL.InserirEmbarcacao(embarcacao)
            Return embarcacao.numeroIMO & "-" & embarcacao.nomeEmbarcacao

        Else
            Return embarcacao.numeroIMO & "-" & embarcacao.nomeEmbarcacao & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravaAvisoAtracacao(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim avisoatracacao As New avisoatracacaoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        avisoatracacao.numeroDuv = dUV
        If nome.Columns.Contains("dataHoraEsperada") Then avisoatracacao.dataHoraEsperada = nome.Rows(0).Item("dataHoraEsperada") Else avisoatracacao.dataHoraEsperada = ""
        If nome.Columns.Contains("cargaPerigosa") Then avisoatracacao.cargaPerigosa = nome.Rows(0).Item("cargaPerigosa") Else avisoatracacao.cargaPerigosa = ""
        If nome.Columns.Contains("qtdeConteineres") Then avisoatracacao.qtdeConteineres = nome.Rows(0).Item("qtdeConteineres") Else avisoatracacao.qtdeConteineres = ""
        If nome.Columns.Contains("pesoCarga") Then avisoatracacao.pesoCarga = nome.Rows(0).Item("pesoCarga") Else avisoatracacao.pesoCarga = ""




        Dim avisoBLL As New avisoatracacaoBLL
        If (avisoatracacao.numeroDuv <> "") And
           (avisoatracacao.dataHoraEsperada <> "") And
           (avisoatracacao.cargaPerigosa <> "") Then

            id = avisoBLL.Inseriravisoatracacao(avisoatracacao)
            Return avisoatracacao.dataHoraEsperada & "-" & avisoatracacao.cargaPerigosa

        Else
            Return avisoatracacao.dataHoraEsperada & "-" & avisoatracacao.cargaPerigosa & "- Não inserido DUV = """
        End If
    End Function

    Private Function GravaAgenteMaritimo(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim agenteMaritimo As New agenteMaritimoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        agenteMaritimo.numeroDUV = dUV
        If nome.Columns.Contains("nomeAgencia") Then agenteMaritimo.nomeAgencia = nome.Rows(0).Item("nomeAgencia") Else agenteMaritimo.nomeAgencia = ""
        If nome.Columns.Contains("cnpjAgenciaNavegacao") Then agenteMaritimo.cnpjAgenciaNavegacao = nome.Rows(0).Item("cnpjAgenciaNavegacao") Else agenteMaritimo.cnpjAgenciaNavegacao = ""

        Dim avisoBLL As New agenteMaritimoBLL
        If (agenteMaritimo.numeroDUV <> "") And
           (agenteMaritimo.nomeAgencia <> "") And
           (agenteMaritimo.cnpjAgenciaNavegacao <> "") Then

            id = avisoBLL.InseriragenteMaritimo(agenteMaritimo)
            Return agenteMaritimo.nomeAgencia & "-" & agenteMaritimo.cnpjAgenciaNavegacao

        Else
            Return agenteMaritimo.nomeAgencia & "-" & agenteMaritimo.cnpjAgenciaNavegacao & "- Não inserido DUV = """
        End If

    End Function

    Private Function GravafundeadouroPrevistoAtracacao(nome As DataTable, dUV As String) As String
        Dim id As Integer = 0
        Dim fundeadouroPrevistoAtracacao As New fundeadourosprevistosatracacaoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        fundeadouroPrevistoAtracacao.numeroDuv = dUV
        If nome.Columns.Contains("fundeadouro") Then fundeadouroPrevistoAtracacao.fundeadouro = nome.Rows(0).Item("fundeadouro") Else fundeadouroPrevistoAtracacao.fundeadouro = ""
        If nome.Columns.Contains("boiaAmarracao") Then fundeadouroPrevistoAtracacao.boiaAmarracao = nome.Rows(0).Item("boiaAmarracao") Else fundeadouroPrevistoAtracacao.boiaAmarracao = ""

        Dim avisoBLL As New fundeadourosprevistosatracacaoBLL
        If (fundeadouroPrevistoAtracacao.numeroDuv <> "") And
           (fundeadouroPrevistoAtracacao.fundeadouro <> "") And
           (fundeadouroPrevistoAtracacao.boiaAmarracao <> "") Then

            id = avisoBLL.Inserirfundeadourosprevistosatracacao(fundeadouroPrevistoAtracacao)
            Return fundeadouroPrevistoAtracacao.fundeadouro & "-" & fundeadouroPrevistoAtracacao.boiaAmarracao

        Else
            Return fundeadouroPrevistoAtracacao.fundeadouro & "-" & fundeadouroPrevistoAtracacao.boiaAmarracao & "-Não inserido DUV = """
        End If


    End Function

    Private Function GravalocaisPrevistosAtracacao(nome As DataTable, duv As String) As String
        Dim id As Integer = 0
        Dim locaisPrevistosAtracacao As New locaisPrevistosAtracacaoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        locaisPrevistosAtracacao.numeroDuv = duv
        If nome.Columns.Contains("areaPorto") Then locaisPrevistosAtracacao.areaPorto = nome.Rows(0).Item("areaPorto") Else locaisPrevistosAtracacao.areaPorto = ""
        If nome.Columns.Contains("berco") Then locaisPrevistosAtracacao.berco = nome.Rows(0).Item("berco") Else locaisPrevistosAtracacao.berco = ""
        If nome.Columns.Contains("cnpjArrendatario") Then locaisPrevistosAtracacao.cnpjArrendatario = nome.Rows(0).Item("cnpjArrendatario") Else locaisPrevistosAtracacao.cnpjArrendatario = ""

        Dim avisoBLL As New locaisprevistosatracacaoBLL
        If (locaisPrevistosAtracacao.numeroDuv <> "") And
           (locaisPrevistosAtracacao.berco <> "") And
           (locaisPrevistosAtracacao.areaPorto <> "") Then

            id = avisoBLL.Inserirlocaisprevistosatracacao(locaisPrevistosAtracacao)
            Return locaisPrevistosAtracacao.berco & "-" & locaisPrevistosAtracacao.areaPorto

        Else
            Return locaisPrevistosAtracacao.berco & "-" & locaisPrevistosAtracacao.areaPorto & "-Não inserido DUV = """
        End If




    End Function

    Private Function GravaFichaAvisoAtracacao(nome As DataTable) As Integer
        Dim id As Integer = 0
        Dim fichaAvisoAtracacao As New fichaavisoatracacaoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        If nome.Columns.Contains("numeroDUV") Then fichaAvisoAtracacao.numeroDuv = nome.Rows(0).Item("numeroDUV") Else fichaAvisoAtracacao.numeroDuv = ""
        If nome.Columns.Contains("assumeEstadia") Then fichaAvisoAtracacao.assumeEstadia = nome.Rows(0).Item("assumeEstadia") Else fichaAvisoAtracacao.assumeEstadia = ""
        If nome.Columns.Contains("cnpjArrendatario") Then fichaAvisoAtracacao.cnpjArrendatario = nome.Rows(0).Item("cnpjArrendatario") Else fichaAvisoAtracacao.cnpjArrendatario = ""
        If nome.Columns.Contains("dataHoraAssumirEstadia") Then fichaAvisoAtracacao.dataHoraAssumirEstadia = CDate(nome.Rows(0).Item("dataHoraAssumirEstadia")) Else fichaAvisoAtracacao.dataHoraAssumirEstadia = ""
        If nome.Columns.Contains("dataHoraPrevistaAtracacao") Then fichaAvisoAtracacao.dataHoraPrevistaAtracacao = CDate(nome.Rows(0).Item("dataHoraPrevistaAtracacao")) Else fichaAvisoAtracacao.dataHoraPrevistaAtracacao = ""
        If nome.Columns.Contains("dataHoraPrevistaDesatracacao") Then fichaAvisoAtracacao.dataHoraPrevistaDesatracacao = CDate(nome.Rows(0).Item("dataHoraPrevistaDesatracacao")) Else fichaAvisoAtracacao.dataHoraPrevistaDesatracacao = ""
        If nome.Columns.Contains("dataHoraSistema") Then fichaAvisoAtracacao.dataHoraSistema = CDate(nome.Rows(0).Item("dataHoraSistema")) Else fichaAvisoAtracacao.dataHoraSistema = ""
        If nome.Columns.Contains("duracaoInferior24h") Then fichaAvisoAtracacao.duracaoInferior24h = nome.Rows(0).Item("duracaoInferior24h") Else fichaAvisoAtracacao.duracaoInferior24h = ""
        If nome.Columns.Contains("portoEstadia") Then fichaAvisoAtracacao.portoEstadia = nome.Rows(0).Item("portoEstadia") Else fichaAvisoAtracacao.portoEstadia = ""
        If nome.Columns.Contains("proximoPortoEscala") Then fichaAvisoAtracacao.proximoPortoEscala = nome.Rows(0).Item("proximoPortoEscala") Else fichaAvisoAtracacao.proximoPortoEscala = ""
        If nome.Columns.Contains("ultimoPortoEscala") Then fichaAvisoAtracacao.ultimoPortoEscala = nome.Rows(0).Item("ultimoPortoEscala") Else fichaAvisoAtracacao.ultimoPortoEscala = ""
        fichaAvisoAtracacao.datagravacao = DateTime.Now
        Dim fichaBLL As New fichaAvisoAtracacaoBLL

        id = fichaBLL.InserirfichaAvisoAtracacao(fichaAvisoAtracacao)


        Return fichaAvisoAtracacao.numeroDuv
    End Function

    Private Function UnicodeBytesToString(ByVal bytes() As Byte) As String
        Return System.Text.Encoding.UTF8.GetString(bytes)
    End Function

End Module
