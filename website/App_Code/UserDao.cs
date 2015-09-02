using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.OleDb;

/// <summary>
/// Summary description for UserDao
/// </summary>
public class UserDao
{
    public UserDao()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    
    //This method adds a new username password combination to the database
    public static bool createAccount(Credentials newUser)
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



                String insert2 = "INSERT INTO [password]([password], [salt]) VALUES (@password, @salt)";
                cmd.Parameters.Clear();
                cmd.CommandText = insert2;
                cmd.Parameters.Add("password", OleDbType.VarChar, 255).Value = newUser.getPassword();
                cmd.Parameters.Add("salt", OleDbType.VarChar, 255).Value = newUser.getSalt();
                cmd.Prepare();

                int rows1 = cmd.ExecuteNonQuery();

                String select = "SELECT LAST(ID) FROM [password]";
                cmd.Parameters.Clear();
                cmd.CommandText = select;
                cmd.Prepare();

                int ID = 0;
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ID = Convert.ToInt32(reader[ID]);
                }
                reader.Close();

                String insert = "INSERT INTO [users]([username], [accessLevel], [password], [createdOnDate]) VALUES (@username, 2, @password, @date)";
                cmd.CommandText = insert;
                cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = newUser.getUsername();
                cmd.Parameters.Add("password", OleDbType.Integer, 32).Value = ID;
                cmd.Parameters.Add("date", OleDbType.Date).Value = System.DateTime.Now;
                cmd.Prepare();

                int rows2 = cmd.ExecuteNonQuery();

                //check if all parts of transaction were successful
                if (rows1 == 1 && rows2 == 1)
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
    //this method returns credentials for a user
    public static Credentials getUserCredentials(string username)
    {
        Credentials userCredentials = null;
        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {
                sqlConn.Open();
                String select = "SELECT [users].username AS DBusername, [users].accessLevel AS DBAccessLevel, [password].password AS DBPassword, [password].salt AS DBSalt  FROM [users] INNER JOIN [password] on [password].ID = [users].password WHERE [users].username = @userName ORDER BY [users].username";
                OleDbCommand cmd = new OleDbCommand(select, sqlConn);
                cmd.Parameters.Add("userName", OleDbType.VarChar, 255).Value = username;

                cmd.Prepare();

                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    String dbusername = dr["DBusername"].ToString();
                    String dbaccessLevel = dr["DBAccessLevel"].ToString();
                    String dbpassword = dr["DBPassword"].ToString();
                    String dbsalt = dr["DBSalt"].ToString();

                    userCredentials = new Credentials(dbusername, dbpassword, dbsalt, dbaccessLevel);
                }

            }

            catch (OleDbException ex)
            {
                userCredentials = null;
            }
            finally
            {
                sqlConn.Close();

            }

            return userCredentials;
        }
    }
    //this method updates the user details.
    public static bool updateAccount(LoggedInUser user)
    {

        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {
                sqlConn.Open();

                OleDbCommand cmd = sqlConn.CreateCommand();
                OleDbTransaction transact = sqlConn.BeginTransaction(); //using a transaction incase something goes wrong...
                cmd.Transaction = transact;



                String update = "UPDATE [users] SET [city] = @city, [state] = @state, [favProgrammingLang] = @favProgLang, [leastFavProgrammingLang] = @leastFavProgLang, [lastProgramDate] = @dateLastProgrammed" +
                    " WHERE [username] = @username";
                
                cmd.CommandText = update; //update users table
                cmd.Parameters.Add("city", OleDbType.VarChar, 255).Value = user.getCity();
                cmd.Parameters.Add("state", OleDbType.VarChar, 255).Value = user.getState();
                cmd.Parameters.Add("favProgLang", OleDbType.VarChar, 255).Value = user.getFavProgLang();
                cmd.Parameters.Add("leastFavProgLang", OleDbType.VarChar, 255).Value = user.getLeastFavProgLang();
                cmd.Parameters.Add("dateLastProgrammed", OleDbType.Date).Value = user.getlastProgDate();
                cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = user.getUsername();
                cmd.Prepare();

                int rows1 = cmd.ExecuteNonQuery();

               

                if(rows1 == 1)
                {
                    transact.Commit();
                    return true;
                }
                else
                {
                    transact.Rollback();
                    return false;
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
        }            

    }

    public static bool changePassword(Credentials user)
    {

        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {
                sqlConn.Open();

                OleDbCommand cmd = sqlConn.CreateCommand();
                OleDbTransaction transact = sqlConn.BeginTransaction(); //using a transaction incase something goes wrong...         
                cmd.Transaction = transact;

                String update = "UPDATE [password] INNER JOIN [users] ON [users].password = [password].ID SET [password].[password] = @password, [password].[salt] = @salt WHERE [users].username = @username";
                cmd.CommandText = update;
                cmd.Parameters.Add("password", OleDbType.VarChar, 255).Value = user.getPassword();
                cmd.Parameters.Add("salt", OleDbType.VarChar, 255).Value = user.getSalt();
                cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = user.getUsername();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 1)
                {
                    transact.Commit();
                    return true;
                }
                else
                {
                    return false;
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

        }
    }
            

    //this method returns a LoggedInUser object populated with results of query. (only a single user)
    public static LoggedInUser getUserDetails(string username)
    {
        LoggedInUser user = null;
        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {
                sqlConn.Open();

                OleDbCommand cmd = sqlConn.CreateCommand();

                String select = "SELECT * FROM users WHERE [username] = @username";
                cmd.CommandText = select;
                cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = username;

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user = new LoggedInUser();
                    user.setUsername(reader["username"].ToString()); 
                    user.setCity(reader["city"].ToString());
                    user.setState(reader["state"].ToString());
                    user.setFavProgLang(reader["favProgrammingLang"].ToString());
                    user.setLeastFavProgLang(reader["leastFavProgrammingLang"].ToString());
                    user.setLastProgDate(DateTime.Parse(reader["lastProgramDate"].ToString()));
                    
                }

                reader.Close();
            }
            catch (OleDbException ex)
            {
                return user;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        return user;
    }

    public static bool deleteAccount(String username)
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



                String insert2 = "DELETE FROM [users] WHERE [username] = @username";
                cmd.Parameters.Clear();
                cmd.CommandText = insert2;
                cmd.Parameters.Add("username", OleDbType.VarChar, 255).Value = username;
                cmd.Prepare();

                int rows = cmd.ExecuteNonQuery();

               

                //check if all parts of transaction were successful
                if (rows == 1)
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
}