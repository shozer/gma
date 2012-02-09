<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="ProjetosCad.aspx.vb" Inherits="admin_ProjetosCad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            Programa em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_programa_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Programa em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_programa_es_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Programa em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_programa_en_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Artigo em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_artigo_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Artigo em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_artigo_es_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Artigo em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_artigo_en_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Vídeo em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_video_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Vídeo em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_video_es_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Vídeo em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_video_en_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Entrevista em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_entrevista_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Entrevista em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_entrevista_es_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Entrevista em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_entrevista_en_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Livro em português:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_livro_pt_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Livro em espanhol:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_livro_es_fte" runat="server" Width="400px"></asp:TextBox>
        </div>
        <div class="campo_titulo">
            Livro em inglês:
        </div>
        <div class="campo">
            <asp:TextBox ID="des_livro_en_fte" runat="server" Width="400px"></asp:TextBox>
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
            <asp:CheckBox ID="flg_vitrine_principal_pro" runat="server" Checked="true" />
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
                            <td>
                                <asp:Button ID="btnRemoverTodosProfissionais" runat="server" CausesValidation="false"
                                    Text="<<" ToolTip="Remover todos os profissionais" />
                                <br />
                                <br />
                                <asp:Button ID="btnRemoverProfissionaisSelecionados" runat="server" CausesValidation="false"
                                    Text="<" ToolTip="Remover os profissionais selecionados" />
                                <br />
                                <br />
                                <asp:Button ID="btnAdicionarProfissionaisSelecionados" runat="server" CausesValidation="false"
                                    Text=">" ToolTip="Adicionar os profissionais selecionados" />
                                <br />
                                <br />
                                <asp:Button ID="btnAdicionarTodosProfissionais" runat="server" CausesValidation="false"
                                    Text=">>" ToolTip="Adicionar todos os profissionais" />
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
                            <td>
                                <asp:Button ID="btnRemoverTodosConsultores" runat="server" CausesValidation="false"
                                    Text="<<" ToolTip="Remover todos os consultores" />
                                <br />
                                <br />
                                <asp:Button ID="btnRemoverConsultoresSelecionados" runat="server" CausesValidation="false"
                                    Text="<" ToolTip="Remover os consultores selecionados" />
                                <br />
                                <br />
                                <asp:Button ID="btnAdicionarConsultoresSelecionados" runat="server" CausesValidation="false"
                                    Text=">" ToolTip="Adicionar os consultores selecionados" />
                                <br />
                                <br />
                                <asp:Button ID="btnAdicionarTodosConsultores" runat="server" CausesValidation="false"
                                    Text=">>" ToolTip="Adicionar todos os consultores" />
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
        <div class="clear">
        </div>
    </div>
    <div class="filtros">
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false"
            PostBackUrl="~/admin/Projetos.aspx" />
    </div>
</asp:Content>
