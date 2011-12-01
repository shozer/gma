Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Restricao
    Implements IDisposable

#Region " Listar "

    Public Function ListarRestricao() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_restricao_res, cod_arquivo_arq, cod_cliente_cli, cod_perfil_per "
        query &= "From tb_gma_restricao "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_restricao")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarRestricao(ByVal cod_restricao_res As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_restricao_res, cod_arquivo_arq, cod_cliente_cli, cod_perfil_per "
        query &= "From tb_gma_restricao "
        query &= "Where cod_restricao_res = @cod_restricao_res "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@cod_restricao_res", cod_restricao_res)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_restricao")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirRestricao(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_restricao(cod_arquivo_arq, cod_cliente_cli, cod_perfil_per) "
        query &= "values(?cod_arquivo_arq, ?cod_cliente_cli, ?cod_perfil_per); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_arquivo_arq", dsRegistro.Tables(0).Rows(0)("cod_arquivo_arq"))
            command.Parameters.AddWithValue("?cod_cliente_cli", dsRegistro.Tables(0).Rows(0)("cod_cliente_cli"))
            command.Parameters.AddWithValue("?cod_perfil_per", dsRegistro.Tables(0).Rows(0)("cod_perfil_per"))

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

    Public Sub AlterarRestricao(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_restricao Set "
        query &= "cod_arquivo_arq = ?cod_arquivo_arq, "
        query &= "cod_cliente_cli = ?cod_cliente_cli, "
        query &= "cod_perfil_per = ?cod_perfil_per "
        query &= "Where cod_restricao_res = ?cod_restricao_res "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_arquivo_arq", dsRegistro.Tables(0).Rows(0)("cod_arquivo_arq"))
            command.Parameters.AddWithValue("?cod_cliente_cli", dsRegistro.Tables(0).Rows(0)("cod_cliente_cli"))
            command.Parameters.AddWithValue("?cod_perfil_per", dsRegistro.Tables(0).Rows(0)("cod_perfil_per"))
            command.Parameters.AddWithValue("?cod_restricao_res", dsRegistro.Tables(0).Rows(0)("cod_restricao_res"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirRestricao(ByVal cod_restricao_res As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_restricao "
        query &= "Where cod_restricao_res = ?cod_restricao_res "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_restricao_res", cod_restricao_res)

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
