Imports System.Data
Imports System.Xml
Imports GMA.DsAdmin

Partial Class admin_Default
    Inherits System.Web.UI.Page

#Region " Botão "

    Protected Sub btnConfirmar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        Dim UsuarioValido As Boolean = False

        Using objUsuario As New Usuario
            UsuarioValido = objUsuario.ValidarUsuario(cod_usuario_usu.Text.Trim, des_senha_usu.Text.Trim)
        End Using

        If UsuarioValido Then
            Session("cod_usuario_usu") = cod_usuario_usu.Text.Trim
            Response.Redirect("Projetos.aspx")
        Else
            cod_usuario_usu.Text = ""
            des_senha_usu.Text = ""
            ScriptManager.RegisterClientScriptBlock(Page, btnConfirmar.GetType, "block", "alert('O usuário é inválido, verifique o seu usuário e senha!');", True)
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
