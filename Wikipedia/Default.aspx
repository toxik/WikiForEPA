<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Wikipedia._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent"> 
    <link href="Styles/Default.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ListView ID="Domains" runat="server" DataKeyNames="Id" 
        DataSourceID="Domains_EDS" GroupItemCount="3" >
        <EmptyDataTemplate>
            <table>
                <tr><td>No data was returned.</td></tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr ID="itemPlaceholderContainer" runat="server">
                <td ID="itemPlaceholder" runat="server" />
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td>
            <table class="domain">
            <tr><td class="domainheader">
                <h2><asp:Hyperlink ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' href='<%# "Domain.aspx?id=" + Eval("Id") %>' /></h2>
            </td></tr>
            <tr><td>
                <asp:ListView ID="LatestArticles" runat="server" DataSource='<%# Eval("LatestArticles") %>'>
                    <EmptyDataTemplate>
                        <p>No articles found</p>
                    </EmptyDataTemplate>
                    <EmptyItemTemplate>
                        <p>Empty Article</p>
                    </EmptyItemTemplate>
                    <ItemTemplate>
                        <li><a href='<%#"~/Article.aspx?id=" + Eval("Id") %>' runat="server"><%# Eval("Name") %></a></li>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <ul><li id="itemPlaceholder" runat="server" /></ul>
                    </LayoutTemplate>
                </asp:ListView>
                </td></tr>
            </table>
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table ID="groupPlaceholderContainer" runat="server">
                <tr ID="groupPlaceholder" runat="server"></tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:EntityDataSource ID="Domains_EDS" runat="server" AutoGenerateWhereClause="True"
        ConnectionString="name=WikipediaEntities" DefaultContainerName="WikipediaEntities"
        EnableFlattening="False" EntitySetName="Domains" 
        Include="Articles.Versions">
    </asp:EntityDataSource>
</asp:Content>
