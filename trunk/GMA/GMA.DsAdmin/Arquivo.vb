Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Web.HttpContext

Public Class Arquivo
    Implements IDisposable

#Region " Listar "

    Public Function ListarArquivo() As DataView
        Dim objArquivo As MySqlConnection = Nothing
        Dim lDSRetorno As New DataSet

        Dim query As String = "Select cod_arquivo_arq, nom_arquivo_arq, des_arquivo_pt_arq, des_arquivo_en_arq, des_arquivo_es_arq, dat_cadastro_arq, sts_ativo_arq "
        query &= "From tb_gma_arquivo "
        query &= "Order by nom_arquivo_arq "

        Try
            objArquivo = New MySqlConnection(Current.Session("cn"))
            objArquivo.Open()

            Dim command As MySqlCommand = New MySqlCommand(query, objArquivo)
            Dim DA As MySqlDataAdapter = New MySqlDataAdapter(command)
            DA.Fill(lDSRetorno, "tb_gma_arquivo")
        Catch ex As Exception
            'Registrar no log
        Finally
            objArquivo.Close()
        End Try

        Return lDSRetorno.Tables(0).DefaultView
    End Function

#End Region

#Region " Dispose "

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class
