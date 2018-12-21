<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_Pass_Alter.aspx.cs" Inherits="WebApplication1.Member_pass_alter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="4" style="text-align: center">パスワードの変更</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td rowspan="8">&nbsp;</td>
            <td class="auto-style1" colspan="2">
                パスワード</td>
            <td rowspan="8">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:TextBox ID="Pass_tb" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                新しいパスワード</td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:TextBox ID="Newpass_tb" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                新しいパスワードの確認入力</td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2">
                <asp:TextBox ID="CnewPass_tb" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
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
