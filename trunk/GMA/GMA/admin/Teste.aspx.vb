Imports System.Data
Imports System.Text
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports GMA.DsAdmin

Partial Class admin_Teste
    Inherits System.Web.UI.Page

    Protected Sub btnGerarPagina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGerarPagina.Click
        Dim MyXsltPath As String = Request.PhysicalApplicationPath & "\templates\Principal.xslt"
        Dim MyXmlPath As String = Request.PhysicalApplicationPath & "\templates\principal.xml"
        Dim MyHTMLPath As String = Request.PhysicalApplicationPath & "\templates\principal.aspx"

        Dim timeout As Int32 = 6000

        Dim lDataView As DataView

        Using objProjeto As New Projeto
            lDataView = objProjeto.ListarProjetoVitrine()
        End Using

        Dim textWriter As XmlTextWriter = New XmlTextWriter(MyXmlPath, Encoding.UTF8)

        textWriter.WriteStartDocument()
        textWriter.WriteStartElement("Dados")
        textWriter.WriteStartElement("projetos")

        '**** Projeto da vitrine principal
        For Each lRow As DataRow In lDataView.Table.Rows
            Dim lDV As DataView

            Using objIP As New ImagemProjeto
                lDV = objIP.ListarImagemProjetoPrincipalPorProjeto(CType(lRow("cod_projeto_pro"), Int32))
            End Using

            textWriter.WriteStartElement("projeto")

            textWriter.WriteElementString("titulo_pt", lRow("nom_projeto_pt_fte").ToString())
            textWriter.WriteElementString("titulo_es", IIf(lRow("nom_projeto_es_fte") Is DBNull.Value, lRow("nom_projeto_pt_fte"), lRow("nom_projeto_es_fte")))
            textWriter.WriteElementString("titulo_en", IIf(lRow("nom_projeto_en_fte") Is DBNull.Value, lRow("nom_projeto_pt_fte"), lRow("nom_projeto_en_fte")))

            textWriter.WriteElementString("briefing_pt", lRow("des_briefing_pt_pro").ToString())
            textWriter.WriteElementString("briefing_es", IIf(lRow("des_briefing_es_pro") Is DBNull.Value, lRow("des_briefing_pt_pro").ToString(), lRow("des_briefing_es_pro")))
            textWriter.WriteElementString("briefing_en", IIf(lRow("des_briefing_en_pro") Is DBNull.Value, lRow("des_briefing_pt_pro").ToString(), lRow("des_briefing_en_pro")))

            textWriter.WriteElementString("local", lRow("des_local_pro").ToString())
            textWriter.WriteElementString("cod_projeto_pro", lRow("cod_projeto_pro").ToString())

            '*** Loop das imagens do projeto
            For i As Int32 = 0 To lDV.Table.Rows.Count - 1
                textWriter.WriteElementString("nom_imagem_projeto_ipr" & i, lDV.Table.Rows(i)("nom_imagem_projeto_ipr").ToString())
            Next

            '*** fecha projeto
            textWriter.WriteEndElement()
        Next

        '*** fecha projetos
        textWriter.WriteEndElement()

        textWriter.WriteStartElement("noticias")

        Using objNoticia As New Noticia
            lDataView = objNoticia.ListarNoticiaAtivoPrincipal()
        End Using

        For Each lRow As DataRow In lDataView.Table.Rows
            textWriter.WriteStartElement("noticia")

            textWriter.WriteElementString("cod_noticia_not", lRow("cod_noticia_not").ToString())

            textWriter.WriteElementString("descricao_pt", lRow("des_descricao_pt_not").ToString())
            textWriter.WriteElementString("descricao_es", IIf(lRow("des_descricao_es_not") Is DBNull.Value, lRow("des_descricao_pt_not"), lRow("des_descricao_es_not")))
            textWriter.WriteElementString("descricao_en", IIf(lRow("des_descricao_en_not") Is DBNull.Value, lRow("des_descricao_pt_not"), lRow("des_descricao_en_not")))

            '*** fecha notícia
            textWriter.WriteEndElement()
        Next

        '*** fecha notícias
        textWriter.WriteEndElement()

        textWriter.WriteStartElement("parceiros")

        '***** Parceiros
        Using objParceiro As New Parceiro
            lDataView = objParceiro.ListarParceiroAtivo()
        End Using

        Dim contador As Int32 = lDataView.Table.Rows.Count

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

        textWriter.WriteElementString("timeout", timeout)

        For Each lRow As DataRow In lDataView.Table.Rows
            textWriter.WriteStartElement("parceiro")

            textWriter.WriteElementString("des_link_par", lRow("des_link_par").ToString())
            textWriter.WriteElementString("des_imagem_par", lRow("des_imagem_par").ToString())
            textWriter.WriteElementString("nom_parceiro_par", lRow("nom_parceiro_par").ToString())

            '*** fecha parceiro
            textWriter.WriteEndElement()
        Next

        '*** fecha parceiros
        textWriter.WriteEndElement()

        '*** fecha dados
        textWriter.WriteEndElement()
        textWriter.WriteEndDocument()
        textWriter.Close()

        Dim xmlDoc As XPathDocument = New XPathDocument(MyXmlPath)

        Dim XSLTransform As XslCompiledTransform = New XslCompiledTransform()
        XSLTransform.Load(MyXsltPath)
        XSLTransform.Transform(MyXmlPath, MyHTMLPath)
    End Sub
End Class
