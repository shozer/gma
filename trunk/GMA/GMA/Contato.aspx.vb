Imports Utilitaria
Imports System.Data

Partial Class Contato
    Inherits System.Web.UI.Page

#Region " Botão "

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click
        If txbNome.Text.Trim = "" Then
            txbNome.Text = ""
            RequiredFieldValidator1.SetFocusOnError = True
            ScriptManager.RegisterClientScriptBlock(Page, btnEnviar.GetType, "block", "alert('Preencha o Nome!');", True)
            Exit Sub

        ElseIf txbAssunto.Text.Trim = "" Then
            txbAssunto.Text = ""
            RequiredFieldValidator3.SetFocusOnError = True
            ScriptManager.RegisterClientScriptBlock(Page, btnEnviar.GetType, "block", "alert('Preencha o Assunto!');", True)
            Exit Sub

        ElseIf txbMensagem.Text.Trim = "" Then
            txbMensagem.Text = ""
            RequiredFieldValidator4.SetFocusOnError = True
            ScriptManager.RegisterClientScriptBlock(Page, btnEnviar.GetType, "block", "alert('Preencha a Mensagem!');", True)
            Exit Sub

        Else
            Dim Mensagem As String = ""

            Mensagem &= "<b>Nome: </b>" & txbNome.Text & "<br>"
            Mensagem &= "<b>E-mail: </b>" & txbEmail.Text & "<br>"

            If txbTelefone.Text <> "" Then
                Mensagem &= "<b>Telefone: </b>(" & txbDdd.Text & ") " & txbTelefone.Text & "<br>"
            End If

            Mensagem &= "<b>Mensagem: </b>" & txbMensagem.Text

            EnviarEmail(txbAssunto.Text.Trim, Mensagem, txbNome.Text, txbEmail.Text, Nothing)
        End If
    End Sub

#End Region

End Class
