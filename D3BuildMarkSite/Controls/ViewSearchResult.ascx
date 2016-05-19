<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSearchResult.ascx.cs" Inherits="D3BuildMarkSite.Controls.ViewSearchResult" %>

<link href="../styles/gui.css" rel="stylesheet" />
<link href="../styles/styles.css" rel="stylesheet" />

<div class="search_result">
    <asp:Label ID="lblBattletag" CssClass="battletag" runat="server" />
    <asp:Label ID="lblHeroClass" CssClass="heroname" runat="server" />
    <asp:LinkButton ID="uxHeroLink2" runat="server" OnClick="uxHeroLink2_Click" />
</div>