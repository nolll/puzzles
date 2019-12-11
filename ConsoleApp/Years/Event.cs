using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Years
{
    public abstract class Event
    {
        public int Year { get; }
        protected abstract IList<Day> Days { get; }

        protected Event(int year)
        {
            Year = year;
        }

        public Day GetDay(int? selectedDay)
        {
            if (selectedDay != null)
            {
                if (selectedDay < Days.Count)
                    return Days[selectedDay.Value - 1];
                return null;
            }

            return Days.Last();
        }
    }
}