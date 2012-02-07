<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="TipoProjetoCad.aspx.vb" Inherits="admin_TipoProjetoCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Tipo projeto"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Tipo de projeto (Pai):
        </div>
        <div class="campo">
            <asp:DropDownList ID="cod_tipo_projeto_pai_tpr" AppendDataBoundItems="true" DataTextField="nom_tipo_projeto_pt_tpr"
                DataValueField="cod_tipo_projeto_tpr" runat="server" DataSourceID="odsTipoProjeto"
                EnableViewState="false">
                <asp:ListItem Value="-1">Nenhum</asp:ListItem>
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odsTipoProjeto" runat="server" EnableViewState="false"
                TypeName="GMA.DsAdmin.TipoProjeto" SelectMethod="ListarTipoProjeto"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Tipo de projeto em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_tipo_projeto_pt_tpr" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o Tipo de projeto em português!"
                Text="*" Display="Dynamic" ControlToValidate="nom_tipo_projeto_pt_tpr"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Tipo de projeto em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_tipo_projeto_es_tpr" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Tipo de projeto em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_tipo_projeto_en_tpr" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Qtd. projetos na vitrine:
        </div>
        <div class="campo">
            <asp:TextBox ID="qtd_projetos_vitrine_tpr" runat="server" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha a quantidade de projetos na vitrine!"
                Text="*" Display="Dynamic" ControlToValidate="qtd_projetos_vitrine_tpr"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_tpr" runat="server" Checked="true" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/TipoProjeto.aspx" />
    </div>
</asp:Content>
