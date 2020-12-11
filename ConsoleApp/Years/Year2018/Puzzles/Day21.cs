using System;
using Core.OperationComputer;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day21 : Day2018
    {
        public Day21() : base(21)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var computer = new OpComputer();
            var result = computer.RunSpecialForDay21(FileInput, 0);
            return new PuzzleResult($"Lowest value for register zero after fewest iterations: {result.first}");
        }

        public override PuzzleResult RunPart2()
        {
            var computer = new OpComputer();
            var result = computer.RunSpecialForDay21(FileInput, 0);
            return new PuzzleResult($"Lowest value for register zero after most iterations: {result.last}");
        }
    }
}