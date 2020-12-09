using System;
using Core.Duet;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day18 : Day2017
    {
        public Day18() : base(18)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var single = new SingleRunner(FileInput);
            single.Run();
            Console.WriteLine($"Recovered frequency: {single.RecoveredFrequency}");

            WritePartTitle();
            var duet = new DuetRunner(FileInput);
            duet.Run();
            Console.WriteLine($"Program 1 send count: {duet.Program1SendCount}");
        }
    }
}