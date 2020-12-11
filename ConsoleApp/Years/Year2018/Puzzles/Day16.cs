using System;
using System.IO;
using System.Linq;
using Core.OperationComputer;
using Core.Tools;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day16 : Day2018
    {
        public Day16() : base(16)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var inputs = FileInput.Split("\r\n\r\n\r\n");
            var input1 = inputs.First();
            
            var computer = new OpComputer();
            var count = computer.InputsMatchingThreeOrMore(input1);
            return new PuzzleResult($"Inputs matching three or more: {count}");
        }

        public override PuzzleResult RunPart2()
        {
            var inputs = FileInput.Split("\r\n\r\n\r\n");
            var input1 = inputs.First();
            var input2 = inputs.Last();

            var computer = new OpComputer();
            var value = computer.RunTestProgram(input1, input2);
            return new PuzzleResult($"Value at register 0 after test program: {value}");
        }
    }
}