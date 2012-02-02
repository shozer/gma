Imports GMA.DsAdmin
Imports System.Data
Imports System.Web.Services

Partial Class admin_OrdenacaoProjetoCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request("cod_tipo_projeto_tpr") <> "" Then
                If Char.IsNumber(Request("cod_tipo_projeto_tpr")) Then
                    Dim lDataView As DataView
                    Dim qtd_projetos_vitrine_tpr As Int32 = 0

                    Using objTipoProjeto As New TipoProjeto
                        lDataView = objTipoProjeto.ConsultarTipoProjeto(CType(Request("cod_tipo_projeto_tpr"), Int32))
                    End Using

                    If lDataView.Table.Rows.Count > 0 Then
                        qtd_projetos_vitrine_tpr = CType(lDataView.Table.Rows(0)("qtd_projetos_vitrine_tpr"), Int32)

                        Using objProjeto As New Projeto
                            lDataView = objProjeto.ListarProjetoAtivoPorTipoProjeto(CType(Request("cod_tipo_projeto_tpr"), Int32))
                        End Using

                        Dim dic As New Dictionary(Of Int32, String)
                        For Each lRow As DataRow In lDataView.Table.Rows
                            dic.Add(CType(lRow("num_posicao_vitrine_pro"), Int32), lRow("des_identificacao_pro"))
                        Next

                        If lDataView.Table.Rows.Count > 0 Then
                            Dim str(qtd_projetos_vitrine_tpr - 1) As String

                            For iterator As Int32 = 0 To qtd_projetos_vitrine_tpr - 1
                                If dic.Count > 0 Then
                                    If dic.ContainsKey(iterator) Then
                                        str(iterator) = dic(iterator)
                                        dic.Remove(iterator)
                                    Else
                                        If dic.Max().Key > qtd_projetos_vitrine_tpr Then
                                            str(iterator) = dic.Max().Value
                                            dic.Remove(dic.Max().Key)
                                        Else
                                            str(iterator) = "" '*** Projeto em branco
                                        End If
                                    End If
                                Else
                                    str(iterator) = "" '*** Projeto em branco
                                End If
                            Next

                            Gallery.DataSource = str
                            Gallery.DataBind()
                        Else
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('Nenhum projeto ativo foi encontrado!'); window.location.href('" & Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/")) & "/OrdenacaoProjeto.aspx" & "');", True)
                            Exit Sub
                        End If
                    Else
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('O tipo de projeto não foi encontrado!'); window.location.href('" & Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf("/")) & "/OrdenacaoProjeto.aspx" & "');", True)
                        Exit Sub
                    End If
                Else
                    PaginaPadrao()
                End If
            Else
                PaginaPadrao()
            End If
        End If
    End Sub

#End Region

#Region " Página padrão "

    Private Sub PaginaPadrao()
        Response.Redirect("OrdenacaoProjeto.aspx")
    End Sub

#End Region

#Region " Web Service "

    <WebMethod(True)> _
    Public Shared Sub SaveListOrder(ByVal ids As Int32())
        For i As Int32 = 0 To ids.Length
            Dim id As Int32 = ids(i)
            Dim ordinal As Int32 = i
            '...
        Next
    End Sub

#End Region

End Class
