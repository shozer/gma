Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_SituacaoProjetoCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_situacao_projeto_spr") Is Nothing Then
            If Not Char.IsNumber(Request("cod_situacao_projeto_spr")) Then
                Response.Redirect("SituacaoProjeto.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_situacao_projeto_spr") Is Nothing Then
                lblTitulo.Text = "Alteração da situação do projeto"

                Dim lDataView As DataView
                Using obj As New SituacaoProjeto
                    lDataView = obj.ConsultarSituacaoProjeto(CType(Request("cod_situacao_projeto_spr"), Int32))
                End Using

                With lDataView.Table
                    nom_situacao_projeto_pt_spr.Text = .Rows(0)("nom_situacao_projeto_pt_spr")
                    nom_situacao_projeto_es_spr.Text = .Rows(0)("nom_situacao_projeto_es_spr").ToString()
                    nom_situacao_projeto_en_spr.Text = .Rows(0)("nom_situacao_projeto_en_spr").ToString()
                End With
            Else
                lblTitulo.Text = "Inclusão da situação do projeto"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Using obj As New SituacaoProjeto
            Dim lDataSet As DataSet = obj.ConsultarSituacaoProjeto(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("nom_situacao_projeto_pt_spr") = nom_situacao_projeto_pt_spr.Text
                .Rows(0)("nom_situacao_projeto_es_spr") = IIf(nom_situacao_projeto_es_spr.Text = "", DBNull.Value, nom_situacao_projeto_es_spr.Text)
                .Rows(0)("nom_situacao_projeto_en_spr") = IIf(nom_situacao_projeto_en_spr.Text = "", DBNull.Value, nom_situacao_projeto_en_spr.Text)
            End With

            If Request("cod_situacao_projeto_spr") Is Nothing Then
                obj.IncluirSituacaoProjeto(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_situacao_projeto_spr") = CType(Request("cod_situacao_projeto_spr"), Int32)
                obj.AlterarSituacaoProjeto(lDataSet)
            End If
        End Using

        Response.Redirect("SituacaoProjeto.aspx")
    End Sub

#End Region

End Class
