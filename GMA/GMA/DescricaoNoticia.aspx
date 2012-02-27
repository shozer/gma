<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DescricaoNoticia.aspx.vb"
    Inherits="DescricaoNoticia" %>

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
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.7.1.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container_geral">
        <header class="topo">
            <nav class="menu">
                <ul id="topnav">
                    <li><a href="#">PROJETOS</a> <span><a href="Projetos.aspx?cod_tipo_projeto_tpr=2">RESIDENCIAL</a>
                        <a href="Projetos.aspx?cod_tipo_projeto_tpr=3">COMERCIAL/INSTITUCIONAL</a> <a href="Projetos.aspx?cod_tipo_projeto_tpr=4">
                            RESTAURO</a> <a href="Projetos.aspx?cod_tipo_projeto_tpr=1">URBANISMO/PAISAGISMO</a>
                        <a href="Projetos.aspx?cod_tipo_projeto_tpr=5">INTERIOR/ DESIGN</a> </span></li>
                    <li><a href="#">ASSESSORIA</a> <span><a href="#">PROJETO</a><a href="#">LAYOUT</a> </span>
                    </li>
                    <li><a href="#">GESTÃO DE OBRAS</a><span><a href="#">REFORMA</a><a href="#">CONSTRUÇÃO</a>
                    </span></li>
                    <li><a href="#">COMUNICAÇÃO VISUAL</a> <span><a href="#">RENDERINGS</a><a href="#">PLANTAS
                        DECORADAS</a><a href="#">ANIMAÇÃO</a><a href="#">MARCAS</a> </span></li>
                    <li><a href="#">UTILITÁRIOS</a> <span><a href="#">BLOCOS CAD</a><a href="#">BLOCOS SKETCHUP</a><a
                        href="#">PADRÃO GMA</a><a href="#">MARCAS</a> </span></li>
                </ul>
                <div class="clear">
                </div>
            </nav>
            <div class="layer_inf">
                <h1 class="logo">
                    <a href="#">
                        <img src="img/logo_site.jpg" style="border: 0;" alt="GMA Arquitetura" />
                    </a>
                </h1>
                <!-- Teste -->
                <div id="parceiro" class="parceiro" runat="server">
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="divisao_header">
            </div>
        </header>
        <section class="main">
            <div id="noticia">
                <div id="titulo_noticia">
                    <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                </div>
                <div id="texto_noticia">
                    <asp:Label ID="lblNoticia" runat="server"></asp:Label>
                </div>
            </div>
        </section>
        
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
