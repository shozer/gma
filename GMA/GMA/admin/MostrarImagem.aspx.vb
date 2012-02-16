
Partial Class admin_MostrarImagem
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request("vid") <> "" Then
                imgFoto.ImageUrl = "~/img/" & Request("vid")
            End If
        End If
    End Sub

#End Region
    
End Class
