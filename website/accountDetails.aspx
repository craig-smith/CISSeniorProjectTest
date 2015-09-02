<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="accountDetails.aspx.cs" Inherits="createAccount" %>
<%@ PreviousPageType VirtualPath="~/login.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function showAddProgram() {
            $("#add-program").removeClass("hidden");
            $("#add-program").css({ visibility: "visible", opacity: 0.0 });
            $("#add-program").fadeTo(1000, 1.0);
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Update Your Account Details</h1>
    <div>
        <asp:Label ID="lblUseranme" Text="Username:" runat="server"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" ValidationGroup="1"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblPassword" Text="Password:" runat="server"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="3"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblCity" Text="City:" runat="server"></asp:Label>
        <asp:TextBox ID="txtCity" runat="server" ValidationGroup="1"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblState" Text="State:" runat="server"></asp:Label>
        <asp:TextBox ID="txtState" runat="server" ValidationGroup="1"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblFavProgrammingLanguage" Text="Favorite Programming Language" runat="server"></asp:Label>
        <asp:TextBox ID="txtFavProgrammingLanguage" runat="server" ValidationGroup="1"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblLeastFavProgrammingLanguage" Text="Least Programming Language" runat="server"></asp:Label>
        <asp:TextBox ID="txtLeastFavProgrammingLanguage" runat="server" ValidationGroup="1"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblLastProgramDate" Text="Last Program Date" runat="server"></asp:Label>
        <asp:DropDownList ID="ddlLastProgramDate" runat="server" ValidationGroup="1"></asp:DropDownList>
    </div>
    <div>
        <asp:Button ID="btnUpdate" Text="Update Details" runat="server" OnClick="btnUpdate_Click" ValidationGroup="1" />
        <asp:Button ID="btnDelete" Text="Delete Account" runat="server" ValidationGroup="1" OnClick="btnDelete_Click" />
    </div>
    <div>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter all values!" ControlToValidate="txtUsername" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter all values!" ControlToValidate="txtCity" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must enter all values!" ControlToValidate="txtState" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must enter all values!" ControlToValidate="txtFavProgrammingLanguage" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="You must enter all values!" ControlToValidate="txtLeastFavProgrammingLanguage" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" Display="Dynamic" MaximumValue="25" MinimumValue="10" ValidationGroup="3" ControlToValidate="txtPassword"></asp:RangeValidator>
    </div>

    <div id="program-gridview">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                <asp:BoundField DataField="programName" HeaderText="programName" SortExpression="programName" />
                <asp:BoundField DataField="language" HeaderText="language" SortExpression="language" />
                <asp:BoundField DataField="createdOnDate" HeaderText="createdOnDate" SortExpression="createdOnDate" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\programaholics_anonymous_database.accdb" DeleteCommand="DELETE FROM [programs] WHERE [ID] = ? AND (([username] = ?) OR ([username] IS NULL AND ? IS NULL)) AND (([programName] = ?) OR ([programName] IS NULL AND ? IS NULL)) AND (([language] = ?) OR ([language] IS NULL AND ? IS NULL)) AND (([createdOnDate] = ?) OR ([createdOnDate] IS NULL AND ? IS NULL))" InsertCommand="INSERT INTO [programs] ([ID], [username], [programName], [language], [createdOnDate]) VALUES (?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" ProviderName="System.Data.OleDb" SelectCommand="SELECT * FROM [programs] WHERE ([username] = ?) ORDER BY [createdOnDate]" UpdateCommand="UPDATE [programs] SET [username] = ?, [programName] = ?, [language] = ?, [createdOnDate] = ? WHERE [ID] = ? AND (([username] = ?) OR ([username] IS NULL AND ? IS NULL)) AND (([programName] = ?) OR ([programName] IS NULL AND ? IS NULL)) AND (([language] = ?) OR ([language] IS NULL AND ? IS NULL)) AND (([createdOnDate] = ?) OR ([createdOnDate] IS NULL AND ? IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_username" Type="String" />
                <asp:Parameter Name="original_username" Type="String" />
                <asp:Parameter Name="original_programName" Type="String" />
                <asp:Parameter Name="original_programName" Type="String" />
                <asp:Parameter Name="original_language" Type="String" />
                <asp:Parameter Name="original_language" Type="String" />
                <asp:Parameter Name="original_createdOnDate" Type="DateTime" />
                <asp:Parameter Name="original_createdOnDate" Type="DateTime" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="programName" Type="String" />
                <asp:Parameter Name="language" Type="String" />
                <asp:Parameter Name="createdOnDate" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="username" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="programName" Type="String" />
                <asp:Parameter Name="language" Type="String" />
                <asp:Parameter Name="createdOnDate" Type="DateTime" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_username" Type="String" />
                <asp:Parameter Name="original_username" Type="String" />
                <asp:Parameter Name="original_programName" Type="String" />
                <asp:Parameter Name="original_programName" Type="String" />
                <asp:Parameter Name="original_language" Type="String" />
                <asp:Parameter Name="original_language" Type="String" />
                <asp:Parameter Name="original_createdOnDate" Type="DateTime" />
                <asp:Parameter Name="original_createdOnDate" Type="DateTime" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    <div>
        <br />
        <input type="button" onclick="showAddProgram()" value="Add Program"/>
    </div>
    <div id="add-program" class="hidden">
        <h2>Enter the program details</h2>
        <div>
            <asp:Label ID="lblProgramName" Text="Program Name: " runat="server"></asp:Label>
            <asp:TextBox ID="txtProgramName" runat="server" ValidationGroup="2"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblLanguage" Text="Language: " runat="server"></asp:Label>
            <asp:TextBox ID="txtLanguage" runat="server" ValidationGroup="2"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblCreatedOnDate" Text="Date Created" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlCreatedOnDate" runat="server" ValidationGroup="2"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btnAddProgram" Text="Submit Program" runat="server" OnClick="btnAddProgram_Click" ValidationGroup="2" />
        </div>
    </div>
</asp:Content>

