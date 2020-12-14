using System;
using Core.Scaffolding;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day17 : Day2019
    {
        public Day17() : base(17)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var sc = new ScaffoldingComputer1(FileInput);
            var input = sc.Run();
            var sif = new ScaffoldIntersectionFinder(input);
            var result1 = sif.GetSumOfAlignmentParameters();

            return new PuzzleResult(result1, 8408);
        }

        public override PuzzleResult RunPart2()
        {
            var sc2 = new ScaffoldingComputer2(FileInput);
            var result2 = sc2.Run();

            return new PuzzleResult(result2, 1_168_948);
        }
    }
}