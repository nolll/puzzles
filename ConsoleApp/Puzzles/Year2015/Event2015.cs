using System.Collections.Generic;
using ConsoleApp.Puzzles.Year2015.Puzzles;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day23;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day25;

namespace ConsoleApp.Puzzles.Year2015
{
    public class Event2015 : Event
    {
        public Event2015() : base(2015)
        {
        }

        public override IList<PuzzleDay> Days => new List<PuzzleDay>
        {
            new Year2015Day01(),
            new Year2015Day02(),
            new Year2015Day03(),
            new Year2015Day04(),
            new Year2015Day05(),
            new Year2015Day06(),
            new Year2015Day07(),
            new Year2015Day08(),
            new Year2015Day09(),
            new Year2015Day10(),
            new Year2015Day11(),
            new Year2015Day12(),
            new Year2015Day13(),
            new Year2015Day14(),
            new Year2015Day15(),
            new Year2015Day16(),
            new Year2015Day17(),
            new Year2015Day18(),
            new Year2015Day19(),
            new Year2015Day20(),
            new Year2015Day21(),
            new Year2015Day22(),
            new Year2015Day23(),
            new Year2015Day24(),
            new Year2015Day25()
        };
    }
}