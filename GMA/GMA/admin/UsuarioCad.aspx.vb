Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_UsuarioCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Request("cod_usuario_usu") Is Nothing Then
                lblTitulo.Text = "Alteração do usuário"

                Dim lDataView As DataView
                Using obj As New Usuario
                    lDataView = obj.ConsultarUsuario(Request("cod_usuario_usu"))
                End Using

                With lDataView.Table
                    nom_usuario_usu.Text = .Rows(0)("nom_usuario_usu")
                    des_email_usu.Text = .Rows(0)("des_email_usu").ToString()
                    cod_usuario_usu.Text = .Rows(0)("cod_usuario_usu").ToString()
                    num_telefone_usu.Text = .Rows(0)("num_telefone_usu").ToString()
                    num_celular_usu.Text = .Rows(0)("num_celular_usu").ToString()
                    sts_ativo_usu.Checked = .Rows(0)("sts_ativo_usu")
                    cod_perfil_per.SelectedValue = .Rows(0)("cod_perfil_per")
                End With

                cod_usuario_usu.Enabled = False
            Else
                lblTitulo.Text = "Inclusão do usuário"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        If Request("cod_usuario_usu") Is Nothing And des_senha_usu.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('É necessário informar a senha do usuário!');", True)
            Exit Sub
        End If

        Using obj As New Usuario
            Dim lDataSet As DataSet = obj.ConsultarUsuario("-1").Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("nom_usuario_usu") = nom_usuario_usu.Text
                .Rows(0)("des_email_usu") = IIf(des_email_usu.Text = "", DBNull.Value, des_email_usu.Text)
                .Rows(0)("cod_usuario_usu") = IIf(cod_usuario_usu.Text = "", DBNull.Value, cod_usuario_usu.Text)
                .Rows(0)("num_telefone_usu") = IIf(num_telefone_usu.Text = "", DBNull.Value, num_telefone_usu.Text)
                .Rows(0)("num_celular_usu") = IIf(num_celular_usu.Text = "", DBNull.Value, num_celular_usu.Text)
                .Rows(0)("cod_perfil_per") = cod_perfil_per.SelectedValue
                .Rows(0)("sts_ativo_usu") = sts_ativo_usu.Checked

                If des_senha_usu.Text <> "" Then
                    Dim seg As New Seguranca
                    .Rows(0)("des_senha_usu") = seg.Criptografar(des_senha_usu.Text)
                Else
                    .Rows(0)("des_senha_usu") = obj.ConsultarUsuario(Request("cod_usuario_usu")).Table.Rows(0)("des_senha_usu")
                End If
            End With

            If Request("cod_usuario_usu") Is Nothing Then
                obj.IncluirUsuario(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_usuario_usu") = Request("cod_usuario_usu")
                obj.AlterarUsuario(lDataSet)
            End If
        End Using

        Response.Redirect("Usuario.aspx")
    End Sub

#End Region

End Class
