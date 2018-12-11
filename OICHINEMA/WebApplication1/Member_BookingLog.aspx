<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_BookingLog.aspx.cs" Inherits="WebApplication1.BookingLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Pagename_lbl" runat="server" Text="チケット購入履歴"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:GridView ID="Log_gv" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="BOOKING_DAY" DataFormatString="{0:yyyy/MM/dd}" HeaderText="購入日" SortExpression="BOOKING_DAY" />
                        <asp:BoundField DataField="WORK_NAME" HeaderText="タイトル" SortExpression="WORK_NAME" />
                        <asp:BoundField DataField="SEAT_ID" HeaderText="座席名" SortExpression="SEAT_ID" />
                        <asp:BoundField DataField="RATE_NAME" HeaderText="チケット名" SortExpression="RATE_NAME" />
                        <asp:BoundField DataField="EVENT_NAME" HeaderText="イベント名" SortExpression="EVENT_NAME" />
                        <asp:BoundField DataField="BOOKINGDETAIL_POINT" HeaderText="ポイント" SortExpression="BOOKINGDETAIL_POINT" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [BOOKING_DAY], [WORK_NAME], [SEAT_ID], [EVENT_NAME], [RATE_NAME], [BOOKINGDETAIL_POINT] FROM [Q_BOOKINGLOG] WHERE ([MEMBER_ID] = ?)">
                    <SelectParameters>
                        <asp:SessionParameter Name="MEMBER_ID" SessionField="UserID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Back_btn" runat="server" OnClick="Back_btn_Click" Text="戻る" />
            </td>
        </tr>
    </table>
</asp:Content>
