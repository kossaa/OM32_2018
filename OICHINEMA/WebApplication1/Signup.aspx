<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WebApplication1.Login" MaintainScrollPositionOnPostback="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
/*新規登録ページ
--------------------------------------------------------------------------------------------*/
    .MenberInfoPanel{
        margin-left:5%;
        margin-right:5%;
        margin-bottom:10%;
        height:100%;
    }
    .AdmissionPanel{
        width:100%;
        padding-top:10px;
        padding-bottom:10px;
    }
    .AdmissionText{
        margin-left:43%;
        text-align:center;
        font-size:30px;
    }
    .NameText{
        font-size:30px;
        width:100%;
        float:left;
    }
    .NameTextBox {
        width:85%;
        height:40px;
        font-size:30px;
        float:right;
    }
    .KanjiPanel{
        float:left;
        width:40%;
        clear:both;
    }
    .KanaPanel{
        float:right;
        width:60%;
    }
    .NameInPanel{
        width:100%;
    }
    .TextBox{
        width:200px;
        height:30px;
        font-size:30px;
    }
    .ADR1TextBox,.ADR2TextBox{
        width:400px;
        height:30px;
        font-size:30px;
    }
    .BirthTextBox{
        width:auto;
        height:30px;
        font-size:20px;
    }
    .SexPanel{
        width:100%;
    }
    .BirthPanel{
    }
    .AddressPanel{
    }

    .EnterButton{
        margin-bottom:20px;
        float:left;
        width:30%;
        height:30px;
        clear:both;

    }
        @media screen and (max-width: 1200px) {
            .TODOHUKEN, .CHOUSON-BANTI {
                clear: both;
            }
            .SI-KU-GUN {
                float: left;
                clear: both;
            }
            @media screen and (max-width: 620px){
                .KanaPanel{
                    float:left;
                    clear:both;
                }
                .KanjiPanel{
                    clear:both;
                }
                .SexPanel{
                    clear:both;
                }
            }
        }

    </style>
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
                <asp:TextBox ID="FNameTxb" CssClass="TextBox" runat="server" Text="姓名" AutoPostBack="True" MaxLength="50"></asp:TextBox>
                <br />
            </asp:Panel>
            <asp:Panel ID="Panel4" CssClass="KanaPanel" runat="server">
                <asp:Label ID="Label1" runat="server" Text="カナ"></asp:Label>
                <br />
                <asp:TextBox ID="FKanaTbx" CssClass="TextBox" runat="server" Text="セイメイ" TabIndex="1" MaxLength="70"></asp:TextBox>
                <br />
            </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="Panel6" CssClass="SexPanel" runat="server">
        <asp:Label ID="SexLbl" CssClass="NameText" runat="server" Text="性別（※）"></asp:Label>
        <asp:DropDownList ID="SexDDL" CssClass="BirthTextBox" runat="server" TabIndex="2">
            <asp:ListItem>男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:DropDownList>
    </asp:Panel>
    <asp:Panel ID="Panel7" CssClass="BirthPanel" runat="server">
        <asp:Label ID="BirthLbl" CssClass="NameText" runat="server" Text="生年月日（※）"></asp:Label>
        <asp:Label ID="Label7" runat="server" Text="（西暦）" Font-Size="30px"></asp:Label>
        <asp:DropDownList ID="YearDDL" CssClass="BirthTextBox" runat="server" TabIndex="3"></asp:DropDownList>
        <asp:Label ID="Label10" runat="server" Text="年" Font-Size="30px"></asp:Label>
        <asp:DropDownList ID="MonthDDL" CssClass="BirthTextBox" runat="server" OnSelectedIndexChanged="MonthDDL_SelectedIndexChanged" AutoPostBack="True" TabIndex="4" >
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
        <asp:DropDownList ID="DayDDL" CssClass="BirthTextBox" runat="server" TabIndex="5"></asp:DropDownList>
        <asp:Label ID="Label9" runat="server" Text="日" Font-Size="30px"></asp:Label>
    </asp:Panel>

    <asp:Panel ID="Panel2" CssClass="AddressPanel" runat="server">
        <asp:Label ID="Label11" CssClass="NameText" runat="server" Text="住所（※）"></asp:Label>
        <asp:Label ID="Label12" runat="server" Text="郵便番号（ハイフンなし）"></asp:Label>
            <br />
        <asp:TextBox ID="PostTxb" CssClass="TextBox" runat="server" TabIndex="6">0640941</asp:TextBox>
        <asp:Button ID="SerchBtn" type="button" runat="server" Text="検索" OnClick="SerchBtn_Click" TabIndex="7" />
            <br />

        <asp:Panel ID="Panel8" CssClass="TODOHUKEN" runat="server">
            <asp:Label ID="Label13" runat="server" Text="都道府県"></asp:Label>
                <br />
            <asp:TextBox ID="FADR1Txb" CssClass="ADR1TextBox" runat="server" TabIndex="8"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel9" CssClass="SI-KU-GUN" runat="server">
            <asp:Label ID="Label14" runat="server" Text="市区町村"></asp:Label>
                <br />
            <asp:TextBox ID="LADR1Txb" CssClass="ADR2TextBox" runat="server" TabIndex="9"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel10" CssClass="CHOUSON-BANTI" runat="server">
            <asp:Label ID="Label15" runat="server" Text="番地・建物名"></asp:Label>
                <br />
            <asp:TextBox ID="ADR2Txb" CssClass="TextBox" runat="server" TabIndex="10">9-2-5</asp:TextBox>
        </asp:Panel>
        <asp:Label ID="Label16" runat="server" Text="電話番号"></asp:Label>
            <br />
        <asp:TextBox ID="TELTxb" CssClass="TextBox" runat="server" TabIndex="11">11111111111</asp:TextBox>
            <br />
        <asp:Label ID="Label17" runat="server" Text="メールアドレス"></asp:Label>
            <br />
        <asp:TextBox ID="MailTxb" CssClass="TextBox" runat="server" TabIndex="12">aaaa@oic.jp</asp:TextBox>
                <br />
        <asp:Label ID="Label18" runat="server" Text="パスワード"></asp:Label>
            <br />
        <asp:TextBox ID="PassTxb" CssClass="TextBox" runat="server" TabIndex="13">abc</asp:TextBox>
        <br />
        <asp:Label ID="Label19" runat="server" Text="パスワード（確認）"></asp:Label>
            <br />
        <asp:TextBox ID="PassTxb2" CssClass="TextBox" runat="server" TextMode="Password" TabIndex="14">abc</asp:TextBox>
        <br />
        <br />
    </asp:Panel>



        <asp:Panel ID="Panel11" CssClass="EnterButton" runat="server">
        <asp:Button ID="EnterBtn" CssClass="EnterButton" runat="server" Text="確定" OnClick="EnterBtn_Click" TabIndex="15" />
        <asp:Label ID="messageLabel" runat="server" Text="Label" Visible="False" Font-Size="20px"></asp:Label>
        </asp:Panel>



    </div>

</asp:Content>
