<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Contato.aspx.vb" Inherits="Contato" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contato</title>
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container_contato">
        <div class="titulo_contato">
            <h2>
                Contato</h2>
            <a href="#" title="fechar" class="close" rel="modalclose">fechar</a>
            <div class="clear">
            </div>
        </div>
        <div class="divisao_titulo">
        </div>
        <div class="container_campos_info">
            <div class="container_campo">
                <div class="campo">
                    <span>Nome</span>
                    <asp:TextBox ID="txbNome" CssClass="input_contato" runat="server"></asp:TextBox>
                    <div class="clear">
                    </div>
                </div>
                <div class="campo">
                    <span>Telefone</span>
                    <asp:TextBox ID="txbDdd" CssClass="input_contato_ddd" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txbTelefone" CssClass="input_contato_telefone" runat="server"></asp:TextBox>
                    <div class="clear">
                    </div>
                </div>
                <div class="campo">
                    <span>Assunto</span>
                    <asp:TextBox ID="txbAssunto" CssClass="input_contato" runat="server"></asp:TextBox>
                    <div class="clear">
                    </div>
                </div>
                <div class="campo">
                    <span>Mensagem</span>
                    <asp:TextBox ID="txbMensagem" CssClass="input_contato_mensagem" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <div class="clear">
                    </div>
                </div>
                <div class="campo">
                    <asp:Button ID="Button1" CssClass="btn_enviar" runat="server" Text="Enviar" />
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="container_info">
            <h3>E-mail</h3>
            <span>contato@gma.com.br</span>
             <h3>Telefone</h3>
            <span>+55 71 3542.0998</span>
            </div>
           
            
        </div>
        <div class="clear">
        </div>
    </div>
    
    </form>
</body>
</html>
