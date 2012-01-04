<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="ProfissionalCad.aspx.vb" Inherits="admin_ProfissionalCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Profissional"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Profissional:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_profissional_prf" runat="server" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o Profissional!"
                Text="*" Display="Dynamic" ControlToValidate="nom_profissional_prf"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            E-mail:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_email_prf" runat="server" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="des_email_prf"
                ErrorMessage="E-mail inválido!" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </div>
        <div class="campo_titulo">
            Telefone:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_telefone_prf" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Celular:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_celular_prf" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_prf" Checked="true" runat="server" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Profissional.aspx" />
    </div>
</asp:Content>
