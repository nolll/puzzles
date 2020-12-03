using System;
using Core.ReindeerOlympics;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day14 : Day2015
    {
        public Day14() : base(14)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var race = new ReindeerRace(FileInput, 2503);
            Console.WriteLine($"Winning distance: {race.WinningDistance}");

            WritePartTitle();
            Console.WriteLine($"Winning score: {race.WinningScore}");
        }
    }
}