﻿<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_MyPage.aspx.cs" Inherits="WebApplication1.Member_MyPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 60px;
        }
        .auto-style3 {
            width: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><%-- MainContent %>--%>
    <table class="auto-style1" style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Pagename_lbl" runat="server" Text="会員情報"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <%--<table style="width:100%;" rules="all">--%>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2">プロフィール</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">会員ID（メールアドレス）</td>
                        <td class="auto-style2">
                            <asp:Label ID="MemID_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">氏名</td>
                        <td class="auto-style2">
                            <asp:Label ID="MemName_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">フリガナ</td>
                        <td class="auto-style2">
                            <asp:Label ID="MemKana_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">性別</td>
                        <td class="auto-style2">
                            <asp:Label ID="MemGender_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">生年月日</td>
                        <td class="auto-style2">
                            <asp:Label ID="MemBirth_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">郵便番号</td>
                        <td class="auto-style2">
                            <asp:Label ID="MemPost_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">住所</td>
                        <td class="auto-style2">
                            <asp:Label ID="MemAdr_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">電話番号</td>
                        <td class="auto-style2">
                            <asp:Label ID="MemTel_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <%--<table style="width:50%;" rules="all">--%>
                <table style="width:100%;">
                    <tr>
                        <td>保有ポイント：</td>
                        <td>
                            <asp:Label ID="MemPoint_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="Purchaselog_linkbtn" runat="server" OnClick="Purchaselog_linkbtn_Click1" PostBackUrl="~/Member_BookingLog.aspx">チケット購入履歴</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="Profile_linkbtn" runat="server" OnClick="Profile_linkbtn_Click1" PostBackUrl="~/Member_info_alter.aspx">プロフィール変更</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="Passalter_linkbtn" runat="server" OnClick="Passalter_linkbtn_Click">パスワード変更</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="text-align: center">
                            <asp:Button ID="Withdrawal_btn" runat="server" Text="退会" style="text-align: left" OnClick="Withdrawal_btn_Click1" OnClientClick="return confirm(&quot;退会します。); " />
                        </td>
        </tr>
        </table>
</asp:Content>
