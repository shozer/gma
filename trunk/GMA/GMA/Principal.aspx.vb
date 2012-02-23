Imports GMA.DsAdmin
Imports System.Data

Partial Class Principal
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim timeout As Int32 = 6000

            If Not Session("idioma") Is Nothing Then
                Session("idioma") = Session("idioma")
            Else
                Session("idioma") = "1"
            End If

            Dim lDataView As DataView
            Dim count As Int32 = 0

            Using objProjeto As New Projeto
                lDataView = objProjeto.ListarProjetoPrincipal()
            End Using

            '**** Projeto da vitrine principal
            If lDataView.Table.Rows.Count > 0 Then
                Dim lDV As DataView

                With lDataView.Table
                    Using objIP As New ImagemProjeto
                        lDV = objIP.ListarImagemProjetoPrincipalPorProjeto(CType(.Rows(0)("cod_projeto_pro"), Int32))
                    End Using

                    If lDV.Table.Rows.Count > 0 Then
                        lblTituloProjeto.InnerText = .Rows(0)("des_identificacao_pro")
                        lblLocalProjeto.InnerText = .Rows(0)("des_local_pro")

                        box4.InnerHtml = ""
                        handles4.InnerHtml = ""
                    End If

                    For Each lRow As DataRow In lDV.Table.Rows
                        handles4.InnerHtml &= "<span></span>"

                        box4.InnerHtml &= "<div class='container_banner'>" & vbCrLf
                        box4.InnerHtml &= " <a href='Projetos.aspx?cod_projeto_pro=" & .Rows(0)("cod_projeto_pro") & "'>" & vbCrLf
                        box4.InnerHtml &= "     <img alt='imagem' src='img/projetos/" & lRow("nom_imagem_projeto_ipr") & "' width='961px' height='395px' />" & vbCrLf
                        box4.InnerHtml &= " </a>" & vbCrLf
                        box4.InnerHtml &= "</div>" & vbCrLf
                    Next
                End With
            End If

            '***** Notícias
            noticias.InnerHtml = ""

            Using objNoticia As New Noticia
                lDataView = objNoticia.ListarNoticiaAtivoPrincipal()
            End Using

            For Each lRow As DataRow In lDataView.Table.Rows
                count += 1

                If count = 1 Then
                    noticias.InnerHtml &= "<ul>" & vbCrLf
                End If

                '*** Cadastro das notícias
                noticias.InnerHtml &= "<li>" & vbCrLf
                noticias.InnerHtml &= " <span class='noticia_list'>" & vbCrLf
                noticias.InnerHtml &= " <a href='DescricaoNoticia.aspx?cod_noticia_not=" & lRow("cod_noticia_not") & "'>" & vbCrLf

                If Session("idioma") = "2" And Not lRow("des_descricao_es_not") Is DBNull.Value Then
                    noticias.InnerHtml &= lRow("des_descricao_es_not")
                ElseIf Session("idioma") = "3" And Not lRow("des_descricao_en_not") Is DBNull.Value Then
                    noticias.InnerHtml &= lRow("des_descricao_en_not")
                Else
                    noticias.InnerHtml &= lRow("des_descricao_pt_not")
                End If

                noticias.InnerHtml &= "</a>" & vbCrLf
                noticias.InnerHtml &= " </span>" & vbCrLf
                noticias.InnerHtml &= "</li>" & vbCrLf

                If count = lDataView.Table.Rows.Count Then
                    noticias.InnerHtml &= "</ul>" & vbCrLf
                    noticias.InnerHtml &= "<div class='setas_noticias'>" & vbCrLf
                    noticias.InnerHtml &= "     <a id='up' href='#'>up</a> <a id='down' href='#'>down</a>" & vbCrLf
                    noticias.InnerHtml &= "</div>" & vbCrLf
                    noticias.InnerHtml &= "<div class='clear'>" & vbCrLf
                    noticias.InnerHtml &= "</div>" & vbCrLf
                End If
            Next

            '***** Parceiros
            Using objParceiro As New Parceiro
                lDataView = objParceiro.ListarParceiroAtivo()
            End Using

            Dim contador As Int32 = lDataView.Table.Rows.Count

            While contador
                If timeout > 1000 Then
                    timeout -= 1000
                Else
                    If timeout > 500 Then
                        timeout -= 100
                    End If
                End If

                contador -= 1
            End While

            Session("timeout") = timeout

            count = 0
            parceiro.InnerHtml = ""

            For Each lRow As DataRow In lDataView.Table.Rows
                count += 1

                If count = 1 Then
                    parceiro.InnerHtml &= "<ul>" & vbCrLf
                End If

                '*** Cadastro dos parceiros
                parceiro.InnerHtml &= "<li>" & vbCrLf

                If Not lRow("des_link_par") Is DBNull.Value Then
                    parceiro.InnerHtml &= "<a href='" & lRow("des_link_par") & "' target='_blank'>"
                    parceiro.InnerHtml &= "    <img src='img/parceiros/" & lRow("des_imagem_par") & "' style='border: 0;' width='139px' heigth='134px' alt='" & lRow("nom_parceiro_par") & "' title='" & lRow("nom_parceiro_par") & "' />"
                    parceiro.InnerHtml &= "</a>"
                Else
                    parceiro.InnerHtml &= "    <img src='img/parceiros/" & lRow("des_imagem_par") & "' style='border: 0;' width='139px' heigth='134px' alt='" & lRow("nom_parceiro_par") & "' title='" & lRow("nom_parceiro_par") & "' />"
                End If

                parceiro.InnerHtml &= "</li>" & vbCrLf

                If count = lDataView.Table.Rows.Count Then
                    parceiro.InnerHtml &= "</ul>" & vbCrLf
                End If
            Next
        End If
    End Sub

#End Region

End Class
