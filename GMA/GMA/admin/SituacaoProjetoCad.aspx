<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="SituacaoProjetoCad.aspx.vb" Inherits="admin_SituacaoProjetoCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Situação do projeto"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Situação do projeto em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_situacao_projeto_pt_spr" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha a situação do projeto em português!"
                Text="*" Display="Dynamic" ControlToValidate="nom_situacao_projeto_pt_spr"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Situação do projeto em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_situacao_projeto_es_spr" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Situação do projeto em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_situacao_projeto_en_spr" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/SituacaoProjeto.aspx" />
    </div>
</asp:Content>
