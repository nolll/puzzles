using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Puzzles
{
    public abstract class Event
    {
        public abstract int Year { get; }
        public abstract List<PuzzleDay> Days { get; }
        
        public PuzzleDay GetDay(int? selectedDay)
        {
            return selectedDay != null 
                ? Days.FirstOrDefault(o => o.Id == selectedDay.Value) 
                : Days.Last();
        }
    }
}