<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="ConsultorEspecializadoCad.aspx.vb" Inherits="admin_ConsultorEspecializadoCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Consultor Especializado"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Consultor:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_consultor_ces" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o Consultor!"
                Text="*" Display="Dynamic" ControlToValidate="nom_consultor_ces"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            E-mail:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_email_ces" runat="server" Width="400px"></asp:TextBox><asp:RegularExpressionValidator
                ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="des_email_ces"
                ErrorMessage="E-mail inválido!" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </div>
        <div class="campo_titulo">
            Telefone:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_telefone_ces" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_ces" Checked="true" runat="server" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/ConsultorEspecializado.aspx" />
    </div>
</asp:Content>
