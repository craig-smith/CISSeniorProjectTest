using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*
 * this class holds information about logged in users
 *  */
public class LoggedInUser
{ 
    private String username;
    private String city;
    private String state;
    private String favProgLang;
    private String leastFavProgLang;
    private DateTime lastProgDate;
    private String password;

    public LoggedInUser(String username, String city, String state, String favProgLang, String leastFavProgLang, DateTime lastProgDate, String password)
    {
        this.username = username;
        this.city = city;
        this.state = state;
        this.favProgLang = favProgLang;
        this.leastFavProgLang = leastFavProgLang;
        this.lastProgDate = lastProgDate;
        this.password = password;
    }
    public LoggedInUser()
    {

    }

    public String getUsername()
    {
        return username;

    }
    public void setUsername(String username)
    {
        this.username = username;

    }
    public String getCity()
    {
        return city;

    }
    public void setCity(String city)
    {
        this.city = city;   
    }
    public String getState()
    {
        return state;
    }
    public void setState(String state)
    {
        this.state = state;
    }
    public String getFavProgLang()
    {
        return favProgLang;
    }
    public void setFavProgLang(String favProgLang)
    {
        this.favProgLang = favProgLang;
    }
    public String getLeastFavProgLang()
    {
        return leastFavProgLang;
    }
    public void setLeastFavProgLang(String leastFavProgLang)
    {
        this.leastFavProgLang = leastFavProgLang;
    }
    public DateTime getlastProgDate()
    {
        return lastProgDate ;
    }
    public void setLastProgDate(DateTime lastProgDate)
    {
        this.lastProgDate = lastProgDate;
    }
    public String getPassword()
    {
        return password;
    }
    public void setPassword(String password)
    {
        this.password = password;
    }
}
