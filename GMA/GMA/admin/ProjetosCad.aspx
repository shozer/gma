﻿<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="ProjetosCad.aspx.vb" Inherits="admin_ProjetosCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../js/jquery.tools.min.js"></script>

    <script type="text/javascript">
        function MostrarDiv() {
            document.getElementById("dialog").style.display = "block";

            var id = "#ctl00_ContentPlaceHolder1_flg_vitrine_principal_pro";
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            $('#mask').css({ 'width': maskWidth, 'height': maskHeight });
            $('#mask').fadeIn(50);
            $('#mask').fadeTo("slow", 0.8);

            //Get the window height and width
            var winH = $(window).height();
            var winW = $(window).width();

            $(id).css('top', winH + $(id).height() / 2);
            $(id).css('left', winW / 2 - $(id).width() / 2);

            $(id).fadeIn(500);
        }
        function FecharDiv() {
            $('#mask').hide();
            $('.window').hide();
        }

        $(document).ready(function() {
            $('.window .close').click(function(e) {
                e.preventDefault();

                $('#mask').hide();
                $('.window').hide();
            });

        });

        function VisualizarImagem() {
            var img = document.getElementById("ctl00_ContentPlaceHolder1_hfImagemClick").value;

            if (img != "") {
                window.open('MostrarImagem.aspx?vid=' + img, 'name');
            }
        }

        function imgClick(imagem, obj) {
            document.getElementById("ctl00_ContentPlaceHolder1_hfImagemClick").value = imagem;

            //Remove a classe selected de todas images
            $('#ctl00_ContentPlaceHolder1_divGaleria .foto_projeto > img').removeClass('selected');

            //Adiciona a classe selected na imagem clicada            
            $(obj).addClass('selected');
        }        
    </script>

    <h1>
        <asp:Label ID="lblTitulo" runat="server" Text="Projetos"></asp:Label>
    </h1>
    <div class="campos">
        <div class="campo_titulo">
            Nome do projeto em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_identificacao_pro" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Preencha o Nome do Projeto!"
                Text="*" Display="Dynamic" ControlToValidate="des_identificacao_pro"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Nome do projeto em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_projeto_es_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Nome do projeto em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="nom_projeto_en_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Briefing do projeto em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_briefing_pt_pro" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px" SkinID="Obrigatorio"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                    runat="server" ErrorMessage="Preencha o briefing em português!" Text="*" Display="Dynamic"
                    ControlToValidate="des_briefing_pt_pro"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Briefing do projeto em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_briefing_es_pro" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Briefing do projeto em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_briefing_en_pro" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Descrição do projeto em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_projeto_pt_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px" SkinID="Obrigatorio"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server" ErrorMessage="Preencha a descrição em português!" Text="*" Display="Dynamic"
                    ControlToValidate="des_projeto_pt_fte"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Descrição do projeto em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_projeto_es_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Descrição do projeto em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_projeto_en_fte" runat="server" TextMode="MultiLine" Width="400px"
                Height="100px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Local: (ex: Salvador-Ba)
        </div>
        <div class="campo">
            <asp:TextBox ID="des_local_pro" runat="server" Width="400px" SkinID="Obrigatorio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Preencha o Local do Projeto!"
                Text="*" Display="Dynamic" ControlToValidate="des_local_pro"></asp:RequiredFieldValidator>
        </div>
        <div class="campo_titulo">
            Cliente:
        </div>
        <div class="campo">
            <asp:DropDownList ID="cod_cliente_cli" EnableViewState="false" AppendDataBoundItems="true"
                DataValueField="cod_cliente_cli" DataTextField="nom_cliente_cli" runat="server"
                DataSourceID="odsCliente" Width="406px">
                <asp:ListItem Value="-1">Selecione</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Selecione um cliente!"
                InitialValue="-1" Display="Dynamic" ControlToValidate="cod_cliente_cli">*</asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="odsCliente" EnableViewState="false" SelectMethod="ListarCliente"
                TypeName="GMA.DsAdmin.Cliente" runat="server"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Programa:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_programa_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Artigo:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_artigo_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Vídeo:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_video_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Entrevista:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_entrevista_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Livro:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_livro_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Tipo do projeto:
        </div>
        <div class="campo">
            <asp:DropDownList ID="cod_tipo_projeto_tpr" EnableViewState="false" AppendDataBoundItems="true"
                DataValueField="cod_tipo_projeto_tpr" DataTextField="nom_tipo_projeto_pt_tpr"
                runat="server" DataSourceID="odsTipoProjeto" Width="406px">
                <asp:ListItem Value="-1">Selecione</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Selecione um tipo do projeto!"
                InitialValue="-1" Display="Dynamic" ControlToValidate="cod_tipo_projeto_tpr">*</asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="odsTipoProjeto" EnableViewState="false" SelectMethod="ListarTipoProjeto"
                TypeName="GMA.DsAdmin.TipoProjeto" runat="server"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Situação do projeto:
        </div>
        <div class="campo">
            <asp:DropDownList ID="cod_situacao_projeto_spr" EnableViewState="false" AppendDataBoundItems="true"
                DataValueField="cod_situacao_projeto_spr" DataTextField="nom_situacao_projeto_pt_spr"
                runat="server" DataSourceID="odsSituacaoProjeto" Width="406px">
                <asp:ListItem Value="-1">Selecione</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Selecione a situação do projeto!"
                InitialValue="-1" Display="Dynamic" ControlToValidate="cod_situacao_projeto_spr">*</asp:RequiredFieldValidator>
            <asp:ObjectDataSource ID="odsSituacaoProjeto" EnableViewState="false" SelectMethod="ListarSituacaoProjeto"
                TypeName="GMA.DsAdmin.SituacaoProjeto" runat="server"></asp:ObjectDataSource>
        </div>
        <div class="campo_titulo">
            Aparecer na vitrine principal:
        </div>
        <div class="campo">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div id="boxes">
                        <div id="dialog" class="window">
                            <div class="form">
                                <div class="topo_form">
                                    <p>
                                        <asp:Label ID="lblIDR" EnableViewState="false" runat="server" Text=""></asp:Label></p>
                                </div>
                                <div class="campos_modal">
                                    <div class="campo_modal">
                                        <asp:Label ID="Label1" EnableViewState="false" runat="server" Text="Já existem 3 projetos na vitrine principal. Selecione um projeto e clique no botão Sim para remover da vitrine."></asp:Label>
                                        <asp:RadioButtonList ID="rblProjetos" DataSourceID="odsProjeto" EnableViewState="false"
                                            DataValueField="cod_projeto_pro" DataTextField="des_identificacao_pro" runat="server"
                                            RepeatDirection="Vertical">
                                        </asp:RadioButtonList>
                                        <asp:ObjectDataSource ID="odsProjeto" EnableViewState="false" TypeName="GMA.DsAdmin.Projeto"
                                            SelectMethod="ListarProjetoVitrine" runat="server"></asp:ObjectDataSource>
                                    </div>
                                    <div class="bt_enviar">
                                        <asp:Button ID="btnSim" runat="server" Text="Sim" CausesValidation="false" />
                                        <asp:Button ID="btnNao" runat="server" Text="Não" CausesValidation="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Não remova o div#mask, pois ele é necessário para preencher toda a janela -->
                        <div id="mask">
                        </div>
                    </div>
                    <asp:CheckBox ID="flg_vitrine_principal_pro" runat="server" AutoPostBack="true" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSim" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnNao" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="campo_titulo">
            Ativo:
        </div>
        <div class="campo">
            <asp:CheckBox ID="sts_ativo_pro" runat="server" Checked="true" />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="campo_titulo">
                    Profissionais envolvidos:
                </div>
                <div class="campo">
                    <table>
                        <tr>
                            <td>
                                Todos profissionais:<br />
                                <asp:ListBox ID="lstTodosProfissionais" runat="server" SelectionMode="Multiple" Width="200px"
                                    Height="200px" DataSourceID="odsProfissionais" DataTextField="nom_profissional_prf"
                                    DataValueField="cod_profissional_prf"></asp:ListBox>
                                <asp:ObjectDataSource ID="odsProfissionais" EnableViewState="false" SelectMethod="ListarProfissional"
                                    TypeName="GMA.DsAdmin.Profissional" runat="server"></asp:ObjectDataSource>
                            </td>
                            <td align="center">
                                <asp:Button ID="btnAdicionarTodosProfissionais" runat="server" CausesValidation="false"
                                    Text=">>" ToolTip="Adicionar todos os profissionais" />
                                <br />
                                <br />
                                <asp:Button ID="btnAdicionarProfissionaisSelecionados" runat="server" CausesValidation="false"
                                    Text=">" ToolTip="Adicionar os profissionais selecionados" />
                                <br />
                                <br />
                                <asp:Button ID="btnRemoverProfissionaisSelecionados" runat="server" CausesValidation="false"
                                    Text="<" ToolTip="Remover os profissionais selecionados" />
                                <br />
                                <br />
                                <asp:Button ID="btnRemoverTodosProfissionais" runat="server" CausesValidation="false"
                                    Text="<<" ToolTip="Remover todos os profissionais" />
                            </td>
                            <td>
                                Profissionais envolvidos:<br />
                                <asp:ListBox ID="lstProfissionaisEnvolvidos" runat="server" SelectionMode="Multiple"
                                    Width="200px" Height="200px"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="campo_titulo">
                    Consultores:
                </div>
                <div class="campo">
                    <table>
                        <tr>
                            <td>
                                Todos consultores:<br />
                                <asp:ListBox ID="lstTodosConsultores" runat="server" SelectionMode="Multiple" Width="200px"
                                    Height="200px" DataSourceID="odsConsultores" DataValueField="cod_consultor_especializado_ces"
                                    DataTextField="nom_consultor_ces"></asp:ListBox>
                                <asp:ObjectDataSource ID="odsConsultores" EnableViewState="false" SelectMethod="ListarConsultorEspecializado"
                                    TypeName="GMA.DsAdmin.ConsultorEspecializado" runat="server"></asp:ObjectDataSource>
                            </td>
                            <td align="center">
                                <asp:Button ID="btnAdicionarTodosConsultores" runat="server" CausesValidation="false"
                                    Text=">>" ToolTip="Adicionar todos os consultores" />
                                <br />
                                <br />
                                <asp:Button ID="btnAdicionarConsultoresSelecionados" runat="server" CausesValidation="false"
                                    Text=">" ToolTip="Adicionar os consultores selecionados" />
                                <br />
                                <br />
                                <asp:Button ID="btnRemoverConsultoresSelecionados" runat="server" CausesValidation="false"
                                    Text="<" ToolTip="Remover os consultores selecionados" />
                                <br />
                                <br />
                                <asp:Button ID="btnRemoverTodosConsultores" runat="server" CausesValidation="false"
                                    Text="<<" ToolTip="Remover todos os consultores" />
                            </td>
                            <td>
                                Consultores envolvidos:<br />
                                <asp:ListBox ID="lstConsultoresSelecionados" runat="server" SelectionMode="Multiple"
                                    Width="200px" Height="200px" DataValueField="cod_consultor_especializado_ces"
                                    DataTextField="nom_consultor_ces"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnRemoverTodosProfissionais" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRemoverProfissionaisSelecionados" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdicionarProfissionaisSelecionados" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdicionarTodosProfissionais" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRemoverTodosConsultores" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRemoverConsultoresSelecionados" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdicionarConsultoresSelecionados" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdicionarTodosConsultores" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="campo_titulo">
            Imagens do projeto:
        </div>
        <div class="campo">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hfImagemClick" runat="server" />
                    <div id="divGaleria" class="galeria_projeto" runat="server">
                    </div>
                    <asp:Panel ID="pnlFoto" runat="server">
                        <img src="../img/bot_pesquisar.png" alt="Visualizar" title="Ampliar a imagem selecionada!"
                            onclick="VisualizarImagem();" style="border: 0; cursor: pointer;">
                        <asp:ImageButton ID="btnExcluir" runat="server" ImageUrl="~/img/bot_excluir.png"
                            ToolTip="Remover a imagem selecionada!" OnClientClick="return confirm('Deseja excluir a imagem?');" />
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnExcluir" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr1" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr2" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr3" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr4" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr5" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr6" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr7" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr8" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr9" runat="server" />
            <asp:FileUpload ID="upl_nom_imagem_projeto_ipr10" runat="server" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Projetos.aspx" />
    </div>
</asp:Content>
