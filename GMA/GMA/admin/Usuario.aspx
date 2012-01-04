<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="Usuario.aspx.vb" Inherits="admin_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Usuários</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" CssClass="botao" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" CssClass="botao" runat="server" Text="Incluir" PostBackUrl="~/admin/UsuarioCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_usuario_usu">
                <Columns>
                    <asp:BoundField DataField="nom_usuario_usu" HeaderText="Nome" SortExpression="nom_usuario_usu">
                    </asp:BoundField>
                    <asp:BoundField DataField="des_email_usu" HeaderText="E-mail" SortExpression="des_email_usu">
                    </asp:BoundField>
                    <asp:BoundField DataField="nom_perfil_per" HeaderText="Perfil" SortExpression="nom_perfil_per">
                    </asp:BoundField>
                    <asp:BoundField DataField="sts_ativo_usu" HeaderText="Ativo" SortExpression="sts_ativo_usu">
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_usuario_usu", "~/admin/UsuarioCad.aspx?cod_usuario_usu={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarUsuario"
        runat="server" TypeName="GMA.DsAdmin.Usuario"></asp:ObjectDataSource>
</asp:Content>
