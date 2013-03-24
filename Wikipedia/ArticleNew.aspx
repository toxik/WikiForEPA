<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Site.Master" AutoEventWireup="true"
    CodeBehind="ArticleNew.aspx.cs" Inherits="Wikipedia.ArticleNew" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Name: <asp:TextBox runat="server" ID="ArticleName" />
        <asp:RequiredFieldValidator runat="server" ErrorMessage="Name cannot be blank" ControlToValidate="ArticleName" CssClass="error" />
    </p>
    <p>Content: <asp:TextBox runat="server" ID="ArticleContent" TextMode="MultiLine" /></p>
    <p><asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitClick" /></p>
</asp:Content>
