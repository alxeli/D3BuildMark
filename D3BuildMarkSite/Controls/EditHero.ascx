<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditHero.ascx.cs" Inherits="D3BuildMarkSite.Controls.EditHero" %>

<link href="../styles/gui.css" rel="stylesheet" />
<link href="../styles/styles.css" rel="stylesheet" />

<%--<form>--%>
    <div class="edit_hero">
        <asp:Label ID="lblHeroClass" runat="server" />
        <asp:Button ID="uxAdd" Text="Add" runat="server" OnClick="uxAdd_Click" />
        <asp:Button ID="uxRemove" Text="Remove" runat="server" OnClick="uxRemove_Click" />
        <asp:LinkButton ID="uxHeroLink" runat="server" OnClick="uxHeroLink_Click" />
    </div>
<%--</form>--%>