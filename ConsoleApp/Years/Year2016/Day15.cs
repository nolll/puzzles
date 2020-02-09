using System;
using Core.KineticSculptureTiming;

namespace ConsoleApp.Years.Year2016
{
    public class Day15 : Day
    {
        public Day15() : base(15)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var sculpture1 = new KineticSculpture(Input);
            Console.WriteLine($"Time to press button: {sculpture1.TimeToPressButton}");

            WritePartTitle();
            var sculpture2 = new KineticSculpture(Input, true);
            Console.WriteLine($"Time to press button: {sculpture2.TimeToPressButton}");
        }

        private const string Input = @"Disc #1 has 17 positions; at time=0, it is at position 1.
Disc #2 has 7 positions; at time=0, it is at position 0.
Disc #3 has 19 positions; at time=0, it is at position 2.
Disc #4 has 5 positions; at time=0, it is at position 0.
Disc #5 has 3 positions; at time=0, it is at position 0.
Disc #6 has 13 positions; at time=0, it is at position 5.";
    }
}