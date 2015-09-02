using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void updateTimer_Tick(object sender, EventArgs e)
    {
        Security.logout(); //wait 5 seconds, then log the user out of the system and redirect to index.aspx
    }
}