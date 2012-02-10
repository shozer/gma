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

                '*** Galeria de imagens
                Using obj As New ImagemProjeto
                    lDataView = obj.ListarImagemProjetoPorProjeto(CType(Request("cod_projeto_pro"), Int32))
                End Using

                For Each lRow As DataRow In lDataView.Table.Rows
                    divGaleria.InnerHtml += "<div class='foto_projeto'><img src='../img/projetos/" & lRow("nom_imagem_projeto_ipr") & "' /></div>"
                Next

                If lDataView.Table.Rows.Count > 0 Then
                    divGaleria.InnerHtml += "<div class='clear'></div>"
                End If
            Else
                lblTitulo.Text = "Inclusão do projeto"
            End If
        End If
    End Sub

#End Region

#Region " Botão "

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim cod_ficha_tecnica_fte As Int32
        Dim cod_projeto_pro As Int32

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

        Using objProjeto As New Projeto
            Dim lDataSet As DataSet = objProjeto.ConsultarProjeto(-1).Table.DataSet

            With lDataSet.Tables(0)
                .Rows.Add(.NewRow())
                .Rows(0)("des_identificacao_pro") = des_identificacao_pro.Text
                .Rows(0)("cod_ficha_tecnica_fte") = cod_ficha_tecnica_fte
                .Rows(0)("des_local_pro") = des_local_pro.Text
                .Rows(0)("cod_tipo_projeto_tpr") = cod_tipo_projeto_tpr.SelectedValue
                .Rows(0)("cod_cliente_cli") = cod_cliente_cli.SelectedValue
                .Rows(0)("cod_situacao_projeto_spr") = cod_situacao_projeto_spr.SelectedValue
                .Rows(0)("flg_vitrine_principal_pro") = flg_vitrine_principal_pro.Checked
                .Rows(0)("sts_ativo_pro") = sts_ativo_pro.Checked
            End With

            If Request("cod_projeto_pro") Is Nothing Then
                cod_projeto_pro = objProjeto.IncluirProjeto(lDataSet)
            Else
                cod_projeto_pro = CType(Request("cod_projeto_pro"), Int32)
                lDataSet.Tables(0).Rows(0)("cod_projeto_pro") = CType(Request("cod_projeto_pro"), Int32)
                objProjeto.AlterarProjeto(lDataSet)
            End If
        End Using

        Using objProfissional As New Profissional
            objProfissional.ExcluirProjetoProfissionalPorProjeto(cod_projeto_pro)

            For Each item As ListItem In lstProfissionaisEnvolvidos.Items
                objProfissional.IncluirProjetoProfissional(CType(item.Value, Int32), cod_projeto_pro)
            Next
        End Using

        Using objConsultor As New ConsultorEspecializado
            objConsultor.ExcluirProjetoConsultorPorProjeto(cod_projeto_pro)

            For Each item As ListItem In lstConsultoresSelecionados.Items
                objConsultor.IncluirProjetoConsultor(CType(item.Value, Int32), cod_projeto_pro)
            Next
        End Using

        Response.Redirect("Projetos.aspx")
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

End Class
