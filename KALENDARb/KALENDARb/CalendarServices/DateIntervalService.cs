using Helpers;

namespace CalendarServices
{
    public class DateIntervalService
    {
        public void CalculateDateInterval(string _sy, string _sm, string _sd, string _ey, string _em, string _ed)
        {
            DateTime startDate = DateTimeExtensions.ReadDateFromConsole(Literals.start_date, _sy, _sm, _sd);
            if (startDate == DateTime.MinValue) return;

            DateTime endDate = DateTimeExtensions.ReadDateFromConsole(Literals.end_date, _ey, _em, _ed);
            if (endDate == DateTime.MinValue) return;

            TimeSpan interval = endDate - startDate;
            ConsoleWrapper.WriteLine(String.Format(Literals.interval_length, interval.Days));
        }
    }
}
