Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Cliente
    Implements IDisposable

#Region " Listar "

    Public Function ListarCliente() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_cliente_cli, nom_cliente_cli, des_email_cli, num_telefone_cli, num_celular_cli, num_cnpj_cli, des_login_cli, des_senha_cli, num_cpf_cli, dat_cadastro_cli "
        query &= "From tb_gma_cliente "
        query &= "Order by nom_cliente_cli "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_cliente")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarCliente(ByVal cod_cliente_cli As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_cliente_cli, nom_cliente_cli, des_email_cli, num_telefone_cli, num_celular_cli, num_cnpj_cli, des_login_cli, des_senha_cli, num_cpf_cli, dat_cadastro_cli "
        query &= "From tb_gma_cliente "
        query &= "Where cod_cliente_cli = ?cod_cliente_cli "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_cliente_cli", cod_cliente_cli)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_cliente")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirCliente(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_cliente(nom_cliente_cli, des_email_cli, num_telefone_cli, num_celular_cli, num_cnpj_cli, des_login_cli, des_senha_cli, num_cpf_cli, dat_cadastro_cli) "
        query &= "values(?nom_cliente_cli, ?des_email_cli, ?num_telefone_cli, ?num_celular_cli, ?num_cnpj_cli, ?des_login_cli, ?des_senha_cli, ?num_cpf_cli, NOW()); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_cliente_cli", dsRegistro.Tables(0).Rows(0)("nom_cliente_cli"))
            command.Parameters.AddWithValue("?des_email_cli", dsRegistro.Tables(0).Rows(0)("des_email_cli"))
            command.Parameters.AddWithValue("?num_telefone_cli", dsRegistro.Tables(0).Rows(0)("num_telefone_cli"))
            command.Parameters.AddWithValue("?num_celular_cli", dsRegistro.Tables(0).Rows(0)("num_celular_cli"))
            command.Parameters.AddWithValue("?num_cnpj_cli", dsRegistro.Tables(0).Rows(0)("num_cnpj_cli"))
            command.Parameters.AddWithValue("?des_login_cli", dsRegistro.Tables(0).Rows(0)("des_login_cli"))
            command.Parameters.AddWithValue("?des_senha_cli", dsRegistro.Tables(0).Rows(0)("des_senha_cli"))
            command.Parameters.AddWithValue("?num_cpf_cli", dsRegistro.Tables(0).Rows(0)("num_cpf_cli"))

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

    Public Sub AlterarCliente(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_cliente Set "
        query &= "nom_cliente_cli = ?nom_cliente_cli, "
        query &= "des_email_cli = ?des_email_cli, "
        query &= "num_telefone_cli = ?num_telefone_cli, "
        query &= "num_celular_cli = ?num_celular_cli, "
        query &= "num_cnpj_cli = ?num_cnpj_cli, "
        query &= "des_login_cli = ?des_login_cli, "
        query &= "des_senha_cli = ?des_senha_cli, "
        query &= "num_cpf_cli = ?num_cpf_cli, "
        query &= "dat_cadastro_cli = NOW() "
        query &= "Where cod_cliente_cli = ?cod_cliente_cli "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_cliente_cli", dsRegistro.Tables(0).Rows(0)("nom_cliente_cli"))
            command.Parameters.AddWithValue("?des_email_cli", dsRegistro.Tables(0).Rows(0)("des_email_cli"))
            command.Parameters.AddWithValue("?num_telefone_cli", dsRegistro.Tables(0).Rows(0)("num_telefone_cli"))
            command.Parameters.AddWithValue("?num_celular_cli", dsRegistro.Tables(0).Rows(0)("num_celular_cli"))
            command.Parameters.AddWithValue("?num_cnpj_cli", dsRegistro.Tables(0).Rows(0)("num_cnpj_cli"))
            command.Parameters.AddWithValue("?des_login_cli", dsRegistro.Tables(0).Rows(0)("des_login_cli"))
            command.Parameters.AddWithValue("?des_senha_cli", dsRegistro.Tables(0).Rows(0)("des_senha_cli"))
            command.Parameters.AddWithValue("?num_cpf_cli", dsRegistro.Tables(0).Rows(0)("num_cpf_cli"))
            command.Parameters.AddWithValue("?cod_cliente_cli", dsRegistro.Tables(0).Rows(0)("cod_cliente_cli"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirCliente(ByVal cod_cliente_cli As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_cliente "
        query &= "Where cod_cliente_cli = ?cod_cliente_cli "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_cliente_cli", cod_cliente_cli)

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
