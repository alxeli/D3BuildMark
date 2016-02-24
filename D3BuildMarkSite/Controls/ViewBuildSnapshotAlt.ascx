<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewBuildSnapshotAlt.ascx.cs" Inherits="D3BuildMarkSite.Controls.ViewBuildSnapshotAlt" %>

<link href="../styles/gui.css" rel="stylesheet" />
<link href="../styles/styles.css" rel="stylesheet" />
<script src="../jquery-1.12.0.js" type = 'text/javascript'></script>

<script type="text/javascript">
    <%--function addLoadEvent(func) {
        var oldonload = window.onload;
        if (typeof window.onload != 'function') {
            window.onload = func;
        } else {
            window.onload = function () {
                if (oldonload) {
                    oldonload();
                }
                func();
            }
        }
    }
    addLoadEvent(HideAllAltAttributes);

    function HideAllAltAttributes() {
        document.getElementById("<%=uxAltNeckAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltShouldersAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltBracersAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltBeltAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltLeftRingAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltRightRingAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltPantsAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltBootsAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltLeftHandAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltRightHandAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltChestAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltGlovesAttributes.ClientID%>").style.display = "none";
        document.getElementById("<%=uxAltHeadAttributes.ClientID%>").style.display = "none";
    }--%>

    function NeckAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltNeckAttributes.ClientID%>");
        test.style.display = "block";
    }
    function NeckAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltNeckAttributes.ClientID%>");
        test.style.display = "none";
    }

    function ShouldersAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltShouldersAttributes.ClientID%>");
        test.style.display = "block";
    }
    function ShouldersAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltShouldersAttributes.ClientID%>");
        test.style.display = "none";
    }

    function BracersAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltBracersAttributes.ClientID%>");
        test.style.display = "block";
    }
    function BracersAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltBracersAttributes.ClientID%>");
        test.style.display = "none";
    }

    function BeltAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltBeltAttributes.ClientID%>");
        test.style.display = "block";
    }
    function BeltAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltBeltAttributes.ClientID%>");
        test.style.display = "none";
    }

    function LeftRingAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltLeftRingAttributes.ClientID%>");
        test.style.display = "block";
    }
    function LeftRingAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltLeftRingAttributes.ClientID%>");
        test.style.display = "none";
    }

    function RightRingAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltRightRingAttributes.ClientID%>");
        test.style.display = "block";
    }
    function RightRingAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltRightRingAttributes.ClientID%>");
        test.style.display = "none";
    }

    function PantsAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltPantsAttributes.ClientID%>");
        test.style.display = "block";
    }
    function PantsAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltPantsAttributes.ClientID%>");
        test.style.display = "none";
    }

    function BootsAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltBootsAttributes.ClientID%>");
        test.style.display = "block";
    }
    function BootsAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltBootsAttributes.ClientID%>");
        test.style.display = "none";
    }

    function LeftHandAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltLeftHandAttributes.ClientID%>");
        test.style.display = "block";
    }
    function LeftHandAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltLeftHandAttributes.ClientID%>");
        test.style.display = "none";
    }

    function RightHandAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltRightHandAttributes.ClientID%>");
        test.style.display = "block";
    }
    function RightHandAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltRightHandAttributes.ClientID%>");
        test.style.display = "none";
    }

    function ChestAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltChestAttributes.ClientID%>");
        test.style.display = "block";
    }
    function ChestAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltChestAttributes.ClientID%>");
        test.style.display = "none";
    }

    function GlovesAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltGlovesAttributes.ClientID%>");
        test.style.display = "block";
    }
    function GlovesAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltGlovesAttributes.ClientID%>");
        test.style.display = "none";
    }

    function HeadAttributesOnAlt() {
        var test = document.getElementById("<%=uxAltHeadAttributes.ClientID%>");
        test.style.display = "block";
    }
    function HeadAttributesOffAlt() {
        var test = document.getElementById("<%=uxAltHeadAttributes.ClientID%>");
        test.style.display = "none";
    }
</script>

<%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
<%--<form>--%>
    <div class="snapshot_left">
        <div class="title">
            <%--<asp:Label ID="lblHeroName" CssClass="nametext" Text="Hero Name" runat="server" />--%>
            <asp:DropDownList ID="uxAltHeroName" runat="server" Font-Size="Large" AutoPostBack="True" OnSelectedIndexChanged="uxAltHeroName_SelectedIndexChanged" />
            <br />
            <asp:TextBox ID="uxAltBuildName" Text="" MaxLength="30" Visible="false" runat="server" />
            <asp:Label ID="lblBuildName" CssClass="buildtext" Text="Build Name" runat="server" />
            <br />
            <asp:Button ID="uxAltImportSnapshot" Text="Import" Visible="false" runat="server" OnClick="uxAltImportSnapshot_Click" />
            <asp:Button ID="uxAltDeleteSnapshot" Text="Delete" Visible="false"  runat="server" OnClick="uxAltDeleteSnapshot_Click" />
            <asp:Button ID="uxAltSaveBuildName" Text="Save" Visible="false" runat="server" OnClick="uxAltSaveBuildName_Click" />
            <asp:Button ID="uxAltEditBuildName" Text="Edit" Visible="false" OnClick="uxAltEditBuildName_Click" runat="server" />
            <br />
            <asp:Label ID="lblBy" CssClass="tagtext" Text="by " runat="server" />
            <asp:Label ID="lblBattletag" CssClass="tagtext" Text="battletag#0000" runat="server" />        
            <br />
        </div>
        <div class="images">
            <div class="item neck">
                <asp:Label ID="lblNeck" AssociatedControlID="uxAltNeckImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltNeckImage" CssClass="item_image" onmouseover="javascript:NeckAttributesOnAlt()" onmouseout="javascript:NeckAttributesOffAlt()" runat="server" />
            </div>
            <div class="item shoulders">
                <asp:Label ID="lblShoulders" AssociatedControlID="uxAltShouldersImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltShouldersImage" CssClass="item_image" onmouseover="javascript:ShouldersAttributesOnAlt()" onmouseout="javascript:ShouldersAttributesOffAlt()" runat="server" />
            </div>
            <div class="item bracers">
                <asp:Label ID="lblBracers" AssociatedControlID="uxAltBracersImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltBracersImage" CssClass="item_image" onmouseover="javascript:BracersAttributesOnAlt()" onmouseout="javascript:BracersAttributesOffAlt()" runat="server" />
            </div>
            <div class="item leftring">
                <asp:Label ID="lblLeftRing" AssociatedControlID="uxAltLeftRingImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltLeftRingImage" CssClass="item_image" onmouseover="javascript:LeftRingAttributesOnAlt()" onmouseout="javascript:LeftRingAttributesOffAlt()" runat="server" />
            </div>
            <div class="item rightring">
                <asp:Label ID="lblRightRing" AssociatedControlID="uxAltRightRingImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltRightRingImage" CssClass="item_image" onmouseover="javascript:RightRingAttributesOnAlt()" onmouseout="javascript:RightRingAttributesOffAlt()" runat="server" />
            </div>
            <div class="item pants">
                <asp:Label ID="lblPants" AssociatedControlID="uxAltPantsImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltPantsImage" CssClass="item_image" onmouseover="javascript:PantsAttributesOnAlt()" onmouseout="javascript:PantsAttributesOffAlt()" runat="server" />
            </div>
            <div class="item boots">
                <asp:Label ID="lblBoots" AssociatedControlID="uxAltBootsImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltBootsImage" CssClass="item_image" onmouseover="javascript:BootsAttributesOnAlt()" onmouseout="javascript:BootsAttributesOffAlt()" runat="server" />
            </div>
            <div class="item lefthand">
                <asp:Label ID="lblLeftHand" AssociatedControlID="uxAltLeftHandImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltLeftHandImage" CssClass="item_image" onmouseover="javascript:LeftHandAttributesOnAlt()" onmouseout="javascript:LeftHandAttributesOffAlt()" runat="server" />
            </div>
            <div class="item righthand">
                <asp:Label ID="lblRightHand" AssociatedControlID="uxAltRightHandImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltRightHandImage" CssClass="item_image" onmouseover="javascript:RightHandAttributesOnAlt()" onmouseout="javascript:RightHandAttributesOffAlt()" runat="server" />
            </div>
            <div class="item chest">
                <asp:Label ID="lblChest" AssociatedControlID="uxAltChestImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltChestImage" CssClass="item_image" onmouseover="javascript:ChestAttributesOnAlt()" onmouseout="javascript:ChestAttributesOffAlt()" runat="server" />
            </div>
            <div class="item belt">
                <asp:Label ID="lblBelt" AssociatedControlID="uxAltBeltImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltBeltImage" CssClass="item_image" onmouseover="javascript:BeltAttributesOnAlt()" onmouseout="javascript:BeltAttributesOffAlt()" runat="server" />
            </div>
            <div class="item gloves">
                <asp:Label ID="lblGloves" AssociatedControlID="uxAltGlovesImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltGlovesImage" CssClass="item_image" onmouseover="javascript:GlovesAttributesOnAlt()" onmouseout="javascript:GlovesAttributesOffAlt()" runat="server" />
            </div>
            <div class="item head">
                <asp:Label ID="lblHead" AssociatedControlID="uxAltHeadImage" Visible="false" runat="server">Empty</asp:Label>
                <asp:Image ID="uxAltHeadImage" CssClass="item_image" onmouseover="javascript:HeadAttributesOnAlt()" onmouseout="javascript:HeadAttributesOffAlt()" runat="server" />
            </div>
            <%--<div class="item_summary">--%>
            <asp:TextBox ID="uxAltNeckAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox neck_box" runat="server" />
            <asp:TextBox ID="uxAltShouldersAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox shoulders_box" runat="server" />
            <asp:TextBox ID="uxAltBracersAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox bracers_box" runat="server" />
            <asp:TextBox ID="uxAltBeltAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox belt_box" runat="server" />
            <asp:TextBox ID="uxAltLeftRingAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox leftring_box" runat="server" />
            <asp:TextBox ID="uxAltRightRingAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox rightring_box" runat="server" />
            <asp:TextBox ID="uxAltPantsAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox pants_box" runat="server" />
            <asp:TextBox ID="uxAltBootsAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox boots_box" runat="server" />
            <asp:TextBox ID="uxAltLeftHandAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox lefthand_box" runat="server" />
            <asp:TextBox ID="uxAltRightHandAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox righthand_box" runat="server" />
            <asp:TextBox ID="uxAltChestAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox chest_box" runat="server" />
            <asp:TextBox ID="uxAltGlovesAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox gloves_box" runat="server" />
            <asp:TextBox ID="uxAltHeadAttributes" ReadOnly="true" TextMode="MultiLine" Text="" CssClass="big_textbox head_box" runat="server" />
        <%--</div>--%>
        </div>
        <br />

        <div class="left">
            <div class="attribute">
                <asp:Label ID="lblPrimaryAttribute" CssClass="textleft" AssociatedControlID="uxAltPrimaryAttribute" runat="server">PrimaryAtt: </asp:Label>
                <asp:Label ID="uxAltPrimaryAttribute" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblDamage" CssClass="textleft" AssociatedControlID="uxAltDamage" runat="server">Damage: </asp:Label>
                <asp:Label ID="uxAltDamage" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblToughness" CssClass="textleft" AssociatedControlID="uxAltToughness" runat="server">Toughness: </asp:Label>
                <asp:Label ID="uxAltToughness" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblRecovery" CssClass="textleft" AssociatedControlID="uxAltRecovery" runat="server">Recovery: </asp:Label>
                <asp:Label ID="uxAltRecovery" CssClass="textright" runat="server">0</asp:Label>
            </div>
            <div class="attribute">
                <asp:Label ID="lblBuildMark" CssClass="textleft" AssociatedControlID="uxAltBuildMark" runat="server">BuildMark: </asp:Label>
                <asp:Label ID="uxAltBuildMark" CssClass="textright" runat="server">0</asp:Label>
            </div>
        </div>

        <div class="right">
            <div class="version">
                <asp:Label ID="lblVersion" Text="Vers." runat="server" />
                <asp:DropDownList ID="uxAltVersion" AutoPostBack="true" Width="100%" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="uxAltVersion_SelectedIndexChanged" />
            </div>
            <asp:Button ID="uxAltImportNewSnapshot" Text="Import" Visible="false" runat="server" OnClick="uxAltImportNewSnapshot_Click" />
            <asp:Button ID="uxAltCompare" Text="Compare" Visible="true" runat="server" OnClick="uxAltCompare_Click" />
        </div>
        
        <%--<div style="clear:both;"></div>--%>
    
    </div>
<%--</form>--%>
