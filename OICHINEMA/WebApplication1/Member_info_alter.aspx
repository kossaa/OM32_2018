<%@ Page Title="" Language="C#" MasterPageFile="~/OICHINEMA.Master" AutoEventWireup="true" CodeBehind="Member_info_alter.aspx.cs" Inherits="WebApplication1.Member_info_alter1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContents" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Pagename_lbl" runat="server" Text="プロフィール変更"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="MEMBER_ID" DataSourceID="SqlDataSource1" Height="50px" Width="300px">
                    <Fields>
                        <asp:BoundField DataField="MEMBER_MAIL" HeaderText="ID(メールアドレス)" SortExpression="MEMBER_MAIL" />
                        <asp:TemplateField HeaderText="氏名" SortExpression="MEMBER_NAME">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MEMBER_NAME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MEMBER_NAME") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("MEMBER_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="フリガナ" SortExpression="MEMBER_KANA">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MEMBER_KANA") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MEMBER_KANA") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("MEMBER_KANA") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="性別" SortExpression="MEMBER_GENDER">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MEMBER_GENDER") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MEMBER_GENDER") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("MEMBER_GENDER") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="生年月日" SortExpression="MEMBER_BIRTH">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("MEMBER_BIRTH","{0:yyyy/MM/dd}") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("MEMBER_BIRTH", "{0:yyyy/MM/dd}") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("MEMBER_BIRTH", "{0:yyyy/MM/dd}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="郵便番号" SortExpression="MEMBER_POST">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("MEMBER_POST") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("MEMBER_POST") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("MEMBER_POST") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="住所" SortExpression="MEMBER_ADR">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("MEMBER_ADR") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("MEMBER_ADR") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("MEMBER_ADR") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="電話番号" SortExpression="MEMBER_TEL">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("MEMBER_TEL") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("MEMBER_TEL") %>'></asp:TextBox>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("MEMBER_TEL") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Button" DeleteText="" InsertText="" NewText="" SelectText="" ShowEditButton="True" />
                    </Fields>
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [MEMBER_ID], [MEMBER_NAME], [MEMBER_KANA], [MEMBER_GENDER], [MEMBER_BIRTH], [MEMBER_POST], [MEMBER_ADR], [MEMBER_TEL], [MEMBER_MAIL] FROM [TBL_MEMBER] WHERE ([MEMBER_ID] = ?)" UpdateCommand="UPDATE [TBL_MEMBER] SET [MEMBER_NAME] = ?, [MEMBER_KANA] = ?, [MEMBER_GENDER] = ?, [MEMBER_BIRTH] = ?, [MEMBER_POST] = ?, [MEMBER_ADR] = ?, [MEMBER_TEL] = ?, [MEMBER_MAIL] = ? WHERE ([MEMBER_ID] = ?)">
                    <SelectParameters>
                        <asp:SessionParameter Name="MEMBER_ID" SessionField="UserID" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
