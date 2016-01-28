<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="Buildview.aspx.cs" Inherits="D3BuildMarkSite.Buildview" %>

<%@ Register Src="~/Controls/uxBuildSnapshotView.ascx" TagPrefix="uc1" TagName="uxBuildSnapshotView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mpHead" runat="server">
    <title>Build Snapshot</title>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cHeader" runat="server">
</asp:Content>--%>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="cNav" runat="server">
</asp:Content>--%>
<asp:Content ID="Content4" ContentPlaceHolderID="cContent" runat="server">
    <uc1:uxBuildSnapshotView runat="server" id="uxBuildSnapshotView" />
</asp:Content>
<%--<asp:Content ID="Content5" ContentPlaceHolderID="cFooter" runat="server">
</asp:Content>--%>
