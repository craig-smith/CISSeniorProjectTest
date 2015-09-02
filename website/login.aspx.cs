using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginCmd()
    {
        if (IsValid)
        {
            String username = txtUsername.Text;
            String password = txtpassword.Text;

            Security.login(username, password);

            setlblMsg();
        }
    }
    //this method creates a new account
    protected void createAccount()
    {
        if (IsValid)
        {
            String username = txtUsername.Text;
            String password = txtpassword.Text;

            if (Security.createNewUser(username, password)) //check if username is taken. If not, create account and log user in. Redirect to accountDetails page for user to update information
            {
                Security.login(username, password);
                Server.Transfer("~/accountDetails.aspx");
            }
            else
            {
                Msg.Text = "Sorry, that username already is taken. Please choose another."; //else display that username is taken
            }
        }
    }

    public String getUsername()
    {
        return txtUsername.Text;
    }

    public String getPassword()
    {
        return txtpassword.Text;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        loginCmd();
    }

    private void setlblMsg()
    {
        if (Security.getUserName() != null && Security.getUserName() != "anonymous")
        {
            //needed to load the correct links for the user
            Response.Redirect("accountDetails.aspx");
        }
        else
        {
            Msg.Text = "Sorry, There was an error with your credentials. Please try again."; //user provided incorrect credentials, try again
        }
    }
    protected void btnCreateAccount_Click(object sender, EventArgs e)
    {
        createAccount();
    }
}