Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_ContatosCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_contato_con") Is Nothing Then
            If Not Char.IsNumber(Request("cod_contato_con")) Then
                Response.Redirect("Contatos.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_contato_con") Is Nothing Then
                lblTitulo.Text = "Alteração do contato"

                Dim lDataView As DataView
                Using obj As New Contatos
                    lDataView = obj.ConsultarContatos(CType(Request("cod_contato_con"), Int32))
                End Using

                With lDataView.Table
                    nom_contato_con.Text = .Rows(0)("nom_contato_con")
                    des_email_con.Text = .Rows(0)("des_email_con").ToString()
                    num_telefone_con.Text = .Rows(0)("num_telefone_con").ToString()
                    num_celular_con.Text = .Rows(0)("num_celular_con").ToString()
                End With
            Else
                lblTitulo.Text = "Inclusão de contato"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Using obj As New Contatos
            Dim lDataSet As DataSet = obj.ConsultarContatos(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())

                .Rows(0)("nom_contato_con") = nom_contato_con.Text
                .Rows(0)("des_email_con") = IIf(des_email_con.Text = "", DBNull.Value, des_email_con.Text)
                .Rows(0)("num_telefone_con") = IIf(num_telefone_con.Text = "", DBNull.Value, num_telefone_con.Text)
                .Rows(0)("num_celular_con") = IIf(num_celular_con.Text = "", DBNull.Value, num_celular_con.Text)
            End With

            If Request("cod_contato_con") Is Nothing Then
                obj.IncluirContatos(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_contato_con") = CType(Request("cod_contato_con"), Int32)
                obj.AlterarContatos(lDataSet)
            End If
        End Using

        Response.Redirect("Contatos.aspx")
    End Sub

#End Region

End Class
