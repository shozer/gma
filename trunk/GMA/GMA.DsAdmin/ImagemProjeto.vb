Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class ImagemProjeto
    Implements IDisposable

#Region " Listar "

    Public Function ListarImagemProjeto() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_imagem_projeto_ipr, nom_imagem_projeto_ipr, cod_projeto_pro, num_ordem_ipr "
        query &= "From tb_gma_imagem_projeto "
        query &= "Order by nom_imagem_projeto_ipr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_imagem_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

    Public Function ListarImagemProjetoGaleriaPorProjeto(ByVal cod_projeto_pro As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_imagem_projeto_ipr, nom_imagem_projeto_ipr, cod_projeto_pro, num_ordem_ipr "
        query &= "From tb_gma_imagem_projeto "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "
        query &= "Order by num_ordem_ipr LIMIT 6 "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_imagem_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

    Public Function ListarImagemProjetoPorProjeto(ByVal cod_projeto_pro As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_imagem_projeto_ipr, nom_imagem_projeto_ipr, cod_projeto_pro, num_ordem_ipr "
        query &= "From tb_gma_imagem_projeto "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "
        query &= "Order by num_ordem_ipr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_imagem_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

    Public Function ListarImagemProjetoPrincipalPorProjeto(ByVal cod_projeto_pro As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_imagem_projeto_ipr, nom_imagem_projeto_ipr, cod_projeto_pro, num_ordem_ipr "
        query &= "From tb_gma_imagem_projeto "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "
        query &= "Order by num_ordem_ipr LIMIT 3 "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_imagem_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarImagemProjeto(ByVal cod_imagem_projeto_ipr As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_imagem_projeto_ipr, nom_imagem_projeto_ipr, cod_projeto_pro, num_ordem_ipr "
        query &= "From tb_gma_imagem_projeto "
        query &= "Where cod_imagem_projeto_ipr = ?cod_imagem_projeto_ipr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_imagem_projeto_ipr", cod_imagem_projeto_ipr)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_imagem_projeto")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirImagemProjeto(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_imagem_projeto(nom_imagem_projeto_ipr, cod_projeto_pro, num_ordem_ipr) "
        query &= "values(?nom_imagem_projeto_ipr, ?cod_projeto_pro, ?num_ordem_ipr); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_imagem_projeto_ipr", dsRegistro.Tables(0).Rows(0)("nom_imagem_projeto_ipr"))
            command.Parameters.AddWithValue("?cod_projeto_pro", dsRegistro.Tables(0).Rows(0)("cod_projeto_pro"))
            command.Parameters.AddWithValue("?num_ordem_ipr", dsRegistro.Tables(0).Rows(0)("num_ordem_ipr"))

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

    Public Sub AlterarImagemProjeto(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_imagem_projeto Set "
        query &= "nom_imagem_projeto_ipr = ?nom_imagem_projeto_ipr, "
        query &= "cod_projeto_pro = ?cod_projeto_pro, "
        query &= "num_ordem_ipr = ?num_ordem_ipr "
        query &= "Where cod_imagem_projeto_ipr = ?cod_imagem_projeto_ipr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_imagem_projeto_ipr", dsRegistro.Tables(0).Rows(0)("nom_imagem_projeto_ipr"))
            command.Parameters.AddWithValue("?cod_projeto_pro", dsRegistro.Tables(0).Rows(0)("cod_projeto_pro"))
            command.Parameters.AddWithValue("?num_ordem_ipr", dsRegistro.Tables(0).Rows(0)("num_ordem_ipr"))
            command.Parameters.AddWithValue("?cod_imagem_projeto_ipr", dsRegistro.Tables(0).Rows(0)("cod_imagem_projeto_ipr"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirImagemProjeto(ByVal cod_imagem_projeto_ipr As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_imagem_projeto "
        query &= "Where cod_imagem_projeto_ipr = ?cod_imagem_projeto_ipr "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_imagem_projeto_ipr", cod_imagem_projeto_ipr)

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub ExcluirImagemProjetoPorProjeto(ByVal cod_projeto_pro As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_imagem_projeto "
        query &= "Where cod_projeto_pro = ?cod_projeto_pro "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_projeto_pro", cod_projeto_pro)

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
