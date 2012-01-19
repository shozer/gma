Imports System.Configuration.ConfigurationManager
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Net.Mail
Imports System.IO
Imports System.Web.HttpContext

Public Class Utilitaria

#Region " E-mail "

    Public Shared Function EnviarEmail(ByVal Assunto As String, ByVal Mensagem As String, ByVal NomeFrom As String, ByVal EmailFrom As String, Optional ByVal EmailTo As String = Nothing) As Boolean
        Dim flag As Boolean = False
        Dim emailExpression As New Regex("^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$")
        Dim smtp As String = IIf(Current.Request.Url.ToString.IndexOf("localhost") > -1, "smtp.webgma.com", "localhost")

        If Assunto <> "" And Mensagem <> "" And NomeFrom <> "" And EmailFrom <> "" Then
            If emailExpression.IsMatch(EmailFrom) Then
                Try
                    Dim Message As New MailMessage()
                    Message.From = New MailAddress(EmailFrom, NomeFrom)
                    Message.To.Add(IIf(EmailTo Is Nothing, AppSettings("Atendimento"), EmailTo))

                    Message.IsBodyHtml = True
                    Message.Subject = Assunto
                    Message.Body = MontarHTML(Mensagem)

                    Dim SmtpClient As New SmtpClient(smtp)
                    SmtpClient.Send(Message)

                    flag = True
                Catch ex As Exception
                    Dim Message As New MailMessage(AppSettings("EmailErros"), AppSettings("EmailErros"))
                    Message.IsBodyHtml = True
                    Message.Subject = "Erro no disparo de e-mail"
                    Message.Body = MontarHTML("Mensagem: " & ex.Message & "<br><br>" & "StackTrace: " & ex.StackTrace)

                    Dim SmtpClient As New SmtpClient(smtp)
                    SmtpClient.Send(Message)

                    flag = False
                Finally
                    '*** Necessário para a perfeita execução do sistema
                End Try
            End If

            Return flag
        End If
    End Function

#End Region
    
#Region " Montar HTML "

    Public Shared Function MontarHTML(ByVal Conteudo As String) As String
        Dim ConteudoModificado As String = ""

        ConteudoModificado &= "<html>"
        ConteudoModificado &= " <head>"
        ConteudoModificado &= " </head>"
        ConteudoModificado &= " <body>"
        ConteudoModificado &= "     <table>"
        ConteudoModificado &= "         <tr>"
        ConteudoModificado &= "             <td style='font-family: Lucida Sans Unicode; font-size: 12;'>"
        ConteudoModificado &= Conteudo
        ConteudoModificado &= "             </td>"
        ConteudoModificado &= "         </tr>"
        ConteudoModificado &= "     </table>"
        ConteudoModificado &= " </body>"
        ConteudoModificado &= "</html>"

        Return ConteudoModificado
    End Function

#End Region

End Class
