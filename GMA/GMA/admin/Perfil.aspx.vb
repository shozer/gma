
Partial Class admin_Perfil
    Inherits System.Web.UI.Page

#Region " Grid "

    Protected Sub grvPrincipal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvPrincipal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.DataItem("sts_ativo_per") Then
                e.Row.Cells(1).Text = "Sim"
            Else
                e.Row.Cells(1).Text = "Não"
            End If
        End If
    End Sub

#End Region
    
End Class
