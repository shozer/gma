<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="TipoProjeto.aspx.vb" Inherits="admin_TipoProjeto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Tipo de Projeto</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" CssClass="botao" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" CssClass="botao" runat="server" Text="Incluir" PostBackUrl="~/admin/TipoProjetoCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_tipo_projeto_tpr">
                <Columns>
                    <asp:BoundField DataField="nom_tipo_projeto_pt_tpr" HeaderText="Tipo de projeto"
                        SortExpression="nom_tipo_projeto_pt_tpr"></asp:BoundField>
                    <asp:BoundField DataField="qtd_projetos_vitrine_tpr" HeaderText="Qtd. na vitrine"
                        SortExpression="qtd_projetos_vitrine_tpr"></asp:BoundField>
                    <asp:BoundField DataField="sts_ativo_tpr" HeaderText="Ativo" SortExpression="sts_ativo_tpr">
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_tipo_projeto_tpr", "~/admin/TipoProjetoCad.aspx?cod_tipo_projeto_tpr={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarTipoProjeto"
        runat="server" TypeName="GMA.DsAdmin.TipoProjeto"></asp:ObjectDataSource>
</asp:Content>
