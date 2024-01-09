using Helpers;

namespace CalendarServices
{
    public class DayOfWeekService
    {
        public void DisplayDayOfWeek(string _sy, string _sm, string _sd)
        {
            DateTime date = DateTimeExtensions.ReadDateFromConsole("", _sy, _sm, _sd);
            ConsoleWrapper.WriteLine(date.DayOfWeek);
        }
    }
}
