Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_PerfilCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_perfil_per") Is Nothing Then
            If Not Char.IsNumber(Request("cod_perfil_per")) Then
                Response.Redirect("Perfil.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_perfil_per") Is Nothing Then
                lblTitulo.Text = "Alteração do perfil"

                Dim lDataView As DataView
                Using obj As New Perfil
                    lDataView = obj.ConsultarPerfil(CType(Request("cod_perfil_per"), Int32))
                End Using

                With lDataView.Table
                    nom_perfil_per.Text = .Rows(0)("nom_perfil_per")
                    sts_ativo_per.Checked = .Rows(0)("sts_ativo_per")
                End With
            Else
                lblTitulo.Text = "Inclusão do perfil"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Using obj As New Perfil
            Dim lDataSet As DataSet = obj.ConsultarPerfil(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("nom_perfil_per") = nom_perfil_per.Text
                .Rows(0)("sts_ativo_per") = sts_ativo_per.Checked
            End With

            If Request("cod_perfil_per") Is Nothing Then
                obj.IncluirPerfil(lDataSet)
            Else
                lDataSet.Tables(0).Rows(0)("cod_perfil_per") = CType(Request("cod_perfil_per"), Int32)
                obj.AlterarPerfil(lDataSet)
            End If
        End Using

        Response.Redirect("Perfil.aspx")
    End Sub

#End Region

End Class
