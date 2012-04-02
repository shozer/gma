<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Principal.aspx.vb" Inherits="Principal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GMA - Grupo Multidisciplinar para Arquitetura</title>
    <meta name="title" content="GMA - Grupo Multidisciplinar para Arquitetura" />
    <meta name="url" content="www.webgma.com" />
    <meta name="description" content="Grupo de arquitetos especializados em projetos residenciais, comerciais, urbanismo ou paisagismo, restauração, interior ou design." />
    <meta name="keywords" content="Arquitetura, Arquitetos, Arquitetos em Salvador, Restauração, Urbanismo, Paisagismo, design de interiores, projetos residenciais, projetos comerciais" />
    <meta name="charset" content="ISO-8859-1" />
    <meta name="revisit-after" content="5" />
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.7.1.min.js" type="text/javascript"></script>
    
    <script src="js/stuHover.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/cycle.js"></script>

    <script type="text/javascript">
        jQuery(function() {
            jQuery('#noticias ul li').cycle({
                fx: 'scrollDown',
                visible: 2,
                speed: 300,
                timeout: 8000,
                next: '#up',
                prev: '#down',
                pager: '#pager'
            });

            jQuery('#parceiro ul').cycle({
                fx: 'fade',
                visible: 2,
                speed: 500,
                timeout: <%=Session("timeout") %>
            });
        })
    </script>

    <script src="js/exemploModal.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-modal-1.0.js"></script>

    <script type="text/javascript">
        jQuery(document).ready(function() {
            jQuery('a#exemplo').modal();
            jQuery('a#exemplo2').modal();
        });
    </script>

    <script src="js/mootools-1.2-core.js" type="text/javascript"></script>

    <script src="js/_class.noobSlide.packed.js" type="text/javascript"></script>

    <script type="text/javascript">
        window.addEvent('domready', function() {
            //SAMPLE 4 (walk to item)
            var nS4 = new noobSlide({
                box: $('box4'),
                items: $$('#box4 div'),
                size: 961,
                interval: 10000,
                autoPlay: true,
                handles: $$('#handles4 span'),
                onWalk: function(currentItem, currentHandle) {
                    this.handles.removeClass('active');
                    currentHandle.addClass('active');
                }
            });
            /*
            var nS1 = new noobSlide({
            box: $('box1'),
            items: $$('#box1 div'),
            size: 961,
            interval: 10000,
            autoPlay: true,
            handles: $$('#handles4 span'),
            onWalk: function(currentItem, currentHandle) {
            this.handles.removeClass('active');
            currentHandle.addClass('active');
            }
            });
            */
        });
    </script>

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
</head>
<body>
    <form id="form1" runat="server">
    <div class="container_geral">
        <header class="topo">
            <nav class="menu" id="nav">
                <ul class="select">
                    <li><a href="#">PROJETOS</a>
                        <ul class="sub">
                            <li><a href="Projetos.aspx?cod_tipo_projeto_tpr=2">RESIDENCIAL</a></li>
                            <li><a href="Projetos.aspx?cod_tipo_projeto_tpr=3">COMERCIAL/INSTITUCIONAL</a></li>
                            <li><a href="Projetos.aspx?cod_tipo_projeto_tpr=4">RESTAURO</a></li>
                            <li><a href="Projetos.aspx?cod_tipo_projeto_tpr=1">URBANISMO/PAISAGISMO</a></li>
                            <li><a href="Projetos.aspx?cod_tipo_projeto_tpr=5">INTERIOR/DESIGN</a></li>
                            <!--li><a href="#">LUMINOTÉCNICO</a></li-->
                        </ul>
                    </li>
                    <li><a href="#">ASSESSORIA</a>
                        <ul class="sub">
                            <li><a href="#">PROJETO</a></li>
                            <li><a href="#">LAYOUT</a></li>
                        </ul>
                    </li>
                    <li><a href="#">GESTÃO DE OBRAS</a>
                        <ul class="sub">
                            <li><a href="#">REFORMA</a></li>
                            <li><a href="#">CONSTRUÇÃO</a></li>
                        </ul>
                    </li>
                    <li><a href="#">COMUNICAÇÃO VISUAL</a>
                        <ul class="sub">
                            <li><a href="#">RENDERINGS</a></li>
                            <li><a href="#">PLANTAS DECORADAS</a></li>
                            <li><a href="#">ANIMAÇÃO</a></li>
                            <li><a href="#">MARCAS</a></li>
                        </ul>
                    </li>
                    <li><a href="#">UTILITÁRIOS</a>
                        <ul class="sub">
                            <li><a href="#">BLOCOS CAD</a></li>
                            <li><a href="#">BLOCOS SKETCHUP</a></li>
                            <li><a href="#">PADRÃO GMA</a></li>
                            <li><a href="#">MARCAS</a></li>
                        </ul>
                    </li>
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
            <div class="banner_destaque">
                <div class="lateral_banner">
                    <div id="box1" runat="server">
                        <div class="descricao_projeto">
                            <h2 id="lblTituloProjeto" runat="server">
                                Casamalha</h2>
                            <h3 id="lblLocalProjeto" runat="server">
                                Paraty-Br</h3>
                            <div class="clear">
                            </div>
                            <div class="divisao_descricao">
                            </div>
                            <span id="lblBriefing" runat="server">A empresa GMA (Grupo Multidisciplinar para Arquitetura)
                                capacitados a traduzir as necessidades do cliente desenvolvendo critérios e ações
                                para uma arquitetura de qualidade eficiente e econômica.</span>
                        </div>
                    </div>
                    <p class="buttons" id="handles4" runat="server">
                        <span></span><span></span><span></span>
                    </p>
                </div>
                <div class="mask3">
                    <div id="box4" runat="server">
                        <div class="container_banner">
                            <a href="#">
                                <img src="img/banner_teste.jpg" alt="Banner" style="border: 0;" />
                            </a>
                        </div>
                        <div class="container_banner">
                            <a href="#">
                                <img src="img/banner_teste.jpg" alt="Banner" style="border: 0;" />
                            </a>
                        </div>
                        <div class="container_banner">
                            <a href="#">
                                <img src="img/banner_teste.jpg" alt="Banner" style="border: 0;" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <footer>
            <div class="footer_sup">
                <div class="container_link_box">
                    <a id="exemplo" href="Contato.aspx" class="link_box modal">CONTATO</a> <a id="exemplo2"
                        href="Espaco_Cliente.aspx" class="link_box margin_right_0">ESPAÇO DO CLIENTE</a>
                </div>
                <div class="titulo_noticias">
                    <span>NOTÍCIAS</span>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="footer_inf">
                <div class="redes_sociais">
                    <a href="#" class="icone_rede_social">
                        <img src="img/twitter.png" style="border: 0;" alt="twitter" />
                    </a><a href="#" class="icone_rede_social">
                        <img src="img/facebook.png" style="border: 0;" alt="twitter" />
                    </a><a href="#" class="icone_rede_social">
                        <img src="img/email.png" style="border: 0;" alt="twitter" />
                    </a>
                    <div class="clear">
                    </div>
                </div>
                <div id="noticias" runat="server">
                </div>
            </div>
        </footer>
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
