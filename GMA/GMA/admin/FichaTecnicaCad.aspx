<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="FichaTecnicaCad.aspx.vb" Inherits="admin_FichaTecnicaCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Ficha técnica"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Projeto em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_projeto_pt_fte" runat="server" Width="400px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o projeto em português!"
                Text="*" Display="Dynamic" ControlToValidate="nom_projeto_pt_fte"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Projeto em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_projeto_es_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Projeto em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_projeto_en_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Descrição da projeto em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_projeto_pt_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ErrorMessage="Preencha a descrição em português!" Text="*" Display="Dynamic"
                    ControlToValidate="des_projeto_pt_fte"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Descrição da projeto em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_projeto_es_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Descrição da projeto em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_projeto_en_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Programa em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_programa_pt_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Programa em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_programa_es_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Programa em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_programa_en_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Artigo em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_artigo_pt_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Artigo em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_artigo_es_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Artigo em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_artigo_en_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Vídeo em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_video_pt_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Vídeo em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_video_es_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Vídeo em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_video_en_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Entrevista em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_entrevista_pt_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Entrevista em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_entrevista_es_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Entrevista em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_entrevista_en_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Livro em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_livro_pt_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Livro em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_livro_es_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Livro em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_livro_en_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/FichaTecnica.aspx" />
    </div>
</asp:Content>
