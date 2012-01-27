<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Erro.aspx.vb" Inherits="admin_Erro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GMA - Administrativo</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scmPrincipal" runat="server" EnableScriptGlobalization="True"
        EnableScriptLocalization="True" OnAsyncPostBackError="HandleError">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <img src="../img/load.gif" alt="load" />
        </ProgressTemplate>
    </asp:UpdateProgress>

    <script type="text/javascript">
        // Register the EndRequest Ajax event
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        // Here the Ajax EndRequest event is used to supress any ALERT error message and
        // show them in the lblStatus instead.
        function EndRequestHandler(sender, args) {
            if (args.get_error()) {
                var msg = args.get_error().message;
                alert(msg.substr(53, msg.length - 53));
                // This will avoid the pop-up
                args.set_errorHandled(true);
            }
        }
    </script>

    <div id="container">
        <div class="topo_admin">
            <h1 class="logo">
                <a href="Principal.aspx">
                    <img src="../img/logo_site.jpg" style="border: 0;" alt="GMA Arquitetura" />
                </a>
            </h1>
            <ul class="menu-hv">
                <li><a href="#">Home</a></li>
                <li><a href="#">Cadastro</a>
                    <ul>
                        <li><a href="Perfil.aspx">Perfis</a></li>
                        <li><a href="Usuario.aspx">Usuários</a></li>
                        <li><a href="Contatos.aspx">Contatos</a></li>
                        <li><a href="Parceiros.aspx">Parceiros</a></li>
                        <li><a href="Cliente.aspx">Clientes</a></li>
                        <li><a href="Noticia.aspx">Notícias</a></li>
                        <li><a href="Restricao.aspx">Restrição</a></li>
                    </ul>
                </li>
                <li><a href="#">Gerência de projeto</a>
                    <ul>
                        <li><a href="TipoProjeto.aspx">Tipo de projeto</a></li>
                        <li><a href="SituacaoProjeto.aspx">Situação do projeto</a></li>
                        <li><a href="ConsultorEspecializado.aspx">Consultor especializado</a></li>
                        <li><a href="Profissional.aspx">Profissional</a></li>
                        <li><a href="FichaTecnica.aspx">Ficha técnica</a></li>
                        <li><a href="#">Projetos</a></li>
                        <li><a href="OrdenacaoProjeto.aspx">Ordenação dos projetos</a></li>
                    </ul>
                </li>
                <li><a href="Arquivo.aspx">Arquivos</a></li>
                <li><a href="#">Relatórios</a>
                    <ul>
                        <li><a href="#">Histórico do projeto</a></li>
                    </ul>
                </li>
                <li class="margin_right_0"><a href="RemoveSessao.aspx">Sair</a></li>
            </ul>
            <div class="clear">
            </div>
        </div>
        <div class="divisao_menu_admin">
        </div>
        <div id="content">
            <asp:Label ID="lblErro" runat="server" Text=""></asp:Label>
        </div>
        <div class="clear">
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
        ShowSummary="false" />
    </form>
</body>
</html>
