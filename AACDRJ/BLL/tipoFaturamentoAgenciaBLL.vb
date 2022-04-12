
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class tipoFaturamentoAgenciaBLL

        Public Function InserirtipoFaturamentoAgencia(ByVal tfag As tipoFaturamentoAgenciaDTO) As Integer

            Dim da As New tipoFaturamentoAgenciaDAL

            Dim id As Integer = 0

            Try
                da.delete(tfag.numeroDUV)
                da.insert(tfag)



                id = 1




            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        Public Function SelecionatipoFaturamentoAgenciaDUV(ByVal DUV As String) As tipoFaturamentoAgenciaDTO()

            Dim tfagDAL As New tipoFaturamentoAgenciaDAL
            Dim tfagDTO As New tipoFaturamentoAgenciaDTO

            Dim tfopdatatable As DataTable = tfagDAL.SelecionatipoFaturamentoAgenciaDUV(DUV)

            Dim i As Integer = 0

            Dim tfagsDTO(tfopdatatable.Rows.Count) As tipoFaturamentoAgenciaDTO





            Try

                For Each linha As DataRow In tfopdatatable.Rows


                    tfagDTO.numeroDUV = linha.Item("numeroDuv")
                    tfagDTO.tipoFaturamentoAgencia = linha.Item("tipoFaturamentoAgencia")



                    tfagsDTO(i) = tfagDTO
                    i = i + 1
                Next




            Catch ex As Exception

            End Try
            Return tfagsDTO
        End Function

        Sub delete(DUV As Integer)

            Dim tfagDAL As New tipoFaturamentoAgenciaDAL


            Try

                tfagDAL.delete(DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub



    End Class

End Namespace
