
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleForm.aspx.cs" Inherits="Schedule.ScheduleForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Button ID="BackBtn" runat="server" ForeColor="Red" Text="◀" />
        <asp:Button ID="DayBtn1" runat="server" Text="XX月YY日" />
        <asp:Button ID="DayBtn2" runat="server" Text="XX月YY日" />
        <asp:Button ID="DayBtn3" runat="server" Text="XX月YY日" />
        <asp:Button ID="DayBtn4" runat="server" Text="XX月YY日" />
        <asp:Button ID="GoBtn" runat="server" ForeColor="Red" Text="▶" />
        <br />
        
        <div>
        <p>
            <asp:Image ID="MovieImage" runat="server" />
            <asp:Label ID="TitleLabel" runat="server" Text="映画タイトル"></asp:Label>
            <asp:LinkButton ID="DetailsLinkBtn" runat="server">作品詳細</asp:LinkButton>
        </p>
        <asp:Label ID="ScreenLabel" runat="server" Text="スクリーン名"></asp:Label>
        <table border="0">
            <tr>
               <td class="auto-style1">
                   <table border="1">
                        <tr>
                            <td class="auto-style1">テーブル1</td>
                            <td class="auto-style1">テーブル2</td>
                            <td class="auto-style1">テーブル3</td>
                        </tr>
                            <tr>
                            <td class="auto-style1">テーブル4</td>
                            <td class="auto-style1">テーブル5</td>
                            <td class="auto-style1">テーブル6</td>
                        </tr>
                            <tr>
                            <td class="auto-style1">テーブル7</td>
                            <td class="auto-style1">テーブル8</td>
                            <td class="auto-style1">テーブル9</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Button ID="TimeBtn" runat="server" Text="上映時間" />

        </div>
    </form>
</body>
</html>
