using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Years;
using ConsoleApp.Years.Year2015;
using ConsoleApp.Years.Year2016;
using ConsoleApp.Years.Year2017;
using ConsoleApp.Years.Year2018;
using ConsoleApp.Years.Year2019;
using ConsoleApp.Years.Year2020;

namespace ConsoleApp
{
    public class DaySelector
    {
        private readonly IList<Event> _events = new List<Event>
        {
            new Event2015(),
            new Event2016(),
            new Event2017(),
            new Event2018(),
            new Event2019(),
            new Event2020(),
        };

        public Day GetDay(int? selectedYear, int? selectedDay)
        {
            var year = GetEvent(selectedYear);
            return year.GetDay(selectedDay);
        }

        private Event GetEvent(int? selectedYear)
        {
            if (selectedYear != null)
            {
                var year = _events.FirstOrDefault(o => o.Year == selectedYear.Value);
                return year ?? _events.Last();
            }

            return _events.Last();
        }
    }
}