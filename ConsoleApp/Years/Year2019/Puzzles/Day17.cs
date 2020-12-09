using System;
using Core.Scaffolding;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day17 : Day2019
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var sc = new ScaffoldingComputer1(FileInput);
            var input = sc.Run();
            var sif = new ScaffoldIntersectionFinder(input);
            var result1 = sif.GetSumOfAlignmentParameters();

            Console.WriteLine($"Sum of alignment parameters: {result1}");

            WritePartTitle();
            var sc2 = new ScaffoldingComputer2(FileInput);
            var result2 = sc2.Run();

            Console.WriteLine($"Dust amount: {result2}");
        }
    }
}