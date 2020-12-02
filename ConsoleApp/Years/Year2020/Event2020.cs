using System.Collections.Generic;

namespace ConsoleApp.Years.Year2020
{
    public class Event2020 : Event
    {
        public Event2020() : base(2020)
        {
        }

        protected override IList<Day> Days => new List<Day>
        {
            new Day01(),
            new Day02()
        };
    }
}