<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Principal.aspx.vb" Inherits="Principal" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GMA Arquitetura</title>
    <link href="App_Themes/Style/StyleGma.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container_geral">
        <header class="topo">
            <h1 class="logo">
                <a href="#">
                    <img src="img/logo_site.jpg" alt="GMA Arquitetura" />
                </a>
            </h1>
            <nav class="menu">
                <ul>
                    <li><a href="#">PROJETOS</a></li>
                    <li><a href="#">CONSULTORIA</a></li>
                    <li><a href="#">GESTÃO DE OBRAS</a></li>
                    <li><a href="#">VISUALIZAÇÃO 3D</a></li>
                    <li class="margin_right_0"><a href="#">UTILITÁRIOS</a></li>
                </ul>
            </nav>
            <div class="parceiro">
                <a href="#">
                    <img src="img/_logo_eliane.jpg" alt="GMA Arquitetura" />
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
                        <img src="img/twitter.png" alt="twitter" />
                    </a>
                    <a href="#" class="icone_rede_social">
                        <img src="img/facebook.png" alt="twitter" />
                    </a>
                    <a href="#" class="icone_rede_social">
                        <img src="img/email.png" alt="twitter" />
                    </a>
                    <div class="clear"></div>
                </div>
                <div class="noticias">
                <span class="noticia_list">
                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the indus
                </span>
                <span class="noticia_list">
                Lorem Ipsum is simply dummy text of the printing and
                </span>
                </div>
            </div>
        </footer>
    </div>
    </form>
</body>
</html>
