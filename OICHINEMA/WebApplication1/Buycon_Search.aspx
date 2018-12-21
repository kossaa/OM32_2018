<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Buycon_Search.aspx.cs" Inherits="WebApplication1.Buy_con" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="3" style="text-align: center">購入情報の確認</td>
        </tr>
        <tr>
            <td rowspan="7">&nbsp;</td>
            <td>&nbsp;</td>
            <td rowspan="7">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">メールアドレス</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:TextBox ID="Mail_tb" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">購入番号</td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:TextBox ID="BuyID_tb" runat="server" MaxLength="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Messe_lbl" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="Inq_btn" runat="server" Text="照会する" OnClick="Inq_btn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
