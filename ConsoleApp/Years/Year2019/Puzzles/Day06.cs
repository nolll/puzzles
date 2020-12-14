using System;
using Core.Orbits;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day06 : Day2019
    {
        public Day06() : base(6)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var calculator = new OrbitCalculator(FileInput);
            var orbitCount = calculator.GetOrbitCount();
            return new PuzzleResult(orbitCount, 278_744);
        }

        public override PuzzleResult RunPart2()
        {
            var calculator = new OrbitCalculator(FileInput);
            var distance = calculator.GetSantaDistance();
            return new PuzzleResult(distance, 475);
        }
    }
}