Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Arquivo
    Implements IDisposable

#Region " Listar "

    Public Function ListarArquivo() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_arquivo_arq, nom_arquivo_arq, des_arquivo_pt_arq, des_arquivo_en_arq, des_arquivo_es_arq, dat_cadastro_arq, sts_ativo_arq "
        query &= "From tb_gma_arquivo "
        query &= "Order by nom_arquivo_arq "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_arquivo")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarArquivo(ByVal cod_arquivo_arq As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_arquivo_arq, nom_arquivo_arq, des_arquivo_pt_arq, des_arquivo_en_arq, des_arquivo_es_arq, dat_cadastro_arq, sts_ativo_arq "
        query &= "From tb_gma_arquivo "
        query &= "Where cod_arquivo_arq = @cod_arquivo_arq "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@cod_arquivo_arq", cod_arquivo_arq)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_arquivo")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirArquivo(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_arquivo(nom_arquivo_arq, des_arquivo_pt_arq, des_arquivo_en_arq, des_arquivo_es_arq, dat_cadastro_arq, sts_ativo_arq) "
        query &= "values(?nom_arquivo_arq, ?des_arquivo_pt_arq, ?des_arquivo_en_arq, ?des_arquivo_es_arq, CURDATE(), ?sts_ativo_arq); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_arquivo_arq", dsRegistro.Tables(0).Rows(0)("nom_arquivo_arq"))
            command.Parameters.AddWithValue("?des_arquivo_pt_arq", dsRegistro.Tables(0).Rows(0)("des_arquivo_pt_arq"))
            command.Parameters.AddWithValue("?des_arquivo_en_arq", dsRegistro.Tables(0).Rows(0)("des_arquivo_en_arq"))
            command.Parameters.AddWithValue("?des_arquivo_es_arq", dsRegistro.Tables(0).Rows(0)("des_arquivo_es_arq"))
            command.Parameters.AddWithValue("?sts_ativo_arq", dsRegistro.Tables(0).Rows(0)("sts_ativo_arq"))

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

    Public Sub AlterarArquivo(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_arquivo Set "
        query &= "nom_arquivo_arq = ?nom_arquivo_arq, "
        query &= "des_arquivo_pt_arq = ?des_arquivo_pt_arq, "
        query &= "des_arquivo_en_arq = ?des_arquivo_en_arq, "
        query &= "des_arquivo_es_arq = ?des_arquivo_es_arq, "
        query &= "dat_cadastro_arq = CURDATE(), "
        query &= "sts_ativo_arq = ?sts_ativo_arq "
        query &= "Where cod_arquivo_arq = ?cod_arquivo_arq "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_arquivo_arq", dsRegistro.Tables(0).Rows(0)("nom_arquivo_arq"))
            command.Parameters.AddWithValue("?des_arquivo_pt_arq", dsRegistro.Tables(0).Rows(0)("des_arquivo_pt_arq"))
            command.Parameters.AddWithValue("?des_arquivo_en_arq", dsRegistro.Tables(0).Rows(0)("des_arquivo_en_arq"))
            command.Parameters.AddWithValue("?des_arquivo_es_arq", dsRegistro.Tables(0).Rows(0)("des_arquivo_es_arq"))
            command.Parameters.AddWithValue("?sts_ativo_arq", dsRegistro.Tables(0).Rows(0)("sts_ativo_arq"))
            command.Parameters.AddWithValue("?cod_arquivo_arq", dsRegistro.Tables(0).Rows(0)("cod_arquivo_arq"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirArquivo(ByVal cod_arquivo_arq As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_arquivo "
        query &= "Where cod_arquivo_arq = ?cod_arquivo_arq "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_arquivo_arq", cod_arquivo_arq)

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
