
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class locaisoperacaoportoBLL

        Public Function Inserirlocaisoperacaoporto(ByVal locop As locaisoperacaoportoDTO) As Integer

            Dim da As New locaisoperacaoportoDAL

            Dim id As Integer = 0

            Try

                da.delete(locop.numeroDuv)
                da.insert(locop)



                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        Public Function SelecionalocaisoperacaoportoDUV(ByVal DUV As String) As locaisoperacaoportoDTO()

            Dim locopDAL As New locaisoperacaoportoDAL
            Dim locopDTO As New locaisoperacaoportoDTO


            Dim locopDatable As DataTable = locopDAL.SelecionalocaisoperacaoportoDUV(DUV)
            Dim i As Integer = 0

            Dim locopsDTO(locopDatable.Rows.Count) As locaisoperacaoportoDTO


            Try

                For Each linha As DataRow In locopDatable.Rows


                    locopDTO.numeroDuv = linha.Item("numeroDuv")
                    locopDTO.areaPorto = linha.Item("areaPorto")
                    locopDTO.cnpjArrendatario = linha.Item("cnpjArrendatario")
                    locopDTO.berco = linha.Item("berco")

                    locopsDTO(i) = locopDTO
                    i = i + 1
                Next





            Catch ex As Exception

            End Try
            Return locopsDTO
        End Function

        Sub delete(DUV As Integer)
            Dim locopsDAL As New locaisoperacaoportoDAL


            Try

                locopsDAL.delete(DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub



    End Class

End Namespace
