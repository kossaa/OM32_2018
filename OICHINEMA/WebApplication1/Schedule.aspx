<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="WebApplication1.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- CSS設定 -->
    <style type="text/css">

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
    <asp:Label ID="LabelChoice" runat="server" Font-Size="20pt" Text="選択中の座席"></asp:Label>
    <br />
    <br />
    <asp:Label ID="LabelNumber1" runat="server" Height="30" style="text-align: center" Text="1" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber2" runat="server" Height="30" style="text-align: center" Text="2" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber3" runat="server" Height="30" style="text-align: center" Text="3" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber4" runat="server" Height="30" style="text-align: center" Text="4" Width="30"></asp:Label>
    <asp:Label ID="LabelVertical1" runat="server" Height="30" style="text-align: center" Text="  " Width="30"></asp:Label>
    <asp:Label ID="LabelNumber5" runat="server" Height="30" style="text-align: center" Text="5" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber6" runat="server" Height="30" style="text-align: center" Text="6" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber7" runat="server" Height="30" style="text-align: center" Text="7" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber8" runat="server" Height="30" style="text-align: center" Text="8" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber9" runat="server" Height="30" style="text-align: center" Text="9" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber10" runat="server" Height="30" style="text-align: center" Text="10" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber11" runat="server" Height="30" style="text-align: center" Text="11" Width="30"></asp:Label>
    <asp:Label ID="LabelVertical2" runat="server" Height="30" style="text-align: center" Text="  " Width="30"></asp:Label>
    <asp:Label ID="LabelNumber12" runat="server" Height="30" style="text-align: center" Text="12" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber13" runat="server" Height="30" style="text-align: center" Text="13" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber14" runat="server" Height="30" style="text-align: center" Text="14" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber15" runat="server" Height="30" style="text-align: center" Text="15" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber16" runat="server" Height="30" style="text-align: center" Text="16" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber17" runat="server" Height="30" style="text-align: center" Text="17" Width="30"></asp:Label>
    <asp:Label ID="LabelNumber18" runat="server" Height="30" style="text-align: center" Text="18" Width="30"></asp:Label>
    <br />
    
    <!--　計188席　-->

    <asp:ImageButton ID="A01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    
    <!--　　-->
    <asp:Image ID="ImageRoad1" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="A05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad2" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="A12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="A15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="B01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad3" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="B05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRpad4" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="B12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="B16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="C01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad5" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="C05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="Imageroad6" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="C12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="C17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="D01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad7" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="D05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad8" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="D12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="D17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="E01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad9" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="E05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad10" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="E12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="E17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="F01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad11" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="F05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad12" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="F12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="F17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="G01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad13" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="G05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad14" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="G12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="G17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:Image ID="ImageRoad15" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad16" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad17" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad18" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad19" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad20" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad21" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad22" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad23" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad24" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad25" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad26" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad27" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad28" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad29" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad30" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad31" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad32" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad33" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:Image ID="ImageRoad34" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <br />
    <asp:ImageButton ID="H01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad35" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="H05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad36" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="H12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="H18" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="I01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad37" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="I05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad38" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="I12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="I18" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="J01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad39" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="J05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad40" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="J12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="J18" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <asp:ImageButton ID="K01" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K02" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K03" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K04" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad41" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="K05" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K06" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K07" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K08" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K09" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K10" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K11" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:Image ID="ImageRoad42" runat="server" Height="30" ImageUrl="/Image/tuuro.png" Width="30" />
    <asp:ImageButton ID="K12" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K13" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K14" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K15" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K16" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K17" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <asp:ImageButton ID="K18" runat="server" CssClass="FreeSeat" Height="30" ImageUrl="/Image/isu.png" OnClick="ImageBtn_Click" Width="30" />
    <br />
    <br />
    &emsp;
    &emsp;
    &emsp;
    &emsp;
    &emsp;
    &emsp;        
    <asp:Button ID="BtnNext" runat="server" Height="50px" OnClick="BtnNext_Click" Text="次へ" Width="100px" />
    &emsp;
    &emsp;
    &emsp;
    &emsp;
    &emsp;
    &emsp;               
    <asp:Button ID="BtnBack" runat="server" Height="50px" OnClick="BtnBack_Click" Text="戻る" Width="100px" />
    <br />
    <br />
</asp:Content>
