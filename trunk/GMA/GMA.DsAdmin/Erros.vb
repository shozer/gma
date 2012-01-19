Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Erros
    Implements IDisposable

#Region " Listar "

    Public Function ListarErros() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_erros_err, nom_pagina_err, num_ip_err, des_message_err, des_stacktrace_err, des_source_err, dat_cadastro_err, flg_verificado_err "
        query &= "From tb_gma_erros "
        query &= "Order by dat_cadastro_err desc "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_erros")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarErros(ByVal cod_erros_err As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_erros_err, nom_pagina_err, num_ip_err, des_message_err, des_stacktrace_err, des_source_err, dat_cadastro_err, flg_verificado_err "
        query &= "From tb_gma_erros "
        query &= "Where cod_erros_err = ?cod_erros_err "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_erros_err", cod_erros_err)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_erros")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirErros(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_erros(nom_pagina_err, num_ip_err, des_message_err, des_stacktrace_err, des_source_err, dat_cadastro_err, flg_verificado_err) "
        query &= "values(?nom_pagina_err, ?num_ip_err, ?des_message_err, ?des_stacktrace_err, ?des_source_err, CURDATE(), 0); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_pagina_err", dsRegistro.Tables(0).Rows(0)("nom_pagina_err"))
            command.Parameters.AddWithValue("?num_ip_err", dsRegistro.Tables(0).Rows(0)("num_ip_err"))
            command.Parameters.AddWithValue("?des_message_err", dsRegistro.Tables(0).Rows(0)("des_message_err"))
            command.Parameters.AddWithValue("?des_stacktrace_err", dsRegistro.Tables(0).Rows(0)("des_stacktrace_err"))
            command.Parameters.AddWithValue("?des_source_err", dsRegistro.Tables(0).Rows(0)("des_source_err"))

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

    Public Sub AlterarErros(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_erros Set "
        query &= "nom_pagina_err = ?nom_pagina_err, "
        query &= "num_ip_err = ?num_ip_err, "
        query &= "des_message_err = ?des_message_err, "
        query &= "des_stacktrace_err = ?des_stacktrace_err, "
        query &= "des_stacktrace_err = ?des_stacktrace_err, "
        query &= "flg_verificado_err = ?flg_verificado_err, "
        query &= "dat_cadastro_err = CURDATE() "
        query &= "Where cod_erros_err = ?cod_erros_err "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_pagina_err", dsRegistro.Tables(0).Rows(0)("nom_pagina_err"))
            command.Parameters.AddWithValue("?num_ip_err", dsRegistro.Tables(0).Rows(0)("num_ip_err"))
            command.Parameters.AddWithValue("?des_message_err", dsRegistro.Tables(0).Rows(0)("des_message_err"))
            command.Parameters.AddWithValue("?des_stacktrace_err", dsRegistro.Tables(0).Rows(0)("des_stacktrace_err"))
            command.Parameters.AddWithValue("?des_source_err", dsRegistro.Tables(0).Rows(0)("des_source_err"))
            command.Parameters.AddWithValue("?flg_verificado_err", dsRegistro.Tables(0).Rows(0)("flg_verificado_err"))
            command.Parameters.AddWithValue("?cod_erros_err", dsRegistro.Tables(0).Rows(0)("cod_erros_err"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirErros(ByVal cod_erros_err As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_erros "
        query &= "Where cod_erros_err = ?cod_erros_err "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_erros_err", cod_erros_err)

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
