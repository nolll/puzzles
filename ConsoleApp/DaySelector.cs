using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Puzzles;
using ConsoleApp.Puzzles.Year2015;
using ConsoleApp.Puzzles.Year2016;
using ConsoleApp.Puzzles.Year2017;
using ConsoleApp.Puzzles.Year2018;
using ConsoleApp.Puzzles.Year2019;
using ConsoleApp.Puzzles.Year2020;
using ConsoleApp.Puzzles.Year2021;
using Core.PuzzleClasses;

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