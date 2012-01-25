Imports GMA.DsAdmin
Imports System.Data

Partial Class DescricaoNoticia
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Session("idioma") Is Nothing Then
                Session("idioma") = Session("idioma")
            Else
                Session("idioma") = "1"
            End If

            If Request("cod_noticia_not") <> "" Then
                If Char.IsNumber(Request("cod_noticia_not")) Then
                    Dim lDataView As DataView

                    Using objNoticia As New Noticia
                        lDataView = objNoticia.ConsultarNoticia(CType(Request("cod_noticia_not"), Int32))
                    End Using

                    If lDataView.Table.Rows.Count > 0 Then
                        With lDataView.Table
                            If Session("idioma") = "2" And Not .Rows(0)("des_titulo_es_not") Is DBNull.Value And Not .Rows(0)("des_noticia_es_not") Is DBNull.Value Then
                                lblTitulo.Text = .Rows(0)("des_titulo_es_not")
                                lblNoticia.Text = .Rows(0)("des_noticia_es_not")
                            ElseIf Session("idioma") = "3" And Not .Rows(0)("des_titulo_en_not") Is DBNull.Value And Not .Rows(0)("des_noticia_en_not") Is DBNull.Value Then
                                lblTitulo.Text = .Rows(0)("des_titulo_en_not")
                                lblNoticia.Text = .Rows(0)("des_noticia_en_not")
                            Else
                                lblTitulo.Text = .Rows(0)("des_titulo_pt_not")
                                lblNoticia.Text = .Rows(0)("des_noticia_pt_not")
                            End If
                        End With
                    Else
                        PaginaPadrao()
                    End If
                Else
                    PaginaPadrao()
                End If
            Else
                PaginaPadrao()
            End If
        End If
    End Sub

#End Region

#Region " Página Padrão "

    Private Sub PaginaPadrao()
        Response.Redirect("Noticias.aspx")
    End Sub

#End Region
    
End Class
