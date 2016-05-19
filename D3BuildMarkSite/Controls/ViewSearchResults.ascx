<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSearchResults.ascx.cs" Inherits="D3BuildMarkSite.Controls.ViewSearchResults" %>
<%@ Register Src="~/Controls/ViewSearchResult.ascx" TagPrefix="uc1" TagName="ViewSearchResult" %>
<link href="../styles/styles.css" rel="stylesheet" />
<div class="searchresults">
    <asp:Label ID="lblSearchString" Text="Showing Results for " runat="server" />
    <br />
    <br />
    <asp:Label ID="lblHeroNames" CssClass="nametext" Text="Hero Names" runat="server" />
    <br />
    <asp:PlaceHolder ID="uxHeroNameResults" runat="server" />
    <br />
    <br />
    <asp:Label ID="lblClassNames" CssClass="nametext" Text="Classes" runat="server" />
    <br />
    <asp:PlaceHolder ID="uxClassResults" runat="server" />
    <br />
    <br />
    <asp:Label ID="lblBattletagResults" CssClass="nametext" Text="Battletags" runat="server" />
    <br />
    <asp:PlaceHolder ID="uxBattletagResults" runat="server" />
</div>
