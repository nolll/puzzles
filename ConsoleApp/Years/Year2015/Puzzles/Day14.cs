using System;
using Core.ReindeerOlympics;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day14 : Day2015
    {
        public Day14() : base(14)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var race = new ReindeerRace(FileInput, 2503);
            return new PuzzleResult(race.WinningDistance, 2655);
        }

        public override PuzzleResult RunPart2()
        {
            var race = new ReindeerRace(FileInput, 2503);
            return new PuzzleResult(race.WinningScore, 1059);
        }
    }
}