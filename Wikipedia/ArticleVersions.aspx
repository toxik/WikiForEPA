<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Site.Master" AutoEventWireup="true"
    CodeBehind="ArticleVersions.aspx.cs" Inherits="Wikipedia.ArticleVersions" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/GridView.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="Versions" AllowPaging="True" 
        AllowSorting="True" CellPadding="4" DataSourceID="Versions_EDS" 
        ForeColor="Black" GridLines="Vertical" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
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
    <asp:EntityDataSource runat="server" ID="Versions_EDS" 
        AutoGenerateWhereClause="True" ConnectionString="name=WikipediaEntities" 
        DefaultContainerName="WikipediaEntities" EnableDelete="True" 
        EnableFlattening="False" EntitySetName="Versions" OnDeleted="VersionDeleted">
        <WhereParameters>
            <asp:QueryStringParameter Name="ArticleId" QueryStringField="id" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
</asp:Content>
