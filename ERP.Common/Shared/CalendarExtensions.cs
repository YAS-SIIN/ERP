

using System;
using System.Globalization;
using System.Linq;

namespace ERP.Common.Shared;

public static class CalendarExtensions 
{                    

    public static string ToPersianDate(this DateTime date, bool withClock = false, bool withPersianNumber = false)
    {
        if (date < Convert.ToDateTime("1960/01/01"))
            return "";
        PersianCalendar pc = new PersianCalendar();
        string year = pc.GetYear(date).ToString();
        string month = pc.GetMonth(date) >= 10 ? pc.GetMonth(date).ToString() : $"0{pc.GetMonth(date)}";
        string day = pc.GetDayOfMonth(date) >= 10 ? pc.GetDayOfMonth(date).ToString() : $"0{pc.GetDayOfMonth(date)}";
        string hour = pc.GetHour(date) >= 10 ? pc.GetHour(date).ToString() : $"0{pc.GetHour(date)}";
        string minute = pc.GetMinute(date) >= 10 ? pc.GetMinute(date).ToString() : $"0{pc.GetMinute(date)}";
        string second = pc.GetSecond(date) >= 10 ? pc.GetSecond(date).ToString() : $"0{pc.GetSecond(date)}";
        if (withPersianNumber)
        {
            year = year.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            month = month.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            day = day.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            hour = hour.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            minute = minute.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
            second = second.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
        }
        if (withClock)
            return $"{year}/{month}/{day} {hour}:{minute}:{second}";
        return $"{year}/{month}/{day}";
    }
    public static DateTime ToPersianDateTime(this DateTime date, bool withClock = false, bool withPersianNumber = false)
    {
        return DateTime.Parse(date.ToPersianDate(withClock, withPersianNumber));
    }
    public static DateTime ToGregorian(this string date, bool withClock = false)
    {
        if (string.IsNullOrEmpty(date))
            return(DateTime.Parse("0001-01-01"));
        PersianCalendar pc = new PersianCalendar();
        string englishNumber = date.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        var DateAndHour = englishNumber.Split(' ');
        var PersianDateArray = DateAndHour[0].Split('/');
        var SelectDate = PersianDateArray.Select(datePart => int.Parse(datePart)).ToArray();
        if (withClock)
        {
            if (DateAndHour.Count() > 1)
            {
                var PersianHourArray = DateAndHour[1].Split(':');
                var SelectHour = PersianHourArray.Select(datePart => int.Parse(datePart)).ToArray();
                return pc.ToDateTime(SelectDate[0], SelectDate[1], SelectDate[2], SelectHour[0], SelectHour[1], SelectHour[2], 0);
            }
        }
        return pc.ToDateTime(SelectDate[0], SelectDate[1], SelectDate[2], 0, 0, 0, 0);
    }
}
