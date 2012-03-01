Imports GMA.DsAdmin
Imports System.Data

Partial Class admin_ProjetosCad
    Inherits System.Web.UI.Page

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request("cod_projeto_pro") Is Nothing Then
            If Not Char.IsNumber(Request("cod_projeto_pro")) Then
                Response.Redirect("Projetos.aspx")
            End If
        End If

        If Not IsPostBack Then
            Dim lDataView As DataView
            ViewState("flg_vitrine_principal_pro") = False

            If Not Request("cod_projeto_pro") Is Nothing Then
                Dim cod_ficha_tecnica_fte As Int32

                lblTitulo.Text = "Alteração do projeto"

                '*** Cadastro do projeto
                Using obj As New Projeto
                    lDataView = obj.ConsultarProjeto(CType(Request("cod_projeto_pro"), Int32))
                End Using

                With lDataView.Table
                    ViewState("cod_ficha_tecnica_fte") = .Rows(0)("cod_ficha_tecnica_fte")
                    cod_ficha_tecnica_fte = .Rows(0)("cod_ficha_tecnica_fte")
                    des_identificacao_pro.Text = .Rows(0)("des_identificacao_pro")
                    des_local_pro.Text = .Rows(0)("des_local_pro")
                    cod_tipo_projeto_tpr.SelectedValue = .Rows(0)("cod_tipo_projeto_tpr")
                    cod_cliente_cli.SelectedValue = .Rows(0)("cod_cliente_cli")
                    cod_situacao_projeto_spr.SelectedValue = .Rows(0)("cod_situacao_projeto_spr")
                    flg_vitrine_principal_pro.Checked = .Rows(0)("flg_vitrine_principal_pro")
                    sts_ativo_pro.Checked = .Rows(0)("sts_ativo_pro")
                End With

                ViewState("flg_vitrine_principal_pro") = flg_vitrine_principal_pro.Checked

                '*** Cadastro da ficha técnica
                Using obj As New FichaTecnica
                    lDataView = obj.ConsultarFichaTecnica(cod_ficha_tecnica_fte)
                End Using

                With lDataView.Table
                    nom_projeto_es_fte.Text = .Rows(0)("nom_projeto_es_fte").ToString()
                    nom_projeto_en_fte.Text = .Rows(0)("nom_projeto_en_fte").ToString()
                    des_projeto_pt_fte.Text = .Rows(0)("des_projeto_pt_fte")
                    des_projeto_es_fte.Text = .Rows(0)("des_projeto_es_fte").ToString()
                    des_projeto_en_fte.Text = .Rows(0)("des_projeto_en_fte").ToString()
                    des_programa_pt_fte.Text = .Rows(0)("des_programa_pt_fte").ToString()
                    des_artigo_pt_fte.Text = .Rows(0)("des_artigo_pt_fte").ToString()
                    des_video_pt_fte.Text = .Rows(0)("des_video_pt_fte").ToString()
                    des_entrevista_pt_fte.Text = .Rows(0)("des_entrevista_pt_fte").ToString()
                    des_livro_pt_fte.Text = .Rows(0)("des_livro_pt_fte").ToString()
                End With

                '*** Galeria de imagens
                Using obj As New ImagemProjeto
                    lDataView = obj.ListarImagemProjetoPorProjeto(CType(Request("cod_projeto_pro"), Int32))
                End Using

                If lDataView.Table.Rows.Count > 0 Then
                    Dim Lista As New List(Of String)

                    For Each lRow As DataRow In lDataView.Table.Rows
                        Lista.Add(lRow("nom_imagem_projeto_ipr"))
                        divGaleria.InnerHtml += "<div class='foto_projeto'><img src='../img/projetos/" & lRow("nom_imagem_projeto_ipr") & "' onclick=""imgClick('projetos/" & lRow("nom_imagem_projeto_ipr") & "', this);"" width='80px' height='80px' style='cursor:pointer;' /></div>"
                    Next

                    ViewState("Imagens") = Lista
                    divGaleria.InnerHtml += "<div class='clear'></div>"
                End If
            Else
                lblTitulo.Text = "Inclusão do projeto"
            End If
        End If

        pnlFoto.Visible = Not ViewState("Imagens") Is Nothing
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim cod_ficha_tecnica_fte As Int32
        Dim cod_projeto_pro As Int32
        Dim Lista As New List(Of String)

        '*** Cadastro da ficha técnica
        Using obj As New FichaTecnica
            Dim lDataSet As DataSet = obj.ConsultarFichaTecnica(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("nom_projeto_pt_fte") = des_identificacao_pro.Text
                .Rows(0)("nom_projeto_es_fte") = IIf(nom_projeto_es_fte.Text = "", DBNull.Value, nom_projeto_es_fte.Text)
                .Rows(0)("nom_projeto_en_fte") = IIf(nom_projeto_en_fte.Text = "", DBNull.Value, nom_projeto_en_fte.Text)
                .Rows(0)("des_projeto_pt_fte") = des_projeto_pt_fte.Text
                .Rows(0)("des_projeto_es_fte") = IIf(des_projeto_es_fte.Text = "", DBNull.Value, des_projeto_es_fte.Text)
                .Rows(0)("des_projeto_en_fte") = IIf(des_projeto_en_fte.Text = "", DBNull.Value, des_projeto_en_fte.Text)
                .Rows(0)("des_programa_pt_fte") = IIf(des_programa_pt_fte.Text = "", DBNull.Value, des_programa_pt_fte.Text)
                .Rows(0)("des_artigo_pt_fte") = IIf(des_artigo_pt_fte.Text = "", DBNull.Value, des_artigo_pt_fte.Text)
                .Rows(0)("des_video_pt_fte") = IIf(des_video_pt_fte.Text = "", DBNull.Value, des_video_pt_fte.Text)
                .Rows(0)("des_entrevista_pt_fte") = IIf(des_entrevista_pt_fte.Text = "", DBNull.Value, des_entrevista_pt_fte.Text)
                .Rows(0)("des_livro_pt_fte") = IIf(des_livro_pt_fte.Text = "", DBNull.Value, des_livro_pt_fte.Text)
            End With

            If Request("cod_projeto_pro") Is Nothing Then
                cod_ficha_tecnica_fte = obj.IncluirFichaTecnica(lDataSet)
            Else
                cod_ficha_tecnica_fte = CType(ViewState("cod_ficha_tecnica_fte"), Int32)
                lDataSet.Tables(0).Rows(0)("cod_ficha_tecnica_fte") = CType(ViewState("cod_ficha_tecnica_fte"), Int32)
                obj.AlterarFichaTecnica(lDataSet)
            End If
        End Using

        '*** Cadastro do projeto
        Using objProjeto As New Projeto
            Dim lDataSet As DataSet = objProjeto.ConsultarProjeto(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("des_identificacao_pro") = des_identificacao_pro.Text
                .Rows(0)("cod_ficha_tecnica_fte") = cod_ficha_tecnica_fte
                .Rows(0)("des_local_pro") = des_local_pro.Text
                .Rows(0)("num_posicao_vitrine_pro") = 9999
                .Rows(0)("cod_tipo_projeto_tpr") = cod_tipo_projeto_tpr.SelectedValue
                .Rows(0)("cod_cliente_cli") = cod_cliente_cli.SelectedValue
                .Rows(0)("cod_situacao_projeto_spr") = cod_situacao_projeto_spr.SelectedValue
                .Rows(0)("flg_vitrine_principal_pro") = flg_vitrine_principal_pro.Checked
                .Rows(0)("sts_ativo_pro") = sts_ativo_pro.Checked
                .Rows(0)("cod_usuario_usu") = Session("cod_usuario_usu")
            End With

            If Request("cod_projeto_pro") Is Nothing Then
                cod_projeto_pro = objProjeto.IncluirProjeto(lDataSet)
            Else
                cod_projeto_pro = CType(Request("cod_projeto_pro"), Int32)
                lDataSet.Tables(0).Rows(0)("cod_projeto_pro") = CType(Request("cod_projeto_pro"), Int32)
                objProjeto.AlterarProjeto(lDataSet)
            End If
        End Using

        '*** Associação dos profissionais participantes
        Using objProfissional As New Profissional
            objProfissional.ExcluirProjetoProfissionalPorProjeto(cod_projeto_pro)

            For Each item As ListItem In lstProfissionaisEnvolvidos.Items
                objProfissional.IncluirProjetoProfissional(CType(item.Value, Int32), cod_projeto_pro)
            Next
        End Using

        '*** Associação dos consultores participantes
        Using objConsultor As New ConsultorEspecializado
            objConsultor.ExcluirProjetoConsultorPorProjeto(cod_projeto_pro)

            For Each item As ListItem In lstConsultoresSelecionados.Items
                objConsultor.IncluirProjetoConsultor(CType(item.Value, Int32), cod_projeto_pro)
            Next
        End Using

        '*** Salva as imagens e carrega na ViewState
        CarregarSalvarImagens(cod_projeto_pro)
        If Not ViewState("Imagens") Is Nothing Then
            Lista = ViewState("Imagens")
        End If

        Using objImagem As New ImagemProjeto
            objImagem.ExcluirImagemProjetoPorProjeto(cod_projeto_pro)

            If Lista.Count > 0 Then
                Dim lDataSet As DataSet = objImagem.ConsultarImagemProjeto(-1).Table.DataSet

                With lDataSet.Tables(0)
                    .Rows.Add(.NewRow())
                    .Rows(0)("cod_projeto_pro") = cod_projeto_pro
                    .Rows(0)("num_ordem_ipr") = 9999

                    For Each item As String In Lista
                        If item <> "" Then
                            .Rows(0)("nom_imagem_projeto_ipr") = item
                            objImagem.IncluirImagemProjeto(lDataSet)
                        End If
                    Next
                End With
            End If
        End Using

        Response.Redirect("Projetos.aspx")
    End Sub

    Protected Sub btnExcluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcluir.Click
        If hfImagemClick.Value <> "" Then
            Dim imagem As String = hfImagemClick.Value.Split("/")(1)
            Dim Lista As List(Of String) = ViewState("Imagens")

            If Lista.Contains(imagem) Then
                Lista.Remove(imagem)
            End If

            If Lista.Count = 0 Then
                ViewState("Imagens") = Nothing
                pnlFoto.Visible = False
            Else
                ViewState("Imagens") = Lista
            End If

            PreencherGaleria()
            hfImagemClick.Value = ""
        Else
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType, "block", "alert('Selecione a imagem que deverá ser excluída!');", True)
        End If
    End Sub

    Protected Sub btnSim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSim.Click
        Using objProjeto As New Projeto
            objProjeto.AlterarProjetoStatusVitrine(rblProjetos.SelectedValue, False)
        End Using
    End Sub

    Protected Sub btnNao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNao.Click
        flg_vitrine_principal_pro.Checked = False
    End Sub

    Protected Sub btnRemoverTodosProfissionais_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoverTodosProfissionais.Click
        For Each item As ListItem In lstProfissionaisEnvolvidos.Items
            lstTodosProfissionais.Items.Add(New ListItem(item.Text, item.Value))
        Next

        '*** Remove a lista
        lstProfissionaisEnvolvidos.Items.Clear()
    End Sub

    Protected Sub btnAdicionarTodosProfissionais_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarTodosProfissionais.Click
        '*** Remove a lista
        lstProfissionaisEnvolvidos.Items.Clear()

        For Each item As ListItem In lstTodosProfissionais.Items
            lstProfissionaisEnvolvidos.Items.Add(New ListItem(item.Text, item.Value))
        Next

        '*** Remove a lista
        lstTodosProfissionais.Items.Clear()
    End Sub

    Protected Sub btnRemoverProfissionaisSelecionados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoverProfissionaisSelecionados.Click
        Dim Lista As New List(Of ListItem)

        For Each item As ListItem In lstProfissionaisEnvolvidos.Items
            If item.Selected Then
                If Not lstTodosProfissionais.Items.Contains(New ListItem(item.Text, item.Value)) Then
                    lstTodosProfissionais.Items.Add(New ListItem(item.Text, item.Value))
                End If
                Lista.Add(item)
            End If
        Next

        While Lista.Count > 0
            lstProfissionaisEnvolvidos.Items.Remove(Lista.Last())
            Lista.Remove(Lista.Last())
        End While
    End Sub

    Protected Sub btnAdicionarProfissionaisSelecionados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarProfissionaisSelecionados.Click
        Dim Lista As New List(Of ListItem)

        For Each item As ListItem In lstTodosProfissionais.Items
            If item.Selected Then
                If Not lstProfissionaisEnvolvidos.Items.Contains(New ListItem(item.Text, item.Value)) Then
                    lstProfissionaisEnvolvidos.Items.Add(New ListItem(item.Text, item.Value))
                End If
                Lista.Add(item)
            End If
        Next

        While Lista.Count > 0
            lstTodosProfissionais.Items.Remove(Lista.Last())
            Lista.Remove(Lista.Last())
        End While
    End Sub

    Protected Sub btnAdicionarConsultoresSelecionados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarConsultoresSelecionados.Click
        Dim Lista As New List(Of ListItem)

        For Each item As ListItem In lstTodosConsultores.Items
            If item.Selected Then
                If Not lstConsultoresSelecionados.Items.Contains(New ListItem(item.Text, item.Value)) Then
                    lstConsultoresSelecionados.Items.Add(New ListItem(item.Text, item.Value))
                End If
                Lista.Add(item)
            End If
        Next

        While Lista.Count > 0
            lstTodosConsultores.Items.Remove(Lista.Last())
            Lista.Remove(Lista.Last())
        End While
    End Sub

    Protected Sub btnAdicionarTodosConsultores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarTodosConsultores.Click
        '*** Remove a lista
        lstConsultoresSelecionados.Items.Clear()

        For Each item As ListItem In lstTodosConsultores.Items
            lstConsultoresSelecionados.Items.Add(New ListItem(item.Text, item.Value))
        Next

        '*** Remove a lista
        lstTodosConsultores.Items.Clear()
    End Sub

    Protected Sub btnRemoverConsultoresSelecionados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoverConsultoresSelecionados.Click
        Dim Lista As New List(Of ListItem)

        For Each item As ListItem In lstConsultoresSelecionados.Items
            If item.Selected Then
                If Not lstTodosConsultores.Items.Contains(New ListItem(item.Text, item.Value)) Then
                    lstTodosConsultores.Items.Add(New ListItem(item.Text, item.Value))
                End If
                Lista.Add(item)
            End If
        Next

        While Lista.Count > 0
            lstConsultoresSelecionados.Items.Remove(Lista.Last())
            Lista.Remove(Lista.Last())
        End While
    End Sub

    Protected Sub btnRemoverTodosConsultores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoverTodosConsultores.Click
        For Each item As ListItem In lstConsultoresSelecionados.Items
            lstTodosConsultores.Items.Add(New ListItem(item.Text, item.Value))
        Next

        '*** Remove a lista
        lstConsultoresSelecionados.Items.Clear()
    End Sub

#End Region

#Region " Métodos Gerais "

    Private Sub PreencherGaleria()
        divGaleria.InnerHtml = ""

        If Not ViewState("Imagens") Is Nothing Then
            Dim Lista As List(Of String) = ViewState("Imagens")

            For Each item As String In Lista
                If item <> "" Then
                    divGaleria.InnerHtml += "<div class='foto_projeto'><img src='../img/projetos/" & item & "' onclick=""imgClick('projetos/" & item & "', this);"" width='80px' height='80px' style='cursor:pointer;' /></div>"
                End If
            Next

            divGaleria.InnerHtml += "<div class='clear'></div>"
        End If
    End Sub

    Private Sub CarregarSalvarImagens(ByVal cod_projeto_pro As Int32)
        Dim Caminho As String = Server.MapPath("..") & "\img\projetos\"
        Dim Lista As New List(Of String)

        If Not ViewState("Imagens") Is Nothing Then
            Lista = ViewState("Imagens")
        End If

        If upl_nom_imagem_projeto_ipr1.HasFile Then
            Dim Nome As String = "pro1_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr1.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr1.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr2.HasFile Then
            Dim Nome As String = "pro2_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr2.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr2.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr3.HasFile Then
            Dim Nome As String = "pro3_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr3.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr3.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr4.HasFile Then
            Dim Nome As String = "pro4_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr4.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr4.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr5.HasFile Then
            Dim Nome As String = "pro5_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr5.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr5.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr6.HasFile Then
            Dim Nome As String = "pro6_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr6.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr6.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr7.HasFile Then
            Dim Nome As String = "pro7_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr7.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr7.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr8.HasFile Then
            Dim Nome As String = "pro8_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr8.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr8.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr9.HasFile Then
            Dim Nome As String = "pro9_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr9.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr9.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If upl_nom_imagem_projeto_ipr10.HasFile Then
            Dim Nome As String = "pro10_" & cod_projeto_pro & DateTime.Now.ToString("ddMMyyyyhhmmssfff") & "." & upl_nom_imagem_projeto_ipr10.FileName.Split(".")(1).ToLower

            upl_nom_imagem_projeto_ipr10.SaveAs(Caminho & Nome)
            Lista.Add(Nome)
        End If

        If Lista.Count > 0 Then
            ViewState("Imagens") = Lista
        Else
            ViewState("Imagens") = Nothing
        End If
    End Sub

#End Region

#Region " PreRenderComplete "

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
        If Not IsPostBack Then
            If Request("cod_projeto_pro") <> "" Then
                Dim lDataView As DataView

                '*** Cadastro dos profissionais
                Using obj As New Profissional
                    lDataView = obj.ListarProfissionalPorProjeto(CType(Request("cod_projeto_pro"), Int32))
                End Using

                For Each lRow As DataRow In lDataView.Table.Rows
                    lstProfissionaisEnvolvidos.Items.Add(New ListItem(lRow("nom_profissional_prf"), lRow("cod_profissional_prf")))
                    lstTodosProfissionais.Items.Remove(New ListItem(lRow("nom_profissional_prf"), lRow("cod_profissional_prf")))
                Next

                '*** Cadastro dos consultores
                Using obj As New ConsultorEspecializado
                    lDataView = obj.ListarConsultorEspecializadoPorProjeto(CType(Request("cod_projeto_pro"), Int32))
                End Using

                For Each lRow As DataRow In lDataView.Table.Rows
                    lstConsultoresSelecionados.Items.Add(New ListItem(lRow("nom_consultor_ces"), lRow("cod_consultor_especializado_ces")))
                    lstTodosConsultores.Items.Remove(New ListItem(lRow("nom_consultor_ces"), lRow("cod_consultor_especializado_ces")))
                Next
            End If
        End If
    End Sub

#End Region

#Region " Eventos Gerais "

    Protected Sub flg_vitrine_principal_pro_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flg_vitrine_principal_pro.CheckedChanged
        If flg_vitrine_principal_pro.Checked Then
            Dim lDataView As DataView

            Using objVitrine As New Projeto
                lDataView = objVitrine.ListarProjetoVitrine()
            End Using

            If lDataView.Table.Rows.Count = 3 AndAlso Not ViewState("flg_vitrine_principal_pro") Then
                rblProjetos.SelectedIndex = 0
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Motivo", "MostrarDiv();", True)
                Exit Sub
            End If
        End If
    End Sub

#End Region
    
End Class
