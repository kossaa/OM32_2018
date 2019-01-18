<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Market.aspx.cs" Inherits="WebApplication1.Market" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">


        .title{
            padding-left:30%;
        }

        .title{
            padding-left:30%;
        }

        .table{
            display:table;
            table-layout:fixed;

        }
        .table {
  table-layout:auto;
  width:100%;
}

        .table{
            display:table;
            table-layout:fixed;

        }
        .div1{
           display:table-cell;
           vertical-align:middle;
           text-align:center;
           

        }

        .div1{
           display:table-cell;
           vertical-align:middle;
           text-align:center;
           

        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <asp:Label ID="Label1" runat="server" Font-Size="26" Text="販売"></asp:Label>
    </div>
    <div ;="" class="table">
        <div class="div1">
            <asp:Button ID="Button2" runat="server" BorderStyle="None" CssClass="sample1" Font-Size="18pt" OnClick="Button2_Click" Text="フード・ドリンク" />
            <asp:Button ID="Button3" runat="server" BorderStyle="None" CssClass="sample2" Font-Size="18pt" OnClick="Button3_Click" Text="前売りチケット" />
        </div>
    </div>
    <style>


        .title{
            padding-left:30%;
        }

        .table{
            display:table;
            table-layout:fixed;

        }
        .div1{
           display:table-cell;
           vertical-align:middle;
           text-align:center;
           

        }

        .sample1 {
            width:auto;
            margin-left:20%;
            margin-right:10%;
            text-decoration:underline;
        }

        .sample2 {
            width:auto;
            margin-right:auto;
            margin-right:auto;
            text-decoration:underline;
        }
    </style>
    <asp:Table ID="Table1" runat="server" CssClass="table" GridLines="Both" HorizontalAlign="Center" Width="1048px">
    </asp:Table>
</asp:Content>
