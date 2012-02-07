<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="Perfil.aspx.vb" Inherits="admin_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Perfis</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" runat="server" Text="Incluir" PostBackUrl="~/admin/PerfilCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_perfil_per" Width="300px">
                <Columns>
                    <asp:BoundField DataField="nom_perfil_per" HeaderText="Nome" SortExpression="nom_perfil_per">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sts_ativo_per" HeaderText="Ativo" SortExpression="sts_ativo_per">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_perfil_per", "~/admin/PerfilCad.aspx?cod_perfil_per={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarPerfil"
        runat="server" TypeName="GMA.DsAdmin.Perfil"></asp:ObjectDataSource>
</asp:Content>
