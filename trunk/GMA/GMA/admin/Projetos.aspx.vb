Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_Projetos
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            
        End If
    End Sub

#End Region

#Region " Grid "

    Protected Sub grvPrincipal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvPrincipal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.DataItem("sts_ativo_pro") Then
                e.Row.Cells(5).Text = "Sim"
            Else
                e.Row.Cells(5).Text = "Não"
            End If
        End If
    End Sub

#End Region

End Class
