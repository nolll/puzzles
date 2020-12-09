using System;
using Core.SleighAssembly;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day07 : Day2018
    {
        public Day07() : base(7)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var assembler1 = new SleighAssembler(FileInput, 1, 0);
            var result1 = assembler1.Assemble();
            Console.WriteLine($"Sleigh assembly order: {result1.Order}");

            WritePartTitle();
            var assembler2 = new SleighAssembler(FileInput, 5, 60);
            var result2 = assembler2.Assemble();
            Console.WriteLine($"Time spent: {result2.Time}s");
        }
    }
}