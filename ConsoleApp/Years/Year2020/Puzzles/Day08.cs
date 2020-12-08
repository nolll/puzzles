using System;
using Core.HandheldGameConsole;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day08 : Day2020
    {
        public Day08() : base(8)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var console = new GameConsoleRunner(FileInput);
            var acc1 = console.RunUntilLoop();
            Console.WriteLine($"Value of acc after loop: {acc1}");

            WritePartTitle();
            var acc2 = console.RunUntilTermination();
            Console.WriteLine($"Value of acc after loop: {acc2}");
        }
    }
}