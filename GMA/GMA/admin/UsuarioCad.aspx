<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="UsuarioCad.aspx.vb" Inherits="admin_UsuarioCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Usuário"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Nome:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_usuario_usu" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o nome!"
                Text="*" Display="Dynamic" ControlToValidate="nom_usuario_usu"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            E-mail:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_email_usu" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Preencha o e-mail!"
                Text="*" Display="Dynamic" ControlToValidate="des_email_usu"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ControlToValidate="des_email_usu"
                    ErrorMessage="E-mail inválido!" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        </div>
        <div class="campo_titulo">
            Login:
        </div>
        <div class="campo">
            <asp:TextBox ID="cod_usuario_usu" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o login!"
                Text="*" Display="Dynamic" ControlToValidate="cod_usuario_usu"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Senha:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_senha_usu" runat="server" Width="400px" TextMode="Password" SkinID="Obrigatorio"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Telefone:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_telefone_usu" runat="server"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Celular:
        </div>
        <div class="campo">
            <asp:TextBox ID="num_celular_usu" runat="server"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Perfil:
        </div>
        <div class="campo">
            <asp:DropDownList ID="cod_perfil_per" AppendDataBoundItems="true" DataTextField="nom_perfil_per"
                DataValueField="cod_perfil_per" runat="server" DataSourceID="odsPerfil" EnableViewState="false">
                <asp:ListItem Value="-1">Selecione</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Selecione um perfil!"
                InitialValue="-1" ControlToValidate="cod_perfil_per" Text="*" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="odsPerfil" runat="server" EnableViewState="false" TypeName="GMA.DsAdmin.Perfil"
                SelectMethod="ListarPerfil"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_usu" runat="server" Checked="true" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Usuario.aspx" />
    </div>
</asp:Content>
