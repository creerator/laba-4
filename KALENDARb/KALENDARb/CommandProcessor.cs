using Helpers;
using CalendarServices;
using System.Runtime.Intrinsics.Arm;

namespace ProgramUtilities
{
    public static class CommandProcessor
    {
        private static readonly LeapYearService _leapYearService = new LeapYearService();
        private static readonly DateIntervalService _dateIntervalService = new DateIntervalService();
        private static readonly DayOfWeekService _dayOfWeekService = new DayOfWeekService();
        private static readonly SaveService _saveService = new SaveService();
        private static readonly LoadService _loadService = new LoadService();

        public static bool ProcessCommand(Dictionary<string, string> d)
        {
            //string command = ConsoleWrapper.ReadLine().Trim().ToLower();

            try
            {
                switch (d["command"])
                {
                    case "check":
                        _leapYearService.CheckLeapYear(d["year"]);
                        break;
                    case "calc":
                        _dateIntervalService.CalculateDateInterval(d["sy"], d["sm"], d["sd"], d["ey"], d["em"], d["ed"]);
                        break;
                    case "day":
                        _dayOfWeekService.DisplayDayOfWeek(d["sy"], d["sm"], d["sd"]);
                        break;
                    case "save":
                        _saveService.Save(d["type"]);
                        break;
                    case "load":
                        _loadService.Load(d["type"], int.Parse(d["n"]));
                        break;
                    case "show":
                        _loadService.ShowFiles(d["type"]);
                        break;
                    case "quit":
                        return false;
                    default:
                        ConsoleWrapper.WriteLine(Literals.unknow_command);
                        break;
                }
            }
            catch {
                return false;
            }

            return true;
        }
    }
}