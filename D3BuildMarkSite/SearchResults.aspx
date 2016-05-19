<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="D3BuildMarkSite.SearchResults" %>

<%@ Register Src="~/Controls/ViewSearchResults.ascx" TagPrefix="uc1" TagName="ViewSearchResults" %>


<asp:Content ID="Content1" ContentPlaceHolderID="mpHead" runat="server">
    <title>Search Results</title>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="cHeader" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="cContent" runat="server">
    <uc1:ViewSearchResults runat="server" id="ViewSearchResults" />
</asp:Content>
<%--<asp:Content ID="Content4" ContentPlaceHolderID="cFooter" runat="server">
</asp:Content>--%>
