using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// holds a complete forum post with all comments
/// </summary>
public class ForumPost
{
    public ForumTopic topic;
    public List<Comment> comments;
	public ForumPost(ForumTopic topic, List<Comment> comments)
	{
        this.topic = topic;
        this.comments = comments;
	}

}