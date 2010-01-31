<%@ Page Title="" Language="C#" MasterPageFile="~/OneColumnWithFooter.Master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div class="post">
        <h2 class="title">
            <a href="#">Authors</a></h2>
        <p class="meta">
        </p>
        <div class="entry">
            <div id="banner" style="float: left; width: 300px;">
                <img src="images/globe.png" alt="" style="width: 300px;" />
            </div>
            <div style="float: left; padding: 10px;">
                <strong>
                    <ul>
                        <li>Joanna Ruth</li>
                        <li>Emil Chludziński</li>
                        <li>Bartosz Nowakowski</li>
                    </ul>
                </strong>
            </div>
        </div>
    </div>
</asp:Content>
