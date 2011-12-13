Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_ArquivoCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_arquivo_arq") Is Nothing Then
            If Not Char.IsNumber(Request("cod_arquivo_arq")) Then
                Response.Redirect("Arquivo.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_arquivo_arq") Is Nothing Then
                lblTitulo.Text = "Alteração de arquivo"

                Dim lDataView As DataView
                Using obj As New Arquivo
                    lDataView = obj.ConsultarArquivo(CType(Request("cod_arquivo_arq"), Int32))
                End Using

                With lDataView.Table
                    nom_arquivo_arq.Text = .Rows(0)("nom_arquivo_arq")
                    des_arquivo_pt_arq.Text = .Rows(0)("des_arquivo_pt_arq")
                    des_arquivo_es_arq.Text = .Rows(0)("des_arquivo_es_arq").ToString()
                    des_arquivo_en_arq.Text = .Rows(0)("des_arquivo_en_arq").ToString()
                    sts_ativo_arq.Checked = .Rows(0)("sts_ativo_arq")
                End With
            Else
                lblTitulo.Text = "Inclusão de arquivo"
            End If
        End If
    End Sub

#End Region

#Region " botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim arquivo As String = ""

        If nom_arquivo_arq.Text <> "" Then
            arquivo = nom_arquivo_arq.Text
        ElseIf upl_nom_arquivo_arq.HasFile Then
            Dim caminho As String = Server.MapPath("")
            Dim nome As String = "arq_" & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_arquivo_arq.FileName.Split(".")(1)

            upl_nom_arquivo_arq.SaveAs(caminho & "\" & nome)
            arquivo = nome
        End If

        If arquivo <> "" Then
            Using obj As New Arquivo
                Dim lDataSet As DataSet = obj.ConsultarArquivo(-1).Table.DataSet

                With lDataSet.Tables(0)
                    .Rows.Add(.NewRow())

                    .Rows(0)("nom_arquivo_arq") = arquivo
                    .Rows(0)("des_arquivo_pt_arq") = des_arquivo_pt_arq.Text
                    .Rows(0)("des_arquivo_es_arq") = IIf(des_arquivo_es_arq.Text = "", DBNull.Value, des_arquivo_es_arq.Text)
                    .Rows(0)("des_arquivo_en_arq") = IIf(des_arquivo_en_arq.Text = "", DBNull.Value, des_arquivo_en_arq.Text)
                    .Rows(0)("sts_ativo_arq") = sts_ativo_arq.Checked
                End With

                If Request("cod_arquivo_arq") Is Nothing Then
                    obj.IncluirArquivo(lDataSet)
                Else
                    lDataSet.Tables(0).Rows(0)("cod_arquivo_arq") = CType(Request("cod_arquivo_arq"), Int32)
                    obj.AlterarArquivo(lDataSet)
                End If
            End Using

            Response.Redirect("Arquivo.aspx")
        Else
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('É necessário adicionar um arquivo!');", True)
        End If
    End Sub

#End Region
    
End Class
