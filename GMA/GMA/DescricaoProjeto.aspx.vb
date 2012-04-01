Imports GMA.DsAdmin
Imports System.Data

Partial Class DescricaoProjeto
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request("cod_projeto_pro") <> "" Then
                Dim lDataView As DataView

                Using objProjeto As New Projeto
                    lDataView = objProjeto.ConsultarProjetoCompleto(CType(Request("cod_projeto_pro"), Int32))
                End Using

                If lDataView.Table.Rows.Count > 0 Then
                    With lDataView.Table
                        Select Case Session("idioma")
                            Case "1"
                                litTitulo.Text = .Rows(0)("nom_projeto_pt_fte")
                                litDescricao.Text = .Rows(0)("des_projeto_pt_fte")
                                litEstado.Text = "Estado: " & .Rows(0)("nom_situacao_projeto_pt_spr").ToString()
                            Case "2"
                                litTitulo.Text = IIf(.Rows(0)("nom_projeto_es_fte") Is DBNull.Value, .Rows(0)("nom_projeto_pt_fte"), .Rows(0)("nom_projeto_es_fte"))
                                litDescricao.Text = IIf(.Rows(0)("des_projeto_es_fte") Is DBNull.Value, .Rows(0)("des_projeto_pt_fte"), .Rows(0)("des_projeto_es_fte"))
                                litEstado.Text = "Estado: " & IIf(.Rows(0)("nom_situacao_projeto_es_spr") Is DBNull.Value, .Rows(0)("nom_situacao_projeto_pt_spr"), .Rows(0)("nom_situacao_projeto_es_spr"))
                            Case "3"
                                litTitulo.Text = IIf(.Rows(0)("nom_projeto_en_fte") Is DBNull.Value, .Rows(0)("nom_projeto_pt_fte"), .Rows(0)("nom_projeto_en_fte"))
                                litDescricao.Text = IIf(.Rows(0)("des_projeto_en_fte") Is DBNull.Value, .Rows(0)("des_projeto_pt_fte"), .Rows(0)("des_projeto_en_fte"))
                                litEstado.Text = "Estado: " & IIf(.Rows(0)("nom_situacao_projeto_en_spr") Is DBNull.Value, .Rows(0)("nom_situacao_projeto_pt_spr"), .Rows(0)("nom_situacao_projeto_en_spr"))
                        End Select

                        litLocal.Text = .Rows(0)("des_local_pro")
                        litCliente.Text = "Cliente: " & .Rows(0)("nom_cliente_cli")
                        litPrograma.Text = "Programa: " & .Rows(0)("des_programa_pt_fte").ToString()
                        litArtigo.Text = "Artigo: " & .Rows(0)("des_artigo_pt_fte").ToString()
                        litVideo.Text = "Vídeo: " & .Rows(0)("des_video_pt_fte").ToString()
                        litEntrevista.Text = "Entrevista: " & .Rows(0)("des_entrevista_pt_fte").ToString()
                        litLivro.Text = "Livro: " & .Rows(0)("des_livro_pt_fte").ToString()
                    End With

                    Using objProfissional As New Profissional
                        lDataView = objProfissional.ListarProfissionalPorProjeto(CType(Request("cod_projeto_pro"), Int32))

                        For Each lRow As DataRow In lDataView.Table.Rows
                            litProfissionais.Text &= lRow("nom_profissional_prf") & " <br/> " & vbCrLf
                        Next
                    End Using

                    Using objConsultorEspecializado As New ConsultorEspecializado
                        lDataView = objConsultorEspecializado.ListarConsultorEspecializadoPorProjeto(CType(Request("cod_projeto_pro"), Int32))

                        For Each lRow As DataRow In lDataView.Table.Rows
                            litConsultores.Text &= lRow("nom_consultor_ces") & " <br/> " & vbCrLf
                        Next
                    End Using

                    litSpan.Text = ""

                    Using objImagemProjeto As New ImagemProjeto
                        lDataView = objImagemProjeto.ListarImagemProjetoGaleriaPorProjeto(CType(Request("cod_projeto_pro"), Int32))

                        Dim count As Int32
                        For Each lRow As DataRow In lDataView.Table.Rows
                            count += 1

                            If count < 6 Then
                                litSpan.Text &= "<span></span>"
                            Else
                                litSpan.Text &= "<span class='margin_right_0'></span>"
                            End If
                        Next
                    End Using
                Else
                    PaginaPadrao()
                End If
            Else
                PaginaPadrao()
            End If
        End If
    End Sub

#End Region

#Region " Página Padrão "

    Private Sub PaginaPadrao()
        Response.Redirect("Principal.aspx")
    End Sub

#End Region

End Class
