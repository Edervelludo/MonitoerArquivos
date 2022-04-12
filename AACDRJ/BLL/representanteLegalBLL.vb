
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class representanteLegalBLL

        Public Function InserirrepresentanteLegal(ByVal representanteLegal As representanteLegalDTO) As Integer

            Dim da As New representanteLegalDAL

            Dim id As Integer = 0

            Try

                da.delete(representanteLegal.numeroDUV)
                da.insert(representanteLegal)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function




        Public Function SelecionarepresentanteLegalDUV(ByVal DUV As String) As representanteLegalDTO

            Dim representanteDAL As New representanteLegalDAL
            Dim representanteDTO As New representanteLegalDTO

            Dim representanteDatable As DataTable = representanteDAL.SelecionaRepresentanteLegalDUV(DUV)





            Try
                representanteDTO.nomeRepresentante = representanteDatable.Rows(0).Item("nomeRepresentante")
                representanteDTO.identificador = representanteDatable.Rows(0).Item("identificador")
                representanteDTO.numeroDUV = representanteDatable.Rows(0).Item("numeroDUV")



            Catch ex As Exception

            End Try
            Return representanteDTO
        End Function



    End Class

End Namespace
