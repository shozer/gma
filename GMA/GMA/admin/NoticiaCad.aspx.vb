Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_NoticiaCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_noticia_not") Is Nothing Then
            If Not Char.IsNumber(Request("cod_noticia_not")) Then
                Response.Redirect("Noticia.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_noticia_not") Is Nothing Then
                lblTitulo.Text = "Alteração de notícia"

                Dim lDataView As DataView
                Using obj As New Noticia
                    lDataView = obj.ConsultarNoticia(CType(Request("cod_noticia_not"), Int32))
                End Using

                With lDataView.Table
                    des_titulo_pt_not.Text = .Rows(0)("des_titulo_pt_not")
                    des_titulo_es_not.Text = .Rows(0)("des_titulo_es_not").ToString()
                    des_titulo_en_not.Text = .Rows(0)("des_titulo_en_not").ToString()
                    des_descricao_pt_not.Text = .Rows(0)("des_descricao_pt_not")
                    des_descricao_es_not.Text = .Rows(0)("des_descricao_es_not").ToString()
                    des_descricao_en_not.Text = .Rows(0)("des_descricao_en_not").ToString()
                    des_noticia_pt_not.Text = .Rows(0)("des_noticia_pt_not")
                    des_noticia_es_not.Text = .Rows(0)("des_noticia_es_not").ToString()
                    des_noticia_en_not.Text = .Rows(0)("des_noticia_en_not").ToString()
                    sts_ativo_not.Checked = .Rows(0)("sts_ativo_not")
                End With
            Else
                lblTitulo.Text = "Inclusão de notícia"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Using obj As New Noticia
            Dim lDataSet As DataSet = obj.ConsultarNoticia(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("des_titulo_pt_not") = des_titulo_pt_not.Text
                .Rows(0)("des_titulo_es_not") = IIf(des_titulo_es_not.Text = "", DBNull.Value, des_titulo_es_not.Text)
                .Rows(0)("des_titulo_en_not") = IIf(des_titulo_en_not.Text = "", DBNull.Value, des_titulo_en_not.Text)
                .Rows(0)("des_descricao_pt_not") = des_descricao_pt_not.Text
                .Rows(0)("des_descricao_es_not") = IIf(des_descricao_es_not.Text = "", DBNull.Value, des_descricao_es_not.Text)
                .Rows(0)("des_descricao_en_not") = IIf(des_descricao_en_not.Text = "", DBNull.Value, des_descricao_en_not.Text)
                .Rows(0)("des_noticia_pt_not") = des_noticia_pt_not.Text
                .Rows(0)("des_noticia_es_not") = IIf(des_noticia_es_not.Text = "", DBNull.Value, des_noticia_es_not.Text)
                .Rows(0)("des_noticia_en_not") = IIf(des_noticia_en_not.Text = "", DBNull.Value, des_noticia_en_not.Text)
                .Rows(0)("sts_ativo_not") = sts_ativo_not.Checked
                .Rows(0)("cod_usuario_usu") = Session("cod_usuario_usu")
            End With

            If Request("cod_noticia_not") Is Nothing Then
                obj.IncluirNoticia(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_noticia_not") = CType(Request("cod_noticia_not"), Int32)
                obj.AlterarNoticia(lDataSet)
            End If
        End Using

        Response.Redirect("Noticia.aspx")
    End Sub

#End Region

End Class
