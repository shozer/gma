Imports GMA.DsAdmin
Imports System.Data

Partial Class Projetos
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
                        Dim count As Int32 = 0
                        qtd_projetos_vitrine_tpr = CType(lDataView.Table.Rows(0)("qtd_projetos_vitrine_tpr"), Int32)
                        qtd_projetos_vitrine_tpr = 16
                        Using objProjetos As New Projeto
                            lDataView = objProjetos.ListarProjetoAtivoPorTipoProjeto(CType(Request("cod_tipo_projeto_tpr"), Int32))
                        End Using

                        For iterator As Int32 = 1 To qtd_projetos_vitrine_tpr
                            Dim ProjetoBranco As Boolean = True
                            count += 1

                            For Each lRow As DataRow In lDataView.Table.Rows
                                If CType(lRow("num_posicao_vitrine_pro"), Int32) = iterator Then
                                    If count = 5 Then
                                        divProjetos.InnerHtml &= "<div class='bloco_projeto margin_right_0'>" & vbCrLf
                                    Else
                                        divProjetos.InnerHtml &= "<div class='bloco_projeto'>" & vbCrLf
                                    End If

                                    divProjetos.InnerHtml &= "  <a href='DescricaoProjeto.aspx?cod_projeto_pro=" & lRow("cod_projeto_pro") & "'>" & vbCrLf

                                    If Not lRow("nom_imagem_projeto_ipr") Is DBNull.Value Then
                                        divProjetos.InnerHtml &= "      <img src='img/" & lRow("nom_imagem_projeto_ipr") & "' style='border: 0;' alt='' />" & vbCrLf
                                    End If

                                    divProjetos.InnerHtml &= "  </a>" & vbCrLf
                                    divProjetos.InnerHtml &= "  <div class='descricao_bloco_projeto'>" & vbCrLf
                                    divProjetos.InnerHtml &= "      <span>" & lRow("des_identificacao_pro") & "</span> <span class='texto_menor'>" & lRow("des_local_pro") & "</span>" & vbCrLf
                                    divProjetos.InnerHtml &= "  </div>" & vbCrLf
                                    divProjetos.InnerHtml &= "</div>" & vbCrLf

                                    ProjetoBranco = False
                                    Exit For
                                End If
                            Next

                            If count = 5 Then
                                If ProjetoBranco Then
                                    divProjetos.InnerHtml &= "<div class='bloco_projeto_vazio margin_right_0'>&nbsp;</div>" & vbCrLf
                                End If

                                divProjetos.InnerHtml &= "<div class='clear'>" & vbCrLf
                                divProjetos.InnerHtml &= "</div>" & vbCrLf
                                divProjetos.InnerHtml &= "<div class='divisao_bloco_projetos'>" & vbCrLf
                                divProjetos.InnerHtml &= "</div>" & vbCrLf
                                count = 0
                            Else
                                If ProjetoBranco Then
                                    divProjetos.InnerHtml &= "<div class='bloco_projeto_vazio'>&nbsp;</div>" & vbCrLf
                                End If

                                If iterator = qtd_projetos_vitrine_tpr Then
                                    divProjetos.InnerHtml &= "<div class='clear'>" & vbCrLf
                                End If
                            End If
                        Next
                    Else
                        PaginaPadrao()
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

#Region " Métodos gerais "

    Private Sub PaginaPadrao()
        Response.Redirect("Principal.aspx")
    End Sub

#End Region

End Class
