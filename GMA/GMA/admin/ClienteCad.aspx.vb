Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_ClienteCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_cliente_cli") Is Nothing Then
            If Not Char.IsNumber(Request("cod_cliente_cli")) Then
                Response.Redirect("Cliente.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_cliente_cli") Is Nothing Then
                lblTitulo.Text = "Alteração do cliente"

                Dim lDataView As DataView
                Using obj As New Cliente
                    lDataView = obj.ConsultarCliente(CType(Request("cod_cliente_cli"), Int32))
                End Using

                With lDataView.Table
                    nom_cliente_cli.Text = .Rows(0)("nom_cliente_cli")
                    des_email_cli.Text = .Rows(0)("des_email_cli").ToString()
                    des_login_cli.Text = .Rows(0)("des_login_cli").ToString()
                    num_telefone_cli.Text = .Rows(0)("num_telefone_cli").ToString()
                    num_celular_cli.Text = .Rows(0)("num_celular_cli").ToString()
                    num_cpf_cli.Text = .Rows(0)("num_cpf_cli").ToString()
                    num_cnpj_cli.Text = .Rows(0)("num_cnpj_cli").ToString()
                End With

                des_login_cli.Enabled = False
            Else
                lblTitulo.Text = "Inclusão do cliente"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        If Request("cod_cliente_cli") Is Nothing And des_senha_cli.Text = "" Then
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('É necessário informar a senha do cliente!');", True)
            Exit Sub
        End If

        Using obj As New Cliente
            Dim lDataSet As DataSet = obj.ConsultarCliente(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("nom_cliente_cli") = nom_cliente_cli.Text
                .Rows(0)("des_email_cli") = IIf(des_email_cli.Text = "", DBNull.Value, des_email_cli.Text)
                .Rows(0)("des_login_cli") = IIf(des_login_cli.Text = "", DBNull.Value, des_login_cli.Text)
                .Rows(0)("num_telefone_cli") = IIf(num_telefone_cli.Text = "", DBNull.Value, num_telefone_cli.Text)
                .Rows(0)("num_celular_cli") = IIf(num_celular_cli.Text = "", DBNull.Value, num_celular_cli.Text)
                .Rows(0)("num_cpf_cli") = IIf(num_cpf_cli.Text = "", DBNull.Value, num_cpf_cli.Text)
                .Rows(0)("num_cnpj_cli") = IIf(num_cnpj_cli.Text = "", DBNull.Value, num_cnpj_cli.Text)

                If des_senha_cli.Text <> "" Then
                    Dim seg As New Seguranca
                    .Rows(0)("des_senha_cli") = seg.Criptografar(des_senha_cli.Text)
                Else
                    .Rows(0)("des_senha_cli") = obj.ConsultarCliente(CType(Request("cod_cliente_cli"), Int32)).Table.Rows(0)("des_senha_cli")
                End If
            End With

            If Request("cod_cliente_cli") Is Nothing Then
                obj.IncluirCliente(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_cliente_cli") = CType(Request("cod_cliente_cli"), Int32)
                obj.AlterarCliente(lDataSet)
            End If
        End Using

        Response.Redirect("Cliente.aspx")
    End Sub

#End Region

End Class
