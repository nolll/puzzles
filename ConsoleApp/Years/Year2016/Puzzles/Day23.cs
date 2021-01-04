using System;
using Core.SafeCracking;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day23 : Day2016
    {
        public override string Comment => "Factorial of 12";

        public Day23() : base(23)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var computer = new SafeCrackingComputerPart1(FileInput, 7, 0);
            return new PuzzleResult(computer.ValueA, 12_748);
        }

        public override PuzzleResult RunPart2()
        {
            // By inspecting output from the computer I realized that it is calculating the factorial of 12
            var computer = new SafeCrackingComputerPart2(FileInput, 12, 0);
            return new PuzzleResult(computer.ValueA, 479_009_308);
        }
    }
}