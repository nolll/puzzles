using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Events;
using ConsoleApp.Events.Event2019;

namespace ConsoleApp
{
    public class DaySelector
    {
        private readonly IList<Event> _events = new List<Event>
        {
            new Event2019()
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