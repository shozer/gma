<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="RestricaoCad.aspx.vb" Inherits="admin_RestricaoCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Restrição"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Arquivo:
        </div>
        <div class="campo">
            <asp:DropDownList ID="cod_arquivo_arq" DataValueField="cod_arquivo_arq" DataTextField="nom_arquivo_arq"
                DataSourceID="odsArquivo" EnableViewState="false" runat="server">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odsArquivo" EnableViewState="false" TypeName="GMA.DsAdmin.Restricao"
                runat="server" SelectMethod="ListarArquivo"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Clientes:
        </div>
        <div class="campo">
            <asp:CheckBoxList ID="cod_cliente_cli" DataValueField="cod_cliente_cli" DataTextField="nom_cliente_cli"
                DataSourceID="odsCliente" EnableViewState="false" runat="server" RepeatColumns="4">
            </asp:CheckBoxList>
            <asp:ObjectDataSource ID="odsCliente" EnableViewState="false" TypeName="GMA.DsAdmin.Cliente"
                runat="server" SelectMethod="ListarCliente"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Perfis:
        </div>
        <div class="campo">
            <asp:CheckBoxList ID="cod_perfil_per" DataValueField="cod_perfil_per" DataTextField="nom_perfil_per"
                DataSourceID="odsPerfil" EnableViewState="false" runat="server" RepeatColumns="4">
            </asp:CheckBoxList>
            <asp:ObjectDataSource ID="odsPerfil" EnableViewState="false" TypeName="GMA.DsAdmin.Perfil"
                runat="server" SelectMethod="ListarPerfil"></asp:ObjectDataSource>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Restricao.aspx" />
    </div>
</asp:Content>
