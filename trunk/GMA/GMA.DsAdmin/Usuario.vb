﻿Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Usuario
    Implements IDisposable

#Region " Listar "

    Public Function ListarUsuario() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_usuario_usu, nom_usuario_usu, des_email_usu, num_telefone_usu, num_celular_usu, cod_perfil_per, des_login_usu, des_senha_usu, sts_ativo_usu "
        query &= "From tb_gma_usuario "
        query &= "Order by nom_usuario_usu "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_usuario")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarUsuario(ByVal cod_usuario_usu As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_usuario_usu, nom_usuario_usu, des_email_usu, num_telefone_usu, num_celular_usu, cod_perfil_per, des_login_usu, des_senha_usu, sts_ativo_usu "
        query &= "From tb_gma_usuario "
        query &= "Where cod_usuario_usu = @cod_usuario_usu "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@cod_usuario_usu", cod_usuario_usu)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_usuario")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirUsuario(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_Usuario(nom_usuario_usu, des_email_usu, num_telefone_usu, num_celular_usu, cod_perfil_per, des_login_usu, des_senha_usu, sts_ativo_usu) "
        query &= "values(?nom_usuario_usu, ?des_email_usu, ?num_telefone_usu, ?num_celular_usu, ?cod_perfil_per, ?des_login_usu, ?des_senha_usu, ?sts_ativo_usu); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_usuario_usu", dsRegistro.Tables(0).Rows(0)("nom_usuario_usu"))
            command.Parameters.AddWithValue("?des_email_usu", dsRegistro.Tables(0).Rows(0)("des_email_usu"))
            command.Parameters.AddWithValue("?num_telefone_usu", dsRegistro.Tables(0).Rows(0)("num_telefone_usu"))
            command.Parameters.AddWithValue("?num_celular_usu", dsRegistro.Tables(0).Rows(0)("num_celular_usu"))
            command.Parameters.AddWithValue("?cod_perfil_per", dsRegistro.Tables(0).Rows(0)("cod_perfil_per"))
            command.Parameters.AddWithValue("?des_login_usu", dsRegistro.Tables(0).Rows(0)("des_login_usu"))
            command.Parameters.AddWithValue("?des_senha_usu", dsRegistro.Tables(0).Rows(0)("des_senha_usu"))
            command.Parameters.AddWithValue("?sts_ativo_usu", dsRegistro.Tables(0).Rows(0)("sts_ativo_usu"))

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

    Public Sub AlterarUsuario(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_usuario Set "
        query &= "nom_usuario_usu = ?nom_usuario_usu, "
        query &= "des_email_usu = ?des_email_usu, "
        query &= "num_telefone_usu = ?num_telefone_usu, "
        query &= "num_celular_usu = ?num_celular_usu, "
        query &= "cod_perfil_per = ?cod_perfil_per, "
        query &= "des_login_usu = ?des_login_usu, "
        query &= "des_senha_usu = ?des_senha_usu, "
        query &= "sts_ativo_usu = ?sts_ativo_usu "
        query &= "Where cod_usuario_usu = ?cod_usuario_usu "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_usuario_usu", dsRegistro.Tables(0).Rows(0)("nom_usuario_usu"))
            command.Parameters.AddWithValue("?des_email_usu", dsRegistro.Tables(0).Rows(0)("des_email_usu"))
            command.Parameters.AddWithValue("?num_telefone_usu", dsRegistro.Tables(0).Rows(0)("num_telefone_usu"))
            command.Parameters.AddWithValue("?num_celular_usu", dsRegistro.Tables(0).Rows(0)("num_celular_usu"))
            command.Parameters.AddWithValue("?cod_perfil_per", dsRegistro.Tables(0).Rows(0)("cod_perfil_per"))
            command.Parameters.AddWithValue("?des_login_usu", dsRegistro.Tables(0).Rows(0)("des_login_usu"))
            command.Parameters.AddWithValue("?des_senha_usu", dsRegistro.Tables(0).Rows(0)("des_senha_usu"))
            command.Parameters.AddWithValue("?sts_ativo_usu", dsRegistro.Tables(0).Rows(0)("sts_ativo_usu"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirUsuario(ByVal cod_usuario_usu As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_usuario "
        query &= "Where cod_usuario_usu = ?cod_usuario_usu "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_usuario_usu", cod_usuario_usu)

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
