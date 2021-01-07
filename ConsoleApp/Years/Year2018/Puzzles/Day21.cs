using System;
using Core.OperationComputer;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day21 : Day2018
    {
        public override string Comment => "OpComputer";
        public override bool IsSlow => true;
        
        public Day21() : base(21)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var computer = new OpComputer();
            var result = computer.RunSpecialForDay21(FileInput, 0);
            return new PuzzleResult(result.first, 103_548);
        }

        public override PuzzleResult RunPart2()
        {
            var computer = new OpComputer();
            var result = computer.RunSpecialForDay21(FileInput, 0);
            return new PuzzleResult(result.last, 14_256_686);
        }
    }
}