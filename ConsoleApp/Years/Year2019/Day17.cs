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
            var sc = new ScaffoldingComputer(InputData.ComputerProgramDay17);
            var input = sc.Run();
            var sif = new ScaffoldIntersectionFinder(input);
            var result = sif.GetSumOfAlignmentParameters();

            Console.WriteLine($"Sum of alignment parameters: {result}");
        }
    }
}