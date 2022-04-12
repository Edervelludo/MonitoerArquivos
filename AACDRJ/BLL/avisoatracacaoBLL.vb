
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class avisoatracacaoBLL

        Public Function Inseriravisoatracacao(ByVal avisoatracacao As avisoatracacaoDTO) As Integer

            Dim da As New avisoatracacaoDAL

            Dim id As Integer = 0

            Try

                da.delete(avisoatracacao.numeroDuv)
                da.insert(avisoatracacao)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        Public Function SelecionaavisoatracacaoDUV(ByVal DUV As String) As avisoatracacaoDTO

            Dim avisoDAL As New avisoatracacaoDAL
            Dim avisoDTO As New avisoatracacaoDTO

            Dim avisoDatable As DataTable = avisoDAL.SelecionaavisoatracacaoDUV(DUV)





            Try
                avisoDTO.numeroDuv = avisoDatable.Rows(0).Item("numeroDuv")
                avisoDTO.dataHoraEsperada = avisoDatable.Rows(0).Item("dataHoraEsperada")
                avisoDTO.cargaPerigosa = avisoDatable.Rows(0).Item("cargaPerigosa")
                avisoDTO.pesoCarga = avisoDatable.Rows(0).Item("pesoCarga")
                avisoDTO.qtdeConteineres = avisoDatable.Rows(0).Item("qtdeConteineres")




            Catch ex As Exception

            End Try
            Return avisoDTO
        End Function



    End Class

End Namespace
