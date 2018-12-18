<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="WebApplication1.Top" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
/*トップ画面
広告
-------------------------------------------------------------------------------------------*/
.Body{
    margin-left:5%;
    margin-right:5%;
}

@media screen and (max-width:767px) {//ページの横幅767px以下 
    .Body{
        width:100vw;
        margin-left:0;
        margin-right:0;
    }
    .AdImage{
        float:left;
        width: 100%;
        height: 300px;    
    }
    .Image{
        width:100%;
    }
    .GridView{
        float:left;
        width:100%;
        height:300px;
        clear:both;
    }
    .Price{
        float:left;
    }
}

@media screen and (min-width:768px) {
    .AdImage {
        clear:both;
        width: 800px;
        height: 300px;
    }
    .Image{
        width:100%;
    }
    .GridView{
        float:left;
        clear:both;
        width:50%;
    }

    /*注目映画と料金表のテキスト*/
    .MainMText, .PriceText {
        text-align: center;
        font-size: 20px;
    }

    /*注目映画*/
    .MainMoviePanel {
        float: left;
        width:45%;
        margin-top: 5%;
    }

    .MainMovieInfo {
        width: 250px;
        height: auto;
        border: 2px solid;
    }
    /*料金表*/
    .Price {
        float: right;
        width:45%;
        margin-top: 5%;
    }

    .PriceGridView {
        width:250px;
        height: auto;
        border: 2px solid;
    }
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Body">
        <asp:Panel ID="AdImagePanel" CssClass="AdImage" runat="server">
                <asp:ImageButton CssClass="Image" ID="AdImageButton" runat="server" />
        </asp:Panel>

        <asp:Panel ID="GridViewPanel" CssClass="GridView" runat="server">
            <asp:Panel ID="MainMoviePanel" CssClass="MainMoviePanel" runat="server">
                <asp:Label ID="MainMovieLabel" CssClass="MainMText" runat="server" Width="180px">注目の映画</asp:Label>
                <asp:GridView ID="MainMoviwGridView" CssClass="MainMovieInfo" runat="server" AutoGenerateColumns="False" DataSourceID="BookingRanking">
                    <Columns>
                        <asp:BoundField DataField="WORK_NAME" HeaderText="映画タイトル" SortExpression="WORK_NAME" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="BookingRanking" runat="server" ConnectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\BookingDB.accdb" ProviderName="System.Data.OleDb" SelectCommand="SELECT [WORK_NAME] FROM [QBookingRanking]"></asp:SqlDataSource>
            </asp:Panel>
            <asp:Panel ID="Panel4" CssClass="Price" runat="server">            
                <asp:Label ID="Label1" Cssclass="PriceText" runat="server" Width="170px">料金</asp:Label>
                <asp:GridView ID="PriceGridView" runat="server" AutoGenerateColumns="False" DataSourceID="PriceDB" Width="300px">
                    <Columns>
                        <asp:BoundField DataField="RATE_NAME" HeaderText="チケットの種類" SortExpression="RATE_NAME" ReadOnly="True" />
                        <asp:BoundField DataField="RATE_PRICE" HeaderText="金額" SortExpression="RATE_PRICE" ReadOnly="True" ValidateRequestMode="Enabled" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="PriceDB" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [RATE_NAME], [RATE_PRICE] FROM [TBL_RATE]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
            </asp:Panel>
        </asp:Panel>
    </div>
</asp:Content>
