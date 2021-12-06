using System.Collections.Generic;
using Core.Platform;
using Core.Puzzles.Year2020.Day01;
using Core.Puzzles.Year2020.Day02;
using Core.Puzzles.Year2020.Day03;
using Core.Puzzles.Year2020.Day04;
using Core.Puzzles.Year2020.Day05;
using Core.Puzzles.Year2020.Day06;
using Core.Puzzles.Year2020.Day07;
using Core.Puzzles.Year2020.Day08;
using Core.Puzzles.Year2020.Day09;
using Core.Puzzles.Year2020.Day10;
using Core.Puzzles.Year2020.Day11;
using Core.Puzzles.Year2020.Day12;
using Core.Puzzles.Year2020.Day13;
using Core.Puzzles.Year2020.Day14;
using Core.Puzzles.Year2020.Day15;
using Core.Puzzles.Year2020.Day16;
using Core.Puzzles.Year2020.Day17;
using Core.Puzzles.Year2020.Day18;
using Core.Puzzles.Year2020.Day19;
using Core.Puzzles.Year2020.Day20;
using Core.Puzzles.Year2020.Day21;
using Core.Puzzles.Year2020.Day22;
using Core.Puzzles.Year2020.Day23;
using Core.Puzzles.Year2020.Day24;
using Core.Puzzles.Year2020.Day25;

namespace Core.Puzzles.Year2020
{
    public class Event2020 : Event
    {
        public override int Year => 2020;

        public override List<PuzzleDay> Days => new()
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