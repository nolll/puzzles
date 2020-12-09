using System;
using Core.CoprocessorConflagration;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day23 : Day2017
    {
        public Day23() : base(23)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var processor1 = new CoProcessor(FileInput);
            processor1.Run();
            Console.WriteLine($"The mul instruction was invoked {processor1.MulCount} times.");

            WritePartTitle();
            var processor2 = new OptimizedCoProcessor();
            processor2.Run();
            Console.WriteLine($"Value left in register h: {processor2.H}.");
        }
    }
}