using System.Collections.Generic;
using App.Platform;
using App.Puzzles.Year2017.Day01;
using App.Puzzles.Year2017.Day02;
using App.Puzzles.Year2017.Day03;
using App.Puzzles.Year2017.Day04;
using App.Puzzles.Year2017.Day05;
using App.Puzzles.Year2017.Day06;
using App.Puzzles.Year2017.Day07;
using App.Puzzles.Year2017.Day08;
using App.Puzzles.Year2017.Day09;
using App.Puzzles.Year2017.Day10;
using App.Puzzles.Year2017.Day11;
using App.Puzzles.Year2017.Day12;
using App.Puzzles.Year2017.Day13;
using App.Puzzles.Year2017.Day14;
using App.Puzzles.Year2017.Day15;
using App.Puzzles.Year2017.Day16;
using App.Puzzles.Year2017.Day17;
using App.Puzzles.Year2017.Day18;
using App.Puzzles.Year2017.Day19;
using App.Puzzles.Year2017.Day20;
using App.Puzzles.Year2017.Day21;
using App.Puzzles.Year2017.Day22;
using App.Puzzles.Year2017.Day23;
using App.Puzzles.Year2017.Day24;
using App.Puzzles.Year2017.Day25;

namespace App.Puzzles.Year2017
{
    public class Event2017 : Event
    {
        public override int Year => 2017;

        public override List<PuzzleDay> Days => new()
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