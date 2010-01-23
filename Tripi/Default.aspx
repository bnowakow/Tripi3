<%@ Page Title="" Language="C#" MasterPageFile="~/TwoColumnsWithFooter.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" Runat="Server">
    Stachursky słucha Omgach.
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div class="post">
				<h2 class="title"><a href="#">Silverlight osadza się tu</a></h2>

				<p class="meta">srebrna strzała like mknie!</p>
				<div class="entry">
				
 <form id="form2" style="height:100%">
    <div id="silverlightControlHost">
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
		  <param name="source" value="ClientBin/SilverlightShowcase.xap"/>
		  <param name="onError" value="onSilverlightError" />
		  <param name="background" value="white" />
		  <param name="minRuntimeVersion" value="3.0.40818.0" />
		  <param name="autoUpgrade" value="true" />
		  <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40818.0" style="text-decoration:none">
 			  <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"/>
		  </a>
	    </object><iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe></div>
    </form>
    </div>
    </div>
	    
    <div id="banner"><img src="images/img07.jpg" alt="" /></div>
			<div class="post">
				<h2 class="title"><a href="#">Omgach Lorem ipsum dolor sit amet </a></h2>

				<p class="meta">Aliquam sit amet tempus sed consequat</p>
				<div class="entry">
					<p>This is <strong>EarthlingTwo</strong>, a free template by <a href="http://www.nodethirtythree.com">nodethirtythree</a> and <a href="http://www.freecsstemplates.org">Free CSS Templates</a>.  It’s kind of a sequel to an older template I did for FCT a long time ago named <a href="http://www.freecsstemplates.org/preview/earthling">Earthling</a>.</p>

					<p>This template is released under the <a href="http://creativecommons.org/licenses/by/3.0/">Creative Commons Attribution</a> license, so use it however you like, just keep the links back to our sites. The scenic photo above is a public domain work from <a href="http://www.pdphoto.org">PDPhoto.org</a>. Be sure to check out my other work at <a href="http://www.nodethirtythree.com/">my site</a> or follow me on <a href="http://twitter.com/nodethirtythree/">Twitter</a> for news and updates. Have fun.</p>
					<p class="links"><a href="#" class="more">Read More</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" class="comments">Comments (33)</a></p>

				</div>
			</div>
			<div style="clear: both;">&nbsp;</div>

</asp:Content>

