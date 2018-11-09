<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
    <tr>
        <td style="text-align: center">ログイン</td>
    </tr>
    <tr>
        <td style="text-align: center">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:TextBox ID="MemMail_tb" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:TextBox ID="Pass_tb" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Button ID="Login_btn" runat="server" OnClick="Login_btn_Click" Text="ログイン" />
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Button ID="Signup_btn" runat="server" OnClick="Signup_btn_Click" Text="新規登録" />
        </td>
    </tr>
</table>
</asp:Content>
