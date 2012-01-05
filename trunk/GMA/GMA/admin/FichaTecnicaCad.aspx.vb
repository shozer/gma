Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_FichaTecnicaCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_ficha_tecnica_fte") Is Nothing Then
            If Not Char.IsNumber(Request("cod_ficha_tecnica_fte")) Then
                Response.Redirect("FichaTecnica.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_ficha_tecnica_fte") Is Nothing Then
                lblTitulo.Text = "Alteração de ficha técnica"

                Dim lDataView As DataView
                Using obj As New FichaTecnica
                    lDataView = obj.ConsultarFichaTecnica(CType(Request("cod_ficha_tecnica_fte"), Int32))
                End Using

                With lDataView.Table
                    nom_projeto_pt_fte.Text = .Rows(0)("nom_projeto_pt_fte")
                    nom_projeto_es_fte.Text = .Rows(0)("nom_projeto_es_fte").ToString()
                    nom_projeto_en_fte.Text = .Rows(0)("nom_projeto_en_fte").ToString()
                    des_projeto_pt_fte.Text = .Rows(0)("des_projeto_pt_fte")
                    des_projeto_es_fte.Text = .Rows(0)("des_projeto_es_fte").ToString()
                    des_projeto_en_fte.Text = .Rows(0)("des_projeto_en_fte").ToString()
                    des_programa_pt_fte.Text = .Rows(0)("des_programa_pt_fte").ToString()
                    des_programa_es_fte.Text = .Rows(0)("des_programa_es_fte").ToString()
                    des_programa_en_fte.Text = .Rows(0)("des_programa_en_fte").ToString()
                    des_artigo_pt_fte.Text = .Rows(0)("des_artigo_pt_fte").ToString()
                    des_artigo_es_fte.Text = .Rows(0)("des_artigo_es_fte").ToString()
                    des_artigo_en_fte.Text = .Rows(0)("des_artigo_en_fte").ToString()
                    des_video_pt_fte.Text = .Rows(0)("des_video_pt_fte").ToString()
                    des_video_es_fte.Text = .Rows(0)("des_video_es_fte").ToString()
                    des_video_en_fte.Text = .Rows(0)("des_video_en_fte").ToString()
                    des_entrevista_pt_fte.Text = .Rows(0)("des_entrevista_pt_fte").ToString()
                    des_entrevista_es_fte.Text = .Rows(0)("des_entrevista_es_fte").ToString()
                    des_entrevista_en_fte.Text = .Rows(0)("des_entrevista_en_fte").ToString()
                    des_livro_pt_fte.Text = .Rows(0)("des_livro_pt_fte").ToString()
                    des_livro_es_fte.Text = .Rows(0)("des_livro_es_fte").ToString()
                    des_livro_en_fte.Text = .Rows(0)("des_livro_en_fte").ToString()
                End With
            Else
                lblTitulo.Text = "Inclusão de ficha técnica"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Using obj As New FichaTecnica
            Dim lDataSet As DataSet = obj.ConsultarFichaTecnica(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("nom_projeto_pt_fte") = nom_projeto_pt_fte.Text
                .Rows(0)("nom_projeto_es_fte") = IIf(nom_projeto_es_fte.Text = "", DBNull.Value, nom_projeto_es_fte.Text)
                .Rows(0)("nom_projeto_en_fte") = IIf(nom_projeto_en_fte.Text = "", DBNull.Value, nom_projeto_en_fte.Text)
                .Rows(0)("des_projeto_pt_fte") = des_projeto_pt_fte.Text
                .Rows(0)("des_projeto_es_fte") = IIf(des_projeto_es_fte.Text = "", DBNull.Value, des_projeto_es_fte.Text)
                .Rows(0)("des_projeto_en_fte") = IIf(des_projeto_en_fte.Text = "", DBNull.Value, des_projeto_en_fte.Text)
                .Rows(0)("des_programa_pt_fte") = IIf(des_programa_pt_fte.Text = "", DBNull.Value, des_programa_pt_fte.Text)
                .Rows(0)("des_programa_es_fte") = IIf(des_programa_es_fte.Text = "", DBNull.Value, des_programa_es_fte.Text)
                .Rows(0)("des_programa_en_fte") = IIf(des_programa_en_fte.Text = "", DBNull.Value, des_programa_en_fte.Text)
                .Rows(0)("des_artigo_pt_fte") = IIf(des_artigo_pt_fte.Text = "", DBNull.Value, des_artigo_pt_fte.Text)
                .Rows(0)("des_artigo_es_fte") = IIf(des_artigo_es_fte.Text = "", DBNull.Value, des_artigo_es_fte.Text)
                .Rows(0)("des_artigo_en_fte") = IIf(des_artigo_en_fte.Text = "", DBNull.Value, des_artigo_en_fte.Text)
                .Rows(0)("des_video_pt_fte") = IIf(des_video_pt_fte.Text = "", DBNull.Value, des_video_pt_fte.Text)
                .Rows(0)("des_video_es_fte") = IIf(des_video_es_fte.Text = "", DBNull.Value, des_video_es_fte.Text)
                .Rows(0)("des_video_en_fte") = IIf(des_video_en_fte.Text = "", DBNull.Value, des_video_en_fte.Text)
                .Rows(0)("des_entrevista_pt_fte") = IIf(des_entrevista_pt_fte.Text = "", DBNull.Value, des_entrevista_pt_fte.Text)
                .Rows(0)("des_entrevista_es_fte") = IIf(des_entrevista_es_fte.Text = "", DBNull.Value, des_entrevista_es_fte.Text)
                .Rows(0)("des_entrevista_en_fte") = IIf(des_entrevista_en_fte.Text = "", DBNull.Value, des_entrevista_en_fte.Text)
                .Rows(0)("des_livro_pt_fte") = IIf(des_livro_pt_fte.Text = "", DBNull.Value, des_livro_pt_fte.Text)
                .Rows(0)("des_livro_es_fte") = IIf(des_livro_es_fte.Text = "", DBNull.Value, des_livro_es_fte.Text)
                .Rows(0)("des_livro_en_fte") = IIf(des_livro_en_fte.Text = "", DBNull.Value, des_livro_en_fte.Text)
            End With

            If Request("cod_ficha_tecnica_fte") Is Nothing Then
                obj.IncluirFichaTecnica(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_ficha_tecnica_fte") = CType(Request("cod_ficha_tecnica_fte"), Int32)
                obj.AlterarFichaTecnica(lDataSet)
            End If
        End Using

        Response.Redirect("FichaTecnica.aspx")
    End Sub

#End Region

End Class
