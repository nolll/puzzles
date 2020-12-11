using System;
using Core.OperationComputer;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day19 : Day2018
    {
        public Day19() : base(19)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var computer = new OpComputer();
            var value1 = computer.RunInstructionPointerProgram(FileInput, 0, true, false);
            return new PuzzleResult($"Value at register 0 when program halts: {value1}");
        }

        public override PuzzleResult RunPart2()
        {
            var computer2 = new OpComputer();
            var value2 = computer2.RunInstructionPointerProgram(FileInput, 1, true, false);
            return new PuzzleResult($"Value at register 0 when program halts: {value2}");
        }
    }
}