using System.Collections.Generic;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day01;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day02;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day03;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day04;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day05;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day06;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day07;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day08;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day09;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day10;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day11;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day12;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day13;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day14;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day15;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day16;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day17;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day18;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day19;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day20;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day21;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day22;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day23;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day24;
using ConsoleApp.Puzzles.Year2021.Puzzles.Day25;

namespace ConsoleApp.Puzzles.Year2021
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
            new Year2021Day05(),
            new Year2021Day06(),
            new Year2021Day07(),
            new Year2021Day08(),
            new Year2021Day09(),
            new Year2021Day10(),
            new Year2021Day11(),
            new Year2021Day12(),
            new Year2021Day13(),
            new Year2021Day14(),
            new Year2021Day15(),
            new Year2021Day16(),
            new Year2021Day17(),
            new Year2021Day18(),
            new Year2021Day19(),
            new Year2021Day20(),
            new Year2021Day21(),
            new Year2021Day22(),
            new Year2021Day23(),
            new Year2021Day24(),
            new Year2021Day25()
        };
    }
}