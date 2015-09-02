using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
           
            getNavLinks();
       
        
    }
    //get nav links from db
private void getNavLinks()
{
        String username = Security.getUserName();
       
             
        List<UserLink> links = LinksDao.getUserLinks(username);

        foreach(UserLink link in links){
            writeNavLink(link);
        }
}
    //add the nav links to the placeholder
    private void writeNavLink(UserLink link)
    {
       
        String element = "<a href='" + link.getPath() + "'><div class='nav-item'>" + link.getTextValue() + "</div></a>";
        LiteralControl userLink = new LiteralControl(element);
        
        PlaceHolder1.Controls.Add(userLink);

    }

   
    
}