﻿<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="Contatos.aspx.vb" Inherits="admin_Contatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Contatos</h1>
    <div class="filtros">
        <asp:Button ID="btnConsultar" CssClass="botao" runat="server" Text="Consultar" />
        <asp:Button ID="btnIncluir" CssClass="botao" runat="server" Text="Incluir" PostBackUrl="~/admin/ContatosCad.aspx" />
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_contato_con">
                <Columns>
                    <asp:BoundField DataField="nom_contato_con" HeaderText="Nome"
                        SortExpression="nom_contato_con"></asp:BoundField>
                    <asp:BoundField DataField="des_email_con" HeaderText="E-mail"
                        SortExpression="des_email_con"></asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnAlterar" runat="server" ImageUrl="~/img/alterar.png" Width="32px"
                                Height="32px" ToolTip="Alterar" PostBackUrl='<%# Eval("cod_contato_con", "~/admin/ContatosCad.aspx?cod_contato_con={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarContatos"
        runat="server" TypeName="GMA.DsAdmin.Contatos"></asp:ObjectDataSource>
</asp:Content>