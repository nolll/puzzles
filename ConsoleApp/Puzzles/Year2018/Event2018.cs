using System.Collections.Generic;
using ConsoleApp.Puzzles.Year2018.Puzzles;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day01;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day02;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day03;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day04;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day05;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day06;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day07;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day08;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day09;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day10;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day11;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day12;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day13;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day14;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day15;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day16;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day17;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day18;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day19;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day20;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day21;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day22;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day23;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day24;
using ConsoleApp.Puzzles.Year2018.Puzzles.Day25;

namespace ConsoleApp.Puzzles.Year2018
{
    public class Event2018 : Event
    {
        public Event2018() : base(2018)
        {
        }

        public override IList<PuzzleDay> Days => new List<PuzzleDay>
        {
            new Year2018Day01(),
            new Year2018Day02(),
            new Year2018Day03(),
            new Year2018Day04(),
            new Year2018Day05(),
            new Year2018Day06(),
            new Year2018Day07(),
            new Year2018Day08(),
            new Year2018Day09(),
            new Year2018Day10(),
            new Year2018Day11(),
            new Year2018Day12(),
            new Year2018Day13(),
            new Year2018Day14(),
            new Year2018Day15(),
            new Year2018Day16(),
            new Year2018Day17(),
            new Year2018Day18(),
            new Year2018Day19(),
            new Year2018Day20(),
            new Year2018Day21(),
            new Year2018Day22(),
            new Year2018Day23(),
            new Year2018Day24(),
            new Year2018Day25()
        };
    }
}