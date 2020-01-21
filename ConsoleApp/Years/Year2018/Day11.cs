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
            var grid = new PowerGrid(Input);
            var maxCoords = grid.GetMaxCoords();
            var strCoords = $"{maxCoords.X},{maxCoords.Y}";
            Console.WriteLine($"Max power coords: {strCoords}");

            WritePartTitle();
            var (coords, size) = grid.GetMaxCoordsAnySize();
            var strCoordsAndSize = $"{coords.X},{coords.Y},{size}";
            Console.WriteLine($"Max power coords and size: {strCoordsAndSize}");
        }

        private const int Input = 1309;
    }
}