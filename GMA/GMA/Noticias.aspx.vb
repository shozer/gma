Imports GMA.DsAdmin
Imports System.Data
Imports System.Xml

Partial Class Noticias
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Session("idioma") Is Nothing Then
                Session("idioma") = Session("idioma")
            Else
                Session("idioma") = "1"
            End If
        End If
    End Sub

#End Region

#Region " Grid "

    Protected Sub grvPrincipal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvPrincipal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Text = "<a href='DescricaoNoticia.aspx?cod_noticia_not=" & e.Row.DataItem("cod_noticia_not") & "' style='text-decoration: none; display: block;'>"

            If Session("idioma") = "2" And Not e.Row.DataItem("des_titulo_es_not") Is DBNull.Value And Not e.Row.DataItem("des_descricao_es_not") Is DBNull.Value Then
                e.Row.Cells(0).Text &= "Título: " & e.Row.DataItem("des_titulo_es_not") & "<br><br>"
                e.Row.Cells(0).Text &= "Descrição: " & e.Row.DataItem("des_descricao_es_not") & "<br>"
            ElseIf Session("idioma") = "3" And Not e.Row.DataItem("des_titulo_en_not") Is DBNull.Value And Not e.Row.DataItem("des_descricao_en_not") Is DBNull.Value Then
                e.Row.Cells(0).Text &= "Título: " & e.Row.DataItem("des_titulo_en_not") & "<br><br>"
                e.Row.Cells(0).Text &= "Descrição: " & e.Row.DataItem("des_descricao_en_not") & "<br>"
            Else
                e.Row.Cells(0).Text &= "Título: " & e.Row.DataItem("des_titulo_pt_not") & "<br><br>"
                e.Row.Cells(0).Text &= "Descrição: " & e.Row.DataItem("des_descricao_pt_not") & "<br>"
            End If

            e.Row.Cells(0).Text &= "</a>"
        End If
    End Sub

#End Region

#Region " HandleError "

    Protected Sub HandleError(ByVal sender As Object, ByVal e As AsyncPostBackErrorEventArgs)
        Dim msgError As String = ""
        Dim doc As New XmlDocument
        doc.Load(Request.PhysicalApplicationPath & "\Erros.xml")

        Dim xmlNodes As XmlNodeList = doc.SelectNodes("/Erros/Erro")

        For Each lRow As XmlNode In xmlNodes
            If Server.GetLastError().GetBaseException().Message.Contains(lRow("keyErro").InnerText) Then
                msgError = lRow("desErro").InnerText
            End If
        Next

        scmPrincipal.AsyncPostBackErrorMessage = msgError
    End Sub

#End Region

End Class
