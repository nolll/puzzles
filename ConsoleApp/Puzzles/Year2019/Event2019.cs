using System.Collections.Generic;
using ConsoleApp.Puzzles.Year2019.Day01;
using ConsoleApp.Puzzles.Year2019.Day02;
using ConsoleApp.Puzzles.Year2019.Day03;
using ConsoleApp.Puzzles.Year2019.Day04;
using ConsoleApp.Puzzles.Year2019.Day05;
using ConsoleApp.Puzzles.Year2019.Day06;
using ConsoleApp.Puzzles.Year2019.Day07;
using ConsoleApp.Puzzles.Year2019.Day08;
using ConsoleApp.Puzzles.Year2019.Day09;
using ConsoleApp.Puzzles.Year2019.Day10;
using ConsoleApp.Puzzles.Year2019.Day11;
using ConsoleApp.Puzzles.Year2019.Day12;
using ConsoleApp.Puzzles.Year2019.Day13;
using ConsoleApp.Puzzles.Year2019.Day14;
using ConsoleApp.Puzzles.Year2019.Day15;
using ConsoleApp.Puzzles.Year2019.Day16;
using ConsoleApp.Puzzles.Year2019.Day17;
using ConsoleApp.Puzzles.Year2019.Day18;
using ConsoleApp.Puzzles.Year2019.Day19;
using ConsoleApp.Puzzles.Year2019.Day20;
using ConsoleApp.Puzzles.Year2019.Day21;
using ConsoleApp.Puzzles.Year2019.Day22;
using ConsoleApp.Puzzles.Year2019.Day23;
using ConsoleApp.Puzzles.Year2019.Day24;
using ConsoleApp.Puzzles.Year2019.Day25;
using Core.PuzzleClasses;

namespace ConsoleApp.Puzzles.Year2019
{
    public class Event2019 : Event
    {
        public override int Year => 2019;

        public override List<PuzzleDay> Days => new()
        {
            new Year2019Day01(),
            new Year2019Day02(),
            new Year2019Day03(),
            new Year2019Day04(),
            new Year2019Day05(),
            new Year2019Day06(),
            new Year2019Day07(),
            new Year2019Day08(),
            new Year2019Day09(),
            new Year2019Day10(),
            new Year2019Day11(),
            new Year2019Day12(),
            new Year2019Day13(),
            new Year2019Day14(),
            new Year2019Day15(),
            new Year2019Day16(),
            new Year2019Day17(),
            new Year2019Day18(),
            new Year2019Day19(),
            new Year2019Day20(),
            new Year2019Day21(),
            new Year2019Day22(),
            new Year2019Day23(),
            new Year2019Day24(),
            new Year2019Day25()
        };
    }
}