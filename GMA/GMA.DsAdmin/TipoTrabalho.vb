Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class TipoTrabalho
    Implements IDisposable

#Region " Listar "

    Public Function ListarTipoTrabalho() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_tipo_trabalho_ttr, nom_tipo_trabalho_ttr "
        query &= "From tb_gma_tipo_trabalho "
        query &= "Order by nom_tipo_trabalho_ttr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_tipo_trabalho")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

    Public Function ListarTipoTrabalhoPorProjeto(ByVal cod_projeto_pro As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select tb_gma_tipo_trabalho.cod_tipo_trabalho_ttr, nom_tipo_trabalho_ttr "
        query &= "From tb_gma_tipo_trabalho "
        query &= "inner join tb_gma_projeto_tipo_trabalho on tb_gma_tipo_trabalho.cod_tipo_trabalho_ttr = tb_gma_projeto_tipo_trabalho.cod_tipo_trabalho_ttr "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "
        query &= "Order by nom_tipo_trabalho_ttr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_tipo_trabalho")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarTipoTrabalho(ByVal cod_tipo_trabalho_ttr As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_tipo_trabalho_ttr, nom_tipo_trabalho_ttr "
        query &= "From tb_gma_tipo_trabalho "
        query &= "Where cod_tipo_trabalho_ttr = ?cod_tipo_trabalho_ttr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_tipo_trabalho_ttr", cod_tipo_trabalho_ttr)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_tipo_trabalho")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirTipoTrabalho(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_tipo_trabalho(nom_tipo_trabalho_ttr) "
        query &= "values(?nom_tipo_trabalho_ttr); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_tipo_trabalho_ttr", dsRegistro.Tables(0).Rows(0)("nom_tipo_trabalho_ttr"))

            primaryKey = command.ExecuteScalar()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return primaryKey
    End Function

    Public Sub IncluirProjetoTipoTrabalho(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing
        Dim query As String = ""

        For Each lRow As DataRow In dsRegistro.Tables(0).Rows
            query &= "Insert into tb_gma_projeto_tipo_trabalho(cod_projeto_pro, cod_tipo_trabalho_ttr) "
            query &= "values(?cod_projeto_pro, ?cod_tipo_trabalho_ttr); "
        Next

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Alterar "

    Public Sub AlterarTipoTrabalho(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_tipo_trabalho Set "
        query &= "nom_tipo_trabalho_ttr = ?nom_tipo_trabalho_ttr "
        query &= "Where cod_tipo_trabalho_ttr = ?cod_tipo_trabalho_ttr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_tipo_trabalho_ttr", dsRegistro.Tables(0).Rows(0)("nom_tipo_trabalho_ttr"))
            command.Parameters.AddWithValue("?cod_tipo_trabalho_ttr", dsRegistro.Tables(0).Rows(0)("cod_tipo_trabalho_ttr"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirTipoTrabalho(ByVal cod_tipo_trabalho_ttr As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_tipo_trabalho "
        query &= "Where cod_tipo_trabalho_ttr = ?cod_tipo_trabalho_ttr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_tipo_trabalho_ttr", cod_tipo_trabalho_ttr)

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
