using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// holds info about forum comments
/// </summary>
public class Comment
{
    public int ID;
    public String username;
    public String comment;
    public int forumTopic;
    public DateTime createdOnDate;
	public Comment(int ID, String username, String comment, int forumTopic, DateTime createdOnDate)
	{
        this.ID = ID;
        this.username = username;
        this.comment = comment;
        this.forumTopic = forumTopic;
        this.createdOnDate = createdOnDate;
	}

    public Comment()
    {

    }
}