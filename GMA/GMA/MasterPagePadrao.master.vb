
Partial Class MasterPagePadrao
    Inherits System.Web.UI.MasterPage

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("idioma") Is Nothing Then
                Session("idioma") = 1
            Else
                Session("idioma") = Session("idioma")
            End If
        End If
    End Sub

#End Region
    
End Class

