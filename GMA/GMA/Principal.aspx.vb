Imports GMA.DsAdmin
Imports System.Data

Partial Class Principal
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Session("idioma") Is Nothing Then
                Session("idioma") = Session("idioma")
            Else
                Session("idioma") = "1"
            End If

            Dim lDataView As DataView
            Dim count As Int32 = 0
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
        End If
    End Sub

#End Region

End Class
