
Imports MonitorArquivos.MANIFESTO.DTO
Imports MonitorArquivos.MANIFESTO.DAL

Namespace MANIFESTO.BLL
    Public Class conhecimentosEmbarqueBLL

        Public Function InserirconhecimentosEmbarque(ByVal conhecimento As conhecimentosEmbarqueDTO) As Integer

            Dim da As New conhecimentosEmbarqueDAL


            Dim id As Integer = 0

            Try

                'da.delete(locat.id_loc_atrac)
                da.insert(conhecimento)
                id = 1

            Catch ex As Exception
                Throw ex
            End Try
            Return id
        End Function



        Public Function SelecionaconhecimentosEmbarqueManifesto(ByVal num_manifesto As String) As conhecimentosEmbarqueDTO()

            Dim conhecimentoDAL As New conhecimentosEmbarqueDAL
            Dim conhecimentoDTO As New conhecimentosEmbarqueDTO


            Dim conhecimentosDatable As DataTable = conhecimentoDAL.SelecionaconhecimentoEmbarqueManifesto(num_manifesto)
            Dim i As Integer = 0

            Dim conhecimentoDTOs(conhecimentosDatable.Rows.Count) As conhecimentosEmbarqueDTO


            Try

                For Each linha As DataRow In conhecimentosDatable.Rows

                    conhecimentoDTO.idman_conhecimentosEmbarque = linha.Item("idman_conhecimentosEmbarque")
                    conhecimentoDTO.num_manifesto = linha.Item("num_manifesto")
                    conhecimentoDTO.num_bl = linha.Item("num_bl")
                    conhecimentoDTO.num_CE_mercante = linha.Item("num_CE_mercante")
                    conhecimentoDTO.dt_emissao = linha.Item("dt_emissao")
                    conhecimentoDTO.tipo_conhecimento = linha.Item("tipo_conhecimento")
                    conhecimentoDTO.consignatario = linha.Item("consignatario")
                    conhecimentoDTO.num_duv = linha.Item("num_duv")





                    conhecimentoDTOs(i) = conhecimentoDTO
                    i = i + 1
                Next





            Catch ex As Exception

            End Try
            Return conhecimentoDTOs
        End Function

        Public Function SelecionaconhecimentosEmbarqueBL(ByVal num_bl As String) As conhecimentosEmbarqueDTO()

            Dim conhecimentoDAL As New conhecimentosEmbarqueDAL
            Dim conhecimentoDTO As New conhecimentosEmbarqueDTO


            Dim conhecimentosDatable As DataTable = conhecimentoDAL.SelecionaconhecimentoEmbarqueBL(num_bl)
            Dim i As Integer = 0

            Dim conhecimentoDTOs(conhecimentosDatable.Rows.Count) As conhecimentosEmbarqueDTO


            Try

                For Each linha As DataRow In conhecimentosDatable.Rows

                    conhecimentoDTO.idman_conhecimentosEmbarque = linha.Item("idman_conhecimentosEmbarque")
                    conhecimentoDTO.num_manifesto = linha.Item("num_manifesto")
                    conhecimentoDTO.num_bl = linha.Item("num_bl")
                    conhecimentoDTO.num_CE_mercante = linha.Item("num_CE_mercante")
                    conhecimentoDTO.dt_emissao = linha.Item("dt_emissao")
                    conhecimentoDTO.tipo_conhecimento = linha.Item("tipo_conhecimento")
                    conhecimentoDTO.consignatario = linha.Item("consignatario")
                    conhecimentoDTO.num_duv = linha.Item("num_duv")




                    conhecimentoDTOs(i) = conhecimentoDTO
                    i = i + 1
                Next





            Catch ex As Exception

            End Try
            Return conhecimentoDTOs
        End Function

        Public Function SelecionaconhecimentosEmbarqueCE(ByVal num_CE_mercante As String) As conhecimentosEmbarqueDTO()

            Dim conhecimentoDAL As New conhecimentosEmbarqueDAL
            Dim conhecimentoDTO As New conhecimentosEmbarqueDTO


            Dim conhecimentosDatable As DataTable = conhecimentoDAL.SelecionaconhecimentoEmbarqueCE(num_CE_mercante)
            Dim i As Integer = 0

            Dim conhecimentoDTOs(conhecimentosDatable.Rows.Count) As conhecimentosEmbarqueDTO


            Try

                For Each linha As DataRow In conhecimentosDatable.Rows

                    conhecimentoDTO.idman_conhecimentosEmbarque = linha.Item("idman_conhecimentosEmbarque")
                    conhecimentoDTO.num_manifesto = linha.Item("num_manifesto")
                    conhecimentoDTO.num_bl = linha.Item("num_bl")
                    conhecimentoDTO.num_CE_mercante = linha.Item("num_CE_mercante")
                    conhecimentoDTO.dt_emissao = linha.Item("dt_emissao")
                    conhecimentoDTO.tipo_conhecimento = linha.Item("tipo_conhecimento")
                    conhecimentoDTO.consignatario = linha.Item("consignatario")
                    conhecimentoDTO.num_duv = linha.Item("num_duv")




                    conhecimentoDTOs(i) = conhecimentoDTO
                    i = i + 1
                Next





            Catch ex As Exception

            End Try
            Return conhecimentoDTOs
        End Function


        Public Function SelecionaconhecimentosEmbarqueDUV(ByVal num_DUV As String) As conhecimentosEmbarqueDTO()

            Dim conhecimentoDAL As New conhecimentosEmbarqueDAL
            Dim conhecimentoDTO As New conhecimentosEmbarqueDTO


            Dim conhecimentosDatable As DataTable = conhecimentoDAL.SelecionaconhecimentoEmbarqueDUV(num_DUV)
            Dim i As Integer = 0

            Dim conhecimentoDTOs(conhecimentosDatable.Rows.Count) As conhecimentosEmbarqueDTO


            Try

                For Each linha As DataRow In conhecimentosDatable.Rows

                    conhecimentoDTO.idman_conhecimentosEmbarque = linha.Item("idman_conhecimentosEmbarque")
                    conhecimentoDTO.num_manifesto = linha.Item("num_manifesto")
                    conhecimentoDTO.num_bl = linha.Item("num_bl")
                    conhecimentoDTO.num_CE_mercante = linha.Item("num_CE_mercante")
                    conhecimentoDTO.dt_emissao = linha.Item("dt_emissao")
                    conhecimentoDTO.tipo_conhecimento = linha.Item("tipo_conhecimento")
                    conhecimentoDTO.consignatario = linha.Item("consignatario")
                    conhecimentoDTO.num_duv = linha.Item("num_duv")




                    conhecimentoDTOs(i) = conhecimentoDTO
                    i = i + 1
                Next





            Catch ex As Exception

            End Try
            Return conhecimentoDTOs
        End Function



        Sub deleteManifesto(num_manifesto As String)
            Dim conhecimentoDAL As New conhecimentosEmbarqueDAL



            Try

                conhecimentoDAL.deleteManifesto(num_manifesto)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub


        Sub deleteBL(num_bl As String)
            Dim conhecimentoDAL As New conhecimentosEmbarqueDAL



            Try

                conhecimentoDAL.deleteBL(num_bl)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub


        Sub deleteDUV(num_DUV As String)
            Dim conhecimentoDAL As New conhecimentosEmbarqueDAL



            Try

                conhecimentoDAL.deleteDUV(num_DUV)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Sub deleteCEMercante(num_CE_mercante As String)
            Dim conhecimentoDAL As New conhecimentosEmbarqueDAL



            Try

                conhecimentoDAL.deleteCEMercante(num_CE_mercante)


            Catch ex As Exception
                Throw ex
            End Try

        End Sub
    End Class

End Namespace
