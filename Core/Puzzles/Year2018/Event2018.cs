using System.Collections.Generic;
using Core.Platform;
using Core.Puzzles.Year2018.Day01;
using Core.Puzzles.Year2018.Day02;
using Core.Puzzles.Year2018.Day03;
using Core.Puzzles.Year2018.Day04;
using Core.Puzzles.Year2018.Day05;
using Core.Puzzles.Year2018.Day06;
using Core.Puzzles.Year2018.Day07;
using Core.Puzzles.Year2018.Day08;
using Core.Puzzles.Year2018.Day09;
using Core.Puzzles.Year2018.Day10;
using Core.Puzzles.Year2018.Day11;
using Core.Puzzles.Year2018.Day12;
using Core.Puzzles.Year2018.Day13;
using Core.Puzzles.Year2018.Day14;
using Core.Puzzles.Year2018.Day15;
using Core.Puzzles.Year2018.Day16;
using Core.Puzzles.Year2018.Day17;
using Core.Puzzles.Year2018.Day18;
using Core.Puzzles.Year2018.Day19;
using Core.Puzzles.Year2018.Day20;
using Core.Puzzles.Year2018.Day21;
using Core.Puzzles.Year2018.Day22;
using Core.Puzzles.Year2018.Day23;
using Core.Puzzles.Year2018.Day24;
using Core.Puzzles.Year2018.Day25;

namespace Core.Puzzles.Year2018
{
    public class Event2018 : Event
    {
        public override int Year => 2018;

        public override List<PuzzleDay> Days => new()
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