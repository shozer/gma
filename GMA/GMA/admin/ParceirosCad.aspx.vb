Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_ParceirosCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_parceiro_par") Is Nothing Then
            If Not Char.IsNumber(Request("cod_parceiro_par")) Then
                Response.Redirect("Parceiros.aspx")
            End If
        End If

        If Not IsPostBack Then
            If Not Request("cod_parceiro_par") Is Nothing Then
                lblTitulo.Text = "Alteração do parceiro"

                Dim lDataView As DataView
                Using obj As New Parceiro
                    lDataView = obj.ConsultarParceiro(CType(Request("cod_parceiro_par"), Int32))
                End Using

                With lDataView.Table
                    nom_parceiro_par.Text = .Rows(0)("nom_parceiro_par")
                    des_imagem_par.Text = .Rows(0)("des_imagem_par").ToString()
                    des_link_par.Text = .Rows(0)("des_link_par").ToString()
                    sts_ativo_par.Checked = .Rows(0)("sts_ativo_par")
                End With
            Else
                lblTitulo.Text = "Inclusão de parceiro"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim imagem As String = ""

        
        If upl_des_imagem_par.HasFile Then
            Dim extensao As String = upl_des_imagem_par.FileName.Split(".")(1).ToLower

            If extensao <> "jpg" And extensao <> "png" And extensao <> "gif" And extensao <> "bmp" Then
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('É necessário adicionar um arquivo com extensão .jpg ou .png ou .gif ou .bmp!');", True)
                Exit Sub
            End If

            Dim caminho As String = Server.MapPath("..") & "\img"
            Dim nome As String = "img_" & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & extensao

            upl_des_imagem_par.SaveAs(caminho & "\" & nome)
            imagem = nome
        ElseIf des_imagem_par.Text <> "" Then
            imagem = des_imagem_par.Text
        End If

        If imagem <> "" Then
            Using obj As New Parceiro
                Dim lDataSet As DataSet = obj.ConsultarParceiro(-1).Table.DataSet

                With lDataSet.Tables(0)
                    .Rows.Add(.NewRow())

                    .Rows(0)("nom_parceiro_par") = nom_parceiro_par.Text
                    .Rows(0)("des_imagem_par") = imagem
                    .Rows(0)("des_link_par") = IIf(des_link_par.Text = "", DBNull.Value, des_link_par.Text)
                    .Rows(0)("sts_ativo_par") = sts_ativo_par.Checked
                    .Rows(0)("cod_usuario_usu") = Session("cod_usuario_usu")
                End With

                If Request("cod_parceiro_par") Is Nothing Then
                    obj.IncluirParceiro(lDataSet)
                Else
                    lDataSet.Tables(0).Rows(0)("cod_parceiro_par") = CType(Request("cod_parceiro_par"), Int32)
                    obj.AlterarParceiro(lDataSet)
                End If
            End Using

            Response.Redirect("Parceiros.aspx")
        Else
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('É necessário adicionar uma imagem!');", True)
        End If
    End Sub

#End Region

End Class
