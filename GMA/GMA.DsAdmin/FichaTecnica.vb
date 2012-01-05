Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class FichaTecnica
    Implements IDisposable

#Region " Listar "

    Public Function ListarFichaTecnica() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_ficha_tecnica_fte, nom_projeto_pt_fte, nom_projeto_en_fte, nom_projeto_es_fte, des_projeto_pt_fte, des_projeto_en_fte, des_projeto_es_fte, des_programa_pt_fte, des_programa_en_fte, des_programa_es_fte, des_artigo_pt_fte, des_artigo_en_fte, des_artigo_es_fte, des_video_pt_fte, des_video_en_fte, des_video_es_fte, des_entrevista_pt_fte, des_entrevista_en_fte, des_entrevista_es_fte, des_livro_pt_fte, des_livro_en_fte, des_livro_es_fte "
        query &= "From tb_gma_ficha_tecnica "
        query &= "Order by nom_projeto_pt_fte "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_ficha_tecnica")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarFichaTecnica(ByVal cod_ficha_tecnica_fte As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_ficha_tecnica_fte, nom_projeto_pt_fte, nom_projeto_en_fte, nom_projeto_es_fte, des_projeto_pt_fte, des_projeto_en_fte, des_projeto_es_fte, des_programa_pt_fte, des_programa_en_fte, des_programa_es_fte, des_artigo_pt_fte, des_artigo_en_fte, des_artigo_es_fte, des_video_pt_fte, des_video_en_fte, des_video_es_fte, des_entrevista_pt_fte, des_entrevista_en_fte, des_entrevista_es_fte, des_livro_pt_fte, des_livro_en_fte, des_livro_es_fte "
        query &= "From tb_gma_ficha_tecnica "
        query &= "Where cod_ficha_tecnica_fte = @cod_ficha_tecnica_fte "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@cod_ficha_tecnica_fte", cod_ficha_tecnica_fte)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_ficha_tecnica")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirFichaTecnica(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_ficha_tecnica(nom_projeto_pt_fte, nom_projeto_en_fte, nom_projeto_es_fte, des_projeto_pt_fte, des_projeto_en_fte, des_projeto_es_fte, des_programa_pt_fte, des_programa_en_fte, des_programa_es_fte, des_artigo_pt_fte, des_artigo_en_fte, des_artigo_es_fte, des_video_pt_fte, des_video_en_fte, des_video_es_fte, des_entrevista_pt_fte, des_entrevista_en_fte, des_entrevista_es_fte, des_livro_pt_fte, des_livro_en_fte, des_livro_es_fte) "
        query &= "values(?nom_projeto_pt_fte, ?nom_projeto_en_fte, ?nom_projeto_es_fte, ?des_projeto_pt_fte, ?des_projeto_en_fte, ?des_projeto_es_fte, ?des_programa_pt_fte, ?des_programa_en_fte, ?des_programa_es_fte, ?des_artigo_pt_fte, ?des_artigo_en_fte, ?des_artigo_es_fte, ?des_video_pt_fte, ?des_video_en_fte, ?des_video_es_fte, ?des_entrevista_pt_fte, ?des_entrevista_en_fte, ?des_entrevista_es_fte, ?des_livro_pt_fte, ?des_livro_en_fte, ?des_livro_es_fte); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_projeto_pt_fte", dsRegistro.Tables(0).Rows(0)("nom_projeto_pt_fte"))
            command.Parameters.AddWithValue("?nom_projeto_en_fte", dsRegistro.Tables(0).Rows(0)("nom_projeto_en_fte"))
            command.Parameters.AddWithValue("?nom_projeto_es_fte", dsRegistro.Tables(0).Rows(0)("nom_projeto_es_fte"))
            command.Parameters.AddWithValue("?des_projeto_pt_fte", dsRegistro.Tables(0).Rows(0)("des_projeto_pt_fte"))
            command.Parameters.AddWithValue("?des_projeto_en_fte", dsRegistro.Tables(0).Rows(0)("des_projeto_en_fte"))
            command.Parameters.AddWithValue("?des_projeto_es_fte", dsRegistro.Tables(0).Rows(0)("des_projeto_es_fte"))
            command.Parameters.AddWithValue("?des_programa_pt_fte", dsRegistro.Tables(0).Rows(0)("des_programa_pt_fte"))
            command.Parameters.AddWithValue("?des_programa_en_fte", dsRegistro.Tables(0).Rows(0)("des_programa_en_fte"))
            command.Parameters.AddWithValue("?des_programa_es_fte", dsRegistro.Tables(0).Rows(0)("des_programa_es_fte"))
            command.Parameters.AddWithValue("?des_artigo_pt_fte", dsRegistro.Tables(0).Rows(0)("des_artigo_pt_fte"))
            command.Parameters.AddWithValue("?des_artigo_en_fte", dsRegistro.Tables(0).Rows(0)("des_artigo_en_fte"))
            command.Parameters.AddWithValue("?des_artigo_es_fte", dsRegistro.Tables(0).Rows(0)("des_artigo_es_fte"))
            command.Parameters.AddWithValue("?des_video_pt_fte", dsRegistro.Tables(0).Rows(0)("des_video_pt_fte"))
            command.Parameters.AddWithValue("?des_video_en_fte", dsRegistro.Tables(0).Rows(0)("des_video_en_fte"))
            command.Parameters.AddWithValue("?des_video_es_fte", dsRegistro.Tables(0).Rows(0)("des_video_es_fte"))
            command.Parameters.AddWithValue("?des_entrevista_pt_fte", dsRegistro.Tables(0).Rows(0)("des_entrevista_pt_fte"))
            command.Parameters.AddWithValue("?des_entrevista_en_fte", dsRegistro.Tables(0).Rows(0)("des_entrevista_en_fte"))
            command.Parameters.AddWithValue("?des_entrevista_es_fte", dsRegistro.Tables(0).Rows(0)("des_entrevista_es_fte"))
            command.Parameters.AddWithValue("?des_livro_pt_fte", dsRegistro.Tables(0).Rows(0)("des_livro_pt_fte"))
            command.Parameters.AddWithValue("?des_livro_en_fte", dsRegistro.Tables(0).Rows(0)("des_livro_en_fte"))
            command.Parameters.AddWithValue("?des_livro_es_fte", dsRegistro.Tables(0).Rows(0)("des_livro_es_fte"))

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

    Public Sub AlterarFichaTecnica(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_ficha_tecnica Set "
        query &= "nom_projeto_pt_fte = ?nom_projeto_pt_fte, "
        query &= "nom_projeto_en_fte = ?nom_projeto_en_fte, "
        query &= "nom_projeto_es_fte = ?nom_projeto_es_fte, "
        query &= "des_projeto_pt_fte = ?des_projeto_pt_fte, "
        query &= "des_projeto_en_fte = ?des_projeto_en_fte, "
        query &= "des_projeto_es_fte = ?des_projeto_es_fte, "
        query &= "des_programa_pt_fte = ?des_programa_pt_fte, "
        query &= "des_programa_en_fte = ?des_programa_en_fte, "
        query &= "des_programa_es_fte = ?des_programa_es_fte, "
        query &= "des_artigo_pt_fte = ?des_artigo_pt_fte, "
        query &= "des_artigo_en_fte = ?des_artigo_en_fte, "
        query &= "des_artigo_es_fte = ?des_artigo_es_fte, "
        query &= "des_video_pt_fte = ?des_video_pt_fte, "
        query &= "des_video_en_fte = ?des_video_en_fte, "
        query &= "des_video_es_fte = ?des_video_es_fte, "
        query &= "des_entrevista_pt_fte = ?des_entrevista_pt_fte, "
        query &= "des_entrevista_en_fte = ?des_entrevista_en_fte, "
        query &= "des_entrevista_es_fte = ?des_entrevista_es_fte, "
        query &= "des_livro_pt_fte = ?des_livro_pt_fte, "
        query &= "des_livro_en_fte = ?des_livro_en_fte, "
        query &= "des_livro_es_fte = ?des_livro_es_fte "
        query &= "Where cod_ficha_tecnica_fte = ?cod_ficha_tecnica_fte "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_projeto_pt_fte", dsRegistro.Tables(0).Rows(0)("nom_projeto_pt_fte"))
            command.Parameters.AddWithValue("?nom_projeto_en_fte", dsRegistro.Tables(0).Rows(0)("nom_projeto_en_fte"))
            command.Parameters.AddWithValue("?nom_projeto_es_fte", dsRegistro.Tables(0).Rows(0)("nom_projeto_es_fte"))
            command.Parameters.AddWithValue("?des_projeto_pt_fte", dsRegistro.Tables(0).Rows(0)("des_projeto_pt_fte"))
            command.Parameters.AddWithValue("?des_projeto_en_fte", dsRegistro.Tables(0).Rows(0)("des_projeto_en_fte"))
            command.Parameters.AddWithValue("?des_projeto_es_fte", dsRegistro.Tables(0).Rows(0)("des_projeto_es_fte"))
            command.Parameters.AddWithValue("?des_programa_pt_fte", dsRegistro.Tables(0).Rows(0)("des_programa_pt_fte"))
            command.Parameters.AddWithValue("?des_programa_en_fte", dsRegistro.Tables(0).Rows(0)("des_programa_en_fte"))
            command.Parameters.AddWithValue("?des_programa_es_fte", dsRegistro.Tables(0).Rows(0)("des_programa_es_fte"))
            command.Parameters.AddWithValue("?des_artigo_pt_fte", dsRegistro.Tables(0).Rows(0)("des_artigo_pt_fte"))
            command.Parameters.AddWithValue("?des_artigo_en_fte", dsRegistro.Tables(0).Rows(0)("des_artigo_en_fte"))
            command.Parameters.AddWithValue("?des_artigo_es_fte", dsRegistro.Tables(0).Rows(0)("des_artigo_es_fte"))
            command.Parameters.AddWithValue("?des_video_pt_fte", dsRegistro.Tables(0).Rows(0)("des_video_pt_fte"))
            command.Parameters.AddWithValue("?des_video_en_fte", dsRegistro.Tables(0).Rows(0)("des_video_en_fte"))
            command.Parameters.AddWithValue("?des_video_es_fte", dsRegistro.Tables(0).Rows(0)("des_video_es_fte"))
            command.Parameters.AddWithValue("?des_entrevista_pt_fte", dsRegistro.Tables(0).Rows(0)("des_entrevista_pt_fte"))
            command.Parameters.AddWithValue("?des_entrevista_en_fte", dsRegistro.Tables(0).Rows(0)("des_entrevista_en_fte"))
            command.Parameters.AddWithValue("?des_entrevista_es_fte", dsRegistro.Tables(0).Rows(0)("des_entrevista_es_fte"))
            command.Parameters.AddWithValue("?des_livro_pt_fte", dsRegistro.Tables(0).Rows(0)("des_livro_pt_fte"))
            command.Parameters.AddWithValue("?des_livro_en_fte", dsRegistro.Tables(0).Rows(0)("des_livro_en_fte"))
            command.Parameters.AddWithValue("?des_livro_es_fte", dsRegistro.Tables(0).Rows(0)("des_livro_es_fte"))
            command.Parameters.AddWithValue("?cod_ficha_tecnica_fte", dsRegistro.Tables(0).Rows(0)("cod_ficha_tecnica_fte"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirFichaTecnica(ByVal cod_ficha_tecnica_fte As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_ficha_tecnica "
        query &= "Where cod_ficha_tecnica_fte = ?cod_ficha_tecnica_fte "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_ficha_tecnica_fte", cod_ficha_tecnica_fte)

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
