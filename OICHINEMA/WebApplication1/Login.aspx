<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" CssClass="AdmissionPanel" runat="server">        
        <asp:Label ID="Label2" CssClass="AdmissionText" runat="server" Text="入会申込"></asp:Label>
    </asp:Panel>
    <br />
    <div class="MenberInfoPanel">

        <asp:Panel ID="Panel2"　CssClass="FullNamePanel" runat="server">
            <asp:Label ID="Label3" CssClass="NameText" runat="server" Text="お名前（※）"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel5" CssClass="NameInPanel" runat="server">
            <asp:Panel ID="Panel1" CssClass="KanjiPanel" runat="server">
                <asp:Label ID="Label4" runat="server" Text="漢字"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" CssClass="TextBox" runat="server" Text="姓"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox3" runat="server" Text="名"></asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="Panel4" CssClass="KanaPanel" runat="server">
                <asp:Label ID="Label1" runat="server" Text="カナ"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" CssClass="TextBox" runat="server" Text="姓"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox4" runat="server" Text="名"></asp:TextBox>
            </asp:Panel>
        </asp:Panel>
        <br />
        <br />
        <br />

         <asp:Label ID="Label5" CssClass="NameText" runat="server" Text="性別（※）"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>




        <br />
        <asp:Label ID="Label6" CssClass="NameText" runat="server" Text="生年月日（※）"></asp:Label>







    </div>

</asp:Content>
