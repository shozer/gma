Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_ProfissionalCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_profissional_prf") Is Nothing Then
            If Not Char.IsNumber(Request("cod_profissional_prf")) Then
                Response.Redirect("Profissional.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_profissional_prf") Is Nothing Then
                lblTitulo.Text = "Alteração do profissional"

                Dim lDataView As DataView
                Using obj As New Profissional
                    lDataView = obj.ConsultarProfissional(CType(Request("cod_profissional_prf"), Int32))
                End Using

                With lDataView.Table
                    nom_profissional_prf.Text = .Rows(0)("nom_profissional_prf")
                    des_email_prf.Text = .Rows(0)("des_email_prf").ToString()
                    num_telefone_prf.Text = .Rows(0)("num_telefone_prf").ToString()
                    num_celular_prf.Text = .Rows(0)("num_celular_prf").ToString()
                    sts_ativo_prf.Checked = .Rows(0)("sts_ativo_prf")
                End With
            Else
                lblTitulo.Text = "Inclusão do profissional"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Using obj As New Profissional
            Dim lDataSet As DataSet = obj.ConsultarProfissional(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("nom_profissional_prf") = nom_profissional_prf.Text
                .Rows(0)("des_email_prf") = IIf(des_email_prf.Text = "", DBNull.Value, des_email_prf.Text)
                .Rows(0)("num_telefone_prf") = IIf(num_telefone_prf.Text = "", DBNull.Value, num_telefone_prf.Text)
                .Rows(0)("num_celular_prf") = IIf(num_celular_prf.Text = "", DBNull.Value, num_celular_prf.Text)
                .Rows(0)("sts_ativo_prf") = sts_ativo_prf.Checked
            End With

            If Request("cod_profissional_prf") Is Nothing Then
                obj.IncluirProfissional(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_profissional_prf") = CType(Request("cod_profissional_prf"), Int32)
                obj.AlterarProfissional(lDataSet)
            End If
        End Using

        Response.Redirect("Profissional.aspx")
    End Sub

#End Region

End Class
