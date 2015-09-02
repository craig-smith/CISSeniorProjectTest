using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class welcomeMsgControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //checking if user is logged in to set personalized message
        String username = Security.getUserName();
        if (username == "anonymous")
        {
            lblWelcomeMsg.Text = "Welcome to Programmers Anonymous. Sign in or Create your free account today!";
        }
        else
        {
            lblWelcomeMsg.Text = "Welcome back " + username;
        }
    }
}