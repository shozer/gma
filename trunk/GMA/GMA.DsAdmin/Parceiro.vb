Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Parceiro
    Implements IDisposable

#Region " Listar "

    Public Function ListarParceiro() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_parceiro_par, nom_parceiro_par, des_imagem_par, des_link_par, tb_gma_parceiro.cod_usuario_usu, nom_usuario_usu, sts_ativo_par "
        query &= "From tb_gma_parceiro "
        query &= "inner join tb_gma_usuario on tb_gma_parceiro.cod_usuario_usu = tb_gma_usuario.cod_usuario_usu "
        query &= "Order by nom_parceiro_par "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_parceiro")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarParceiro(ByVal cod_parceiro_par As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_parceiro_par, nom_parceiro_par, des_imagem_par, des_link_par, cod_usuario_usu, sts_ativo_par "
        query &= "From tb_gma_parceiro "
        query &= "Where cod_parceiro_par = ?cod_parceiro_par "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_parceiro_par", cod_parceiro_par)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_parceiro")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirParceiro(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_parceiro(nom_parceiro_par, des_imagem_par, des_link_par, cod_usuario_usu, sts_ativo_par) "
        query &= "values(?nom_parceiro_par, ?des_imagem_par, ?des_link_par, ?cod_usuario_usu, ?sts_ativo_par); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_parceiro_par", dsRegistro.Tables(0).Rows(0)("nom_parceiro_par"))
            command.Parameters.AddWithValue("?des_imagem_par", dsRegistro.Tables(0).Rows(0)("des_imagem_par"))
            command.Parameters.AddWithValue("?des_link_par", dsRegistro.Tables(0).Rows(0)("des_link_par"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?sts_ativo_par", dsRegistro.Tables(0).Rows(0)("sts_ativo_par"))

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

    Public Sub AlterarParceiro(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_parceiro Set "
        query &= "nom_parceiro_par = ?nom_parceiro_par, "
        query &= "des_imagem_par = ?des_imagem_par, "
        query &= "des_link_par = ?des_link_par, "
        query &= "cod_usuario_usu = ?cod_usuario_usu, "
        query &= "sts_ativo_par = ?sts_ativo_par "
        query &= "Where cod_parceiro_par = ?cod_parceiro_par "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_parceiro_par", dsRegistro.Tables(0).Rows(0)("nom_parceiro_par"))
            command.Parameters.AddWithValue("?des_imagem_par", dsRegistro.Tables(0).Rows(0)("des_imagem_par"))
            command.Parameters.AddWithValue("?des_link_par", dsRegistro.Tables(0).Rows(0)("des_link_par"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?sts_ativo_par", dsRegistro.Tables(0).Rows(0)("sts_ativo_par"))
            command.Parameters.AddWithValue("?cod_parceiro_par", dsRegistro.Tables(0).Rows(0)("cod_parceiro_par"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirParceiro(ByVal cod_parceiro_par As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_parceiro "
        query &= "Where cod_parceiro_par = ?cod_parceiro_par "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_parceiro_par", cod_parceiro_par)

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
