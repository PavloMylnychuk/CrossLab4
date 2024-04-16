internal class Date
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public Date(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    // Індексатор
    public Date this[int index]
    {
        get
        {
            DateTime currentDate = new DateTime(Year, Month, Day);
            if (index >= 0)
                return currentDate.AddDays(index);
            else
                return currentDate.AddDays(-index);
        }
    }

    // Перевантаження операторів
    public static bool operator !(Date date)
    {
        return DateTime.DaysInMonth(date.Year, date.Month) != date.Day;
    }

    public static bool operator true(Date date)
    {
        return date.Day == 1 && date.Month == 1;
    }

    public static bool operator false(Date date)
    {
        return !(date.Day == 1 && date.Month == 1);
    }

    public static bool operator &(Date date1, Date date2)
    {
        return date1.Day == date2.Day && date1.Month == date2.Month && date1.Year == date2.Year;
    }

    public static implicit operator string(Date date)
    {
        return $"{date.Day}.{date.Month}.{date.Year}";
    }

    public static implicit operator Date(string s)
    {
        string[] parts = s.Split('.');
        return new Date(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }
}
