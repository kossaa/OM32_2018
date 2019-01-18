<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Individual_Page.aspx.cs" Inherits="WebApplication1.Individual_Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
        .auto-style7 {
            width: 317px;
            height: 21px;
        }
        .auto-style8 {
            height: 21px;
        }
        .auto-style9 {
            width: 420px;
        }
        .auto-style11 {
            height: 10%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style7">
                <asp:Label ID="PublicationDateLabel" runat="server"></asp:Label>
            </td>
            <td class="auto-style8">
                <asp:Label ID="MovieTitleLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style9" rowspan="4">
                <asp:Image ID="MovieSignbordImage" runat="server" Height="300px" Width="420px" />
                <br />
                <asp:ImageButton ID="MovieCaptureImage1" runat="server" Height="100px" OnClick="MovieCaptureImage1_Click"  Width="135px" />
                <asp:ImageButton ID="MovieCaptureImage2" runat="server" Height="100px" OnClick="MovieCaptureImage2_Click"  Width="135px" />
                <asp:ImageButton ID="MovieCaptureImage3" runat="server" Height="100px" OnClick="MovieCaptureImage3_Click"  Width="135px" />
            </td>
            <td height="10%" style="background-color: #FDF0BB">
                <asp:Label ID="SummaryLabel" runat="server" Text="あらすじ"></asp:Label>
            </td>
        </tr>

        <tr>
            <td valign="top" style="background-color: #F1FFDB">
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:Label ID="MainSummaryLabel" runat="server" Width="850px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="TimeLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style11" style="background-color: #FDF0BB">
                <asp:Label ID="CastLabel" runat="server" Text="キャスト"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" style="background-color: #F1FFDB">
                <asp:Table ID="CastTable" runat="server">
                </asp:Table>
            </td>
        </tr>
    </table>
    <br />
    </asp:Content>
