<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uxBuildSnapshotView.ascx.cs" Inherits="D3BuildMarkSite.Controls.uxBuildSnapshotView" %>

<link href="../styles/gui.css" rel="stylesheet" />
<link href="../styles/styles.css" rel="stylesheet" />

<div class="snapshot">
    <div class="title">
        <asp:Label ID="lblBuildName" CssClass="nametext" Text="Build Name" runat="server" />
        <br />
        <asp:Label ID="lblBy" CssClass="tagtext" Text="by " runat="server" />
        <asp:Label ID="lblBattletag" CssClass="tagtext" Text="battletag#0000" runat="server" />        
        <br />
    </div>
    <div class="images">
        <div class="item neck">
            <asp:Label ID="lblNeck" AssociatedControlID="uxNeckImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxNeckImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item shoulders">
            <asp:Label ID="lblShoulders" AssociatedControlID="uxShouldersImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxShouldersImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item bracers">
            <asp:Label ID="lblBracers" AssociatedControlID="uxBracersImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxBracersImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item belt">
            <asp:Label ID="lblBelt" AssociatedControlID="uxBeltImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxBeltImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item leftring">
            <asp:Label ID="lblLeftRing" AssociatedControlID="uxLeftRingImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxLeftRingImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item rightring">
            <asp:Label ID="lblRightRing" AssociatedControlID="uxRightRingImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxRightRingImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item pants">
            <asp:Label ID="lblPants" AssociatedControlID="uxPantsImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxPantsImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item boots">
            <asp:Label ID="lblBoots" AssociatedControlID="uxBootsImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxBootsImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item lefthand">
            <asp:Label ID="lblLeftHand" AssociatedControlID="uxLeftHandImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxLeftHandImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item righthand">
            <asp:Label ID="lblRightHand" AssociatedControlID="uxRightHandImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxRightHandImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item chest">
            <asp:Label ID="lblChest" AssociatedControlID="uxChestImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxChestImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item gloves">
            <asp:Label ID="lblGloves" AssociatedControlID="uxGlovesImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxGlovesImage" CssClass="item_image" runat="server" />
        </div>
        <div class="item head">
            <asp:Label ID="lblHead" AssociatedControlID="uxHeadImage" Visible="false" runat="server">Empty</asp:Label>
            <asp:Image ID="uxHeadImage" CssClass="item_image" runat="server" />
        </div>
    </div>
    <br />

    <div class="left">
        <div class="attribute">
            <asp:Label ID="lblPrimaryAttribute" CssClass="textleft" AssociatedControlID="uxPrimaryAttribute" runat="server">PrimaryAtt: </asp:Label>
            <asp:Label ID="uxPrimaryAttribute" CssClass="textright" runat="server">0</asp:Label>
        </div>
        <div class="attribute">
            <asp:Label ID="lblDamage" CssClass="textleft" AssociatedControlID="uxDamage" runat="server">Damage: </asp:Label>
            <asp:Label ID="uxDamage" CssClass="textright" runat="server">0</asp:Label>
        </div>
        <div class="attribute">
            <asp:Label ID="lblToughness" CssClass="textleft" AssociatedControlID="uxToughness" runat="server">Toughness: </asp:Label>
            <asp:Label ID="uxToughness" CssClass="textright" runat="server">0</asp:Label>
        </div>
        <div class="attribute">
            <asp:Label ID="lblRecovery" CssClass="textleft" AssociatedControlID="uxRecovery" runat="server">Recovery: </asp:Label>
            <asp:Label ID="uxRecovery" CssClass="textright" runat="server">0</asp:Label>
        </div>
        <div class="attribute">
            <asp:Label ID="lblBuildMark" CssClass="textleft" AssociatedControlID="uxBuildMark" runat="server">BuildMark: </asp:Label>
            <asp:Label ID="uxBuildMark" CssClass="textright" runat="server">0</asp:Label>
        </div>
    </div>

    <div class="right">
        <div class="version">
            Version
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <div style="clear:both;"></div>
</div>

<div class="item_summary">
    <asp:TextBox ID="uxItemSummary" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox" runat="server" />
</div>