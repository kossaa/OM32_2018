<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_info_alter2.aspx.cs" Inherits="WebApplication1.Member_info_alter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
        .auto-style7 {
            width: 100px;
        }
        .auto-style8 {
            width: 100px;
            height: 25px;
        }
        .auto-style9 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Pagename_lbl" runat="server" Text="プロフィール変更"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td colspan="4">氏名</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="漢字"></asp:Label>
                            <br />
                            <asp:TextBox ID="memname_tb" runat="server" OnTextChanged="memname_tb_TextChanged"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="Label2" runat="server" Text="カナ"></asp:Label>
                            <br />
                            <asp:TextBox ID="memkana_tb" runat="server" OnTextChanged="memnamekana_tb_TextChanged"></asp:TextBox>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td colspan="4">性別<br />
                            <asp:DropDownList ID="memgender_ddl" runat="server" OnSelectedIndexChanged="memgender_ddl_SelectedIndexChanged">
                                <asp:ListItem>男</asp:ListItem>
                                <asp:ListItem>女</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td colspan="4">生年月日<br />
                            （西暦）<asp:DropDownList ID="membirthyear_ddl" runat="server" OnSelectedIndexChanged="membirthyear_ddl_SelectedIndexChanged">
                            </asp:DropDownList>
                            年 <asp:DropDownList ID="membirthmonth_ddl" runat="server" OnSelectedIndexChanged="membirthmonth_ddl_SelectedIndexChanged">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            月 <asp:DropDownList ID="membirthday_ddl" runat="server" OnSelectedIndexChanged="membirthday_ddl_SelectedIndexChanged">
                            </asp:DropDownList>
                            日</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td colspan="4">郵便番号（ハイフンなし）<br />
                            <asp:TextBox ID="mempost_tb" runat="server" OnTextChanged="mempost_tb_TextChanged"></asp:TextBox>
                            <asp:Button ID="Postsearch_btn" runat="server" OnClick="Postsearch_btn_Click" Text="検索" />
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td colspan="4">住所<br />
                            <asp:TextBox ID="memadr_tb" runat="server" OnTextChanged="memadr_tb_TextChanged"></asp:TextBox>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td colspan="4">電話番号<br />
                            <asp:TextBox ID="memtel_tb" runat="server" OnTextChanged="memtel_tb_TextChanged"></asp:TextBox>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&nbsp;</td>
                        <td colspan="4">メールアドレス<br />
                            <asp:TextBox ID="memmail_tb" runat="server" OnTextChanged="memmail_tb_TextChanged"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Label ID="Messe_lbl" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8"></td>
                        <td class="auto-style9">
                            <asp:Button ID="Back_btn" runat="server" OnClick="Back_btn_Click" Text="戻る" OnClientClick="return confirm(&quot;前のページに戻ります。(変更内容は破棄されます。)&quot;);" />
                        </td>
                        <td class="auto-style9" colspan="2">
                            <asp:Button ID="Cancel_btn" runat="server" OnClick="Cancel_btn_Click" Text="キャンセル" OnClientClick="return confirm(&quot;内容を元に戻します。(確定されていない情報は破棄されます。)&quot;);" />
                        </td>
                        <td class="auto-style9">
                            <asp:Button ID="Con_btn" runat="server" OnClick="btn_Click" Text="確定" />
                        </td>
                        <td class="auto-style8"></td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
</asp:Content>
