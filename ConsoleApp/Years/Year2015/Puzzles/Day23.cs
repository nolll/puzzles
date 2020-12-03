using System;
using Core.TuringLock;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day23 : Day2015
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var computer1 = new ChristmasComputer();
            computer1.Run(FileInput);
            Console.WriteLine($"Value of register B: {computer1.RegisterB}");

            WritePartTitle();
            var computer2 = new ChristmasComputer();
            computer2.Run(FileInput, 1);
            Console.WriteLine($"Value of register B: {computer2.RegisterB}");
        }
    }
}