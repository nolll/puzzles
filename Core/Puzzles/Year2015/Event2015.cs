using System.Collections.Generic;
using Core.Platform;
using Core.Puzzles.Year2015.Day01;
using Core.Puzzles.Year2015.Day02;
using Core.Puzzles.Year2015.Day03;
using Core.Puzzles.Year2015.Day04;
using Core.Puzzles.Year2015.Day05;
using Core.Puzzles.Year2015.Day06;
using Core.Puzzles.Year2015.Day07;
using Core.Puzzles.Year2015.Day08;
using Core.Puzzles.Year2015.Day09;
using Core.Puzzles.Year2015.Day10;
using Core.Puzzles.Year2015.Day11;
using Core.Puzzles.Year2015.Day12;
using Core.Puzzles.Year2015.Day13;
using Core.Puzzles.Year2015.Day14;
using Core.Puzzles.Year2015.Day15;
using Core.Puzzles.Year2015.Day16;
using Core.Puzzles.Year2015.Day17;
using Core.Puzzles.Year2015.Day18;
using Core.Puzzles.Year2015.Day19;
using Core.Puzzles.Year2015.Day20;
using Core.Puzzles.Year2015.Day21;
using Core.Puzzles.Year2015.Day22;
using Core.Puzzles.Year2015.Day23;
using Core.Puzzles.Year2015.Day24;
using Core.Puzzles.Year2015.Day25;

namespace Core.Puzzles.Year2015
{
    public class Event2015 : Event
    {
        public override int Year => 2015;

        public override List<PuzzleDay> Days => new()
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