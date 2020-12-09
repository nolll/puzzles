using System;
using Core.CpuInstructions;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day08 : Day2017
    {
        public Day08() : base(8)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calculator = new CpuInstructionCalculator(FileInput);
            Console.WriteLine($"Largest value at end: {calculator.LargestValueAtEnd}");

            WritePartTitle();
            Console.WriteLine($"Largest value ever: {calculator.LargestValueEver}");
        }
    }
}