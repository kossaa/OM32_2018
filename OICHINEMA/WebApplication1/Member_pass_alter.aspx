<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_pass_alter.aspx.cs" Inherits="WebApplication1.Member_pass_alter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="4" style="text-align: center">パスワード変更</td>
        </tr>
        <tr>
            <td class="auto-style1" rowspan="6">&nbsp;</td>
            <td style="text-align: right">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="Oldpass_tb" runat="server" TextMode="Password" MaxLength="20" OnTextChanged="Oldpass_tb_TextChanged" style="text-align: left"></asp:TextBox>
            </td>
            <td class="auto-style1" rowspan="6">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="Newpass_tb" runat="server" TextMode="Password" MaxLength="20" OnTextChanged="Newpass_tb_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label4" runat="server" style="text-align: right" Text="Label"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="Newpass2_tb" runat="server" TextMode="Password" MaxLength="20" OnTextChanged="Newpass2_tb_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Messe_lbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Messe2_lbl" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="Con_btn" runat="server" Text="確定" OnClick="Con_btn_Click" />
            </td>
            <td style="text-align: center">
                <asp:Button ID="Back_btn" runat="server" Text="戻る" OnClick="Back_btn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
