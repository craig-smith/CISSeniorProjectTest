using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Security
/// </summary>
public class Security
{
	public Security()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //returns the username of the logged on user
    //if user is not logged in set username session variable to 'anonymous'
    public static String getUserName()
    {
        String username = null;
        if (HttpContext.Current.Session["username"] != null)
        {
            username = HttpContext.Current.Session["username"].ToString();
            return username;
        }
        else
        {
            HttpContext.Current.Session["username"] = "anonymous";
            username = "anonymous";
        }
        return username;
    }
    //log the user in
    public static void login(string username, string password)
    {
        PasswordManager passManager = new PasswordManager(username, password); //password manager uses hashing to check passwords
        if (passManager.checkPassword())
        {
            HttpContext.Current.Session["username"] = username;
           
        }
    }
    //this method checks that a user has access to the current url. If not, redirects to the index.aspx page
    public static void checkUrl()
    {
        String username = Security.getUserName();
        //get the current url
        char[] remove = { '/' }; //used to remove leading / from path to math values stored in db
        String currentUrl = HttpContext.Current.Request.CurrentExecutionFilePath.TrimStart(remove);
        
        //get allowed links
        List<UserLink> links = LinksDao.getUserLinks(username);
        //check if this link is in list
        int allowed = links.FindIndex(f => f.getPath() == currentUrl);

        //kick user if trying to access unallowed link
        if (allowed < 0)
        {
            HttpContext.Current.Response.Redirect("~/index.aspx");
        }
    }
    //kill the session and move the user back to index page
    public static void logout()
    {
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Response.Redirect("~/index.aspx");
    }

    public static bool createNewUser(string username, string password)
    {
        PasswordManager passManager = new PasswordManager(username, password);

        bool created = passManager.createNewAccount();

        return created;
    }
}