<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Principal.aspx.vb" Inherits="Principal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GMA Arquitetura</title>
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />

    <script src="js/mootools-1.2-core.js" type="text/javascript"></script>

    <script src="js/_class.noobSlide.packed.js" type="text/javascript"></script>

    <script type="text/javascript">        window.addEvent('domready', function () {            //SAMPLE 4 (walk to item)            var nS4 = new noobSlide({                box: $('box4'),                items: $$('#box4 div'),                size: 961,                interval: 10000,                autoPlay: true,                handles: $$('#handles4 span'),                onWalk: function (currentItem, currentHandle) {                    this.handles.removeClass('active');                    currentHandle.addClass('active');                }            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container_geral">
        <header class="topo">
            <nav class="menu">
                <ul id="topnav">
                    <li><a href="#">PROJETOS</a> <span><a href="#">RESIDENCIAL</a> <a href="#">COMERCIAL</a>
                        <a href="#">URBANISMO/PAISAGISMO</a><a href="#">RESTAURO</a><a href="#"> INTERIOR/ DESIGN</a>
                    </span></li>
                    <li><a href="#">CONSULTORIA</a></li>
                    <li><a href="#">GESTÃO DE OBRAS</a> </li>
                    <li><a href="#">VISUALIZAÇÃO 3D</a> </li>
                    <li><a href="#">UTILITÁRIOS</a></li>
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
                <div class="parceiro">
                    <a href="#">
                        <img src="img/_logo_eliane.jpg" style="border: 0;" alt="GMA Arquitetura" />
                    </a>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="divisao_header">
            </div>
        </header>
        <div class="main">
            <section class="banner_destaque">
                <div class="lateral_banner">
                    <div class="descricao_projeto">
                        <h2>
                            Casamalha</h2>
                        <h3>
                            Paraty-Br</h3>
                        <div class="clear">
                        </div>
                        <div class="divisao_descricao"></div>
                        <span>A empresa GMA (Grupo Multidisciplinar capacitados a traduzir as necessidades do
                            cliente desenvolvendo critérios e ações para uma arquitetura de qualidade eficiente
                            e econômica. </span>
                    </div>
                    <p class="buttons" id="handles4">
                        <span></span><span></span><span></span>
                    </p>
                </div>
                <div class="mask3">
                    <div id="box4">
                        <div class="container_banner">
                            <a href="/Paginas/Contato.aspx">
                                <img src="img/banner_teste.jpg" alt="Cadastre-se" style="border: 0;" />
                            </a>
                        </div>
                        <div class="container_banner">
                            <a href="/Paginas/Convenios-e-Beneficios.aspx">
                                <img src="img/banner_teste.jpg" alt="Cadastre-se" style="border: 0;" />
                            </a>
                        </div>
                        <div class="container_banner">
                            <a href="/Paginas/Convenios-e-Beneficios.aspx">
                                <img src="img/banner_teste.jpg" alt="Cadastre-se" style="border: 0;" />
                            </a>
                        </div>
                    </div>
                </div>
            </section>
        </div>
        <footer>
            <div class="footer_sup">
                <div class="container_link_box">
                    <a href="#" class="link_box">CONTATO</a> <a href="#" class="link_box margin_right_0">
                        ESPAÇO DO CLIENTE</a>
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
                <div class="noticias">
                    <span class="noticia_list">Lorem Ipsum is simply dummy text of the printing and typesetting
                        industry. Lorem Ipsum has been the indus </span><span class="noticia_list">Lorem Ipsum
                            is simply dummy text of the printing and </span>
                </div>
            </div>
        </footer>
    </div>
    </form>
</body>
</html>
