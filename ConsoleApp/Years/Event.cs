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
            return selectedDay != null 
                ? Days.FirstOrDefault(o => o.Id == selectedDay.Value) 
                : Days.Last();
        }
    }
}