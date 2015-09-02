<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="forums.aspx.cs" Inherits="forums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Welcome to the Forums. Be Kind and support your fellow Members!</h1>
    <p>Any rude comments will be deleted from the system!</p>
    <p>You must be logged in to make comments.</p>
    <h2><asp:Label ID="lblHeader" runat="server"></asp:Label></h2>
    <asp:PlaceHolder ID="topicsPlaceHolder" runat="server"></asp:PlaceHolder>
    <asp:Panel ID="CommentPanel"  Visible="false" runat="server">
        <asp:Label ID="lblComment" Text="Comment: " runat="server"></asp:Label>
        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:Button ID="btnComment" Text="Comment" runat="server" OnClick="btnComment_Click" />
    </asp:Panel>
    <asp:Panel ID="NewPostPanel" Visible="false" runat="server">
        <h2>Create new Post</h2>
        <div>
            <asp:Label ID="lblNewPost" Text="Post Title: " runat="server"></asp:Label>
            <asp:TextBox ID="txtNewPost" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblFirstComment" Text="First Comment: " runat="server"></asp:Label> 
            <asp:TextBox ID="txtFirstComment" runat="server" TextMode="MultiLine"></asp:TextBox>            
        </div>
        <asp:Button ID="btnNewPost" Text="New Post" runat="server" OnClick="btnNewPost_Click" />
    </asp:Panel>
</asp:Content>

