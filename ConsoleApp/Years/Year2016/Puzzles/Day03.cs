using System;
using Core.ImpossibleTriangles;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day03 : Day2016
    {
        public Day03() : base(3)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var validator = new TriangleValidator();
            var horizontalValidCount = validator.GetHorizontalValidCount(FileInput);
            return new PuzzleResult($"Valid horizontal triangles: {horizontalValidCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var validator = new TriangleValidator();
            var verticalValidCount = validator.GetVerticalValidCount(FileInput);
            return new PuzzleResult($"Valid vertical triangles: {verticalValidCount}");
        }
    }
}