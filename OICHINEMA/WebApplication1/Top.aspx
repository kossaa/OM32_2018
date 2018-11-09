<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="WebApplication1.Top" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Body">
        <div class="AdLinkButton">
            <asp:ImageButton ID="ImageButton1" runat="server" Width="100%" Height="100%" ImageUrl="~/Image/avengers.JPG"/>
        </div>

        <div class="MainMovie">
            <asp:Label ID="Label2" CssClass="MainMText" runat="server" Width="180px">注目の映画</asp:Label>
            <asp:GridView CssClass="MainMovieInfo" runat="server"></asp:GridView>
        </div>

        <div class="Price">
            <asp:Label ID="Label1" Cssclass="PriceText" runat="server" Width="170px">料金</asp:Label>
            <asp:GridView ID="PriceGridView" runat="server"></asp:GridView>
        </div>
    </div>

</asp:Content>
