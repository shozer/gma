<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GMA Arquitetura</title>
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />
<!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
< ![endif]-->
<!--[if IE]>
<script type="text/javascript">
document.createElement("article");
document.createElement("nav");
document.createElement("section");
document.createElement("header");
document.createElement("aside");
document.createElement("figure");
document.createElement("legend");
document.createElement("footer");
</script>
<![endif] -->
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
        <section class="container_idiomas">
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
        </section>
    </div>
    </form>
</body>
</html>
