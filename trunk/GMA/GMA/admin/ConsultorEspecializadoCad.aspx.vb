Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_ConsultorEspecializadoCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_consultor_especializado_ces") Is Nothing Then
            If Not Char.IsNumber(Request("cod_consultor_especializado_ces")) Then
                Response.Redirect("ConsultorEspecializado.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_consultor_especializado_ces") Is Nothing Then
                lblTitulo.Text = "Alteração do consultor especializado"

                Dim lDataView As DataView
                Using obj As New ConsultorEspecializado
                    lDataView = obj.ConsultarConsultorEspecializado(CType(Request("cod_consultor_especializado_ces"), Int32))
                End Using

                With lDataView.Table
                    nom_consultor_ces.Text = .Rows(0)("nom_consultor_ces")
                    des_email_ces.Text = .Rows(0)("des_email_ces").ToString()
                    num_telefone_ces.Text = .Rows(0)("num_telefone_ces").ToString()
                    sts_ativo_ces.Checked = .Rows(0)("sts_ativo_ces")
                End With
            Else
                lblTitulo.Text = "Inclusão do consultor especializado"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Using obj As New ConsultorEspecializado
            Dim lDataSet As DataSet = obj.ConsultarConsultorEspecializado(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("nom_consultor_ces") = nom_consultor_ces.Text
                .Rows(0)("des_email_ces") = IIf(des_email_ces.Text = "", DBNull.Value, des_email_ces.Text)
                .Rows(0)("num_telefone_ces") = IIf(num_telefone_ces.Text = "", DBNull.Value, num_telefone_ces.Text)
                .Rows(0)("sts_ativo_ces") = sts_ativo_ces.Checked
            End With

            If Request("cod_consultor_especializado_ces") Is Nothing Then
                obj.IncluirConsultorEspecializado(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_consultor_especializado_ces") = CType(Request("cod_consultor_especializado_ces"), Int32)
                obj.AlterarConsultorEspecializado(lDataSet)
            End If
        End Using

        Response.Redirect("ConsultorEspecializado.aspx")
    End Sub

#End Region

End Class
