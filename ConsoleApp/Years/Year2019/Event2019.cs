using System.Collections.Generic;
using ConsoleApp.Years.Year2019.Puzzles;
using ConsoleApp.Years.Year2019.Puzzles.Day18;

namespace ConsoleApp.Years.Year2019
{
    public class Event2019 : Event
    {
        public Event2019() : base(2019)
        {
        }

        public override IList<PuzzleDay> Days => new List<PuzzleDay>
        {
            new Year2019Day01(),
            new Year2019Day02(),
            new Year2019Day03(),
            new Year2019Day04(),
            new Year2019Day05(),
            new Year2019Day06(),
            new Year2019Day07(),
            new Year2019Day08(),
            new Year2019Day09(),
            new Year2019Day10(),
            new Year2019Day11(),
            new Year2019Day12(),
            new Year2019Day13(),
            new Year2019Day14(),
            new Year2019Day15(),
            new Year2019Day16(),
            new Year2019Day17(),
            new Year2019Day18(),
            new Year2019Day19(),
            new Year2019Day20(),
            new Year2019Day21(),
            new Year2019Day22(),
            new Year2019Day23(),
            new Year2019Day24(),
            new Year2019Day25()
        };
    }
}