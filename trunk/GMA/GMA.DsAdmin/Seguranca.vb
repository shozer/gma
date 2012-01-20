Imports System.Web.Security
Imports System.Data

Public Class Seguranca
    Implements IDisposable

#Region " Criptografar "

    Public Function Criptografar(ByVal senha As String) As String
        Dim Retorno As String = ""

        If senha <> "" Then
            Retorno = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "sha1")
        End If

        Return Retorno
    End Function

#End Region

#Region " Dispose "

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        GC.SuppressFinalize(Me)
    End Sub

#End Region

End Class
