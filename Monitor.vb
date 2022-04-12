Imports System.IO
Imports System.IO.Compression
Imports System.ServiceProcess

Public Class Monitor
    Dim WithEvents MonitorArquivos As New FileSystemWatcher()
    'Dim log As StreamWriter = New IO.StreamWriter("C:\MonitorArquivosPSP\log.txt", True) 'retornaArquivoLOG()

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Adicione código aqui para iniciar seu serviço. Este método deve ajustar
        ' o que é necessário para que seu serviço possa executar seu trabalho.
        'New-Item -ItemType SymbolicLink -Name duvs_xmls -Target C:\PSPMonitorXML\DuvFiles\


        MonitorArquivos.Path = LeParametros("CAMINHO_FONTE")
        MonitorArquivos.IncludeSubdirectories = If(LeParametros("SUBDIRETORIOS") = "true", True, False)       ' Monitora subdiretorios
        MonitorArquivos.Filter = LeParametros("FILTRO")                                          ' Monitora somente arquivos XML
        ' Inclui mudança em atributos a lista de mudanças que pode disparar eventos de notificação
        MonitorArquivos.NotifyFilter = NotifyFilters.FileName Or NotifyFilters.CreationTime Or NotifyFilters.Size Or NotifyFilters.LastAccess  'Or NotifyFilters.LastAccess 'Or NotifyFilters.DirectoryName
        ' Permite a notificação de eventos
        MonitorArquivos.EnableRaisingEvents = True
    End Sub

    Private Sub MonitorarEventos(ByVal sender As Object, ByVal e As FileSystemEventArgs) Handles MonitorArquivos.Changed, MonitorArquivos.Created, MonitorArquivos.Deleted

        Using Log As TextWriter = retornaArquivoLOG()

            'All         15 	A criação, exclusão, alteração ou a renomeação de um arquivo ou uma pasta.
            'Changed     4	A alteração de um arquivo ou uma pasta. 
            '            Os tipos de alterações incluem: alterações de tamanho, atributos,
            '            configurações de segurança, última gravação e hora do último acesso.
            'Created     1 	A criação de um arquivo ou uma pasta.
            'Deleted     2 	A exclusão de um arquivo ou uma pasta.
            'Renamed     8 	A renomeação de um arquivo ou uma pasta.

            'Process.Start("c:\AtualizaAISCash\AtualizaNavios.exe")
            Dim textoretorno As String = ""
            If (e.ChangeType = 4) Or (e.ChangeType = 1) Then


                If e.Name.Contains("_AACDRJ_") Then

                    'Using arq_erros As System.IO.StreamWriter = retornaArquivoErro()

                    textoretorno = GravarAACDRJ(e.FullPath)
                    Log.WriteLine("Arquivo alterado: " & e.Name & " - " & " Evento : " & e.ChangeType & " - " & DateTime.Now & "->" & textoretorno & " " & Microsoft.VisualBasic.Chr(10) & "")

                    'End Using


                End If


                If e.Name.Contains("CHEGADASAIDA") Then

                    If (e.ChangeType = 1) Then


                        textoretorno = GravarCHEGADASAIDA(e.FullPath)
                        Log.WriteLine("Arquivo alterado: " & e.Name & " - " & " Evento : " & e.ChangeType & " - " & DateTime.Now & "->" & textoretorno & " " & Microsoft.VisualBasic.Chr(10) & "")

                    End If
                End If


                If e.Name.Contains("_DE_") Then


                    textoretorno = GravarDE(e.FullPath)
                    Log.WriteLine("Arquivo alterado: " & e.Name & " - " & " Evento : " & e.ChangeType & " - " & DateTime.Now & "->" & textoretorno & " " & Microsoft.VisualBasic.Chr(10) & "")

                End If




                Log.Close()
                Log.Dispose()


            End If





        End Using


    End Sub

    Protected Overrides Sub OnStop()
        ' Adicione código aqui para realizar qualquer limpeza necessária para parar seu serviço.

        MonitorArquivos.Dispose()
    End Sub





End Class
