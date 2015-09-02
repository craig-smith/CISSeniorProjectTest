using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for ProgramsDao
/// </summary>
public class ProgramsDao
{
	public ProgramsDao()
	{
		
	}

    public static bool addProgram(string username, string language, string programName, DateTime createdOnDate)
    {
         Boolean created;
        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {
                sqlConn.Open();

                OleDbCommand cmd = sqlConn.CreateCommand();
                OleDbTransaction transact = sqlConn.BeginTransaction(); //useing a transaction because we need to update 2 tables in db
                cmd.Transaction = transact;



                String insert = "INSERT INTO [programs]([username], [programName], [language], [createdOnDate]) VALUES(@username, @programName, @language, @createdOnDate)" ;
                cmd.CommandText = insert;
                cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = username;
                cmd.Parameters.Add("programName", OleDbType.VarChar, 255).Value = programName;
                cmd.Parameters.Add("language", OleDbType.VarChar, 255).Value = language;
                cmd.Parameters.Add("createdOnDate", OleDbType.Date).Value = createdOnDate;
                cmd.Prepare();

                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    transact.Commit();
                    created = true;
                }
                else
                {
                    transact.Rollback(); //cancel transaction if unsuccessful
                    created = false;
                }
            }

            catch (OleDbException ex)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();

            }
            return created;
        }
    }

    public static bool deletePrograms(string username)
    {
        Boolean delete;
        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {
                sqlConn.Open();

                OleDbCommand cmd = sqlConn.CreateCommand();
                OleDbTransaction transact = sqlConn.BeginTransaction(); //useing a transaction because we need to update 2 tables in db
                cmd.Transaction = transact;



                String deleteString = "DELETE FROM [programs] WHERE [username] = @username";
                cmd.CommandText = deleteString;
                cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = username;
                
                cmd.Prepare();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 1)
                {
                    transact.Commit();
                    delete = true;
                }
                else
                {
                    transact.Rollback(); //cancel transaction if unsuccessful
                    delete = false;
                }
            }

            catch (OleDbException ex)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();

            }
            return delete;
        }
    }

    /**
     * this method returns a list of UserPrograms objects of every program in the system.
     * */
    public static List<UserPrograms> getAllPrograms()
    {
        List<UserPrograms> programs = new List<UserPrograms>();

        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {
                

                String query = "SELECT * FROM [programs] ORDER BY [username]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, sqlConn);
               ProgramsDataSet ds = new ProgramsDataSet();
               adapter.Fill(ds, "programs");
               DataTable table = new DataTable();
               table = ds.Tables["programs"];
               int i = 0;

               do
               {
                   DataRow dr = table.Rows[i]; //set current data row
                   List<Program> userPrograms = new List<Program>(); //new list for each user
                   String username = dr["username"].ToString(); //get current user

                   while (username == dr["username"].ToString()) //for each user create new Program and add to list of programs
                   { 
                       Program program = new Program();
                       program.username = dr["username"].ToString();
                       program.ID = Convert.ToInt32(dr["ID"].ToString());
                       program.language = dr["language"].ToString();
                       program.programName = dr["programName"].ToString();
                       program.createdOnDate = dr["createdOnDate"].ToString();
                       userPrograms.Add(program);
                       i++;
                       if (i < table.Rows.Count) //make sure we don't out of bounds error
                       {
                           dr = table.Rows[i]; //move to next data row
                       }
                       else
                       {
                           break; //break loop if gone over total data rows in table
                       }
                   }
                   UserPrograms thisUser = new UserPrograms(); //complets list of all programs for user
                   thisUser.username = username; //set username
                   thisUser.programs = userPrograms; //add all programs
                   programs.Add(thisUser); //add to all programs in system.
               } while (i < table.Rows.Count);
               
            }

            catch (OleDbException ex)
            {

            }
            finally
            {
                sqlConn.Close();

            }

            return programs;
        }
    }
}