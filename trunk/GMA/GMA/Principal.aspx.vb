
Partial Class Principal
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("idioma") = Session("idioma")
    End Sub

#End Region
    
End Class
