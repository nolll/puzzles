using System;
using Core.KineticSculptureTiming;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day15 : Day2016
    {
        public Day15() : base(15)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var sculpture1 = new KineticSculpture(FileInput);
            Console.WriteLine($"Time to press button: {sculpture1.TimeToPressButton}");

            WritePartTitle();
            var sculpture2 = new KineticSculpture(FileInput, true);
            Console.WriteLine($"Time to press button: {sculpture2.TimeToPressButton}");
        }
    }
}