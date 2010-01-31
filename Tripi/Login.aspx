<%@ Page Title="" Language="C#" MasterPageFile="~/OneColumnWithFooter.Master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:Login ID="LoginCtrl" runat="server" OnAuthenticate="AutenticateUser" DestinationPageUrl="~/Default.aspx">
    </asp:Login>
</asp:Content>
