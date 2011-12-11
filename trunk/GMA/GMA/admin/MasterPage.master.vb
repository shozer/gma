Imports System.Xml

Partial Class admin_MasterPage
    Inherits System.Web.UI.MasterPage

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

