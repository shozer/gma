<%@ Application Language="VB" %>

<script RunAt="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        If Request.Url.ToString().IndexOf("localhost") = -1 Then
            Dim ex As Exception = Server.GetLastError()
            Dim cod_erro_err As Int32
            Dim Mensagem As String = ""
        
            Mensagem &= "<b>Página: </b>" & Request.Url.ToString()
            Mensagem &= "<br><b>IP: </b>" & Request.UserHostAddress
            Mensagem &= "<br><br><b>Message: </b>" & ex.Message
            Mensagem &= "<br><br><b>StackTrace: </b>" & ex.StackTrace
            Mensagem &= "<br><br><b>Source: </b>" & ex.Source
        
            Utilitaria.EnviarEmail("Erro no site GMA", Mensagem, System.Configuration.ConfigurationManager.AppSettings("EmailErros"))
        
            Using objErro As New GMA.DsAdmin.Erros
                Dim lDataSet As System.Data.DataSet = objErro.ConsultarErros(-1).Table.DataSet
            
                With lDataSet.Tables(0)
                    .Rows.Add(.NewRow())
                    .Rows(0)("nom_pagina_err") = Request.Url.ToString()
                    .Rows(0)("num_ip_err") = Request.UserHostAddress
                    .Rows(0)("des_message_err") = ex.Message
                    .Rows(0)("des_stacktrace_err") = ex.StackTrace
                    .Rows(0)("des_source_err") = ex.Source
                End With
            
                cod_erro_err = objErro.IncluirErros(lDataSet)
            End Using
            
            'Server.ClearError()
            'Server.Transfer("~/admin/Erro.aspx?cod_erro_err=" & cod_erro_err)
        End If
    End Sub
                                      
    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
       
</script>

