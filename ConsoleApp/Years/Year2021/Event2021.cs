using System.Collections.Generic;
using ConsoleApp.Years.Year2021.Puzzles;

namespace ConsoleApp.Years.Year2021
{
    public class Event2021 : Event
    {
        public Event2021() : base(2021)
        {
        }

        public override IList<Day> Days => new List<Day>
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04()
        };
    }
}