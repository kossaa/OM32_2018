<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_MyPage.aspx.cs" Inherits="WebApplication1.Member_MyPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label5" runat="server" Text="会員情報"></asp:Label>
        <br />
        <table style="width:100%;">
            <tr>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="プロフィール"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="保有ポイント："></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:LinkButton ID="LinkButton3" runat="server">履歴を見る・・・</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="購入履歴"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView2" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:LinkButton ID="LinkButton4" runat="server">もっと見る・・・</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="プロフィール変更" />
                </td>
                <td style="text-align: left">
                    <asp:Button ID="Button2" runat="server" Text="退会" />
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
