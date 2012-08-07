<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Espaco_Cliente.aspx.vb"
    Inherits="Espaco_Cliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Espaço do cliente</title>
    <meta name="title" content="GMA - Grupo Multidisciplinar para Arquitetura" />
    <meta name="url" content="www.webgma.com" />
    <meta name="description" content="Grupo de arquitetos especializados em projetos residenciais, comerciais, urbanismo ou paisagismo, restauração, interior ou design." />
    <meta name="keywords" content="Arquitetura, Arquitetos, Arquitetos em Salvador, Restauração, Urbanismo, Paisagismo, design de interiores, projetos residenciais, projetos comerciais" />
    <meta name="charset" content="ISO-8859-1" />
    <meta name="revisit-after" content="5" />
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
                    <asp:TextBox ID="txbUsuario" CssClass="input_contato" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbUsuario" ErrorMessage="Preencha o Usuário!"
                        Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <div class="clear">
                    </div>
                </div>
                <div class="campo">
                    <span>Senha</span>
                    <asp:TextBox ID="txbSenha" CssClass="input_contato" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txbSenha" ErrorMessage="Preencha a Senha!"
                        Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <div class="clear">
                    </div>
                </div>
                <div class="campo">
                    <asp:Button ID="btnEnviar" CssClass="btn_enviar" runat="server" Text="Entrar" />
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    </form>

    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-29071308-1']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>

</body>
</html>
