using System;
using Core.ImpossibleTriangles;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day03 : Day2016
    {
        public Day03() : base(3)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var validator = new TriangleValidator();
            var horizontalValidCount = validator.GetHorizontalValidCount(FileInput);
            Console.WriteLine($"Valid horizontal triangles: {horizontalValidCount}");

            WritePartTitle();
            var verticalValidCount = validator.GetVerticalValidCount(FileInput);
            Console.WriteLine($"Valid vertical triangles: {verticalValidCount}");
        }
    }
}