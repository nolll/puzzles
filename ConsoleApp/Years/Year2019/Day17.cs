using System;
using Core.Scaffolding;
using Data.Inputs;

namespace ConsoleApp.Years.Year2019
{
    public class Day17 : Day
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var sc = new ScaffoldingComputer1(InputData.ComputerProgramDay17);
            var input = sc.Run();
            var sif = new ScaffoldIntersectionFinder(input);
            var result1 = sif.GetSumOfAlignmentParameters();

            Console.WriteLine($"Sum of alignment parameters: {result1}");

            WritePartTitle();
            var sc2 = new ScaffoldingComputer2(InputData.ComputerProgramDay17);
            var result2 = sc2.Run();

            Console.WriteLine($"Dust amount: {result2}");
        }
    }
}