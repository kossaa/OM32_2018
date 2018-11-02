<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="WebApplication1.Top" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Body">
        <div class="AdLinkButton">
            <asp:ImageButton ID="ImageButton1" runat="server" />
        </div>

        <div class="MainMovie">
            <asp:GridView CssClass="MainMovieInfo" runat="server"></asp:GridView>
        </div>

        <div class="Price">
            <asp:GridView ID="PriceGridView" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
