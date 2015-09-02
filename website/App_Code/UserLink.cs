using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// this class is used to hold information about links in the application
/// </summary>
public class UserLink
{
    private String path;
    private String textValue;

    public UserLink(String path, String textValue)
    {
        this.path = path;
        this.textValue = textValue;
    }

    public String getPath()
    {
        return path;
    }

    public String getTextValue()
    {
        return textValue;
    }

}