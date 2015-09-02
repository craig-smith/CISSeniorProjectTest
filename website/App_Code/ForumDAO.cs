using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// database object to access forum data tables
/// </summary>
public class ForumDAO
{
	public ForumDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /**
     * this mehtod load all fourm topics
     * */
    public List<ForumTopic> getAllTopics()
    {
        List<ForumTopic> topics = new List<ForumTopic>();
        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {
                

                String query = "SELECT * FROM [forum_topic] ORDER BY [createdOnDate]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, sqlConn);
                ForumTopicDataSet ds = new ForumTopicDataSet();
                adapter.Fill(ds, "forum_topic");
                DataTable table = ds.Tables["forum_topic"];

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    ForumTopic topic = new ForumTopic();
                    DataRow currentRow = table.Rows[i];
                    topic.ID = Convert.ToInt32(currentRow["ID"]);
                    topic.title = currentRow["title"].ToString();
                    topic.createdBy = currentRow["createdBy"].ToString();
                    topic.createdOnDate = DateTime.Parse(currentRow["createdOnDate"].ToString());

                    topics.Add(topic);
                }
               
            }
            catch (OleDbException ex)
            {

            }
            finally
            {
                sqlConn.Close();

            }
            return topics;
        }
    }
    /**
     * this method gets a specific forum post and all comments
     * 
     * */

    internal ForumPost getForumPost(int postID)
    {
        List<Comment> comments = new List<Comment>();
        ForumTopic topic = new ForumTopic();

        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {

                sqlConn.Open();
                OleDbCommand query = sqlConn.CreateCommand();
                String sql = "SELECT * FROM [forum_topic] WHERE [ID] = @ID";
                query.CommandText = sql;
                query.Parameters.Add("ID", OleDbType.Integer).Value = postID;

                query.Prepare();

                OleDbDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    topic.title = reader["title"].ToString();
                    topic.ID = Convert.ToInt32(reader["ID"]);
                    topic.createdBy = reader["createdBy"].ToString();
                    topic.createdOnDate = DateTime.Parse(reader["createdOnDate"].ToString());
                }
                reader.Close();
                sql = "SELECT * FROM [forum_comment] WHERE [forum_topic] = @ID ORDER BY [createdOnDate] ASC";
                query.CommandText = sql;
                query.Parameters.Clear();
                query.Parameters.Add("ID", OleDbType.Integer).Value = postID;
                query.Prepare();

                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    int ID = Convert.ToInt32(reader["ID"]);
                    String username = reader["username"].ToString();
                    String comment = reader["comment"].ToString();
                    int forum_topic = Convert.ToInt32(reader["forum_topic"]);
                    DateTime createdOnDate = DateTime.Parse(reader["createdOnDate"].ToString());

                    Comment userComment = new Comment(ID, username, comment, forum_topic, createdOnDate);
                    comments.Add(userComment);
                }

                

            }
            catch (OleDbException ex)
            {

            }
            finally
            {
                sqlConn.Close();

            }
            ForumPost post = new ForumPost(topic, comments);
            return post;
        }
    }

    //this method inserts a new comment to the db
    internal bool addComment(Comment comment)
    {
        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {

                sqlConn.Open();
                OleDbCommand query = sqlConn.CreateCommand();
                String sql = "INSERT INTO [forum_comment]([username], [comment], [forum_topic], [createdOnDate]) VALUES(@username, @comment, @forum_topic, @createdOnDate)";
                query.CommandText = sql;
                query.Parameters.Add("username", OleDbType.VarChar, 255).Value = comment.username;
                query.Parameters.Add("comment", OleDbType.VarChar, 255).Value = comment.comment;
                query.Parameters.Add("forum_topic", OleDbType.Integer).Value = comment.forumTopic;
                query.Parameters.Add("createdOnDate", OleDbType.Date).Value = comment.createdOnDate;

                query.Prepare();

                int rows = query.ExecuteNonQuery();
                if (rows > 0)
                {
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

    //this method inserts a new forum topic to the db
    internal int createNewTopic(ForumTopic topic)
    {
        int lastID;
        String database = System.Configuration.ConfigurationManager.ConnectionStrings["programaholics_anonymous_databaseConnectionString"].ConnectionString;
        using (OleDbConnection sqlConn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + database))
        {
            try
            {

                sqlConn.Open();
                OleDbCommand query = sqlConn.CreateCommand();
                String sql = "INSERT INTO [forum_topic]([createdBy], [title], [createdOnDate]) VALUES(@username, @title, @createdOnDate)";
                query.CommandText = sql;
                query.Parameters.Add("username", OleDbType.VarChar, 255).Value = topic.createdBy;
                query.Parameters.Add("title", OleDbType.VarChar, 255).Value = topic.title;                
                query.Parameters.Add("createdOnDate", OleDbType.Date).Value = topic.createdOnDate;

                query.Prepare();

                int rows = query.ExecuteNonQuery();
                if (rows > 0)
                {
                    sql = "Select @@Identity";
                    query.CommandText = sql;
                    lastID = (int)query.ExecuteScalar();
                    return lastID;
                }
                else
                {
                    return 0;
                }


            }
            catch (OleDbException ex)
            {
                return 0;
            }
            finally
            {
                sqlConn.Close();

            }
        }
    }
}