using System.Collections.Generic;
using System.Linq;
using Core.Platform;
using Core.Puzzles.Year2015;
using Core.Puzzles.Year2016;
using Core.Puzzles.Year2017;
using Core.Puzzles.Year2018;
using Core.Puzzles.Year2019;
using Core.Puzzles.Year2020;
using Core.Puzzles.Year2021;

namespace Core
{
    public class PuzzleRepository
    {
        private readonly IList<Event> _events = new List<Event>
        {
            new Event2015(),
            new Event2016(),
            new Event2017(),
            new Event2018(),
            new Event2019(),
            new Event2020(),
            new Event2021()
        };

        public PuzzleDay GetDay(int? selectedYear, int? selectedDay)
        {
            var year = GetEvent(selectedYear);
            return year.GetDay(selectedDay);
        }

        public Event GetEvent(int? selectedYear)
        {
            if (selectedYear != null)
            {
                var year = _events.FirstOrDefault(o => o.Year == selectedYear.Value);
                return year ?? _events.Last();
            }

            return _events.Last();
        }
        
        public List<PuzzleDay> GetAll()
        {
            var eventDays = _events.Select(o => o.Days);
            var allDays = new List<PuzzleDay>();
            foreach (var days in eventDays)
            {
                allDays.AddRange(days);
            }

            return allDays;
        }
    }
}