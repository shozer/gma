Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Contatos
    Implements IDisposable

#Region " Listar "

    Public Function ListarContatos() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_contato_con, nom_contato_con, des_email_con, num_telefone_con, num_celular_con "
        query &= "From tb_gma_contatos "
        query &= "Order by nom_contato_con "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_contatos")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarContatos(ByVal cod_contato_con As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_contato_con, nom_contato_con, des_email_con, num_telefone_con, num_celular_con "
        query &= "From tb_gma_contatos "
        query &= "Where cod_contato_con = @cod_contato_con "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@cod_contato_con", cod_contato_con)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_contatos")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirContatos(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_contatos(nom_contato_con, des_email_con, num_telefone_con, num_celular_con) "
        query &= "values(?nom_contato_con, ?des_email_con, ?num_telefone_con, ?num_celular_con); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_contato_con", dsRegistro.Tables(0).Rows(0)("nom_contato_con"))
            command.Parameters.AddWithValue("?des_email_con", dsRegistro.Tables(0).Rows(0)("des_email_con"))
            command.Parameters.AddWithValue("?num_telefone_con", dsRegistro.Tables(0).Rows(0)("num_telefone_con"))
            command.Parameters.AddWithValue("?num_celular_con", dsRegistro.Tables(0).Rows(0)("num_celular_con"))

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

    Public Sub AlterarContatos(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_contatos Set "
        query &= "nom_contato_con = ?nom_contato_con, "
        query &= "des_email_con = ?des_email_con, "
        query &= "num_telefone_con = ?num_telefone_con, "
        query &= "num_celular_con = ?num_celular_con "
        query &= "Where cod_contato_con = ?cod_contato_con "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_contato_con", dsRegistro.Tables(0).Rows(0)("nom_contato_con"))
            command.Parameters.AddWithValue("?des_email_con", dsRegistro.Tables(0).Rows(0)("des_email_con"))
            command.Parameters.AddWithValue("?num_telefone_con", dsRegistro.Tables(0).Rows(0)("num_telefone_con"))
            command.Parameters.AddWithValue("?num_celular_con", dsRegistro.Tables(0).Rows(0)("num_celular_con"))
            command.Parameters.AddWithValue("?cod_contato_con", dsRegistro.Tables(0).Rows(0)("cod_contato_con"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirContatos(ByVal cod_contato_con As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_contatos "
        query &= "Where cod_contato_con = ?cod_contato_con "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_contato_con", cod_contato_con)

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
