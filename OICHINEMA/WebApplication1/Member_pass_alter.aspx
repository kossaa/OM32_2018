<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_pass_alter.aspx.cs" Inherits="WebApplication1.Member_pass_alter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="4" style="text-align: center">パスワードの変更</td>
        </tr>
        <tr>
            <td rowspan="5">&nbsp;</td>
            <td style="text-align: right">
                パスワード：</td>
            <td style="text-align: left">
                <asp:TextBox ID="Pass_tb" runat="server" MaxLength="20" AutoPostBack="True"></asp:TextBox>
                <asp:Label ID="IconP_lbl" runat="server" Text="*"></asp:Label>
            </td>
            <td rowspan="5">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                新しいパスワード：</td>
            <td style="text-align: left">
                <asp:TextBox ID="Newpass_tb" runat="server" MaxLength="20" TextMode="Password" AutoPostBack="True"></asp:TextBox>
                <asp:Label ID="IconNp_lbl" runat="server" Text="*"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                新しいパスワードの確認入力</td>
            <td style="text-align: left">
                <asp:TextBox ID="CnewPass_tb" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                <asp:Label ID="IconCnp_lbl" runat="server" Text="*" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:Label ID="Messe_lbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="Com_btn" runat="server" OnClick="Com_btn_Click" Text="確定" />
            </td>
            <td style="text-align: center">
                <asp:Button ID="Cancel_btn" runat="server" CommandName="Cancel" OnClick="Cancel_btn_Click" Text="キャンセル" />
            </td>
        </tr>
        </table>
</asp:Content>
