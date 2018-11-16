<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Seat.aspx.cs" Inherits="WebApplication1.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <!-- CSS設定 -->
    <style type ="text/css" >
        .ChoiceSeat{background-color:gray}
        .FreeSeat{background-color:none}
        .SoldSeat{background-color:red}
    </style>

    <div>
        <asp:Label ID="Label1" runat="server" Text="選択中の席"></asp:Label>
        <br />
        <br />
  
        <asp:Table ID="Table1" runat="server" BorderColor="#3333CC" BorderWidth="1px" GridLines="Both">
        </asp:Table>
        &emsp;
        &emsp;   
        &emsp;
        &emsp;    
        <asp:Button ID="Button1" runat="server" Text="確定" Height="50px" Width="100px" OnClick="Button1_Click" />
        &emsp;
        &emsp;
        &emsp;
        &emsp;
        <asp:Button ID="Button2" runat="server" Text="戻る" Height="50px" Width="100px" OnClick="Button2_Click" /> 
        <br /> 
        <br /> 
        <br /> 
        <asp:Label ID="Label2" runat="server" Text="label2"></asp:Label>
        <br /> 
        <br /> 
        <asp:Label ID="Label3" runat="server" Text="label3"></asp:Label>
        
        <br />
        <br />
        <asp:Table ID="Table2" runat="server" CssClass="SoldSeat">
        </asp:Table>
        
    </div>
</asp:Content>
