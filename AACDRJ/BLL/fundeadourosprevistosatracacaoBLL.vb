
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class fundeadourosprevistosatracacaoBLL

        Public Function Inserirfundeadourosprevistosatracacao(ByVal fundat As fundeadourosprevistosatracacaoDTO) As Integer

            Dim da As New fundeadourosprevistosatracacaoDAL

            Dim id As Integer = 0

            Try

                da.delete(fundat.numeroDuv)
                da.insert(fundat)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function




        Public Function SelecionafundeadourosprevistosatracacaoDUV(ByVal DUV As String) As fundeadourosprevistosatracacaoDTO()

            Dim fundatDAL As New fundeadourosprevistosatracacaoDAL
            Dim fundatDTO As New fundeadourosprevistosatracacaoDTO

            Dim fundopoDatable As DataTable = fundatDAL.SelecionafundeadourosprevistosatracacaoDUV(DUV)
            Dim i As Integer = 0

            Dim fundatsDTO(fundopoDatable.Rows.Count) As fundeadourosprevistosatracacaoDTO


            Try



                For Each linha As DataRow In fundopoDatable.Rows

                    fundatDTO.numeroDuv = linha.Item("numeroDuv")
                    fundatDTO.fundeadouro = linha.Item("fundeadouro")
                    fundatDTO.boiaAmarracao = linha.Item("boiaAmarracao")


                    fundatsDTO(i) = fundatDTO
                    i = i + 1
                Next






            Catch ex As Exception

            End Try
            Return fundatsDTO
        End Function


        Sub delete(DUV As Integer)

            Dim fundatDAL As New fundeadourosprevistosatracacaoDAL


            Try

                fundatDAL.delete(DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub




    End Class

End Namespace
