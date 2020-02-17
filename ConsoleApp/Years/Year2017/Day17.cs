using System;
using Core.Spinlock;

namespace ConsoleApp.Years.Year2017
{
    public class Day17 : Day
    {
        public Day17() : base(17)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var runner = new SpinlockRunner(Input);
            runner.Run(2017);
            Console.WriteLine($"Next value after 2017: {runner.NextValue}");
        }

        private const int Input = 370;
    }
}