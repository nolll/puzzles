using System.Collections.Generic;
using Core.PuzzleClasses;
using Core.Puzzles.Year2016.Day01;
using Core.Puzzles.Year2016.Day02;
using Core.Puzzles.Year2016.Day03;
using Core.Puzzles.Year2016.Day04;
using Core.Puzzles.Year2016.Day05;
using Core.Puzzles.Year2016.Day06;
using Core.Puzzles.Year2016.Day07;
using Core.Puzzles.Year2016.Day08;
using Core.Puzzles.Year2016.Day09;
using Core.Puzzles.Year2016.Day10;
using Core.Puzzles.Year2016.Day11;
using Core.Puzzles.Year2016.Day12;
using Core.Puzzles.Year2016.Day13;
using Core.Puzzles.Year2016.Day14;
using Core.Puzzles.Year2016.Day15;
using Core.Puzzles.Year2016.Day16;
using Core.Puzzles.Year2016.Day17;
using Core.Puzzles.Year2016.Day18;
using Core.Puzzles.Year2016.Day19;
using Core.Puzzles.Year2016.Day20;
using Core.Puzzles.Year2016.Day21;
using Core.Puzzles.Year2016.Day22;
using Core.Puzzles.Year2016.Day23;
using Core.Puzzles.Year2016.Day24;
using Core.Puzzles.Year2016.Day25;

namespace Core.Puzzles.Year2016
{
    public class Event2016 : Event
    {
        public override int Year => 2016;

        public override List<PuzzleDay> Days => new()
        {
            new Year2016Day01(),
            new Year2016Day02(),
            new Year2016Day03(),
            new Year2016Day04(),
            new Year2016Day05(),
            new Year2016Day06(),
            new Year2016Day07(),
            new Year2016Day08(),
            new Year2016Day09(),
            new Year2016Day10(),
            new Year2016Day11(),
            new Year2016Day12(),
            new Year2016Day13(),
            new Year2016Day14(),
            new Year2016Day15(),
            new Year2016Day16(),
            new Year2016Day17(),
            new Year2016Day18(),
            new Year2016Day19(),
            new Year2016Day20(),
            new Year2016Day21(),
            new Year2016Day22(),
            new Year2016Day23(),
            new Year2016Day24(),
            new Year2016Day25()
        };
    }
}