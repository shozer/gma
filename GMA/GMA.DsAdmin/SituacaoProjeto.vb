Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class SituacaoProjeto
    Implements IDisposable

#Region " Listar "

    Public Function ListarSituacaoProjeto() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_situacao_projeto_spr, nom_situacao_projeto_pt_spr, nom_situacao_projeto_en_spr, nom_situacao_projeto_es_spr "
        query &= "From tb_gma_situacao_projeto "
        query &= "Order by nom_situacao_projeto_pt_spr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_situacao_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarSituacaoProjeto(ByVal cod_situacao_projeto_spr As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_situacao_projeto_spr, nom_situacao_projeto_pt_spr, nom_situacao_projeto_en_spr, nom_situacao_projeto_es_spr "
        query &= "From tb_gma_situacao_projeto "
        query &= "Where cod_situacao_projeto_spr = ?cod_situacao_projeto_spr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", cod_situacao_projeto_spr)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_situacao_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirSituacaoProjeto(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_situacao_projeto(nom_situacao_projeto_pt_spr, nom_situacao_projeto_en_spr, nom_situacao_projeto_es_spr) "
        query &= "values(?nom_situacao_projeto_pt_spr, ?nom_situacao_projeto_en_spr, ?nom_situacao_projeto_es_spr); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_situacao_projeto_pt_spr", dsRegistro.Tables(0).Rows(0)("nom_situacao_projeto_pt_spr"))
            command.Parameters.AddWithValue("?nom_situacao_projeto_en_spr", dsRegistro.Tables(0).Rows(0)("nom_situacao_projeto_en_spr"))
            command.Parameters.AddWithValue("?nom_situacao_projeto_es_spr", dsRegistro.Tables(0).Rows(0)("nom_situacao_projeto_es_spr"))

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

    Public Sub AlterarSituacaoProjeto(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_situacao_projeto Set "
        query &= "nom_situacao_projeto_pt_spr = ?nom_situacao_projeto_pt_spr, "
        query &= "nom_situacao_projeto_en_spr = ?nom_situacao_projeto_en_spr, "
        query &= "nom_situacao_projeto_es_spr = ?nom_situacao_projeto_es_spr "
        query &= "Where cod_situacao_projeto_spr = ?cod_situacao_projeto_spr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_situacao_projeto_pt_spr", dsRegistro.Tables(0).Rows(0)("nom_situacao_projeto_pt_spr"))
            command.Parameters.AddWithValue("?nom_situacao_projeto_en_spr", dsRegistro.Tables(0).Rows(0)("nom_situacao_projeto_en_spr"))
            command.Parameters.AddWithValue("?nom_situacao_projeto_es_spr", dsRegistro.Tables(0).Rows(0)("nom_situacao_projeto_es_spr"))
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", dsRegistro.Tables(0).Rows(0)("cod_situacao_projeto_spr"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirSituacaoProjeto(ByVal cod_situacao_projeto_spr As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_situacao_projeto "
        query &= "Where cod_situacao_projeto_spr = ?cod_situacao_projeto_spr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_situacao_projeto_spr", cod_situacao_projeto_spr)

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
