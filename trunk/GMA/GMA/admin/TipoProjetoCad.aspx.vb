Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_TipoProjetoCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_tipo_projeto_tpr") Is Nothing Then
            If Not Char.IsNumber(Request("cod_tipo_projeto_tpr")) Then
                Response.Redirect("TipoProjeto.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_tipo_projeto_tpr") Is Nothing Then
                lblTitulo.Text = "Alteração de tipo projeto"

                Dim lDataView As DataView
                Using obj As New TipoProjeto
                    lDataView = obj.ConsultarTipoProjeto(CType(Request("cod_tipo_projeto_tpr"), Int32))
                End Using

                With lDataView.Table
                    nom_tipo_projeto_pt_tpr.Text = .Rows(0)("nom_tipo_projeto_pt_tpr")
                    nom_tipo_projeto_es_tpr.Text = .Rows(0)("nom_tipo_projeto_es_tpr").ToString()
                    nom_tipo_projeto_en_tpr.Text = .Rows(0)("nom_tipo_projeto_en_tpr").ToString()
                    qtd_projetos_vitrine_tpr.Text = .Rows(0)("qtd_projetos_vitrine_tpr").ToString()
                    sts_ativo_tpr.Checked = .Rows(0)("sts_ativo_tpr")

                    If Not .Rows(0)("cod_tipo_projeto_pai_tpr") Is DBNull.Value Then
                        cod_tipo_projeto_pai_tpr.SelectedValue = .Rows(0)("cod_tipo_projeto_pai_tpr")
                    End If
                End With
            Else
                lblTitulo.Text = "Inclusão de tipo projeto"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Using obj As New TipoProjeto
            Dim lDataSet As DataSet = obj.ConsultarTipoProjeto(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())

                .Rows(0)("nom_tipo_projeto_pt_tpr") = nom_tipo_projeto_pt_tpr.Text
                .Rows(0)("nom_tipo_projeto_es_tpr") = IIf(nom_tipo_projeto_es_tpr.Text = "", DBNull.Value, nom_tipo_projeto_es_tpr.Text)
                .Rows(0)("nom_tipo_projeto_en_tpr") = IIf(nom_tipo_projeto_en_tpr.Text = "", DBNull.Value, nom_tipo_projeto_en_tpr.Text)
                .Rows(0)("qtd_projetos_vitrine_tpr") = qtd_projetos_vitrine_tpr.Text
                .Rows(0)("sts_ativo_tpr") = sts_ativo_tpr.Checked
                .Rows(0)("cod_tipo_projeto_pai_tpr") = IIf(cod_tipo_projeto_pai_tpr.SelectedValue = "-1", DBNull.Value, cod_tipo_projeto_pai_tpr.SelectedValue)
            End With

            If Request("cod_tipo_projeto_tpr") Is Nothing Then
                obj.IncluirTipoProjeto(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_tipo_projeto_tpr") = CType(Request("cod_tipo_projeto_tpr"), Int32)
                obj.AlterarTipoProjeto(lDataSet)
            End If
        End Using

        Response.Redirect("TipoProjeto.aspx")
    End Sub

#End Region

End Class
