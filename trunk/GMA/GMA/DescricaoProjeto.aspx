<%@ Page Language="VB" MasterPageFile="~/MasterPagePadraoInterna.master" AutoEventWireup="false"
    CodeFile="DescricaoProjeto.aspx.vb" Inherits="DescricaoProjeto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="banner_destaque">
        <div class="mask4">
            <div id="box4">
                <asp:Repeater ID="rptImagens" DataSourceID="odsImagem" runat="server">
                    <ItemTemplate>
                        <div class="container_banner_2">
                            <a href="#">
                                <img src='img/projetos/<%# DataBinder.Eval(Container.DataItem, "nom_imagem_projeto_ipr")%>'
                                    style="border: 0; width:958px; height:400px; " />
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:ObjectDataSource ID="odsImagem" TypeName="GMA.DsAdmin.ImagemProjeto" SelectMethod="ListarImagemProjetoGaleriaPorProjeto"
                    runat="server">
                    <SelectParameters>
                        <asp:QueryStringParameter QueryStringField="cod_projeto_pro" Name="cod_projeto_pro"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
        <p class="buttons_slide_int" id="handles4">
            <asp:Literal ID="litSpan" runat="server"><span></span></asp:Literal>
        </p>
    </div>
    <div class="content_interna_projetos">
        <div class="content_sidebar_left">
            <h2>
                <asp:Literal ID="litTitulo" runat="server">Casa Espa�o</asp:Literal>
            </h2>
            <h4>
                <asp:Literal ID="litLocal" runat="server">Alphaville litoral norte - Salvador BR</asp:Literal>
            </h4>
            <p>
                <asp:Literal ID="litDescricao" runat="server">
                O pensar arquitetura � resultado de um m�todo de experimenta��o onde o arquiteto
                e o cliente fazem parte de um mesmo processo para cria��o. "Arquitetura como uma
                produ��o coletiva". O pensar arquitetura � resultado de um m�todo de experimenta��o
                onde o arquiteto e o cliente fazem parte de um mesmo processo para cria��o. "Arquitetura
                como uma produ��o coletiva". O pensar arquitetura � resultado de um m�todo de experimenta��o
                onde o arquiteto e o cliente fazem parte de um mesmo processo para cria��o. "Arquitetura
                como uma produ��o coletiva". O pensar arquitetura � resultado de um m�todo de experimenta��o
                onde o arquiteto e o cliente fazem parte de um mesmo processo para cria��o. "Arquitetura
                como uma produ��o coletiva".
                </asp:Literal>
            </p>
        </div>
        <div class="content_sidebar_right">
            <h3>
                Ficha T�cnica</h3>
            <div class="content_info_sidebar_right">
                <div class="left_info_sidebar_right">
                    <h4>
                        Dados do projeto
                    </h4>
                    <span>
                        <asp:Literal ID="litCliente" runat="server"></asp:Literal>
                        <br />
                        <asp:Literal ID="litPrograma" runat="server"></asp:Literal>
                        <br />
                        <asp:Literal ID="litEstado" runat="server"></asp:Literal>
                    </span>
                </div>
                <div class="right_info_sidebar_right">
                    <h4>
                        Links relacionados
                    </h4>
                    <span>
                        <asp:Literal ID="litArtigo" runat="server"></asp:Literal>
                        <br />
                        <asp:Literal ID="litVideo" runat="server"></asp:Literal>
                        <br />
                        <asp:Literal ID="litEntrevista" runat="server"></asp:Literal>
                        <br />
                        <asp:Literal ID="litLivro" runat="server"></asp:Literal>
                    </span>
                </div>
                <div class="clear">
                </div>
            </div>
            <h3>
                Autores</h3>
            <div class="border_azul_menor">
            </div>
            <div class="content_info_sidebar_right">
                <div class="left_info_sidebar_right margin_top_0">
                    <h4>
                        GMA - Grupo Multidisciplinar para Arquitetura</h4>
                    <span>
                        <asp:Literal ID="litProfissionais" runat="server"></asp:Literal></span>
                </div>
                <div class="right_info_sidebar_right margin_top_0">
                    <h4>
                        Consultoria Especializada
                    </h4>
                    <span>
                        <asp:Literal ID="litConsultores" runat="server"></asp:Literal></span>
                </div>
                <div class="clear">
                </div>
            </div>
            <h3>
                P�gina do projeto</h3>
        </div>
    </div>
</asp:Content>
