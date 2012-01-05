﻿Imports System.Configuration.ConfigurationManager
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

        Dim query As String = "Select cod_projeto_pro, des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, cod_ficha_tecnica_fte, cod_tipo_projeto_tpr, cod_usuario_usu, cod_cliente_cli, cod_situacao_projeto_spr, sts_ativo_pro "
        query &= "From tb_gma_projeto "
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

#End Region

#Region " Consultar "

    Public Function ConsultarProjeto(ByVal cod_projeto_pro As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_projeto_pro, des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, cod_ficha_tecnica_fte, cod_tipo_projeto_tpr, cod_usuario_usu, cod_cliente_cli, cod_situacao_projeto_spr, sts_ativo_pro "
        query &= "From tb_gma_projeto "
        query &= "Where cod_projeto_pro = @cod_projeto_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@cod_projeto_pro", cod_projeto_pro)

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

        Dim query As String = "Insert into tb_gma_projeto(des_identificacao_pro, dat_cadastro_pro, num_posicao_vitrine_pro, cod_ficha_tecnica_fte, cod_tipo_projeto_tpr, cod_usuario_usu, cod_cliente_cli, cod_situacao_projeto_spr, sts_ativo_pro) "
        query &= "values(?des_identificacao_pro, CURDATE(), ?num_posicao_vitrine_pro, ?cod_ficha_tecnica_fte, ?cod_tipo_projeto_tpr, ?cod_usuario_usu, ?cod_cliente_cli, ?cod_situacao_projeto_spr, ?sts_ativo_pro); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?des_identificacao_pro", dsRegistro.Tables(0).Rows(0)("des_identificacao_pro"))
            command.Parameters.AddWithValue("?num_posicao_vitrine_pro", dsRegistro.Tables(0).Rows(0)("num_posicao_vitrine_pro"))
            command.Parameters.AddWithValue("?cod_ficha_tecnica_fte", dsRegistro.Tables(0).Rows(0)("cod_ficha_tecnica_fte"))
            command.Parameters.AddWithValue("?cod_tipo_projeto_tpr", dsRegistro.Tables(0).Rows(0)("cod_tipo_projeto_tpr"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?cod_cliente_cli", dsRegistro.Tables(0).Rows(0)("cod_cliente_cli"))
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", dsRegistro.Tables(0).Rows(0)("cod_situacao_projeto_spr"))
            command.Parameters.AddWithValue("?sts_ativo_pro", dsRegistro.Tables(0).Rows(0)("sts_ativo_pro"))

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
        query &= "dat_cadastro_pro = CURDATE(), "
        query &= "num_posicao_vitrine_pro = ?num_posicao_vitrine_pro, "
        query &= "cod_ficha_tecnica_fte = ?cod_ficha_tecnica_fte, "
        query &= "cod_tipo_projeto_tpr = ?cod_tipo_projeto_tpr, "
        query &= "cod_usuario_usu = ?cod_usuario_usu, "
        query &= "cod_cliente_cli = ?cod_cliente_cli, "
        query &= "cod_situacao_projeto_spr = ?cod_situacao_projeto_spr, "
        query &= "sts_ativo_pro = ?sts_ativo_pro "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?des_identificacao_pro", dsRegistro.Tables(0).Rows(0)("des_identificacao_pro"))
            command.Parameters.AddWithValue("?num_posicao_vitrine_pro", dsRegistro.Tables(0).Rows(0)("num_posicao_vitrine_pro"))
            command.Parameters.AddWithValue("?cod_ficha_tecnica_fte", dsRegistro.Tables(0).Rows(0)("cod_ficha_tecnica_fte"))
            command.Parameters.AddWithValue("?cod_tipo_projeto_tpr", dsRegistro.Tables(0).Rows(0)("cod_tipo_projeto_tpr"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?cod_cliente_cli", dsRegistro.Tables(0).Rows(0)("cod_cliente_cli"))
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", dsRegistro.Tables(0).Rows(0)("cod_situacao_projeto_spr"))
            command.Parameters.AddWithValue("?sts_ativo_pro", dsRegistro.Tables(0).Rows(0)("sts_ativo_pro"))
            command.Parameters.AddWithValue("?cod_projeto_pro", dsRegistro.Tables(0).Rows(0)("cod_projeto_pro"))

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