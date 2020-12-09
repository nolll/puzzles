using System;
using Core.Orbits;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day06 : Day2019
    {
        public Day06() : base(6)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var calculator = new OrbitCalculator(FileInput);
            var orbitCount = calculator.GetOrbitCount();
            Console.WriteLine($"Total number of orbits: {orbitCount}");

            WritePartTitle();
            var distance = calculator.GetSantaDistance();
            Console.WriteLine($"Distance to Santa: {distance}");
        }
    }
}