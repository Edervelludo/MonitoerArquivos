
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class tipoFaturamentoRecebedorBLL

        Public Function InserirtipoFaturamentoRecebedor(ByVal tfag As tipoFaturamentoRecebedorDTO) As Integer

            Dim da As New tipoFaturamentoRecebedorDAL

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



        Public Function SelecionatipoFaturamentoRecebedorDUV(ByVal DUV As String) As tipoFaturamentoRecebedorDTO()

            Dim tfrcDAL As New tipoFaturamentoRecebedorDAL
            Dim tfrcDTO As New tipoFaturamentoRecebedorDTO

            Dim tfrcdatatable As DataTable = tfrcDAL.SelecionatipoFaturamentoRecebedorDUV(DUV)

            Dim i As Integer = 0

            Dim tfrcsDTO(tfrcdatatable.Rows.Count) As tipoFaturamentoRecebedorDTO





            Try

                For Each linha As DataRow In tfrcdatatable.Rows


                    tfrcDTO.numeroDUV = linha.Item("numeroDuv")
                    tfrcDTO.tipoFaturamentoRecebedor = linha.Item("tipoFaturamentoRecebedor")



                    tfrcsDTO(i) = tfrcDTO
                    i = i + 1
                Next




            Catch ex As Exception

            End Try
            Return tfrcsDTO
        End Function

        Sub delete(DUV As Integer)

            Dim tfarDAL As New tipoFaturamentoRecebedorDAL


            Try

                tfarDAL.delete(DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub



    End Class

End Namespace
