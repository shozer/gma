Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Projeto
    Implements IDisposable

#Region " Listar "

    Public Function ListarProjeto() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select tb_gma_projeto.cod_projeto_pro, des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, cod_ficha_tecnica_fte, tb_gma_projeto.cod_tipo_projeto_tpr, nom_tipo_projeto_pt_tpr, cod_usuario_usu, tb_gma_projeto.cod_cliente_cli, nom_cliente_cli, tb_gma_projeto.cod_situacao_projeto_spr, nom_situacao_projeto_pt_spr, des_local_pro, flg_vitrine_principal_pro, sts_ativo_pro, des_briefing_pt_pro, des_briefing_es_pro, des_briefing_en_pro "
        query &= "From tb_gma_projeto "
        query &= "inner join tb_gma_tipo_projeto on tb_gma_projeto.cod_tipo_projeto_tpr = tb_gma_tipo_projeto.cod_tipo_projeto_tpr "
        query &= "inner join tb_gma_situacao_projeto on tb_gma_projeto.cod_situacao_projeto_spr = tb_gma_situacao_projeto.cod_situacao_projeto_spr "
        query &= "inner join tb_gma_cliente on tb_gma_projeto.cod_cliente_cli = tb_gma_cliente.cod_cliente_cli "
        query &= "Order by des_identificacao_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

    Public Function ListarProjetoAtivoPorTipoProjeto(ByVal cod_tipo_projeto_tpr As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_projeto_pro, des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, cod_ficha_tecnica_fte, cod_tipo_projeto_tpr, cod_usuario_usu, cod_cliente_cli, cod_situacao_projeto_spr, des_local_pro, flg_vitrine_principal_pro, sts_ativo_pro, des_briefing_pt_pro, des_briefing_es_pro, des_briefing_en_pro, "
        query &= "(select nom_imagem_projeto_ipr from tb_gma_imagem_projeto where tb_gma_projeto.cod_projeto_pro = tb_gma_imagem_projeto.cod_projeto_pro Order By num_ordem_ipr asc LIMIT 1) as nom_imagem_projeto_ipr "
        query &= "From tb_gma_projeto "
        query &= "Where sts_ativo_pro = 1 "
        query &= "and cod_tipo_projeto_tpr = ?cod_tipo_projeto_tpr "
        query &= "Order by num_posicao_vitrine_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_tipo_projeto_tpr", cod_tipo_projeto_tpr)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

    Public Function ListarProjetoPrincipal() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_projeto_pro, des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, cod_ficha_tecnica_fte, cod_tipo_projeto_tpr, cod_usuario_usu, cod_cliente_cli, cod_situacao_projeto_spr, des_local_pro, flg_vitrine_principal_pro, sts_ativo_pro, des_briefing_pt_pro, des_briefing_es_pro, des_briefing_en_pro "
        query &= "From tb_gma_projeto "
        query &= "Where flg_vitrine_principal_pro = 1 "
        query &= "and sts_ativo_pro = 1 "
        query &= "Order by dat_cadastro_pro desc LIMIT 1 "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

    Public Function ListarProjetoVitrine() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_projeto_pro, des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, tb_gma_projeto.cod_ficha_tecnica_fte, cod_tipo_projeto_tpr, cod_usuario_usu, cod_cliente_cli, cod_situacao_projeto_spr, des_local_pro, flg_vitrine_principal_pro, sts_ativo_pro, des_briefing_pt_pro, des_briefing_es_pro, des_briefing_en_pro, "
        query &= "nom_projeto_pt_fte, nom_projeto_en_fte, nom_projeto_es_fte, des_projeto_pt_fte, des_projeto_en_fte, des_projeto_es_fte, des_programa_pt_fte, des_artigo_pt_fte, des_video_pt_fte, des_entrevista_pt_fte, des_livro_pt_fte "
        query &= "From tb_gma_projeto "
        query &= "inner join tb_gma_ficha_tecnica on tb_gma_projeto.cod_ficha_tecnica_fte = tb_gma_ficha_tecnica.cod_ficha_tecnica_fte "
        query &= "Where flg_vitrine_principal_pro = 1 "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarProjeto(ByVal cod_projeto_pro As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_projeto_pro, des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, cod_ficha_tecnica_fte, cod_tipo_projeto_tpr, cod_usuario_usu, cod_cliente_cli, cod_situacao_projeto_spr, des_local_pro, flg_vitrine_principal_pro, sts_ativo_pro, des_briefing_pt_pro, des_briefing_es_pro, des_briefing_en_pro "
        query &= "From tb_gma_projeto "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirProjeto(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_projeto(des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, cod_ficha_tecnica_fte, cod_tipo_projeto_tpr, cod_usuario_usu, cod_cliente_cli, cod_situacao_projeto_spr, des_local_pro, flg_vitrine_principal_pro, sts_ativo_pro, des_briefing_pt_pro, des_briefing_es_pro, des_briefing_en_pro) "
        query &= "select ?des_identificacao_pro, NOW(), max(num_posicao_vitrine_pro) + 1, ?cod_ficha_tecnica_fte, ?cod_tipo_projeto_tpr, ?cod_usuario_usu, ?cod_cliente_cli, ?cod_situacao_projeto_spr, ?des_local_pro, ?flg_vitrine_principal_pro, ?sts_ativo_pro, ?des_briefing_pt_pro, ?des_briefing_es_pro, ?des_briefing_en_pro from tb_gma_projeto where cod_tipo_projeto_tpr = ?cod_tipo_projeto_tpr; SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?des_identificacao_pro", dsRegistro.Tables(0).Rows(0)("des_identificacao_pro"))
            command.Parameters.AddWithValue("?cod_ficha_tecnica_fte", dsRegistro.Tables(0).Rows(0)("cod_ficha_tecnica_fte"))
            command.Parameters.AddWithValue("?cod_tipo_projeto_tpr", dsRegistro.Tables(0).Rows(0)("cod_tipo_projeto_tpr"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?cod_cliente_cli", dsRegistro.Tables(0).Rows(0)("cod_cliente_cli"))
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", dsRegistro.Tables(0).Rows(0)("cod_situacao_projeto_spr"))
            command.Parameters.AddWithValue("?des_local_pro", dsRegistro.Tables(0).Rows(0)("des_local_pro"))
            command.Parameters.AddWithValue("?flg_vitrine_principal_pro", dsRegistro.Tables(0).Rows(0)("flg_vitrine_principal_pro"))
            command.Parameters.AddWithValue("?sts_ativo_pro", dsRegistro.Tables(0).Rows(0)("sts_ativo_pro"))
            command.Parameters.AddWithValue("?des_briefing_pt_pro", dsRegistro.Tables(0).Rows(0)("des_briefing_pt_pro"))
            command.Parameters.AddWithValue("?des_briefing_es_pro", dsRegistro.Tables(0).Rows(0)("des_briefing_es_pro"))
            command.Parameters.AddWithValue("?des_briefing_en_pro", dsRegistro.Tables(0).Rows(0)("des_briefing_en_pro"))

            primaryKey = command.ExecuteScalar()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return primaryKey
    End Function

#End Region

#Region " Alterar "

    Public Sub AlterarProjeto(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_projeto Set "
        query &= "des_identificacao_pro = ?des_identificacao_pro, "
        query &= "dat_cadastro_pro = NOW(), "
        query &= "cod_ficha_tecnica_fte = ?cod_ficha_tecnica_fte, "
        query &= "cod_tipo_projeto_tpr = ?cod_tipo_projeto_tpr, "
        query &= "cod_usuario_usu = ?cod_usuario_usu, "
        query &= "cod_cliente_cli = ?cod_cliente_cli, "
        query &= "cod_situacao_projeto_spr = ?cod_situacao_projeto_spr, "
        query &= "des_local_pro = ?des_local_pro, "
        query &= "flg_vitrine_principal_pro = ?flg_vitrine_principal_pro, "
        query &= "sts_ativo_pro = ?sts_ativo_pro, "
        query &= "des_briefing_pt_pro = ?des_briefing_pt_pro, "
        query &= "des_briefing_es_pro = ?des_briefing_es_pro, "
        query &= "des_briefing_en_pro = ?des_briefing_en_pro "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?des_identificacao_pro", dsRegistro.Tables(0).Rows(0)("des_identificacao_pro"))
            command.Parameters.AddWithValue("?cod_ficha_tecnica_fte", dsRegistro.Tables(0).Rows(0)("cod_ficha_tecnica_fte"))
            command.Parameters.AddWithValue("?cod_tipo_projeto_tpr", dsRegistro.Tables(0).Rows(0)("cod_tipo_projeto_tpr"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?cod_cliente_cli", dsRegistro.Tables(0).Rows(0)("cod_cliente_cli"))
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", dsRegistro.Tables(0).Rows(0)("cod_situacao_projeto_spr"))
            command.Parameters.AddWithValue("?des_local_pro", dsRegistro.Tables(0).Rows(0)("des_local_pro"))
            command.Parameters.AddWithValue("?flg_vitrine_principal_pro", dsRegistro.Tables(0).Rows(0)("flg_vitrine_principal_pro"))
            command.Parameters.AddWithValue("?sts_ativo_pro", dsRegistro.Tables(0).Rows(0)("sts_ativo_pro"))
            command.Parameters.AddWithValue("?cod_projeto_pro", dsRegistro.Tables(0).Rows(0)("cod_projeto_pro"))
            command.Parameters.AddWithValue("?des_briefing_pt_pro", dsRegistro.Tables(0).Rows(0)("des_briefing_pt_pro"))
            command.Parameters.AddWithValue("?des_briefing_es_pro", dsRegistro.Tables(0).Rows(0)("des_briefing_es_pro"))
            command.Parameters.AddWithValue("?des_briefing_en_pro", dsRegistro.Tables(0).Rows(0)("des_briefing_en_pro"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub AlterarProjetoStatusVitrine(ByVal cod_projeto_pro As Int32, ByVal flg_vitrine_principal_pro As Boolean)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_projeto Set "
        query &= "flg_vitrine_principal_pro = ?flg_vitrine_principal_pro "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?flg_vitrine_principal_pro", flg_vitrine_principal_pro)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub AlterarProjetoPosicao(ByVal cod_projeto_pro As Int32, ByVal num_posicao_vitrine_pro As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_projeto Set "
        query &= "num_posicao_vitrine_pro = ?num_posicao_vitrine_pro "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?num_posicao_vitrine_pro", num_posicao_vitrine_pro)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirProjeto(ByVal cod_projeto_pro As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_projeto "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Dispose "

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class
