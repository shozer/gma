<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="FichaTecnica.aspx.vb" Inherits="admin_FichaTecnica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Ficha Técnica</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" runat="server" Text="Incluir" PostBackUrl="~/admin/FichaTecnicaCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_ficha_tecnica_fte" Width="400px">
                <Columns>
                    <asp:BoundField DataField="nom_projeto_pt_fte" HeaderText="Projeto" SortExpression="nom_projeto_pt_fte">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_ficha_tecnica_fte", "~/admin/FichaTecnicaCad.aspx?cod_ficha_tecnica_fte={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarFichaTecnica"
        runat="server" TypeName="GMA.DsAdmin.FichaTecnica"></asp:ObjectDataSource>
</asp:Content>
