<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="BookingLog.aspx.cs" Inherits="WebApplication1.BookingLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="チケット購入履歴"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="BOOKING_DAY" DataFormatString="{0:yyyy/MM/dd}" HeaderText="購入日" HtmlEncode="False" />
                        <asp:BoundField DataField="WORK_NAME" HeaderText="作品名" />
                        <asp:BoundField DataField="SEAT_ID" HeaderText="座席" />
                        <asp:BoundField DataField="RATE_NAME" HeaderText="チケット名" />
                        <asp:BoundField DataField="EVENT_NAME" HeaderText="イベント名" />
                        <asp:BoundField DataField="BOOKINGDETAIL_POINT" HeaderText="ポイント" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
