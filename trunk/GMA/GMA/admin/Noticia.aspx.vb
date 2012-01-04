
Partial Class admin_Noticia
    Inherits System.Web.UI.Page

#Region " Grid "

    Protected Sub grvPrincipal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grvPrincipal.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.DataItem("sts_ativo_not") Then
                e.Row.Cells(3).Text = "Sim"
            Else
                e.Row.Cells(3).Text = "Não"
            End If
        End If
    End Sub

#End Region

End Class
