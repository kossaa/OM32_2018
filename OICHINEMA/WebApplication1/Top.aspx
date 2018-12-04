<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="WebApplication1.Top" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Body">
        <asp:ImageButton ID="ImageButton1" CssClass="AdImage" runat="server" ImageUrl="~/Image/avengers.JPG"/>
        <div class="GridView">
            <div class="MainMovie">
                <asp:Label ID="Label2" CssClass="MainMText" runat="server" Width="180px">注目の映画</asp:Label>
                <asp:GridView CssClass="MainMovieInfo" runat="server"></asp:GridView>
            </div>

            <div class="Price">
                <asp:Label ID="Label1" Cssclass="PriceText" runat="server" Width="170px">料金</asp:Label>
                <asp:GridView ID="PriceGridView" runat="server" AutoGenerateColumns="False" DataSourceID="PriceDB">
                    <Columns>
                        <asp:BoundField DataField="RATE_NAME" HeaderText="チケットの種類" SortExpression="RATE_NAME" ReadOnly="True" />
                        <asp:BoundField DataField="RATE_PRICE" HeaderText="金額" SortExpression="RATE_PRICE" ReadOnly="True" ValidateRequestMode="Enabled" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="PriceDB" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [RATE_NAME], [RATE_PRICE] FROM [TBL_RATE]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            </div>
        </div>
    </div>

</asp:Content>
