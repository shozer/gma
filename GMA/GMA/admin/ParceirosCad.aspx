<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="ParceirosCad.aspx.vb" Inherits="admin_ParceirosCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Parceiros"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Parceiro:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_parceiro_par" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o Parceiro!"
                Text="*" Display="Dynamic" ControlToValidate="nom_parceiro_par"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Imagem:
        </div>
        <div class="campo">
            <asp:Label ID="des_imagem_par" runat="server"></asp:Label>
            <asp:FileUpload ID="upl_des_imagem_par" runat="server" />
        </div>
        <div class="campo_titulo">
            Link:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_link_par" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_par" runat="server" Checked="true" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Parceiros.aspx" />
    </div>
</asp:Content>
