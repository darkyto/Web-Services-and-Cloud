namespace Task01.WeekDayService
{
    using System;
    using System.Globalization;

    public class WeekDay : IWeekDay
    {
        public string DayOfWeek(DateTime date)
        {
            if (date == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter");
            }
            var cultureBG = new CultureInfo("bg-BG");
            string dayOfWeek = cultureBG.DateTimeFormat.DayNames[(int)date.DayOfWeek];

            return dayOfWeek;
        }
    }
}
