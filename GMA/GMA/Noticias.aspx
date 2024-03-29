﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Noticias.aspx.vb" Inherits="Noticias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GMA - Grupo Multidisciplinar para Arquitetura</title>
    <meta name="title" content="GMA - Grupo Multidisciplinar para Arquitetura" />
    <meta name="url" content="www.webgma.com" />
    <meta name="description" content="Grupo de arquitetos especializados em projetos residenciais, comerciais, urbanismo ou paisagismo, restauração, interior ou design." />
    <meta name="keywords" content="Arquitetura, Arquitetos, Arquitetos em Salvador, Restauração, Urbanismo, Paisagismo, design de interiores, projetos residenciais, projetos comerciais" />
    <meta name="charset" content="ISO-8859-1" />
    <meta name="revisit-after" content="5" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scmPrincipal" runat="server" EnableScriptGlobalization="True"
        EnableScriptLocalization="True" OnAsyncPostBackError="HandleError">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <img src="img/load.gif" alt="load" />
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

    <div id="noticia">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                    PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                    DataKeyNames="cod_noticia_not" Width="700px" Font-Names="Lucida Sans Unicode"
                    ForeColor="#556D8F">
                    <Columns>
                        <asp:BoundField DataField="des_titulo_pt_not" HeaderText="Notícias" SortExpression="des_titulo_pt_not">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        Nenhuma notícia cadastrada.
                    </EmptyDataTemplate>
                    <FooterStyle BackColor="#185DAA" Font-Bold="True" ForeColor="White" Font-Size="12px" />
                    <RowStyle BackColor="#EFF3FB" Font-Size="12px" />
                    <EditRowStyle BackColor="#2461BF" Font-Size="12px" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Size="12px" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Size="12px" />
                    <HeaderStyle BackColor="#185DAA" Font-Bold="True" ForeColor="White" Font-Size="12px" />
                    <AlternatingRowStyle BackColor="White" Font-Size="12px" />
                    <EmptyDataRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Size="12px" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarNoticiaAtivo"
            runat="server" TypeName="GMA.DsAdmin.Noticia"></asp:ObjectDataSource>
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
