using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class createAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<DateTime> dates = DatePicker.getDatesBeforeToday(256); //get 1 year of dates in the past
            foreach (DateTime date in dates)
            {
                ddlLastProgramDate.Items.Add(date.ToShortDateString()); //add them to the drop down list
                ddlCreatedOnDate.Items.Add(date.ToShortDateString());
            }
            txtUsername.Enabled = false;
            if (PreviousPage != null)
            {
                txtUsername.Text = PreviousPage.getUsername(); //get previous page information
               
            }
            else
            {
                getUserDetails(); //if previous page is not present, get logged in user details from db

            }
        }

        
    }
    //this method gets the user details for the logged in user and populates the controls on the page for display/editing
    private void getUserDetails()
    {
        LoggedInUser user = UserDao.getUserDetails(Security.getUserName()); //call to db access to get user details
        if (user.getUsername() != null)
        {
            txtUsername.Text = user.getUsername();
        }
        if (user.getCity() != null)
        {
            txtCity.Text = user.getCity();
        }
        if (user.getState() != null)
        {
            txtState.Text = user.getState();
        }
        if (user.getFavProgLang() != null)
        {
            txtFavProgrammingLanguage.Text = user.getFavProgLang();
        }
        if (user.getlastProgDate() != null)
        {
            txtLeastFavProgrammingLanguage.Text = user.getLeastFavProgLang();
        }
        if (user.getlastProgDate() != null)
        {
            ddlLastProgramDate.ClearSelection();
            ddlLastProgramDate.Items.FindByText(user.getlastProgDate().ToShortDateString()).Selected = true ;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e) //updates user info
    {
        String username = txtUsername.Text;
        String password = txtPassword.Text;
        String city = txtCity.Text;
        String state = txtState.Text;
        String favProgLang = txtFavProgrammingLanguage.Text; ;
        String leastFavProgLang = txtLeastFavProgrammingLanguage.Text;
        DateTime dateLastProgrammed = DateTime.Parse(ddlLastProgramDate.SelectedItem.Text);

        LoggedInUser user = new LoggedInUser(username, city, state, favProgLang, leastFavProgLang, dateLastProgrammed, password);

        bool updated = UserDao.updateAccount(user);

        if (updated)
        {
            lblMsg.Text = "User details updated!";
        }
        else
        {
            lblMsg.Text = "Sorry, there was an error. Please try again";
        }
        if (user.getPassword() != "")
        {
            PasswordManager passManager = new PasswordManager(user.getUsername(), user.getPassword());
            passManager.changePassword();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAddProgram_Click(object sender, EventArgs e)
    {
        String username = Security.getUserName();
        String language = txtLanguage.Text;
        String programName = txtProgramName.Text;

        DateTime createdOnDate = DateTime.Parse(ddlCreatedOnDate.SelectedItem.Text);
        bool success = ProgramsDao.addProgram(username, language, programName, createdOnDate);
        if (success)
        {
            GridView1.DataBind();
            txtLanguage.Text = "";
            txtProgramName.Text = "";
            ddlCreatedOnDate.ClearSelection();
            
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {   
        String username = Security.getUserName();
        bool success = UserDao.deleteAccount(username);
        if (success)
        {
            success = ProgramsDao.deletePrograms(username);
            if (success)
            {
                Security.logout();
            }
        }
    }
}