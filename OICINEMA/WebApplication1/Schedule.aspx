<%@ Page Title="" Language="C#" MasterPageFile="~/OICINEMA.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="WebApplication1.Schedule" %>
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
        <!--  -->
        .table1{
            border-color: red;
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
        <br />       
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>       
        <br />
        <br />
        <br />       
        <div >
            <!-- テーブル -->
            <asp:Table ID="Table1" runat="server" >
            </asp:Table>
        </div>
    </div>
</body>
</html>
</asp:Content>
