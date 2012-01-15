Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class TipoProjeto
    Implements IDisposable

#Region " Listar "

    Public Function ListarTipoProjeto() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_tipo_projeto_tpr, cod_tipo_projeto_pai_tpr, nom_tipo_projeto_pt_tpr, nom_tipo_projeto_en_tpr, nom_tipo_projeto_es_tpr, qtd_projetos_vitrine_tpr, sts_ativo_tpr "
        query &= "From tb_gma_tipo_projeto "
        query &= "Order by nom_tipo_projeto_pt_tpr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_tipo_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarTipoProjeto(ByVal cod_tipo_projeto_tpr As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_tipo_projeto_tpr, cod_tipo_projeto_pai_tpr, nom_tipo_projeto_pt_tpr, nom_tipo_projeto_en_tpr, nom_tipo_projeto_es_tpr, qtd_projetos_vitrine_tpr, sts_ativo_tpr "
        query &= "From tb_gma_tipo_projeto "
        query &= "Where cod_tipo_projeto_tpr = ?cod_tipo_projeto_tpr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_tipo_projeto_tpr", cod_tipo_projeto_tpr)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_tipo_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirTipoProjeto(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_tipo_projeto(cod_tipo_projeto_pai_tpr, nom_tipo_projeto_pt_tpr, nom_tipo_projeto_en_tpr, nom_tipo_projeto_es_tpr, qtd_projetos_vitrine_tpr, sts_ativo_tpr) "
        query &= "values(?cod_tipo_projeto_pai_tpr, ?nom_tipo_projeto_pt_tpr, ?nom_tipo_projeto_en_tpr, ?nom_tipo_projeto_es_tpr, ?qtd_projetos_vitrine_tpr, ?sts_ativo_tpr); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_tipo_projeto_pai_tpr", dsRegistro.Tables(0).Rows(0)("cod_tipo_projeto_pai_tpr"))
            command.Parameters.AddWithValue("?nom_tipo_projeto_pt_tpr", dsRegistro.Tables(0).Rows(0)("nom_tipo_projeto_pt_tpr"))
            command.Parameters.AddWithValue("?nom_tipo_projeto_en_tpr", dsRegistro.Tables(0).Rows(0)("nom_tipo_projeto_en_tpr"))
            command.Parameters.AddWithValue("?nom_tipo_projeto_es_tpr", dsRegistro.Tables(0).Rows(0)("nom_tipo_projeto_es_tpr"))
            command.Parameters.AddWithValue("?qtd_projetos_vitrine_tpr", dsRegistro.Tables(0).Rows(0)("qtd_projetos_vitrine_tpr"))
            command.Parameters.AddWithValue("?sts_ativo_tpr", dsRegistro.Tables(0).Rows(0)("sts_ativo_tpr"))

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

    Public Sub AlterarTipoProjeto(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_tipo_projeto Set "
        query &= "cod_tipo_projeto_pai_tpr = ?cod_tipo_projeto_pai_tpr, "
        query &= "nom_tipo_projeto_pt_tpr = ?nom_tipo_projeto_pt_tpr, "
        query &= "nom_tipo_projeto_en_tpr = ?nom_tipo_projeto_en_tpr, "
        query &= "nom_tipo_projeto_es_tpr = ?nom_tipo_projeto_es_tpr, "
        query &= "qtd_projetos_vitrine_tpr = ?qtd_projetos_vitrine_tpr, "
        query &= "sts_ativo_tpr = ?sts_ativo_tpr "
        query &= "Where cod_tipo_projeto_tpr = ?cod_tipo_projeto_tpr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_tipo_projeto_pai_tpr", dsRegistro.Tables(0).Rows(0)("cod_tipo_projeto_pai_tpr"))
            command.Parameters.AddWithValue("?nom_tipo_projeto_pt_tpr", dsRegistro.Tables(0).Rows(0)("nom_tipo_projeto_pt_tpr"))
            command.Parameters.AddWithValue("?nom_tipo_projeto_en_tpr", dsRegistro.Tables(0).Rows(0)("nom_tipo_projeto_en_tpr"))
            command.Parameters.AddWithValue("?nom_tipo_projeto_es_tpr", dsRegistro.Tables(0).Rows(0)("nom_tipo_projeto_es_tpr"))
            command.Parameters.AddWithValue("?qtd_projetos_vitrine_tpr", dsRegistro.Tables(0).Rows(0)("qtd_projetos_vitrine_tpr"))
            command.Parameters.AddWithValue("?sts_ativo_tpr", dsRegistro.Tables(0).Rows(0)("sts_ativo_tpr"))
            command.Parameters.AddWithValue("?cod_tipo_projeto_tpr", dsRegistro.Tables(0).Rows(0)("cod_tipo_projeto_tpr"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirTipoProjeto(ByVal cod_tipo_projeto_tpr As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_tipo_projeto "
        query &= "Where cod_tipo_projeto_tpr = ?cod_tipo_projeto_tpr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_tipo_projeto_tpr", cod_tipo_projeto_tpr)

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
