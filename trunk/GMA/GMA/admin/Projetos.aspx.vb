Imports System.Web.Services

Partial Class admin_Projetos
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Gallery.DataSource = New String() {"blue", "orange", "brown", "red", "yellow", "green", "black", "white", "purple"}
            Gallery.DataBind()
        End If
    End Sub

#End Region

#Region " Web Service "

    <WebMethod(True)> _
    Public Shared Sub SaveListOrder(ByVal ids As Int32())
        For i As Int32 = 0 To ids.Length
            Dim id As Int32 = ids(i)
            Dim ordinal As Int32 = i
            '...
        Next
    End Sub

#End Region

End Class
