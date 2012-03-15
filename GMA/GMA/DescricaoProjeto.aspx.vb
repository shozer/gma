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
                    lDataView = objProjeto.ConsultarProjeto(CType(Request("cod_projeto_pro"), Int32))
                End Using

                If lDataView.Table.Rows.Count > 0 Then
                    With lDataView.Table
                        lblTitulo.InnerText = .Rows(0)("des_identificacao_pro")
                        lblLocal.InnerText = .Rows(0)("des_local_pro")
                        lblDescricao.InnerText = .Rows(0)("des_local_pro")

                        Select Case Session("idioma")
                            Case "1"
                                lblDescricao.InnerText = .Rows(0)("des_projeto_pt_fte")
                            Case "2"
                                lblDescricao.InnerText = .Rows(0)("des_projeto_pt_fte")
                                NomeProjeto = IIf(lRow("nom_projeto_es_fte") Is DBNull.Value, lRow("nom_projeto_pt_fte"), lRow("nom_projeto_es_fte"))
                                Briefing = IIf(lRow("des_briefing_es_pro") Is DBNull.Value, lRow("des_briefing_pt_pro").ToString(), lRow("des_briefing_es_pro"))
                            Case "3"
                                NomeProjeto = IIf(lRow("nom_projeto_en_fte") Is DBNull.Value, lRow("nom_projeto_pt_fte"), lRow("nom_projeto_en_fte"))
                                Briefing = IIf(lRow("des_briefing_en_pro") Is DBNull.Value, lRow("des_briefing_pt_pro").ToString(), lRow("des_briefing_en_pro"))
                        End Select

                        nom_projeto_es_fte.Text = .Rows(0)("nom_projeto_es_fte").ToString()
                        nom_projeto_en_fte.Text = .Rows(0)("nom_projeto_en_fte").ToString()
                        des_projeto_pt_fte.Text = .Rows(0)("des_projeto_pt_fte")
                        des_projeto_es_fte.Text = .Rows(0)("des_projeto_es_fte").ToString()
                        des_projeto_en_fte.Text = .Rows(0)("des_projeto_en_fte").ToString()
                        des_programa_pt_fte.Text = .Rows(0)("des_programa_pt_fte").ToString()
                        des_artigo_pt_fte.Text = .Rows(0)("des_artigo_pt_fte").ToString()
                        des_video_pt_fte.Text = .Rows(0)("des_video_pt_fte").ToString()
                        des_entrevista_pt_fte.Text = .Rows(0)("des_entrevista_pt_fte").ToString()
                        des_livro_pt_fte.Text = .Rows(0)("des_livro_pt_fte").ToString()
                    End With
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
