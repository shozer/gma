<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="OrdenacaoProjeto.aspx.vb" Inherits="admin_OrdenacaoProjeto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        Ordenação dos projetos</h1>
    <div class="filtros">
        <div class="linha_filtro">
            <div class="campo_titulo_filtro">
                Tipo de projeto:
            </div>
            <div class="campo_filtro">
                <asp:DropDownList ID="cod_tipo_projeto_tpr" AppendDataBoundItems="true" DataValueField="cod_tipo_projeto_tpr"
                    DataTextField="nom_tipo_projeto_pt_tpr" EnableViewState="false" runat="server"
                    DataSourceID="odsTipoProjeto">
                    <asp:ListItem Value="-1">Todos</asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsTipoProjeto" EnableViewState="false" TypeName="GMA.DsAdmin.TipoProjeto"
                    runat="server" SelectMethod="ListarTipoProjeto"></asp:ObjectDataSource>
            </div>
        </div>
        <div class="linha_filtro">
            <div class="botao_filtro">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grvPrincipal" EnableViewState="false" AllowPaging="true" AllowSorting="true"
                PageSize="30" AutoGenerateColumns="false" runat="server" DataSourceID="odsPrincipal"
                DataKeyNames="cod_tipo_projeto_tpr" Width="500px">
                <Columns>
                    <asp:BoundField DataField="nom_tipo_projeto_pt_tpr" HeaderText="Tipo de projeto"
                        SortExpression="nom_tipo_projeto_pt_tpr">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="qtd_projetos_vitrine_tpr" HeaderText="Qtd. de projetos na vitrine"
                        SortExpression="qtd_projetos_vitrine_tpr">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sts_ativo_tpr" HeaderText="Ativo" SortExpression="sts_ativo_tpr">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:ImageButton ID="btnOrdenar" runat="server" ImageUrl="~/img/ordenacao.png" Width="32px"
                                Height="32px" ToolTip="Ordenar os projetos na vitrine" PostBackUrl='<%# Eval("cod_tipo_projeto_tpr", "~/admin/OrdenacaoProjetoCad.aspx?cod_tipo_projeto_tpr={0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Nenhuma informação foi encontrada.
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPrincipal" EnableViewState="false" SelectMethod="ListarTipoProjetoPorFiltro"
        runat="server" TypeName="GMA.DsAdmin.TipoProjeto">
        <SelectParameters>
            <asp:ControlParameter ControlID="cod_tipo_projeto_tpr" Name="cod_tipo_projeto_tpr"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
