<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GMA - Grupo Multidisciplinar para Arquitetura</title>
    <meta name="title" content="GMA Grupo Multidisciplinar para Arquitetura" />
    <meta name="url" content="www.webgma.com" />
    <meta name="description" content="Grupo de arquitetos especializados em projetos residenciais, comerciais, urbanismo ou paisagismo, restauração, interior ou design." />
    <meta name="keywords" content="Arquitetura, Arquitetos, Arquitetos em Salvador, Restauração, Urbanismo, Paisagismo, design de interiores, projetos residenciais, projetos comerciais" />
    <meta name="charset" content="ISO-8859-1" />
    <meta name="revisit-after" content="5" />
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function forward(id) {
            document.getElementById("hfIdioma").value = id;
            var btn = document.getElementById("btnSpace");
            btn.click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container_intro">
        <div class="container_idiomas">
            <h1 class="logo_intro">
                <img src="img/logo_intro.png" alt="GMA - Grupo Multidisciplinar para Arquitetura" />
            </h1>
            <div class="links_idiomas">
                <a href="javascript:forward(1)" class="idioma"><span>[</span> português <span>]</span></a>
                <a href="javascript:forward(2)" class="idioma"><span>[</span> espanõl <span>]</span></a>
                <a href="javascript:forward(3)" class="idioma margin_right_0"><span>[</span> english
                    <span>]</span></a>
                <div class="clear">
                </div>
                <asp:HiddenField ID="hfIdioma" runat="server"></asp:HiddenField>
                <asp:ImageButton ID="btnSpace" runat="server" ImageUrl="~/img/spacer.gif"></asp:ImageButton>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
