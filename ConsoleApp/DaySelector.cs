using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Days;

namespace ConsoleApp
{
    public class DaySelector
    {
        private readonly IList<Day> _days = new List<Day>
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
            new Day06(),
            new Day07(),
            new Day08(),
            new Day09()
        };

        public Day GetDay(int? selectedDay)
        {
            if (selectedDay != null)
            {
                if(selectedDay < _days.Count)
                    return _days[selectedDay.Value - 1];
                return null;
            }

            return _days.Last();
        }
    }
}