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
</head>
<body>
    <form id="form1" runat="server">
    <div id="noticia">
        <div id="titulo_noticia">
            <asp:Label ID="lblTitulo" runat="server"></asp:Label>
        </div>
        <div id="texto_noticia">
            <asp:Label ID="lblNoticia" runat="server"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
