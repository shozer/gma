<%@ Page Language="VB" MasterPageFile="~/admin/MasterPage.master" AutoEventWireup="false"
    CodeFile="OrdenacaoProjetoCad.aspx.vb" Inherits="admin_OrdenacaoProjetoCad" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.1/jquery.min.js"></script>

    <script type="text/javascript">$.ajaxSetup({ dataType: "json", type: "POST", contentType: "application/json; charset=utf-8" });</script>

    <style type="text/css">
        #galleryUL
        {
            width: 570px;
            list-style-type: none;
            margin: 0px;
            padding: 0px;
        }
        #galleryUL li
        {
            float: left;
            padding: 5px;
            width: 100px;
            height: 100px;
        }
        #galleryUL li div
        {
            width: 90px;
            height: 50px;
            border: solid 1px black;
            background-color: #E0E0E0;
            text-align: center;
            padding-top: 40px;
        }
        .placeHolder div
        {
            background-color: white !important;
            border: dashed 1px gray !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <h1>
        Ordenação do projeto</h1>
    <ul id="galleryUL">
        <asp:Repeater ID="Gallery" runat="server">
            <ItemTemplate>
                <li itemid='<%# Container.ItemIndex %>'>
                    <div>
                        <%# Container.DataItem %></div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <script type="text/javascript" src="../js/jquery.dragsort-0.3.10.min.js"></script>

    <script type="text/javascript">
        $("#galleryUL").dragsort({ dragSelector: "div", dragEnd: saveOrder, placeHolderTemplate: "<li class='placeHolder'><div></div></li>" });

		    function saveOrder() {
		        var data = new Array();
		        $("#galleryUL li").each(function(i, elm) { data[i] = $(elm).attr("itemID"); });
		        $.post("OrdenacaoProjetoCad.aspx/SaveListOrder", '{"ids":["' + data.join('","') + '"]}');
		    };
    </script>

    <div style="clear: both;">
    </div>
</asp:Content>
