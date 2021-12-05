using System.Collections.Generic;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day01;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day02;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day03;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day04;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day05;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day06;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day07;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day08;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day09;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day10;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day11;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day12;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day13;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day14;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day15;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day16;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day17;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day18;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day19;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day20;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day21;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day22;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day23;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day24;
using ConsoleApp.Puzzles.Year2017.Puzzles.Day25;

namespace ConsoleApp.Puzzles.Year2017
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