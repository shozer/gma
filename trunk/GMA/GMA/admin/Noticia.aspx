<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="Noticia.aspx.vb" Inherits="admin_Noticia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Notícias</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" CssClass="botao" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" CssClass="botao" runat="server" Text="Incluir" PostBackUrl="~/admin/NoticiaCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_noticia_not">
                <Columns>
                    <asp:BoundField DataField="des_titulo_pt_not" HeaderText="Título" SortExpression="des_titulo_pt_not">
                    </asp:BoundField>
                    <asp:BoundField DataField="nom_usuario_usu" HeaderText="Quem criou" SortExpression="nom_usuario_usu">
                    </asp:BoundField>
                    <asp:BoundField DataField="dat_cadastro_not" HeaderText="Data da criação" SortExpression="dat_cadastro_not"
                        DataFormatString="{0:dd/MM/yyyy HH:mm}"></asp:BoundField>
                    <asp:BoundField DataField="sts_ativo_not" HeaderText="Ativo" SortExpression="sts_ativo_not">
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_noticia_not", "~/admin/NoticiaCad.aspx?cod_noticia_not={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarNoticia"
        runat="server" TypeName="GMA.DsAdmin.Noticia"></asp:ObjectDataSource>
</asp:Content>
