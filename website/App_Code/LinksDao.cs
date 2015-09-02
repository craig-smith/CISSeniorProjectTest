using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

/*
 * this class is responsible for loading the gui links according to the logged in user
 * */
public class LinksDao
{
	public LinksDao()
	{
		
	}

    public static List<UserLink> getUserLinks(String username)
    {
        List<UserLink> links = new List<UserLink>(); //list to hold results of query

        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString; //connection string for db

        OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database); //db connection

        sqlConn.Open(); //connect to db

        //sql select string
        String select = "SELECT [links].path, [links].textValue FROM [links] INNER JOIN [users] ON [users].accessLevel = [links].accessLevel WHERE username = @username";

        OleDbCommand cmd = new OleDbCommand(select, sqlConn);

        //add parameters to command
        cmd.Parameters.Add("userName", OleDbType.VarChar, 255).Value = username;
        cmd.Prepare();
        
        //create data reader
        OleDbDataReader dr = cmd.ExecuteReader();

        //add results of query to links list
        while (dr.Read())
        {
            String path = dr["path"].ToString();
            String textValue = dr["textValue"].ToString();
            UserLink link = new UserLink(path, textValue);
            links.Add(link);
        }
        //close all resources and return list to calling method
        dr.Close();
        sqlConn.Close();
        return links;
    }
}