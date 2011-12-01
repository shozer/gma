<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Principal.aspx.vb" Inherits="Principal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GMA Arquitetura</title>
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>

    <script src="js/droplinemenu.js" type="text/javascript"></script>

    <script type="text/javascript">
    //build menu with DIV ID="myslidemenu" on page:
    droplinemenu.buildmenu("droplinetabs1")
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container_geral">
        <header class="topo">
            <h1 class="logo">
                <a href="#">
                    <img src="img/logo_site.jpg" style="border: 0;" alt="GMA Arquitetura" />
                </a>
            </h1>
            <!-- Teste -->
            <nav id="droplinetabs1" class="menu">
                <ul>
                    <li><a href="#">PROJETOS</a>
                        <ul>
                            <li><a href="#">submenu 1</a>
                            <li><a href="#">submenu 2</a>
                            <li><a href="#">submenu 3</a>
                        </ul>
                    </li>
                    <li><a href="#">CONSULTORIA</a>
                        <ul>
                            <li><a href="#">submenu 1</a>
                            <li><a href="#">submenu 2</a>
                            <li><a href="#">submenu 3</a>
                        </ul>
                    </li>
                    <li><a href="#">GESTÃO DE OBRAS</a>
                        <ul>
                            <li><a href="#">submenu 1</a>
                            <li><a href="#">submenu 2</a>
                            <li><a href="#">submenu 3</a>
                        </ul>
                    </li>
                    <li><a href="#">VISUALIZAÇÃO 3D</a>
                        <ul>
                            <li><a href="#">submenu 1</a>
                            <li><a href="#">submenu 2</a>
                            <li><a href="#">submenu 3</a>
                        </ul>
                    </li>
                    <li class="margin_right_0"><a href="#">UTILITÁRIOS</a>
                        <ul>
                            <li><a href="#">submenu 1</a>
                            <li><a href="#">submenu 2</a>
                            <li><a href="#">submenu 3</a>
                        </ul>
                    </li>
                </ul>
            </nav>
            <!--nav class="menu">
                <ul>
                    <li><a href="#">PROJETOS</a></li>
                    <li><a href="#">CONSULTORIA</a></li>
                    <li><a href="#">GESTÃO DE OBRAS</a></li>
                    <li><a href="#">VISUALIZAÇÃO 3D</a></li>
                    <li class="margin_right_0"><a href="#">UTILITÁRIOS</a></li>
                </ul>
            </nav-->
            <div class="parceiro">
                <a href="#">
                    <img src="img/_logo_eliane.jpg" style="border: 0;" alt="GMA Arquitetura" />
                </a>
            </div>
            <div class="clear">
            </div>
        </header>
        <section class="main">
            <div class="banner_destaque">
                <img src="img/banner_destaque.jpg" alt="Destaque GMA" />
            </div>
        </section>
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
