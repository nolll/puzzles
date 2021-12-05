using System.Collections.Generic;
using ConsoleApp.Years.Year2020.Puzzles;
using ConsoleApp.Years.Year2020.Puzzles.Day03;
using ConsoleApp.Years.Year2020.Puzzles.Day11;

namespace ConsoleApp.Years.Year2020
{
    public class Event2020 : Event
    {
        public Event2020() : base(2020)
        {
        }

        public override IList<PuzzleDay> Days => new List<PuzzleDay>
        {
            new Year2020Day01(),
            new Year2020Day02(),
            new Year2020Day03(),
            new Year2020Day04(),
            new Year2020Day05(),
            new Year2020Day06(),
            new Year2020Day07(),
            new Year2020Day08(),
            new Year2020Day09(),
            new Year2020Day10(),
            new Year2020Day11(),
            new Year2020Day12(),
            new Year2020Day13(),
            new Year2020Day14(),
            new Year2020Day15(),
            new Year2020Day16(),
            new Year2020Day17(),
            new Year2020Day18(),
            new Year2020Day19(),
            new Year2020Day20(),
            new Year2020Day21(),
            new Year2020Day22(),
            new Year2020Day23(),
            new Year2020Day24(),
            new Year2020Day25()
        };
    }
}