using System.Collections.Generic;
using ConsoleApp.Years.Year2021.Puzzles;

namespace ConsoleApp.Years.Year2021
{
    public class Event2021 : Event
    {
        public Event2021() : base(2021)
        {
        }

        public override IList<PuzzleDay> Days => new List<PuzzleDay>
        {
            new Year2021Day01(),
            new Year2021Day02(),
            new Year2021Day03(),
            new Year2021Day04(),
            new Year2021Day05()
        };
    }
}