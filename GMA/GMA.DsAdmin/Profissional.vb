Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Profissional
    Implements IDisposable

#Region " Listar "

    Public Function ListarProfissional() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_profissional_prf, nom_profissional_prf, des_email_prf, num_telefone_prf, num_celular_prf, sts_ativo_prf "
        query &= "From tb_gma_profissional "
        query &= "Order by nom_profissional_prf "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_profissional")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarProfissional(ByVal cod_profissional_prf As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_profissional_prf, nom_profissional_prf, des_email_prf, num_telefone_prf, num_celular_prf, sts_ativo_prf "
        query &= "From tb_gma_profissional "
        query &= "Where cod_profissional_prf = @cod_profissional_prf "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@cod_profissional_prf", cod_profissional_prf)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_profissional")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirProfissional(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_profissional(nom_profissional_prf, des_email_prf, num_telefone_prf, num_celular_prf, sts_ativo_prf) "
        query &= "values(?nom_profissional_prf, ?des_email_prf, ?num_telefone_prf, ?num_celular_prf, ?sts_ativo_prf); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_profissional_prf", dsRegistro.Tables(0).Rows(0)("nom_profissional_prf"))
            command.Parameters.AddWithValue("?des_email_prf", dsRegistro.Tables(0).Rows(0)("des_email_prf"))
            command.Parameters.AddWithValue("?num_telefone_prf", dsRegistro.Tables(0).Rows(0)("num_telefone_prf"))
            command.Parameters.AddWithValue("?num_celular_prf", dsRegistro.Tables(0).Rows(0)("num_celular_prf"))
            command.Parameters.AddWithValue("?sts_ativo_prf", dsRegistro.Tables(0).Rows(0)("sts_ativo_prf"))

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

    Public Sub AlterarProfissional(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_profissional Set "
        query &= "nom_profissional_prf = ?nom_profissional_prf, "
        query &= "des_email_prf = ?des_email_prf, "
        query &= "num_telefone_prf = ?num_telefone_prf, "
        query &= "num_celular_prf = ?num_celular_prf, "
        query &= "sts_ativo_prf = ?sts_ativo_prf "
        query &= "Where cod_profissional_prf = ?cod_profissional_prf "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_profissional_prf", dsRegistro.Tables(0).Rows(0)("nom_profissional_prf"))
            command.Parameters.AddWithValue("?des_email_prf", dsRegistro.Tables(0).Rows(0)("des_email_prf"))
            command.Parameters.AddWithValue("?num_telefone_prf", dsRegistro.Tables(0).Rows(0)("num_telefone_prf"))
            command.Parameters.AddWithValue("?num_celular_prf", dsRegistro.Tables(0).Rows(0)("num_celular_prf"))
            command.Parameters.AddWithValue("?sts_ativo_prf", dsRegistro.Tables(0).Rows(0)("sts_ativo_prf"))
            command.Parameters.AddWithValue("?cod_profissional_prf", dsRegistro.Tables(0).Rows(0)("cod_profissional_prf"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirProfissional(ByVal cod_profissional_prf As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_profissional "
        query &= "Where cod_profissional_prf = ?cod_profissional_prf "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_profissional_prf", cod_profissional_prf)

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
