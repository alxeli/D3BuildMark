<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.ascx.cs" Inherits="D3BuildMarkSite.Controls.EditProfile" %>
<%@ Register Src="~/Controls/EditHero.ascx" TagPrefix="uc1" TagName="EditHero" %>


<link href="../styles/gui.css" rel="stylesheet" />
<link href="../styles/styles.css" rel="stylesheet" />

<form>
    <div class="edit_profile">
        <div class="left_label">
            <asp:Label ID="lblUserName" AssociatedControlID="lblUserNameValue" Text="Username:" runat="server" />
            <br />
            <asp:Label ID="lblBattletag" AssociatedControlID="lblBattletagValue" Text="Battletag:" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblUpdateBattletag" AssociatedControlID="uxUpdateBattletag" Text="New Battletag:" runat="server" />
            <br />
            <asp:Button ID="uxSaveBattletag" CssClass="left_button" Text="Save Battletag" runat="server" OnClick="uxSaveBattletag_Click" />
            <br />
        </div>
        <div class="right_content">
            <asp:Label ID="lblUserNameValue" runat="server" />
            <br />
            <asp:Label ID="lblBattletagValue" runat="server" />
            <br />
            <br />
            <asp:TextBox ID="uxUpdateBattletag" runat="server" />
            <br />
            <asp:Button ID="uxCancelBattletag" CssClass="right_button" Text="Cancel" OnClick="uxCancelBattletag_Click" runat="server" />
            <br />
        </div>
        <div style="clear:both;"></div>
        <div class="left_heroes">
            <asp:Label ID="lblImportedHeroes" Text="Imported Heroes" CssClass="center_title" runat="server" />
            <br />
            <asp:PlaceHolder ID="uxImportedHeroesPlaceholder" runat="server" />
        </div>
        <div class="right_heroes">
            <asp:Label ID="lblOnlineHeroes" Text="Online Heroes" CssClass="center_title" runat="server" />
            <br />
            <asp:PlaceHolder ID="uxOnlineHeroesPlaceholder" runat="server" />
        </div>
        <div style="clear:both;"></div>
    </div>
</form>