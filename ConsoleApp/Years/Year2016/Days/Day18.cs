using System;
using Core.FloorTraps;

namespace ConsoleApp.Years.Year2016.Days
{
    public class Day18 : Day2016
    {
        public Day18() : base(18)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var detector1 = new FloorTrapDetector(Input);
            detector1.FindTraps(40);
            Console.WriteLine($"Number of safe tiles after 40 rows: {detector1.SafeCount}");

            WritePartTitle();
            var detector2 = new FloorTrapDetector(Input);
            detector2.FindTraps(400_000);
            Console.WriteLine($"Number of safe tiles after 400000 rows: {detector2.SafeCount}");
        }

        protected override string Input => ".^^^^^.^^.^^^.^...^..^^.^.^..^^^^^^^^^^..^...^^.^..^^^^..^^^^...^.^.^^^^^^^^....^..^^^^^^.^^^.^^^.^^";
    }
}