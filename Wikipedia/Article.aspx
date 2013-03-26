<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Site.Master" AutoEventWireup="true"
    CodeBehind="Article.aspx.cs" Inherits="Wikipedia.Article" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="ActionsContent" ContentPlaceHolderID="ActionsBar" runat="server">
    <span runat="server" id="EditAction" visible="false">
        <a runat="server" id="EditLink" href="">Edit</a>
    </span>
    <span runat="server" id="ProtectAction" visible="false">
        <span class="separator">|</span>
        <asp:LinkButton runat="server" ID="ProtectLink" OnClick="ProtectToggle">Protect</asp:LinkButton>
    </span>
    <span runat="server" id="VersionAction" visible="false">
        <span class="separator">|</span>
        <a runat="server" id="VersionsLinks" href="">Revision history</a>
    </span>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Label runat="server" ID="ArticleName" /></h1>
    <asp:Label runat="server" ID="ArticleContent" />
</asp:Content>
