<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="userManagement.aspx.cs" Inherits="userManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
            <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
            <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
            <asp:BoundField DataField="favProgrammingLang" HeaderText="favProgrammingLang" SortExpression="favProgrammingLang" />
            <asp:BoundField DataField="leastFavProgrammingLang" HeaderText="leastFavProgrammingLang" SortExpression="leastFavProgrammingLang" />
            <asp:BoundField DataField="lastProgramDate" HeaderText="lastProgramDate" SortExpression="lastProgramDate" />
            <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
            <asp:BoundField DataField="createdOnDate" HeaderText="createdOnDate" SortExpression="createdOnDate" />
            <asp:BoundField DataField="accessLevel" HeaderText="accessLevel" SortExpression="accessLevel" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\programaholics_anonymous_database.accdb" DeleteCommand="DELETE FROM [users] WHERE (([username] = ?) OR ([username] IS NULL AND ? IS NULL)) AND (([city] = ?) OR ([city] IS NULL AND ? IS NULL)) AND (([state] = ?) OR ([state] IS NULL AND ? IS NULL)) AND (([favProgrammingLang] = ?) OR ([favProgrammingLang] IS NULL AND ? IS NULL)) AND (([leastFavProgrammingLang] = ?) OR ([leastFavProgrammingLang] IS NULL AND ? IS NULL)) AND (([lastProgramDate] = ?) OR ([lastProgramDate] IS NULL AND ? IS NULL)) AND (([password] = ?) OR ([password] IS NULL AND ? IS NULL)) AND (([createdOnDate] = ?) OR ([createdOnDate] IS NULL AND ? IS NULL)) AND (([accessLevel] = ?) OR ([accessLevel] IS NULL AND ? IS NULL))" InsertCommand="INSERT INTO [users] ([username], [city], [state], [favProgrammingLang], [leastFavProgrammingLang], [lastProgramDate], [password], [createdOnDate], [accessLevel]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" ProviderName="System.Data.OleDb" SelectCommand="SELECT * FROM [users]" UpdateCommand="UPDATE [users] SET [city] = ?, [state] = ?, [favProgrammingLang] = ?, [leastFavProgrammingLang] = ?, [lastProgramDate] = ?, [password] = ?, [createdOnDate] = ?, [accessLevel] = ? WHERE (([username] = ?) OR ([username] IS NULL AND ? IS NULL)) AND (([city] = ?) OR ([city] IS NULL AND ? IS NULL)) AND (([state] = ?) OR ([state] IS NULL AND ? IS NULL)) AND (([favProgrammingLang] = ?) OR ([favProgrammingLang] IS NULL AND ? IS NULL)) AND (([leastFavProgrammingLang] = ?) OR ([leastFavProgrammingLang] IS NULL AND ? IS NULL)) AND (([lastProgramDate] = ?) OR ([lastProgramDate] IS NULL AND ? IS NULL)) AND (([password] = ?) OR ([password] IS NULL AND ? IS NULL)) AND (([createdOnDate] = ?) OR ([createdOnDate] IS NULL AND ? IS NULL)) AND (([accessLevel] = ?) OR ([accessLevel] IS NULL AND ? IS NULL))">
        <DeleteParameters>
            <asp:Parameter Name="original_username" Type="String" />
            <asp:Parameter Name="original_city" Type="String" />
            <asp:Parameter Name="original_city" Type="String" />
            <asp:Parameter Name="original_state" Type="String" />
            <asp:Parameter Name="original_state" Type="String" />
            <asp:Parameter Name="original_favProgrammingLang" Type="String" />
            <asp:Parameter Name="original_favProgrammingLang" Type="String" />
            <asp:Parameter Name="original_leastFavProgrammingLang" Type="String" />
            <asp:Parameter Name="original_leastFavProgrammingLang" Type="String" />
            <asp:Parameter Name="original_lastProgramDate" Type="DateTime" />
            <asp:Parameter Name="original_lastProgramDate" Type="DateTime" />
            <asp:Parameter Name="original_password" Type="Int32" />
            <asp:Parameter Name="original_password" Type="Int32" />
            <asp:Parameter Name="original_createdOnDate" Type="DateTime" />
            <asp:Parameter Name="original_createdOnDate" Type="DateTime" />
            <asp:Parameter Name="original_accessLevel" Type="Int32" />
            <asp:Parameter Name="original_accessLevel" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="username" Type="String" />
            <asp:Parameter Name="city" Type="String" />
            <asp:Parameter Name="state" Type="String" />
            <asp:Parameter Name="favProgrammingLang" Type="String" />
            <asp:Parameter Name="leastFavProgrammingLang" Type="String" />
            <asp:Parameter Name="lastProgramDate" Type="DateTime" />
            <asp:Parameter Name="password" Type="Int32" />
            <asp:Parameter Name="createdOnDate" Type="DateTime" />
            <asp:Parameter Name="accessLevel" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="city" Type="String" />
            <asp:Parameter Name="state" Type="String" />
            <asp:Parameter Name="favProgrammingLang" Type="String" />
            <asp:Parameter Name="leastFavProgrammingLang" Type="String" />
            <asp:Parameter Name="lastProgramDate" Type="DateTime" />
            <asp:Parameter Name="password" Type="Int32" />
            <asp:Parameter Name="createdOnDate" Type="DateTime" />
            <asp:Parameter Name="accessLevel" Type="Int32" />
            <asp:Parameter Name="original_username" Type="String" />
            <asp:Parameter Name="original_city" Type="String" />
            <asp:Parameter Name="original_city" Type="String" />
            <asp:Parameter Name="original_state" Type="String" />
            <asp:Parameter Name="original_state" Type="String" />
            <asp:Parameter Name="original_favProgrammingLang" Type="String" />
            <asp:Parameter Name="original_favProgrammingLang" Type="String" />
            <asp:Parameter Name="original_leastFavProgrammingLang" Type="String" />
            <asp:Parameter Name="original_leastFavProgrammingLang" Type="String" />
            <asp:Parameter Name="original_lastProgramDate" Type="DateTime" />
            <asp:Parameter Name="original_lastProgramDate" Type="DateTime" />
            <asp:Parameter Name="original_password" Type="Int32" />
            <asp:Parameter Name="original_password" Type="Int32" />
            <asp:Parameter Name="original_createdOnDate" Type="DateTime" />
            <asp:Parameter Name="original_createdOnDate" Type="DateTime" />
            <asp:Parameter Name="original_accessLevel" Type="Int32" />
            <asp:Parameter Name="original_accessLevel" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:Button ID="WritePrograms" Text="Write Programs" runat="server" OnClick="WritePrograms_Click" />
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>

