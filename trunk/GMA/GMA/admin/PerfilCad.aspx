<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="PerfilCad.aspx.vb" Inherits="admin_PerfilCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Perfis"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Perfil:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_perfil_per" runat="server" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o Perfil!"
                Text="*" Display="Dynamic" ControlToValidate="nom_perfil_per"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_per" Checked="true" runat="server" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Perfil.aspx" />
    </div>
</asp:Content>
