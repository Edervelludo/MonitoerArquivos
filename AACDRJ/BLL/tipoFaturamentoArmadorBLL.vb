
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class tipoFaturamentoArmadorBLL

        Public Function InserirtipoFaturamentoArmador(ByVal tfag As tipoFaturamentoArmadorDTO) As Integer

            Dim da As New tipoFaturamentoArmadorDAL

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



        Public Function SelecionatipoFaturamentoArmadorDUV(ByVal DUV As String) As tipoFaturamentoArmadorDTO()

            Dim tfarDAL As New tipoFaturamentoArmadorDAL
            Dim tfarDTO As New tipoFaturamentoArmadorDTO

            Dim tfardatatable As DataTable = tfarDAL.SelecionatipoFaturamentoArmadorDUV(DUV)

            Dim i As Integer = 0

            Dim tfarsDTO(tfardatatable.Rows.Count) As tipoFaturamentoArmadorDTO





            Try

                For Each linha As DataRow In tfardatatable.Rows


                    tfarDTO.numeroDUV = linha.Item("numeroDuv")
                    tfarDTO.tipoFaturamentoArmador = linha.Item("tipoFaturamentoArmador")



                    tfarsDTO(i) = tfarDTO
                    i = i + 1
                Next




            Catch ex As Exception

            End Try
            Return tfarsDTO
        End Function

        Sub delete(DUV As Integer)

            Dim tfarDAL As New tipoFaturamentoArmadorDAL


            Try

                tfarDAL.delete(DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub



    End Class

End Namespace
