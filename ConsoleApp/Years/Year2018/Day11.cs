using System;
using Core.FuelSquare;

namespace ConsoleApp.Years.Year2018
{
    public class Day11 : Day
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var grid1 = new PowerGrid(300, Input);
            var maxCoords = grid1.GetMaxCoords();
            var strCoords = $"{maxCoords.X},{maxCoords.Y}";
            Console.WriteLine($"Max power coords: {strCoords}");

            WritePartTitle();
            var grid2 = new PowerGrid(5, Input);
            var (coords2, size2) = grid2.GetMaxCoordsAnySizeSlow();
            var strCoordsAndSize2 = $"{coords2.X},{coords2.Y},{size2}";
            Console.WriteLine($"Max power coords and size slow: {strCoordsAndSize2}");

            var (coords3, size3) = grid2.GetMaxCoordsAnySizeFast();
            var strCoordsAndSize3 = $"{coords3.X},{coords3.Y},{size3}";
            Console.WriteLine($"Max power coords and size fast: {strCoordsAndSize3}");
        }

        private const int Input = 1309;
    }
}