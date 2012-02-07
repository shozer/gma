<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="NoticiaCad.aspx.vb" Inherits="admin_NoticiaCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Notícias"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Título em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_titulo_pt_not" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o título em português!"
                Text="*" Display="Dynamic" ControlToValidate="des_titulo_pt_not"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Título em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_titulo_es_not" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Título em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_titulo_en_not" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Descrição da notícia em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_descricao_pt_not" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px" SkinID="Obrigatorio"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ErrorMessage="Preencha a descrição em português!" Text="*" Display="Dynamic"
                    ControlToValidate="des_descricao_pt_not"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Descrição da notícia em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_descricao_es_not" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Descrição da notícia em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_descricao_en_not" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Notícia em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_noticia_pt_not" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px" SkinID="Obrigatorio"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ErrorMessage="Preencha a notícia em português!" Text="*" Display="Dynamic"
                    ControlToValidate="des_noticia_pt_not"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Notícia em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_noticia_es_not" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Notícia em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_noticia_en_not" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_not" runat="server" Checked="true" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Noticia.aspx" />
    </div>
</asp:Content>
