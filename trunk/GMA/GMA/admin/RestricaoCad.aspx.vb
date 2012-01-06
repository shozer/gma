Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_RestricaoCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_arquivo_arq") Is Nothing Then
            If Not Char.IsNumber(Request("cod_arquivo_arq")) Then
                Response.Redirect("Restricao.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_arquivo_arq") Is Nothing Then
                lblTitulo.Text = "Alteração da restrição"

                cod_arquivo_arq.SelectedValue = Request("cod_arquivo_arq")
                cod_arquivo_arq.Enabled = False
            Else
                lblTitulo.Text = "Inclusão da restrição"
            End If
        End If
    End Sub

#End Region

#Region " Eventos gerais "

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        Dim lDataView As New DataView

        For Each lRow As ListItem In cod_perfil_per.Items
            Using obj As New Restricao
                lDataView = obj.ConsultarRestricaoPorArquivoPerfil(CType(Request("cod_arquivo_arq"), Int32), CType(lRow.Value, Int32))
            End Using

            lRow.Selected = lDataView.Table.Rows.Count > 0
        Next

        For Each lRow As ListItem In cod_cliente_cli.Items
            Using obj As New Restricao
                lDataView = obj.ConsultarRestricaoPorArquivoCliente(CType(Request("cod_arquivo_arq"), Int32), CType(lRow.Value, Int32))
            End Using

            lRow.Selected = lDataView.Table.Rows.Count > 0
        Next
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim clientes As String = ""
        Dim perfis As String = ""

        For Each lRow As ListItem In cod_cliente_cli.Items
            If lRow.Selected Then
                clientes &= lRow.Value & ";"
            End If
        Next

        For Each lRow As ListItem In cod_perfil_per.Items
            If lRow.Selected Then
                perfis &= lRow.Value & ";"
            End If
        Next

        If clientes <> "" Or perfis <> "" Then
            Using objRestricao As New Restricao
                '*** Realiza a exclusão de todas as restrições associadas a esse arquivo
                objRestricao.ExcluirRestricaoPorArquivo(CType(cod_arquivo_arq.SelectedValue, Int32))

                Dim lDataSet As DataSet = objRestricao.ConsultarRestricao(-1).Table.DataSet
                lDataSet.Tables(0).Rows.Add(lDataSet.Tables(0).NewRow())

                For Each item As String In clientes.Split(";")
                    If item <> "" Then
                        With lDataSet.Tables(0)
                            .Rows(0)("cod_arquivo_arq") = cod_arquivo_arq.SelectedValue
                            .Rows(0)("cod_cliente_cli") = item
                        End With

                        objRestricao.IncluirRestricao(lDataSet)
                    End If
                Next

                For Each item As String In perfis.Split(";")
                    If item <> "" Then
                        With lDataSet.Tables(0)
                            .Rows(0)("cod_arquivo_arq") = cod_arquivo_arq.SelectedValue
                            .Rows(0)("cod_perfil_per") = item
                        End With

                        objRestricao.IncluirRestricao(lDataSet)
                    End If
                Next
            End Using

            Response.Redirect("Restricao.aspx")
        Else
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('É necessário selecionar um cliente ou perfil!');", True)
        End If
    End Sub

#End Region
    
End Class
