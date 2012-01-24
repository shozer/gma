﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Espaco_Cliente.aspx.vb"
    Inherits="Espaco_Cliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Espaço Cliente</title>
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container_espaco_cliente">
        <div class="titulo_espaco_cliente">
            <h2>
                Espaço cliente</h2>
            <a href="#" title="fechar" class="close" rel="modalclose">fechar</a>
            <div class="clear">
            </div>
        </div>
        <div class="divisao_titulo_espaco_cliente">
        </div>
        <div class="container_campos_info">
            <div class="container_campo">
                <div class="campo">
                    <span>Usuário</span>
                    <asp:TextBox ID="txbUsuario" CssClass="input_contato" runat="server"></asp:TextBox>
                    <div class="clear">
                    </div>
                </div>
                <div class="campo">
                    <span>Senha</span>
                    <asp:TextBox ID="txbSenha" CssClass="input_contato" runat="server"></asp:TextBox>
                    <div class="clear">
                    </div>
                </div>
                <div class="campo">
                    <asp:Button ID="Button1" CssClass="btn_enviar" runat="server" Text="Entrar" />
                    <div class="clear">
                    </div>
                </div>
            </div>
            
        </div>
        <div class="clear">
        </div>
    </div>
    </form>
</body>
</html>