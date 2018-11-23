<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="WebApplication1.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <!-- CSS設定 -->
    <style type ="text/css" >
        .ChoiceSeat{background-color:gray}
        .FreeSeat{background-color:none}
        .SoldSeat{background-color:red}
        .labelScreen {
            margin-left: 10%;
            background-color: black;
            color: white;
            font: large;
            }
    </style>

    <br />
    <asp:Label ID="Label1" runat="server" Text="選択中の座席"></asp:Label>



    <br />
    <br />
   
    <asp:ImageButton ID="A01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    <asp:ImageButton ID="A15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
   
    <br />

	<asp:ImageButton ID="B01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="B16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>


    <br />
	<asp:ImageButton ID="C01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="C17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
			
	<br />
		
	<asp:ImageButton ID="D01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="D17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
		
	<br />	
		
	<asp:ImageButton ID="E01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="E17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>

    <br />

	<asp:ImageButton ID="F01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="F17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
   
    <br />

	<asp:ImageButton ID="G01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="G17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    
    <br />

	<asp:ImageButton ID="H01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="H18"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    
    <br />
    
	<asp:ImageButton ID="I01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="I18"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    
    <br />
    
	<asp:ImageButton ID="J01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="J18"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>

    <br />

	<asp:ImageButton ID="K01" 	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K02"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K03"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K04"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K05"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K06"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K07"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K08"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K09"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K10"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K11"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K12"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K13"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K14"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K15"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K16"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K17"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
	<asp:ImageButton ID="K18"	runat="server" ImageUrl="/img/isu.png" Width="30" Height="30" OnClick="ImageBtn_Click" CssClass="FreeSeat"/>
    
    <br />
    <br />

    &emsp;
    &emsp;
    &emsp;
    &emsp;
    &emsp;
    &emsp;

    <asp:Button ID="Button1" runat="server" Text="確定" Height="50px" Width="100px" OnClick="Button1_Click" />

    &emsp;
    &emsp;
    &emsp;
    &emsp;
    &emsp;
    &emsp;

    <asp:Button ID="Button2" runat="server" Text="戻る" Height="50px" Width="100px" OnClick="Button2_Click" /> 
    
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <br />

</asp:Content>
