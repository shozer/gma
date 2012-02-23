Imports GMA.DsAdmin
Imports System.Data

Partial Class MasterPagePadraoInterna
    Inherits System.Web.UI.MasterPage

#Region " Load "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim timeout As Int32 = 6000

            If Session("idioma") Is Nothing Then
                Session("idioma") = 1
            Else
                Session("idioma") = Session("idioma")
            End If

            '***** Parceiros
            Dim lDataView As DataView

            Using objParceiro As New Parceiro
                lDataView = objParceiro.ListarParceiroAtivo()
            End Using

            Dim contador As Int32 = lDataView.Table.Rows.Count
            Dim count As Int32 = 0

            While contador
                If timeout > 1000 Then
                    timeout -= 1000
                Else
                    If timeout > 500 Then
                        timeout -= 100
                    End If
                End If

                contador -= 1
            End While

            Session("timeout") = timeout
            parceiro.InnerHtml = ""

            For Each lRow As DataRow In lDataView.Table.Rows
                count += 1

                If count = 1 Then
                    parceiro.InnerHtml &= "<ul>" & vbCrLf
                End If

                '*** Cadastro das notícias
                parceiro.InnerHtml &= "<li>" & vbCrLf

                If Not lRow("des_link_par") Is DBNull.Value Then
                    parceiro.InnerHtml &= "<a href='" & lRow("des_link_par") & "' target='_blank'>"
                    parceiro.InnerHtml &= "    <img src='img/parceiros/" & lRow("des_imagem_par") & "' style='border: 0;' width='139px' heigth='134px' alt='" & lRow("nom_parceiro_par") & "' title='" & lRow("nom_parceiro_par") & "' />"
                    parceiro.InnerHtml &= "</a>"
                Else
                    parceiro.InnerHtml &= "    <img src='img/parceiros/" & lRow("des_imagem_par") & "' style='border: 0;' width='139px' heigth='134px' alt='" & lRow("nom_parceiro_par") & "' title='" & lRow("nom_parceiro_par") & "' />"
                End If

                parceiro.InnerHtml &= "</li>" & vbCrLf

                If count = lDataView.Table.Rows.Count Then
                    parceiro.InnerHtml &= "</ul>" & vbCrLf
                End If
            Next
        End If
    End Sub

#End Region

End Class

