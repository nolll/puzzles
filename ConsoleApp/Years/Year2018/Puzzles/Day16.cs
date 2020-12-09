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

        protected override void RunDay()
        {
            var inputs = FileInput.Split("\r\n\r\n\r\n");
            var input1 = inputs.First();
            var input2 = inputs.Last();

            WritePartTitle();
            var computer = new OpComputer();
            var count = computer.InputsMatchingThreeOrMore(input1);
            Console.WriteLine($"Inputs matching three or more: {count}");

            WritePartTitle();
            var value = computer.RunTestProgram(input1, input2);
            Console.WriteLine($"Value at register 0 after test program: {value}");
        }
    }
}