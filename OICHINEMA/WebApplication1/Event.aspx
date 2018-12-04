
<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="WebApplication1.Event" %>




<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
    <style type="text/css">
       .auto-style7 {
           width: 182px;
           height: 51px;
           text-align: center;
       }
       .auto-style8 {
           width: 182px;
           height: 21px;
           text-align: center;
       }
       .auto-style9 {
           height: 21px;
       }
       .auto-style10 {
           width: 182px;
           height: 38px;
           text-align: center;
       }
       .auto-style11 {
           height: 38px;
       }
       .auto-style12 {
           width: 182px;
           height: 34px;
           text-align: center;
       }
       .auto-style13 {
           height: 34px;
       }
       .auto-style14 {
           height: 51px;
       }
       .auto-style16 {
           height: 31px;
           width: 182px;
       }
   </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="background-color: #FFFFFF">
                <asp:Label ID="Label11" runat="server" Font-Size="50pt" Text="イベント一覧"></asp:Label>
            </td>
        </tr>
    </table>

   <table style="width:100%;">
       <tr>
           <td class="auto-style16" style="background-color: #c0c0c0; font-size: x-large;">イベント開始日</td>
           <td style="background-color: #c0c0c0; font-size: x-large;"></td>
       </tr>
       <tr>
           <td class="auto-style7" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel1" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel1" runat="server"></asp:Label>
           </td>
           <td class="auto-style14" style="background-color: #FFFFE0">
               <asp:Label ID="NameLabel1" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label1" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel1" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label12" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel1" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td class="auto-style12" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel2" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel2" runat="server"></asp:Label>
           </td>
           <td class="auto-style13" style="background-color: #FFFFFF">
               <asp:Label ID="NameLabel2" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label2" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel2" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label13" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel2" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td class="auto-style8" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel3" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel3" runat="server"></asp:Label>
           </td>
           <td class="auto-style9" style="background-color: #FFFFE0">
               <asp:Label ID="NameLabel3" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label3" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel3" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label14" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel3" runat="server"></asp:Label>
           </td>
       </tr>
        <tr>
           <td class="auto-style8" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel4" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel4" runat="server"></asp:Label>
            </td>
           <td class="auto-style9" style="background-color: #FFFFFF">
               <asp:Label ID="NameLabel4" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label4" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel4" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label15" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel4" runat="server"></asp:Label>
            </td>
       </tr>
        <tr>
           <td class="auto-style8" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel5" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel5" runat="server"></asp:Label>
            </td>
           <td class="auto-style9" style="background-color: #FFFFE0">
               <asp:Label ID="NameLabel5" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label5" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel5" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label16" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel5" runat="server"></asp:Label>
            </td>
       </tr>
        <tr>
           <td class="auto-style8" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel6" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel6" runat="server"></asp:Label>
            </td>
           <td class="auto-style9" style="background-color: #FFFFFF">
               <asp:Label ID="NameLabel6" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label6" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel6" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label17" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel6" runat="server"></asp:Label>
            </td>
       </tr>
        <tr>
           <td class="auto-style8" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel7" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel7" runat="server"></asp:Label>
            </td>
           <td class="auto-style9" style="background-color: #FFFFE0">
               <asp:Label ID="NameLabel7" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label7" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel7" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label18" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel7" runat="server"></asp:Label>
            </td>
       </tr>
        <tr>
           <td class="auto-style10" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel8" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel8" runat="server"></asp:Label>
            </td>
           <td class="auto-style11" style="background-color: #FFFFFF">
               <asp:Label ID="NameLabel8" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label8" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel8" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label19" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel8" runat="server"></asp:Label>
            </td>
       </tr>
        <tr>
           <td class="auto-style10" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel9" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel9" runat="server"></asp:Label>
            </td>
           <td class="auto-style11" style="background-color: #FFFFE0">
               <asp:Label ID="NameLabel9" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label9" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel9" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label20" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel9" runat="server"></asp:Label>
            </td>
       </tr>
        <tr>
           <td class="auto-style12" style="background-color: #c0c0c0">
               <asp:Label ID="DayLabel10" runat="server" Font-Size="15pt"></asp:Label>
               <br />
               <asp:Label ID="WeekDayLabel10" runat="server"></asp:Label>
            </td>
           <td class="auto-style13" style="background-color: #FFFFFF">
               <asp:Label ID="NameLabel10" runat="server"></asp:Label>
               <br />
               <asp:Label ID="Label10" runat="server">　</asp:Label>
               <br />
               <asp:Label ID="DetailLabel10" runat="server" Width="500px"></asp:Label>
               <br />
               <asp:Label ID="Label21" runat="server"></asp:Label>
               <br />
               <asp:Label ID="PeriodLabel10" runat="server"></asp:Label>
            </td>
       </tr>

   </table>
</asp:Content>

