using System;

delegate string TimeHandler(DateTime dt);

class TimeFormatter
{
    public string FormatTime(DateTime dt)
    {
        return dt.ToString("HH:mm:ss");
    }
}

class DateFormatter
{
    public string FormatDate(DateTime dt)
    {
        return dt.ToString("dd.MM.yyyy");
    }
}

class Program
{
    static void Main()
    {
        TimeFormatter timeFormatter = new TimeFormatter();
        DateFormatter dateFormatter = new DateFormatter();

        TimeHandler handler = timeFormatter.FormatTime;
        Console.WriteLine("Время: " + handler(DateTime.Now));

        handler = dateFormatter.FormatDate;
        Console.WriteLine("Дата: " + handler(DateTime.Now));
        Console.ReadKey();
    }
}