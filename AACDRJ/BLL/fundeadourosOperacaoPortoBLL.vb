
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class fundeadourosOperacaoPortoBLL

        Public Function InserirfundeadourosOperacaoPorto(ByVal fundop As fundeadourosOperacaoPortoDTO) As Integer

            Dim da As New fundeadourosOperacaoPortoDAL

            Dim id As Integer = 0

            Try
                da.delete(fundop.numeroDuv)
                da.insert(fundop)



                id = 1




            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        Public Function SelecionafundeadourosOperacaoPortoDUV(ByVal DUV As String) As fundeadourosOperacaoPortoDTO()

            Dim fundopDAL As New fundeadourosOperacaoPortoDAL
            Dim fundopDTO As New fundeadourosOperacaoPortoDTO

            Dim fundopoDatable As DataTable = fundopDAL.SelecionafundeadourosOperacaoPortoDUV(DUV)

            Dim i As Integer = 0

            Dim fundopsDTO(fundopoDatable.Rows.Count) As fundeadourosOperacaoPortoDTO




            Try

                For Each linha As DataRow In fundopoDatable.Rows


                    fundopDTO.numeroDuv = linha.Item("numeroDuv")
                    fundopDTO.boiaAmarracao = linha.Item("boiaAmarracao")
                    fundopDTO.fundeadouro = linha.Item("fundeadouro")


                    fundopsDTO(i) = fundopDTO
                    i = i + 1
                Next




            Catch ex As Exception

            End Try
            Return fundopsDTO
        End Function

        Sub delete(DUV As Integer)

            Dim fundopDAL As New fundeadourosOperacaoPortoDAL


            Try

                fundopDAL.delete(DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub



    End Class

End Namespace
