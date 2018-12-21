<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            height: 22px;
        }
        .auto-style3 {
            height: 22px;
            width: 67px;
        }
    </style>
</head>
<body>
    <div>
        <asp:Button ID="BackBtn" runat="server" ForeColor="Red" Text="◀" />
        <asp:Button ID="DayBtn1" runat="server" Text="XX月YY日" />
        <asp:Button ID="DayBtn2" runat="server" Text="XX月YY日" />
        <asp:Button ID="DayBtn3" runat="server" Text="XX月YY日" />
        <asp:Button ID="DayBtn4" runat="server" Text="XX月YY日" />
        <asp:Button ID="GoBtn" runat="server" ForeColor="Red" Text="▶" />
        <br />
        
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        
        <div>
        <p>
            <asp:Image ID="MovieImage" runat="server" />
            <asp:Label ID="TitleLabel" runat="server" Text="映画タイトル"></asp:Label>
            <asp:LinkButton ID="DetailsLinkBtn" runat="server">作品詳細</asp:LinkButton>
        </p>
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
        <asp:Label ID="ScreenLabel" runat="server" Text="スクリーン名"></asp:Label>
        <table id="ScreenTable" runat="server" border="0">
            <tr>
               <td class="auto-style1">
                   <table border="1">
                        <tr>
                            <td class="auto-style1" id="ClassArea1" runat="server" >エリア1</td>
                            <td class="auto-style1" id="ClassArea2" runat="server" >エリア2</td>
                            <td class="auto-style1" id="ClassArea3" runat="server" >エリア3</td>
                        </tr>
                            <tr>
                            <td class="auto-style1" id="ClassArea4" runat="server">エリア4</td>
                            <td class="auto-style1" id="ClassArea5" runat="server">エリア5</td>
                            <td class="auto-style1" id="ClassArea6" runat="server">エリア6</td>
                        </tr>
                            <tr>
                            <td class="auto-style1" id="ClassArea7" runat="server">エリア7</td>
                            <td class="auto-style1" id="ClassArea8" runat="server">エリア8</td>
                            <td class="auto-style1" id="ClassArea9" runat="server">エリア9</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Button ID="TimeBtn" runat="server" Text="上映時間" />

        </div>
        </div>
</body>
</html>
</asp:Content>
