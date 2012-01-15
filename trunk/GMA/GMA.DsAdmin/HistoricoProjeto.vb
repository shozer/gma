Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class HistoricoProjeto
    Implements IDisposable

#Region " Listar "

    Public Function ListarHistoricoProjeto() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_historico_projeto_hpr, cod_usuario_usu, cod_situacao_projeto_spr, cod_projeto_pro, dat_cadastro_hpr "
        query &= "From tb_gma_historico_projeto "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_historico_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarHistoricoProjeto(ByVal cod_historico_projeto_hpr As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_historico_projeto_hpr, cod_usuario_usu, cod_situacao_projeto_spr, cod_projeto_pro, dat_cadastro_hpr "
        query &= "From tb_gma_historico_projeto "
        query &= "Where cod_historico_projeto_hpr = ?cod_historico_projeto_hpr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_historico_projeto_hpr", cod_historico_projeto_hpr)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_historico_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirHistoricoProjeto(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_historico_projeto(cod_usuario_usu, cod_situacao_projeto_spr, cod_projeto_pro, dat_cadastro_hpr) "
        query &= "values(?cod_usuario_usu, ?cod_situacao_projeto_spr, ?cod_projeto_pro, CURDATE()); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", dsRegistro.Tables(0).Rows(0)("cod_situacao_projeto_spr"))
            command.Parameters.AddWithValue("?cod_projeto_pro", dsRegistro.Tables(0).Rows(0)("cod_projeto_pro"))

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

    Public Sub AlterarHistoricoProjeto(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_historico_projeto Set "
        query &= "cod_usuario_usu = ?cod_usuario_usu, "
        query &= "cod_situacao_projeto_spr = ?cod_situacao_projeto_spr, "
        query &= "cod_projeto_pro = ?cod_projeto_pro, "
        query &= "dat_cadastro_hpr = CURDATE() "
        query &= "Where cod_historico_projeto_hpr = ?cod_historico_projeto_hpr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", dsRegistro.Tables(0).Rows(0)("cod_situacao_projeto_spr"))
            command.Parameters.AddWithValue("?cod_projeto_pro", dsRegistro.Tables(0).Rows(0)("cod_projeto_pro"))
            command.Parameters.AddWithValue("?cod_historico_projeto_hpr", dsRegistro.Tables(0).Rows(0)("cod_historico_projeto_hpr"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirHistoricoProjeto(ByVal cod_historico_projeto_hpr As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_historico_projeto "
        query &= "Where cod_historico_projeto_hpr = ?cod_historico_projeto_hpr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_historico_projeto_hpr", cod_historico_projeto_hpr)

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
