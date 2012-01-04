<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="Profissional.aspx.vb" Inherits="admin_Profissional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Profissionais</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" CssClass="botao" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" CssClass="botao" runat="server" Text="Incluir" PostBackUrl="~/admin/ProfissionalCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_profissional_prf">
                <Columns>
                    <asp:BoundField DataField="nom_profissional_prf" HeaderText="Profissional"
                        SortExpression="nom_profissional_prf"></asp:BoundField>
                    <asp:BoundField DataField="des_email_prf" HeaderText="E-mail" SortExpression="des_email_prf">
                    </asp:BoundField>
                    <asp:BoundField DataField="sts_ativo_prf" HeaderText="Ativo" SortExpression="sts_ativo_prf">
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_profissional_prf", "~/admin/ProfissionalCad.aspx?cod_profissional_prf={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarProfissional"
        runat="server" TypeName="GMA.DsAdmin.Profissional"></asp:ObjectDataSource>
</asp:Content>
