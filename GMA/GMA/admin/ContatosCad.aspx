<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="ContatosCad.aspx.vb" Inherits="admin_ContatosCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Contatos"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Nome:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_contato_con" runat="server" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o Nome!"
                Text="*" Display="Dynamic" ControlToValidate="nom_contato_con"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            E-mail:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_email_con" runat="server" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="des_email_con"
                ErrorMessage="E-mail inválido!" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </div>
        <div class="campo_titulo">
            Telefone:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_telefone_con" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Celular:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_celular_con" runat="server"></asp:TextBox>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Contatos.aspx" />
    </div>
</asp:Content>
