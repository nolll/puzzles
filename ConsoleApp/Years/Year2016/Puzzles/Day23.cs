using System;
using Core.SafeCracking;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day23 : Day2016
    {
        public Day23() : base(23)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var computer1 = new SafeCrackingComputerPart1(FileInput, 7, 0);
            return new PuzzleResult($"Value in register A: {computer1.ValueA}");
        }

        public override PuzzleResult RunPart2()
        {
            // By inspecting output from the computer I realized that it is calculating the factorial of 12
            var computer2 = new SafeCrackingComputerPart2(FileInput, 12, 0);
            return new PuzzleResult($"Value in register A: {computer2.ValueA}");
        }
    }
}