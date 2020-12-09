using System;
using Core.LineDance;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day16 : Day2017
    {
        public Day16() : base(16)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var dancingPrograms1 = new DancingPrograms();
            dancingPrograms1.Dance(FileInput, 1);
            Console.WriteLine($"Programs after one dance: {dancingPrograms1.Programs}");

            WritePartTitle();
            var dancingPrograms2 = new DancingPrograms();
            dancingPrograms2.Dance(FileInput, 1_000_000_000);
            Console.WriteLine($"Programs after one billion dances: {dancingPrograms2.Programs}");
        }
    }
}