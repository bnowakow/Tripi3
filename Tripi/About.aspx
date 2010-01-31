<%@ Page Title="" Language="C#" MasterPageFile="~/OneColumnWithFooter.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Image ID="ImageGlobe" runat="server" Height="283px" 
        ImageUrl="~/images/globe.png" Width="312px" ImageAlign="Left" />   
    <h2 class="title">Autorzy</h2>
    <div class="entry">
    </div>
    Bartosz Nowakowski
    Emil Chludziński
    Joanna Ruth
</asp:Content>

