<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" 
    Inherits="WebApplication1.WebForm1" MasterPageFile="~/OICHINEMA.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server">
        <div class="menu">
            <asp:Panel ID="Panel2" runat="server" Height="10%">
                <asp:Button ID="Button1" runat="server" Height="70px" Text="◀" Width="150px" BorderStyle="Solid" />
                <asp:Button ID="Button2" runat="server" Height="70px" Text="〇〇月××日" Width="150px" BorderStyle="Solid" />
                <asp:Button ID="Button3" runat="server" Height="70px" Text="〇〇月××日" Width="150px" BorderStyle="Solid" />
                <asp:Button ID="Button4" runat="server" Height="70px" Text="〇〇月××日" Width="150px" BorderStyle="Solid" />
                <asp:Button ID="Button5" runat="server" Height="70px" Text="〇〇月××日" Width="150px" BorderStyle="Solid" />
                <asp:Button ID="Button6" runat="server" Height="70px" Text="▶" Width="150px" BorderStyle="Solid" />
            </asp:Panel>
        </div>
    </asp:Panel>

    

<div id="a">
    <asp:Panel CssClass="MInfo" runat="server">
        <asp:Panel  CssClass="PanelMName" runat="server" Width ="25%" >
            <div class="MTitle">
                <asp:Label CssClass="MTitle" runat="server" Font-Size="20pt" ForeColor="Black" Text="映画タイトル"></asp:Label>
            </div>
        </asp:Panel>
        <div class="MSeet">
            <asp:Panel ID="PanelSeet" CssClass="PalelSeet" runat="server" Height="255px">
                <asp:Table CssClass="TSeet" runat="server" BorderStyle="Solid">
                    <asp:TableRow>
                        <asp:TableCell BackColor="YellowGreen"></asp:TableCell>
                        <asp:TableCell ></asp:TableCell>
                        <asp:TableCell BackColor="YellowGreen"></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell BackColor="YellowGreen"></asp:TableCell>
                        <asp:TableCell></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell BackColor="YellowGreen"></asp:TableCell>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell BackColor="YellowGreen"></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:Panel>
        </div>
    </asp:Panel>
</div>
    

    
    </asp:Content>
