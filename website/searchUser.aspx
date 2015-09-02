<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchUser.aspx.cs" Inherits="searchUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Search Users</h1>
    <div>
        <asp:Label ID="lblSearch" Text="Search for users" runat="server"></asp:Label>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    </div>
    <div>
        <div>
            <asp:Label ID="lblUsername" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblCity" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblState" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblFavProgLang" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblLeastFavProgLang" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblLastProgDate" runat="server"></asp:Label>  
        </div>  
    </div>
        <div>
            <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" />
        </div>
</asp:Content>

