<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    &lt;%@ Page Language="VB" AutoEventWireup="true" %&gt;
    &lt;!DOCTYPE html&gt;
    
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
          timeout: <xsl:value-of select="Dados/parceiros/timeout"/>
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
                  <li>
                    <a href="#">PROJETOS</a>
                    <ul class="sub">
                      <li>
                        <a href="Projetos.aspx?cod_tipo_projeto_tpr=2">RESIDENCIAL</a>
                      </li>
                      <li>
                        <a href="Projetos.aspx?cod_tipo_projeto_tpr=3">COMERCIAL/INSTITUCIONAL</a>
                      </li>
                      <li>
                        <a href="Projetos.aspx?cod_tipo_projeto_tpr=4">RESTAURO</a>
                      </li>
                      <li>
                        <a href="Projetos.aspx?cod_tipo_projeto_tpr=1">URBANISMO/PAISAGISMO</a>
                      </li>
                      <li>
                        <a href="Projetos.aspx?cod_tipo_projeto_tpr=5">INTERIOR/DESIGN</a>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <a href="#">ASSESSORIA</a>
                    <ul class="sub">
                      <li>
                        <a href="#">PROJETO</a>
                      </li>
                      <li>
                        <a href="#">LAYOUT</a>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <a href="#">GESTÃO DE OBRAS</a>
                    <ul class="sub">
                      <li>
                        <a href="#">REFORMA</a>
                      </li>
                      <li>
                        <a href="#">CONSTRUÇÃO</a>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <a href="#">COMUNICAÇÃO VISUAL</a>
                    <ul class="sub">
                      <li>
                        <a href="#">RENDERINGS</a>
                      </li>
                      <li>
                        <a href="#">PLANTAS DECORADAS</a>
                      </li>
                      <li>
                        <a href="#">ANIMAÇÃO</a>
                      </li>
                      <li>
                        <a href="#">MARCAS</a>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <a href="#">UTILITÁRIOS</a>
                    <ul class="sub">
                      <li>
                        <a href="#">BLOCOS CAD</a>
                      </li>
                      <li>
                        <a href="#">BLOCOS SKETCHUP</a>
                      </li>
                      <li>
                        <a href="#">PADRÃO GMA</a>
                      </li>
                      <li>
                        <a href="#">MARCAS</a>
                      </li>
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
                <div id="parceiro" class="parceiro">
                  <ul>
                    <xsl:for-each select="Dados/parceiros/parceiro">
                      <li>
                        <xsl:choose>
                          <xsl:when test="des_link_par != ''">
                            &lt;a href="<xsl:value-of select="des_link_par"/>" target="_blank"&gt;
                            &lt;img src="img/parceiros/<xsl:value-of select="des_imagem_par"/>" style="border: 0;" width="139px" heigth="134px" alt="<xsl:value-of select="nom_parceiro_par"/>" title="<xsl:value-of select="nom_parceiro_par"/>" / &gt;
                            &lt;/a&gt;
                          </xsl:when>
                          <xsl:otherwise>
                            &lt;img src="img/parceiros/<xsl:value-of select="des_imagem_par"/>" style="border: 0;" width="139px" heigth="134px" alt="<xsl:value-of select="nom_parceiro_par"/>" title="<xsl:value-of select="nom_parceiro_par"/>" / &gt;
                          </xsl:otherwise>
                        </xsl:choose>
                      </li>
                    </xsl:for-each>
                  </ul>
                </div>
                <div class="clear">
                </div>
              </div>
              <div class="divisao_header">
              </div>
            </header>
            <section class="main">
              <div class="banner_destaque">
                <xsl:for-each select="Dados/projetos/projeto">
                  <div class="lateral_banner">
                    <div id="box1">
                      <div class="descricao_projeto">
                        <h2 id="lblTituloProjeto">
                          &lt; If Session("idioma") Is Nothing Then %&gt;
                            <xsl:value-of select="titulo_pt"/>
                          &lt;% ElseIf Session("idioma") = "3" Then %&gt;
                            <xsl:value-of select="titulo_en"/>
                          &lt;% ElseIf Session("idioma") = "2" Then %&gt;
                            <xsl:value-of select="titulo_es"/>
                          &lt; Else &gt;
                            <xsl:value-of select="titulo_pt"/>
                          &lt;% End If %&gt;
                        </h2>
                        <h3 id="lblLocalProjeto">
                          <xsl:value-of select="local"/>
                        </h3>
                        <div class="clear">
                        </div>
                        <div class="divisao_descricao">
                        </div>
                        <span id="lblBriefing" runat="server">
                          &lt; If Session("idioma") Is Nothing Then %&gt;
                            <xsl:value-of select="briefing_pt"/>
                          &lt;% ElseIf Session("idioma") = "3" Then %&gt;
                            <xsl:value-of select="briefing_en"/>
                          &lt;% ElseIf Session("idioma") = "2" Then %&gt;
                            <xsl:value-of select="briefing_es"/>
                          &lt; Else &gt;
                            <xsl:value-of select="briefing_pt"/>
                          &lt;% End If %&gt;                          
                        </span>
                      </div>
                    </div>
                    <p class="buttons" id="handles4">
                      <span></span>
                      <span></span>
                      <span></span>
                    </p>
                  </div>
                  <div class="mask3">
                    <div id="box4">
                      <div class="container_banner">
                        &lt;a href="Projetos.aspx?cod_projeto_pro=<xsl:value-of select="cod_projeto_pro"/>"&gt;
                        &lt;img src="img/projetos/<xsl:value-of select="nom_imagem_projeto_ipr0"/>" alt="Banner" style="border: 0;" /&gt;
                        &lt;/a&gt;
                      </div>
                      <div class="container_banner">
                        &lt;a href="Projetos.aspx?cod_projeto_pro=<xsl:value-of select="cod_projeto_pro"/>"&gt;
                        &lt;img src="img/projetos/<xsl:value-of select="nom_imagem_projeto_ipr1"/>" alt="Banner" style="border: 0;" /&gt;
                        &lt;/a&gt;
                      </div>
                      <div class="container_banner">
                        &lt;a href="Projetos.aspx?cod_projeto_pro=<xsl:value-of select="cod_projeto_pro"/>"&gt;
                        &lt;img src="img/projetos/<xsl:value-of select="nom_imagem_projeto_ipr3"/>" alt="Banner" style="border: 0;" /&gt;
                        &lt;/a&gt;
                      </div>
                    </div>
                  </div>
                </xsl:for-each>
              </div>
            </section>
            <footer>
              <div class="footer_sup">
                <div class="container_link_box">
                  <a id="exemplo" href="Contato.aspx" class="link_box modal">CONTATO</a>
                  <a id="exemplo2"
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
                  </a>
                  <a href="#" class="icone_rede_social">
                    <img src="img/facebook.png" style="border: 0;" alt="twitter" />
                  </a>
                  <a href="#" class="icone_rede_social">
                    <img src="img/email.png" style="border: 0;" alt="twitter" />
                  </a>
                  <div class="clear">
                  </div>
                </div>
                <div id="noticias">
                  <ul>
                    <xsl:for-each select="Dados/noticias/noticia">
                      <li>
                        <span class="noticia_list">
                          &lt;a href="DescricaoNoticia.aspx?cod_noticia_not=<xsl:value-of select="cod_noticia_not"/>" &gt;
                            &lt; If Session("idioma") Is Nothing Then %&gt;
                              <xsl:value-of select="descricao_pt"/>
                            &lt;% ElseIf Session("idioma") = "3" Then %&gt;
                              <xsl:value-of select="descricao_en"/>
                            &lt;% ElseIf Session("idioma") = "2" Then %&gt;
                              <xsl:value-of select="descricao_es"/>
                            &lt; Else &gt;
                              <xsl:value-of select="descricao_pt"/>
                            &lt;% End If %&gt;
                          &lt;/a&gt;
                        </span>
                      </li>
                    </xsl:for-each>
                  </ul>
                  <div class="setas_noticias">
                    <a id="up" href="#">up</a>
                    <a id="down" href="#">down</a>
                  </div>
                  <div class="clear">
                  </div>
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
  </xsl:template>
</xsl:stylesheet>
