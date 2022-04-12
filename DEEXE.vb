Imports System.IO
Imports MonitorArquivos.AACDRJ.BLL
Imports MonitorArquivos.DE.BLL
Imports MonitorArquivos.DE.DTO

Module DEEXE

    Public Function GravarDE(ByVal args As String) As String

        Dim arquivo As String = args



        Dim Dados() As Byte
        Dim fs As FileStream = New FileStream(arquivo, FileMode.Open, FileAccess.Read)
        Dim br As BinaryReader = New BinaryReader(fs)

        Dados = br.ReadBytes(CType(fs.Length, Integer))

        'Console.WriteLine(GravaTabelasArquivoAACDRJ(Dados))

        Return GravaTabelasArquivoDE(Dados)

    End Function


    Public Function GravaTabelasArquivoDE(Dados As Byte()) As String
        Dim retorno As String = ""
        Dim xml As String = UnicodeBytesToString(Dados)

        Dim srXml As New System.IO.StringReader(xml)
        Dim dsXml As New DataSet
        dsXml.ReadXml(srXml)
        Dim DUV As String = ""
        Dim cnpjAgencia As String = ""
        Dim numeroIMO As String = ""

        For Each nome As DataTable In dsXml.Tables



            Select Case nome.TableName
                Case "fichaDadosEmbarcacao"
                    DUV = GravafichaDadosEmbarcacao(nome)
                    retorno += " fichaDadosEmbarcacao-> DUV:" & DUV

                Case "agenteMaritimo"
                    cnpjAgencia = GravaDEagenteMaritimo(nome)
                    retorno += " agenteMaritima ->" & cnpjAgencia

                    'atualiza cnpjagencia -> fichaDadosEmbarcacao
                    retorno += " fichaDadosEmbarcacao AtualizacnpjAgenciaNavegacao_fichaDadosEmbarcacao ->" & AtualizacnpjAgenciaNavegacao_fichaDadosEmbarcacao(DUV, cnpjAgencia)


                Case "embarcacao"
                    numeroIMO = GravaDEembarcacao(nome)
                    retorno += " embarcacao ->" & numeroIMO

                    'atualiza numeroIMO -> fichaDadosEmbarcacao
                    retorno += " numeroIMO AtualizanumeroIMO_fichaDadosEmbarcacao ->" & AtualizanumeroIMO_fichaDadosEmbarcacao(DUV, numeroIMO)


                Case "caracteristicas"
                    numeroIMO = GravaDECaracteristicas(nome, numeroIMO)
                    retorno += " caracteristicas ->" & numeroIMO








                Case Else

            End Select




        Next

        Return retorno
    End Function

    Private Function GravaDECaracteristicas(nome As DataTable, numeroIMO As String) As String
        Dim id As Integer = 0
        Dim caracteristicas As New DEcaracteristicasDTO



        caracteristicas.numeroIMO = numeroIMO

        ' Largura -->
        If nome.Columns.Contains("largura") Then caracteristicas.largura = nome.Rows(0).Item("largura") Else caracteristicas.largura = ""

        ' Comprimento -->
        If nome.Columns.Contains("comprimento") Then caracteristicas.comprimento = nome.Rows(0).Item("comprimento") Else caracteristicas.comprimento = ""

        ' Altura -->
        If nome.Columns.Contains("altura") Then caracteristicas.altura = nome.Rows(0).Item("altura") Else caracteristicas.altura = ""

        ' Calado máximo -->
        If nome.Columns.Contains("caladoMaximo") Then caracteristicas.caladoMaximo = nome.Rows(0).Item("caladoMaximo") Else caracteristicas.caladoMaximo = ""

        ' Calado mínimo -->
        If nome.Columns.Contains("caladoMinimo") Then caracteristicas.caladoMinimo = nome.Rows(0).Item("caladoMinimo") Else caracteristicas.caladoMinimo = ""

        ' Capacidade máxima de água potável (m³) -->

        If nome.Columns.Contains("capacidadeMaximaAgua") Then caracteristicas.capacidadeMaximaAgua = nome.Rows(0).Item("capacidadeMaximaAgua") Else caracteristicas.capacidadeMaximaAgua = ""

        ' Arqueação bruta -->
        If nome.Columns.Contains("arqueacaoBruta") Then caracteristicas.arqueacaoBruta = nome.Rows(0).Item("arqueacaoBruta") Else caracteristicas.arqueacaoBruta = ""

        ' DWT (T) -->
        If nome.Columns.Contains("dwt") Then caracteristicas.dwt = nome.Rows(0).Item("dwt") Else caracteristicas.dwt = ""

        ' Capacidade de água de lastro -->
        If nome.Columns.Contains("capacidadeAguaLastro") Then caracteristicas.capacidadeAguaLastro = nome.Rows(0).Item("capacidadeAguaLastro") Else caracteristicas.capacidadeAguaLastro = ""

        ' Arqueação líquida -->
        If nome.Columns.Contains("arqueacaoLiquida") Then caracteristicas.arqueacaoLiquida = nome.Rows(0).Item("arqueacaoLiquida") Else caracteristicas.arqueacaoLiquida = ""

        ' Velocidade máxima -->
        If nome.Columns.Contains("velocidadeMaxima") Then caracteristicas.velocidadeMaxima = nome.Rows(0).Item("velocidadeMaxima") Else caracteristicas.velocidadeMaxima = ""

        ' Capacidade máxima de armazenamento dos efluentes sanitários (m³) -->
        If nome.Columns.Contains("capacidadeMaximaEfluentes") Then caracteristicas.capacidadeMaximaEfluentes = nome.Rows(0).Item("capacidadeMaximaEfluentes") Else caracteristicas.capacidadeMaximaEfluentes = ""

        ' Nº de cozinhas -->
        If nome.Columns.Contains("numeroCozinhas") Then caracteristicas.numeroCozinhas = nome.Rows(0).Item("numeroCozinhas") Else caracteristicas.numeroCozinhas = ""

        ' Nº de tanques de lastro -->
        If nome.Columns.Contains("numeroTanquesLastro") Then caracteristicas.numeroTanquesLastro = nome.Rows(0).Item("numeroTanquesLastro") Else caracteristicas.numeroTanquesLastro = ""

        ' Cor do casco -->
        If nome.Columns.Contains("corCasco") Then caracteristicas.corCasco = nome.Rows(0).Item("corCasco") Else caracteristicas.corCasco = ""

        ' Tipo do casco -->
        If nome.Columns.Contains("tipoCasco") Then caracteristicas.tipoCasco = nome.Rows(0).Item("tipoCasco") Else caracteristicas.tipoCasco = ""

        ' Cor da superestrutura -->
        If nome.Columns.Contains("corSuperestrutura") Then caracteristicas.corSuperestrutura = nome.Rows(0).Item("corSuperestrutura") Else caracteristicas.corSuperestrutura = ""

        ' Tipo da superestrutura -->
        If nome.Columns.Contains("tipoSuperestrutura") Then caracteristicas.tipoSuperestrutura = nome.Rows(0).Item("tipoSuperestrutura") Else caracteristicas.tipoSuperestrutura = ""

        ' Nº de câmaras refrigeradas -->
        If nome.Columns.Contains("camarasRefrigeradas") Then caracteristicas.camarasRefrigeradas = nome.Rows(0).Item("camarasRefrigeradas") Else caracteristicas.camarasRefrigeradas = ""

        ' Nº de leitos na enfermaria de bordo -->
        If nome.Columns.Contains("numeroLeitosHospital") Then caracteristicas.numeroLeitosHospital = nome.Rows(0).Item("numeroLeitosHospital") Else caracteristicas.numeroLeitosHospital = ""

        ' Nº de piscinas para adultos-->
        If nome.Columns.Contains("numeroPiscinaAdulto") Then caracteristicas.numeroPiscinaAdulto = nome.Rows(0).Item("numeroPiscinaAdulto") Else caracteristicas.numeroPiscinaAdulto = ""

        ' Nº de piscinas infantis-->
        If nome.Columns.Contains("numeroPiscinaInfantil") Then caracteristicas.numeroPiscinaInfantil = nome.Rows(0).Item("numeroPiscinaInfantil") Else caracteristicas.numeroPiscinaInfantil = ""

        ' Nº de restaurantes -->
        If nome.Columns.Contains("numeroRestaurantes") Then caracteristicas.numeroRestaurantes = nome.Rows(0).Item("numeroRestaurantes") Else caracteristicas.numeroRestaurantes = ""

        ' Nº de aparelhos de ar-condicionado -->
        If nome.Columns.Contains("unidadesArCondicionado") Then caracteristicas.unidadesArCondicionado = nome.Rows(0).Item("unidadesArCondicionado") Else caracteristicas.unidadesArCondicionado = ""

        ' Nº de banheiras de hidromassagem-->
        If nome.Columns.Contains("banheirasHidromassagem") Then caracteristicas.banheirasHidromassagem = nome.Rows(0).Item("banheirasHidromassagem") Else caracteristicas.banheirasHidromassagem = ""

        ' Nº de tanques de bordo -->
        If nome.Columns.Contains("totalTanques") Then caracteristicas.totalTanques = nome.Rows(0).Item("totalTanques") Else caracteristicas.totalTanques = ""

        ' Nº de porões da embarcação -->
        If nome.Columns.Contains("numeroPoroes") Then caracteristicas.numeroPoroes = nome.Rows(0).Item("numeroPoroes") Else caracteristicas.numeroPoroes = ""




        Dim avisoBLL As New DEcaracteristicasBLL
        If (caracteristicas.numeroIMO <> "") Then

            id = avisoBLL.InserirCaracteristicas(caracteristicas)
            Return caracteristicas.numeroIMO

        Else
            Return ""
        End If
    End Function

    Private Function AtualizanumeroIMO_fichaDadosEmbarcacao(dUV As String, numeroIMO As String) As String
        Dim id As Integer = 0

        Dim avisoBLL As New fichaDadosEmbarcacaoBLL


        If (dUV <> "") And
           (numeroIMO <> "") Then

            id = avisoBLL.AtualizaNumeroIMO(dUV, numeroIMO)
            Return id
        Else
            Return ""
        End If
    End Function

    Private Function GravaDEembarcacao(nome As DataTable) As String
        Dim id As Integer = 0
        Dim embarcacao As New DEembarcacaoDTO


        If nome.Columns.Contains("numeroIMO") Then embarcacao.numeroIMO = nome.Rows(0).Item("numeroIMO") Else embarcacao.numeroIMO = ""
        If nome.Columns.Contains("nomeEmbarcacao") Then embarcacao.nomeEmbarcacao = nome.Rows(0).Item("nomeEmbarcacao") Else embarcacao.nomeEmbarcacao = ""
        If nome.Columns.Contains("areaNavegacao") Then embarcacao.areaNavegacao = nome.Rows(0).Item("areaNavegacao") Else embarcacao.areaNavegacao = ""
        If nome.Columns.Contains("nomeSociedadeClassificacao") Then embarcacao.nomeSociedadeClassificacao = nome.Rows(0).Item("nomeSociedadeClassificacao") Else embarcacao.nomeSociedadeClassificacao = ""
        If nome.Columns.Contains("numeroInternacionalRegistro") Then embarcacao.numeroInternacionalRegistro = nome.Rows(0).Item("numeroInternacionalRegistro") Else embarcacao.numeroInternacionalRegistro = ""
        If nome.Columns.Contains("portariaHomologacaoHeliponto") Then embarcacao.portariaHomologacaoHeliponto = nome.Rows(0).Item("portariaHomologacaoHeliponto") Else embarcacao.portariaHomologacaoHeliponto = ""
        If nome.Columns.Contains("autonomiaRetencao") Then embarcacao.autonomiaRetencao = nome.Rows(0).Item("autonomiaRetencao") Else embarcacao.autonomiaRetencao = ""
        If nome.Columns.Contains("finalidade") Then embarcacao.finalidade = nome.Rows(0).Item("finalidade") Else embarcacao.finalidade = ""
        If nome.Columns.Contains("tipoEmbarcacao") Then embarcacao.tipoEmbarcacao = nome.Rows(0).Item("tipoEmbarcacao") Else embarcacao.tipoEmbarcacao = ""
        If nome.Columns.Contains("dataCertificadoRegistro") Then embarcacao.dataCertificadoRegistro = nome.Rows(0).Item("dataCertificadoRegistro") Else embarcacao.dataCertificadoRegistro = ""
        If nome.Columns.Contains("numeroProvisorioRegistro") Then embarcacao.numeroProvisorioRegistro = nome.Rows(0).Item("numeroProvisorioRegistro") Else embarcacao.numeroProvisorioRegistro = ""
        If nome.Columns.Contains("numeroPRPM") Then embarcacao.numeroPRPM = nome.Rows(0).Item("numeroPRPM") Else embarcacao.numeroPRPM = ""
        If nome.Columns.Contains("numeroTie") Then embarcacao.numeroTie = nome.Rows(0).Item("numeroTie") Else embarcacao.numeroTie = ""
        If nome.Columns.Contains("numeroPreps") Then embarcacao.numeroPreps = nome.Rows(0).Item("numeroPreps") Else embarcacao.numeroPreps = ""
        If nome.Columns.Contains("dataAdesaoPreps") Then embarcacao.dataAdesaoPreps = nome.Rows(0).Item("dataAdesaoPreps") Else embarcacao.dataAdesaoPreps = ""
        If nome.Columns.Contains("inscricao") Then embarcacao.inscricao = nome.Rows(0).Item("inscricao") Else embarcacao.inscricao = ""
        If nome.Columns.Contains("estadoBandeira") Then embarcacao.estadoBandeira = nome.Rows(0).Item("estadoBandeira") Else embarcacao.estadoBandeira = ""
        If nome.Columns.Contains("alturaBordaLivre") Then embarcacao.alturaBordaLivre = nome.Rows(0).Item("alturaBordaLivre") Else embarcacao.alturaBordaLivre = ""
        If nome.Columns.Contains("capacidadeEquipamentoBordaLivre") Then embarcacao.capacidadeEquipamentoBordaLivre = nome.Rows(0).Item("capacidadeEquipamentoBordaLivre") Else embarcacao.capacidadeEquipamentoBordaLivre = ""
        If nome.Columns.Contains("anoFabricacao") Then embarcacao.anoFabricacao = nome.Rows(0).Item("anoFabricacao") Else embarcacao.anoFabricacao = ""

        Dim embarcacaoBLL As New DEembarcacaoBLL

        id = embarcacaoBLL.InserirEmbarcacao(embarcacao)


        Return embarcacao.numeroIMO

    End Function


    Private Function AtualizacnpjAgenciaNavegacao_fichaDadosEmbarcacao(dUV As String, cnpjAgencia As String) As String
        Dim id As Integer = 0

        Dim avisoBLL As New fichaDadosEmbarcacaoBLL


        If (dUV <> "") And
           (cnpjAgencia <> "") Then

            id = avisoBLL.AtualizacnpjAgenciaNavegacao(dUV, cnpjAgencia)
            Return id
        Else
            Return ""
        End If
    End Function

    Private Function GravaDEagenteMaritimo(nome As DataTable) As String
        Dim id As Integer = 0
        Dim agenteMaritimo As New DEagenteMaritimoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)


        If nome.Columns.Contains("nomeAgencia") Then agenteMaritimo.nomeAgencia = nome.Rows(0).Item("nomeAgencia") Else agenteMaritimo.nomeAgencia = ""
        If nome.Columns.Contains("cnpjAgenciaNavegacao") Then agenteMaritimo.cnpjAgenciaNavegacao = nome.Rows(0).Item("cnpjAgenciaNavegacao") Else agenteMaritimo.cnpjAgenciaNavegacao = ""

        Dim avisoBLL As New DEagenteMaritimoBLL
        If (agenteMaritimo.nomeAgencia <> "") And
           (agenteMaritimo.cnpjAgenciaNavegacao <> "") Then

            id = avisoBLL.InseriragenteMaritimo(agenteMaritimo)
            Return agenteMaritimo.cnpjAgenciaNavegacao

        Else
            Return ""
        End If
    End Function

    Private Function GravafichaDadosEmbarcacao(nome As DataTable) As Integer
        Dim id As Integer = 0
        Dim fichaDadosEmbarcacao As New fichaDadosEmbarcacaoDTO

        'Console.WriteLine(nome.Columns.Contains("cnpjArrendatario").ToString)
        If nome.Columns.Contains("numeroDUV") Then fichaDadosEmbarcacao.numeroDUV = nome.Rows(0).Item("numeroDUV") Else fichaDadosEmbarcacao.numeroDUV = ""
        If nome.Columns.Contains("dataHoraPrevistaAtracacao") Then fichaDadosEmbarcacao.dataHoraPrevistaAtracacao = nome.Rows(0).Item("dataHoraPrevistaAtracacao") Else fichaDadosEmbarcacao.dataHoraPrevistaAtracacao = ""
        If nome.Columns.Contains("dataHoraPrevistaDesatracacao") Then fichaDadosEmbarcacao.dataHoraPrevistaDesatracacao = nome.Rows(0).Item("dataHoraPrevistaDesatracacao") Else fichaDadosEmbarcacao.dataHoraPrevistaDesatracacao = ""


        Dim fichaBLL As New fichaDadosEmbarcacaoBLL

        id = fichaBLL.InserirfichaDadosEmbarcacao(fichaDadosEmbarcacao)


        Return fichaDadosEmbarcacao.numeroDUV
    End Function







    Private Function UnicodeBytesToString(ByVal bytes() As Byte) As String
        Return System.Text.Encoding.UTF8.GetString(bytes)
    End Function

End Module
