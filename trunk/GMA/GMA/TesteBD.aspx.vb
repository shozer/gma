Imports System.Data
Imports GMA.DsAdmin

Partial Class TesteBD
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LimparCampos()
        End If
    End Sub

#End Region

#Region " Botões "

    Protected Sub btnCadastrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCadastrar.Click
        Dim lDataSet As DataSet

        Using objContato As New Contatos
            lDataSet = objContato.ConsultarContatos(-1).Table.DataSet
            lDataSet.Tables(0).Rows.Add(lDataSet.Tables(0).NewRow())
        End Using

        With lDataSet.Tables(0)
            .Rows(0)("nom_contato_con") = nom_contato_con.Text.Trim
            .Rows(0)("des_email_con") = des_email_con.Text.Trim
            .Rows(0)("num_telefone_con") = num_telefone_con.Text.Trim
            .Rows(0)("num_celular_con") = num_celular_con.Text.Trim
        End With

        If cod_contato_con.Text.Trim <> "" Then
            lDataSet.Tables(0).Rows(0)("cod_contato_con") = cod_contato_con.Text.Trim

            Using objContato As New Contatos
                objContato.AlterarContatos(lDataSet)
            End Using
        Else
            Dim pk As Int32
            Using objContato As New Contatos
                pk = objContato.IncluirContatos(lDataSet)
            End Using

            ScriptManager.RegisterStartupScript(Page, Page.GetType, "success", "alert('A primary key é: " & pk & "');", True)
        End If
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcluir.Click
        If cod_contato_con.Text.Trim <> "" Then
            Try
                Using objContato As New Contatos
                    objContato.ExcluirContatos(CType(cod_contato_con.Text.Trim, Int32))
                End Using
            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Page, Page.GetType, "success", "alert('Erro ao excluir: " & ex.Message & "');", True)
            End Try
        End If
    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Dim lDataView As DataView
        Using objContato As New Contatos
            lDataView = objContato.ListarContatos()
        End Using

        grvPrincipal.DataSource = lDataView
        grvPrincipal.DataBind()
    End Sub

#End Region

#Region " Métodos gerais "

    Private Sub LimparCampos()
        cod_contato_con.Text = ""
        nom_contato_con.Text = ""
        des_email_con.Text = ""
        num_telefone_con.Text = ""
        num_celular_con.Text = ""
    End Sub

#End Region
    
End Class
