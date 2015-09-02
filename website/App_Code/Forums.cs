using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Business layer object for all logic behind the forums
/// </summary>
public class Forums
{
	public Forums()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //gets a forum post from the datalayer
    public ForumPost getTopic(int postID)
    {
        ForumDAO dataLayer = new ForumDAO();
        ForumPost post = dataLayer.getForumPost(postID);

        return post;
    }
    //gets all forum topics in database
    public List<ForumTopic> getAllTopics()
    {
        ForumDAO datalayer = new ForumDAO();
        List<ForumTopic> topics = datalayer.getAllTopics();

        return topics;
    }
    //adds a comment to a post
    public bool addComment(int postID, string username, string userComment)
    {
        Comment comment = new Comment();
        comment.forumTopic = postID;
        comment.username = username;
        comment.comment = userComment;
        comment.createdOnDate = DateTime.Now;

        ForumDAO dataLayer = new ForumDAO();
       bool success = dataLayer.addComment(comment);
       return success;
    }
    //adds a new post to db
    public bool addPost(string postTitle, string firstComment, string username)
    {
        ForumDAO dataLayer = new ForumDAO();
        ForumTopic topic = new ForumTopic();
        topic.createdBy = username;
        topic.createdOnDate = DateTime.Now;
        topic.title = postTitle;
        int topicID = dataLayer.createNewTopic(topic);

        Comment comment = new Comment();
        comment.comment = firstComment;
        comment.username = username;
        comment.createdOnDate = DateTime.Now;
        comment.forumTopic = topicID;
        bool success = dataLayer.addComment(comment);

        return success;
        
    }
}