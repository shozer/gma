<%@ Page Language="VB" MasterPageFile="~/MasterPagePadrao.master" AutoEventWireup="false"
    CodeFile="Projetos.aspx.vb" Inherits="Projetos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="sidebar_left_projetos">
        <h2 id="lblTitulo" runat="server"></h2>
        <div class="divisao_descricao">
        </div>
        <span>A empresa GMA (Grupo Multidisciplinar capacitados a traduzir as necessidades do
            cliente desenvolvendo critérios e ações para uma arquitetura de qualidade eficiente
            e econômica. </span>
    </div>
    <div class="sidebar_rigth_projetos">
        <div id="carrossel">
            <ul>
                <div id="divProjetos" runat="server">
                </div>
            </ul>
        </div>
        <div class="setas_projetos">
            <a href="#" class="prev">
                <img src="img/seta_prev_projetos.jpg" style="border: 0;" alt="" />
            </a><a href="#" class="next">
                <img src="img/seta_next_projetos.jpg" style="border: 0;" alt="" />
            </a>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
