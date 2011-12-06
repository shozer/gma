
Partial Class _Default
    Inherits System.Web.UI.Page

#Region " Botão "

    Protected Sub btnSpace_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSpace.Click
        Session("idioma") = hfIdioma.Value
        Response.Redirect("Principal.aspx")
    End Sub

#End Region
    
End Class
