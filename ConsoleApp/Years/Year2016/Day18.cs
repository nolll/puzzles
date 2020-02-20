using System;
using Core.FloorTraps;

namespace ConsoleApp.Years.Year2016
{
    public class Day18 : Day
    {
        public Day18() : base(18)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var detector = new FloorTrapDetector(Input);
            detector.FindTraps(40);
            Console.WriteLine($"Number of safe tiles: {detector.SafeCount}");
        }

        private const string Input = ".^^^^^.^^.^^^.^...^..^^.^.^..^^^^^^^^^^..^...^^.^..^^^^..^^^^...^.^.^^^^^^^^....^..^^^^^^.^^^.^^^.^^";
    }
}