Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Noticia
    Implements IDisposable

#Region " Listar "

    Public Function ListarNoticia() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_noticia_not, des_titulo_pt_not, des_titulo_en_not, des_titulo_es_not, des_descricao_pt_not, des_descricao_en_not, des_descricao_es_not, des_noticia_pt_not, des_noticia_en_not, des_noticia_es_not, dat_cadastro_not, sts_ativo_not, tb_gma_noticia.cod_usuario_usu, nom_usuario_usu "
        query &= "From tb_gma_noticia "
        query &= "inner join tb_gma_usuario on tb_gma_noticia.cod_usuario_usu = tb_gma_usuario.cod_usuario_usu "
        query &= "Order by des_titulo_pt_not "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_noticia")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

    Public Function ListarNoticiaAtivo() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_noticia_not, des_titulo_pt_not, des_titulo_en_not, des_titulo_es_not, des_descricao_pt_not, des_descricao_en_not, des_descricao_es_not, des_noticia_pt_not, des_noticia_en_not, des_noticia_es_not, dat_cadastro_not, sts_ativo_not, tb_gma_noticia.cod_usuario_usu, nom_usuario_usu "
        query &= "From tb_gma_noticia "
        query &= "inner join tb_gma_usuario on tb_gma_noticia.cod_usuario_usu = tb_gma_usuario.cod_usuario_usu "
        query &= "Order by des_titulo_pt_not "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_noticia")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarNoticia(ByVal cod_noticia_not As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_noticia_not, des_titulo_pt_not, des_titulo_en_not, des_titulo_es_not, des_descricao_pt_not, des_descricao_en_not, des_descricao_es_not, des_noticia_pt_not, des_noticia_en_not, des_noticia_es_not, dat_cadastro_not, sts_ativo_not, cod_usuario_usu "
        query &= "From tb_gma_noticia "
        query &= "Where cod_noticia_not = ?cod_noticia_not "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_noticia_not", cod_noticia_not)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_noticia")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirNoticia(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_noticia(des_titulo_pt_not, des_titulo_en_not, des_titulo_es_not, des_descricao_pt_not, des_descricao_en_not, des_descricao_es_not, des_noticia_pt_not, des_noticia_en_not, des_noticia_es_not, dat_cadastro_not, sts_ativo_not, cod_usuario_usu) "
        query &= "values(?des_titulo_pt_not, ?des_titulo_en_not, ?des_titulo_es_not, ?des_descricao_pt_not, ?des_descricao_en_not, ?des_descricao_es_not, ?des_noticia_pt_not, ?des_noticia_en_not, ?des_noticia_es_not, NOW(), ?sts_ativo_not, ?cod_usuario_usu); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?des_titulo_pt_not", dsRegistro.Tables(0).Rows(0)("des_titulo_pt_not"))
            command.Parameters.AddWithValue("?des_titulo_en_not", dsRegistro.Tables(0).Rows(0)("des_titulo_en_not"))
            command.Parameters.AddWithValue("?des_titulo_es_not", dsRegistro.Tables(0).Rows(0)("des_titulo_es_not"))
            command.Parameters.AddWithValue("?des_descricao_pt_not", dsRegistro.Tables(0).Rows(0)("des_descricao_pt_not"))
            command.Parameters.AddWithValue("?des_descricao_en_not", dsRegistro.Tables(0).Rows(0)("des_descricao_en_not"))
            command.Parameters.AddWithValue("?des_descricao_es_not", dsRegistro.Tables(0).Rows(0)("des_descricao_es_not"))
            command.Parameters.AddWithValue("?des_noticia_pt_not", dsRegistro.Tables(0).Rows(0)("des_noticia_pt_not"))
            command.Parameters.AddWithValue("?des_noticia_en_not", dsRegistro.Tables(0).Rows(0)("des_noticia_en_not"))
            command.Parameters.AddWithValue("?des_noticia_es_not", dsRegistro.Tables(0).Rows(0)("des_noticia_es_not"))
            command.Parameters.AddWithValue("?sts_ativo_not", dsRegistro.Tables(0).Rows(0)("sts_ativo_not"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))

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

    Public Sub AlterarNoticia(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_noticia Set "
        query &= "des_titulo_pt_not = ?des_titulo_pt_not, "
        query &= "des_titulo_en_not = ?des_titulo_en_not, "
        query &= "des_titulo_es_not = ?des_titulo_es_not, "
        query &= "des_descricao_pt_not = ?des_descricao_pt_not, "
        query &= "des_descricao_en_not = ?des_descricao_en_not, "
        query &= "des_descricao_es_not = ?des_descricao_es_not, "
        query &= "des_noticia_pt_not = ?des_noticia_pt_not, "
        query &= "des_noticia_en_not = ?des_noticia_en_not, "
        query &= "des_noticia_es_not = ?des_noticia_es_not, "
        query &= "dat_cadastro_not = NOW(), "
        query &= "sts_ativo_not = ?sts_ativo_not, "
        query &= "cod_usuario_usu = ?cod_usuario_usu "
        query &= "Where cod_noticia_not = ?cod_noticia_not "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?des_titulo_pt_not", dsRegistro.Tables(0).Rows(0)("des_titulo_pt_not"))
            command.Parameters.AddWithValue("?des_titulo_en_not", dsRegistro.Tables(0).Rows(0)("des_titulo_en_not"))
            command.Parameters.AddWithValue("?des_titulo_es_not", dsRegistro.Tables(0).Rows(0)("des_titulo_es_not"))
            command.Parameters.AddWithValue("?des_descricao_pt_not", dsRegistro.Tables(0).Rows(0)("des_descricao_pt_not"))
            command.Parameters.AddWithValue("?des_descricao_en_not", dsRegistro.Tables(0).Rows(0)("des_descricao_en_not"))
            command.Parameters.AddWithValue("?des_descricao_es_not", dsRegistro.Tables(0).Rows(0)("des_descricao_es_not"))
            command.Parameters.AddWithValue("?des_noticia_pt_not", dsRegistro.Tables(0).Rows(0)("des_noticia_pt_not"))
            command.Parameters.AddWithValue("?des_noticia_en_not", dsRegistro.Tables(0).Rows(0)("des_noticia_en_not"))
            command.Parameters.AddWithValue("?des_noticia_es_not", dsRegistro.Tables(0).Rows(0)("des_noticia_es_not"))
            command.Parameters.AddWithValue("?sts_ativo_not", dsRegistro.Tables(0).Rows(0)("sts_ativo_not"))
            command.Parameters.AddWithValue("?cod_usuario_usu", dsRegistro.Tables(0).Rows(0)("cod_usuario_usu"))
            command.Parameters.AddWithValue("?cod_noticia_not", dsRegistro.Tables(0).Rows(0)("cod_noticia_not"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirNoticia(ByVal cod_noticia_not As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_noticia "
        query &= "Where cod_noticia_not = ?cod_noticia_not "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_noticia_not", cod_noticia_not)

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
