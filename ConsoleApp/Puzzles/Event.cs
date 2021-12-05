using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Puzzles
{
    public abstract class Event
    {
        public int Year { get; }
        public abstract IList<PuzzleDay> Days { get; }

        protected Event(int year)
        {
            Year = year;
        }

        public PuzzleDay GetDay(int? selectedDay)
        {
            return selectedDay != null 
                ? Days.FirstOrDefault(o => o.Id == selectedDay.Value) 
                : Days.Last();
        }
    }
}