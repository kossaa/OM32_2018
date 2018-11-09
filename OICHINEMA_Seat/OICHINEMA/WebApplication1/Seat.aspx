<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Seat.aspx.cs" Inherits="WebApplication1.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <!-- CSS設定 -->
    <style type ="text/css" >
        .SeatImg{background-color:gray}
        .SeatImg2{background-color:none}
    </style>

    <div>
  
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
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <br />    
    </div>
</asp:Content>
