<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="4" style="text-align: center">プロフィール変更</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">会員ID｛メールアドレス｝</td>
            <td colspan="2">
                <asp:TextBox ID="MemID_tb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">氏名</td>
            <td colspan="2">
                <asp:TextBox ID="MemName_tb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">フリガナ</td>
            <td colspan="2">
                <asp:TextBox ID="MemNameKana_tb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">生年月日</td>
            <td colspan="2">
                <asp:TextBox ID="MemBirth_tb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">性別</td>
            <td colspan="2">
                <asp:TextBox ID="MemGender_tb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">電話番号</td>
            <td colspan="2">
                <asp:TextBox ID="MemTel_tb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">郵便番号</td>
            <td colspan="2">
                <asp:TextBox ID="MemPost_tb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">住所</td>
            <td colspan="2">
                <asp:TextBox ID="MemAdr_tb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: right">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Back_btn" runat="server" OnClick="Back_btn_Click" Text="戻る" />
            </td>
            <td colspan="2">
                <asp:Button ID="Cancel_btn" runat="server" OnClick="Cancel_btn_Click" Text="キャンセル" />
            </td>
            <td>
                <asp:Button ID="Update_btn" runat="server" OnClick="Update_btn_Click" Text="確定" />
            </td>
        </tr>
    </table>
</asp:Content>
