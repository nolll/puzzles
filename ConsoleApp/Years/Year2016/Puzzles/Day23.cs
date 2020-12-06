using System;
using Core.SafeCracking;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day23 : Day2016
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            //var computer1 = new AssembunnyComputerPart1(FileInput, 7, 0);
            //Console.WriteLine($"Value in register A: {computer1.ValueA}");

            WritePartTitle();
            // By inspecting output from the computer I realized that it is calculating the factorial of 12
            var computer2 = new SafeCrackingComputerPart2(FileInput, 12, 0);
            Console.WriteLine($"Value in register A: {computer2.ValueA}");
            //var factorial = Factorial(12);
            //Console.WriteLine($"Value in register A: {factorial}");
        }
    }
}