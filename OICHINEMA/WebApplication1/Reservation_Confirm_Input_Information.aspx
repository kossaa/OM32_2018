<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Reservation_Confirm_Input_Information.aspx.cs" Inherits="WebApplication1.Reservation_Confirm_Input_Information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
        .auto-style10 {
            width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="MovieNameLabel" runat="server" Text="上映タイトル："></asp:Label>
            </td>
            <td>                
                <asp:TextBox ID="MovieNameTextbox" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="NameLabel" runat="server" Text="氏名："></asp:Label>
            </td>
            <td>                
                <asp:TextBox ID="NameTextbox" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ReservationSeatLabel" runat="server" Text="予約席："></asp:Label>
            </td>
            <td>                
                <asp:TextBox ID="ReservationSeatTextbox" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="MailAddressLabel" runat="server" Text="メールアドレス："></asp:Label>
            </td>
            <td>                
                <asp:TextBox ID="MailAddressTextbox" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
         <tr>
             <td>
                 <asp:Label ID="ReservationDateStartLabel" runat="server" Text="上映予定日時："></asp:Label>
             </td>
             <td>
                 <asp:TextBox ID="ReservationDateStartTextbox" runat="server" Width="139px"></asp:TextBox>
                 <asp:Label ID="ReservationDateLabel" runat="server" Text="～"></asp:Label>
                 <asp:TextBox ID="ReservationDateEndTextbox" runat="server" Width="139px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td colspan="2">
                 <asp:Label ID="ConfirmLabel" runat="server" Text="以上の内容でよろしいでしょうか"></asp:Label>
             </td>
         </tr>
         <tr>
             <td class="auto-style10">
                 <asp:Button ID="BackBtn" runat="server" Text="戻る" OnClick="BackBtn_Click" />
             </td>
             <td>
                 <asp:Button ID="AcceptBtn" runat="server" Text="確定" OnClick="AcceptBtn_Click" />
             </td>
         </tr>
        </table>
</asp:Content>
