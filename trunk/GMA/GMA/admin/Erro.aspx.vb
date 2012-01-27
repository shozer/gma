Imports GMA.DsAdmin
Imports System.Data
Imports System.Xml

Partial Class admin_Erro
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request("cod_erro_err") <> "" Then
                Dim lDataview As DataView

                Using objErro As New Erros
                    lDataview = objErro.ConsultarErros(CType(Request("cod_erro_err"), Int32))
                End Using

                If lDataview.Table.Rows.Count > 0 Then
                    lblErro.Text = "Message: " & lDataview.Table.Rows(0)("des_message_err") & "<br><br>"
                    lblErro.Text &= "StackTrace: " & lDataview.Table.Rows(0)("des_stacktrace_err") & "<br><br>"
                    lblErro.Text = "Página: " & lDataview.Table.Rows(0)("nom_pagina_err") & "<br><br>"
                End If
            End If
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
