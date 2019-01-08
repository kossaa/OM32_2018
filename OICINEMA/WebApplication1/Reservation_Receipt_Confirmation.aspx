<%@ Page Title="" Language="C#" MasterPageFile="~/OICINEMA.Master" AutoEventWireup="true" CodeBehind="Reservation_Receipt_Confirmation.aspx.cs" Inherits="WebApplication1.Reservation_Receipt_Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <h2>予約を受け付けました</h2>
                <asp:Label ID="BookingIDLabel" runat="server"></asp:Label>
                <br />
                <asp:Label ID="BookingMailAddressLabel" runat="server"></asp:Label>
                <p><a href="https://www.yahoo.co.jp/">TOPへ戻る</a></p>
            </td>
        </tr>
    </table>
</asp:Content>