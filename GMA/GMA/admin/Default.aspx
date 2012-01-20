<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GMA - Administrativo</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scmPrincipal" runat="server" EnableScriptGlobalization="True"
        EnableScriptLocalization="True" OnAsyncPostBackError="HandleError">
    </asp:ScriptManager>

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

    <div id="content_default">
        <div class="logo_default">
            <img alt="Logo" src="../img/logo_intro.png" style="border: 0px;" />
        </div>
        <div class="texto_default">
            <div class="linha_default">
                <div class="coluna_texto_default">
                    <asp:Label ID="Label1" runat="server" Text="Usuário:" ForeColor="White"></asp:Label>
                </div>
                <div class="coluna_campo_default">
                    <asp:TextBox ID="cod_usuario_usu" runat="server" EnableViewState="false" Width="150px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o Usuário!"
                        Display="Dynamic" ControlToValidate="cod_usuario_usu">*</asp:RequiredFieldValidator>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="linha_default">
                <div class="coluna_texto_default">
                    <asp:Label ID="Label2" runat="server" Text="Senha:" ForeColor="White"></asp:Label>
                </div>
                <div class="coluna_campo_default">
                    <asp:TextBox ID="des_senha_usu" runat="server" EnableViewState="false" TextMode="Password"
                        Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ErrorMessage="Preencha a Senha!" Display="Dynamic" ControlToValidate="des_senha_usu">*</asp:RequiredFieldValidator>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="botao_default">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" />
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
        runat="server" />
    </form>
</body>
</html>
