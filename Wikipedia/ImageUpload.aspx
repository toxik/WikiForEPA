<%@ Page Title="Wikipedia:Upload" Language="C#" MasterPageFile="~/Layouts/Site.Master" AutoEventWireup="true"
    CodeBehind="ImageUpload.aspx.cs" Inherits="Wikipedia.ImageUpload" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Image Upload</h1>
    <p><asp:FileUpload ID="File" runat="server" size="50" />
    <asp:Button ID="UploadButton" CssClass="btn" runat="server" Text="Upload" OnClick="UploadClick" /></p>
    <p>
        <asp:Label ID="Description" runat="server" Text="Label" Visible="False"></asp:Label>
        <br /><br />
        <asp:Label ID="Result" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
</asp:Content>
