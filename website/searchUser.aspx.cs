using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class searchUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        resetLabels();//clear labels in case searched useer does not have some items filled
        String searchUser = txtSearch.Text;
        LoggedInUser user = UserDao.getUserDetails(searchUser); //call to get user info

        if (user != null) //populate controls if user was found
        {
            lblUsername.Text = "username: " + user.getUsername();
            lblCity.Text = "City: " + user.getCity();
            lblState.Text = "State: " + user.getState();
            lblFavProgLang.Text = "Faforite Programming Language : " + user.getFavProgLang();
            lblLeastFavProgLang.Text = "Least Favorite Programming Language: " +  user.getLeastFavProgLang();
            lblLastProgDate.Text = "Last Program Date: " + user.getlastProgDate().ToShortDateString();
        }
        else
        {
            lblUsername.Text = "No such user in the system"; //notify user that search failed
        }
    }

    private void resetLabels() //resets the controls on the page
    {
        lblUsername.Text = "";
        lblCity.Text = "";
        lblState.Text = "";
        lblFavProgLang.Text = "";
        lblLeastFavProgLang.Text = "";
        lblLastProgDate.Text = "";
    }
}