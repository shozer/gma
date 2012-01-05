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
            Else
                lblTitulo.Text = "Inclusão da restrição"
            End If
        End If
    End Sub

#End Region

#Region " Eventos gerais "

    Protected Sub cod_perfil_per_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cod_perfil_per.DataBound
        Dim lDataView As DataView
        Using obj As New Restricao
            lDataView = obj.ConsultarRestricaoPorArquivoPerfil(CType(Request("cod_arquivo_arq"), Int32), 1)
        End Using

        With lDataView.Table
            'nom_arquivo_arq.Text = .Rows(0)("nom_arquivo_arq")
            'des_arquivo_pt_arq.Text = .Rows(0)("des_arquivo_pt_arq")
            'des_arquivo_es_arq.Text = .Rows(0)("des_arquivo_es_arq").ToString()
            'des_arquivo_en_arq.Text = .Rows(0)("des_arquivo_en_arq").ToString()
            'sts_ativo_arq.Checked = .Rows(0)("sts_ativo_arq")
        End With
    End Sub

    Protected Sub cod_cliente_cli_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles cod_cliente_cli.DataBound
        Dim lDataView As DataView
        Using obj As New Restricao
            lDataView = obj.ConsultarRestricaoPorArquivoCliente(CType(Request("cod_arquivo_arq"), Int32), 1)
        End Using

        With lDataView.Table
            'nom_arquivo_arq.Text = .Rows(0)("nom_arquivo_arq")
            'des_arquivo_pt_arq.Text = .Rows(0)("des_arquivo_pt_arq")
            'des_arquivo_es_arq.Text = .Rows(0)("des_arquivo_es_arq").ToString()
            'des_arquivo_en_arq.Text = .Rows(0)("des_arquivo_en_arq").ToString()
            'sts_ativo_arq.Checked = .Rows(0)("sts_ativo_arq")
        End With
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        'Dim arquivo As String = ""

        'If nom_arquivo_arq.Text <> "" Then
        '    arquivo = nom_arquivo_arq.Text
        'ElseIf upl_nom_arquivo_arq.HasFile Then
        '    Dim caminho As String = Server.MapPath("..") & "\arquivos"
        '    Dim nome As String = "arq_" & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_arquivo_arq.FileName.Split(".")(1).ToLower

        '    upl_nom_arquivo_arq.SaveAs(caminho & "\" & nome)
        '    arquivo = nome
        'End If

        'If arquivo <> "" Then
        '    Using obj As New Arquivo
        '        Dim lDataSet As DataSet = obj.ConsultarArquivo(-1).Table.DataSet

        '        With lDataSet.Tables(0)
        '            .Rows.Add(.NewRow())

        '            .Rows(0)("nom_arquivo_arq") = arquivo
        '            .Rows(0)("des_arquivo_pt_arq") = des_arquivo_pt_arq.Text
        '            .Rows(0)("des_arquivo_es_arq") = IIf(des_arquivo_es_arq.Text = "", DBNull.Value, des_arquivo_es_arq.Text)
        '            .Rows(0)("des_arquivo_en_arq") = IIf(des_arquivo_en_arq.Text = "", DBNull.Value, des_arquivo_en_arq.Text)
        '            .Rows(0)("sts_ativo_arq") = sts_ativo_arq.Checked
        '        End With

        '        If Request("cod_arquivo_arq") Is Nothing Then
        '            obj.IncluirArquivo(lDataSet)
        '        Else
        '            lDataSet.Tables(0).Rows(0)("cod_arquivo_arq") = CType(Request("cod_arquivo_arq"), Int32)
        '            obj.AlterarArquivo(lDataSet)
        '        End If
        '    End Using

        '    Response.Redirect("Restricao.aspx")
        'Else
        '    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('É necessário adicionar um arquivo!');", True)
        'End If
    End Sub

#End Region
    
End Class
