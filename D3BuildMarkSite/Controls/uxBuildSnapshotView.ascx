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
        <div class="item head">
            Head: 
            <asp:Label ID="lblHead" AssociatedControlID="uxHeadImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxHeadImage" runat="server" />
        </div>
        <div class="item neck">
            Neck: 
            <asp:Label ID="lblNeck" AssociatedControlID="uxNeckImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxNeckImage" runat="server" />
        </div>
        <div class="item shoulders">
            Shoulders: 
            <asp:Label ID="lblShoulders" AssociatedControlID="uxShouldersImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxShouldersImage" runat="server" />
        </div>
        <div class="item gloves">
            Gloves: 
            <asp:Label ID="lblGloves" AssociatedControlID="uxGlovesImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxGlovesImage" runat="server" />
        </div>
        <div class="item chest">
            Chest: 
            <asp:Label ID="lblChest" AssociatedControlID="uxChestImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxChestImage" runat="server" />
        </div>
        <div class="item bracers">
            Bracers: 
            <asp:Label ID="lblBracers" AssociatedControlID="uxBracersImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxBracersImage" runat="server" />
        </div>
        <div class="item belt">
            Belt: 
            <asp:Label ID="lblBelt" AssociatedControlID="uxBeltImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxBeltImage" runat="server" />
        </div>
        <div class="item leftring">
            Left Ring: 
            <asp:Label ID="lblLeftRing" AssociatedControlID="uxLeftRingImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxLeftRingImage" runat="server" />
        </div>
        <div class="item rightring">
            Right Ring: 
            <asp:Label ID="lblRightRing" AssociatedControlID="uxRightRingImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxRightRingImage" runat="server" />
        </div>
        <div class="item pants">
            Pants: 
            <asp:Label ID="lblPants" AssociatedControlID="uxPantsImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxPantsImage" runat="server" />
        </div>
        <div class="item boots">
            Boots: 
            <asp:Label ID="lblBoots" AssociatedControlID="uxBootsImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxBootsImage" runat="server" />
        </div>
        <div class="item lefthand">
            Left Hand: 
            <asp:Label ID="lblLeftHand" AssociatedControlID="uxLeftHandImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxLeftHandImage" runat="server" />
        </div>
        <div class="item righthand">
            Right Hand: 
            <asp:Label ID="lblRightHand" AssociatedControlID="uxRightHandImage" runat="server">Empty</asp:Label>
            <asp:Image ID="uxRightHandImage" runat="server" />
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