using System.Collections.Generic;

namespace ConsoleApp.Years.Year2015
{
    public class Event2015 : Event
    {
        public Event2015() : base(2015)
        {
        }

        protected override IList<Day> Days => new List<Day>
        {
            new Day01(),
            new Day02(),
        };
    }
}