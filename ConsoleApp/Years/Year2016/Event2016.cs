using System.Collections.Generic;
using ConsoleApp.Years.Year2016.Puzzles;

namespace ConsoleApp.Years.Year2016
{
    public class Event2016 : Event
    {
        public Event2016() : base(2016)
        {
        }

        public override IList<PuzzleDay> Days => new List<PuzzleDay>
        {
            new Year2016Day01(),
            new Year2016Day02(),
            new Year2016Day03(),
            new Year2016Day04(),
            new Year2016Day05(),
            new Year2016Day06(),
            new Year2016Day07(),
            new Year2016Day08(),
            new Year2016Day09(),
            new Year2016Day10(),
            new Year2016Day11(),
            new Year2016Day12(),
            new Year2016Day13(),
            new Year2016Day14(),
            new Year2016Day15(),
            new Year2016Day16(),
            new Year2016Day17(),
            new Year2016Day18(),
            new Year2016Day19(),
            new Year2016Day20(),
            new Year2016Day21(),
            new Year2016Day22(),
            new Year2016Day23(),
            new Year2016Day24(),
            new Year2016Day25()
        };
    }
}