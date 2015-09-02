<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Sign in or Create Account</h1>
    <div>
        <asp:Label ID="lblusername" Text="UserName:" runat="server"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblpassword" Text="Password: " runat="server"></asp:Label>
        <asp:TextBox ID="txtpassword" TextMode="Password" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Msg" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnSubmit" Text="Login" runat="server" CommandName="loginCmd()" CommandArgument="null" OnClick="btnSubmit_Click" />
        <asp:Button ID="btnCreateAccount" Text="Create Account" runat="server" OnClick="btnCreateAccount_Click" />
    </div>
</asp:Content>

