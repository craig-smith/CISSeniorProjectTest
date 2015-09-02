using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class forums : System.Web.UI.Page
{
    private Forums forum;
    protected void Page_Load(object sender, EventArgs e)
    {
        forum = new Forums();
        if (Request["ID"] != null) //check if we have a post to load
        {
            loadForumPost();
        }
        else
        {
            loadAllTopics();
        }
       
    }

    private void loadAllTopics() //method to load all forum topics
    {
        List<ForumTopic> topics = forum.getAllTopics();
        lblHeader.Text = "All Posts";
        foreach (ForumTopic topic in topics)
        {
            String HTML = getTopicHTML(topic);
            LiteralControl forumTopic = new LiteralControl(HTML);
            topicsPlaceHolder.Controls.Add(forumTopic);
        }
        if (Security.getUserName() != "anonymous") //only show newPostPanel to logged in users
        {
            NewPostPanel.Visible = true;
        }
    }

    private void loadForumPost() //method to load a specific post
    {

        int id = Convert.ToInt32(Request["ID"]);
        ForumPost post = forum.getTopic(id);
        String postHTML = getPostHTML(post);
        LiteralControl forumPost = new LiteralControl(postHTML);
        lblHeader.Text = "Post created by " + post.topic.createdBy + " on " + post.topic.createdOnDate.ToShortDateString() + " at " + post.topic.createdOnDate.ToShortTimeString();
        topicsPlaceHolder.Controls.Add(forumPost);
        if (Security.getUserName() != "anonymous") //only show newCommentPanel to logged in users
        {
            CommentPanel.Visible = true;
        }
    }

    private string getTopicHTML(ForumTopic topic) //method to generate html for forum topics
    {
        String HTML = "<a href='/forums.aspx?ID="   + topic.ID + "'<h2>" + topic.title + "</h2></a></br>" ;
        return HTML;
    }

    private string getPostHTML(ForumPost post)
    {
        String HTML = "<h1>" + post.topic.title + "</h1>";
        List<Comment> comments = post.comments;
        foreach (Comment c in comments)
        {
            HTML += getCommentHTML(c);
        }

        return HTML;
    }

    private string getCommentHTML(Comment c) // method to write out html for a forum comment
    {
        String HTML = "<div class='forum_comment'>" + c.comment + "<p> Written by " + c.username + " on " + c.createdOnDate.ToShortDateString()  + " at " + c.createdOnDate.ToShortTimeString() + " </p> </div>";

        return HTML;
    }
    protected void btnComment_Click(object sender, EventArgs e) //click event for adding a comment to a post
    {
        Forums forums = new Forums();
        bool success = forums.addComment(Convert.ToInt32(Request["ID"]), Security.getUserName(), txtComment.Text);
        if (!success)
        {
            lblComment.Text = "Sorry, there was an error, please try again!";
        }
        else
        {
            topicsPlaceHolder.Controls.Clear();
            txtComment.Text = "";
            loadForumPost();
        }
    }
    protected void btnNewPost_Click(object sender, EventArgs e) //method to add a new forum topic
    {
        Forums forums = new Forums();
        bool success = forums.addPost(txtNewPost.Text, txtFirstComment.Text, Security.getUserName());
        if (success)
        {
            topicsPlaceHolder.Controls.Clear();
            loadAllTopics();
            txtFirstComment.Text = "";
            txtNewPost.Text = "";
        }
        else
        {
            lblNewPost.Text = "Sorry there was an error. Please try again.";
        }
    }
}