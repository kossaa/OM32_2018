<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Access.aspx.cs" Inherits="WebApplication1.Access" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label1" CssClass="AccessLabel" runat="server" Text="Label" Font-Size="50px">アクセス</asp:Label>
    </p>
    <asp:Panel CssClass="ImagePanel" runat="server">
        <asp:Image CssClass="AccessImage" runat="server" ImageUrl="~/Image/アクセス画像.jpg" Width="100%" BorderStyle="Solid"/>
    </asp:Panel>
    <asp:Panel CssClass="TextPanel" runat="server">
        <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="17px">
住所：543-0001　大阪市天王寺区上本町６-８-４ <br />
TEL：06-6772-2233　FAX：06-6772-1272<br />
<br />
阪神なんば線<br />
阪神本線・三宮、西宮、尼崎から大阪上本町まで直通<br />
※ 阪神尼崎～大阪上本町まで約20分<br />
<br />
JR「大阪」駅から<br />
環状線「鶴橋」駅下車、近鉄線（大阪線・奈良線）に乗り換え、「大阪上本町」駅下車、南へ約100m<br />
地下鉄谷町線「東梅田」駅から<br />
「谷町九丁目」駅下車、徒歩5分<br />
地下御堂筋線「梅田」駅から<br />
「なんば」駅下車、地下鉄千日前線に乗り換え。「谷町九丁目」駅下車、南東へ約100m</asp:Label>
    </asp:Panel>
</asp:Content>
