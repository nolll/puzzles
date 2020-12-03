using System;
using Core.FuelSquare;

namespace ConsoleApp.Years.Year2018.Days
{
    public class Day11 : Day2018
    {
        public Day11() : base(11)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var grid1 = new PowerGrid(300, NumberInput);
            var maxCoords = grid1.GetMaxCoords();
            var strCoords = $"{maxCoords.X},{maxCoords.Y}";
            Console.WriteLine($"Max power coords: {strCoords}");

            WritePartTitle();
            var grid2 = new PowerGrid(300, NumberInput);
            var (coords2, size2) = grid2.GetMaxCoordsAnySize();
            var strCoordsAndSize2 = $"{coords2.X},{coords2.Y},{size2}";
            Console.WriteLine($"Max power coords and size fast: {strCoordsAndSize2}");
        }

        private const int NumberInput = 1309;
    }
}