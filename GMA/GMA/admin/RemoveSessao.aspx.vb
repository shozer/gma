
Partial Class admin_RemoveSessao
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Abandon()
        Response.Redirect("Default.aspx")
    End Sub

#End Region

End Class
