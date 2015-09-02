using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatePicker
/// </summary>
public class DatePicker
{
   
	public DatePicker()
	{
	}
    //returns a list of dates starting from today to <int days> back
    public static List<DateTime> getDatesBeforeToday(int days)
    {
        List<DateTime> dates = new List<DateTime>();
        DateTime date = System.DateTime.Now;
        dates.Add(date);

        for (int i = 0; i <= days; i++)
        {
            date = subtractOneDay(date);
            dates.Add(date);
        }

        return dates;
    }
    //subtracts one day from date
    private static DateTime subtractOneDay(DateTime date)
    {
        return date.AddDays(-1);

    }
}