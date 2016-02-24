﻿<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="D3BuildMarkSite.Users.AccountSettings" %>

<%@ Register Src="~/Controls/EditProfile.ascx" TagPrefix="uc1" TagName="EditProfile" %>


<%--<asp:Content ID="Content1" ContentPlaceHolderID="mpHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cHeader" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="cContent" runat="server">
    <link href="../styles/styles.css" rel="stylesheet" />
        <asp:LoginView ID="uxLoginView" runat="server">
            <AnonymousTemplate>
                <div id="account_settings">
                    <asp:literal ID="lblNotLoggedIn" Text="Not Logged In..." runat="server" />
                </div>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <div id="account_settings">
                    <asp:ChangePassword ID="uxChangePassword" MembershipProvider="SqlMembership" runat="server"/>
                    <br />
                    <uc1:EditProfile ID="uxEditProfile" runat="server" />
                </div>
                <div id="main_waiting">

                </div>
            </LoggedInTemplate>
        </asp:LoginView>
</asp:Content>
<%--<asp:Content ID="Content4" ContentPlaceHolderID="cFooter" runat="server">
</asp:Content>--%>
