using System.Collections.Generic;
using ConsoleApp.Puzzles.Year2015.Puzzles;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day01;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day02;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day03;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day04;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day05;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day06;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day07;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day08;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day09;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day10;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day11;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day12;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day13;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day14;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day15;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day16;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day17;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day18;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day19;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day20;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day21;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day22;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day23;
using ConsoleApp.Puzzles.Year2015.Puzzles.Day24;
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