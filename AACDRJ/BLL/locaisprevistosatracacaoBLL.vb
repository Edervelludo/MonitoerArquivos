
Imports MonitorArquivos.AACDRJ.DTO
Imports MonitorArquivos.AACDRJ.DAL

Namespace AACDRJ.BLL
    Public Class locaisprevistosatracacaoBLL

        Public Function Inserirlocaisprevistosatracacao(ByVal locat As locaisprevistosatracacaoDTO) As Integer

            Dim da As New locaisprevistosatracacaoDAL

            Dim duv As String = ""

            'Try

            da.delete(locat.numeroDuv)
            da.insert(locat)
            duv = locat.numeroDuv

            ' Catch ex As Exception
            '    Throw ex
            'End Try
            Return duv
        End Function



        Public Function SelecionalocaisprevistosatracacaoDUV(ByVal DUV As String) As locaisprevistosatracacaoDTO()

            Dim locatDAL As New locaisprevistosatracacaoDAL
            Dim locatDTO As New locaisprevistosatracacaoDTO


            Dim locatDatable As DataTable = locatDAL.SelecionalocaisprevistosatracacaoDUV(DUV)
            Dim i As Integer = 0

            Dim locatsDTO(locatDatable.Rows.Count) As locaisprevistosatracacaoDTO


            Try

                For Each linha As DataRow In locatDatable.Rows


                    locatDTO.numeroDuv = linha.Item("numeroDuv")
                    locatDTO.areaPorto = linha.Item("areaPorto")
                    locatDTO.cnpjArrendatario = linha.Item("cnpjArrendatario")
                    locatDTO.berco = linha.Item("berco")

                    locatsDTO(i) = locatDTO
                    i = i + 1
                Next





            Catch ex As Exception

            End Try
            Return locatsDTO
        End Function

        Sub delete(DUV As Integer)
            Dim locatDAL As New locaisprevistosatracacaoDAL



            Try

                locatDAL.delete(DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub



    End Class

End Namespace
