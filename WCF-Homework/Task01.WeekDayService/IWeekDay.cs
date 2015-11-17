namespace Task01.WeekDayService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IWeekDay
    {
        [OperationContract]
        string DayOfWeek(DateTime date);
    }
}
