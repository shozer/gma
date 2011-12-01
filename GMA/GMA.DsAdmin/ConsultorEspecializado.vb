Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class ConsultorEspecializado
    Implements IDisposable

#Region " Listar "

    Public Function ListarConsultorEspecializado() As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_consultor_especializado_ces, nom_consultor_ces, des_email_ces, num_telefone_ces, sts_ativo_ces "
        query &= "From tb_gma_consultor_especializado "
        query &= "Order by nom_consultor_ces "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_consultor_especializado")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Consultar "

    Public Function ConsultarConsultorEspecializado(ByVal cod_consultor_especializado_ces As Int32) As DataView
        Dim conn As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_consultor_especializado_ces, nom_consultor_ces, des_email_ces, num_telefone_ces, sts_ativo_ces "
        query &= "From tb_gma_consultor_especializado "
        query &= "Where cod_consultor_especializado_ces = @cod_consultor_especializado_ces "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@cod_consultor_especializado_ces", cod_consultor_especializado_ces)

            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_consultor_especializado")
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Incluir "

    Public Function IncluirConsultorEspecializado(ByVal dsRegistro As DataSet) As Int32
        Dim conn As MySqlConnection = Nothing
        Dim primaryKey As Int32 = -1

        Dim query As String = "Insert into tb_gma_consultor_especializado(nom_consultor_ces, des_email_ces, num_telefone_ces, sts_ativo_ces) "
        query &= "values(?nom_consultor_ces, ?des_email_ces, ?num_telefone_ces, ?sts_ativo_ces); SELECT LAST_INSERT_ID();"

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_consultor_ces", dsRegistro.Tables(0).Rows(0)("nom_consultor_ces"))
            command.Parameters.AddWithValue("?des_email_ces", dsRegistro.Tables(0).Rows(0)("des_email_ces"))
            command.Parameters.AddWithValue("?num_telefone_ces", dsRegistro.Tables(0).Rows(0)("num_telefone_ces"))
            command.Parameters.AddWithValue("?sts_ativo_ces", dsRegistro.Tables(0).Rows(0)("sts_ativo_ces"))

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

    Public Sub AlterarConsultorEspecializado(ByVal dsRegistro As DataSet)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Update tb_gma_consultor_especializado Set "
        query &= "nom_consultor_ces = ?nom_consultor_ces, "
        query &= "des_email_ces = ?des_email_ces, "
        query &= "num_telefone_ces = ?num_telefone_ces, "
        query &= "sts_ativo_ces = ?sts_ativo_ces "
        query &= "Where cod_consultor_especializado_ces = ?cod_consultor_especializado_ces "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?nom_consultor_ces", dsRegistro.Tables(0).Rows(0)("nom_consultor_ces"))
            command.Parameters.AddWithValue("?des_email_ces", dsRegistro.Tables(0).Rows(0)("des_email_ces"))
            command.Parameters.AddWithValue("?num_telefone_ces", dsRegistro.Tables(0).Rows(0)("num_telefone_ces"))
            command.Parameters.AddWithValue("?sts_ativo_ces", dsRegistro.Tables(0).Rows(0)("sts_ativo_ces"))
            command.Parameters.AddWithValue("?cod_consultor_especializado_ces", dsRegistro.Tables(0).Rows(0)("cod_consultor_especializado_ces"))

            command.ExecuteNonQuery()
        Catch ex As Exception
            'Registrar no log
        Finally
            conn.Close()
        End Try
    End Sub

#End Region

#Region " Excluir "

    Public Sub ExcluirConsultorEspecializado(ByVal cod_consultor_especializado_ces As Int32)
        Dim conn As MySqlConnection = Nothing

        Dim query As String = "Delete from tb_gma_consultor_especializado "
        query &= "Where cod_consultor_especializado_ces = ?cod_consultor_especializado_ces "

        Try
            conn = New MySqlConnection(ConnectionStrings.Item("StringConexao").ConnectionString)
            conn.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("?cod_consultor_especializado_ces", cod_consultor_especializado_ces)

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
