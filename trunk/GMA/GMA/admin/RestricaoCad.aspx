<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="RestricaoCad.aspx.vb" Inherits="admin_RestricaoCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function Seleciona() {
            var hf = document.getElementById("ctl00_ContentPlaceHolder1_hfSelecionado");

            for (i = 0; i < document.aspnetForm.elements.length; i++) {
                if (document.aspnetForm.elements[i].type == "checkbox") {
                    if (document.aspnetForm.elements[i].checked) {
                        hf.value = true;
                        break;
                    }
                }
            }

            alert(document.getElementById("ctl00_ContentPlaceHolder1_hfSelecionado").value);
            //document.getElementById("ctl00_ContentPlaceHolder1_hfSelecionado").value = hf.value;
        }
    </script>

    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Restrição"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Arquivo:
        </div>
        <div class="campo">
            <asp:DropDownList ID="cod_arquivo_arq" AppendDataBoundItems="true" DataValueField="cod_arquivo_arq"
                DataTextField="des_arquivo_pt_arq" DataSourceID="odsArquivo" EnableViewState="false"
                runat="server">
                <asp:ListItem Value="-1">Selecione</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Selecione um arquivo!"
                Display="Dynamic" Text="*" ControlToValidate="cod_arquivo_arq" InitialValue="-1"></asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="odsArquivo" EnableViewState="false" TypeName="GMA.DsAdmin.Arquivo"
                runat="server" SelectMethod="ListarArquivo"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Clientes:
        </div>
        <div class="campo">
            <asp:CheckBoxList ID="cod_cliente_cli" DataValueField="cod_cliente_cli" DataTextField="nom_cliente_cli"
                DataSourceID="odsCliente" EnableViewState="false" runat="server" RepeatColumns="4">
            </asp:CheckBoxList>
            <asp:ObjectDataSource ID="odsCliente" EnableViewState="false" TypeName="GMA.DsAdmin.Cliente"
                runat="server" SelectMethod="ListarCliente"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Perfis:
        </div>
        <div class="campo">
            <asp:CheckBoxList ID="cod_perfil_per" DataValueField="cod_perfil_per" DataTextField="nom_perfil_per"
                DataSourceID="odsPerfil" EnableViewState="false" runat="server" RepeatColumns="4">
            </asp:CheckBoxList>
            <asp:ObjectDataSource ID="odsPerfil" EnableViewState="false" TypeName="GMA.DsAdmin.Perfil"
                runat="server" SelectMethod="ListarPerfil"></asp:ObjectDataSource>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:HiddenField ID="hfSelecionado" runat="server" />
        <asp:Button ID="btnSalvar" CssClass="botao" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" CssClass="botao" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Restricao.aspx" />
    </div>
</asp:Content>
