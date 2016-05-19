<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewBuildSnapshot.ascx.cs" Inherits="D3BuildMarkSite.Controls.uxBuildSnapshotView" %>

<link href="../styles/gui.css" rel="stylesheet" />
<link href="../styles/styles.css" rel="stylesheet" />
<script src="../jquery-1.12.0.js" type = 'text/javascript'></script>

<script type="text/javascript">
    function NeckAttributesOn() {
        var test = document.getElementById("<%=uxNeckAttributes.ClientID%>");
        test.style.display = "block";
    }
    function NeckAttributesOff() {
        var test = document.getElementById("<%=uxNeckAttributes.ClientID%>");
        test.style.display = "none";
    }

    function ShouldersAttributesOn() {
        var test = document.getElementById("<%=uxShouldersAttributes.ClientID%>");
        test.style.display = "block";
    }
    function ShouldersAttributesOff() {
        var test = document.getElementById("<%=uxShouldersAttributes.ClientID%>");
        test.style.display = "none";
    }

    function BracersAttributesOn() {
        var test = document.getElementById("<%=uxBracersAttributes.ClientID%>");
        test.style.display = "block";
    }
    function BracersAttributesOff() {
        var test = document.getElementById("<%=uxBracersAttributes.ClientID%>");
        test.style.display = "none";
    }

    function BeltAttributesOn() {
        var test = document.getElementById("<%=uxBeltAttributes.ClientID%>");
        test.style.display = "block";
    }
    function BeltAttributesOff() {
        var test = document.getElementById("<%=uxBeltAttributes.ClientID%>");
        test.style.display = "none";
    }

    function LeftRingAttributesOn() {
        var test = document.getElementById("<%=uxLeftRingAttributes.ClientID%>");
        test.style.display = "block";
    }
    function LeftRingAttributesOff() {
        var test = document.getElementById("<%=uxLeftRingAttributes.ClientID%>");
        test.style.display = "none";
    }

    function RightRingAttributesOn() {
        var test = document.getElementById("<%=uxRightRingAttributes.ClientID%>");
        test.style.display = "block";
    }
    function RightRingAttributesOff() {
        var test = document.getElementById("<%=uxRightRingAttributes.ClientID%>");
        test.style.display = "none";
    }

    function PantsAttributesOn() {
        var test = document.getElementById("<%=uxPantsAttributes.ClientID%>");
        test.style.display = "block";
    }
    function PantsAttributesOff() {
        var test = document.getElementById("<%=uxPantsAttributes.ClientID%>");
        test.style.display = "none";
    }

    function BootsAttributesOn() {
        var test = document.getElementById("<%=uxBootsAttributes.ClientID%>");
        test.style.display = "block";
    }
    function BootsAttributesOff() {
        var test = document.getElementById("<%=uxBootsAttributes.ClientID%>");
        test.style.display = "none";
    }

    function LeftHandAttributesOn() {
        var test = document.getElementById("<%=uxLeftHandAttributes.ClientID%>");
        test.style.display = "block";
    }
    function LeftHandAttributesOff() {
        var test = document.getElementById("<%=uxLeftHandAttributes.ClientID%>");
        test.style.display = "none";
    }

    function RightHandAttributesOn() {
        var test = document.getElementById("<%=uxRightHandAttributes.ClientID%>");
        test.style.display = "block";
    }
    function RightHandAttributesOff() {
        var test = document.getElementById("<%=uxRightHandAttributes.ClientID%>");
        test.style.display = "none";
    }

    function ChestAttributesOn() {
        var test = document.getElementById("<%=uxChestAttributes.ClientID%>");
        test.style.display = "block";
    }
    function ChestAttributesOff() {
        var test = document.getElementById("<%=uxChestAttributes.ClientID%>");
        test.style.display = "none";
    }

    function GlovesAttributesOn() {
        var test = document.getElementById("<%=uxGlovesAttributes.ClientID%>");
        test.style.display = "block";
    }
    function GlovesAttributesOff() {
        var test = document.getElementById("<%=uxGlovesAttributes.ClientID%>");
        test.style.display = "none";
    }

    function HeadAttributesOn() {
        var test = document.getElementById("<%=uxHeadAttributes.ClientID%>");
        test.style.display = "block";
    }
    function HeadAttributesOff() {
        var test = document.getElementById("<%=uxHeadAttributes.ClientID%>");
        test.style.display = "none";
    }
</script>

    <div class="snapshot_right">
        <div class="title">
            <asp:DropDownList ID="uxHeroName" runat="server" Font-Size="Large" AutoPostBack="True" OnSelectedIndexChanged="uxHeroName_SelectedIndexChanged" />
            <br />
            <asp:TextBox ID="uxBuildName" Text="" MaxLength="30" Visible="false" runat="server" />
            <asp:Label ID="lblBuildName" CssClass="buildtext" Text="Build Name" runat="server" />
            <br />
            <asp:Button ID="uxImportSnapshot" Text="Import" Visible="false" runat="server" OnClick="uxImportSnapshot_Click" />
            <asp:Button ID="uxDeleteSnapshot" Text="Delete" Visible="false"  runat="server" OnClick="uxDeleteSnapshot_Click" />
            <asp:Button ID="uxSaveBuildName" Text="Save" Visible="false" runat="server" OnClick="uxSaveBuildName_Click" />
            <asp:Button ID="uxEditBuildName" Text="Edit" Visible="false" OnClick="uxEditBuildName_Click" runat="server" />
            <br />
            <asp:Label ID="lblBy" CssClass="tagtext" Text="by " runat="server" />
            <asp:Label ID="lblBattletag" CssClass="tagtext" Text="battletag#0000" runat="server" />        
            <br />
        </div>

        <div class="images">
            <div class="item neck">
                <asp:Label ID="lblNeck" AssociatedControlID="uxNeckImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxNeckImage" CssClass="item_image" onmouseover="javascript:NeckAttributesOn()" onmouseout="javascript:NeckAttributesOff()" runat="server" />
            </div>
            <div class="item shoulders">
                <asp:Label ID="lblShoulders" AssociatedControlID="uxShouldersImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxShouldersImage" CssClass="item_image" onmouseover="javascript:ShouldersAttributesOn()" onmouseout="javascript:ShouldersAttributesOff()" runat="server" />
            </div>
            <div class="item bracers">
                <asp:Label ID="lblBracers" AssociatedControlID="uxBracersImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxBracersImage" CssClass="item_image" onmouseover="javascript:BracersAttributesOn()" onmouseout="javascript:BracersAttributesOff()" runat="server" />
            </div>
            <div class="item leftring">
                <asp:Label ID="lblLeftRing" AssociatedControlID="uxLeftRingImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxLeftRingImage" CssClass="item_image" onmouseover="javascript:LeftRingAttributesOn()" onmouseout="javascript:LeftRingAttributesOff()" runat="server" />
            </div>
            <div class="item rightring">
                <asp:Label ID="lblRightRing" AssociatedControlID="uxRightRingImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxRightRingImage" CssClass="item_image" onmouseover="javascript:RightRingAttributesOn()" onmouseout="javascript:RightRingAttributesOff()" runat="server" />
            </div>
            <div class="item pants">
                <asp:Label ID="lblPants" AssociatedControlID="uxPantsImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxPantsImage" CssClass="item_image" onmouseover="javascript:PantsAttributesOn()" onmouseout="javascript:PantsAttributesOff()" runat="server" />
            </div>
            <div class="item boots">
                <asp:Label ID="lblBoots" AssociatedControlID="uxBootsImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxBootsImage" CssClass="item_image" onmouseover="javascript:BootsAttributesOn()" onmouseout="javascript:BootsAttributesOff()" runat="server" />
            </div>
            <div class="item lefthand">
                <asp:Label ID="lblLeftHand" AssociatedControlID="uxLeftHandImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxLeftHandImage" CssClass="item_image" onmouseover="javascript:LeftHandAttributesOn()" onmouseout="javascript:LeftHandAttributesOff()" runat="server" />
            </div>
            <div class="item righthand">
                <asp:Label ID="lblRightHand" AssociatedControlID="uxRightHandImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxRightHandImage" CssClass="item_image" onmouseover="javascript:RightHandAttributesOn()" onmouseout="javascript:RightHandAttributesOff()" runat="server" />
            </div>
            <div class="item chest">
                <asp:Label ID="lblChest" AssociatedControlID="uxChestImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxChestImage" CssClass="item_image" onmouseover="javascript:ChestAttributesOn()" onmouseout="javascript:ChestAttributesOff()" runat="server" />
            </div>
            <div class="item belt">
                <asp:Label ID="lblBelt" AssociatedControlID="uxBeltImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxBeltImage" CssClass="item_image" onmouseover="javascript:BeltAttributesOn()" onmouseout="javascript:BeltAttributesOff()" runat="server" />
            </div>
            <div class="item gloves">
                <asp:Label ID="lblGloves" AssociatedControlID="uxGlovesImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxGlovesImage" CssClass="item_image" onmouseover="javascript:GlovesAttributesOn()" onmouseout="javascript:GlovesAttributesOff()" runat="server" />
            </div>
            <div class="item head">
                <asp:Label ID="lblHead" AssociatedControlID="uxHeadImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxHeadImage" CssClass="item_image" onmouseover="javascript:HeadAttributesOn()" onmouseout="javascript:HeadAttributesOff()" runat="server" />
            </div>
            <%--<div class="item_summary">--%>
            <asp:TextBox ID="uxNeckAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox neck_box" runat="server" />
            <asp:TextBox ID="uxShouldersAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox shoulders_box" runat="server" />
            <asp:TextBox ID="uxBracersAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox bracers_box" runat="server" />
            <asp:TextBox ID="uxBeltAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox belt_box" runat="server" />
            <asp:TextBox ID="uxLeftRingAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox leftring_box" runat="server" />
            <asp:TextBox ID="uxRightRingAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox rightring_box" runat="server" />
            <asp:TextBox ID="uxPantsAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox pants_box" runat="server" />
            <asp:TextBox ID="uxBootsAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox boots_box" runat="server" />
            <asp:TextBox ID="uxLeftHandAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox lefthand_box" runat="server" />
            <asp:TextBox ID="uxRightHandAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox righthand_box" runat="server" />
            <asp:TextBox ID="uxChestAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox chest_box" runat="server" />
            <asp:TextBox ID="uxGlovesAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox gloves_box" runat="server" />
            <asp:TextBox ID="uxHeadAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox head_box" runat="server" />
        <%--</div>--%>
        </div>
        <br />
        
        <div class="right">
            <div class="version">
                <asp:Label ID="lblVersion" Text="Build Snapshot" runat="server" />
                <asp:DropDownList ID="uxVersion" AutoPostBack="true" Width="100%" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="uxVersion_SelectedIndexChanged" />
            </div>
            <asp:Button ID="uxImportNewSnapshot" Text="Import" Visible="false" runat="server" OnClick="uxImportNewSnapshot_Click" />
        </div>

        
        <div class="left">
            <div class="attribute">
                <asp:Label ID="lblStrength" CssClass="textleft" AssociatedControlID="uxStrength" runat="server">Strength: </asp:Label>
                <asp:Label ID="uxStrength" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblDexterity" CssClass="textleft" AssociatedControlID="uxDexterity" runat="server">Dexterity: </asp:Label>
                <asp:Label ID="uxDexterity" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblIntelligence" CssClass="textleft" AssociatedControlID="uxIntelligence" runat="server">Intelligence: </asp:Label>
                <asp:Label ID="uxIntelligence" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblVitality" CssClass="textleft" AssociatedControlID="uxVitality" runat="server">Vitality: </asp:Label>
                <asp:Label ID="uxVitality" CssClass="textright" runat="server">0</asp:Label>
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
                <asp:Label ID="lblLife" CssClass="textleft" AssociatedControlID="uxLife" runat="server">Life: </asp:Label>
                <asp:Label ID="uxLife" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblBuildMarkSingle" CssClass="textleft" AssociatedControlID="uxBuildMarkSingle" runat="server">BuildMark (Single): </asp:Label>
                <asp:Label ID="uxBuildMarkSingle" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblBuildMarkMultiple" CssClass="textleft" AssociatedControlID="uxBuildMarkMultiple" runat="server">BuildMark (Multiple): </asp:Label>
                <asp:Label ID="uxBuildMarkMultiple" CssClass="textright" runat="server">0</asp:Label>
            </div>
        </div>

        
        <%--<div style="clear:both;"></div>--%>
    
    </div>
<%--</form>--%>
