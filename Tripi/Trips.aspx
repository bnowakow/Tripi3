<%@ Page Title="" Language="C#" MasterPageFile="~/OneColumnWithFooter.Master" AutoEventWireup="true"
    CodeFile="Trips.aspx.cs" Inherits="Trips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div class="post" style="width: 100%">
        <h2 class="title">
            <a href="#">Trips</a></h2>
        <p class="meta">
            from all users</p>
        <div class="entry">
            <div id="Div1">
                <form id="form2" style="height: 100%">
                <div style="height: 700px;">
                    <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                        width="100%" height="100%">
                        <param name="source" value="ClientBin/SilverlightShowcase.xap" />
                        <param name="onError" value="onSilverlightError" />
                        <param name="background" value="white" />
                        <param name="minRuntimeVersion" value="3.0.40818.0" />
                        <param name="autoUpgrade" value="true" />
                        <param name="initParams" value="userName=<%= Page.User.Identity.Name %>" />
                        
                        <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40818.0" style="text-decoration: none">
                            <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight"
                                style="border-style: none" />
                        </a>
                    </object>
                    <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px;
                        border: 0px"></iframe>
                </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
