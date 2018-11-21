<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel3" CssClass="AdmissionPanel" runat="server">        
        <asp:Label ID="Label2" CssClass="AdmissionText" runat="server" Text="入会申込"></asp:Label>
    </asp:Panel>
    <br />
    <div class="MenberInfoPanel">
        <asp:Panel ID="Panel5" CssClass="NameInPanel" runat="server">
                <asp:Label ID="Label3" CssClass="NameText" runat="server" Text="お名前（※）"></asp:Label>
                <asp:Panel ID="Panel1" CssClass="KanjiPanel" runat="server">
                <asp:Label ID="Label4" runat="server" Text="漢字"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox2" CssClass="TextBox" runat="server" Text="姓"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox3" CssClass="TextBox" runat="server" Text="名"></asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="Panel4" CssClass="KanaPanel" runat="server">
                <asp:Label ID="Label1" runat="server" Text="カナ"></asp:Label>
                <br />
                <asp:TextBox ID="TextBox1" CssClass="TextBox" runat="server" Text="セイ"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox4" CssClass="TextBox" runat="server" Text="メイ"></asp:TextBox>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="Panel6" CssClass="SexPanel" runat="server">
            <asp:Label ID="Label5" CssClass="NameText" runat="server" Text="性別（※）"></asp:Label>
            <asp:DropDownList ID="DropDownList1" CssClass="BirthTextBox" runat="server">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
        <asp:Panel ID="Panel7" CssClass="BirthPanel" runat="server">
            <asp:Label ID="Label6" CssClass="NameText" runat="server" Text="生年月日（※）"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text="（西暦）" Font-Size="30px"></asp:Label>
            <asp:DropDownList ID="DropDownList2" CssClass="BirthTextBox" runat="server" AutoPostBack="True"></asp:DropDownList>
            <asp:Label ID="Label10" runat="server" Text="年" Font-Size="30px"></asp:Label>
            <asp:DropDownList ID="DropDownList3" CssClass="BirthTextBox" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True" >
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label8" runat="server" Text="月" Font-Size="30px"></asp:Label>
            <asp:DropDownList ID="DropDownList4" CssClass="BirthTextBox" runat="server"></asp:DropDownList>
            <asp:Label ID="Label9" runat="server" Text="日" Font-Size="30px"></asp:Label>
        </asp:Panel>

        <asp:Panel ID="Panel2" CssClass="AddressPanel" runat="server">
            <asp:Label ID="Label11" CssClass="NameText" runat="server" Text="住所（※）"></asp:Label>
            <asp:Label ID="Label12" runat="server" Text="郵便番号（ハイフンなし）"></asp:Label>
                <br />
            <asp:TextBox ID="TextBox5" CssClass="TextBox" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="検索" OnClick="Button1_Click" />
                <br />

            <asp:Panel ID="Panel8" CssClass="TODOHUKEN" runat="server">
                <asp:Label ID="Label13" runat="server" Text="都道府県"></asp:Label>
                    <br />
                <asp:TextBox ID="TextBox6" CssClass="TextBox" runat="server"></asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="Panel9" CssClass="SI-KU-GUN" runat="server">
                <asp:Label ID="Label14" runat="server" Text="市区郡"></asp:Label>
                    <br />
                <asp:TextBox ID="TextBox7" CssClass="TextBox" runat="server"></asp:TextBox>
            </asp:Panel>
            <asp:Panel ID="Panel10" CssClass="CHOUSON-BANTI" runat="server">
                <asp:Label ID="Label15" runat="server" Text="町村・番地・建物名"></asp:Label>
                    <br />
                <asp:TextBox ID="TextBox8" CssClass="TextBox" runat="server"></asp:TextBox>
            </asp:Panel>
            <asp:Label ID="Label16" runat="server" Text="電話番号"></asp:Label>
                <br />
            <asp:TextBox ID="TextBox9" CssClass="TextBox" runat="server"></asp:TextBox>
                <br />
            <asp:Label ID="Label17" runat="server" Text="メールアドレス"></asp:Label>
                <br />
            <asp:TextBox ID="TextBox10" CssClass="TextBox" runat="server"></asp:TextBox>
                 <br />
            <asp:Label ID="Label18" runat="server" Text="パスワード"></asp:Label>
                <br />
            <asp:TextBox ID="TextBox11" CssClass="TextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label19" runat="server" Text="パスワード（確認）"></asp:Label>
                <br />
            <asp:TextBox ID="TextBox12" CssClass="TextBox" runat="server"></asp:TextBox>
        </asp:Panel>



        <asp:Panel ID="Panel11" runat="server">
        <asp:Button ID="Button2" CssClass="EnterButton" runat="server" Text="確定" OnClick="Button2_Click" />
        <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
        </asp:Panel>



    </div>

</asp:Content>
