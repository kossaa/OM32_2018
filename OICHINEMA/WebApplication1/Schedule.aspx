<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" 
    Inherits="WebApplication1.WebForm1" MasterPageFile="~/OICHINEMA.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel2" runat="server" Height="72px">
            <asp:Button ID="Button1" runat="server" Height="70px" Text="◀" Width="150px" BorderStyle="Solid" />
            <asp:Button ID="Button2" runat="server" Height="70px" Text="〇〇月××日" Width="150px" BorderStyle="Solid" />
            <asp:Button ID="Button3" runat="server" Height="70px" Text="〇〇月××日" Width="150px" BorderStyle="Solid" />
            <asp:Button ID="Button4" runat="server" Height="70px" Text="〇〇月××日" Width="150px" BorderStyle="Solid" />
            <asp:Button ID="Button5" runat="server" Height="70px" Text="〇〇月××日" Width="150px" BorderStyle="Solid" />
            <asp:Button ID="Button6" runat="server" Height="70px" Text="▶" Width="150px" BorderStyle="Solid" />
        </asp:Panel>
    </asp:Panel>

    

<div id="a">
    <asp:Panel ID="Panel3" runat="server">
        <asp:Panel ID="PanelMName" CssClass="PanelMName" runat="server" >
                <asp:Label ID="Label1" CssClass="Label2" runat="server" Font-Size="20pt" ForeColor="Black" Text="映画タイトル"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="PanelSeet" CssClass="PalelSeet" runat="server" Height="255px">
            <asp:Table ID="Table1" runat="server" Height="255px" Width="400px" BorderStyle="Solid">
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
    </asp:Panel>
</div>
    

    <asp:Label ID="Label2" runat="server" ForeColor="Fuchsia" Text="//=====================//"></asp:Label>

    

    </asp:Content>
