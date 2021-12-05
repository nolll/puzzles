using System.Collections.Generic;
using ConsoleApp.Years.Year2017.Puzzles;

namespace ConsoleApp.Years.Year2017
{
    public class Event2017 : Event
    {
        public Event2017() : base(2017)
        {
        }

        public override IList<PuzzleDay> Days => new List<PuzzleDay>
        {
            new Year2017Day01(),
            new Year2017Day02(),
            new Year2017Day03(),
            new Year2017Day04(),
            new Year2017Day05(),
            new Year2017Day06(),
            new Year2017Day07(),
            new Year2017Day08(),
            new Year2017Day09(),
            new Year2017Day10(),
            new Year2017Day11(),
            new Year2017Day12(),
            new Year2017Day13(),
            new Year2017Day14(),
            new Year2017Day15(),
            new Year2017Day16(),
            new Year2017Day17(),
            new Year2017Day18(),
            new Year2017Day19(),
            new Year2017Day20(),
            new Year2017Day21(),
            new Year2017Day22(),
            new Year2017Day23(),
            new Year2017Day24(),
            new Year2017Day25()
        };
    }
}