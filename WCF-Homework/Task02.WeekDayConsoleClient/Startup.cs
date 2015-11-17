namespace Task02.WeekDayConsoleClient
{
    using System;
    using System.Globalization;
    using System.Threading;

    using DayServiceReference;

    public class Startup
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            var client = new WeekDayClient();
            Console.WriteLine("Днес е {0}!", client.DayOfWeek(DateTime.Now));
        }
    }
}
