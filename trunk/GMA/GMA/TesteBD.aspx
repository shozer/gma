<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TesteBD.aspx.vb" Inherits="TesteBD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .linha
        {
            width: 300px;
            margin-bottom: 10px;
        }
        .coluna
        {
            width: 150px;
            text-align: left;
            float: left;
        }
        .coluna_bt
        {
            width: 100px;
            text-align: left;
            float: left;
        }
        .clear
        {
            clear: both;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <div>
        <div class="linha">
            <div class="coluna">
                <asp:Label ID="Label5" runat="server" Text="Código:"></asp:Label></div>
            <div class="coluna">
                <asp:TextBox ID="cod_contato_con" runat="server"></asp:TextBox></div>
            <div class="clear">
            </div>
        </div>
        <div class="linha">
            <div class="coluna">
                <asp:Label ID="Label1" runat="server" Text="Nome:"></asp:Label></div>
            <div class="coluna">
                <asp:TextBox ID="nom_contato_con" runat="server"></asp:TextBox></div>
            <div class="clear">
            </div>
        </div>
        <div class="linha">
            <div class="coluna">
                <asp:Label ID="Label2" runat="server" Text="E-mail:"></asp:Label></div>
            <div class="coluna">
                <asp:TextBox ID="des_email_con" runat="server"></asp:TextBox></div>
            <div class="clear">
            </div>
        </div>
        <div class="linha">
            <div class="coluna">
                <asp:Label ID="Label3" runat="server" Text="Telefone:"></asp:Label></div>
            <div class="coluna">
                <asp:TextBox ID="num_telefone_con" runat="server"></asp:TextBox></div>
            <div class="clear">
            </div>
        </div>
        <div class="linha">
            <div class="coluna">
                <asp:Label ID="Label4" runat="server" Text="Celular:"></asp:Label></div>
            <div class="coluna">
                <asp:TextBox ID="num_celular_con" runat="server"></asp:TextBox></div>
            <div class="clear">
            </div>
        </div>
        <div class="linha">
            <fieldset style="width: 300px;">
                <div class="coluna_bt">
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" /></div>
                <div class="coluna_bt">
                    <asp:Button ID="btnExcluir" runat="server" Text="Excluir" /></div>
                <div class="coluna_bt">
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" /></div>
            </fieldset>
            <div class="clear">
            </div>
        </div>
        <div class="linha">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grvPrincipal" EnableViewState="false" AutoGenerateColumns="false"
                        runat="server">
                        <Columns>
                            <asp:BoundField DataField="nom_contato_con" HeaderText="Nome"></asp:BoundField>
                            <asp:BoundField DataField="des_email_con" HeaderText="E-mail"></asp:BoundField>
                            <asp:BoundField DataField="num_telefone_con" HeaderText="Telefone"></asp:BoundField>
                            <asp:BoundField DataField="num_celular_con" HeaderText="Celular"></asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            Nenhum contato cadastrado!
                        </EmptyDataTemplate>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
