
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class TipofaturamentoOperadorBLL

        Public Function Inserirtiposfaturamentooperador(ByVal tfop As tipoFaturamentoOperadorDTO) As Integer

            Dim da As New tipoFaturamentoOperadorDAL

            Dim id As Integer = 0

            Try
                da.delete(tfop.numeroDUV)
                da.insert(tfop)



                id = 1




            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        Public Function SelecionatipofaturamentooperadorDUV(ByVal DUV As String) As tipoFaturamentoOperadorDTO()

            Dim tfopDAL As New tipoFaturamentoOperadorDAL
            Dim tfopDTO As New tipoFaturamentoOperadorDTO

            Dim tfopdatatable As DataTable = tfopDAL.SelecionatipoFaturamentoOperadorDUV(DUV)

            Dim i As Integer = 0

            Dim tfopsDTO(tfopdatatable.Rows.Count) As tipoFaturamentoOperadorDTO





            Try

                For Each linha As DataRow In tfopdatatable.Rows


                    tfopDTO.numeroDUV = linha.Item("numeroDuv")
                    tfopDTO.tipoFaturamentoOperador = linha.Item("tipoFaturamentoOperador")



                    tfopsDTO(i) = tfopDTO
                    i = i + 1
                Next




            Catch ex As Exception

            End Try
            Return tfopsDTO
        End Function

        Sub delete(DUV As Integer)

            Dim tfopDAL As New tipoFaturamentoOperadorDAL


            Try

                tfopDAL.delete(DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub



    End Class

End Namespace
