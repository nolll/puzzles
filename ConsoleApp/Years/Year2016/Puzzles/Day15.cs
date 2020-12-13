using System;
using Core.KineticSculptureTiming;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day15 : Day2016
    {
        public Day15() : base(15)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var sculpture = new KineticSculpture(FileInput);
            return new PuzzleResult(sculpture.TimeToPressButton, 317_371);
        }

        public override PuzzleResult RunPart2()
        {
            var sculpture = new KineticSculpture(FileInput, true);
            return new PuzzleResult(sculpture.TimeToPressButton, 2_080_951);
        }
    }
}