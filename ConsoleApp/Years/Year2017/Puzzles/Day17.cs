using System;
using Core.Spinlock;

namespace ConsoleApp.Years.Year2017.Puzzles
{
    public class Day17 : Day2017
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var runner1 = new SpinlockRunnerPart1(NumberInput);
            runner1.Run(2017);
            Console.WriteLine($"Next value after 2017: {runner1.NextValue}");

            WritePartTitle();
            var runner2 = new SpinlockRunnerPart2(NumberInput);
            runner2.Run(50_000_000);
            Console.WriteLine($"Next value after 0: {runner2.SecondValue}");
        }

        private const int NumberInput = 370;
    }
}