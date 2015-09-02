using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void WritePrograms_Click(object sender, EventArgs e)
    {
        try
        {
            List<UserPrograms> programs = ProgramsDao.getAllPrograms();
            foreach (UserPrograms p in programs)
            {
                ProgramsXmlWriter writer = new ProgramsXmlWriter(p);
                writer.writeXML();
            }
            lblmsg.Text = "User Programs successfully saved to the App_Data directory.";
        }
        catch (System.IO.IOException ex)
        {
            lblmsg.Text = "Sorry, there was an error, please try again.";
        }
    }
}