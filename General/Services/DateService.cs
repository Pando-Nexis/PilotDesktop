using Nager.Date;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotDesktop.General.Services
{
    public static class DateService
    {
        public static DateTime GetFirstMondayOfWeek(string weekString)
        {
            int.TryParse(weekString.Substring(1, 2), out var year);
            int.TryParse(weekString.Substring(3, 2), out var week);
            return GetFirstMondayOfWeek(year, week);
        }
        public static DateTime GetFirstMondayOfWeek(int year, int week)
        {
            var culture = new System.Globalization.CultureInfo("sv-SE");
            var date = Convert.ToDateTime("20" + year.ToString() + "-01-01");
            while (culture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) != week)
            {
                date = date.AddDays(1);
            }
            date = GetFirstMondayOfWeek(date);
            return date;
        }

        public static DateTime GetNextMonday(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(1);
            }
            return date;
        }
        public static DateTime GetFirstMondayOfWeek(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }
            return date;
        }

        public static int GetWeek(DateTime date)
        {
            var culture = new System.Globalization.CultureInfo("sv-SE");
            return culture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        public static string GetWeekString(DateTime date)
        {
            var value = GetWeek(date);
            if (value > 9)
                return GetWeek(date).ToString();
            else
                return "0" + GetWeek(date).ToString();


        }
        public static string GetYearWeekString(DateTime date)
        {
            if (date.Year == 1)
                date = DateTime.Parse("2001-01-01");
            var culture = new System.Globalization.CultureInfo("sv-SE");
            var weekString = string.Empty;
            weekString = culture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
            if (weekString.Length == 1)
                weekString = "0" + weekString;
            weekString = "w" + date.Year.ToString().Substring(2, 2) + weekString;
            return weekString;
        }
        public static string GetWeekDay(DateTime date)
        {
            var dayOfWeek = string.Empty;
            switch (date.DayOfWeek)
            {
                case (DayOfWeek.Monday):
                    dayOfWeek = "Måndag";
                    break;
                case (DayOfWeek.Tuesday):
                    dayOfWeek = "Tisdag";
                    break;
                case (DayOfWeek.Wednesday):
                    dayOfWeek = "Onsdag";
                    break;
                case (DayOfWeek.Thursday):
                    dayOfWeek = "Torsdag";
                    break;
                case (DayOfWeek.Friday):
                    dayOfWeek = "Fredag";
                    break;
                case (DayOfWeek.Saturday):
                    dayOfWeek = "Lördag";
                    break;
                case (DayOfWeek.Sunday):
                    dayOfWeek = "Söndag";
                    break;
            }
            return dayOfWeek;
        }

        public static string GetLastDayOfMonth(DateTime date)
        {
            var dateString = date.ToShortDateString();
            dateString = dateString.Substring(0, 7) + "-01";
            date = Convert.ToDateTime(dateString).AddMonths(1).AddDays(-1);
            return date.Date.ToShortDateString();
        }
        public static bool IsWoorkDay(DateTime date)
        {
            var culture = new System.Globalization.CultureInfo("sv-SE");
            var daystring = culture.DateTimeFormat.GetDayName(date.DayOfWeek) + " v." + culture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;

            }
            else if (DateSystem.IsPublicHoliday(date, CountryCode.SE))
            {
                return false;
            }
            return true;
        }
        public static Color WorkDayColor1()
        {
            string colorcode = "#FFF9F7F3";
            int argb = Int32.Parse(colorcode.Replace("#", ""), NumberStyles.HexNumber);
            return Color.FromArgb(argb);
        }
        public static Color WorkDayColor2()
        {
            string colorcode = "#FFF1F9FA";
            int argb = Int32.Parse(colorcode.Replace("#", ""), NumberStyles.HexNumber);
            return Color.FromArgb(argb);
        }
        public static Color NotWorkDayColor()
        {
            string colorcode = "#FFFDE7D6";
            int argb = Int32.Parse(colorcode.Replace("#", ""), NumberStyles.HexNumber);
            return Color.FromArgb(argb);

        }
    
    }
}
