using System.Collections.Generic;
using Core.Platform;
using Core.Puzzles.Year2021.Day01;
using Core.Puzzles.Year2021.Day02;
using Core.Puzzles.Year2021.Day03;
using Core.Puzzles.Year2021.Day04;
using Core.Puzzles.Year2021.Day05;
using Core.Puzzles.Year2021.Day06;
using Core.Puzzles.Year2021.Day07;
using Core.Puzzles.Year2021.Day08;
using Core.Puzzles.Year2021.Day09;
using Core.Puzzles.Year2021.Day10;
using Core.Puzzles.Year2021.Day11;
using Core.Puzzles.Year2021.Day12;
using Core.Puzzles.Year2021.Day13;
using Core.Puzzles.Year2021.Day14;
using Core.Puzzles.Year2021.Day15;
using Core.Puzzles.Year2021.Day16;
using Core.Puzzles.Year2021.Day17;
using Core.Puzzles.Year2021.Day18;
using Core.Puzzles.Year2021.Day19;
using Core.Puzzles.Year2021.Day20;
using Core.Puzzles.Year2021.Day21;
using Core.Puzzles.Year2021.Day22;
using Core.Puzzles.Year2021.Day23;
using Core.Puzzles.Year2021.Day24;
using Core.Puzzles.Year2021.Day25;

namespace Core.Puzzles.Year2021
{
    public class Event2021 : Event
    {
        public override int Year => 2021;

        public override List<PuzzleDay> Days => new()
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