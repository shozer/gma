<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="Cliente.aspx.vb" Inherits="admin_Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Clientes</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" runat="server" Text="Incluir" PostBackUrl="~/admin/ClienteCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_cliente_cli" Width="500px">
                <Columns>
                    <asp:BoundField DataField="nom_cliente_cli" HeaderText="Cliente" SortExpression="nom_cliente_cli">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="des_email_cli" HeaderText="E-mail" SortExpression="des_email_cli">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="des_login_cli" HeaderText="Login" SortExpression="des_login_cli">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_cliente_cli", "~/admin/ClienteCad.aspx?cod_cliente_cli={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarCliente"
        runat="server" TypeName="GMA.DsAdmin.Cliente"></asp:ObjectDataSource>
</asp:Content>
