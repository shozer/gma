Imports System.Xml

Partial Class admin_MasterPage
    Inherits System.Web.UI.MasterPage

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("cod_usuario_usu") Is Nothing Then
                Response.Redirect("RemoveSessao.aspx")
            Else
                Session("cod_usuario_usu") = Session("cod_usuario_usu")
            End If
        End If
    End Sub

#End Region

#Region " HandleError "

    Protected Sub HandleError(ByVal sender As Object, ByVal e As AsyncPostBackErrorEventArgs)
        Dim msgError As String = Server.GetLastError().GetBaseException().Message
        'Dim doc As New XmlDocument
        'doc.Load(Request.PhysicalApplicationPath & "\Erros.xml")

        'Dim xmlNodes As XmlNodeList = doc.SelectNodes("/Erros/Erro")

        'For Each lRow As XmlNode In xmlNodes
        '    If Server.GetLastError().GetBaseException().Message.Contains(lRow("keyErro").InnerText) Then
        '        msgError = lRow("desErro").InnerText
        '    End If
        'Next

        scmPrincipal.AsyncPostBackErrorMessage = msgError
    End Sub

#End Region

End Class

