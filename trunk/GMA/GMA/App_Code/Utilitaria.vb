Imports System.Configuration.ConfigurationManager
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Net.Mail
Imports System.IO
Imports System.Web.HttpContext

Public Class Utilitaria

#Region " E-mail "

    Public Shared Function EnviarEmail(ByVal Assunto As String, ByVal Mensagem As String, Optional ByVal EmailTo As String = Nothing) As Boolean
        Dim flag As Boolean = False
        Dim emailExpression As New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        Dim smtp As String = IIf(Current.Request.Url.ToString.IndexOf("localhost") > -1, "smtp.webgma.com", "localhost")

        If Assunto <> "" And Mensagem <> "" Then
            Try
                Dim Message As New MailMessage()
                Message.From = New MailAddress(AppSettings("Atendimento"), AppSettings("Atendimento"))
                Message.To.Add(IIf(EmailTo Is Nothing, AppSettings("Atendimento"), EmailTo))

                Message.IsBodyHtml = True
                Message.Subject = Assunto
                Message.Body = MontarHTML(Mensagem)

                Dim SmtpClient As New SmtpClient(smtp)
                SmtpClient.Send(Message)

                flag = True
            Catch ex As Exception
                Using objErro As New GMA.DsAdmin.Erros
                    Dim lDataSet As System.Data.DataSet = objErro.ConsultarErros(-1).Table.DataSet

                    With lDataSet.Tables(0)
                        .Rows.Add(.NewRow())
                        .Rows(0)("nom_pagina_err") = Current.Request.Url.ToString()
                        .Rows(0)("num_ip_err") = Current.Request.UserHostAddress
                        .Rows(0)("des_message_err") = ex.Message
                        .Rows(0)("des_stacktrace_err") = ex.StackTrace
                        .Rows(0)("des_source_err") = ex.Source
                    End With

                    objErro.IncluirErros(lDataSet)
                End Using

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
