<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="ArquivoCad.aspx.vb" Inherits="admin_ArquivoCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Arquivos"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Arquivo:
        </div>
        <div class="campo">
            <asp:Label ID="nom_arquivo_arq" runat="server"></asp:Label>
            <asp:FileUpload ID="upl_nom_arquivo_arq" runat="server" />
        </div>
        <div class="campo_titulo">
            Descrição do arquivo em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_arquivo_pt_arq" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px" SkinID="Obrigatorio"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server" ErrorMessage="Preencha a descrição em português!" Text="*" Display="Dynamic"
                    ControlToValidate="des_arquivo_pt_arq"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Descrição do arquivo em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_arquivo_es_arq" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Descrição do arquivo em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_arquivo_en_arq" runat="server" TextMode="MultiLine" Width="400px"
                Height="250px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_arq" runat="server" Checked="true" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Arquivo.aspx" />
    </div>
</asp:Content>
