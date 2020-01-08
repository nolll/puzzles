using System.Collections.Generic;

namespace ConsoleApp.Years.Year2017
{
    public class Event2017 : Event
    {
        public Event2017() : base(2017)
        {
        }

        protected override IList<Day> Days => new List<Day>
        {
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
            new Day06()
        };
    }
}