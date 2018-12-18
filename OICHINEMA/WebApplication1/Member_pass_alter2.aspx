<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_pass_alter2.aspx.cs" Inherits="WebApplication1.Member_pass_alter2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server">
        <ChangePasswordTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">パスワードの変更</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">パスワード:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="CurrentPassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="パスワードが必要です。" ToolTip="パスワードが必要です。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">新しいパスワード:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="NewPassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="新しいパスワードが必要です。" ToolTip="新しいパスワードが必要です。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">新しいパスワードの確認入力:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="新しいパスワードの確認入力が必要です。" ToolTip="新しいパスワードの確認入力が必要です。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="新しいパスワードの確認入力は、新しいパスワードの入力と一致しなければなりません。" ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="パスワードの変更" ValidationGroup="ChangePassword1" />
                                </td>
                                <td>
                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="キャンセル" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
    </asp:ChangePassword>
</asp:Content>
