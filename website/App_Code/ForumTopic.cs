using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Holds information about a forum topic
/// </summary>
public class ForumTopic
{
    public int ID;
    public String title;
    public String createdBy;
    public DateTime createdOnDate;

	public ForumTopic(int ID, String title, String createdBy, DateTime createdOnDate)
	{
        this.ID = ID;
        this.title = title;
        this.createdBy = createdBy;
        this.createdOnDate = createdOnDate;
	}

    public ForumTopic()
    {

    }
}