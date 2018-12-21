<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td style="text-align: center" colspan="3">
            <asp:Label ID="Pagename_lbl" runat="server" Text="ログイン"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: center" rowspan="8">&nbsp;</td>
        <td style="text-align: center">&nbsp;</td>
        <td style="text-align: center" rowspan="8">&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="UserID_lbl" runat="server" Text="ユーザーID"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:TextBox ID="MemMail_tb" runat="server" type="email"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="Pass_lbl" runat="server" Text="パスワード"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:TextBox ID="Pass_tb" runat="server" TextMode="Password" pattern="[A-Z,a-z,1-9]*" title="大小英数字のみで入力して下さい。"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="Messe_lbl" runat="server"></asp:Label>
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
