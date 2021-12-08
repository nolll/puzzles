using System.Collections.Generic;
using App.Platform;
using App.Puzzles.Year2021.Day01;
using App.Puzzles.Year2021.Day02;
using App.Puzzles.Year2021.Day03;
using App.Puzzles.Year2021.Day04;
using App.Puzzles.Year2021.Day05;
using App.Puzzles.Year2021.Day06;
using App.Puzzles.Year2021.Day07;
using App.Puzzles.Year2021.Day08;
using App.Puzzles.Year2021.Day09;
using App.Puzzles.Year2021.Day10;
using App.Puzzles.Year2021.Day11;
using App.Puzzles.Year2021.Day12;
using App.Puzzles.Year2021.Day13;
using App.Puzzles.Year2021.Day14;
using App.Puzzles.Year2021.Day15;
using App.Puzzles.Year2021.Day16;
using App.Puzzles.Year2021.Day17;
using App.Puzzles.Year2021.Day18;
using App.Puzzles.Year2021.Day19;
using App.Puzzles.Year2021.Day20;
using App.Puzzles.Year2021.Day21;
using App.Puzzles.Year2021.Day22;
using App.Puzzles.Year2021.Day23;
using App.Puzzles.Year2021.Day24;
using App.Puzzles.Year2021.Day25;

namespace App.Puzzles.Year2021
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