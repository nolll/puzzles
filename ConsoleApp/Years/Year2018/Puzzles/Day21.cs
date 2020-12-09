using System;
using Core.OperationComputer;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day21 : Day2018
    {
        public Day21() : base(21)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var computer = new OpComputer();
            var result = computer.RunSpecialForDay21(FileInput, 0);
            Console.WriteLine($"Lowest value for register zero after fewest iterations: {result.first}");

            WritePartTitle();
            Console.WriteLine($"Lowest value for register zero after most iterations: {result.last}");
        }
    }
}