using System;
using Core.OperationComputer;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day19 : Day2018
    {
        public Day19() : base(19)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var computer = new OpComputer();
            var value1 = computer.RunInstructionPointerProgram(FileInput, 0, true, false);
            Console.WriteLine($"Value at register 0 when program halts: {value1}");

            WritePartTitle();
            var computer2 = new OpComputer();
            var value2 = computer2.RunInstructionPointerProgram(FileInput, 1, true, false);
            Console.WriteLine($"Value at register 0 when program halts: {value2}");
        }
    }
}