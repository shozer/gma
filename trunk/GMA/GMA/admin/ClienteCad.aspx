<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="ClienteCad.aspx.vb" Inherits="admin_ClienteCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Usuário"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Nome:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_cliente_cli" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o nome!"
                Text="*" Display="Dynamic" ControlToValidate="nom_cliente_cli"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            E-mail:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_email_cli" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Preencha o e-mail!"
                Text="*" Display="Dynamic" ControlToValidate="des_email_cli"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="des_email_cli"
                    ErrorMessage="E-mail inválido!" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </div>
        <div class="campo_titulo">
            Login:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_login_cli" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o login!"
                Text="*" Display="Dynamic" ControlToValidate="des_login_cli"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Senha:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_senha_cli" runat="server" Width="400px" TextMode="Password" SkinID="Obrigatorio"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Telefone:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_telefone_cli" runat="server"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Celular:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_celular_cli" runat="server"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            CPF:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_cpf_cli" runat="server"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            CNPJ:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_cnpj_cli" runat="server"></asp:TextBox>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Cliente.aspx" />
    </div>
</asp:Content>
