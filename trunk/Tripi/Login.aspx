<%@ Page Title="" Language="C#" MasterPageFile="~/OneColumnWithFooter.Master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div class="post">
        <p class="meta">
            Log in</p>
        <div class="entry">
            <div id="Div1">
                <asp:Login ID="LoginCtrl" runat="server" OnAuthenticate="AutenticateUser" 
                    DestinationPageUrl="~/Default.aspx" TitleText="">
                </asp:Login>
            </div>
        </div>
    </div>
</asp:Content>
