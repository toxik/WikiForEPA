<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Site.Master" AutoEventWireup="true"
    CodeBehind="Domain.aspx.cs" Inherits="Wikipedia.Domain" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/GridView.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="ActionsContent" ContentPlaceHolderID="ActionsBar" runat="server">
    <span runat="server" id="NewAction" visible="false">
        <a runat="server" id="NewLink" href="">New</a>
    </span>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 runat="server" id="DomainName" visible="false"></h1>
    <asp:GridView runat="server" ID="ArticlesGridView" CellPadding="4"
        GridLines="Vertical" ForeColor="Black"
        AutoGenerateColumns="False" AllowSorting="True" OnSorting="GV_Sorting"
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
        BorderWidth="1px">
        <AlternatingRowStyle BackColor="LightGray" />
        <Columns>
            <asp:TemplateField HeaderText="Article Name" SortExpression="Name">
                <ItemTemplate>
                    <a runat="server" href='<%# "~/Article.aspx?id=" + Eval("Id") %>'><%# Eval ("Name") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UserName" HeaderText="Username"
                SortExpression="UserName" />
            <asp:CheckBoxField DataField="IsProtected" HeaderText="Protected"
                SortExpression="IsProtected" />
            <asp:BoundField DataField="CreateDate" HeaderText="Created"
                SortExpression="CreateDate" />
        </Columns>
        <EmptyDataTemplate>No Articles Found.</EmptyDataTemplate>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
</asp:Content>
