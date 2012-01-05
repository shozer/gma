<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="SituacaoProjeto.aspx.vb" Inherits="admin_SituacaoProjeto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Situação do projeto</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" CssClass="botao" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" CssClass="botao" runat="server" Text="Incluir" PostBackUrl="~/admin/SituacaoProjetoCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_situacao_projeto_spr">
                <Columns>
                    <asp:BoundField DataField="nom_situacao_projeto_pt_spr" HeaderText="Situação" SortExpression="nom_situacao_projeto_pt_spr">
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_situacao_projeto_spr", "~/admin/SituacaoProjetoCad.aspx?cod_situacao_projeto_spr={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarSituacaoProjeto"
        runat="server" TypeName="GMA.DsAdmin.SituacaoProjeto"></asp:ObjectDataSource>
</asp:Content>
