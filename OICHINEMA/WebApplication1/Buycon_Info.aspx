<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Buycon_Info.aspx.cs" Inherits="WebApplication1.Buycon_Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
    <tr>
        <td colspan="3" style="text-align: center">購入情報</td>
    </tr>
    <tr>
        <td rowspan="2">&nbsp;</td>
        <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="SCHEDULE_START" HeaderText="開始日時" SortExpression="SCHEDULE_START" />
                    <asp:BoundField DataField="SCHEDULE_END" HeaderText="終了日時" SortExpression="SCHEDULE_END" />
                    <asp:BoundField DataField="WORK_NAME" HeaderText="タイトル" SortExpression="WORK_NAME" />
                    <asp:BoundField DataField="SCREEN_ID" HeaderText="スクリーン" SortExpression="SCREEN_ID" />
                    <asp:BoundField DataField="SEAT_ID" HeaderText="座席" SortExpression="SEAT_ID" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [SCHEDULE_START], [SCHEDULE_END], [WORK_NAME], [SCREEN_ID], [SEAT_ID] FROM [Q_BUYCON] WHERE ([BOOKING_ID] = ?)">
                <SelectParameters>
                    <asp:SessionParameter Name="BOOKING_ID" SessionField="bookingid" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
        <td rowspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Back_btn" runat="server" OnClick="Back_btn_Click" Text="戻る" />
        </td>
    </tr>
    </table>
</asp:Content>
